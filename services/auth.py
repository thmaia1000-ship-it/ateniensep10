# -*- coding: utf-8 -*-
"""
Serviço de autenticação e gestão de usuários
"""

import uuid
from database.db import query_all, query_one, execute

# Dicionário de sessões em memória token -> user
SESSIONS = {}

def authenticate(username, password):
    username = (username or '').strip()
    password = (password or '').strip()
    user = query_one(
        "SELECT ID_usuario, nome_usuario, username, nivel_usuario, status, id_professor FROM tb_usuarios WHERE LOWER(TRIM(username)) = LOWER(?) AND TRIM(senha) = ?",
        (username, password)
    )
    if user:
        if (user.get('status') or '').upper() == 'INATIVO':
            return None
        token = str(uuid.uuid4())
        user_info = {
            'id': user['ID_usuario'],
            'nome': user['nome_usuario'],
            'username': user['username'],
            'nivel': user['nivel_usuario'],
            'id_professor': user.get('id_professor'),
            'token': token
        }
        SESSIONS[token] = user_info
        return user_info
    return None

def get_current_user(token):
    return SESSIONS.get(token)

def logout(token):
    if token in SESSIONS:
        del SESSIONS[token]
        return True
    return False

def list_users():
    return query_all("""
        SELECT 
            u.ID_usuario as id, 
            u.nome_usuario as nome, 
            u.username, 
            u.nivel_usuario as nivel, 
            COALESCE(NULLIF(u.status, ''), 'ATIVO') as status,
            u.id_professor,
            p.nome_professor as professor_nome
        FROM tb_usuarios u
        LEFT JOIN tb_professores p ON u.id_professor = p.ID_professor
        ORDER BY u.ID_usuario
    """)

def get_user(user_id):
    return query_one("""
        SELECT 
            u.ID_usuario as id, 
            u.nome_usuario as nome, 
            u.username, 
            u.nivel_usuario as nivel, 
            COALESCE(NULLIF(u.status, ''), 'ATIVO') as status,
            u.id_professor,
            p.nome_professor as professor_nome
        FROM tb_usuarios u
        LEFT JOIN tb_professores p ON u.id_professor = p.ID_professor
        WHERE u.ID_usuario = ?
    """, (user_id,))

def create_user(nome, username, senha, nivel=1, status='ATIVO', id_professor=None):
    max_id = query_one("SELECT MAX(ID_usuario) as max_id FROM tb_usuarios")
    next_id = (max_id['max_id'] or 0) + 1 if max_id else 1
    id_prof = int(id_professor) if id_professor else None
    execute(
        "INSERT INTO tb_usuarios (ID_usuario, nome_usuario, username, senha, nivel_usuario, status, id_professor) VALUES (?, ?, ?, ?, ?, ?, ?)",
        (next_id, (nome or '').strip(), (username or '').strip(), (senha or '').strip(), int(nivel or 1), (status or 'ATIVO').strip(), id_prof)
    )
    return next_id

def update_user(user_id, nome, username, senha=None, nivel=None, status=None, id_professor=None):
    campos = ["nome_usuario = ?", "username = ?"]
    valores = [(nome or '').strip(), (username or '').strip()]
    if senha and str(senha).strip():
        campos.append("senha = ?")
        valores.append(str(senha).strip())
    if nivel is not None:
        campos.append("nivel_usuario = ?")
        valores.append(int(nivel))
    if status is not None:
        campos.append("status = ?")
        valores.append(str(status).strip())
    if id_professor is not None:
        campos.append("id_professor = ?")
        valores.append(int(id_professor) if id_professor else None)
    valores.append(user_id)
    sql = f"UPDATE tb_usuarios SET {', '.join(campos)} WHERE ID_usuario = ?"
    return execute(sql, tuple(valores))

def delete_user(user_id):
    return execute("DELETE FROM tb_usuarios WHERE ID_usuario = ?", (user_id,))
