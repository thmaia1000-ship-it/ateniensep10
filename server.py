#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Servidor Web Master Escolar Ateniense
Backend RESTful e servidor de arquivos estáticos multithreaded.
"""

import os
import sys
import json
import urllib.parse
from http.server import ThreadingHTTPServer, BaseHTTPRequestHandler
from datetime import datetime

# Adiciona diretório base ao sys.path
BASE_DIR = os.path.dirname(os.path.abspath(__file__))
if BASE_DIR not in sys.path:
    sys.path.insert(0, BASE_DIR)

from database.db import query_all, query_one, execute
import services.auth as auth_service
import services.secretaria as secretaria_service
import services.financeiro as financeiro_service
import services.academico as academico_service
import services.contabil as contabil_service
import services.produtos as produtos_service
import services.cursos as cursos_service
import services.documentos as documentos_service
import import_database

class AtenienseHandler(BaseHTTPRequestHandler):
    
    def log_message(self, format, *args):
        try:
            sys.stderr.write(f"[{datetime.now().strftime('%H:%M:%S')}] {format % args}\n")
        except Exception:
            pass

    def send_json(self, data, status=200):
        body = json.dumps(data, ensure_ascii=False, default=str).encode('utf-8')
        self.send_response(status)
        self.send_header('Content-Type', 'application/json; charset=utf-8')
        self.send_header('Content-Length', str(len(body)))
        self.send_header('Access-Control-Allow-Origin', '*')
        self.send_header('Access-Control-Allow-Methods', 'GET, POST, PUT, DELETE, OPTIONS')
        self.send_header('Access-Control-Allow-Headers', 'Content-Type, Authorization')
        self.end_headers()
        self.wfile.write(body)

    def send_file(self, filepath, content_type):
        if not os.path.exists(filepath):
            self.send_error(404, "Arquivo não encontrado")
            return
        with open(filepath, 'rb') as f:
            content = f.read()
        self.send_response(200)
        self.send_header('Content-Type', content_type)
        self.send_header('Content-Length', str(len(content)))
        self.end_headers()
        self.wfile.write(content)

    def do_OPTIONS(self):
        self.send_response(200)
        self.send_header('Access-Control-Allow-Origin', '*')
        self.send_header('Access-Control-Allow-Methods', 'GET, POST, PUT, DELETE, OPTIONS')
        self.send_header('Access-Control-Allow-Headers', 'Content-Type, Authorization')
        self.end_headers()

    def get_user_from_header(self):
        auth_header = self.headers.get('Authorization', '')
        if auth_header.startswith('Bearer '):
            token = auth_header[7:].strip()
            return auth_service.get_current_user(token)
        return None

    def read_json_body(self):
        content_length = int(self.headers.get('Content-Length', 0))
        if content_length > 0:
            body = self.rfile.read(content_length).decode('utf-8')
            return json.loads(body)
        return {}

    def do_GET(self):
        parsed = urllib.parse.urlparse(self.path)
        path = parsed.path
        query = urllib.parse.parse_qs(parsed.query)

        # 1. Roteamento de Arquivos Estáticos e UI
        if path == '/' or path == '/index.html':
            self.send_file(os.path.join(BASE_DIR, 'templates', 'index.html'), 'text/html; charset=utf-8')
            return
            
        if path.startswith('/static/'):
            rel_path = path[8:]
            full_path = os.path.join(BASE_DIR, 'static', rel_path)
            content_type = 'application/octet-stream'
            if path.endswith('.css'): content_type = 'text/css'
            elif path.endswith('.js'): content_type = 'application/javascript'
            elif path.endswith('.png'): content_type = 'image/png'
            elif path.endswith('.jpg') or path.endswith('.jpeg'): content_type = 'image/jpeg'
            elif path.endswith('.svg'): content_type = 'image/svg+xml'
            elif path.endswith('.ico'): content_type = 'image/x-icon'
            self.send_file(full_path, content_type)
            return

        # 2. Rotas de API REST
        try:
            # Usuário Atual
            if path == '/api/auth/me':
                user = self.get_user_from_header()
                if user:
                    self.send_json({'user': user})
                else:
                    self.send_json({'error': 'Não autenticado'}, 401)
                return

            # Dashboard Stats - Mês Vigente
            if path == '/api/dashboard':
                from datetime import datetime
                now = datetime.now()
                mes_vigente_str = now.strftime('%Y-%m')
                meses_nomes = ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro']
                mes_extenso = f"{meses_nomes[now.month - 1]} de {now.year}"

                total_alunos = query_one("SELECT COUNT(*) as c FROM tb_alunos WHERE status != 'INATIVO'")['c']
                total_turmas = query_one("SELECT COUNT(*) as c FROM tb_turmas")['c']

                # 1. Faturamento do Mês Atual (Entradas faturadas no caixa no mês corrente)
                faturamento_mes = query_one("""
                    SELECT 
                        COALESCE(SUM(CAST(valor_total AS REAL)), 0.0) as total,
                        COUNT(*) as qtd
                    FROM tb_caixa 
                    WHERE tipo_movimentacao = 'ENTRADA'
                      AND strftime('%Y-%m', data) = ?
                """, (mes_vigente_str,))
                faturamento_mes_total = faturamento_mes['total'] if faturamento_mes else 0.0
                faturamento_mes_qtd = faturamento_mes['qtd'] if faturamento_mes else 0

                # 2. Mensalidades a Receber do Mês Vigente
                contratos = query_all("""
                    SELECT 
                        m.ID_mensalidade,
                        m.n_parcelas,
                        m.parcelas_pagas,
                        CAST(m.valor_parcela AS REAL) as valor_parcela,
                        CAST(m.saldo_devedor AS REAL) as saldo_devedor,
                        m.data_inicio
                    FROM tb_mensalidades m
                    JOIN tb_alunos a ON m.idaluno = a.ID_aluno
                    WHERE m.ano_letivo = ? 
                      AND a.status != 'INATIVO' 
                      AND CAST(m.saldo_devedor AS REAL) > 0
                """, (now.year,))

                mensalidades_receber_qtd = 0
                mensalidades_receber_total = 0.0

                for c in contratos:
                    try:
                        start_month = int(c['data_inicio'].split('-')[1])
                    except:
                        start_month = 1
                    
                    parcela_mes = (now.month - start_month) + 1
                    n_parc = int(c['n_parcelas'] or 12)
                    pagas = int(c['parcelas_pagas'] or 0)

                    if 1 <= parcela_mes <= n_parc:
                        if pagas < parcela_mes:
                            mensalidades_receber_qtd += 1
                            v_devido = min(c['valor_parcela'], c['saldo_devedor'])
                            mensalidades_receber_total += v_devido
                    elif parcela_mes > n_parc and c['saldo_devedor'] > 0:
                        mensalidades_receber_qtd += 1
                        v_devido = min(c['valor_parcela'], c['saldo_devedor'])
                        mensalidades_receber_total += v_devido

                # 3. Lançamentos faturados no mês vigente
                lancamentos_mes = query_all("""
                    SELECT * FROM tb_caixa 
                    WHERE strftime('%Y-%m', data) = ?
                    ORDER BY data DESC, ID_caixa DESC
                    LIMIT 20
                """, (mes_vigente_str,))

                self.send_json({
                    'total_alunos': total_alunos,
                    'total_turmas': total_turmas,
                    'mes_vigente': mes_extenso,
                    'faturamento_mes_total': faturamento_mes_total,
                    'faturamento_mes_qtd': faturamento_mes_qtd,
                    'mensalidades_a_receber_mes_total': mensalidades_receber_total,
                    'mensalidades_a_receber_mes_qtd': mensalidades_receber_qtd,
                    'ultimos_lancamentos': lancamentos_mes
                })
                return

            # Alunos
            if path == '/api/alunos':
                busca = query.get('busca', [''])[0]
                status = query.get('status', [''])[0]
                turma_id = query.get('turma_id', [None])[0]
                limit = int(query.get('limit', [100])[0])
                offset = int(query.get('offset', [0])[0])
                alunos = secretaria_service.list_alunos(busca, status, turma_id, limit, offset)
                total = secretaria_service.count_alunos(busca, status, turma_id)
                self.send_json({'alunos': alunos, 'total': total})
                return

            if path.startswith('/api/alunos/'):
                parts = path.split('/')
                aluno_id = parts[3]
                dados = secretaria_service.get_aluno(aluno_id)
                if dados:
                    self.send_json(dados)
                else:
                    self.send_json({'error': 'Aluno não encontrado'}, 404)
                return

            # Turmas & Professores
            if path == '/api/turmas':
                self.send_json({'turmas': secretaria_service.list_turmas()})
                return

            if path.startswith('/api/turmas/') and path.endswith('/alunos'):
                turma_id = path.split('/')[3]
                self.send_json({'alunos': secretaria_service.get_alunos_turma(turma_id)})
                return

            if path == '/api/professores':
                self.send_json({'professores': secretaria_service.list_professores()})
                return

            # Responsáveis
            if path == '/api/responsaveis':
                tipo = query.get('tipo', ['financeiro'])[0]
                busca = query.get('busca', [''])[0]
                self.send_json({'responsaveis': secretaria_service.list_responsaveis(tipo, busca)})
                return

            # Financeiro: Caixa & Mensalidades
            if path == '/api/caixa':
                dt_ini = query.get('data_inicio', [None])[0]
                dt_fim = query.get('data_fim', [None])[0]
                tipo = query.get('tipo', [None])[0]
                busca = query.get('busca', [None])[0]
                limit = int(query.get('limit', [100])[0])
                itens = financeiro_service.list_caixa(dt_ini, dt_fim, tipo, busca, limit)
                saldo = financeiro_service.get_saldo_caixa()
                self.send_json({'caixa': itens, 'saldo': saldo})
                return

            if path == '/api/mensalidades':
                status = query.get('status', ['todas'])[0]
                busca = query.get('busca', [''])[0]
                limit = int(query.get('limit', [100])[0])
                self.send_json({'mensalidades': financeiro_service.list_mensalidades(status, busca, limit)})
                return

            if path == '/api/financeiro/tabela-mensalidades':
                self.send_json({'tabela': financeiro_service.list_tabela_mensalidades()})
                return

            if path.startswith('/api/mensalidades/carne/'):
                aluno_id = path.split('/')[4]
                self.send_json(financeiro_service.gerar_carne_dados(aluno_id))
                return

            # Acadêmico: Boletim, Diário, Matérias, Faltas
            if path.startswith('/api/boletim/'):
                aluno_id = path.split('/')[3]
                ano = query.get('ano', [None])[0]
                boletim = academico_service.get_boletim(aluno_id, ano)
                self.send_json(boletim or {'error': 'Não encontrado'})
                return

            if path == '/api/diario':
                turma_id = query.get('turma_id', [None])[0]
                busca = query.get('busca', [None])[0]
                self.send_json({'diario': academico_service.list_diario(turma_id, busca)})
                return

            if path == '/api/materias':
                self.send_json({'materias': academico_service.list_materias()})
                return

            if path == '/api/bimestres':
                self.send_json({'bimestres': academico_service.list_bimestres()})
                return

            if path == '/api/faltas':
                turma_id = query.get('turma_id', [None])[0]
                self.send_json({'faltas': academico_service.list_faltas(turma_id)})
                return

            # Contábil & DRE
            if path == '/api/despesas':
                dt_ini = query.get('data_inicio', [None])[0]
                dt_fim = query.get('data_fim', [None])[0]
                self.send_json({'despesas': contabil_service.list_despesas(dt_ini, dt_fim)})
                return

            if path == '/api/dre':
                ano = query.get('ano', [None])[0]
                self.send_json(contabil_service.get_dre(ano))
                return

            # Produtos & Vendas
            if path == '/api/produtos':
                busca = query.get('busca', [''])[0]
                self.send_json({'produtos': produtos_service.list_produtos(busca)})
                return

            if path == '/api/vendas':
                self.send_json({'vendas': produtos_service.list_vendas()})
                return

            # Cursos Livres
            if path == '/api/cursos':
                self.send_json({'cursos': cursos_service.list_cursos()})
                return

            if path == '/api/cursos/mensalidades':
                self.send_json({'mensalidades': cursos_service.list_mensalidades_cursos()})
                return

            # Documentos Oficiais
            if path == '/api/documentos/dados':
                aluno_id = query.get('aluno_id', [None])[0]
                if aluno_id:
                    self.send_json(documentos_service.get_dados_completos_aluno(aluno_id))
                else:
                    self.send_json({'error': 'aluno_id obrigatório'}, 400)
                return

            if path == '/api/documentos/recibo':
                caixa_id = query.get('caixa_id', [None])[0]
                if caixa_id:
                    self.send_json(documentos_service.get_recibo_dados(caixa_id))
                else:
                    self.send_json({'error': 'caixa_id obrigatório'}, 400)
                return

            if path == '/api/documentos/declaracao':
                tipo = query.get('tipo', ['matricula'])[0]
                aluno_id = query.get('aluno_id', [None])[0]
                if not aluno_id:
                    self.send_json({'error': 'aluno_id é obrigatório'}, 400)
                    return
                extra = {k: v[0] for k, v in query.items() if k not in ['tipo', 'aluno_id']}
                dados = documentos_service.get_declaracao(tipo, aluno_id, extra)
                self.send_json(dados)
                return

            # Usuários
            if path == '/api/usuarios':
                self.send_json({'usuarios': auth_service.list_users()})
                return

            self.send_json({'error': 'Rota não encontrada'}, 404)
        except Exception as e:
            self.send_json({'error': str(e)}, 500)

    def do_POST(self):
        parsed = urllib.parse.urlparse(self.path)
        path = parsed.path
        body = self.read_json_body()
        user = self.get_user_from_header()
        username = user['username'] if user else 'ADMIN'

        try:
            # Login
            if path == '/api/auth/login':
                u = body.get('username')
                p = body.get('password')
                res = auth_service.authenticate(u, p)
                if res:
                    self.send_json(res)
                else:
                    self.send_json({'error': 'Usuário ou senha inválidos'}, 401)
                return

            if path == '/api/auth/logout':
                token = body.get('token')
                auth_service.logout(token)
                self.send_json({'success': True})
                return

            # Aluno Criar
            if path == '/api/alunos':
                new_id = secretaria_service.create_aluno(body, username)
                self.send_json({'id': new_id, 'message': 'Aluno cadastrado com sucesso!'})
                return

            # Turma Criar
            if path == '/api/turmas':
                new_id = secretaria_service.create_turma(body, username)
                self.send_json({'id': new_id, 'message': 'Turma cadastrada com sucesso!'})
                return

            # Professor Criar
            if path == '/api/professores':
                new_id = secretaria_service.create_professor(body)
                self.send_json({'id': new_id, 'message': 'Professor cadastrado com sucesso!'})
                return

            # Caixa Lançar
            if path == '/api/caixa':
                new_id = financeiro_service.create_movimentacao(body, username)
                self.send_json({'id': new_id, 'message': 'Lançamento registrado com sucesso!'})
                return

            # Pagar Mensalidade
            if path == '/api/mensalidades/pagar':
                mid = body.get('mensalidade_id')
                qtd = int(body.get('quantidade_parcelas', 1))
                forma = body.get('forma_pagamento', 'DINHEIRO')
                obs = body.get('observacao', '')
                res = financeiro_service.pagar_mensalidade(mid, qtd, forma, username, obs)
                self.send_json(res)
                return

            # Criar Tabela de Mensalidade
            if path == '/api/financeiro/tabela-mensalidades':
                new_id = financeiro_service.create_tabela_mensalidade(body)
                self.send_json({'id': new_id, 'message': 'Configuração de mensalidade cadastrada com sucesso!'})
                return

            # Lançar Nota
            if path == '/api/notas':
                aid = body.get('aluno_id')
                mid = body.get('materia_id')
                bim = body.get('bimestre')
                nota = body.get('nota')
                ano = body.get('ano_letivo', datetime.now().strftime('%Y'))
                res = academico_service.lancar_nota(aid, mid, bim, nota, ano, username)
                self.send_json({'id': res, 'message': 'Nota gravada com sucesso!'})
                return

            # Diário Criar
            if path == '/api/diario':
                res = academico_service.create_diario(body, username)
                self.send_json({'id': res, 'message': 'Registro de diário salvo com sucesso!'})
                return

            # Despesa Criar
            if path == '/api/despesas':
                res = contabil_service.create_despesa(body, username)
                self.send_json({'id': res, 'message': 'Despesa registrada com sucesso!'})
                return

            # Produto Criar
            if path == '/api/produtos':
                res = produtos_service.create_produto(body, username)
                self.send_json({'id': res, 'message': 'Produto cadastrado com sucesso!'})
                return

            # Venda PDV
            if path == '/api/vendas':
                cliente = body.get('cliente_nome', 'CONSUMIDOR')
                itens = body.get('itens', [])
                forma = body.get('forma_pagamento', 'DINHEIRO')
                obs = body.get('observacao', '')
                res = produtos_service.realizar_venda(cliente, itens, forma, username, obs)
                self.send_json(res)
                return

            # Curso Criar
            if path == '/api/cursos':
                res = cursos_service.create_curso(body)
                self.send_json({'id': res, 'message': 'Curso cadastrado com sucesso!'})
                return

            # Usuário Criar
            if path == '/api/usuarios':
                res = auth_service.create_user(body.get('nome'), body.get('username'), body.get('senha'), body.get('nivel', 1))
                self.send_json({'id': res, 'message': 'Usuário criado com sucesso!'})
                return

            # Reimportar Banco de Dados
            if path == '/api/database/reimport':
                caminho = body.get('caminho_arquivo')
                sql_content = body.get('sql_content')
                sql_base64 = body.get('sql_base64')
                
                target_path = None
                if sql_base64:
                    import base64
                    target_path = os.path.join(BASE_DIR, 'database', 'uploaded_db.sql')
                    with open(target_path, 'wb') as f:
                        f.write(base64.b64decode(sql_base64))
                elif sql_content:
                    target_path = os.path.join(BASE_DIR, 'database', 'uploaded_db.sql')
                    with open(target_path, 'w', encoding='utf-8') as f:
                        f.write(sql_content)
                elif caminho:
                    target_path = caminho.strip()
                    if not os.path.exists(target_path):
                        self.send_json({'success': False, 'error': f"Arquivo não encontrado no diretório: {target_path}"}, 400)
                        return
                        
                res = import_database.import_sql(target_path)
                if res and res.get('success'):
                    self.send_json({
                        'success': True,
                        'message': f"Banco de dados importado com sucesso a partir de {os.path.basename(res.get('file', 'dbateniense.sql'))}!",
                        'detalhes': res
                    })
                else:
                    self.send_json({'success': False, 'error': res.get('error', 'Falha ao importar o arquivo SQL.')}, 500)
                return

            self.send_json({'error': 'Rota POST não encontrada'}, 404)
        except Exception as e:
            self.send_json({'error': str(e)}, 500)

    def do_PUT(self):
        parsed = urllib.parse.urlparse(self.path)
        path = parsed.path
        body = self.read_json_body()

        try:
            if path.startswith('/api/alunos/'):
                aluno_id = path.split('/')[3]
                secretaria_service.update_aluno(aluno_id, body)
                self.send_json({'message': 'Aluno atualizado com sucesso!'})
                return

            if path.startswith('/api/produtos/'):
                prod_id = path.split('/')[3]
                produtos_service.update_produto(prod_id, body)
                self.send_json({'message': 'Produto atualizado com sucesso!'})
                return

            if path.startswith('/api/financeiro/tabela-mensalidades/'):
                item_id = int(path.split('/')[4])
                res = financeiro_service.update_tabela_mensalidade(item_id, body)
                self.send_json(res)
                return

            if path.startswith('/api/cursos/'):
                curso_id = int(path.split('/')[3])
                res = cursos_service.update_curso(curso_id, body)
                self.send_json({'message': 'Curso atualizado com sucesso!', 'curso': res})
                return

            if path.startswith('/api/bimestres/'):
                b_id = int(path.split('/')[3])
                res = academico_service.update_bimestre(b_id, body.get('data_inicio'), body.get('data_fim'))
                self.send_json({'message': 'Bimestre atualizado com sucesso!', 'bimestre': res})
                return

            self.send_json({'error': 'Rota PUT não encontrada'}, 404)
        except Exception as e:
            self.send_json({'error': str(e)}, 500)

    def do_DELETE(self):
        parsed = urllib.parse.urlparse(self.path)
        path = parsed.path

        try:
            if path.startswith('/api/alunos/'):
                aluno_id = path.split('/')[3]
                secretaria_service.delete_aluno(aluno_id)
                self.send_json({'message': 'Aluno excluído com sucesso!'})
                return

            if path.startswith('/api/produtos/'):
                prod_id = path.split('/')[3]
                produtos_service.delete_produto(prod_id)
                self.send_json({'message': 'Produto excluído com sucesso!'})
                return

            if path.startswith('/api/usuarios/'):
                user_id = path.split('/')[3]
                auth_service.delete_user(user_id)
                self.send_json({'message': 'Usuário excluído com sucesso!'})
                return

            if path.startswith('/api/financeiro/tabela-mensalidades/'):
                item_id = int(path.split('/')[4])
                financeiro_service.delete_tabela_mensalidade(item_id)
                self.send_json({'message': 'Configuração de mensalidade excluída com sucesso!'})
                return

            if path.startswith('/api/cursos/'):
                curso_id = int(path.split('/')[3])
                cursos_service.delete_curso(curso_id)
                self.send_json({'message': 'Curso excluído com sucesso!'})
                return

            self.send_json({'error': 'Rota DELETE não encontrada'}, 404)
        except Exception as e:
            self.send_json({'error': str(e)}, 500)

def run(port=8080):
    server_address = ('0.0.0.0', port)
    httpd = ThreadingHTTPServer(server_address, AtenienseHandler)
    print(f"==================================================")
    print(f"🎓 MASTER ESCOLAR ATENIENSE - PLATAFORMA WEB ONLINE")
    print(f"🔗 Servidor rodando em http://localhost:{port}")
    print(f"==================================================")
    try:
        httpd.serve_forever()
    except KeyboardInterrupt:
        print("\nServidor encerrado.")
        httpd.server_close()

if __name__ == '__main__':
    port = int(sys.argv[1]) if len(sys.argv) > 1 else 8080
    run(port)
