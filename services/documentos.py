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

def get_dados_completos_aluno(aluno_id):
    aluno = query_one("""
    SELECT a.*, t.nome_turma, t.serie 
    FROM tb_alunos a
    LEFT JOIN tb_alunos_turmas at ON a.ID_aluno = at.idaluno
    LEFT JOIN tb_turmas t ON at.idturma = t.ID_turma
    WHERE a.ID_aluno = ?
    """, (aluno_id,))
    
    resp_acad = query_one("SELECT * FROM tb_responsavel_academico WHERE idaluno = ?", (aluno_id,))
    resp_fin = query_one("SELECT * FROM tb_responsavel_financeiro WHERE idaluno = ?", (aluno_id,))
    
    return {
        'aluno': aluno,
        'resp_acad': resp_acad,
        'resp_fin': resp_fin,
        'data_extenso': get_data_extenso()
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
