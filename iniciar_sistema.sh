#!/bin/bash
# ==============================================================================
# Script de Inicialização do Master Escolar Ateniense (Plataforma Web)
# ==============================================================================

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" >/dev/null 2>&1 && pwd )"
cd "$DIR"

echo "=========================================================="
echo "🎓 CENTRO EDUCACIONAL ATENIENSE - MASTER ESCOLAR WEB"
echo "=========================================================="
echo "Iniciando o servidor da aplicação..."

# Inicia o servidor Python
python3 server.py 8080 &
SERVER_PID=$!

sleep 1

echo "Abrindo o sistema no navegador padrão..."
open "http://localhost:8080"

echo "Pressione Ctrl+C para encerrar o sistema."
wait $SERVER_PID
