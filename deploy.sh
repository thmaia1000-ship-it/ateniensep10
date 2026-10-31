#!/bin/bash
# ==============================================================================
# Script de Deploy e Atualização no Servidor de Produção
# ==============================================================================

set -e

echo "=========================================================="
echo "🚀 Publicação Master Escolar Ateniense"
echo "🌐 Domínio: https://ateniensep10.agenciabr3.com.br"
echo "=========================================================="

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" >/dev/null 2>&1 && pwd )"
cd "$DIR"

echo "1. Puxando atualizações mais recentes do GitHub..."
git pull origin main

echo "2. Reiniciando serviço do sistema..."
if command -v systemctl >/dev/null 2>&1 && systemctl is-active --quiet ateniense; then
    sudo systemctl restart ateniense
    echo "Serviço systemd (ateniense) reiniciado com sucesso!"
elif command -v pm2 >/dev/null 2>&1 && pm2 describe ateniense >/dev/null 2>&1; then
    pm2 restart ateniense
    echo "Processo PM2 (ateniense) reiniciado!"
else
    echo "Reiniciando processo Python em background..."
    pkill -f "python3 server.py" || true
    nohup python3 server.py 8080 > server.log 2>&1 &
    echo "Servidor rodando em background na porta 8080 (logs em server.log)!"
fi

echo "=========================================================="
echo "✅ Publicação concluída com sucesso!"
echo "Acesse: https://ateniensep10.agenciabr3.com.br"
echo "=========================================================="
