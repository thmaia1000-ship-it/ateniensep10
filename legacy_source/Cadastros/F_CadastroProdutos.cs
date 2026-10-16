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
    public partial class F_CadastroProdutos : Form
    {
        public F_CadastroProdutos()
        {
            InitializeComponent();
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            string Data = DateTime.Now.ToString("yyyy-MM-dd");

            string queryInsertProduto = String.Format(@"
                INSERT INTO 
                    tb_produtos (produto,descricao,valor_custo,valor_venda,estoque,data_gerada,usuario)  
                VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", tb_Produto.Text, tb_descricao.Text, tb_ValorCusto.Text, tb_ValorVenda.Text, tb_Estoque.Value, Data, Globais.Main.PassarUsuario);

            Banco.dml(queryInsertProduto);
            MessageBox.Show("Produto Cadastrado", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

            tb_Produto.Clear();
            tb_descricao.Clear();
            tb_ValorCusto.Clear();
            tb_ValorVenda.Clear();
            tb_Estoque.Value = 1;
            tb_Produto.Focus();
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            tb_Produto.Clear();
            tb_descricao.Clear();
            tb_ValorCusto.Clear();
            tb_ValorVenda.Clear();
            tb_Estoque.Value = 1;
            tb_Produto.Focus();
        }

        private void F_CadastroProdutos_Load(object sender, EventArgs e)
        {
            
        }

        private void tb_ValorCusto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente numero e ponto", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente um ponto", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_ValorVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente numero e ponto", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente um ponto", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
