#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Script de automação para compilação do executável Windows (.exe) do Ateniense.
Pode ser executado com: python aplicativos/compilar_windows.py
"""

import os
import sys
import subprocess
import shutil

BASE_DIR = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
os.chdir(BASE_DIR)

def print_header(title):
    print("\n" + "=" * 65)
    print(f"🎓 {title}")
    print("=" * 65)

def check_environment():
    print("\n[1/4] Verificando ambiente...")
    print(f"Diretório raiz: {BASE_DIR}")
    print(f"Versão do Python: {sys.version.split()[0]}")
    
    # Verifica pastas essenciais
    required_paths = ['templates', 'static', 'database', 'Ateniense.spec', 'app_launcher.py']
    for p in required_paths:
        full_p = os.path.join(BASE_DIR, p)
        if not os.path.exists(full_p):
            print(f"[ERRO] Item obrigatório não encontrado: {p}")
            return False
        print(f"  ✓ {p} encontrado.")
    return True

def install_pyinstaller():
    print("\n[2/4] Verificando PyInstaller...")
    try:
        import PyInstaller
        print(f"  ✓ PyInstaller instalado: versão {PyInstaller.__version__}")
        return True
    except ImportError:
        print("  Instalando PyInstaller...")
        res = subprocess.run([sys.executable, "-m", "pip", "install", "--upgrade", "pyinstaller"])
        return res.returncode == 0

def run_build():
    print("\n[3/4] Compilando executável com PyInstaller...")
    cmd = [sys.executable, "-m", "PyInstaller", "--clean", "-y", "Ateniense.spec"]
    res = subprocess.run(cmd)
    return res.returncode == 0

def verify_output():
    print("\n[4/4] Verificando resultado da compilação...")
    exe_path = os.path.join(BASE_DIR, "dist", "Ateniense.exe")
    if os.path.exists(exe_path):
        size_mb = os.path.getsize(exe_path) / (1024 * 1024)
        print_header("SUCESSO! EXECUTÁVEL GERADO COM ÊXITO")
        print(f"Local do arquivo: {exe_path}")
        print(f"Tamanho aproximado: {size_mb:.2f} MB")
        print("\nPara iniciar o sistema, basta dar dois cliques em Ateniense.exe!")
        print("=" * 65)
        return True
    else:
        # Se estiver no Mac/Linux, o arquivo pode ser apenas "Ateniense"
        unix_path = os.path.join(BASE_DIR, "dist", "Ateniense")
        if os.path.exists(unix_path):
            print(f"[INFO] Binário gerado para a plataforma atual: {unix_path}")
            print("Para gerar .exe para Windows, execute este script em um ambiente Windows.")
            return True
        print("[ERRO] Arquivo compilado não foi encontrado na pasta dist/")
        return False

def main():
    print_header("COMPILADOR MASTER ESCOLAR ATENIENSE")
    if not check_environment():
        sys.exit(1)
    if not install_pyinstaller():
        print("[ERRO] Falha ao instalar PyInstaller.")
        sys.exit(1)
    if not run_build():
        print("[ERRO] Falha na compilação.")
        sys.exit(1)
    if not verify_output():
        sys.exit(1)

if __name__ == '__main__':
    main()
