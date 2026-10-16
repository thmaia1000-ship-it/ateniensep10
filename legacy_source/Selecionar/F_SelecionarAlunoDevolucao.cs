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
    public partial class F_SelecionarAlunoDevolucao : Form
    {
        Caixa.F_Devolucao f_Devolucao;
        public F_SelecionarAlunoDevolucao(Caixa.F_Devolucao f)
        {
            InitializeComponent();
            f_Devolucao = f;
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text != "")
            {
                var vcon = Banco.ConexaoBanco();

                MySqlCommand cm = new MySqlCommand();
                cm.CommandText = String.Format(@"SELECT
                tba.ID_aluno as 'ID',
                tba.nome_aluno as 'Nome',
                tba.datanasc as 'Dt. Nascimento'
                 FROM tb_alunos as tba
                WHERE  tba.nome_aluno LIKE ('" + tb_pesquisa.Text + "%')");

                cm.Connection = vcon;
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cm;
                da.Fill(dt);
                dgv_SelecionarAluno.DataSource = dt;
                vcon.Close();
                dgv_SelecionarAluno.Columns[0].Width = 55;
                dgv_SelecionarAluno.Columns[1].Width = 413;
                dgv_SelecionarAluno.Columns[2].Width = 120;
                dgv_SelecionarAluno.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else
            {
                MessageBox.Show("Preencha o campo nome para pesquisar");
                tb_pesquisa.Focus();
            }
        }

        private void dgv_SelecionarAluno_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            f_Devolucao.tb_aluno.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[1].Value.ToString();
            f_Devolucao.tb_aluno.Tag = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();


            var vcon = Banco.ConexaoBanco();

            string vquery = String.Format(@"
            SELECT
                ID_responsavel_financeiro
                FROM tb_responsavel_financeiro
                WHERE idaluno =" + f_Devolucao.tb_aluno.Tag);

            DataTable responsavel = Banco.dql(vquery);
            if (responsavel.Rows.Count == 0)
            {
                MessageBox.Show("Este Aluno(a) não possui um responsável financeiro cadastrado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string ID_cliente = responsavel.Rows[0].Field<Int32>("ID_responsavel_financeiro").ToString();

                MySqlCommand cm = new MySqlCommand();
                cm.CommandText = String.Format(@"SELECT produto as 'Produto', quantidade as 'Qtd', data_gerada as 'Data Venda', ID_venda FROM tb_vendas WHERE idcliente={0}", ID_cliente);

                cm.Connection = vcon;
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cm;
                da.Fill(dt);
                f_Devolucao.dgv_Produto.DataSource = dt;
                vcon.Close();
                f_Devolucao.dgv_Produto.ClearSelection();
                f_Devolucao.dgv_Produto.Columns[0].Width = 320;
                f_Devolucao.dgv_Produto.Columns[1].Width = 40;
                f_Devolucao.dgv_Produto.Columns[2].Width = 117;
                f_Devolucao.dgv_Produto.Columns[3].Visible = false;
                f_Devolucao.dgv_Produto.ClearSelection();


                Close();
            }
        }
    }
}
