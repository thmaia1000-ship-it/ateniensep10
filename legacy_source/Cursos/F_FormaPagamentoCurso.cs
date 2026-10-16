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
    public partial class F_FormaPagamentoCurso : Form
    {
        Cursos.F_PagarMensalidadeCurso f_FormaDePagamento;

        decimal Recebido, Total, Troco, Desconto;
        int modo;

        public F_FormaPagamentoCurso(Cursos.F_PagarMensalidadeCurso f)
        {
            InitializeComponent();
            f_FormaDePagamento = f;
        }

        private void calcular()
        {
            if (tb_Desconto.Text == "")
            {
                tb_Desconto.Text = "0";
            }

            else
            {
                if (modo == 2)
                {
                    string SaldoCarteira = String.Format(@"
                        SELECT saldo_carteira
                        FROM tb_carteira_aluno
                        WHERE idaluno={0}", Globais.Main.PassarIdAluno);
                    DataTable saldocarteira = Banco.dql(SaldoCarteira);

                    decimal Saldo_Carteira = saldocarteira.Rows[0].Field<decimal>("saldo_carteira");

                    if (Globais.Main.Modo == "3")
                    {
                        decimal ValorTotal = Convert.ToDecimal(f_FormaDePagamento.lb_SubTotal.Text.Replace(".", ","));

                        if (ValorTotal > Saldo_Carteira)
                        {
                            decimal Valor = ValorTotal - Saldo_Carteira;
                            lb_Total.Text = Valor.ToString();
                            tb_Valor.Text = Valor.ToString().Replace(".", ",");
                        }
                        else
                        {
                            lb_Total.Text = "0,00";
                            tb_Valor.Text = "0,00";
                        }

                        //Acrescimo Crédito

                        tb_Troco.Text = "0";
                        Total = decimal.Parse(lb_Total.Text);
                        Recebido = decimal.Parse(tb_Valor.Text.Replace(".", ","));
                        Desconto = decimal.Parse(tb_Desconto.Text.Replace(".", ","));
                        Desconto = decimal.Parse(tb_Valor.Text.Replace(".", ",")) * Desconto / 100;
                        Total = decimal.Parse(tb_Valor.Text.Replace(".", ",")) + Desconto;
                        lb_Total.Text = Total.ToString();
                        tb_Valor.Text = Total.ToString();

                    }
                    else if (Saldo_Carteira < 0)
                    {
                        decimal ValorTotal = Convert.ToDecimal(f_FormaDePagamento.lb_SubTotal.Text.Replace(".", ","));
                        decimal Valor = ValorTotal - Saldo_Carteira;
                        lb_Total.Text = Valor.ToString().Replace(".", ",");
                        tb_Valor.Text = Valor.ToString();
                        tb_Troco.Text = "0";
                        Total = decimal.Parse(lb_Total.Text);
                        Recebido = decimal.Parse(tb_Valor.Text.Replace(".", ","));
                        Desconto = decimal.Parse(tb_Desconto.Text.Replace(".", ","));
                        Desconto = decimal.Parse(tb_Valor.Text.Replace(".", ",")) * Desconto / 100;
                        Total = decimal.Parse(tb_Valor.Text.Replace(".", ",")) + Desconto;
                        lb_Total.Text = Total.ToString();
                        tb_Valor.Text = Total.ToString();
                    }
                    else
                    {
                        //Acrescimo Crédito

                        lb_Total.Text = f_FormaDePagamento.lb_SubTotal.Text;
                        tb_Valor.Text = f_FormaDePagamento.lb_SubTotal.Text;

                        tb_Troco.Text = "0";
                        Total = decimal.Parse(lb_Total.Text);
                        Recebido = decimal.Parse(tb_Valor.Text.Replace(".", ","));
                        Desconto = decimal.Parse(tb_Desconto.Text.Replace(".", ","));
                        Desconto = decimal.Parse(tb_Valor.Text.Replace(".", ",")) * Desconto / 100;
                        Total = decimal.Parse(tb_Valor.Text.Replace(".", ",")) + Desconto;
                        lb_Total.Text = Total.ToString();
                        tb_Valor.Text = Total.ToString();
                    }

                }

                else
                {

                    if (tb_Valor.Enabled == true && tb_Desconto.Text == "0")
                    {
                        string SaldoCarteira = String.Format(@"
                        SELECT saldo_carteira
                        FROM tb_carteira_aluno
                        WHERE idaluno={0}", Globais.Main.PassarIdAluno);
                        DataTable saldocarteira = Banco.dql(SaldoCarteira);

                        decimal Saldo_Carteira = saldocarteira.Rows[0].Field<decimal>("saldo_carteira");

                        if (Globais.Main.Modo == "3")
                        {
                            decimal ValorTotal = Convert.ToDecimal(f_FormaDePagamento.lb_SubTotal.Text.Replace(".", ","));

                            if (ValorTotal > Saldo_Carteira)
                            {
                                decimal Valor = ValorTotal - Saldo_Carteira;
                                lb_Total.Text = Valor.ToString();
                                tb_Valor.Text = Valor.ToString().Replace(".", ",");
                            }
                            else
                            {
                                lb_Total.Text = "0,00";
                                tb_Valor.Text = "0,00";
                            }
                        }
                        else if (Saldo_Carteira < 0)
                        {
                            decimal ValorTotal = Convert.ToDecimal(f_FormaDePagamento.lb_SubTotal.Text.Replace(".", ","));
                            decimal Valor = ValorTotal - Saldo_Carteira;
                            lb_Total.Text = Valor.ToString();
                            tb_Valor.Text = Valor.ToString().Replace(".", ",");
                        }
                        else
                        {
                            lb_Total.Text = f_FormaDePagamento.lb_SubTotal.Text;
                        }

                        tb_Troco.Text = "0";
                        Total = decimal.Parse(lb_Total.Text);
                        Recebido = decimal.Parse(tb_Valor.Text.Replace(".", ","));
                        Desconto = decimal.Parse(tb_Desconto.Text.Replace(".", ","));

                        Recebido = Recebido - Total;
                        Troco = Recebido - Desconto;
                        tb_Troco.Text = Troco.ToString();
                        lb_Total.Text = Total.ToString();
                    }
                    else if (tb_Valor.Enabled == true && tb_Desconto.Text != "0")
                    {
                        string SaldoCarteira = String.Format(@"
                        SELECT saldo_carteira
                        FROM tb_carteira_aluno
                        WHERE idaluno={0}", Globais.Main.PassarIdAluno);
                        DataTable saldocarteira = Banco.dql(SaldoCarteira);

                        decimal Saldo_Carteira = saldocarteira.Rows[0].Field<decimal>("saldo_carteira");

                        if (Globais.Main.Modo == "3")
                        {
                            decimal ValorTotal = Convert.ToDecimal(f_FormaDePagamento.lb_SubTotal.Text.Replace(".", ","));

                            if (ValorTotal > Saldo_Carteira)
                            {
                                decimal Valor = ValorTotal - Saldo_Carteira;
                                lb_Total.Text = Valor.ToString();
                                tb_Valor.Text = Valor.ToString().Replace(".", ",");
                            }
                            else
                            {
                                lb_Total.Text = "0,00";
                                tb_Valor.Text = "0,00";
                            }
                        }
                        else if (Saldo_Carteira < 0)
                        {
                            decimal ValorTotal = Convert.ToDecimal(f_FormaDePagamento.lb_SubTotal.Text.Replace(".", ","));
                            decimal Valor = ValorTotal - Saldo_Carteira;
                            lb_Total.Text = Valor.ToString();
                            tb_Valor.Text = Valor.ToString().Replace(".", ",");
                        }
                        else
                        {
                            lb_Total.Text = f_FormaDePagamento.lb_SubTotal.Text;
                        }
                        Total = decimal.Parse(lb_Total.Text);
                        Recebido = decimal.Parse(tb_Valor.Text.Replace(".", ","));
                        Desconto = decimal.Parse(tb_Desconto.Text.Replace(".", ","));

                        Desconto = Total - Desconto;
                        Troco = Recebido - Desconto;
                        tb_Troco.Text = Troco.ToString();
                        lb_Total.Text = Desconto.ToString();

                        if (tb_Valor.Enabled == true && tb_Troco.Text != "0")
                        {
                            tb_Troco.Text = "";

                            Saldo_Carteira = saldocarteira.Rows[0].Field<decimal>("saldo_carteira");

                            if (Globais.Main.Modo == "3")
                            {
                                decimal ValorTotal = Convert.ToDecimal(f_FormaDePagamento.lb_SubTotal.Text.Replace(".", ","));

                                if (ValorTotal > Saldo_Carteira)
                                {
                                    decimal Valor = ValorTotal - Saldo_Carteira;
                                    lb_Total.Text = Valor.ToString();
                                    tb_Valor.Text = Valor.ToString().Replace(".", ",");
                                }
                                else
                                {
                                    lb_Total.Text = "0,00";
                                    tb_Valor.Text = "0,00";
                                }
                            }
                            else if (Saldo_Carteira < 0)
                            {
                                decimal ValorTotal = Convert.ToDecimal(f_FormaDePagamento.lb_SubTotal.Text.Replace(".", ","));
                                decimal Valor = ValorTotal - Saldo_Carteira;
                                lb_Total.Text = Valor.ToString();
                                tb_Valor.Text = Valor.ToString().Replace(".", ",");
                            }
                            else
                            {
                                lb_Total.Text = f_FormaDePagamento.lb_SubTotal.Text;
                            }
                            //lb_Total.Text = f_FormaDePagamento.lb_SubTotal.Text;
                            Total = decimal.Parse(lb_Total.Text);
                            Recebido = decimal.Parse(tb_Valor.Text.Replace(".", ","));
                            Desconto = decimal.Parse(tb_Desconto.Text.Replace(".", ","));

                            Desconto = Total - Desconto;
                            Troco = Recebido - Desconto;
                            tb_Troco.Text = Troco.ToString();
                            lb_Total.Text = Desconto.ToString();
                        }
                    }
                    else if (tb_Valor.Enabled == false && tb_Troco.Text == "0")
                    {
                        string SaldoCarteira = String.Format(@"
                        SELECT saldo_carteira
                        FROM tb_carteira_aluno
                        WHERE idaluno={0}", Globais.Main.PassarIdAluno);
                        DataTable saldocarteira = Banco.dql(SaldoCarteira);

                        decimal Saldo_Carteira = saldocarteira.Rows[0].Field<decimal>("saldo_carteira");

                        if (Globais.Main.Modo == "3")
                        {
                            decimal ValorTotal = Convert.ToDecimal(f_FormaDePagamento.lb_SubTotal.Text.Replace(".", ","));

                            if (ValorTotal > Saldo_Carteira)
                            {
                                decimal Valor = ValorTotal - Saldo_Carteira;
                                lb_Total.Text = Valor.ToString();
                                tb_Valor.Text = Valor.ToString().Replace(".", ",");
                            }
                            else
                            {
                                lb_Total.Text = "0,00";
                                tb_Valor.Text = "0,00";
                            }
                        }
                        else if (Saldo_Carteira < 0)
                        {
                            decimal ValorTotal = Convert.ToDecimal(f_FormaDePagamento.lb_SubTotal.Text.Replace(".", ","));
                            decimal Valor = ValorTotal - Saldo_Carteira;
                            lb_Total.Text = Valor.ToString().Replace(".", ",");
                            tb_Valor.Text = Valor.ToString();
                        }
                        else
                        {
                            lb_Total.Text = f_FormaDePagamento.lb_SubTotal.Text.Replace(".", ",");
                            tb_Valor.Text = f_FormaDePagamento.lb_SubTotal.Text;
                        }
                        Total = decimal.Parse(tb_Valor.Text.Replace(".", ","));
                        Desconto = decimal.Parse(tb_Desconto.Text.Replace(".", ","));
                        Desconto = Total - Desconto;
                        tb_Troco.Text = "0.00";
                        lb_Total.Text = Desconto.ToString();
                        tb_Valor.Text = Desconto.ToString();
                    }
                    else if (tb_Valor.Enabled == false && tb_Troco.Text != "0")
                    {
                        string SaldoCarteira = String.Format(@"
                        SELECT saldo_carteira
                        FROM tb_carteira_aluno
                        WHERE idaluno={0}", Globais.Main.PassarIdAluno);
                        DataTable saldocarteira = Banco.dql(SaldoCarteira);

                        decimal Saldo_Carteira = saldocarteira.Rows[0].Field<decimal>("saldo_carteira");

                        if (Globais.Main.Modo == "3")
                        {
                            decimal ValorTotal = Convert.ToDecimal(f_FormaDePagamento.lb_SubTotal.Text.Replace(".", ","));

                            if (ValorTotal > Saldo_Carteira)
                            {
                                decimal Valor = ValorTotal - Saldo_Carteira;
                                lb_Total.Text = Valor.ToString();
                                tb_Valor.Text = Valor.ToString().Replace(".", ",");
                            }
                            else
                            {
                                lb_Total.Text = "0,00";
                                tb_Valor.Text = "0,00";
                            }
                        }
                        else if (Saldo_Carteira < 0)
                        {
                            decimal ValorTotal = Convert.ToDecimal(f_FormaDePagamento.lb_SubTotal.Text.Replace(".", ","));
                            decimal Valor = ValorTotal - Saldo_Carteira;
                            lb_Total.Text = Valor.ToString().Replace(".", ",");
                            tb_Valor.Text = Valor.ToString();
                        }
                        else
                        {
                            lb_Total.Text = f_FormaDePagamento.lb_SubTotal.Text.Replace(".", ",");
                            tb_Valor.Text = f_FormaDePagamento.lb_SubTotal.Text;
                        }

                        Total = decimal.Parse(tb_Valor.Text.Replace(".", ","));
                        Desconto = decimal.Parse(tb_Desconto.Text.Replace(".", ","));
                        Desconto = Total - Desconto;
                        tb_Troco.Text = "0.00";
                        lb_Total.Text = Desconto.ToString();
                        tb_Valor.Text = Desconto.ToString();

                    }
                }
            }
        }

            private void btn_Dinheiro_Click(object sender, EventArgs e)
        {
            modo = 0;
            lb_desconto.Text = "Desconto";
            btn_Salvar.Enabled = true;
            gpb_FormaPag.Enabled = true;
            lb_RSdesc.Text = "R$";
            lb_FormaPagamento.Text = "DINHEIRO";
            lb_FormaPagamento.ForeColor = Color.Green;
            tb_Valor.Enabled = true;
            tb_Valor.Cursor.Equals(Cursors.IBeam);
            tb_Troco.Text = "0,00";
            tb_Desconto.Text = "0";
            tb_Valor.Text = f_FormaDePagamento.lb_SubTotal.Text;
            lb_Total.Text = f_FormaDePagamento.lb_SubTotal.Text;

            string SaldoCarteira = String.Format(@"
                SELECT saldo_carteira
                FROM tb_carteira_aluno
                WHERE idaluno={0}", Globais.Main.PassarIdAluno);
            DataTable saldocarteira = Banco.dql(SaldoCarteira);

            decimal Saldo_Carteira = saldocarteira.Rows[0].Field<decimal>("saldo_carteira");

            if (Globais.Main.Modo == "3")
            {
                decimal ValorTotal = Convert.ToDecimal(f_FormaDePagamento.lb_SubTotal.Text.Replace(".", ","));

                if (ValorTotal > Saldo_Carteira)
                {
                    decimal Valor = ValorTotal - Saldo_Carteira;
                    lb_Total.Text = Valor.ToString();
                    tb_Valor.Text = Valor.ToString().Replace(".", ",");
                }
                else
                {
                    lb_Total.Text = "0,00";
                    tb_Valor.Text = "0,00";
                }

            }
            else if (Saldo_Carteira < 0)
            {
                decimal ValorTotal = Convert.ToDecimal(f_FormaDePagamento.lb_SubTotal.Text.Replace(".", ","));
                decimal Valor = ValorTotal - Saldo_Carteira;
                lb_Total.Text = Valor.ToString().Replace(".", ",");
                tb_Valor.Text = Valor.ToString();
            }
        }

        private void btn_Pix_Click(object sender, EventArgs e)
        {
            modo = 0;
            lb_desconto.Text = "Desconto";
            lb_RSdesc.Text = "R$";
            btn_Salvar.Enabled = true;
            gpb_FormaPag.Enabled = true;
            lb_FormaPagamento.Text = "PIX";
            lb_FormaPagamento.ForeColor = Color.Green;
            tb_Valor.Enabled = false;
            tb_Valor.Cursor.Equals(Cursors.No);
            tb_Troco.Text = "0,00";
            tb_Desconto.Text = "0";
            tb_Valor.Text = f_FormaDePagamento.lb_SubTotal.Text;
            lb_Total.Text = f_FormaDePagamento.lb_SubTotal.Text;

            string SaldoCarteira = String.Format(@"
                SELECT saldo_carteira
                FROM tb_carteira_aluno
                WHERE idaluno={0}", Globais.Main.PassarIdAluno);
            DataTable saldocarteira = Banco.dql(SaldoCarteira);

            decimal Saldo_Carteira = saldocarteira.Rows[0].Field<decimal>("saldo_carteira");

            if (Globais.Main.Modo == "3")
            {

                decimal ValorTotal = Convert.ToDecimal(f_FormaDePagamento.lb_SubTotal.Text.Replace(".", ","));

                if (ValorTotal > Saldo_Carteira)
                {
                    decimal Valor = ValorTotal - Saldo_Carteira;
                    lb_Total.Text = Valor.ToString();
                    tb_Valor.Text = Valor.ToString().Replace(".", ",");
                }
                else
                {
                    lb_Total.Text = "0,00";
                    tb_Valor.Text = "0,00";
                }

            }
            else if (Saldo_Carteira < 0)
            {
                decimal ValorTotal = Convert.ToDecimal(f_FormaDePagamento.lb_SubTotal.Text.Replace(".", ","));
                decimal Valor = ValorTotal - Saldo_Carteira;
                lb_Total.Text = Valor.ToString().Replace(".", ",");
                tb_Valor.Text = Valor.ToString();
            }
        }

        private void btn_Debito_Click(object sender, EventArgs e)
        {
            modo = 0;
            lb_desconto.Text = "Desconto";
            lb_RSdesc.Text = "R$";
            btn_Salvar.Enabled = true;
            gpb_FormaPag.Enabled = true;
            lb_FormaPagamento.Text = "DÉBITO";
            lb_FormaPagamento.ForeColor = Color.Green;
            tb_Valor.Enabled = false;
            tb_Valor.Cursor.Equals(Cursors.No);
            tb_Troco.Text = "0,00";
            tb_Desconto.Text = "0";
            tb_Valor.Text = f_FormaDePagamento.lb_SubTotal.Text;
            lb_Total.Text = f_FormaDePagamento.lb_SubTotal.Text;

            string SaldoCarteira = String.Format(@"
                SELECT saldo_carteira
                FROM tb_carteira_aluno
                WHERE idaluno={0}", Globais.Main.PassarIdAluno);
            DataTable saldocarteira = Banco.dql(SaldoCarteira);

            decimal Saldo_Carteira = saldocarteira.Rows[0].Field<decimal>("saldo_carteira");

            if (Globais.Main.Modo == "3")
            {

                decimal ValorTotal = Convert.ToDecimal(f_FormaDePagamento.lb_SubTotal.Text.Replace(".", ","));

                if (ValorTotal > Saldo_Carteira)
                {
                    decimal Valor = ValorTotal - Saldo_Carteira;
                    lb_Total.Text = Valor.ToString();
                    tb_Valor.Text = Valor.ToString().Replace(".", ",");
                }
                else
                {
                    lb_Total.Text = "0,00";
                    tb_Valor.Text = "0,00";
                }
            }
            else if (Saldo_Carteira < 0)
            {
                decimal ValorTotal = Convert.ToDecimal(f_FormaDePagamento.lb_SubTotal.Text.Replace(".", ","));
                decimal Valor = ValorTotal - Saldo_Carteira;
                lb_Total.Text = Valor.ToString().Replace(".", ",");
                tb_Valor.Text = Valor.ToString();
            }
        }

        private void btn_Credito_Click(object sender, EventArgs e)
        {
            modo = 0;
            lb_desconto.Text = "Desconto";
            lb_RSdesc.Text = "%";
            btn_Salvar.Enabled = true;
            gpb_FormaPag.Enabled = true;
            lb_FormaPagamento.Text = "CRÉDITO";
            lb_FormaPagamento.ForeColor = Color.Green;
            tb_Valor.Enabled = false;
            tb_Valor.Cursor.Equals(Cursors.No);
            tb_Troco.Text = "0,00";
            tb_Desconto.Text = "0";
            tb_Valor.Text = f_FormaDePagamento.lb_SubTotal.Text;
            lb_Total.Text = f_FormaDePagamento.lb_SubTotal.Text;

            string SaldoCarteira = String.Format(@"
                SELECT saldo_carteira
                FROM tb_carteira_aluno
                WHERE idaluno={0}", Globais.Main.PassarIdAluno);
            DataTable saldocarteira = Banco.dql(SaldoCarteira);

            decimal Saldo_Carteira = saldocarteira.Rows[0].Field<decimal>("saldo_carteira");

            if (Globais.Main.Modo == "3")
            {

                decimal ValorTotal = Convert.ToDecimal(f_FormaDePagamento.lb_SubTotal.Text.Replace(".", ","));

                if (ValorTotal > Saldo_Carteira)
                {
                    decimal Valor = ValorTotal - Saldo_Carteira;
                    lb_Total.Text = Valor.ToString();
                    tb_Valor.Text = Valor.ToString().Replace(".", ",");
                }
                else
                {
                    lb_Total.Text = "0,00";
                    tb_Valor.Text = "0,00";
                }
            }
            else if (Saldo_Carteira < 0)
            {
                decimal ValorTotal = Convert.ToDecimal(f_FormaDePagamento.lb_SubTotal.Text.Replace(".", ","));
                decimal Valor = ValorTotal - Saldo_Carteira;
                lb_Total.Text = Valor.ToString().Replace(".", ",");
                tb_Valor.Text = Valor.ToString();
            }

            if (MessageBox.Show("A VISTA?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                lb_RSdesc.Text = "%";
                lb_desconto.Text = "Acréscimo %";
                modo = 2;
            }

        }

        private void F_FormaPagamentoCurso_Load(object sender, EventArgs e)
        {
            btn_Salvar.Enabled = false;
            btn_Salvar.Enabled = false;
            gpb_FormaPag.Enabled = false;
            tb_Valor.Text = f_FormaDePagamento.lb_SubTotal.Text.Replace(".", ",");
            lb_Total.Text = f_FormaDePagamento.lb_SubTotal.Text;


            tb_Desconto.Text = "0";
            tb_Troco.Text = "0,00";

            lb_nomeUsuario.Text = Globais.Main.PassarUsuario;

            string SaldoCarteira = String.Format(@"
                SELECT saldo_carteira
                FROM tb_carteira_aluno
                WHERE idaluno={0}", Globais.Main.PassarIdAluno);
            DataTable saldocarteira = Banco.dql(SaldoCarteira);

            decimal Saldo_Carteira = saldocarteira.Rows[0].Field<decimal>("saldo_carteira");

            if (Saldo_Carteira > 0)
            {
                if (MessageBox.Show("O Aluno(a) possui " + Saldo_Carteira.ToString("C") + " de saldo. Deseja Usar?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    decimal ValorTotal = Convert.ToDecimal(f_FormaDePagamento.lb_SubTotal.Text.Replace(".", ","));
                    Globais.Main.Modo = "3";
                    if (ValorTotal > Saldo_Carteira)
                    {
                        decimal Valor = ValorTotal - Saldo_Carteira;
                        lb_Total.Text = Valor.ToString();
                        tb_Valor.Text = Valor.ToString().Replace(".", ",");
                    }

                    else
                    {
                        lb_Total.Text = "0,00";
                        tb_Valor.Text = "0,00";
                    }
                }
                else
                {
                    Globais.Main.Modo = "";
                }
            }
            else if (Saldo_Carteira < 0)
            {
                decimal ValorTotal = Convert.ToDecimal(f_FormaDePagamento.lb_SubTotal.Text.Replace(".", ","));
                decimal Valor = ValorTotal - Saldo_Carteira;
                lb_Total.Text = Valor.ToString();
                tb_Valor.Text = Valor.ToString().Replace(".", ",");
                Globais.Main.Modo = "4";
            }
        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            calcular();
            if (modo == 2)
            {
                modo = 0;
            }
            string Data = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime Horario = DateTime.Now;
            if (MessageBox.Show("CONFIRMAR O RECEBIMENTO DA MENSALIDADE?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Globais.Main.PassarData = "";
                Globais.Main.PassarHorario = "";
                Globais.Main.PassarCaixa = lb_Total.Text;

                int Minuto = 0;

                for (int i = 1; i <= f_FormaDePagamento.cb_NParcelas.Value; i++)
                {
                    var vcon = Banco.ConexaoBanco();
                    string DescontarMensalidade = string.Format(@"UPDATE tb_mensalidades_cursos 
                                    SET 
                                    saldo_devedor= saldo_devedor - valor_parcela,
                                    parcelas_pagas = parcelas_pagas + 1
                                    WHERE ID_mensalidade_curso={0}",  Globais.Main.PassarID_Mensalidade);

                    Banco.dml(DescontarMensalidade);
                    vcon.Close();

                    decimal Valor_Total = Convert.ToDecimal(lb_Total.Text) / f_FormaDePagamento.cb_NParcelas.Value;

                    if (modo == 0)
                    {
                        Minuto = Minuto + 1;
                        DateTime MinutoHorario = Horario.AddMinutes(Minuto);

                        string Mensalidades = String.Format(@"SELECT IFNULL (MAX(mensalidades_paga),0) as mensalidades_pagas FROM tb_caixa WHERE descricao = 'Mensalidade Curso' AND idaluno={0} AND curso='{1}' AND idmensalidade={2}", Globais.Main.PassarIdAluno,f_FormaDePagamento.lb_Cursando.Text, Globais.Main.PassarID_Mensalidade);

                        DataTable mensalidades = Banco.dql(Mensalidades);

                        string Mensalidades_Pagas = mensalidades.Rows[0].Field<Int64>("mensalidades_pagas").ToString();
                        int Mensalidade_Paga = Convert.ToInt32(Mensalidades_Pagas) + 1;
                        Globais.Main.PassarMensalidades_paga = Mensalidade_Paga.ToString();

                        Globais.Main.PassarForma = lb_FormaPagamento.Text;
                        Globais.Main.PassarForma1 = "";
                        Globais.Main.PassarForma2 = "";
                        string Entrada = "ENTRADA";
                        string Mensalidade = "Mensalidade Curso";
                        var vconn = Banco.ConexaoBanco();
                        string CaixaPagamento = String.Format(@"INSERT INTO
                        tb_caixa (valor_total,forma,tipo_movimentacao,descricao,usuario,data,horario,nome,curso,idaluno,mensalidades_paga,idmensalidade)
                        VALUES('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10},{11})", Valor_Total.ToString().Replace(",", "."), lb_FormaPagamento.Text, Entrada, Mensalidade, lb_nomeUsuario.Text, Data, MinutoHorario.ToString("HH:mm"), Globais.Main.PassarAluno, f_FormaDePagamento.lb_Cursando.Text, f_FormaDePagamento.tb_Aluno.Tag, Mensalidade_Paga, Globais.Main.PassarID_Mensalidade);
                        Banco.dml(CaixaPagamento);
                        vconn.Close();
                    }
                    if (Globais.Main.Modo == "3" || Globais.Main.Modo == "4")
                    {
                        string SaldoCarteira = String.Format(@"
                        SELECT saldo_carteira
                        FROM tb_carteira_aluno
                        WHERE idaluno={0}", Globais.Main.PassarIdAluno);
                        DataTable saldocarteira = Banco.dql(SaldoCarteira);

                        decimal Saldo_Carteira = saldocarteira.Rows[0].Field<decimal>("saldo_carteira");



                        string QueryAtualizarSaldo = String.Format(@"UPDATE tb_carteira_aluno SET saldo_carteira= saldo_carteira -'" + Saldo_Carteira.ToString() + "' WHERE idaluno ={0}", Globais.Main.PassarIdAluno);
                        Banco.dml(QueryAtualizarSaldo);

                        if (Globais.Main.Modo == "3")
                        {
                            string queryInsertCarteira = String.Format(@"
                            INSERT INTO 
                            tb_carteira (nome_aluno,valor_total,tipo,descricao,idaluno,data_gerada,usuario)  
                            VALUES ('{0}','{1}','{2}','{3}',{4},'{5}','{6}')", f_FormaDePagamento.tb_Aluno.Text, Saldo_Carteira.ToString().Replace("-", ""), "SAIDA", "Mensalidade", Globais.Main.PassarIdAluno, Data, Globais.Main.PassarUsuario);

                            Banco.dml(queryInsertCarteira);
                        }
                        else if (Globais.Main.Modo == "4")
                        {
                            string queryInsertCarteira = String.Format(@"
                            INSERT INTO 
                            tb_carteira (nome_aluno,valor_total,tipo,descricao,idaluno,data_gerada,usuario)  
                            VALUES ('{0}','{1}','{2}','{3}',{4},'{5}','{6}')", f_FormaDePagamento.tb_Aluno.Text, Saldo_Carteira.ToString().Replace("-", ""), "ENTRADA", "Mensalidade", Globais.Main.PassarIdAluno, Data, Globais.Main.PassarUsuario);

                            Banco.dml(queryInsertCarteira);

                        }

                        Globais.Main.Modo = "";
                    }
                }

                MessageBox.Show("Pagamento de mensalidade Confirmado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string CodigoVenda = String.Format(@"SELECT IFNULL (MAX(ID_caixa),0) as codigo, descricao FROM tb_caixa");

                DataTable Codigovenda = Banco.dql(CodigoVenda);

                Globais.Main.PassarIdCaixa = Codigovenda.Rows[0].Field<Int64>("codigo").ToString();
                Globais.Main.PassarDesc = Codigovenda.Rows[0].Field<string>("descricao");
                Globais.Main.Modo = "2";
                Globais.Main.PassarNomeCurso = f_FormaDePagamento.lb_Cursando.Text;

                Cursos.SelecionarRecibo selecionar = new Cursos.SelecionarRecibo();
                selecionar.ShowDialog();

                Close();

            }
            
        }

        private void btn_Calc_Click(object sender, EventArgs e)
        {
            calcular();
        }

        private void tb_Valor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente número e virgula", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente uma virgula", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chk_outros_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_outros.Checked == true)
            {
                if (f_FormaDePagamento.cb_NParcelas.Value == 1)
                {
                    string IDMensalidade = String.Format(@"SELECT ID_mensalidade_curso FROM tb_mensalidades_cursos WHERE idaluno = {0} AND curso = {1}", f_FormaDePagamento.tb_Aluno.Tag, Globais.Main.PassarCurso);

                    DataTable idmensalidade = Banco.dql(IDMensalidade);

                    int ID_mensalidade = idmensalidade.Rows[0].Field<Int32>("ID_mensalidade_curso");

                    modo = 1;
                    tb_Desconto.Enabled = false;
                    tb_Valor.Enabled = false;
                    string Mensalidades = String.Format(@"SELECT IFNULL (MAX(mensalidades_paga),0) as mensalidades_pagas FROM tb_caixa WHERE descricao = 'Mensalidade Curso' AND idaluno ={0} AND curso='{1}' AND idmensalidade={2}", f_FormaDePagamento.tb_Aluno.Tag,f_FormaDePagamento.lb_Cursando.Text,ID_mensalidade);

                    DataTable mensalidades = Banco.dql(Mensalidades);

                    string Mensalidades_Pagas = mensalidades.Rows[0].Field<Int64>("mensalidades_pagas").ToString();
                    int Mensalidade_Paga = Convert.ToInt32(Mensalidades_Pagas) + Convert.ToInt32(f_FormaDePagamento.cb_NParcelas.Text);
                    Globais.Main.PassarMensalidades_paga = Mensalidade_Paga.ToString();
                    Cursos.F_DuasFormasCurso f_DuasFormas = new Cursos.F_DuasFormasCurso(this);
                    f_DuasFormas.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Não é possível pagar mais de uma mensalidade com duas formas de pagamento", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    chk_outros.Checked = false;
                }

            }
            else
            {
                modo = 0;
                tb_Desconto.Enabled = true;
                tb_Valor.Enabled = true;
                if (Globais.Main.PassarForma1 != "" && Globais.Main.PassarForma2 != "")
                {
                    Globais.Main.PassarForma1 = "";
                    Globais.Main.PassarForma2 = "";
                }
            }
        }

        private void tb_Desconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente número e virgula", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente uma virgula", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_Desconto_Leave(object sender, EventArgs e)
        {
            if (tb_Desconto.Text == "")
            {
                tb_Desconto.Text = "0";
            }
        }
    }
    
}
