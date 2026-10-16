# 🎓 Master Escolar Ateniense — Plataforma Web

Sistema completo de Gestão Escolar e Financeira do **Centro Educacional Ateniense**, totalmente convertido do legado C# (Windows Forms) para uma moderna aplicação Web responsiva, rápida e intuitiva.

---

## 🚀 Como Iniciar o Sistema

### Opção 1: Pelo script executável
Dê um duplo clique ou execute no terminal:
```bash
./iniciar_sistema.sh
```
O sistema iniciará e abrirá automaticamente no navegador em: **[http://localhost:8080](http://localhost:8080)**.

### Opção 2: Manualmente via terminal
```bash
python3 server.py 8080
```
E acesse `http://localhost:8080` no navegador.

---

## 🔐 Credenciais de Acesso (Importadas do Banco Original)

| Usuário | Senha | Nível | Perfil |
| :--- | :--- | :--- | :--- |
| **admin** | `140602` | **5** | Administrador Geral |
| **IURY** | `iury1304a` | **5** | Direção / Gestão |
| **emelly** | `emelly26` | **3** | Secretaria / Operacional |

---

## 📊 Banco de Dados & Importação

O banco de dados foi completamente importado a partir do dump oficial **`dbateniense.sql`**:

| Tabela | Registros Importados | Descrição |
| :--- | :---: | :--- |
| `tb_faltas_historico` | **31.317** | Histórico de chamadas e faltas |
| `tb_notas` | **15.457** | Lançamentos de notas bimestrais |
| `tb_caixa` | **8.512** | Livro Caixa e fluxo de movimentações financeiras |
| `tb_vendas` | **3.203** | Vendas efetuadas (PDV de produtos e uniformes) |
| `tb_diario` | **2.738** | Diário online e planejamentos pedagógicos |
| `tb_mensalidades` | **468** | Contratos de mensalidades escolares |
| `tb_contas` | **393** | Contas e caixas |
| `tb_mensalidades_cursos` | **329** | Mensalidades de cursos livres |
| `tb_carteira_aluno` | **322** | Carteirinhas dos alunos |
| `tb_observacoes` | **305** | Observações pedagógicas |
| `tb_responsavel_financeiro` | **295** | Cadastro de responsáveis financeiros |
| `tb_alunos_turmas` | **292** | Alocações de alunos em turmas |
| `tb_responsavel_academico` | **285** | Cadastro de responsáveis acadêmicos |
| `tb_alunos` | **283** | Alunos cadastrados com ficha completa |
| `tb_materias` | **157** | Disciplinas da grade curricular |
| `tb_produtos` | **51** | Estoque de produtos da loja escolar |
| `tb_turmas` | **31** | Turmas escolares |
| `tb_professores` | **5** | Corpo docente |
| `tb_bimestres` | **4** | Bimestres letivos |

> **Nota:** Caso deseje restaurar ou sincronizar o banco a qualquer momento, basta clicar no botão **"Reimportar Banco SQL"** na tela de Gestão de Usuários ou executar `python3 import_database.py`.

---

## 📋 Mapeamento de Menus e Funcionalidades

### 1. Secretaria
- **Nova Matrícula:** Cadastro completo do aluno, responsável financeiro, responsável acadêmico e turma.
- **Consultar Matrículas:** Listagem com busca instantânea por nome, matrícula, bairro e status.
- **Responsável Acadêmico / Responsável Financeiro:** Gestão de contatos, CPF, RG e endereços.
- **Contratos:** Contrato Normal, Meio Período, Integral e Matrícula 2027.
- **Termo de Responsabilidade:** Emissão em formato oficial timbrado com assinatura.
- **Gerar Carnê Escolar:** Emissão de boletos/carnê com todas as parcelas do ano.
- **Professores:** Cadastro e consulta do corpo docente.

### 2. Acadêmico
- **Gerar Boletim Escolar:** Cálculo automático de notas do 1º ao 4º bimestre, médias, faltas e situação do aluno (Aprovado / Recuperação).
- **Diário Online:** Registro de aulas, atividades pedagógicas, recursos e objetivos.
- **Gestão de Turmas:** Visualização das turmas, turnos, professores alocados e alunos.
- **Definir Bimestres:** Datas de início e término dos períodos letivos.

### 3. Financeiro
- **Livro Caixa:** Extrato em tempo real de entradas e saídas, com cálculo do saldo líquido atual, filtros por período e forma de pagamento.
- **Receber Mensalidade:** Baixa de parcelas em aberto, cálculo do saldo devedor restante e emissão instantânea de recibo.
- **Mensalidades (Cursos & Horários):** Painel para consultar e alterar os valores das mensalidades de todos os cursos (Educação Infantil, Ensino Fundamental, Dança, Judô, Futebol, Formatura) e horários/turnos oferecidos (Matutino, Vespertino, Meio Período, Integral), com opção de reajustar automaticamente contratos em aberto.
- **2ª Via de Recibos:** Emissão de comprovantes de pagamento e recebimento timbrados.

### 4. Contábil & DRE
- **Despesas:** Cadastro de despesas operacionais com opção de lançamento automático de saída no caixa.
- **DRE Gerencial:** Demonstrativo de Resultado do Exercício com comparativo mês a mês de receitas, despesas e resultado líquido.

### 5. Produtos & PDV (Frente de Caixa)
- **Estoque & Preços:** Catálogo de uniformes, materiais e produtos com preços de custo e venda.
- **PDV (Frente de Caixa):** Ponto de Venda interativo com carrinho, seleção rápida, baixa automática de estoque e lançamento no fluxo de caixa.

### 6. Cursos Livres
- Gestão de cursos extracurriculares, matrículas e controle de mensalidades de cursos.

### 7. Declarações Oficiais
Todas formatadas em padrão timbrado oficial do **Centro Educacional Ateniense**, prontas para visualização e impressão direta (A4):
- Declaração de Matrícula
- Declaração de Quitação de Débitos
- Declaração de Comparecimento
- Declaração de Frequência Escolar
- Guia de Transferência
- Termo de Rescisão Contratual
