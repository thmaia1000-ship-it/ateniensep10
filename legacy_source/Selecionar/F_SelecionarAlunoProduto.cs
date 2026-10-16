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
    public partial class F_SelecionarAlunoProduto : Form
    {
        Caixa.F_Vendas f_Vendas;
        public F_SelecionarAlunoProduto(Caixa.F_Vendas f)
        {
            InitializeComponent();
            f_Vendas = f;
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text != "")
            {

                var vcon = Banco.ConexaoBanco();

                MySqlCommand cm = new MySqlCommand();
                cm.CommandText = "SELECT ID_aluno as 'ID', nome_aluno as 'Aluno', datanasc as 'Dt. Nasc' FROM tb_alunos WHERE nome_aluno LIKE ('" + tb_pesquisa.Text + "%')";

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

            f_Vendas.tb_nome.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[1].Value.ToString();
            f_Vendas.tb_nome.Tag = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();

            var vcon = Banco.ConexaoBanco();
            string vquery = String.Format(@"
            SELECT
                ID_responsavel_financeiro,
                nome,
                cpf,
                rua,
                bairro,
                numero
                FROM tb_responsavel_financeiro
                WHERE idaluno =" + f_Vendas.tb_nome.Tag);

            DataTable dt = Banco.dql(vquery);

            string SaldoCarteira = String.Format(@"
                SELECT saldo_carteira
                FROM tb_carteira_aluno
                WHERE idaluno={0}", f_Vendas.tb_nome.Tag);
            DataTable saldocarteira = Banco.dql(SaldoCarteira);


            f_Vendas.lb_IDRespFinan.Text = dt.Rows[0].Field<Int32>("ID_responsavel_financeiro").ToString();
            f_Vendas.lb_NomeResp.Text = dt.Rows[0].Field<string>("nome");
            f_Vendas.lb_cpf.Text = dt.Rows[0].Field<string>("cpf");
            f_Vendas.lb_SaldoCarteira.Text = saldocarteira.Rows[0].Field<decimal>("saldo_carteira").ToString("C");
            f_Vendas.npd_quantidade.Value = 1;
            Close();
        }
    }
}
