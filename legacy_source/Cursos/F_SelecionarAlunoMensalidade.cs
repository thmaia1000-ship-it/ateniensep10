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

namespace Escolar.Cursos
{
    public partial class F_SelecionarAlunoMensalidade : Form
    {

        Cursos.F_PagarMensalidadeCurso f_PagarMensalidadeCurso;

        public F_SelecionarAlunoMensalidade(Cursos.F_PagarMensalidadeCurso f)
        {
            InitializeComponent();
            f_PagarMensalidadeCurso = f;
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text != "")
            {

                var vcon = Banco.ConexaoBanco();

                MySqlCommand cm = new MySqlCommand();
                cm.CommandText = "SELECT tba.ID_aluno as 'ID', tba.nome_aluno as 'Aluno', tbc.nome_curso as 'Curso', tbm.curso as 'ID_curso', tbm.ID_mensalidade_curso as 'ID_mensalidade',tbm.ano_letivo as 'Ano Letivo' FROM tb_alunos as tba, tb_mensalidades_cursos as tbm,tb_cursos as tbc  WHERE tba.nome_aluno LIKE ('" + tb_pesquisa.Text + "%') AND tbm.idaluno = tba.ID_aluno AND tbc.ID_curso = tbm.curso AND tbm.ano_letivo="+ cb_ano.SelectedValue;

                cm.Connection = vcon;
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cm;
                da.Fill(dt);
                dgv_SelecionarAluno.DataSource = dt;
                vcon.Close();
                dgv_SelecionarAluno.Columns[0].Width = 55;
                dgv_SelecionarAluno.Columns[1].Width = 360;
                dgv_SelecionarAluno.Columns[2].Width = 130;
                dgv_SelecionarAluno.Columns[5].Width = 60;
                dgv_SelecionarAluno.Columns[3].Visible = false;
                dgv_SelecionarAluno.Columns[4].Visible = false;
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

            f_PagarMensalidadeCurso.tb_Aluno.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[1].Value.ToString();
            f_PagarMensalidadeCurso.tb_Aluno.Tag = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
            string ID_curso = dgv.Rows[dgv.SelectedRows[0].Index].Cells[3].Value.ToString();

            Globais.Main.PassarAluno = f_PagarMensalidadeCurso.tb_Aluno.Text.ToString();
            Globais.Main.PassarIdAluno = f_PagarMensalidadeCurso.tb_Aluno.Tag.ToString();
            Globais.Main.PassarID_Mensalidade = dgv.Rows[dgv.SelectedRows[0].Index].Cells[4].Value.ToString();
            Globais.Main.PassarCurso = ID_curso;
            Globais.Main.PassarAno = cb_ano.SelectedValue.ToString();
            f_PagarMensalidadeCurso.btn_excluir.Enabled = true;
            var vcon = Banco.ConexaoBanco();
            string vquery = String.Format(@"
            SELECT
                n_parcelas,
                valor_parcela,
                saldo_devedor,
                valor_total,
                data_inicio,
                parcelas_pagas,
                curso
                FROM tb_mensalidades_cursos
                WHERE idaluno={0} AND ID_mensalidade_curso={1} ", f_PagarMensalidadeCurso.tb_Aluno.Tag, Globais.Main.PassarID_Mensalidade);

            DataTable dt = Banco.dql(vquery);

            if (dt.Rows.Count > 0)
            {

                string vParcelas = String.Format(@"
                SELECT
                n_parcelas - parcelas_pagas as parcelas
                FROM tb_mensalidades_cursos
                WHERE idaluno={0} AND ID_mensalidade_curso={1}", f_PagarMensalidadeCurso.tb_Aluno.Tag, Globais.Main.PassarID_Mensalidade);

                DataTable dpc = Banco.dql(vParcelas);

                vcon.Close();
                f_PagarMensalidadeCurso.cb_NParcelas.Text = "1";

                f_PagarMensalidadeCurso.tb_ValorPago.Text = dt.Rows[0].Field<decimal>("saldo_devedor").ToString("C");
                f_PagarMensalidadeCurso.tb_ValorParcela.Text = dt.Rows[0].Field<decimal>("valor_parcela").ToString("C");
                f_PagarMensalidadeCurso.lb_nParcelasPendentes.Text = dpc.Rows[0].Field<Int64>("parcelas").ToString();
                f_PagarMensalidadeCurso.tb_ValorParcela.Tag = dt.Rows[0].Field<decimal>("valor_parcela").ToString();
                f_PagarMensalidadeCurso.lb_SubTotal.Text = dt.Rows[0].Field<decimal>("valor_parcela").ToString();
                f_PagarMensalidadeCurso.tb_nParcelasPagas.Text = dt.Rows[0].Field<Int32>("parcelas_pagas").ToString();
                ID_curso = dt.Rows[0].Field<Int32>("curso").ToString();

                string Nome_curso = String.Format(@"SELECT nome_curso FROM tb_cursos WHERE ID_curso={0}", ID_curso);
                DataTable nome_curso = Banco.dql(Nome_curso);

                f_PagarMensalidadeCurso.lb_Cursando.Text = nome_curso.Rows[0].Field<string>("nome_curso").ToUpper();
                f_PagarMensalidadeCurso.lb_RS.Text = "R$";
                f_PagarMensalidadeCurso.btn_Pagamento.Enabled = true;

                string Parcelas_Pagas = dt.Rows[0].Field<Int32>("parcelas_pagas").ToString();

                string SaldoCarteira = String.Format(@"
                SELECT saldo_carteira
                FROM tb_carteira_aluno
                WHERE idaluno={0}", Globais.Main.PassarIdAluno);
                DataTable saldocarteira = Banco.dql(SaldoCarteira);


                f_PagarMensalidadeCurso.lb_carteira.Text = saldocarteira.Rows[0].Field<decimal>("saldo_carteira").ToString("C");

                vcon.Close();

                var vconn = Banco.ConexaoBanco();
                string PassarResponsavel = String.Format(@"
                SELECT 
                nome 
                FROM tb_responsavel_financeiro 
                WHERE idaluno=" + f_PagarMensalidadeCurso.tb_Aluno.Tag);

                DataTable dtt = Banco.dql(PassarResponsavel);

                if (dtt.Rows.Count > 0)
                {
                    f_PagarMensalidadeCurso.lb_ResFinan.Text = dtt.Rows[0].Field<string>("nome");
                }
                else
                {
                    MessageBox.Show("Este Aluno(a) não possui um responsável financeiro cadastrado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //Globais.Main.PassarIdAluno = f_PagarMensalidadeCurso.lb_ResFinan.Text;
                vconn.Close();

                //Testando
                decimal Valor;
                int Nparcelas, parcelas_pagas;
                string DataAtual;

                f_PagarMensalidadeCurso.dgv_Parcelas.Rows.Clear();

                Valor = dt.Rows[0].Field<decimal>("valor_parcela");
                Nparcelas = Convert.ToInt32(dt.Rows[0].Field<Int32>("n_parcelas"));
                parcelas_pagas = Convert.ToInt32(dt.Rows[0].Field<Int32>("parcelas_pagas"));

                DataAtual = dt.Rows[0].Field<DateTime>("data_inicio").ToString(); ;
                int mes = 0;
                DateTime dttt = Convert.ToDateTime(DataAtual);
                DateTime DataHoje = DateTime.Today;


                string DataPaga = String.Format(@"
                SELECT c.horario, c.data, c.mensalidades_paga, IFNULL(t.soma_total, 0) AS valor_total_somado
                FROM (
                    SELECT horario, data, valor_total, mensalidades_paga, ID_caixa
                    FROM tb_caixa
                    WHERE descricao = 'Mensalidade Curso' AND curso='{1}' AND idaluno = {0} AND idmensalidade= {2}
                    GROUP BY mensalidades_paga
                ) c
                LEFT JOIN (
                    SELECT mensalidades_paga, SUM(valor_total) AS soma_total
                    FROM tb_caixa
                    WHERE descricao = 'Mensalidade Curso' AND curso='{1}' AND idaluno = {0} AND idmensalidade= {2}
                    GROUP BY mensalidades_paga
                ) t ON c.mensalidades_paga = t.mensalidades_paga
                ORDER BY c.mensalidades_paga", f_PagarMensalidadeCurso.tb_Aluno.Tag, f_PagarMensalidadeCurso.lb_Cursando.Text, Globais.Main.PassarID_Mensalidade);
                DataTable datapaga = Banco.dql(DataPaga);


                if (dpc.Rows[0].Field<Int64>("parcelas") < 0)
                {
                    f_PagarMensalidadeCurso.lb_nParcelasPendentes.Text = "0";
                }

                int Linha = -1;
                int Numero = 0;

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
                        f_PagarMensalidadeCurso.dgv_Parcelas.Rows.Add(Numero, datapaga.Rows[Linha].Field<decimal>("valor_total_somado").ToString("C"), dttt.ToShortDateString(), dataCalculada, dataCalculada, Status);
                        f_PagarMensalidadeCurso.dgv_Parcelas.Columns[2].Visible = false;
                    }
                    else
                    {
                        string Status = "ABERTO";
                        f_PagarMensalidadeCurso.dgv_Parcelas.Rows.Add(Numero, datapaga.Rows[Linha].Field<decimal>("valor_total_somado").ToString("C"), dttt.ToShortDateString(), dataCalculada, dataCalculada, Status);
                        f_PagarMensalidadeCurso.dgv_Parcelas.Columns[2].Visible = false;
                    }

                    if (parcelas_pagas > 0)
                    {
                        f_PagarMensalidadeCurso.dgv_Parcelas.Rows[Linha].Cells[4].Value = "PAGO";
                        f_PagarMensalidadeCurso.dgv_Parcelas.Rows[Linha].Cells[5].Value = datapaga.Rows[Linha].Field<DateTime>("data").ToString("dd/MM/yyyy");
                    }

                    Numero = Convert.ToInt32(f_PagarMensalidadeCurso.dgv_Parcelas.Rows[f_PagarMensalidadeCurso.dgv_Parcelas.Rows[Linha].Index].Cells[0].Value);
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
                        f_PagarMensalidadeCurso.dgv_Parcelas.Rows.Add(Numero, Valor, dataCalculada, dataCalculada, Status);
                        f_PagarMensalidadeCurso.dgv_Parcelas.Columns[2].Visible = false;
                    }
                    else
                    {
                        string Status = "ABERTO";
                        f_PagarMensalidadeCurso.dgv_Parcelas.Rows.Add(Numero, Valor, dataCalculada, dataCalculada, Status);
                        f_PagarMensalidadeCurso.dgv_Parcelas.Columns[2].Visible = false;
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
