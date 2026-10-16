# -*- coding: utf-8 -*-
"""
Serviço Financeiro: Caixa, Mensalidades, Pagamentos, Recibos de Entrada e Saída
"""

from datetime import datetime
from database.db import query_all, query_one, execute

def get_saldo_caixa():
    res = query_one("""
    SELECT 
        COALESCE(SUM(CASE WHEN UPPER(tipo_movimentacao) LIKE '%ENTRADA%' THEN CAST(valor_total AS REAL) ELSE 0 END), 0) as total_entradas,
        COALESCE(SUM(CASE WHEN UPPER(tipo_movimentacao) LIKE '%SA%' THEN CAST(valor_total AS REAL) ELSE 0 END), 0) as total_saidas
    FROM tb_caixa
    """)
    entradas = res['total_entradas'] if res else 0.0
    saidas = res['total_saidas'] if res else 0.0
    return {
        'total_entradas': entradas,
        'total_saidas': saidas,
        'saldo_atual': entradas - saidas
    }

def list_caixa(data_inicio=None, data_fim=None, tipo=None, busca=None, limit=100, offset=0):
    params = []
    where_clauses = []
    
    if data_inicio:
        where_clauses.append("data >= ?")
        params.append(data_inicio)
    if data_fim:
        where_clauses.append("data <= ?")
        params.append(data_fim)
    if tipo:
        where_clauses.append("UPPER(tipo_movimentacao) LIKE ?")
        params.append(f"%{tipo.upper()}%")
    if busca:
        where_clauses.append("(nome LIKE ? OR descricao LIKE ? OR usuario LIKE ?)")
        params.extend([f"%{busca}%", f"%{busca}%", f"%{busca}%"])
        
    where_str = ("WHERE " + " AND ".join(where_clauses)) if where_clauses else ""
    
    sql = f"""
    SELECT 
        ID_caixa as id,
        valor_total,
        forma,
        tipo_movimentacao,
        nome,
        descricao,
        usuario,
        data,
        horario,
        curso,
        observacao,
        idaluno,
        idmensalidade
    FROM tb_caixa
    {where_str}
    ORDER BY ID_caixa DESC
    LIMIT ? OFFSET ?
    """
    params.extend([limit, offset])
    return query_all(sql, tuple(params))

def create_movimentacao(data, usuario='ADMIN'):
    hoje = datetime.now()
    data_str = data.get('data') or hoje.strftime('%Y-%m-%d')
    hora_str = data.get('horario') or hoje.strftime('%H:%M:%S')
    
    return execute("""
    INSERT INTO tb_caixa (
        valor_total, forma, tipo_movimentacao, nome, descricao,
        usuario, data, horario, curso, observacao, idaluno
    ) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
    """, (
        data.get('valor_total', 0.0),
        data.get('forma', 'DINHEIRO'),
        data.get('tipo_movimentacao', 'ENTRADA'),
        data.get('nome', ''),
        data.get('descricao', ''),
        usuario,
        data_str,
        hora_str,
        data.get('curso', 'ENSINO REGULAR'),
        data.get('observacao', ''),
        data.get('idaluno')
    ))

def list_mensalidades(status='todas', busca='', limit=100, offset=0):
    params = []
    where_clauses = []
    
    if busca:
        where_clauses.append("(a.nome_aluno LIKE ? OR m.ID_mensalidade = ?)")
        params.extend([f"%{busca}%", busca if busca.isdigit() else -1])
        
    if status == 'aberto':
        where_clauses.append("CAST(m.saldo_devedor AS REAL) > 0")
    elif status == 'pago':
        where_clauses.append("CAST(m.saldo_devedor AS REAL) <= 0")
        
    where_str = ("WHERE " + " AND ".join(where_clauses)) if where_clauses else ""
    
    sql = f"""
    SELECT 
        m.ID_mensalidade as id,
        m.n_parcelas,
        m.valor_total,
        m.saldo_devedor,
        m.valor_parcela,
        m.data_inicio,
        m.parcelas_pagas,
        m.ano_letivo,
        m.curso,
        m.turno,
        a.nome_aluno,
        a.ID_aluno as idaluno,
        r.nome as responsavel_nome,
        r.telefone as responsavel_telefone
    FROM tb_mensalidades m
    LEFT JOIN tb_alunos a ON m.idaluno = a.ID_aluno
    LEFT JOIN tb_responsavel_financeiro r ON a.ID_aluno = r.idaluno
    {where_str}
    ORDER BY m.ID_mensalidade DESC
    LIMIT ? OFFSET ?
    """
    params.extend([limit, offset])
    return query_all(sql, tuple(params))

def pagar_mensalidade(mensalidade_id, qtd_parcelas, forma_pagamento, usuario='ADMIN', observacao=''):
    m = query_one("SELECT * FROM tb_mensalidades WHERE ID_mensalidade = ?", (mensalidade_id,))
    if not m:
        raise ValueError("Mensalidade não encontrada")
        
    valor_parcela = float(m['valor_parcela'] or 0)
    parcelas_pagas_atual = int(m['parcelas_pagas'] or 0)
    n_parcelas = int(m['n_parcelas'] or 0)
    saldo_devedor = float(m['saldo_devedor'] or 0)
    
    total_a_pagar = valor_parcela * qtd_parcelas
    novas_parcelas_pagas = parcelas_pagas_atual + qtd_parcelas
    novo_saldo_devedor = max(0.0, saldo_devedor - total_a_pagar)
    
    # Atualiza tb_mensalidades
    execute("""
    UPDATE tb_mensalidades 
    SET parcelas_pagas = ?, saldo_devedor = ?
    WHERE ID_mensalidade = ?
    """, (novas_parcelas_pagas, f"{novo_saldo_devedor:.2f}", mensalidade_id))
    
    # Aluno
    aluno = query_one("SELECT nome_aluno FROM tb_alunos WHERE ID_aluno = ?", (m['idaluno'],))
    aluno_nome = aluno['nome_aluno'] if aluno else "ALUNO"
    
    hoje = datetime.now()
    desc = f"PAGAMENTO DE MENSALIDADE ({qtd_parcelas} PARCELA(S)) - PARCELAS {parcelas_pagas_atual+1} A {novas_parcelas_pagas}"
    
    # Lança no Caixa
    caixa_id = execute("""
    INSERT INTO tb_caixa (
        valor_total, forma, tipo_movimentacao, nome, descricao,
        usuario, data, horario, curso, observacao, idaluno, mensalidades_paga, idmensalidade
    ) VALUES (?, ?, 'ENTRADA', ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
    """, (
        f"{total_a_pagar:.2f}",
        forma_pagamento,
        aluno_nome,
        desc,
        usuario,
        hoje.strftime('%Y-%m-%d'),
        hoje.strftime('%H:%M:%S'),
        m['curso'] or 'ENSINO REGULAR',
        observacao,
        m['idaluno'],
        qtd_parcelas,
        mensalidade_id
    ))
    
    return {
        'caixa_id': caixa_id,
        'mensalidade_id': mensalidade_id,
        'total_pago': total_a_pagar,
        'saldo_restante': novo_saldo_devedor,
        'parcelas_pagas': novas_parcelas_pagas,
        'aluno_nome': aluno_nome
    }

def gerar_carne_dados(aluno_id):
    aluno_data = query_one("""
    SELECT a.ID_aluno, a.nome_aluno, a.etapa, a.turno, a.ano_letivo,
           rf.nome as resp_nome, rf.CPF as resp_cpf, rf.telefone as resp_tel,
           rf.rua, rf.bairro, rf.numero, rf.CEP
    FROM tb_alunos a
    LEFT JOIN tb_responsavel_financeiro rf ON a.ID_aluno = rf.idaluno
    WHERE a.ID_aluno = ?
    """, (aluno_id,))
    
    mensalidade = query_one("""
    SELECT * FROM tb_mensalidades 
    WHERE idaluno = ? 
    ORDER BY ID_mensalidade DESC LIMIT 1
    """, (aluno_id,))
    
    return {
        'aluno': aluno_data,
        'mensalidade': mensalidade
    }

# --- GESTÃO DE VALORES DE MENSALIDADES POR CURSO E HORÁRIO ---

def list_tabela_mensalidades():
    return query_all("""
    SELECT 
        id,
        curso,
        etapa,
        turno,
        horario_descricao,
        valor_mensalidade,
        n_parcelas_padrao,
        ano_vigente,
        ativo
    FROM tb_tabela_mensalidades
    ORDER BY curso ASC, turno ASC, id ASC
    """)

def get_tabela_mensalidade(item_id):
    return query_one("SELECT * FROM tb_tabela_mensalidades WHERE id = ?", (item_id,))

def create_tabela_mensalidade(data):
    return execute("""
    INSERT INTO tb_tabela_mensalidades (
        curso, etapa, turno, horario_descricao, valor_mensalidade, n_parcelas_padrao, ano_vigente, ativo
    ) VALUES (?, ?, ?, ?, ?, ?, ?, 1)
    """, (
        data.get('curso', 'Educação Infantil'),
        data.get('etapa', 'Todas as Etapas'),
        data.get('turno', 'MATUTINO'),
        data.get('horario_descricao', ''),
        float(data.get('valor_mensalidade', 0.0)),
        int(data.get('n_parcelas_padrao', 12)),
        data.get('ano_vigente', '2026')
    ))

def update_tabela_mensalidade(item_id, data):
    novo_valor = float(data.get('valor_mensalidade', 0.0))
    horario_desc = data.get('horario_descricao', '')
    n_parcelas = int(data.get('n_parcelas_padrao', 12))
    ano = data.get('ano_vigente', '2026')
    reajustar_ativos = bool(data.get('reajustar_contratos_ativos', False))

    # Pega valores atuais do registro
    atual = query_one("SELECT * FROM tb_tabela_mensalidades WHERE id = ?", (item_id,))
    if not atual:
        raise ValueError("Configuração de mensalidade não encontrada")

    curso = data.get('curso', atual['curso'])
    turno = data.get('turno', atual['turno'])
    etapa = data.get('etapa', atual['etapa'])

    execute("""
    UPDATE tb_tabela_mensalidades SET
        curso = ?,
        etapa = ?,
        turno = ?,
        horario_descricao = ?,
        valor_mensalidade = ?,
        n_parcelas_padrao = ?,
        ano_vigente = ?
    WHERE id = ?
    """, (curso, etapa, turno, horario_desc, novo_valor, n_parcelas, ano, item_id))

    contratos_afetados = 0
    # Se solicitado, reajusta contratos em aberto do curso e turno
    if reajustar_ativos:
        contratos = query_all("""
        SELECT ID_mensalidade, n_parcelas, parcelas_pagas, saldo_devedor 
        FROM tb_mensalidades 
        WHERE curso LIKE ? AND turno LIKE ? AND CAST(saldo_devedor AS REAL) > 0
        """, (f"%{curso}%", f"%{turno}%"))

        for c in contratos:
            tot_parcelas = int(c['n_parcelas'] or 12)
            pagas = int(c['parcelas_pagas'] or 0)
            restantes = max(0, tot_parcelas - pagas)
            novo_saldo = restantes * novo_valor
            execute("""
            UPDATE tb_mensalidades SET
                valor_parcela = ?,
                saldo_devedor = ?
            WHERE ID_mensalidade = ?
            """, (f"{novo_valor:.2f}", f"{novo_saldo:.2f}", c['ID_mensalidade']))
            contratos_afetados += 1

    return {
        'id': item_id,
        'valor_mensalidade': novo_valor,
        'contratos_reajustados': contratos_afetados,
        'message': f"Valor atualizado com sucesso para R$ {novo_valor:.2f}." + (f" ({contratos_afetados} contratos ativos reajustados)" if contratos_afetados > 0 else "")
    }

def delete_tabela_mensalidade(item_id):
    return execute("DELETE FROM tb_tabela_mensalidades WHERE id = ?", (item_id,))

