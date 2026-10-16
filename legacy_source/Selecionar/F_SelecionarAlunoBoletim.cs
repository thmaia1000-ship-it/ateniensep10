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
using MySqlX.XDevAPI.Relational;

namespace Escolar
{
    public partial class F_SelecionarAlunoBoletim : Form
    {
        F_BoletimEscolar f_SelecionarAlunoBoletim;
        public F_SelecionarAlunoBoletim(F_BoletimEscolar b)
        {
            InitializeComponent();
            f_SelecionarAlunoBoletim = b;
        }

        private void F_SelecionarAlunoBoletim_Load(object sender, EventArgs e)
        {
            
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

            f_SelecionarAlunoBoletim.tb_Aluno.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[1].Value.ToString();
            //f_SelecionarAlunoBoletim.tb_turma.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[4].Value.ToString();

            f_SelecionarAlunoBoletim.tb_Aluno.Tag = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
            //f_SelecionarAlunoBoletim.tb_turma.Tag = dgv.Rows[dgv.SelectedRows[0].Index].Cells[5].Value.ToString();

            f_SelecionarAlunoBoletim.lb_obgAluno.Text = "";

            Close();

            var vcon = Banco.ConexaoBanco();

            MySqlCommand cm = new MySqlCommand();
            cm.CommandText = String.Format(@"
                   SELECT
                   materia as 'Materia',
                   nota1 as '1 BIM',
                   nota2 as '2 BIM',
                   nota3 as '3 BIM',
                   nota4 as '4 BIM',
                   media as 'Media',
                   recuperacao as 'Rec',
                   media_final as 'Media Final',
                   professor as 'Professor(a)',
                   ID_nota
                   FROM tb_notas
                   WHERE idaluno=" + f_SelecionarAlunoBoletim.tb_Aluno.Tag);

            cm.Connection = vcon;
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cm;
            da.Fill(dt);
            f_SelecionarAlunoBoletim.dgv_Notas.DataSource = dt;
            vcon.Close();
            f_SelecionarAlunoBoletim.dgv_Notas.ClearSelection();
            f_SelecionarAlunoBoletim.dgv_Notas.Columns[0].Width = 140;
            f_SelecionarAlunoBoletim.dgv_Notas.Columns[1].Width = 50;
            f_SelecionarAlunoBoletim.dgv_Notas.Columns[2].Width = 50;
            f_SelecionarAlunoBoletim.dgv_Notas.Columns[3].Width = 50;
            f_SelecionarAlunoBoletim.dgv_Notas.Columns[4].Width = 50;
            f_SelecionarAlunoBoletim.dgv_Notas.Columns[5].Width = 45;
            f_SelecionarAlunoBoletim.dgv_Notas.Columns[6].Width = 45;
            f_SelecionarAlunoBoletim.dgv_Notas.Columns[7].Width = 45;
            f_SelecionarAlunoBoletim.dgv_Notas.Columns[8].Width = 145;
            f_SelecionarAlunoBoletim.dgv_Notas.Columns[9].Visible = false;
            f_SelecionarAlunoBoletim.tb_MediaFinal.Visible = false;
            f_SelecionarAlunoBoletim.lb_mediafinal.Visible = false;
            f_SelecionarAlunoBoletim.lb_resultadoFinal.Visible = false;
            f_SelecionarAlunoBoletim.btn_faltas.Enabled = true;
        }

        private void tb_pesquisa_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgv_SelecionarAluno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
