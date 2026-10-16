using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.DRE
{
    public partial class F_NovaDespesa : Form
    {
        public F_NovaDespesa()
        {
            InitializeComponent();
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            bool insert = true;
            if(cb_tipo.Text == "" )
            {
                MessageBox.Show("Campo 'Tipo' Obrigatório","Mensagem do Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                cb_tipo.Focus();
                insert = false;
            }
            else if (tb_descricao.Text == "")
            {
                MessageBox.Show("Campo Obrigatório", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_descricao.Focus();
                insert = false;
            }
            else if (tb_valor.Text == "")
            {
                MessageBox.Show("Campo Obrigatório", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_valor.Focus();
                insert = false;
            }

            if (insert)
            {
                string data = dtp_data.Value.ToString("yyyy-MM-dd");
                string InsertDespesa = $"INSERT INTO tb_despesas SET tipo='{cb_tipo.Text}', descricao='{tb_descricao.Text}',valor='{tb_valor.Text.Replace(",",".")}',data='{data}',observacoes='{tb_obs.Text}',usuario='{Globais.Main.PassarUsuario}',data_gerada='{DateTime.Today.ToString("yyyy-MM-dd")}'";
                Banco.dml(InsertDespesa);

                Close();
            }
        }

        private void F_NovaDespesa_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> tipo = new Dictionary<string, string>();

            tipo.Add("Prolabore", "Prolabore");
            tipo.Add("Impostos", "Impostos");
            tipo.Add("Despesas Variáveis", "Despesas Variáveis");
            tipo.Add("Despesas Fixas", "Despesas Fixas");
            tipo.Add("Gastos com Pessoas", "Gastos com Pessoas");
            cb_tipo.DataSource = new BindingSource(tipo, null);
            cb_tipo.DisplayMember = "Value";
            cb_tipo.ValueMember = "Key";

            cb_tipo.SelectedValue = -1;
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
    }
}
