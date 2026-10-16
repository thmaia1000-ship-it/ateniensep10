#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
🎓 Launcher Desktop do Master Escolar Ateniense
Inicia o servidor em segundo plano e abre o navegador automaticamente.
Compatível com Windows (.exe), Linux e macOS.
"""

import os
import sys
import time
import socket
import threading
import webbrowser
from http.server import ThreadingHTTPServer

# Garante inclusão do diretório base
if getattr(sys, 'frozen', False):
    BASE_DIR = getattr(sys, '_MEIPASS', os.path.dirname(os.path.abspath(__file__)))
else:
    BASE_DIR = os.path.dirname(os.path.abspath(__file__))

if BASE_DIR not in sys.path:
    sys.path.insert(0, BASE_DIR)

from server import AtenienseHandler

def find_available_port(start_port=8080, max_attempts=10):
    for port in range(start_port, start_port + max_attempts):
        with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
            if s.connect_ex(('127.0.0.1', port)) != 0:
                return port
    return start_port

def start_server(httpd):
    httpd.serve_forever()

def main():
    port = find_available_port(8080)
    url = f"http://127.0.0.1:{port}"

    print("==================================================")
    print("🎓 MASTER ESCOLAR ATENIENSE - SOFTWARE DESKTOP")
    print(f"🔗 Iniciando servidor em {url}...")
    print("==================================================")

    server_address = ('127.0.0.1', port)
    httpd = ThreadingHTTPServer(server_address, AtenienseHandler)

    # Inicia o servidor HTTP em uma thread secundária
    server_thread = threading.Thread(target=start_server, args=(httpd,), daemon=True)
    server_thread.start()

    # Aguarda 1 segundo e abre o navegador
    time.sleep(1.2)
    print(f"🌐 Abrindo navegador em {url}...")
    try:
        webbrowser.open(url)
    except Exception as e:
        print(f"Não foi possível abrir o navegador automaticamente: {e}")

    print("\n[OK] O sistema está ativo e pronto para uso!")
    print("Mantenha esta janela aberta enquanto estiver utilizando o sistema.")
    print("Pressione Ctrl+C ou feche esta janela para encerrar o aplicativo.\n")

    try:
        while True:
            time.sleep(1)
    except (KeyboardInterrupt, SystemExit):
        print("\nEncerrando Master Escolar Ateniense...")
        try:
            httpd.shutdown()
            httpd.server_close()
        except Exception:
            pass
        sys.exit(0)

if __name__ == '__main__':
    main()
