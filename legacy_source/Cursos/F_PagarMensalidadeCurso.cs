using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Cursos
{
    public partial class F_PagarMensalidadeCurso : Form
    {
        decimal ValorParcela, ValorTotalParcela;
        public F_PagarMensalidadeCurso()
        {
            InitializeComponent();
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            Cursos.F_SelecionarAlunoMensalidade f_SelecionarAlunoMensalidade = new Cursos.F_SelecionarAlunoMensalidade(this);
            f_SelecionarAlunoMensalidade.ShowDialog();
        }

        private void abreForm(int nivel, Form f)
        {
            if (Globais.logado)
            {

                if (Globais.nivel >= nivel)
                //Procedimentos
                {

                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Acesso não permitido");
                }

            }
            else
            {
                MessageBox.Show("É necessário ter um usuário logado");
            }
        }
        private void Atualizar()
        {
            string ID_curso = Globais.Main.PassarCurso;

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
                WHERE idaluno={0} AND ID_mensalidade_curso={1}", tb_Aluno.Tag, Globais.Main.PassarID_Mensalidade);

            DataTable dt = Banco.dql(vquery);

            if (dt.Rows.Count > 0)
            {

                string vParcelas = String.Format(@"
                SELECT
                n_parcelas - parcelas_pagas as parcelas
                FROM tb_mensalidades_cursos
                WHERE idaluno =" + tb_Aluno.Tag);

                DataTable dpc = Banco.dql(vParcelas);

                vcon.Close();
                cb_NParcelas.Text = "1";

                tb_ValorPago.Text = dt.Rows[0].Field<decimal>("saldo_devedor").ToString("C");
                tb_ValorParcela.Text = dt.Rows[0].Field<decimal>("valor_parcela").ToString("C");
                lb_nParcelasPendentes.Text = dpc.Rows[0].Field<Int64>("parcelas").ToString();
                tb_ValorParcela.Tag = dt.Rows[0].Field<decimal>("valor_parcela").ToString();
                lb_SubTotal.Text = dt.Rows[0].Field<decimal>("valor_parcela").ToString();
                tb_nParcelasPagas.Text = dt.Rows[0].Field<Int32>("parcelas_pagas").ToString();
                ID_curso = dt.Rows[0].Field<Int32>("curso").ToString();

                string Nome_curso = String.Format(@"SELECT nome_curso FROM tb_cursos WHERE ID_curso={0}", ID_curso);
                DataTable nome_curso = Banco.dql(Nome_curso);

                lb_Cursando.Text = nome_curso.Rows[0].Field<string>("nome_curso").ToUpper();
                lb_RS.Text = "R$";
                btn_Pagamento.Enabled = true;

                string Parcelas_Pagas = dt.Rows[0].Field<Int32>("parcelas_pagas").ToString();

                string SaldoCarteira = String.Format(@"
                SELECT saldo_carteira
                FROM tb_carteira_aluno
                WHERE idaluno={0}", Globais.Main.PassarIdAluno);
                DataTable saldocarteira = Banco.dql(SaldoCarteira);


                lb_carteira.Text = saldocarteira.Rows[0].Field<decimal>("saldo_carteira").ToString("C");

                vcon.Close();

                var vconn = Banco.ConexaoBanco();
                string PassarResponsavel = String.Format(@"
                SELECT 
                nome 
                FROM tb_responsavel_financeiro 
                WHERE idaluno=" + tb_Aluno.Tag);

                DataTable dtt = Banco.dql(PassarResponsavel);

                if (dtt.Rows.Count > 0)
                {
                    lb_ResFinan.Text = dtt.Rows[0].Field<string>("nome");
                }
                else
                {
                    MessageBox.Show("Este Aluno(a) não possui um responsável financeiro cadastrado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //Globais.Main.PassarIdAluno = lb_ResFinan.Text;
                vconn.Close();

                //Testando
                decimal Valor;
                int Nparcelas, parcelas_pagas;
                string DataAtual;

                dgv_Parcelas.Rows.Clear();

                Valor = dt.Rows[0].Field<decimal>("valor_parcela");
                Nparcelas = Convert.ToInt32(dt.Rows[0].Field<Int32>("n_parcelas"));
                parcelas_pagas = Convert.ToInt32(dt.Rows[0].Field<Int32>("parcelas_pagas"));

                DataAtual = dt.Rows[0].Field<DateTime>("data_inicio").ToString(); ;
                int mes = 0;
                DateTime dttt = Convert.ToDateTime(DataAtual);
                DateTime DataHoje = DateTime.Today;

                if (dpc.Rows[0].Field<Int64>("parcelas") < 0)
                {
                    lb_nParcelasPendentes.Text = "0";
                }

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
                ORDER BY c.mensalidades_paga", tb_Aluno.Tag, lb_Cursando.Text, Globais.Main.PassarID_Mensalidade);
                DataTable datapaga = Banco.dql(DataPaga);


                if (dpc.Rows[0].Field<Int64>("parcelas") < 0)
                {
                    lb_nParcelasPendentes.Text = "0";
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
                        dgv_Parcelas.Rows.Add(Numero, datapaga.Rows[Linha].Field<decimal>("valor_total_somado").ToString("C"), dttt.ToShortDateString(), dataCalculada, dataCalculada, Status);
                        dgv_Parcelas.Columns[2].Visible = false;
                    }
                    else
                    {
                        string Status = "ABERTO";
                        dgv_Parcelas.Rows.Add(Numero, datapaga.Rows[Linha].Field<decimal>("valor_total_somado").ToString("C"), dttt.ToShortDateString(), dataCalculada, dataCalculada, Status);
                        dgv_Parcelas.Columns[2].Visible = false;
                    }

                    if (parcelas_pagas > 0)
                    {
                        dgv_Parcelas.Rows[Linha].Cells[4].Value = "PAGO";
                        dgv_Parcelas.Rows[Linha].Cells[5].Value = datapaga.Rows[Linha].Field<DateTime>("data").ToString("dd/MM/yyyy");
                    }

                    Numero = Convert.ToInt32(dgv_Parcelas.Rows[dgv_Parcelas.Rows[Linha].Index].Cells[0].Value);
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
                        dgv_Parcelas.Rows.Add(Numero, Valor, dataCalculada, dataCalculada, Status);
                        dgv_Parcelas.Columns[2].Visible = false;
                    }
                    else
                    {
                        string Status = "ABERTO";
                        dgv_Parcelas.Rows.Add(Numero, Valor, dataCalculada, dataCalculada, Status);
                        dgv_Parcelas.Columns[2].Visible = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Este Aluno(a) não possui uma mensalidade cadastrada!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_atualizar_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (tb_Aluno.Text != "Busque aqui o Aluno(a)")
            {
                Gestão.F_GestaoMensalidadeCursos f_GestaoMensalidadeCursos = new Gestão.F_GestaoMensalidadeCursos();
                abreForm(1, f_GestaoMensalidadeCursos);
            }
            else
            {
                MessageBox.Show("Você precisa selecionar um Aluno(a)", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void F_PagarMensalidadeCurso_Load(object sender, EventArgs e)
        {
            tb_Aluno.Text = "Busque aqui o Aluno(a)";
            lb_nParcelasPendentes.Text = "";
            tb_ValorPago.Text = "";
            tb_ValorParcela.Text = "";
            lb_SubTotal.Text = "";
            lb_RS.Text = "";
            lb_Cursando.Text = "";
            btn_Pagamento.Enabled = false;
            dgv_Parcelas.Columns[2].Visible = false;
            lb_carteira.Text = "";
            btn_excluir.Enabled = false;
        }

        private void dgv_Parcelas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgv_Parcelas.ClearSelection();
            if (this.dgv_Parcelas.Columns[e.ColumnIndex].Name == "Status")
            {
                if (e.Value != null && (string)e.Value == "PAGO")
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
                else if (e.Value != null && (string)e.Value == "ATRASADO")
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            tb_Aluno.Text = "Busque aqui o Aluno(a)";
            lb_nParcelasPendentes.Text = "";
            tb_ValorPago.Text = "";
            tb_ValorParcela.Text = "";
            lb_SubTotal.Text = "";
            lb_RS.Text = "";
            cb_NParcelas.Text = "1";
            btn_Pagamento.Enabled = false;
            lb_Cursando.Text = "";
            lb_carteira.Text = "";
            btn_excluir.Enabled = false;
            for (int i = 0; i < dgv_Parcelas.RowCount; i++)
            {
                dgv_Parcelas.Rows[i].DataGridView.Columns.Clear();
            }
        }

        private void btn_Pagamento_Click(object sender, EventArgs e)
        {
            if (lb_nParcelasPendentes.Text == "0")
            {
                
                MessageBox.Show("Não é possível confirmar o pagamento, pois este Aluno(a) já pagou todas as suas parcelas", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                Cursos.F_FormaPagamentoCurso f_FormaPagamentoCurso = new Cursos.F_FormaPagamentoCurso(this);
                abreForm(1, f_FormaPagamentoCurso);

                Atualizar();

            }
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmar exclusão?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string ExcluirRegistro = String.Format(@"DELETE FROM tb_mensalidades_cursos WHERE ID_mensalidade_curso =" + Globais.Main.PassarID_Mensalidade);
                MessageBox.Show("Exclusão feita com sucesso!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Banco.dml(ExcluirRegistro);
            }
        }

        private void cb_NParcelas_ValueChanged(object sender, EventArgs e)
        {
            if (cb_NParcelas.Value == 1)
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 1;
                lb_SubTotal.Text = ValorTotalParcela.ToString();
            }
            else if (cb_NParcelas.Value == 2)
            {
                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 2;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.Value == 3)
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 3;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.Value == 4)
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 4;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.Value == 5)
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 5;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.Value == 6)
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 6;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.Value == 7)
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 7;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.Value == 8)
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 8;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.Value == 9)
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 9;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.Value == 10)
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 10;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.Value == 11)
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 11;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.Value == 12)
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 12;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
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
