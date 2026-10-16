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

namespace Escolar.Turmas
{
    public partial class SelecionarAluno : Form
    {
        Turmas.AdicionarAluno turmas;

        public SelecionarAluno(Turmas.AdicionarAluno f)
        {
            InitializeComponent();
            turmas = f;
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text != "")
            {

                var vcon = Banco.ConexaoBanco();

                MySqlCommand cm = new MySqlCommand();
                cm.CommandText = "SELECT ID_aluno as 'ID', nome_aluno as 'Aluno', etapa as 'Etapa',turno as 'Turno' FROM tb_alunos WHERE nome_aluno LIKE ('" + tb_pesquisa.Text + "%') AND status != 'DESATIVADO'";

                cm.Connection = vcon;
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cm;
                da.Fill(dt);
                dgv_SelecionarAluno.DataSource = dt;
                vcon.Close();

                dgv_SelecionarAluno.Columns[0].Width = 55;
                dgv_SelecionarAluno.Columns[1].Width = 433;
                dgv_SelecionarAluno.Columns[2].Width = 110;
                dgv_SelecionarAluno.Columns[3].Visible = false;
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

            turmas.tb_nome.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[1].Value.ToString();
            turmas.tb_nome.Tag = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();

            turmas.Etapa = dgv.Rows[dgv.SelectedRows[0].Index].Cells[2].Value.ToString();

            Close();
        }
    }
}
