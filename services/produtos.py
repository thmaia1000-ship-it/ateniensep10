# -*- coding: utf-8 -*-
"""
Serviço de Produtos e PDV (Ponto de Venda)
"""

import uuid
from datetime import datetime
from database.db import query_all, query_one, execute

def list_produtos(busca='', limit=100):
    params = []
    where = ""
    if busca:
        where = "WHERE produto LIKE ? OR descricao LIKE ?"
        params.extend([f"%{busca}%", f"%{busca}%"])
    sql = f"""
    SELECT 
        ID_produto as id,
        produto,
        descricao,
        valor_custo,
        valor_venda,
        estoque,
        data_gerada,
        usuario
    FROM tb_produtos
    {where}
    ORDER BY produto ASC
    LIMIT {limit}
    """
    return query_all(sql, tuple(params))

def get_produto(prod_id):
    return query_one("SELECT * FROM tb_produtos WHERE ID_produto = ?", (prod_id,))

def create_produto(data, usuario='ADMIN'):
    data_gerada = datetime.now().strftime('%Y-%m-%d')
    return execute("""
    INSERT INTO tb_produtos (produto, descricao, valor_custo, valor_venda, estoque, data_gerada, usuario)
    VALUES (?, ?, ?, ?, ?, ?, ?)
    """, (
        data.get('produto', ''),
        data.get('descricao', ''),
        data.get('valor_custo', 0.0),
        data.get('valor_venda', 0.0),
        data.get('estoque', 0),
        data_gerada,
        usuario
    ))

def update_produto(prod_id, data):
    return execute("""
    UPDATE tb_produtos SET
        produto = ?, descricao = ?, valor_custo = ?, valor_venda = ?, estoque = ?
    WHERE ID_produto = ?
    """, (
        data.get('produto', ''),
        data.get('descricao', ''),
        data.get('valor_custo', 0.0),
        data.get('valor_venda', 0.0),
        data.get('estoque', 0),
        prod_id
    ))

def delete_produto(prod_id):
    return execute("DELETE FROM tb_produtos WHERE ID_produto = ?", (prod_id,))

def realizar_venda(cliente_nome, itens, forma_pagamento='DINHEIRO', usuario='ADMIN', observacao=''):
    codigo_venda = str(uuid.uuid4())[:8].upper()
    data_gerada = datetime.now().strftime('%Y-%m-%d')
    hora_str = datetime.now().strftime('%H:%M:%S')
    
    total_geral = 0.0
    
    for item in itens:
        prod_id = item.get('id')
        qtd = int(item.get('quantidade', 1))
        preco = float(item.get('valor_venda', 0.0))
        subtotal = preco * qtd
        total_geral += subtotal
        
        prod = query_one("SELECT produto, estoque FROM tb_produtos WHERE ID_produto = ?", (prod_id,))
        p_nome = prod['produto'] if prod else "PRODUTO"
        
        # Debita estoque
        execute("UPDATE tb_produtos SET estoque = MAX(0, estoque - ?) WHERE ID_produto = ?", (qtd, prod_id))
        
        # Insere tb_vendas
        execute("""
        INSERT INTO tb_vendas (produto, valor_total, quantidade, observacao, nome, usuario, data_gerada, codigovenda, idproduto)
        VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)
        """, (
            p_nome,
            f"{subtotal:.2f}",
            qtd,
            observacao,
            cliente_nome or 'CONSUMIDOR',
            usuario,
            data_gerada,
            codigo_venda,
            prod_id
        ))
        
    # Insere entrada no tb_caixa
    caixa_id = execute("""
    INSERT INTO tb_caixa (valor_total, forma, tipo_movimentacao, nome, descricao, usuario, data, horario, curso, codigovenda)
    VALUES (?, ?, 'ENTRADA', ?, ?, ?, ?, ?, 'VENDA PRODUTOS', ?)
    """, (
        f"{total_geral:.2f}",
        forma_pagamento,
        cliente_nome or 'CONSUMIDOR',
        f"VENDA PDV #{codigo_venda} ({len(itens)} itens)",
        usuario,
        data_gerada,
        hora_str,
        codigo_venda
    ))
    
    return {
        'codigo_venda': codigo_venda,
        'total': total_geral,
        'itens_count': len(itens),
        'caixa_id': caixa_id
    }

def list_vendas(limit=100):
    return query_all(f"""
    SELECT 
        v.ID_venda as id,
        v.produto,
        v.valor_total,
        v.quantidade,
        v.nome as cliente,
        v.usuario,
        v.data_gerada,
        v.codigovenda
    FROM tb_vendas v
    ORDER BY v.ID_venda DESC
    LIMIT {limit}
    """)
