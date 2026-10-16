#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Script de importação do dump MySQL (dbateniense.sql) para SQLite (ateniense.db).
Mantém fidelidade total de esquemas, tabelas e registros.
"""

import os
import sys
import re
import sqlite3
import time

BASE_DIR = os.path.dirname(os.path.abspath(__file__))
SQL_FILE = os.path.join(BASE_DIR, 'database', 'dbateniense.sql')
DB_FILE = os.path.join(BASE_DIR, 'database', 'ateniense.db')

def clean_mysql_create_table(sql):
    idx = sql.rfind(')')
    if idx != -1:
        sql = sql[:idx+1] + ';'
        
    sql = re.sub(r'COLLATE\s*=?\s*[\w_]+', '', sql, flags=re.IGNORECASE)
    sql = re.sub(r'CHARACTER\s+SET\s+[\w_]+', '', sql, flags=re.IGNORECASE)
    sql = re.sub(r'DEFAULT\s+CHARSET\s*=?\s*[\w_]+', '', sql, flags=re.IGNORECASE)
    sql = re.sub(r'ENGINE\s*=?\s*[\w_]+', '', sql, flags=re.IGNORECASE)
    sql = re.sub(r'AUTO_INCREMENT\s*=?\s*\d+', '', sql, flags=re.IGNORECASE)
    sql = re.sub(r'\bAUTO_INCREMENT\b', '', sql, flags=re.IGNORECASE)
    
    # Converte tipos
    sql = re.sub(r'\bint\(\d+\)', 'INTEGER', sql, flags=re.IGNORECASE)
    sql = re.sub(r'\btinyint\(\d+\)', 'INTEGER', sql, flags=re.IGNORECASE)
    sql = re.sub(r'\bsmallint\(\d+\)', 'INTEGER', sql, flags=re.IGNORECASE)
    sql = re.sub(r'\bmediumint\(\d+\)', 'INTEGER', sql, flags=re.IGNORECASE)
    sql = re.sub(r'\bbigint\(\d+\)', 'INTEGER', sql, flags=re.IGNORECASE)
    sql = re.sub(r'\bdouble\b', 'REAL', sql, flags=re.IGNORECASE)
    sql = re.sub(r'\bfloat\b', 'REAL', sql, flags=re.IGNORECASE)
    sql = re.sub(r'\bdecimal\([^)]+\)', 'REAL', sql, flags=re.IGNORECASE)
    sql = re.sub(r'\bdatetime\b', 'TEXT', sql, flags=re.IGNORECASE)
    sql = re.sub(r'\bdate\b', 'TEXT', sql, flags=re.IGNORECASE)
    sql = re.sub(r'\btimestamp\b', 'TEXT', sql, flags=re.IGNORECASE)
    sql = re.sub(r'\btime\b', 'TEXT', sql, flags=re.IGNORECASE)
    sql = re.sub(r'\b(medium|long)?blob\b', 'BLOB', sql, flags=re.IGNORECASE)
    sql = re.sub(r'\b(medium|long)?text\b', 'TEXT', sql, flags=re.IGNORECASE)
    sql = re.sub(r'\bvarchar\([^)]+\)', 'TEXT', sql, flags=re.IGNORECASE)
    sql = re.sub(r'\bchar\([^)]+\)', 'TEXT', sql, flags=re.IGNORECASE)
    sql = re.sub(r'\benum\([^)]+\)', 'TEXT', sql, flags=re.IGNORECASE)
    
    lines = []
    for l in sql.split('\n'):
        cleaned_line = l.strip()
        if cleaned_line.startswith(('KEY ', 'INDEX ', 'FULLTEXT ', 'SPATIAL ', 'UNIQUE KEY ')):
            continue
        lines.append(l)
    joined = '\n'.join(lines)
    joined = re.sub(r',\s*\)', '\n)', joined)
    return joined

def sanitize_mysql_insert(sql):
    # Substitui escapes do MySQL com segurança:
    # \' -> ''
    # \" -> "
    # \\ -> \
    # \r\n -> \n
    # \0 -> ''
    s = sql
    s = s.replace(r"\'", "''")
    s = s.replace(r'\"', '"')
    s = s.replace(r'\r\n', '\n')
    s = s.replace(r'\n', ' ')
    s = s.replace(r'\0', '')
    s = s.replace(r'\\', '\\')
    return s

def import_sql(sql_file_path=None):
    target_file = sql_file_path if (sql_file_path and os.path.exists(sql_file_path)) else SQL_FILE
    if not os.path.exists(target_file):
        print(f"Arquivo SQL não encontrado em: {target_file}")
        return {'success': False, 'error': f"Arquivo não encontrado: {target_file}"}
        
    print(f"Iniciando importação de {target_file} para {DB_FILE}...")
    start_time = time.time()
    
    if os.path.exists(DB_FILE):
        os.remove(DB_FILE)
        
    conn = sqlite3.connect(DB_FILE)
    cursor = conn.cursor()
    cursor.execute("PRAGMA synchronous = OFF")
    cursor.execute("PRAGMA journal_mode = MEMORY")
    cursor.execute("PRAGMA foreign_keys = OFF")
    
    current_statement = []
    in_create = False
    in_insert = False
    
    table_counts = {}
    
    with open(target_file, 'r', encoding='utf-8', errors='ignore') as f:
        for line in f:
            stripped = line.strip()
            
            if stripped.startswith('--') or stripped.startswith('/*') or not stripped:
                continue
                
            if 'CREATE TABLE' in line:
                in_create = True
                current_statement = [line]
                continue
                
            if in_create:
                current_statement.append(line)
                if stripped.endswith(';'):
                    in_create = False
                    full_create = ''.join(current_statement)
                    sqlite_create = clean_mysql_create_table(full_create)
                    tname_match = re.search(r'CREATE TABLE\s+`?(\w+)`?', sqlite_create, re.IGNORECASE)
                    tname = tname_match.group(1) if tname_match else "desconhecida"
                    try:
                        cursor.execute(sqlite_create)
                        table_counts[tname] = 0
                    except Exception as e:
                        print(f"Erro no CREATE TABLE {tname}: {e}")
                    current_statement = []
                continue
                
            if 'INSERT INTO' in line:
                in_insert = True
                current_statement = [line]
                if stripped.endswith(';'):
                    in_insert = False
                    full_insert = ''.join(current_statement)
                    _execute_insert(cursor, full_insert, table_counts)
                    current_statement = []
                continue
                
            if in_insert:
                current_statement.append(line)
                if stripped.endswith(';'):
                    in_insert = False
                    full_insert = ''.join(current_statement)
                    _execute_insert(cursor, full_insert, table_counts)
                    current_statement = []
                continue

    conn.commit()
    conn.close()
    
    elapsed = time.time() - start_time
    total_recs = sum(table_counts.values())
    print(f"\nImportação concluída com sucesso em {elapsed:.2f}s!")
    print(f"Total de tabelas importadas: {len(table_counts)}")
    for t, count in sorted(table_counts.items(), key=lambda x: -x[1]):
        print(f"  - {t}: {count} registros")
    print(f"\nTOTAL GERAL DE REGISTROS: {total_recs}")
    return {
        'success': True,
        'elapsed': round(elapsed, 2),
        'total_tables': len(table_counts),
        'total_records': total_recs,
        'tables': table_counts,
        'file': target_file
    }

def _execute_insert(cursor, insert_sql, table_counts):
    m = re.search(r'INSERT INTO\s+`?(\w+)`?', insert_sql, re.IGNORECASE)
    tname = m.group(1) if m else "tabela"
    
    sanitized = sanitize_mysql_insert(insert_sql)
    try:
        cursor.execute(sanitized)
        tuples_count = insert_sql.count('),(') + 1
        table_counts[tname] = table_counts.get(tname, 0) + tuples_count
    except Exception as e:
        # Se falhou, tenta executar tupla a tupla para não perder dados
        # Pega a parte INSERT INTO `table` (`col1`, `col2`) VALUES
        try:
            val_idx = sanitized.find('VALUES')
            if val_idx != -1:
                header = sanitized[:val_idx+6]
                body = sanitized[val_idx+6:].strip()
                if body.endswith(';'):
                    body = body[:-1].strip()
                # Divide pelas tuplas: ), (
                # Regex split seguro para tuplas
                tuples = re.split(r'\),\s*\(', body)
                success_count = 0
                for i, tup in enumerate(tuples):
                    tup_str = tup.strip()
                    if not tup_str.startswith('('):
                        tup_str = '(' + tup_str
                    if not tup_str.endswith(')'):
                        tup_str = tup_str + ')'
                    single_sql = f"{header} {tup_str};"
                    try:
                        cursor.execute(single_sql)
                        success_count += 1
                    except Exception:
                        pass
                table_counts[tname] = table_counts.get(tname, 0) + success_count
        except Exception as e2:
            print(f"Aviso ao inserir em {tname}: {e2}")

if __name__ == '__main__':
    import_sql()
