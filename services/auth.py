# -*- coding: utf-8 -*-
"""
Serviço de autenticação e gestão de usuários
"""

import uuid
from database.db import query_all, query_one, execute

# Dicionário de sessões em memória token -> user
SESSIONS = {}

def authenticate(username, password):
    user = query_one(
        "SELECT ID_usuario, nome_usuario, username, nivel_usuario, status FROM tb_usuarios WHERE username = ? AND senha = ?",
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
    return query_all("SELECT ID_usuario as id, nome_usuario as nome, username, nivel_usuario as nivel, status FROM tb_usuarios ORDER BY ID_usuario")

def create_user(nome, username, senha, nivel):
    return execute(
        "INSERT INTO tb_usuarios (nome_usuario, username, senha, nivel_usuario, status) VALUES (?, ?, ?, ?, '')",
        (nome, username, senha, nivel)
    )

def update_user(user_id, nome, username, senha=None, nivel=None):
    if senha:
        return execute(
            "UPDATE tb_usuarios SET nome_usuario = ?, username = ?, senha = ?, nivel_usuario = ? WHERE ID_usuario = ?",
            (nome, username, senha, nivel, user_id)
        )
    else:
        return execute(
            "UPDATE tb_usuarios SET nome_usuario = ?, username = ?, nivel_usuario = ? WHERE ID_usuario = ?",
            (nome, username, nivel, user_id)
        )

def delete_user(user_id):
    return execute("DELETE FROM tb_usuarios WHERE ID_usuario = ?", (user_id,))
