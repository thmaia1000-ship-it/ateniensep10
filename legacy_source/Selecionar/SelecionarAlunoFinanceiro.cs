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

namespace Escolar
{
    public partial class SelecionarAlunoFinanceiro : Form
    {
        F_ResponsavelFinanceiro formNovoRespFinanceiro;

        public SelecionarAlunoFinanceiro(F_ResponsavelFinanceiro p)
        {
            InitializeComponent();
            formNovoRespFinanceiro = p;
        }

        private void SelecionarAlunoFinanceiro_Load(object sender, EventArgs e)
        {
//            string queryAluno = String.Format(@"

//            SELECT  
//                ID_aluno as 'ID',
//                nome_aluno as 'Nome',
//                datanasc as 'D. Nascimento',
//                sexo as 'Sexo'
//             FROM tb_alunos
//             ORDER BY nome_aluno;
//");

//            dgv_SelecionarAluno.DataSource = Banco.dql(queryAluno);
        }

        private void dgv_SelecionarAluno_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            formNovoRespFinanceiro.tb_aluno.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[1].Value.ToString();
            formNovoRespFinanceiro.tb_aluno.Tag = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
            Close();
        }

        private void tb_pesquisa_TextChanged(object sender, EventArgs e)
        {
            //var vcon = Banco.ConexaoBanco();

            //MySqlCommand cm = new MySqlCommand();
            //cm.CommandText = "SELECT ID_aluno as 'ID', nome_aluno as 'Aluno', datanasc as 'D. Nascimento' FROM tb_alunos WHERE nome_aluno LIKE ('%" + tb_pesquisa.Text + "%')";

            //cm.Connection = vcon;
            //MySqlDataAdapter da = new MySqlDataAdapter();
            //DataTable dt = new DataTable();
            //da.SelectCommand = cm;
            //da.Fill(dt);
            //dgv_SelecionarAluno.DataSource = dt;
            //vcon.Close();
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text != "")
            {

                var vcon = Banco.ConexaoBanco();

                MySqlCommand cm = new MySqlCommand();
                cm.CommandText = "SELECT ID_aluno as 'ID', nome_aluno as 'Aluno' FROM tb_alunos WHERE nome_aluno LIKE ('" + tb_pesquisa.Text + "%')";

                cm.Connection = vcon;
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cm;
                da.Fill(dt);
                dgv_SelecionarAluno.DataSource = dt;
                vcon.Close();

                dgv_SelecionarAluno.Columns[0].Width = 55;
                dgv_SelecionarAluno.Columns[1].Width = 533;
            }
            else
            {
                MessageBox.Show("Preencha o campo nome para pesquisar");
                tb_pesquisa.Focus();
            }
        }
    }
}