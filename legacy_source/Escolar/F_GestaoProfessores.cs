using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar
{
    public partial class F_GestaoProfessores : Form
    {
        public F_GestaoProfessores()
        {
            InitializeComponent();
        }

        private void F_GestaoProfessores_Load(object sender, EventArgs e)
        {
            string vquery = " SELECT ID_professor as 'ID', nome_professor as 'Nome', telefone as 'Telefone' FROM tb_professores ORDER BY nome_professor";

            dgv_professor.DataSource = Banco.dql(vquery);
            dgv_professor.Columns[0].Width = 60;
            dgv_professor.Columns[1].Width = 170;
            dgv_professor.Columns[2].Width = 100;
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgv_professor_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int contlinhas = dgv.SelectedRows.Count;
            if (contlinhas > 0)
            {

                DataTable dt = new DataTable();
                string vid = dgv.SelectedRows[0].Cells[0].Value.ToString();
                string vquery = "SELECT * FROM tb_professores WHERE ID_professor=" + vid;

                dt = Banco.dql(vquery);
                tb_idProfessor.Text = dt.Rows[0].Field<Int32>("ID_professor").ToString();
                tb_NomeProfessor.Text = dt.Rows[0].Field<string>("nome_professor");
                mtb_Telefone.Text = dt.Rows[0].Field<string>("telefone");

            }
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            tb_idProfessor.Clear();
            tb_NomeProfessor.Clear();
            mtb_Telefone.Clear();
            tb_NomeProfessor.Focus();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            string vquery;
            if (tb_idProfessor.Text == "")
            {
                vquery = "INSERT INTO tb_professores (nome_professor, telefone) VALUES ('" + tb_NomeProfessor.Text + "','" + mtb_Telefone.Text + "')";
                MessageBox.Show("Professor(a) cadastrado com sucesso!");
            }
            else
            {
                vquery = "UPDATE tb_professores SET nome_professor='" + tb_NomeProfessor.Text + "', telefone='" + mtb_Telefone.Text + "' WHERE ID_professor=" + tb_idProfessor.Text;
                MessageBox.Show("Dados alterados com sucesso!");
            }
            Banco.dml(vquery);
            vquery = " SELECT ID_professor as 'ID', nome_professor as 'Nome', telefone as 'Telefone' FROM tb_professores ORDER BY nome_professor";

            dgv_professor.DataSource = Banco.dql(vquery);
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseja excluir?", "Excluir?", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                string vquery = "DELETE FROM tb_professores WHERE ID_professor=" + tb_idProfessor.Text;
                Banco.dml(vquery);
                dgv_professor.Rows.Remove(dgv_professor.CurrentRow);
                MessageBox.Show("Excluido com sucesso!");
            }
        }
    }
    }

