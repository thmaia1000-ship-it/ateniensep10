@echo off
chcp 65001 > nul
title Compilador Master Escolar Ateniense - Windows EXE
color 0A

echo ======================================================================
echo       🎓 MASTER ESCOLAR ATENIENSE - GERADOR DE EXECUTÁVEL (.EXE)
echo ======================================================================
echo.

cd /d "%~dp0.."

echo [1/4] Verificando instalacao do Python...
python --version > nul 2>&1
if %errorlevel% neq 0 (
    color 0C
    echo [ERRO] Python nao foi encontrado no PATH do Windows!
    echo.
    echo Por favor, instale o Python 3.10 ou superior pelo site oficial (python.org).
    echo IMPORTANTE: Durante a instalacao, marque a opcao "Add Python to PATH".
    echo.
    pause
    exit /b 1
)
python --version

echo.
echo [2/4] Verificando e instalando PyInstaller...
python -m pip install --upgrade pip
python -m pip install --upgrade pyinstaller

if %errorlevel% neq 0 (
    color 0C
    echo.
    echo [ERRO] Falha ao instalar o PyInstaller via pip. Verifique sua conexao com a internet.
    pause
    exit /b 1
)

echo.
echo [3/4] Compilando executavel nativo (.exe)...
pyinstaller --clean -y Ateniense.spec

if %errorlevel% neq 0 (
    color 0C
    echo.
    echo [ERRO] Ocorreu uma falha durante a compilacao com o PyInstaller.
    pause
    exit /b 1
)

echo.
echo [4/4] Verificando arquivo gerado...
if exist "dist\Ateniense.exe" (
    color 0A
    echo.
    echo ======================================================================
    echo  SUCESSO! O executavel Windows foi gerado com exito:
    echo  -> dist\Ateniense.exe
    echo ======================================================================
    echo.
    echo Como usar:
    echo 1. Basta dar dois cliques em "dist\Ateniense.exe" para abrir o sistema.
    echo 2. O banco de dados sera mantido automaticamente na pasta database\
    echo 3. Voce pode mover a pasta dist para onde desejar ou criar um atalho no Desktop.
    echo.
) else (
    color 0C
    echo [AVISO] O processo finalizou, mas nao localizou dist\Ateniense.exe.
)

pause
