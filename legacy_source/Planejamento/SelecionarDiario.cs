using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Escolar.Diario
{
    public partial class SelecionarDiario : Form
    {
        public SelecionarDiario()
        {
            InitializeComponent();
        }

        private void BuscaFiltrada(string data_inicio, string data_fim, string professor, string serie)
        {
            using (var vcon = Banco.ConexaoBanco())
            {
                // Montar filtros
                List<string> filtros = new List<string>();
                filtros.Add("tbd.data_diario BETWEEN @data_inicio AND @data_fim");

                if (professor != "Nenhum")
                    filtros.Add("tbd.nome_professor = @professor");

                if (serie != "0")
                    filtros.Add("tbd.turma = @serie");

                string whereFinal = "WHERE " + string.Join(" AND ", filtros);

                string sql = $@"
            SELECT    
                tbd.ID_diario AS 'ID',
                tbd.nome_professor AS 'Professor',
                tbt.turno AS 'Turno',
                tbd.data_diario AS 'Dt. Diario',
                tbd.serie AS 'Serie'
            FROM tb_diario tbd
            INNER JOIN tb_turmas tbt ON tbd.turma = tbt.ID_turma
            {whereFinal}
            ORDER BY tbd.nome_professor, data_diario
        ";

                MySqlCommand cm = new MySqlCommand(sql, vcon);

                // Parâmetros obrigatórios
                cm.Parameters.AddWithValue("@data_inicio", data_inicio);
                cm.Parameters.AddWithValue("@data_fim", data_fim);

                // Parâmetros opcionais
                if (professor != "Nenhum")
                    cm.Parameters.AddWithValue("@professor", professor);

                if (serie != "0")
                    cm.Parameters.AddWithValue("@serie", serie);

                // Preenche DataGridView
                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgv_planejamentos.DataSource = dt;

                // Ajustes de layout
                dgv_planejamentos.Columns[0].Width = 45;
                dgv_planejamentos.Columns[1].Width = 200;
                dgv_planejamentos.Columns[2].Width = 80;
                dgv_planejamentos.Columns[3].Width = 80;
                dgv_planejamentos.Columns[4].Width = 90;

                dgv_planejamentos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {

            string data_inicio = dtp_Data1.Value.ToString("yyyy-MM-dd");
            string data_fim = dtp_Data2.Value.ToString("yyyy-MM-dd");
            string professor = cb_professor.Text;
            string serie = cb_etapa.SelectedValue.ToString();

            BuscaFiltrada(data_inicio,data_fim,professor, serie);
        }

        private void dgv_SelecionarAluno_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            Globais.Main.PassarIDDiario = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();

            diario_online documento_Diario = new diario_online();
            documento_Diario.Show();
        }

        private void SelecionarDiario_Load(object sender, EventArgs e)
        {
            string vqueryTurmas = $@"
            SELECT
                ID_turma,
                nome_turma
            FROM
                tb_turmas
            WHERE ano_letivo = {dtp_Data1.Value:yyyy}
            ORDER BY
                ID_turma";

            cb_etapa.Items.Clear();

            DataTable dtTurmas = Banco.dql(vqueryTurmas);


            DataRow novaLinha = dtTurmas.NewRow();
            novaLinha["ID_turma"] = 0;
            novaLinha["nome_turma"] = "Todas";
            dtTurmas.Rows.InsertAt(novaLinha, 0);

            cb_etapa.DataSource = dtTurmas;
            cb_etapa.DisplayMember = "nome_turma";
            cb_etapa.ValueMember = "ID_turma";

            cb_etapa.SelectedValue = 0;

            string vqueryProfessor = @"
            SELECT
                ID_professor,
                nome_professor
            FROM
                tb_professores
            WHERE ID_professor > 1
            ORDER BY
                nome_professor";

            cb_professor.Items.Clear();

            DataTable dtProfessores = Banco.dql(vqueryProfessor);

            DataRow LinhaNova= dtProfessores.NewRow();
            LinhaNova["ID_professor"] = 0;
            LinhaNova["nome_professor"] = "Nenhum";
            dtProfessores.Rows.InsertAt(LinhaNova, 0);

            // Define o DataSource do ComboBox
            cb_professor.DataSource = dtProfessores;
            cb_professor.DisplayMember = "nome_professor";
            cb_professor.ValueMember = "ID_professor";

            // Define o valor padrão para o ComboBox
            cb_professor.SelectedValue = 0; // Seleciona "Nenhum" por padrão


            DateTime data = DateTime.Today;
            DateTime primeiroDiaDoMes = new DateTime(data.Year, data.Month, 1);
            DateTime ultimoDiaDoMes = new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month));

            dtp_Data1.Value = primeiroDiaDoMes;
            dtp_Data2.Value = ultimoDiaDoMes;

            var vcon = Banco.ConexaoBanco();

            MySqlCommand cm = new MySqlCommand();
            cm.CommandText = String.Format(@"
            SELECT
            tbd.ID_diario as 'ID',
            tbd.nome_professor as 'Professor',
            tbt.turno as 'Turno',
            tbd.data_diario as 'Dt. Diario',
            tbd.serie as 'Serie'
            FROM tb_diario as tbd
            INNER JOIN tb_turmas as tbt
            WHERE tbd.data_diario BETWEEN '{0}' AND '{1}' ORDER BY tbd.nome_professor", primeiroDiaDoMes.ToString("yyyy-MM-dd"), ultimoDiaDoMes.ToString("yyyy-MM-dd"));

            cm.Connection = vcon;
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cm;
            da.Fill(dt);
            dgv_planejamentos.DataSource = dt;
            vcon.Close();
            dgv_planejamentos.Columns[0].Width = 45;
            dgv_planejamentos.Columns[1].Width = 200;
            dgv_planejamentos.Columns[2].Width = 80;
            dgv_planejamentos.Columns[3].Width = 80;
            dgv_planejamentos.Columns[4].Width = 90;
            dgv_planejamentos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void cb_etapa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string data_inicio = dtp_Data1.Value.ToString("yyyy-MM-dd");
            string data_fim = dtp_Data2.Value.ToString("yyyy-MM-dd");
            string professor = cb_professor.Text;
            string serie = cb_etapa.SelectedValue.ToString();

            BuscaFiltrada(data_inicio, data_fim, professor, serie);
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            int Linha = -1;

            for (int i = 1; i <= dgv_planejamentos.Rows.Count; i++)
            {
                Linha = Linha + 1;

                Globais.Main.PassarIDDiario= dgv_planejamentos.Rows[dgv_planejamentos.Rows[Linha].Index].Cells[0].Value.ToString();
                
                documento_Diario documento_Diario = new documento_Diario();
                documento_Diario.Show();
            }
        }

    }
}
