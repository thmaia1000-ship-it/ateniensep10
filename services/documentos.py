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
