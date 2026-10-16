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

namespace Escolar.Selecionar
{
    public partial class F_SelecionarProduto : Form
    {
        Caixa.F_Vendas f_vendas;
        public F_SelecionarProduto(Caixa.F_Vendas f)
        {
            InitializeComponent();
            f_vendas = f;
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text != "")
            {

                var vcon = Banco.ConexaoBanco();

                MySqlCommand cm = new MySqlCommand();
                cm.CommandText = "SELECT ID_produto as 'ID' , produto as 'Produto', descricao as 'Desc',valor_custo as 'Valor Custo', valor_venda as 'Valor venda'  FROM tb_produtos as tba WHERE produto LIKE ('" + tb_pesquisa.Text + "%') OR ID_produto LIKE ('" + tb_pesquisa.Text + "%')";

                cm.Connection = vcon;
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cm;
                da.Fill(dt);
                dgv_SelecionarAluno.DataSource = dt;
                vcon.Close();
                dgv_SelecionarAluno.Columns[0].Width = 55;
                dgv_SelecionarAluno.Columns[1].Width = 220;
                dgv_SelecionarAluno.Columns[2].Width = 200;
                dgv_SelecionarAluno.Columns[3].Width = 60;
                dgv_SelecionarAluno.Columns[4].Width = 60;
                dgv_SelecionarAluno.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_SelecionarAluno.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_SelecionarAluno.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_SelecionarAluno.Columns[3].DefaultCellStyle.Format = "C";
                dgv_SelecionarAluno.Columns[4].DefaultCellStyle.Format = "C";
            }
            else
            {
                MessageBox.Show("Preencha o campo Produto para pesquisar", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_pesquisa.Focus();
            }
        }

        private void dgv_SelecionarAluno_DoubleClick(object sender, EventArgs e)
        {
            //DataGridView dgv = (DataGridView)sender;

            //f_vendas.tb_Produto.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[1].Value.ToString();
            //f_vendas.tb_Produto.Tag = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();

            //var vcon = Banco.ConexaoBanco();
            //string vquery = String.Format(@"
            //SELECT
            //    ID_produto,
            //    produto,
            //    descricao,
            //    valor_venda,
            //    estoque
            //    FROM tb_produtos
            //    WHERE ID_produto =" + f_vendas.tb_Produto.Tag);

            //DataTable dt = Banco.dql(vquery);

            //vcon.Close();

            //string descricao = "  Descrição: ";
            //f_vendas.lb_nome_produto.Text = dt.Rows[0].Field<string>("produto");
            //f_vendas.tb_descricao.Text = descricao + dt.Rows[0].Field<string>("descricao");
            //f_vendas.lb_ValorVenda.Text = dt.Rows[0].Field<decimal>("valor_venda").ToString();
            //f_vendas.lb_estoque.Text = dt.Rows[0].Field<Int32>("estoque").ToString();
            //f_vendas.lb_IDProduto.Text = dt.Rows[0].Field<Int32>("ID_produto").ToString();
            //f_vendas.dgv_Produto.ClearSelection();


            //Close();
        }

        private void F_SelecionarProduto_Load(object sender, EventArgs e)
        {
            var vcon = Banco.ConexaoBanco();
            string ListaProdutos = String.Format(@"
                SELECT ID_produto as 'ID' ,
                produto as 'Produto',
                descricao as 'Desc',
                valor_custo as 'Valor Custo',
                valor_venda as 'Valor venda' 
                FROM tb_produtos as tba");

            dgv_SelecionarAluno.DataSource = Banco.dql(ListaProdutos);
            dgv_SelecionarAluno.Columns[0].Width = 55;
            dgv_SelecionarAluno.Columns[1].Width = 220;
            dgv_SelecionarAluno.Columns[2].Width = 200;
            dgv_SelecionarAluno.Columns[3].Width = 60;
            dgv_SelecionarAluno.Columns[4].Width = 60;
            dgv_SelecionarAluno.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_SelecionarAluno.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_SelecionarAluno.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_SelecionarAluno.Columns[3].DefaultCellStyle.Format = "C";
            dgv_SelecionarAluno.Columns[4].DefaultCellStyle.Format = "C";
        }
    }

}
