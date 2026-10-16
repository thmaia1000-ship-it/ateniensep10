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
namespace Escolar.Caixa
{
    public partial class F_Devolucao : Form
    {

        string idSelecionado = "";
        public F_Devolucao()
        {
            InitializeComponent();
        }

        private void btn_BuscarAluno_Click(object sender, EventArgs e)
        {
            Selecionar.F_SelecionarAlunoDevolucao f_SelecionarAlunoDevolucao = new Selecionar.F_SelecionarAlunoDevolucao(this);
            f_SelecionarAlunoDevolucao.ShowDialog();
        }

        private void F_Devolucao_Load(object sender, EventArgs e)
        {
        }

        private void dgv_Produto_SelectionChanged(object sender, EventArgs e)
        {
            
            DataGridView dgv = (DataGridView)sender;
            if (dgv.SelectedRows.Count > 0)
            {
                idSelecionado = dgv.Rows[dgv.SelectedRows[0].Index].Cells[3].Value.ToString();

            }
        }

        private void btn_Devolucao_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmar Devolução?", "Mensagem do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            else
            {
            int quantidade, idProduto;

            var vconn = Banco.ConexaoBanco();

            string Vendas = String.Format(@"SELECT idproduto,quantidade FROM tb_vendas WHERE ID_venda={0}", idSelecionado);

            DataTable vendas = Banco.dql(Vendas);

            idProduto = vendas.Rows[0].Field<Int32>("idproduto");
            quantidade = vendas.Rows[0].Field<Int32>("quantidade");

            string BaixaEstoque = String.Format(@"UPDATE tb_produtos SET estoque= estoque +'" + quantidade + "' WHERE ID_produto ={0}", idProduto);
            Banco.dml(BaixaEstoque);

            string ExcluirRegistro = String.Format(@"DELETE FROM tb_vendas WHERE ID_venda ={0}", idSelecionado);
            MessageBox.Show("Devolução feita com sucesso!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Banco.dml(ExcluirRegistro);

            var vcon = Banco.ConexaoBanco();

            string vquery = String.Format(@"
            SELECT
                ID_responsavel_financeiro
                FROM tb_responsavel_financeiro
                WHERE idaluno =" + tb_aluno.Tag);

            DataTable responsavel = Banco.dql(vquery);

            string ID_cliente = responsavel.Rows[0].Field<Int32>("ID_responsavel_financeiro").ToString();

            MySqlCommand cm = new MySqlCommand();
            cm.CommandText = String.Format(@"SELECT produto as 'Produto', quantidade as 'Qtd', data_gerada as 'Data Venda', ID_venda FROM tb_vendas WHERE idcliente={0}", ID_cliente);

            cm.Connection = vcon;
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cm;
            da.Fill(dt);
            dgv_Produto.DataSource = dt;
            vcon.Close();
            dgv_Produto.ClearSelection();
            dgv_Produto.Columns[0].Width = 320;
            dgv_Produto.Columns[1].Width = 40;
            dgv_Produto.Columns[2].Width = 117;
            dgv_Produto.Columns[3].Visible = false;
            dgv_Produto.ClearSelection();

            vconn.Close();
            }

        }
    }
}
