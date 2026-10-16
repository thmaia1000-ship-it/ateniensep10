using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Escolar
{
    public partial class F_SelecionarAlunoMensalidade : Form

    {
        F_PagarMensalidade f_selecionarAlunoCaixa;

        public F_SelecionarAlunoMensalidade(F_PagarMensalidade f)
        {
            InitializeComponent();
            f_selecionarAlunoCaixa = f;
        }
    
        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text != "")
            {
                var vcon = Banco.ConexaoBanco();

                MySqlCommand cm = new MySqlCommand();
                cm.CommandText = $@"
                SELECT tba.ID_aluno as 'ID', tba.nome_aluno as 'Aluno',tbm.valor_parcela as 'Parcela', tbm.ID_mensalidade as 'Contrato'
                FROM tb_alunos as tba
                INNER JOIN tb_mensalidades as tbm
                ON tbm.idaluno = tba.ID_aluno
                WHERE tba.nome_aluno LIKE '{tb_pesquisa.Text}%' AND tbm.ano_letivo={cb_ano.Text}";

                cm.Connection = vcon;
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cm;
                da.Fill(dt);
                dgv_SelecionarAluno.DataSource = dt;
                vcon.Close();
                dgv_SelecionarAluno.Columns[0].Width = 55;
                dgv_SelecionarAluno.Columns[1].Width = 455;
                dgv_SelecionarAluno.Columns[2].Width = 70;
                dgv_SelecionarAluno.Columns[3].Width = 60;
                dgv_SelecionarAluno.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else
            {
                MessageBox.Show("Preencha o campo nome para pesquisar");
                tb_pesquisa.Focus();
            }
        }
        private void dgv_SelecionarAluno_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            f_selecionarAlunoCaixa.tb_Aluno.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[1].Value.ToString();
            f_selecionarAlunoCaixa.tb_Aluno.Tag = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();

            Globais.Main.PassarID_Mensalidade = dgv.Rows[dgv.SelectedRows[0].Index].Cells[3].Value.ToString();

            Globais.Main.PassarAluno = f_selecionarAlunoCaixa.tb_Aluno.Text.ToString();
            Globais.Main.PassarIdAluno = f_selecionarAlunoCaixa.tb_Aluno.Tag.ToString();
            Globais.Main.PassarAno = cb_ano.SelectedValue.ToString();

            string vquery = String.Format(@"
            SELECT
                ID_mensalidade,
                n_parcelas,
                valor_parcela,
                saldo_devedor,
                valor_total,
                data_inicio,
                parcelas_pagas,
                curso
                FROM tb_mensalidades
                WHERE ID_mensalidade ={0}", Globais.Main.PassarID_Mensalidade);

            DataTable dt = Banco.dql(vquery);

            if (dt.Rows.Count > 0)
            {

                int ParcelasPendentes = dt.Rows[0].Field<Int32>("n_parcelas") - dt.Rows[0].Field<Int32>("parcelas_pagas");
                f_selecionarAlunoCaixa.cb_NParcelas.Text = "1";

                f_selecionarAlunoCaixa.tb_ValorPago.Text = dt.Rows[0].Field<decimal>("saldo_devedor").ToString("C");
                f_selecionarAlunoCaixa.tb_ValorParcela.Text = dt.Rows[0].Field<decimal>("valor_parcela").ToString("C");
                f_selecionarAlunoCaixa.lb_nParcelasPendentes.Text = ParcelasPendentes.ToString();
                f_selecionarAlunoCaixa.tb_ValorParcela.Tag = dt.Rows[0].Field<decimal>("valor_parcela").ToString();
                f_selecionarAlunoCaixa.lb_SubTotal.Text = dt.Rows[0].Field<decimal>("valor_parcela").ToString();
                f_selecionarAlunoCaixa.tb_nParcelasPagas.Text = dt.Rows[0].Field<Int32>("parcelas_pagas").ToString();
                f_selecionarAlunoCaixa.lb_Cursando.Text = dt.Rows[0].Field<string>("curso");
                f_selecionarAlunoCaixa.lb_RS.Text = "R$";
                f_selecionarAlunoCaixa.btn_Pagamento.Enabled = true;

                string SaldoCarteira = String.Format(@"
                SELECT saldo_carteira
                FROM tb_carteira_aluno
                WHERE idaluno={0}", Globais.Main.PassarIdAluno);
                DataTable saldocarteira = Banco.dql(SaldoCarteira);

                f_selecionarAlunoCaixa.lb_carteira.Text = saldocarteira.Rows[0].Field<decimal>("saldo_carteira").ToString("C");

                string PassarResponsavel = String.Format(@"
                SELECT 
                nome 
                FROM tb_responsavel_financeiro 
                WHERE idaluno=" + Globais.Main.PassarIdAluno);

                DataTable dtt = Banco.dql(PassarResponsavel);

                if (dtt.Rows.Count > 0)
                {
                    f_selecionarAlunoCaixa.lb_ResFinan.Text = dtt.Rows[0].Field<string>("nome");
                }
                else
                {
                    MessageBox.Show("Este Aluno(a) não possui um responsável financeiro cadastrado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                

                f_selecionarAlunoCaixa.dgv_Parcelas.Rows.Clear();

                string DataPaga = String.Format(@"
               SELECT c.horario, c.data, c.mensalidades_paga, IFNULL(t.soma_total, 0) AS valor_total_somado
                FROM (
                    SELECT horario, data, valor_total, mensalidades_paga, ID_caixa
                    FROM tb_caixa
                    WHERE descricao = 'Mensalidade' AND idmensalidade = {0}
                    GROUP BY mensalidades_paga
                ) c
                LEFT JOIN (
                    SELECT mensalidades_paga, SUM(valor_total) AS soma_total
                    FROM tb_caixa
                    WHERE descricao = 'Mensalidade'AND idmensalidade ={0}
                    GROUP BY mensalidades_paga
                ) t ON c.mensalidades_paga = t.mensalidades_paga
                ORDER BY c.mensalidades_paga

                ", Globais.Main.PassarID_Mensalidade);
                DataTable datapaga = Banco.dql(DataPaga);

                int Linha = -1;
                int Numero = 0;

                decimal Valor = dt.Rows[0].Field<decimal>("valor_parcela");
                int Nparcelas = dt.Rows[0].Field<Int32>("n_parcelas");
                int parcelas_pagas = dt.Rows[0].Field<Int32>("parcelas_pagas");

                String DataAtual = dt.Rows[0].Field<DateTime>("data_inicio").ToString(); ;
                int mes = 0;
                DateTime dttt = Convert.ToDateTime(DataAtual);
                DateTime DataHoje = DateTime.Today;

                for (int i = 1; i <= parcelas_pagas; i++)
                {
                    dttt = Convert.ToDateTime(DataAtual).AddMonths(-1);
                    mes = mes + 1;
                    dttt = dttt.AddMonths(mes);

                    // Obtém a data ajustada para cálculo
                    string dataCalculada = CalcularQuintoDiaUtil(dttt.Month, dttt.Year);
                    Numero = Numero + 1;
                    Linha++;

                    // Verifica se a parcela está dentro do prazo de pagamento
                    if (Convert.ToDateTime(dataCalculada) < DataHoje)
                    {
                        string Status = "ATRASADO";
                        f_selecionarAlunoCaixa.dgv_Parcelas.Rows.Add(Numero, datapaga.Rows[Linha].Field<decimal>("valor_total_somado").ToString("C"), dttt.ToShortDateString(), dataCalculada, dataCalculada, Status);
                        f_selecionarAlunoCaixa.dgv_Parcelas.Columns[2].Visible = false;
                    }
                    else
                    {
                        string Status = "ABERTO";
                        f_selecionarAlunoCaixa.dgv_Parcelas.Rows.Add(Numero, datapaga.Rows[Linha].Field<decimal>("valor_total_somado").ToString("C"), dttt.ToShortDateString(), dataCalculada, dataCalculada, Status);
                        f_selecionarAlunoCaixa.dgv_Parcelas.Columns[2].Visible = false;
                    }

                    if (parcelas_pagas > 0)
                    {
                        f_selecionarAlunoCaixa.dgv_Parcelas.Rows[Linha].Cells[4].Value = "PAGO";
                        f_selecionarAlunoCaixa.dgv_Parcelas.Rows[Linha].Cells[5].Value = datapaga.Rows[Linha].Field<DateTime>("data").ToString("dd/MM/yyyy");
                    }

                    Numero = Convert.ToInt32(f_selecionarAlunoCaixa.dgv_Parcelas.Rows[f_selecionarAlunoCaixa.dgv_Parcelas.Rows[Linha].Index].Cells[0].Value);
                }

                for (int i = 1; i <= Nparcelas - parcelas_pagas; i++)
                {
                    dttt = Convert.ToDateTime(DataAtual).AddMonths(-1);
                    mes = mes + 1;
                    dttt = dttt.AddMonths(mes);

                    // Obtém a data ajustada para cálculo
                    string dataCalculada = CalcularQuintoDiaUtil(dttt.Month, dttt.Year);
                    Numero = Numero + 1;

                    // Verifica se a parcela está dentro do prazo de pagamento
                    if (Convert.ToDateTime(dataCalculada) < DataHoje)
                    {
                        string Status = "ATRASADO";
                        f_selecionarAlunoCaixa.dgv_Parcelas.Rows.Add(Numero, Valor, dataCalculada, dataCalculada, Status);
                        f_selecionarAlunoCaixa.dgv_Parcelas.Columns[2].Visible = false;
                    }
                    else
                    {
                        string Status = "ABERTO";
                        f_selecionarAlunoCaixa.dgv_Parcelas.Rows.Add(Numero, Valor, dataCalculada, dataCalculada, Status);
                        f_selecionarAlunoCaixa.dgv_Parcelas.Columns[2].Visible = false;
                    }
                }
                Close();
            }
            else
            {
                MessageBox.Show("Este Aluno(a) não possui uma mensalidade cadastrada!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void F_SelecionarAlunoMensalidade_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> ano = new Dictionary<string, string>();

            ano.Add("2022", "2022");
            ano.Add("2023", "2023");
            ano.Add("2024", "2024");
            ano.Add("2025", "2025");
            ano.Add("2026", "2026");
            ano.Add("2027", "2027");
            ano.Add("2028", "2028");
            ano.Add("2029", "2029");
            ano.Add("2030", "2030");
            cb_ano.DataSource = new BindingSource(ano, null);
            cb_ano.DisplayMember = "Value";
            cb_ano.ValueMember = "Key";

            cb_ano.SelectedValue = DateTime.Now.ToString("yyyy");

            
        }

        // Lista de feriados fixos (dia e mês) no Brasil
        private static List<DateTime> FeriadosFixos(int ano)
        {
            return new List<DateTime>
        {
            new DateTime(ano, 1, 1),   // Confraternização Universal
            new DateTime(ano, 4, 21),  // Tiradentes
            //new DateTime(ano, 5, 1),   // Dia do Trabalho
            new DateTime(ano, 9, 7),   // Independência do Brasil
            new DateTime(ano, 10, 12), // Nossa Senhora Aparecida
            new DateTime(ano, 11, 2),  // Finados
            new DateTime(ano, 11, 15), // Proclamação da República
            new DateTime(ano, 12, 25),  // Natal

            // Feriados regionais de Manaus (Amazonas)
            new DateTime(ano, 9, 5),   // Elevação do Amazonas à categoria de província
            new DateTime(ano, 10, 24),  // Aniversário de Manaus
            // Carnaval
            new DateTime(ano, 3, 3),
            new DateTime(ano, 3, 4),
            new DateTime(ano, 3, 5),
        };
        }

        private string CalcularQuintoDiaUtil(int mes, int ano)
        {
            DateTime data = new DateTime(ano, mes, 1);
            int diaUtilCount = 0;

            List<DateTime> feriados = FeriadosFixos(ano);

            while (diaUtilCount < 5)
            {
                // Verifica se não é final de semana e nem feriado
                if (data.DayOfWeek != DayOfWeek.Saturday && data.DayOfWeek != DayOfWeek.Sunday && !feriados.Contains(data))
                {
                    diaUtilCount++;
                }

                if (diaUtilCount < 5)
                {
                    data = data.AddDays(1);
                }
            }

            return data.ToString("dd/MM/yyyy");
        }
    }
}
