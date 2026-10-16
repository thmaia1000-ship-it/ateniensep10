# -*- coding: utf-8 -*-
"""
Serviço Contábil: Despesas e DRE Gerencial
"""

from datetime import datetime
from database.db import query_all, query_one, execute

def list_despesas(data_inicio=None, data_fim=None, tipo=None, limit=100):
    params = []
    where_clauses = []
    if data_inicio:
        where_clauses.append("data >= ?")
        params.append(data_inicio)
    if data_fim:
        where_clauses.append("data <= ?")
        params.append(data_fim)
    if tipo:
        where_clauses.append("tipo = ?")
        params.append(tipo)
        
    where_str = ("WHERE " + " AND ".join(where_clauses)) if where_clauses else ""
    return query_all(f"""
    SELECT 
        ID_despesa as id,
        tipo,
        descricao,
        valor,
        data,
        observacoes,
        usuario,
        data_gerada
    FROM tb_despesas
    {where_str}
    ORDER BY data DESC, ID_despesa DESC
    LIMIT {limit}
    """, tuple(params))

def create_despesa(data, usuario='ADMIN'):
    data_gerada = datetime.now().strftime('%Y-%m-%d')
    despesa_id = execute("""
    INSERT INTO tb_despesas (tipo, descricao, valor, data, observacoes, usuario, data_gerada)
    VALUES (?, ?, ?, ?, ?, ?, ?)
    """, (
        data.get('tipo', 'OPERACIONAL'),
        data.get('descricao', ''),
        data.get('valor', 0.0),
        data.get('data', data_gerada),
        data.get('observacoes', ''),
        usuario,
        data_gerada
    ))
    
    # Se solicitado, lança saída no caixa
    if data.get('lancar_caixa'):
        hoje = datetime.now()
        execute("""
        INSERT INTO tb_caixa (valor_total, forma, tipo_movimentacao, nome, descricao, usuario, data, horario, curso, observacao)
        VALUES (?, ?, 'SAÍDA', 'DESPESA', ?, ?, ?, ?, 'ENSINO REGULAR', ?)
        """, (
            data.get('valor', 0.0),
            data.get('forma', 'DINHEIRO'),
            f"DESPESA: {data.get('descricao', '')}",
            usuario,
            data.get('data', data_gerada),
            hoje.strftime('%H:%M:%S'),
            data.get('observacoes', '')
        ))
        
    return despesa_id

def get_dre(ano=None):
    if not ano:
        ano = datetime.now().strftime('%Y')
        
    # Agrupa entradas (receitas) do caixa por mês do ano
    receitas_por_mes = query_all("""
    SELECT 
        strftime('%m', data) as mes,
        SUM(CAST(valor_total AS REAL)) as total
    FROM tb_caixa
    WHERE strftime('%Y', data) = ? AND UPPER(tipo_movimentacao) LIKE '%ENTRADA%'
    GROUP BY strftime('%m', data)
    ORDER BY mes ASC
    """, (ano,))
    
    # Agrupa saídas (despesas) do caixa por mês do ano
    despesas_por_mes = query_all("""
    SELECT 
        strftime('%m', data) as mes,
        SUM(CAST(valor_total AS REAL)) as total
    FROM tb_caixa
    WHERE strftime('%Y', data) = ? AND UPPER(tipo_movimentacao) LIKE '%SA%'
    GROUP BY strftime('%m', data)
    ORDER BY mes ASC
    """, (ano,))
    
    rec_dict = {row['mes']: row['total'] for row in receitas_por_mes}
    desp_dict = {row['mes']: row['total'] for row in despesas_por_mes}
    
    meses_nomes = [
        ('01', 'Janeiro'), ('02', 'Fevereiro'), ('03', 'Março'), ('04', 'Abril'),
        ('05', 'Maio'), ('06', 'Junho'), ('07', 'Julho'), ('08', 'Agosto'),
        ('09', 'Setembro'), ('10', 'Outubro'), ('11', 'Novembro'), ('12', 'Dezembro')
    ]
    
    dre_mensal = []
    total_receitas_ano = 0.0
    total_despesas_ano = 0.0
    
    for num, nome in meses_nomes:
        r = float(rec_dict.get(num, 0.0))
        d = float(desp_dict.get(num, 0.0))
        resultado = r - d
        total_receitas_ano += r
        total_despesas_ano += d
        dre_mensal.append({
            'mes_num': num,
            'mes_nome': nome,
            'receitas': r,
            'despesas': d,
            'resultado': resultado
        })
        
    return {
        'ano': ano,
        'meses': dre_mensal,
        'total_receitas': total_receitas_ano,
        'total_despesas': total_despesas_ano,
        'resultado_liquido': total_receitas_ano - total_despesas_ano
    }
