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
    public partial class F_SelcionarProfessorBoletim : Form
    {
        F_BoletimEscolar f_SelecionarProfessorBoletim;

        public F_SelcionarProfessorBoletim(F_BoletimEscolar bp)
        {
            InitializeComponent();
            f_SelecionarProfessorBoletim = bp;
        }

        private void F_SelcionarProfessorBoletim_Load(object sender, EventArgs e)
        {
            string queryProfessor = String.Format(@"

            SELECT  
                ID_professor as 'ID',
                nome_professor as 'Nome',
                telefone as 'Telefone'
             FROM tb_professores
                ORDER BY nome_professor;
");

            dgv_SelecionarProfessor.DataSource = Banco.dql(queryProfessor);
            dgv_SelecionarProfessor.Columns[0].Width = 25;
            dgv_SelecionarProfessor.Columns[1].Width = 453;
            dgv_SelecionarProfessor.Columns[2].Width = 120;
            dgv_SelecionarProfessor.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void tb_pesquisa_TextChanged(object sender, EventArgs e)
        {
            //var vcon = Banco.ConexaoBanco();

            //MySqlCommand cm = new MySqlCommand();
            //cm.CommandText = "SELECT ID_professor as 'ID', nome_professor as 'Professor(a)', telefone as 'Telefone' FROM tb_professores WHERE nome_professor LIKE ('%" + tb_pesquisa.Text + "%')";

            //cm.Connection = vcon;
            //MySqlDataAdapter da = new MySqlDataAdapter();
            //DataTable dt = new DataTable();
            //da.SelectCommand = cm;
            //da.Fill(dt);
            //dgv_SelecionarProfessor.DataSource = dt;
            //vcon.Close();
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text != "")
            {

                var vcon = Banco.ConexaoBanco();

                MySqlCommand cm = new MySqlCommand();
                cm.CommandText = "SELECT ID_professor as 'ID', nome_professor as 'Professor(a)', telefone as 'Telefone' FROM tb_professores WHERE nome_professor LIKE ('" + tb_pesquisa.Text + "%')";

                cm.Connection = vcon;
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cm;
                da.Fill(dt);
                dgv_SelecionarProfessor.DataSource = dt;
                vcon.Close();
                dgv_SelecionarProfessor.Columns[0].Width = 25;
                dgv_SelecionarProfessor.Columns[1].Width = 453;
                dgv_SelecionarProfessor.Columns[2].Width = 120;
                dgv_SelecionarProfessor.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else
            {
                MessageBox.Show("Preencha o campo nome para pesquisar");
                tb_pesquisa.Focus();
            }
        }

        private void dgv_SelecionarProfessor_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            f_SelecionarProfessorBoletim.tb_Professor.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[1].Value.ToString();
            f_SelecionarProfessorBoletim.tb_Professor.Tag = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
            f_SelecionarProfessorBoletim.lb_obgProfessor.Text = "";
            Close();
        }
    }
}
