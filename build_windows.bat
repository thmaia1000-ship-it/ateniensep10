@echo off
chcp 65001 > nul
title Compilador Master Escolar Ateniense - Windows EXE
cd /d "%~dp0"

echo ========================================================
echo  🎓 Compilador Master Escolar Ateniense (.exe Windows)
echo ========================================================
echo.

python --version > nul 2>&1
if %errorlevel% neq 0 (
    echo [ERRO] Python nao foi encontrado no PATH do Windows.
    echo Instale o Python 3 (marcando a opcao "Add Python to PATH") e tente novamente.
    pause
    exit /b 1
)

echo [1/3] Instalando/atualizando o PyInstaller...
python -m pip install --upgrade pip
python -m pip install --upgrade pyinstaller

echo.
echo [2/3] Gerando o executavel com PyInstaller...
pyinstaller --clean -y Ateniense.spec

if %errorlevel% neq 0 (
    echo.
    echo [ERRO] Falha ao compilar o executavel. Verifique as mensagens acima.
    pause
    exit /b 1
)

echo.
echo ========================================================
echo [3/3] SUCESSO! Executavel gerado na pasta "dist/":
echo   -^> dist\Ateniense.exe
echo.
echo Para executar, basta dar dois cliques em dist\Ateniense.exe!
echo ========================================================
pause
