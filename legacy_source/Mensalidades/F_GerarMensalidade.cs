using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Escolar.Caixa;
using Escolar.GerarContratos;

namespace Escolar
{
    public partial class F_GerarMensalidade : Form
    {
        private decimal _valorTotal;
        private decimal _valorParcela;
        private string _dataAtual;


        // Dicionário corrigido: ano -> contrato -> valor
        private readonly Dictionary<string, Dictionary<string, decimal>> _valoresPorAno =
            new Dictionary<string, Dictionary<string, decimal>>
            {
                ["2025"] = new Dictionary<string, decimal>
                {
                    ["NORMAL"] = 630m,
                    ["MEIO P."] = 1100m,
                    ["INTEGRAL"] = 1700m
                },
                ["2026"] = new Dictionary<string, decimal>
                {
                    ["NORMAL"] = 650m,
                    ["MEIO P."] = 1150m,
                    ["INTEGRAL"] = 1700m
                },
                ["2027"] = new Dictionary<string, decimal>
                {
                    ["NORMAL"] = 700m,
                    ["MEIO P."] = 1200m,
                    ["INTEGRAL"] = 1800m
                }
            };

        public F_GerarMensalidade()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            dgv_Parcelas.Columns[3].Visible = false;
            cb_Parcelas.SelectedIndex = 11;
            tb_Aluno.Text = "Busque aqui o Aluno(a)";

            // Configurar Contrato
            var contratos = new[] { "NORMAL", "MEIO P.", "INTEGRAL" };
            cb_contrato.DataSource = contratos;

            // Configurar Turno
            var turnos = new[] { "MATUTINO", "MATUTINO M. PERIODO", "VESPERTINO", "VESPERTINO M. PERIODO", "INTEGRAL" };
            cb_Turno.DataSource = turnos;


        }

        private void F_GerarMensalidade_Load(object sender, EventArgs e)
        {
            // Configurar data inicial

            if (Globais.Main.PassarPlanoContrato == "Matricula2027")
            {
                dtp_Data.Value = new DateTime(2027, 1, 9);
            }
            else
            {
                var dataAtual = CalcularQuintoDiaUtil(DateTime.Now.Month, DateTime.Now.Year);
                dtp_Data.Value = DateTime.ParseExact(dataAtual, "dd/MM/yyyy", null);
            }

            Globais.Main.PassarAno = dtp_Data.Value.ToString("yyyy");
            CarregarTurmas();
            AtualizarValores();

        }

        private void CalcularParcelas()
        {
            if (!ValidarCamposObrigatorios()) return;

            dgv_Parcelas.Rows.Clear();

            _valorTotal = decimal.Parse(tb_Valor.Text);
            var numeroParcelas = int.Parse(cb_Parcelas.Text);
            _valorParcela = Math.Round(_valorTotal / numeroParcelas, 2);

            var dataVencimento = dtp_Data.Value;
            for (int i = 1; i <= numeroParcelas; i++)
            {
                var dataPagamento = CalcularQuintoDiaUtil(dataVencimento.Month, dataVencimento.Year);
                dgv_Parcelas.Rows.Add(i, _valorParcela, dataPagamento);
                dataVencimento = dataVencimento.AddMonths(1);
            }
        }

        private void SalvarMensalidade()
        {
            if (!ValidarDadosSalvamento()) return;

            try
            {
                var idAluno = tb_Aluno.Tag.ToString();
                var dados = ObterDadosAluno(idAluno);
                Globais.Main.PassarContrato = cb_contrato.Text;

                RegistrarMensalidade(idAluno, dados);
                AtualizarDadosAluno(idAluno, dados);
                RegistrarTurmasAluno(idAluno, dados);

                MessageBox.Show("Mensalidade Registrada com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (PerguntarGerarContrato())
                {
                    GerarContrato();
                }

                if (PerguntarGerarTermoResponsabilidade())
                {
                    GerarTermoResponsabilidade();
                }

                AbrirPagamentoPrimeiraParcela();
                LimparFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private (string serie, string turno, int idEtapa, string nomeAluno, string nomeCurso)
            ObterDadosAluno(string idAluno)
        {
            var query = $@"
                SELECT 
                    a.etapa,
                    a.turno,
                    a.nome_aluno,
                    c.nome_curso,
                   	t.idetapa
                FROM tb_alunos a
                INNER JOIN tb_cursos c ON a.idcurso = c.ID_curso
                INNER JOIN tb_turmas t ON t.ID_turma = {cb_turma.SelectedValue}
                WHERE a.ID_aluno = {idAluno}";

            var dt = Banco.dql(query);
            if (dt.Rows.Count == 0) throw new Exception("Aluno não encontrado");

            var row = dt.Rows[0];
            Globais.Main.PassarIdAluno = idAluno;
            Globais.Main.PassarAluno = row["nome_aluno"].ToString();
            Globais.Main.PassarCurso = row["nome_curso"].ToString();
            Globais.Main.PassarAno = dtp_Data.Value.ToString("yyyy");

            return (
                row["etapa"].ToString(),
                row["turno"].ToString(),
                Convert.ToInt32(row["idetapa"]),
                row["nome_aluno"].ToString(),
                row["nome_curso"].ToString()
            );
        }

        private void RegistrarMensalidade(string idAluno, (string serie, string turno, int idEtapa, string nomeAluno, string nomeCurso) dados)
        {
            var dataAtual = DateTime.Now.ToString("yyyy-MM-dd");
            var horaAtual = DateTime.Now.ToString("HH:mm");
            _dataAtual = dtp_Data.Value.ToString("yyyy-MM-09");

            var query = $@"
                INSERT INTO tb_mensalidades 
                (n_parcelas, valor_total, saldo_devedor, valor_parcela, data_inicio, 
                 parcelas_pagas, data_gerada, horario, curso, idaluno, ano_letivo, 
                 usuario, idturma, turno, idresponsavel)
                VALUES 
                ({cb_Parcelas.Text}, '{_valorTotal:0.00}', '{_valorTotal:0.00}', '{_valorParcela:0.00}',
                 '{_dataAtual}', 0, '{dataAtual}', '{horaAtual}', '{dados.nomeCurso}',
                 {idAluno}, {Globais.Main.PassarAno}, '{Globais.Main.PassarUsuario}',
                 {dados.idEtapa}, '{cb_Turno.Text}', {cb_respFinan.SelectedValue})";

            Banco.dml(query);
        }

        private void AtualizarDadosAluno(string idAluno, (string serie, string turno, int idEtapa, string nomeAluno, string nomeCurso) dados)
        {
            var query = $@"
                UPDATE tb_alunos 
                SET etapa = '{dados.serie}', 
                    ano_letivo = {Globais.Main.PassarAno}, 
                    status = 'ATIVO',
                    turno = '{cb_Turno.Text}' 
                WHERE ID_aluno = {idAluno}";

            Banco.dml(query);
        }

        private void RegistrarTurmasAluno(string idAluno, (string serie, string turno, int idEtapa, string nomeAluno, string nomeCurso) dados)
        {
            if (cb_contrato.Text == "INTEGRAL")
            {
                RegistrarTurmasIntegral(idAluno, dados);
            }
            else
            {
                RegistrarTurmaNormal(idAluno);
            }
        }

        private void RegistrarTurmasIntegral(string idAluno, (string serie, string turno, int idEtapa, string nomeAluno, string nomeCurso) dados)
        {
            var query = $@"
                SELECT ID_turma 
                FROM tb_turmas 
                WHERE serie = '{dados.serie}' 
                AND turno != '{dados.turno}' 
                AND ano_letivo = '{Globais.Main.PassarAno}'";

            var dt = Banco.dql(query);
            if (dt.Rows.Count > 0)
            {
                var idTurma = Convert.ToInt32(dt.Rows[0]["ID_turma"]);
                RegistrarTurma(idAluno, cb_turma.SelectedValue.ToString());
                RegistrarTurma(idAluno, idTurma.ToString());
            }
        }

        private void RegistrarTurmaNormal(string idAluno)
        {
            RegistrarTurma(idAluno, cb_turma.SelectedValue.ToString());
        }

        private void RegistrarTurma(string idAluno, string idTurma)
        {
            var query = $@"
                INSERT INTO tb_alunos_turmas (idturma, idaluno, ano_letivo)
                VALUES ({idTurma}, {idAluno}, {Globais.Main.PassarAno})";
            Banco.dml(query);
        }

        private bool ValidarCamposObrigatorios()
        {
            if (string.IsNullOrEmpty(cb_Parcelas.Text) || string.IsNullOrEmpty(tb_Valor.Text))
            {
                MessageBox.Show("Todos os campos precisam ser preenchidos",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidarDadosSalvamento()
        {
            if (string.IsNullOrEmpty(tb_Aluno.Tag?.ToString()) || string.IsNullOrEmpty(tb_Valor.Text))
            {
                MessageBox.Show("Selecione um aluno e preencha o valor",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (MessageBox.Show("DESEJA GERAR A MENSALIDADE?", "Confirmação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return false;
            }

            return true;
        }

        private bool PerguntarGerarContrato()
        {
            return MessageBox.Show("GERAR CONTRATO?", "Confirmação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private bool PerguntarGerarTermoResponsabilidade()
        {
            return MessageBox.Show("GERAR TERMO DE RESPONSABILIDADE?", "Confirmação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void GerarContrato()
        {
            var idMensalidade = ObterUltimoIdMensalidade();
            Globais.Main.PassarID_Mensalidade = idMensalidade;

            Form contratoForm = null;

            // Usando if/else em vez de switch expression para compatibilidade com C# 7.3
            if (cb_contrato.Text == "NORMAL" && Globais.Main.PassarAno == "2026")
            {
                contratoForm = new F_ContratoNormal();
            }
            else if (cb_contrato.Text == "MEIO P." && Globais.Main.PassarAno == "2026")
            {
                contratoForm = new F_ContratoMeioPeriodo();
            }
            else if (cb_contrato.Text == "INTEGRAL" && Globais.Main.PassarAno == "2026")
            {
                contratoForm = new F_ContratoIntegral();
            }
            else if (Globais.Main.PassarAno == "2027")
            {
                contratoForm = new F_Contrato2027();
            }
            

            contratoForm?.ShowDialog();
        }

        private string ObterUltimoIdMensalidade()
        {
            var query = $@"
                SELECT ID_mensalidade 
                FROM tb_mensalidades 
                WHERE idaluno = {Globais.Main.PassarIdAluno} 
                ORDER BY ID_mensalidade DESC 
                LIMIT 1";

            var dt = Banco.dql(query);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["ID_mensalidade"].ToString();
            }
            return string.Empty;
        }

        private void GerarTermoResponsabilidade()
        {
            //var escolha = new F_EscolherRespAcad();
            //escolha.ShowDialog();

            var termo = new TermoResp();
            termo.ShowDialog();
        }

        private void AbrirPagamentoPrimeiraParcela()
        {
            var pagamento = new PagarPrimeiraParcela_Temp();
            pagamento.ShowDialog();
        }

        private void LimparFormulario()
        {
            tb_Aluno.Text = "Busque aqui o Aluno(a)";
            tb_Aluno.Tag = null;
            tb_Valor.Clear();
            cb_Parcelas.SelectedIndex = 0;
            dgv_Parcelas.Rows.Clear();
            Globais.Main.Modo = "";
        }

        private void AtualizarValores()
        {
            if (cb_contrato.SelectedItem == null || cb_Parcelas.SelectedItem == null) return;

            tb_Valor.Enabled = false;
            var ano = Globais.Main.PassarAno;
            var contrato = cb_contrato.SelectedItem.ToString();
            var parcelas = int.Parse(cb_Parcelas.Text);

            // Verificação corrigida para C# 7.3
            if (_valoresPorAno.ContainsKey(ano))
            {
                var valoresAno = _valoresPorAno[ano];
                if (valoresAno.ContainsKey(contrato))
                {
                    var valorMensal = valoresAno[contrato];
                    tb_Valor.Text = (valorMensal * parcelas).ToString();
                }
                else
                {
                    tb_Valor.Text = "0";
                }
            }
            else
            {
                tb_Valor.Text = "0";
            }

            CalcularParcelas();
        }

        private void CarregarTurmas()
        {
            var query = $@"
                SELECT ID_turma, nome_turma 
                FROM tb_turmas 
                WHERE ID_turma >= 1 
                AND ano_letivo = '{Globais.Main.PassarAno}'";

            cb_turma.DataSource = Banco.dql(query);
            cb_turma.DisplayMember = "nome_turma";
            cb_turma.ValueMember = "ID_turma";
            cb_turma.SelectedIndex = -1;
        }

        private void AbrirSelecaoAluno()
        {
            tb_Aluno.Clear();
            var selecao = new F_SelecionarAlunoGerarMensalidade(this);
            selecao.ShowDialog();
        }

        private void AbrirFormPorNivel(int nivel, Form form)
        {
            if (!Globais.logado)
            {
                MessageBox.Show("É necessário ter um usuário logado", "Acesso negado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Globais.nivel >= nivel)
            {
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acesso não permitido", "Acesso negado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static List<DateTime> ObterFeriados(int ano)
        {
            var feriados = new List<DateTime>
            {
                new DateTime(ano, 1, 1),   // Confraternização Universal
                new DateTime(ano, 4, 21),  // Tiradentes
                new DateTime(ano, 9, 7),   // Independência do Brasil
                new DateTime(ano, 10, 12), // Nossa Senhora Aparecida
                new DateTime(ano, 11, 2),  // Finados
                new DateTime(ano, 11, 15), // Proclamação da República
                new DateTime(ano, 12, 25), // Natal
                new DateTime(ano, 9, 5),   // Elevação do Amazonas
                new DateTime(ano, 10, 24), // Aniversário de Manaus
            };

            // Adicionar Carnaval (datas móveis para 2025, 2026, 2027)
            feriados.AddRange(ObterCarnaval(ano));

            return feriados;
        }

        private static List<DateTime> ObterCarnaval(int ano)
        {
            var carnaval = new List<DateTime>();
            switch (ano)
            {
                case 2025:
                    carnaval.AddRange(new[] { new DateTime(2025, 3, 3), new DateTime(2025, 3, 4), new DateTime(2025, 3, 5) });
                    break;
                case 2026:
                    carnaval.AddRange(new[] { new DateTime(2026, 2, 16), new DateTime(2026, 2, 17), new DateTime(2026, 2, 18) });
                    break;
                case 2027:
                    carnaval.AddRange(new[] { new DateTime(2027, 2, 8), new DateTime(2027, 2, 9), new DateTime(2027, 2, 10) });
                    break;
            }
            return carnaval;
        }

        private string CalcularQuintoDiaUtil(int mes, int ano)
        {
            var data = new DateTime(ano, mes, 1);
            var feriados = ObterFeriados(ano);
            var diasUteis = 0;

            while (diasUteis < 5)
            {
                if (data.DayOfWeek != DayOfWeek.Saturday &&
                    data.DayOfWeek != DayOfWeek.Sunday &&
                    !feriados.Contains(data))
                {
                    diasUteis++;
                }

                if (diasUteis < 5)
                {
                    data = data.AddDays(1);
                }
            }

            return data.ToString("dd/MM/yyyy");
        }

        private void btn_Parcelas_Click(object sender, EventArgs e) => CalcularParcelas();

        private void btn_Salvar_Click(object sender, EventArgs e) => SalvarMensalidade();

        private void btn_BuscarAluno_Click(object sender, EventArgs e) => AbrirSelecaoAluno();

        private void btn_Cancelar_Click(object sender, EventArgs e) => LimparFormulario();

        private void cb_contrato_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cb_contrato.Text == "INTEGRAL")
            {
                cb_Turno.Text = "INTEGRAL";
                cb_Turno.Enabled = false;
            }
            else
            {
                cb_Turno.Enabled = true;
            }

            AtualizarValores();
        }

        private void cb_Parcelas_SelectionChangeCommitted(object sender, EventArgs e) => AtualizarValores();

        private void dtp_Data_ValueChanged(object sender, EventArgs e)
        {
            Globais.Main.PassarAno = dtp_Data.Value.ToString("yyyy");
            CarregarTurmas();
            AtualizarValores();
        }

        private void F_GerarMensalidade_FormClosed(object sender, FormClosedEventArgs e)
        {
            Globais.Main.PassarAluno = "";
            Globais.Main.PassarIdAluno = "";
            Globais.Main.PassarAno = "";
        }

        private void F_GerarMensalidade_Leave(object sender, EventArgs e)
        {
            Globais.Main.Modo = "";
        }
    }
}