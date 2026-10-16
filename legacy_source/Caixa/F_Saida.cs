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
    public partial class F_Saida : Form
    {
        public F_Saida()
        {
            InitializeComponent();
        }

        private void F_Saida_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> forma = new Dictionary<string, string>();

            forma.Add("DINHEIRO", "DINHEIRO");
            forma.Add("PIX", "PIX");
            forma.Add("CRÉDITO", "CRÉDITO");
            forma.Add("DÉBITO", "DÉBITO");

            cb_Forma.DataSource = new BindingSource(forma, null);
            cb_Forma.DisplayMember = "Value";
            cb_Forma.ValueMember = "Key";

            string data = DateTime.Now.ToString("dd/MM/yyyy");
            string hora = DateTime.Now.ToString("HH:mm");
            lb_DATA.Text = hora + " " + data;
            lb_atendente.Text = Globais.Main.PassarUsuario;
            tb_valor.Text = "R$ 0,00";
        }

        private void btn_Limpar_Click(object sender, EventArgs e)
        {
            tb_valor.Text = "";
            tb_nome.Text = "";
            tb_descricao.Text = "";
            tb_valor.Text = "R$ 0,00";
        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            string Data = DateTime.Now.ToString("yyyy-MM-dd");
            string Horario = DateTime.Now.ToString("HH:mm");
            string Saida = "SAIDA";

            if (tb_nome.Text != "" && tb_valor.Text != "" && tb_descricao.Text != "")
            {
                if (MessageBox.Show("CONFIRMAR SAIDA?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    var vcon = Banco.ConexaoBanco();
                    string CaixaPagamento = String.Format(@"INSERT INTO
                    tb_caixa (valor_total,forma,tipo_movimentacao,descricao,usuario,data,horario,nome)
                    VALUES('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}')", tb_valor.Text.Replace(",", "."), cb_Forma.SelectedValue, Saida, tb_descricao.Text, Globais.Main.PassarUsuario, Data, Horario, tb_nome.Text.ToUpper());
                    Banco.dml(CaixaPagamento);
                    vcon.Close();

                    MessageBox.Show("SAÍDA REGISTRADA!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (MessageBox.Show("IMPRIMIR RECIBO?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Globais.Main.PassarCaixa = tb_valor.Text;
                        Globais.Main.PassarDesc = tb_descricao.Text;
                        Globais.Main.PassarAluno = tb_nome.Text;
                        Globais.Main.Modo = "0";
                        F_ReciboSaida f_ReciboSaida = new F_ReciboSaida();
                        f_ReciboSaida.ShowDialog();
                    }
                    tb_valor.Text = "";
                    tb_nome.Text = "";
                    tb_descricao.Text = "";
                    tb_valor.Text = "R$ 0,00";
                }
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void tb_valor_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb_valor_Enter(object sender, EventArgs e)
        {
            tb_valor.Text = "";
        }
    }
}
