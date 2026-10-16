using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Escolar.Notas.Selecionar
{
    public partial class SelecionarAluno : Form
    {
        private Gerar_Boletim gerar_Boletim;

        public SelecionarAluno(Gerar_Boletim f)
        {
            InitializeComponent();
            gerar_Boletim = f;
        }

        private void SelecionarAluno_Load(object sender, EventArgs e)
        {
            // Geração dinâmica dos anos letivos (reduz código repetitivo)
            var anos = new Dictionary<string, string>();
            for (int i = 2022; i <= 2030; i++)
            {
                anos.Add(i.ToString(), i.ToString());
            }

            cb_ano.DataSource = new BindingSource(anos, null);
            cb_ano.DisplayMember = "Value";
            cb_ano.ValueMember = "Key";
            cb_ano.SelectedValue = DateTime.Now.ToString("yyyy");

            // O método CarregarDados tratará da inicialização da turma e da grelha
            CarregarTurmas();
            CarregarDados();
        }

        private void CarregarTurmas()
        {
            string queryTurmas = $@"
                SELECT ID_turma, nome_turma 
                FROM tb_turmas 
                WHERE ID_turma >= 1 AND ano_letivo = '{cb_ano.SelectedValue}'";

            cb_turma.DataSource = Banco.dql(queryTurmas);
            cb_turma.DisplayMember = "nome_turma";
            cb_turma.ValueMember = "ID_turma";
        }

        // Fusão do método Atualizar e btn_Pesquisar_Click para evitar duplicação de código
        private void CarregarDados(string pesquisa = "")
        {
            string query = @"
                SELECT DISTINCT 
                    tba.ID_aluno AS 'ID',	
                    tba.nome_aluno AS 'Aluno(a)',
                    tba.etapa AS 'Etapa'
                FROM tb_alunos AS tba
                INNER JOIN tb_alunos_turmas AS tbt ON tbt.idaluno = tba.ID_aluno
                INNER JOIN tb_notas AS tbn ON tbn.idaluno = tba.ID_aluno AND tbn.ano_letivo = @anoLetivo
                WHERE tbt.idturma = @idTurma ";

            if (!string.IsNullOrWhiteSpace(pesquisa))
            {
                query += "AND tba.nome_aluno LIKE @pesquisa ";
            }
            query += "ORDER BY tba.nome_aluno";

            // Uso de blocos 'using' para garantir o fecho correto da ligação e libertação de memória
            using (var vcon = Banco.ConexaoBanco())
            using (var cm = new MySqlCommand(query, vcon))
            {
                cm.Parameters.AddWithValue("@anoLetivo", cb_ano.SelectedValue);
                cm.Parameters.AddWithValue("@idTurma", cb_turma.SelectedValue);

                if (!string.IsNullOrWhiteSpace(pesquisa))
                {
                    cm.Parameters.AddWithValue("@pesquisa", pesquisa + "%");
                }

                using (var da = new MySqlDataAdapter(cm))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv_SelecionarAluno.DataSource = dt;
                }
            }

            FormatarGrelha();
        }

        private void FormatarGrelha()
        {
            if (dgv_SelecionarAluno.Columns.Count >= 3)
            {
                dgv_SelecionarAluno.Columns[0].Width = 55;
                dgv_SelecionarAluno.Columns[1].Width = 563;
                dgv_SelecionarAluno.Columns[2].Width = 110;
            }
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            CarregarDados(tb_pesquisa.Text);
        }

        private void cb_turma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void dgv_SelecionarAluno_DoubleClick(object sender, EventArgs e)
        {
            if (dgv_SelecionarAluno.SelectedRows.Count == 0) return;

            DataGridViewRow linhaSelecionada = dgv_SelecionarAluno.SelectedRows[0];

            gerar_Boletim.tb_aluno.Tag = linhaSelecionada.Cells[0].Value.ToString();
            gerar_Boletim.tb_aluno.Text = linhaSelecionada.Cells[1].Value.ToString();
            string nomeEtapa = linhaSelecionada.Cells[2].Value.ToString().ToUpper();

            gerar_Boletim.dgv_Notas.Rows.Clear();
            Globais.Main.PassarAno = cb_ano.Text;

            // Ocultar labels por defeito. Apenas o 1º Ano as ativa.
            gerar_Boletim.lb_nota.Visible = false;
            gerar_Boletim.tb_nota.Visible = false;

            // Substituição de múltiplos IFs por Switch (mais legível e eficiente)
            switch (nomeEtapa)
            {
                case "MATERNAL I": Globais.Main.PassarIDEtapa = 1; break;
                case "JARDIM I": Globais.Main.PassarIDEtapa = 2; break;
                case "JARDIM II": Globais.Main.PassarIDEtapa = 3; break;
                case "MATERNAL II": Globais.Main.PassarIDEtapa = 5; break;
                case "1° ANO":
                case "1º ANO":
                    gerar_Boletim.lb_nota.Visible = true;
                    gerar_Boletim.tb_nota.Visible = true;
                    Globais.Main.PassarIDEtapa = 4;
                    break;
                default:
                    Globais.Main.PassarIDEtapa = 0;
                    break;
            }

            string queryNotas = $@"
                SELECT ID_nota, nota, materia, ano_letivo 
                FROM tb_notas 
                WHERE idaluno = {gerar_Boletim.tb_aluno.Tag} 
                  AND bimestre = {Globais.Main.PassarBimestre} 
                  AND idetapa = {Globais.Main.PassarIDEtapa} 
                  AND ano_letivo = '{Globais.Main.PassarAno}' 
                ORDER BY idmateria";

            DataTable notas = Banco.dql(queryNotas);

            if (notas.Rows.Count > 0)
            {
                Globais.Main.PassarAno = notas.Rows[0].Field<string>("ano_letivo");

                // Iteração simplificada (Foreach em vez de For com incremento manual de linha)
                foreach (DataRow row in notas.Rows)
                {
                    gerar_Boletim.dgv_Notas.Rows.Add(
                        row.Field<string>("nota"),
                        row.Field<string>("materia"),
                        row.Field<int>("ID_nota")
                    );
                }
                gerar_Boletim.btn_imprimir.Enabled = true;
            }
            else
            {
                MessageBox.Show($"O Aluno(a) não possui notas cadastradas referente ao {Globais.Main.PassarBimestre}º Bimestre",
                                "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gerar_Boletim.btn_imprimir.Enabled = false;
            }

            gerar_Boletim.dgv_Notas.ClearSelection();
            this.Close();
        }
    }
}