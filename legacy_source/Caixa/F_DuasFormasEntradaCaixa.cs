using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Caixa
{
    public partial class F_DuasFormasEntradaCaixa : Form
    {
        F_Entrada f_Entrada;

        decimal Valor1, Valor2, Valor_Soma;

        private void tb_Valor1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb_Valor2_KeyPress(object sender, KeyPressEventArgs e)
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

        public F_DuasFormasEntradaCaixa(F_Entrada f)
        {
            InitializeComponent();
            f_Entrada = f;
        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            //decimal Valor = decimal.Parse(f_Entrada.lb_Total.Text);

            if (tb_Valor1.Text != "" && tb_Valor2.Text != "" && tb_descricao.Text != "")
            {
                Valor1 = decimal.Parse(tb_Valor1.Text);
                Valor2 = decimal.Parse(tb_Valor2.Text);

                Valor_Soma = Valor1 + Valor2;
                lb_Total.Text = Valor_Soma.ToString("C");

                Globais.Main.PassarForma1 = cb_forma1.Text;
                Globais.Main.PassarForma2 = cb_forma2.Text;

                string Data = DateTime.Now.ToString("yyyy-MM-dd");
                string Horario = DateTime.Now.ToString("HH:mm");
                string Entrada = "ENTRADA";

                Globais.Main.PassarCaixa = Valor_Soma.ToString();
                Globais.Main.PassarAluno = f_Entrada.tb_nome.Text;
                Globais.Main.PassarDesc = tb_descricao.Text;

                var vconn = Banco.ConexaoBanco();
                string CaixaPagamento1 = String.Format(@"INSERT INTO
                    tb_caixa (valor_total,forma,tipo_movimentacao,descricao,usuario,data,horario,nome,curso,idaluno)
                    VALUES('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9})", tb_Valor1.Text.Replace(",", "."), cb_forma1.Text, Entrada, tb_descricao.Text, Globais.Main.PassarUsuario, Data, Horario, Globais.Main.PassarAluno, Globais.Main.PassarCurso, f_Entrada.tb_nome.Tag.ToString());
                Banco.dml(CaixaPagamento1);
                vconn.Close();

                vconn = Banco.ConexaoBanco();
                string CaixaPagamento2 = String.Format(@"INSERT INTO
                    tb_caixa (valor_total,forma,tipo_movimentacao,descricao,usuario,data,horario,nome,curso,idaluno)
                    VALUES('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9})", tb_Valor2.Text.Replace(",", "."), cb_forma2.Text, Entrada, tb_descricao.Text, Globais.Main.PassarUsuario, Data, Horario, Globais.Main.PassarAluno, Globais.Main.PassarCurso, f_Entrada.tb_nome.Tag.ToString());
                Banco.dml(CaixaPagamento2);
                vconn.Close();

                MessageBox.Show("ENTRADA REGISTRADA!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);


                
                if (MessageBox.Show("IMPRIMIR CUPOM?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Globais.Main.Modo = "0";
                    F_ReciboEntrada f_ReciboEntrada = new F_ReciboEntrada();
                    f_ReciboEntrada.ShowDialog();
                }

                Close();

            }
            else
            {
                MessageBox.Show("Todos os Campos são obrigatórios!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void F_DuasFormasEntradaCaixa_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> forma = new Dictionary<string, string>();

            forma.Add("DINHEIRO", "DINHEIRO");
            forma.Add("PIX", "PIX");
            forma.Add("DÉBITO", "DÉBITO");
            forma.Add("CRÉDITO", "CRÉDITO");

            cb_forma1.DataSource = new BindingSource(forma, null);
            cb_forma1.DisplayMember = "Value";
            cb_forma1.ValueMember = "Key";
            cb_forma2.DataSource = new BindingSource(forma, null);
            cb_forma2.DisplayMember = "Value";
            cb_forma2.ValueMember = "Key";
        }
    }
}
