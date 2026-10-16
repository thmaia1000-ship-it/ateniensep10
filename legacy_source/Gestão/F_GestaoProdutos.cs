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

namespace Escolar.Gestão
{
    public partial class F_GestaoProdutos : Form
    {
        string idSelecionado = "";

        int linha = 0;
        public F_GestaoProdutos()
        {
            InitializeComponent();
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text != "")
            {
                var vcon = Banco.ConexaoBanco();

                MySqlCommand cm = new MySqlCommand();
                cm.CommandText = "SELECT ID_produto as 'ID', produto as 'Produto' FROM tb_produtos WHERE produto LIKE ('" + tb_pesquisa.Text + "%')";

                cm.Connection = vcon;
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cm;
                da.Fill(dt);
                dgv_GestaoAlunos.DataSource = dt;
                dgv_GestaoAlunos.Columns[0].Width = 45;
                dgv_GestaoAlunos.Columns[1].Width = 255;
                vcon.Close();
            }
            else
            {
                MessageBox.Show("Preencha o campo produto para pesquisar", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja salvar estes dados?", "Salvar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            else
            {
                linha = dgv_GestaoAlunos.SelectedRows[0].Index;
                string BaixaEstoque = String.Format(@"UPDATE tb_produtos SET produto='{0}',descricao='{1}',valor_custo='{2}',valor_venda='{3}',estoque={4} WHERE ID_produto ={5}", tb_Produto.Text, tb_descricao.Text, tb_ValorCusto.Text, tb_ValorVenda.Text, tb_Estoque.Value, idSelecionado);

                Banco.dml(BaixaEstoque);

                dgv_GestaoAlunos[1, linha].Value = tb_Produto.Text;
                MessageBox.Show("Dados Alterados com sucesso!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information); ;

            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja excluir os dados deste produto?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            else
            {

                string vqueryExcluirAluno = String.Format(@"
                DELETE FROM
                    tb_produtos
                WHERE
                    ID_produto={0}
                 ", idSelecionado);
                Banco.dml(vqueryExcluirAluno);
                dgv_GestaoAlunos.Rows.Remove(dgv_GestaoAlunos.CurrentRow);
                MessageBox.Show("Produto excluído", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgv_GestaoAlunos_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.SelectedRows.Count > 0)
            {
                idSelecionado = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();

                string vqueryCampos = String.Format(@"
                 SELECT
                    produto,
                    descricao,
                    valor_custo,
                    valor_venda,
                    estoque
                FROM
                    tb_produtos
                WHERE ID_produto={0}
                 ", idSelecionado);

                DataTable dt = Banco.dql(vqueryCampos);
                tb_Produto.Text = dt.Rows[0].Field<string>("produto");
                tb_descricao.Text = dt.Rows[0].Field<string>("descricao");
                tb_ValorCusto.Text = dt.Rows[0].Field<decimal>("valor_custo").ToString();
                tb_ValorVenda.Text = dt.Rows[0].Field<decimal>("valor_venda").ToString();
                tb_Estoque.Value = dt.Rows[0].Field<Int32>("estoque");
                tb_ValorCusto.Text = tb_ValorCusto.Text.Replace(",", ".");
                tb_ValorVenda.Text = tb_ValorVenda.Text.Replace(",", ".");
            }
        }

        private void F_GestaoProdutos_Load(object sender, EventArgs e)
        {
            var vcon = Banco.ConexaoBanco();

            MySqlCommand cm = new MySqlCommand();
            cm.CommandText = "SELECT ID_produto as 'ID', produto as 'Produto' FROM tb_produtos ORDER BY produto";

            cm.Connection = vcon;
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cm;
            da.Fill(dt);
            dgv_GestaoAlunos.DataSource = dt;
            dgv_GestaoAlunos.Columns[0].Width = 45;
            dgv_GestaoAlunos.Columns[1].Width = 255;
            vcon.Close();
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
