#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Teste automatizado de todos os módulos e APIs do Master Escolar Ateniense
"""

import urllib.request
import json
import sys

BASE_URL = "http://127.0.0.1:8080"

def request_json(path, method="GET", data=None, token=None):
    headers = {"Content-Type": "application/json"}
    if token:
        headers["Authorization"] = f"Bearer {token}"
        
    req_data = json.dumps(data).encode("utf-8") if data else None
    req = urllib.request.Request(f"{BASE_URL}{path}", data=req_data, headers=headers, method=method)
    
    with urllib.request.urlopen(req) as resp:
        return json.loads(resp.read().decode("utf-8"))

def main():
    print("--- 1. TESTANDO LOGIN ---")
    login_res = request_json("/api/auth/login", method="POST", data={"username": "admin", "password": "140602"})
    print("Login sucesso:", login_res["nome"], "| Nível:", login_res["nivel"])
    token = login_res["token"]

    print("\n--- 2. TESTANDO DASHBOARD ---")
    dash = request_json("/api/dashboard", token=token)
    print(f"Total de Alunos: {dash['total_alunos']}")
    print(f"Total de Turmas: {dash['total_turmas']}")
    print(f"Saldo em Caixa: R$ {dash['saldo_caixa']:.2f}")
    print(f"Mensalidades em Aberto: R$ {dash['mensalidades_abertas_total']:.2f}")

    print("\n--- 3. TESTANDO CONSULTA DE ALUNOS ---")
    alunos_res = request_json("/api/alunos?limit=5", token=token)
    print(f"Total retornado: {len(alunos_res['alunos'])} de {alunos_res['total']}")
    primeiro_aluno = alunos_res["alunos"][0]
    print("Primeiro aluno:", primeiro_aluno["nome"], f"(#{primeiro_aluno['id']})")

    print("\n--- 4. TESTANDO BOLETIM DO ALUNO ---")
    boletim = request_json(f"/api/boletim/{primeiro_aluno['id']}", token=token)
    print("Boletim:", boletim['aluno']['nome_aluno'], "- Matérias:", len(boletim['materias']))

    print("\n--- 5. TESTANDO MENSALIDADES ---")
    mensalidades = request_json("/api/mensalidades?limit=3", token=token)
    print(f"Mensalidades listadas: {len(mensalidades['mensalidades'])}")

    print("\n--- 6. TESTANDO LIVRO CAIXA ---")
    caixa = request_json("/api/caixa?limit=3", token=token)
    print(f"Lançamentos de caixa listados: {len(caixa['caixa'])}")

    print("\n--- 7. TESTANDO PRODUTOS / PDV ---")
    produtos = request_json("/api/produtos?limit=5", token=token)
    print(f"Produtos em catálogo: {len(produtos['produtos'])}")

    print("\n--- 8. TESTANDO DRE GERENCIAL ---")
    dre = request_json("/api/dre?ano=2026", token=token)
    print(f"Receitas DRE: R$ {dre['total_receitas']:.2f} | Despesas: R$ {dre['total_despesas']:.2f} | Resultado: R$ {dre['resultado_liquido']:.2f}")

    print("\n--- 9. TESTANDO DECLARAÇÕES OFICIAIS ---")
    doc_dados = request_json(f"/api/documentos/dados?aluno_id={primeiro_aluno['id']}", token=token)
    print("Data por extenso:", doc_dados['data_extenso'])

    print("\n✅ TODOS OS TESTES PASSARAM COM 100% DE SUCESSO!")

if __name__ == "__main__":
    main()
