# -*- coding: utf-8 -*-
"""
Serviço de Cursos: Criar, Editar, Listar e Excluir Cursos
"""

from database.db import query_all, query_one, execute

def list_cursos():
    return query_all("SELECT ID_curso as id, nome_curso FROM tb_cursos ORDER BY ID_curso ASC")

def get_curso(curso_id):
    return query_one("SELECT ID_curso as id, nome_curso FROM tb_cursos WHERE ID_curso = ?", (curso_id,))

def create_curso(data):
    nome = data.get('nome_curso', '').strip()
    if not nome:
        raise ValueError("O nome do curso não pode ser vazio.")
    next_id_row = query_one("SELECT COALESCE(MAX(ID_curso), 0) + 1 AS next_id FROM tb_cursos")
    next_id = next_id_row['next_id'] if next_id_row else 1
    execute("INSERT INTO tb_cursos (ID_curso, nome_curso) VALUES (?, ?)", (next_id, nome))
    return next_id

def update_curso(curso_id, data):
    nome = data.get('nome_curso', '').strip()
    if not nome:
        raise ValueError("O nome do curso não pode ser vazio.")
    execute("UPDATE tb_cursos SET nome_curso = ? WHERE ID_curso = ?", (nome, curso_id))
    return {'id': curso_id, 'nome_curso': nome}

def delete_curso(curso_id):
    return execute("DELETE FROM tb_cursos WHERE ID_curso = ?", (curso_id,))

def list_mensalidades_cursos(limit=100):
    return query_all(f"""
    SELECT 
        mc.ID_mensalidade_curso as id,
        mc.n_parcelas,
        mc.valor_total,
        mc.saldo_devedor,
        mc.valor_parcela,
        mc.parcelas_pagas,
        mc.nome_curso,
        a.nome_aluno,
        a.ID_aluno as idaluno
    FROM tb_mensalidades_cursos mc
    LEFT JOIN tb_alunos a ON mc.idaluno = a.ID_aluno
    ORDER BY mc.ID_mensalidade_curso DESC
    LIMIT {limit}
    """)
