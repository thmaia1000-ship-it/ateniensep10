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
        "SELECT ID_usuario, nome_usuario, username, nivel_usuario, status FROM tb_usuarios WHERE LOWER(TRIM(username)) = LOWER(?) AND TRIM(senha) = ?",
        (username, password)
    )
    if user:
        token = str(uuid.uuid4())
        user_info = {
            'id': user['ID_usuario'],
            'nome': user['nome_usuario'],
            'username': user['username'],
            'nivel': user['nivel_usuario'],
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
    return query_all("SELECT ID_usuario as id, nome_usuario as nome, username, nivel_usuario as nivel, COALESCE(NULLIF(status, ''), 'ATIVO') as status FROM tb_usuarios ORDER BY ID_usuario")

def get_user(user_id):
    return query_one(
        "SELECT ID_usuario as id, nome_usuario as nome, username, nivel_usuario as nivel, COALESCE(NULLIF(status, ''), 'ATIVO') as status FROM tb_usuarios WHERE ID_usuario = ?",
        (user_id,)
    )

def create_user(nome, username, senha, nivel=1, status='ATIVO'):
    max_id = query_one("SELECT MAX(ID_usuario) as max_id FROM tb_usuarios")
    next_id = (max_id['max_id'] or 0) + 1 if max_id else 1
    execute(
        "INSERT INTO tb_usuarios (ID_usuario, nome_usuario, username, senha, nivel_usuario, status) VALUES (?, ?, ?, ?, ?, ?)",
        (next_id, (nome or '').strip(), (username or '').strip(), (senha or '').strip(), int(nivel or 1), (status or 'ATIVO').strip())
    )
    return next_id

def update_user(user_id, nome, username, senha=None, nivel=None, status=None):
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
    valores.append(user_id)
    sql = f"UPDATE tb_usuarios SET {', '.join(campos)} WHERE ID_usuario = ?"
    return execute(sql, tuple(valores))

def delete_user(user_id):
    return execute("DELETE FROM tb_usuarios WHERE ID_usuario = ?", (user_id,))
