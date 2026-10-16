# -*- coding: utf-8 -*-
"""
Serviço de Documentos, Contratos, Declarações e Recibos Oficiais do Ateniense
"""

from datetime import datetime
from database.db import query_all, query_one

MESES_PT = {
    1: 'Janeiro', 2: 'Fevereiro', 3: 'Março', 4: 'Abril',
    5: 'Maio', 6: 'Junho', 7: 'Julho', 8: 'Agosto',
    9: 'Setembro', 10: 'Outubro', 11: 'Novembro', 12: 'Dezembro'
}

def get_data_extenso():
    hoje = datetime.now()
    return f"Manaus, {hoje.day} de {MESES_PT[hoje.month]} de {hoje.year}"

def format_data_br(data_str):
    if not data_str:
        return '-'
    try:
        parts = str(data_str).split(' ')[0].split('-')
        if len(parts) == 3:
            return f"{parts[2]}/{parts[1]}/{parts[0]}"
    except Exception:
        pass
    return str(data_str)

def get_dados_completos_aluno(aluno_id):
    aluno = query_one("""
    SELECT a.*, t.nome_turma, t.serie, t.turno as turma_turno 
    FROM tb_alunos a
    LEFT JOIN tb_alunos_turmas at ON a.ID_aluno = at.idaluno
    LEFT JOIN tb_turmas t ON at.idturma = t.ID_turma
    WHERE a.ID_aluno = ?
    """, (aluno_id,))
    
    if not aluno:
        return None
        
    aluno_dict = dict(aluno)
    aluno_dict['datanasc_formatada'] = format_data_br(aluno_dict.get('datanasc'))
    
    resp_acad = query_one("SELECT * FROM tb_responsavel_academico WHERE idaluno = ?", (aluno_id,))
    resp_fin = query_one("SELECT * FROM tb_responsavel_financeiro WHERE idaluno = ?", (aluno_id,))
    
    return {
        'aluno': aluno_dict,
        'resp_acad': resp_acad,
        'resp_fin': resp_fin,
        'data_extenso': get_data_extenso()
    }

def get_declaracao(tipo, aluno_id, params=None):
    if params is None:
        params = {}
        
    aluno_info = get_dados_completos_aluno(aluno_id)
    if not aluno_info or not aluno_info.get('aluno'):
        return {'error': 'Aluno não encontrado'}
        
    aluno = aluno_info['aluno']
    resp_acad = aluno_info['resp_acad'] or {}
    resp_fin = aluno_info['resp_fin'] or {}
    hoje = datetime.now()
    data_extenso = get_data_extenso()
    
    # 1. Busca mensalidades para quitação e rescisão
    mensalidade = query_one("""
        SELECT * FROM tb_mensalidades 
        WHERE idaluno = ? 
        ORDER BY ano_letivo DESC, ID_mensalidade DESC 
        LIMIT 1
    """, (aluno_id,))
    
    # 2. Busca faltas para declaração de frequência
    faltas_row = query_one("""
        SELECT COUNT(*) as total FROM tb_faltas_historico 
        WHERE idaluno = ? AND status = 'FALTOU'
    """, (aluno_id,))
    total_faltas = faltas_row['total'] if faltas_row else 0
    
    # 3. Busca notas para guia de transferência
    materias_notas = []
    if tipo == 'transferencia':
        from services.academico import get_boletim
        boletim_data = get_boletim(aluno_id, aluno.get('ano_letivo'))
        if boletim_data:
            materias_notas = boletim_data.get('materias', [])

    return {
        'tipo': tipo,
        'aluno': aluno,
        'resp_acad': resp_acad,
        'resp_fin': resp_fin,
        'mensalidade': mensalidade,
        'total_faltas': total_faltas,
        'materias_notas': materias_notas,
        'data_extenso': data_extenso,
        'hoje_iso': hoje.strftime('%Y-%m-%d'),
        'hoje_formatado': hoje.strftime('%d/%m/%Y'),
        'ano_letivo': aluno.get('ano_letivo') or hoje.year,
        'params': params
    }

def get_recibo_dados(caixa_id):
    caixa = query_one("SELECT * FROM tb_caixa WHERE ID_caixa = ?", (caixa_id,))
    if not caixa:
        return None
        
    aluno = None
    if caixa['idaluno']:
        aluno = query_one("SELECT nome_aluno, etapa, turno FROM tb_alunos WHERE ID_aluno = ?", (caixa['idaluno'],))
        
    return {
        'caixa': caixa,
        'aluno': aluno,
        'data_extenso': get_data_extenso()
    }

# ================= EXTENSO E FORMATAÇÃO DE CONTRATOS =================

UNIDADES = ['', 'um', 'dois', 'três', 'quatro', 'cinco', 'seis', 'sete', 'oito', 'nove',
            'dez', 'onze', 'doze', 'treze', 'quatorze', 'quinze', 'dezesseis',
            'dezessete', 'dezoito', 'dezenove']
DEZENAS = ['', '', 'vinte', 'trinta', 'quarenta', 'cinquenta', 'sessenta', 'setenta', 'oitenta', 'noventa']
CENTENAS = ['', 'cento', 'duzentos', 'trezentos', 'quatrocentos', 'quinhentos',
            'seiscentos', 'setecentos', 'oitocentos', 'novecentos']

def numero_extenso(n):
    try:
        n = int(n)
    except Exception:
        return str(n)
    if n == 0:
        return 'zero'
    if n == 100:
        return 'cem'
    if n < 20:
        return UNIDADES[n]
    if n < 100:
        d = DEZENAS[n // 10]
        u = UNIDADES[n % 10]
        return d + (' e ' + u if u else '')
    if n < 1000:
        c = CENTENAS[n // 100]
        resto = n % 100
        return c + (' e ' + numero_extenso(resto) if resto else '')
    if n < 1000000:
        m = n // 1000
        resto = n % 1000
        str_m = 'mil' if m == 1 else numero_extenso(m) + ' mil'
        if resto == 0:
            return str_m
        if resto < 100 or resto % 100 == 0:
            return str_m + ' e ' + numero_extenso(resto)
        return str_m + ', ' + numero_extenso(resto)
    return str(n)

def valor_por_extenso(valor):
    try:
        val = float(valor)
    except Exception:
        return ''
    reais = int(val)
    centavos = int(round((val - reais) * 100))
    partes = []
    if reais > 0:
        partes.append(f"{numero_extenso(reais)} {'real' if reais == 1 else 'reais'}")
    if centavos > 0:
        partes.append(f"{numero_extenso(centavos)} {'centavo' if centavos == 1 else 'centavos'}")
    return ' e '.join(partes)

def format_moeda(val):
    try:
        val = float(val or 0)
        return f"R$ {val:,.2f}".replace(',', 'X').replace('.', ',').replace('X', '.')
    except Exception:
        return "R$ 0,00"

def get_contratos_lista(ano=None, busca=None, turno=None, aluno_id=None):
    sql = """
    SELECT 
        m.ID_mensalidade,
        m.idaluno,
        a.nome_aluno,
        a.datanasc,
        a.etapa as aluno_etapa,
        a.turno as aluno_turno,
        m.idresponsavel,
        rf.nome as resp_nome,
        rf.cpf as resp_cpf,
        rf.telefone as resp_telefone,
        ra.nome as resp_acad_nome,
        m.n_parcelas,
        m.parcelas_pagas,
        m.valor_parcela,
        m.valor_total,
        m.saldo_devedor,
        m.data_inicio,
        m.ano_letivo,
        m.curso,
        m.turno as contrato_turno,
        t.nome_turma,
        t.serie as turma_serie
    FROM tb_mensalidades m
    LEFT JOIN tb_alunos a ON m.idaluno = a.ID_aluno
    LEFT JOIN tb_responsavel_financeiro rf ON m.idresponsavel = rf.ID_responsavel_financeiro
    LEFT JOIN tb_responsavel_academico ra ON a.ID_aluno = ra.idaluno
    LEFT JOIN tb_turmas t ON m.idturma = t.ID_turma
    WHERE 1=1
    """
    params = []
    if aluno_id:
        sql += " AND m.idaluno = ?"
        params.append(aluno_id)
    if ano:
        sql += " AND m.ano_letivo = ?"
        params.append(ano)
    if turno:
        sql += " AND m.turno LIKE ?"
        params.append(f"%{turno}%")
    if busca:
        if str(busca).isdigit():
            sql += " AND (a.ID_aluno = ? OR m.ID_mensalidade = ? OR a.nome_aluno LIKE ? OR rf.nome LIKE ? OR rf.cpf LIKE ?)"
            term = f"%{busca}%"
            params.extend([int(busca), int(busca), term, term, term])
        else:
            sql += " AND (a.nome_aluno LIKE ? OR rf.nome LIKE ? OR rf.cpf LIKE ?)"
            term = f"%{busca}%"
            params.extend([term, term, term])
        
    sql += " ORDER BY m.ano_letivo DESC, m.ID_mensalidade DESC"
    rows = query_all(sql, params)
    
    contratos = []
    for r in rows:
        d = dict(r)
        d['valor_parcela_fmt'] = format_moeda(d.get('valor_parcela'))
        d['valor_total_fmt'] = format_moeda(d.get('valor_total'))
        d['saldo_devedor_fmt'] = format_moeda(d.get('saldo_devedor'))
        d['data_inicio_fmt'] = format_data_br(d.get('data_inicio'))
        contratos.append(d)
    return contratos

def buscar_alunos_com_contratos(termo):
    if not termo:
        termo = ''
    termo = str(termo).strip()
    sql = """
    SELECT a.ID_aluno as id, a.nome_aluno as nome, a.datanasc, a.etapa, a.turno, a.ano_letivo,
           t.nome_turma,
           rf.nome as resp_fin_nome, rf.cpf as resp_fin_cpf,
           ra.nome as resp_acad_nome,
           (SELECT COUNT(*) FROM tb_mensalidades m WHERE m.idaluno = a.ID_aluno) as total_contratos
    FROM tb_alunos a
    LEFT JOIN tb_alunos_turmas at ON a.ID_aluno = at.idaluno
    LEFT JOIN tb_turmas t ON at.idturma = t.ID_turma
    LEFT JOIN tb_responsavel_financeiro rf ON a.ID_aluno = rf.idaluno
    LEFT JOIN tb_responsavel_academico ra ON a.ID_aluno = ra.idaluno
    WHERE 1=1
    """
    params = []
    if termo:
        if termo.isdigit():
            sql += " AND (a.ID_aluno = ? OR a.nome_aluno LIKE ?)"
            params.extend([int(termo), f"%{termo}%"])
        else:
            sql += " AND a.nome_aluno LIKE ?"
            params.append(f"%{termo}%")
            
    sql += """
    GROUP BY a.ID_aluno
    ORDER BY total_contratos DESC, a.nome_aluno ASC
    LIMIT 40
    """
    rows = query_all(sql, params)
    alunos = []
    for r in rows:
        d = dict(r)
        d['datanasc_formatada'] = format_data_br(d.get('datanasc'))
        alunos.append(d)
    return alunos

def get_contrato_dados(tipo, aluno_id=None, mensalidade_id=None, extra=None):
    if extra is None:
        extra = {}
        
    mensalidade = None
    if mensalidade_id:
        mensalidade = query_one("""
            SELECT m.*, t.nome_turma, t.serie as turma_serie
            FROM tb_mensalidades m
            LEFT JOIN tb_turmas t ON m.idturma = t.ID_turma
            WHERE m.ID_mensalidade = ?
        """, (mensalidade_id,))
        if mensalidade and not aluno_id:
            aluno_id = mensalidade['idaluno']
            
    if not aluno_id and not mensalidade:
        return {'error': 'Aluno ou Contrato não informado'}
        
    aluno_info = get_dados_completos_aluno(aluno_id)
    if not aluno_info or not aluno_info.get('aluno'):
        return {'error': 'Aluno não encontrado'}
        
    aluno = aluno_info['aluno']
    resp_acad = aluno_info['resp_acad'] or {}
    resp_fin = aluno_info['resp_fin'] or {}
    
    if not mensalidade:
        mensalidade = query_one("""
            SELECT m.*, t.nome_turma, t.serie as turma_serie
            FROM tb_mensalidades m
            LEFT JOIN tb_turmas t ON m.idturma = t.ID_turma
            WHERE m.idaluno = ?
            ORDER BY m.ano_letivo DESC, m.ID_mensalidade DESC
            LIMIT 1
        """, (aluno_id,))
        
    if mensalidade:
        m_dict = dict(mensalidade)
    else:
        m_dict = {
            'ID_mensalidade': None,
            'idaluno': aluno_id,
            'idresponsavel': resp_fin.get('ID_responsavel_financeiro'),
            'n_parcelas': 12,
            'valor_parcela': 700.0,
            'valor_total': 8400.0,
            'saldo_devedor': 8400.0,
            'parcelas_pagas': 0,
            'data_inicio': f"{aluno.get('ano_letivo') or datetime.now().year}-01-09",
            'ano_letivo': aluno.get('ano_letivo') or datetime.now().year,
            'curso': aluno.get('etapa') or 'Educação Infantil / Fundamental',
            'turno': aluno.get('turno') or 'MATUTINO',
            'nome_turma': aluno.get('nome_turma')
        }
        
    n_parcelas = int(m_dict.get('n_parcelas') or 12)
    valor_parcela = float(m_dict.get('valor_parcela') or 0.0)
    valor_total = float(m_dict.get('valor_total') or (valor_parcela * n_parcelas))
    parcelas_pagas = int(m_dict.get('parcelas_pagas') or 0)
    ano_letivo = m_dict.get('ano_letivo') or aluno.get('ano_letivo') or datetime.now().year
    
    m_dict['n_parcelas_extenso'] = numero_extenso(n_parcelas)
    m_dict['valor_parcela_fmt'] = format_moeda(valor_parcela)
    m_dict['valor_parcela_extenso'] = valor_por_extenso(valor_parcela)
    m_dict['valor_total_fmt'] = format_moeda(valor_total)
    m_dict['valor_total_extenso'] = valor_por_extenso(valor_total)
    m_dict['data_inicio_fmt'] = format_data_br(m_dict.get('data_inicio'))
    
    carne_parcelas = []
    try:
        data_ini_dt = datetime.strptime(str(m_dict.get('data_inicio') or f"{ano_letivo}-01-09").split(' ')[0], '%Y-%m-%d')
    except Exception:
        data_ini_dt = datetime(int(ano_letivo), 1, 9)
        
    for i in range(1, n_parcelas + 1):
        m_idx = (data_ini_dt.month - 1 + (i - 1)) % 12 + 1
        ano_parc = data_ini_dt.year + (data_ini_dt.month - 1 + (i - 1)) // 12
        venc_str = f"5º DIA ÚTIL DE {MESES_PT[m_idx].upper()}/{ano_parc}"
        status_parc = 'PAGO' if i <= parcelas_pagas else 'EM ABERTO'
        carne_parcelas.append({
            'numero': i,
            'parcela_str': f"{i:02d}/{n_parcelas:02d}",
            'mes_nome': MESES_PT[m_idx],
            'ano': ano_parc,
            'vencimento_str': venc_str,
            'valor_fmt': format_moeda(valor_parcela),
            'status': status_parc,
            'codigo_referencia': f"35062.{m_dict.get('ID_mensalidade') or 100:05d} {aluno_id:05d}.{i:02d}000 00000.000000 1 {int(valor_parcela * 100):010d}"
        })
        
    contratada = {
        'nome_fantasia': 'CENTRO EDUCACIONAL ATENIENSE',
        'razao_social': 'I. M. AZULAY ME',
        'cnpj': '35.062.987/0001-53',
        'endereco': 'Rua Rosalind Franklin, Nº 25 - Parque 10 de Novembro - CEP: 69.054-731, Manaus/AM',
        'telefone': '(92) 98450-3988',
        'email': 'ceateniensep10@hotmail.com',
        'cidade': 'Manaus',
        'uf': 'AM'
    }
    
    hoje = datetime.now()
    
    return {
        'tipo': tipo,
        'contratada': contratada,
        'aluno': aluno,
        'resp_fin': resp_fin,
        'resp_acad': resp_acad,
        'mensalidade': m_dict,
        'carne_parcelas': carne_parcelas,
        'data_extenso': get_data_extenso(),
        'hoje_iso': hoje.strftime('%Y-%m-%d'),
        'hoje_formatado': hoje.strftime('%d/%m/%Y'),
        'ano_letivo': ano_letivo,
        'extra': extra
    }

