using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar
{
    public partial class F_FormaPagamento : Form
    {
        F_Caixa f_FormaDePagamento;

        decimal Recebido, Total, Troco, Desconto;

        public F_FormaPagamento(F_Caixa f)
        {
            InitializeComponent();
            f_FormaDePagamento = f;
        }


        private void btn_Dinheiro_Click(object sender, EventArgs e)
        {
            btn_Salvar.Enabled = true;
            gpb_FormaPag.Enabled = true;

            lb_FormaPagamento.Text = "DINHEIRO";
            lb_FormaPagamento.ForeColor = Color.Green;
            tb_Valor.Enabled = true;
            tb_Valor.Cursor.Equals(Cursors.IBeam);
            tb_Troco.Text = "0,00";
            tb_Desconto.Text = "0";
            tb_Valor.Text = f_FormaDePagamento.lb_SubTotal.Text;
            lb_Total.Text = f_FormaDePagamento.lb_SubTotal.Text;
        }

        private void btn_Pix_Click(object sender, EventArgs e)
        {
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
        }

        private void btn_Debito_Click(object sender, EventArgs e)
        {
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
        }

        private void btn_Credito_Click(object sender, EventArgs e)
        {
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
        }

        private void tb_Desconto_Leave(object sender, EventArgs e)
        {
            if (tb_Desconto.Text == "")
            {
                tb_Desconto.Text = "0";
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            tb_Desconto.Text = "0";
            tb_Troco.Text = "0,00";
            btn_Salvar.Enabled = false;
            gpb_FormaPag.Enabled = false;
            tb_Valor.Text = f_FormaDePagamento.lb_SubTotal.Text;
            lb_Total.Text = f_FormaDePagamento.lb_SubTotal.Text;
        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
           F_ReciboInterdigitus f_ReciboInterdigitus = new F_ReciboInterdigitus(this);
            f_ReciboInterdigitus.Show();
            
        }

        private void tb_Desconto_KeyPress(object sender, KeyPressEventArgs e)
        {
           
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
                {
                    e.Handled = true;
                }
                // somente permite um ponto decimal
                if (e.KeyChar == ',' && (sender as TextBox).Text.IndexOf(',') > -1)
                {
                    e.Handled = true;
                }
            
        }

        private void btn_Calc_Click(object sender, EventArgs e)
        {
            if (tb_Desconto.Text == "")
            {
                tb_Desconto.Text = "0";
            }

            else { 

            if (tb_Valor.Enabled == true && tb_Desconto.Text == "0")
            {
                lb_Total.Text = f_FormaDePagamento.lb_SubTotal.Text;
                tb_Troco.Text = "0";
                Total = decimal.Parse(lb_Total.Text);
                Recebido = decimal.Parse(tb_Valor.Text);
                Desconto = decimal.Parse(tb_Desconto.Text);

                Recebido = Recebido - Total;
                Troco = Recebido - Desconto;
                tb_Troco.Text = Troco.ToString();
                lb_Total.Text = Total.ToString();

            }
            else if (tb_Valor.Enabled == true && tb_Desconto.Text != "0")
            {
                lb_Total.Text = f_FormaDePagamento.lb_SubTotal.Text;
                Total = decimal.Parse(lb_Total.Text);
                Recebido = decimal.Parse(tb_Valor.Text);
                Desconto = decimal.Parse(tb_Desconto.Text);

                Desconto = Total - Desconto;
                Troco = Recebido - Desconto;
                tb_Troco.Text = Troco.ToString();
                lb_Total.Text = Desconto.ToString();

                if (tb_Valor.Enabled == true && tb_Troco.Text != "0")
                {
                    tb_Troco.Text = "";
                    lb_Total.Text = f_FormaDePagamento.lb_SubTotal.Text;
                    Total = decimal.Parse(lb_Total.Text);
                    Recebido = decimal.Parse(tb_Valor.Text);
                    Desconto = decimal.Parse(tb_Desconto.Text);

                    Desconto = Total - Desconto;
                    Troco = Recebido - Desconto;
                    tb_Troco.Text = Troco.ToString();
                    lb_Total.Text = Desconto.ToString();
                }
            }
            else if (tb_Valor.Enabled == false && tb_Troco.Text == "0")
            {  
                lb_Total.Text = f_FormaDePagamento.lb_SubTotal.Text;
                tb_Valor.Text = f_FormaDePagamento.lb_SubTotal.Text;

                Total = decimal.Parse(tb_Valor.Text);
                Desconto = decimal.Parse(tb_Desconto.Text);
                Desconto = Total - Desconto;
                tb_Troco.Text = "0,00";
                lb_Total.Text = Desconto.ToString();
                tb_Valor.Text = Desconto.ToString();
            }
            else if (tb_Valor.Enabled == false && tb_Troco.Text != "0")
            {
                lb_Total.Text = f_FormaDePagamento.lb_SubTotal.Text;
                tb_Valor.Text = f_FormaDePagamento.lb_SubTotal.Text;

                Total = decimal.Parse(tb_Valor.Text);
                Desconto = decimal.Parse(tb_Desconto.Text);
                Desconto = Total - Desconto;
                tb_Troco.Text = "0,00";
                lb_Total.Text = Desconto.ToString();
                tb_Valor.Text = Desconto.ToString();
            }
            }

        }
        

        private void F_FormaPagamento_Load(object sender, EventArgs e)
        {
            btn_Salvar.Enabled = false;
            gpb_FormaPag.Enabled = false;
            tb_Valor.Text = f_FormaDePagamento.lb_SubTotal.Text;
            lb_Total.Text = f_FormaDePagamento.lb_SubTotal.Text;
            tb_Desconto.Text = "0";
            tb_Troco.Text = "0,00";

            lb_nomeUsuario.Text = Globais.Main.PassarUsuario;
            

        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            string Horario = DateTime.Now.ToString();
            if (MessageBox.Show("CONFIRMAR O RECEBIMENTO DA MENSALIDADE?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                var vconn = Banco.ConexaoBanco();
                string CaixaPagamento = String.Format(@"INSERT INTO
                    tb_caixa (valor_pago,valor_total,desconto,troco_cliente,forma,usuario,data_horario,idaluno)
                    VALUES('{0}', '{1}','{2}','{3}','{4}','{5}','{6}',{7})", tb_Valor.Text, lb_Total.Text, tb_Desconto.Text, tb_Troco.Text, lb_FormaPagamento.Text,lb_nomeUsuario.Text,Horario, f_FormaDePagamento.tb_Aluno.Tag);
                Banco.dml(CaixaPagamento);
                vconn.Close();

                if (f_FormaDePagamento.cb_NParcelas.SelectedItem.ToString() == "1")
                {
                    var vcon = Banco.ConexaoBanco();
                    string DescontarMensalidade = @"UPDATE tb_mensalidades 
                                    SET 
                                    valor_total= valor_total - valor_parcela,
                                    n_parcelas= n_parcelas -1,
                                    parcelas_pagas = parcelas_pagas +1
                                    WHERE idaluno=" + f_FormaDePagamento.tb_Aluno.Tag;
                    Banco.dml(DescontarMensalidade);
                    MessageBox.Show("Pagamento de mensalidade Confirmado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vcon.Close();

                }
                else if (f_FormaDePagamento.cb_NParcelas.SelectedItem.ToString() == "2")
                {
                    var vcon = Banco.ConexaoBanco();
                    string DescontarMensalidade = @"UPDATE tb_mensalidades 
                                    SET 
                                    valor_total= valor_total - valor_parcela - valor_parcela,
                                    n_parcelas= n_parcelas -2,
                                    parcelas_pagas = parcelas_pagas +2
                                    WHERE idaluno=" + f_FormaDePagamento.tb_Aluno.Tag;
                    Banco.dml(DescontarMensalidade);
                    MessageBox.Show("Pagamento de mensalidade Confirmado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vcon.Close();

                }
                else if (f_FormaDePagamento.cb_NParcelas.SelectedItem.ToString() == "3")
                {
                    var vcon = Banco.ConexaoBanco();
                    string DescontarMensalidade = @"UPDATE tb_mensalidades 
                                    SET 
                                    valor_total= valor_total - valor_parcela - valor_parcela - valor_parcela,
                                    n_parcelas= n_parcelas -3,
                                    parcelas_pagas = parcelas_pagas +3
                                    WHERE idaluno=" + f_FormaDePagamento.tb_Aluno.Tag;
                    Banco.dml(DescontarMensalidade);
                    MessageBox.Show("Pagamento de mensalidade Confirmado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vcon.Close();

                }
                else if (f_FormaDePagamento.cb_NParcelas.SelectedItem.ToString() == "4")
                {
                    var vcon = Banco.ConexaoBanco();
                    string DescontarMensalidade = @"UPDATE tb_mensalidades 
                                    SET 
                                    valor_total= valor_total - valor_parcela - valor_parcela - valor_parcela - valor_parcela,
                                    n_parcelas= n_parcelas -4,
                                    parcelas_pagas = parcelas_pagas +4
                                    WHERE idaluno=" + f_FormaDePagamento.tb_Aluno.Tag;
                    Banco.dml(DescontarMensalidade);
                    MessageBox.Show("Pagamento de mensalidade Confirmado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vcon.Close();


                }
                else if (f_FormaDePagamento.cb_NParcelas.SelectedItem.ToString() == "5")
                {
                    var vcon = Banco.ConexaoBanco();
                    string DescontarMensalidade = @"UPDATE tb_mensalidades 
                                    SET 
                                    valor_total= valor_total - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela,
                                    n_parcelas= n_parcelas -5,
                                    parcelas_pagas = parcelas_pagas +5
                                    WHERE idaluno=" + f_FormaDePagamento.tb_Aluno.Tag;
                    Banco.dml(DescontarMensalidade);
                    MessageBox.Show("Pagamento de mensalidade Confirmado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vcon.Close();

                }
                else if (f_FormaDePagamento.cb_NParcelas.SelectedItem.ToString() == "6")
                {
                    var vcon = Banco.ConexaoBanco();
                    string DescontarMensalidade = @"UPDATE tb_mensalidades 
                                    SET 
                                    valor_total= valor_total - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela,
                                    n_parcelas= n_parcelas -6,
                                    parcelas_pagas = parcelas_pagas +6
                                    WHERE idaluno=" + f_FormaDePagamento.tb_Aluno.Tag;
                    Banco.dml(DescontarMensalidade);
                    MessageBox.Show("Pagamento de mensalidade Confirmado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vcon.Close();

                }
                else if (f_FormaDePagamento.cb_NParcelas.SelectedItem.ToString() == "7")
                {
                    var vcon = Banco.ConexaoBanco();
                    string DescontarMensalidade = @"UPDATE tb_mensalidades 
                                    SET 
                                    valor_total= valor_total - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela,
                                    n_parcelas= n_parcelas -7,
                                    parcelas_pagas = parcelas_pagas +7
                                    WHERE idaluno=" + f_FormaDePagamento.tb_Aluno.Tag;
                    Banco.dml(DescontarMensalidade);
                    MessageBox.Show("Pagamento de mensalidade Confirmado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vcon.Close();

                }
                else if (f_FormaDePagamento.cb_NParcelas.SelectedItem.ToString() == "8")
                {
                    var vcon = Banco.ConexaoBanco();
                    string DescontarMensalidade = @"UPDATE tb_mensalidades 
                                    SET 
                                    valor_total= valor_total - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela,
                                    n_parcelas= n_parcelas -8,
                                    parcelas_pagas = parcelas_pagas +8
                                    WHERE idaluno=" + f_FormaDePagamento.tb_Aluno.Tag;
                    Banco.dml(DescontarMensalidade);
                    MessageBox.Show("Pagamento de mensalidade Confirmado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vcon.Close();

                }
                else if (f_FormaDePagamento.cb_NParcelas.SelectedItem.ToString() == "9")
                {
                    var vcon = Banco.ConexaoBanco();
                    string DescontarMensalidade = @"UPDATE tb_mensalidades 
                                    SET 
                                    valor_total= valor_total - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela,
                                    n_parcelas= n_parcelas -9,
                                    parcelas_pagas = parcelas_pagas +9
                                    WHERE idaluno=" + f_FormaDePagamento.tb_Aluno.Tag;
                    Banco.dml(DescontarMensalidade);
                    MessageBox.Show("Pagamento de mensalidade Confirmado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vcon.Close();

                }
                else if (f_FormaDePagamento.cb_NParcelas.SelectedItem.ToString() == "10")
                {
                    var vcon = Banco.ConexaoBanco();
                    string DescontarMensalidade = @"UPDATE tb_mensalidades 
                                    SET 
                                    valor_total= valor_total - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela,
                                    n_parcelas= n_parcelas -10,
                                    parcelas_pagas = parcelas_pagas +10
                                    WHERE idaluno=" + f_FormaDePagamento.tb_Aluno.Tag;
                    Banco.dml(DescontarMensalidade);
                    MessageBox.Show("Pagamento de mensalidade Confirmado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vcon.Close();

                }
                else if (f_FormaDePagamento.cb_NParcelas.SelectedItem.ToString() == "11")
                {
                    var vcon = Banco.ConexaoBanco();
                    string DescontarMensalidade = @"UPDATE tb_mensalidades 
                                    SET 
                                    valor_total= valor_total - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela,
                                    n_parcelas= n_parcelas -11,
                                    parcelas_pagas = parcelas_pagas +11
                                    WHERE idaluno=" + f_FormaDePagamento.tb_Aluno.Tag;
                    Banco.dml(DescontarMensalidade);
                    MessageBox.Show("Pagamento de mensalidade Confirmado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vcon.Close();

                }
                else if (f_FormaDePagamento.cb_NParcelas.SelectedItem.ToString() == "12")
                {
                    var vcon = Banco.ConexaoBanco();
                    string DescontarMensalidade = @"UPDATE tb_mensalidades 
                                    SET 
                                    valor_total= valor_total - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela,
                                    n_parcelas= n_parcelas -12,
                                    parcelas_pagas = parcelas_pagas +12
                                    WHERE idaluno=" + f_FormaDePagamento.tb_Aluno.Tag;
                    Banco.dml(DescontarMensalidade);
                    MessageBox.Show("Pagamento de mensalidade Confirmado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vcon.Close();

                }
                else if (f_FormaDePagamento.cb_NParcelas.SelectedItem.ToString() == "13")
                {
                    var vcon = Banco.ConexaoBanco();
                    string DescontarMensalidade = @"UPDATE tb_mensalidades 
                                    SET 
                                    valor_total= valor_total - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela,
                                    n_parcelas= n_parcelas -13,
                                    parcelas_pagas = parcelas_pagas +13
                                    WHERE idaluno=" + f_FormaDePagamento.tb_Aluno.Tag;
                    Banco.dml(DescontarMensalidade);
                    MessageBox.Show("Pagamento de mensalidade Confirmado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vcon.Close();

                }
                else if (f_FormaDePagamento.cb_NParcelas.SelectedItem.ToString() == "14")
                {
                    var vcon = Banco.ConexaoBanco();
                    string DescontarMensalidade = @"UPDATE tb_mensalidades 
                                    SET 
                                    valor_total= valor_total - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela,
                                    n_parcelas= n_parcelas -14,
                                    parcelas_pagas = parcelas_pagas +14
                                    WHERE idaluno=" + f_FormaDePagamento.tb_Aluno.Tag;
                    Banco.dml(DescontarMensalidade);
                    MessageBox.Show("Pagamento de mensalidade Confirmado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vcon.Close();

                }
                else if (f_FormaDePagamento.cb_NParcelas.SelectedItem.ToString() == "15")
                {
                    var vcon = Banco.ConexaoBanco();
                    string DescontarMensalidade = @"UPDATE tb_mensalidades 
                                    SET 
                                    valor_total= valor_total - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela,
                                    n_parcelas= n_parcelas -15,
                                    parcelas_pagas = parcelas_pagas +15
                                    WHERE idaluno=" + f_FormaDePagamento.tb_Aluno.Tag;
                    Banco.dml(DescontarMensalidade);
                    MessageBox.Show("Pagamento de mensalidade Confirmado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vcon.Close();

                }
                else if (f_FormaDePagamento.cb_NParcelas.SelectedItem.ToString() == "16")
                {
                    var vcon = Banco.ConexaoBanco();
                    string DescontarMensalidade = @"UPDATE tb_mensalidades 
                                    SET 
                                    valor_total= valor_total - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela,
                                    n_parcelas= n_parcelas -16,
                                    parcelas_pagas = parcelas_pagas +16
                                    WHERE idaluno=" + f_FormaDePagamento.tb_Aluno.Tag;
                    Banco.dml(DescontarMensalidade);
                    MessageBox.Show("Pagamento de mensalidade Confirmado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vcon.Close();

                }
                else if (f_FormaDePagamento.cb_NParcelas.SelectedItem.ToString() == "17")
                {
                    var vcon = Banco.ConexaoBanco();
                    string DescontarMensalidade = @"UPDATE tb_mensalidades 
                                    SET 
                                    valor_total= valor_total - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela,
                                    n_parcelas= n_parcelas -17,
                                    parcelas_pagas = parcelas_pagas +17
                                    WHERE idaluno=" + f_FormaDePagamento.tb_Aluno.Tag;
                    Banco.dml(DescontarMensalidade);
                    MessageBox.Show("Pagamento de mensalidade Confirmado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vcon.Close();

                }
                else if (f_FormaDePagamento.cb_NParcelas.SelectedItem.ToString() == "18")
                {
                    var vcon = Banco.ConexaoBanco();
                    string DescontarMensalidade = @"UPDATE tb_mensalidades 
                                    SET 
                                    valor_total= valor_total - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela,
                                    n_parcelas= n_parcelas -18,
                                    parcelas_pagas = parcelas_pagas +18
                                    WHERE idaluno=" + f_FormaDePagamento.tb_Aluno.Tag;
                    Banco.dml(DescontarMensalidade);
                    MessageBox.Show("Pagamento de mensalidade Confirmado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vcon.Close();

                }
                else if (f_FormaDePagamento.cb_NParcelas.SelectedItem.ToString() == "19")
                {
                    var vcon = Banco.ConexaoBanco();
                    string DescontarMensalidade = @"UPDATE tb_mensalidades 
                                    SET 
                                    valor_total= valor_total - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela,
                                    n_parcelas= n_parcelas -19,
                                    parcelas_pagas = parcelas_pagas +19,
                                    WHERE idaluno=" + f_FormaDePagamento.tb_Aluno.Tag;
                    Banco.dml(DescontarMensalidade);
                    MessageBox.Show("Pagamento de mensalidade Confirmado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vcon.Close();

                }
                else if (f_FormaDePagamento.cb_NParcelas.SelectedItem.ToString() == "20")
                {
                    var vcon = Banco.ConexaoBanco();
                    string DescontarMensalidade = @"UPDATE tb_mensalidades 
                                    SET 
                                    valor_total= valor_total - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela,
                                    n_parcelas= n_parcelas -20,
                                    parcelas_pagas = parcelas_pagas +20
                                    WHERE idaluno=" + f_FormaDePagamento.tb_Aluno.Tag;
                    Banco.dml(DescontarMensalidade);
                    MessageBox.Show("Pagamento de mensalidade Confirmado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vcon.Close();

                }
                else if (f_FormaDePagamento.cb_NParcelas.SelectedItem.ToString() == "21")
                {
                    var vcon = Banco.ConexaoBanco();
                    string DescontarMensalidade = @"UPDATE tb_mensalidades 
                                    SET 
                                    valor_total= valor_total - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela - valor_parcela,
                                    n_parcelas= n_parcelas -21,
                                    parcelas_pagas = parcelas_pagas +21
                                    WHERE idaluno=" + f_FormaDePagamento.tb_Aluno.Tag;
                    Banco.dml(DescontarMensalidade);
                    MessageBox.Show("Pagamento de mensalidade Confirmado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vcon.Close();
                    
                }
                F_ReciboMensalidade f_ReciboMensalidade = new F_ReciboMensalidade(this);
                f_ReciboMensalidade.Show();        
            }
            
        }

        }
}
