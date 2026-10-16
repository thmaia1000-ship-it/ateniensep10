# 🎓 Seção Aplicativos - Master Escolar Ateniense

Esta pasta contém as ferramentas e scripts automatizados para gerar a versão **Desktop Executável (.exe)** do sistema para computadores Windows.

---

## 📁 Conteúdo desta Pasta:

1. **`gerar_executavel.bat`**: Script em lote (*batch*) para execução direta no Windows com **1 duplo-clique**. Ele verifica o Python, instala o PyInstaller e compila o `.exe` automaticamente.
2. **`compilar_windows.py`**: Script Python complementar de automação e validação de arquivos para compilação.
3. **`Ateniense.spec`** (na raiz): Especificação detalhada de empacotamento do PyInstaller (inclui HTML, CSS, JS, banco SQLite e ícones).
4. **`app_launcher.py`** (na raiz): Ponto de entrada do executável que inicia o servidor local e abre o navegador automaticamente.

---

## 🚀 Como Gerar o Arquivo `.exe` no Windows:

### Método 1: Duplo-clique no `.bat` (Mais Simples)
1. Certifique-se de que o computador Windows possui o **Python 3.10+** instalado (durante a instalação, marque a caixa **"Add Python to PATH"**).
2. Dê **dois cliques** no arquivo:
   ```
   aplicativos\gerar_executavel.bat
   ```
   *(ou no `build_windows.bat` na raiz do projeto)*.
3. O script cuidará de tudo: instalação do PyInstaller, compilação dos módulos e empacotamento.
4. Ao finalizar, o arquivo estará pronto em:
   ```
   dist\Ateniense.exe
   ```

---

### Método 2: Via Linha de Comando (Prompt / PowerShell)
Abra a pasta do projeto no Prompt de Comando do Windows e execute:
```cmd
python aplicativos\compilar_windows.py
```
ou diretamente:
```cmd
pip install pyinstaller
pyinstaller --clean -y Ateniense.spec
```

---

## 🔒 Persistência dos Dados (Segurança Garantida):
- Quando o `.exe` é executado, ele armazena o banco de dados SQLite em uma subpasta permanente `database\ateniense.db`.
- Qualquer novo aluno matriculado, pagamento recebido, contrato impresso ou nota lançada **permanece salvo com segurança** após fechar o programa.
- Para realizar backup, basta copiar a pasta `database\`.
