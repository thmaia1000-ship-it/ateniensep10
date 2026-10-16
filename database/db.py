# -*- coding: utf-8 -*-
"""
Módulo de conexão e manipulação do banco de dados SQLite do Ateniense.
"""

import os
import sqlite3
import sys
import shutil
from typing import List, Dict, Any, Optional

def get_db_path() -> str:
    if getattr(sys, 'frozen', False):
        # Executável compilado (.exe)
        exe_dir = os.path.dirname(sys.executable)
        data_dir = os.path.join(exe_dir, 'database')
        os.makedirs(data_dir, exist_ok=True)
        target_db = os.path.join(data_dir, 'ateniense.db')
        
        # Se ainda não existir no diretório de persistência, copia o banco empacotado
        if not os.path.exists(target_db):
            bundled_db = os.path.join(getattr(sys, '_MEIPASS', ''), 'database', 'ateniense.db')
            if os.path.exists(bundled_db):
                try:
                    shutil.copy2(bundled_db, target_db)
                except Exception as e:
                    print(f"Erro ao inicializar banco: {e}")
        return target_db
    else:
        BASE_DIR = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
        return os.path.join(BASE_DIR, 'database', 'ateniense.db')

DB_PATH = get_db_path()

def get_connection() -> sqlite3.Connection:
    conn = sqlite3.connect(get_db_path())
    conn.row_factory = sqlite3.Row
    conn.execute("PRAGMA foreign_keys = ON")
    return conn

def query_all(sql: str, params: tuple = ()) -> List[Dict[str, Any]]:
    with get_connection() as conn:
        cursor = conn.cursor()
        cursor.execute(sql, params)
        rows = cursor.fetchall()
        return [dict(row) for row in rows]

def query_one(sql: str, params: tuple = ()) -> Optional[Dict[str, Any]]:
    with get_connection() as conn:
        cursor = conn.cursor()
        cursor.execute(sql, params)
        row = cursor.fetchone()
        return dict(row) if row else None

def execute(sql: str, params: tuple = ()) -> int:
    with get_connection() as conn:
        cursor = conn.cursor()
        cursor.execute(sql, params)
        conn.commit()
        return cursor.lastrowid
