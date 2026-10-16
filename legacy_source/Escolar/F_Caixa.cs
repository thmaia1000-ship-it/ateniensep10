using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Escolar
{
    public partial class F_Caixa : Form
    {
        
        decimal ValorParcela, ValorTotalParcela;

        public F_Caixa()
        {
            InitializeComponent();
            
        }

        private void cb_NParcelas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cb_NParcelas.SelectedItem.ToString() == "1") {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 1;
                lb_SubTotal.Text = ValorTotalParcela.ToString();
            }
            else if (cb_NParcelas.SelectedItem.ToString() == "2")
            {
                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 2;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.SelectedItem.ToString() == "3")
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 3;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.SelectedItem.ToString() == "4")
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 4;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.SelectedItem.ToString() == "5")
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 5;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.SelectedItem.ToString() == "6")
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 6;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.SelectedItem.ToString() == "7")
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 7;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.SelectedItem.ToString() == "8")
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 8;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.SelectedItem.ToString() == "9")
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 9;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.SelectedItem.ToString() == "10")
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 10;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.SelectedItem.ToString() == "11")
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 11;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.SelectedItem.ToString() == "12")
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 12;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.SelectedItem.ToString() == "13")
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 13;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.SelectedItem.ToString() == "14")
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 14;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.SelectedItem.ToString() == "15")
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 15;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.SelectedItem.ToString() == "16")
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 16;
                tb_ValorParcela.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.SelectedItem.ToString() == "17")
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 17;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.SelectedItem.ToString() == "18")
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 18;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.SelectedItem.ToString() == "19")
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 19;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.SelectedItem.ToString() == "20")
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 20;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }
            else if (cb_NParcelas.SelectedItem.ToString() == "21")
            {

                ValorParcela = decimal.Parse(tb_ValorParcela.Tag.ToString());
                ValorTotalParcela = ValorParcela * 21;
                lb_SubTotal.Text = ValorTotalParcela.ToString();

            }

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

        private void btn_Pagamento_Click(object sender, EventArgs e)
        {
            
            F_FormaPagamento f_FormaPagamento = new F_FormaPagamento(this);
            abreForm(1,f_FormaPagamento);
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            F_SelecionarAlunoMensalidade f_SelecionarAlunoMensalidade = new F_SelecionarAlunoMensalidade(this);
            f_SelecionarAlunoMensalidade.ShowDialog();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            tb_Aluno.Text = "Busque aqui o Aluno(a)";
            tb_nParcelasPendentes.Text = "";
            tb_ValorPago.Text = "";
            tb_ValorParcela.Text = "";
            lb_SubTotal.Text = "";
            lb_RS.Text = "";
            cb_NParcelas.Text = "1";
        }

        private void F_Caixa_Load(object sender, EventArgs e)
        {
            tb_Aluno.Text = "Busque aqui o Aluno(a)";
            tb_nParcelasPendentes.Text = "";
            tb_ValorPago.Text = "";
            tb_ValorParcela.Text = "";
            lb_SubTotal.Text = "";
            lb_RS.Text = "";
        }


        
    }
           
}

        
        
    

