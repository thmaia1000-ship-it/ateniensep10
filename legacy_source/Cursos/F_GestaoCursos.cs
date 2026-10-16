using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Gestão
{
    public partial class F_GestaoCursos : Form
    {
        public F_GestaoCursos()
        {
            InitializeComponent();
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            tb_IDCurso.Clear();
            tb_curso.Clear();
            tb_curso.Focus();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            string vquery;
            if (tb_IDCurso.Text == "")
            {
                vquery = "INSERT INTO tb_cursos (nome_curso) VALUES ('" + tb_curso.Text + "')";
                MessageBox.Show("Curso cadastrado com sucesso!");

                dgv_curso.ClearSelection();
                tb_curso.Clear();
                tb_IDCurso.Clear();
            }
            else
            {
                vquery = "UPDATE tb_cursos SET nome_curso='" + tb_curso.Text + "' WHERE ID_curso=" + tb_IDCurso.Text;
                MessageBox.Show("Dados alterados com sucesso!");
            }
            Banco.dml(vquery);
            vquery = " SELECT ID_curso as 'ID', nome_curso as 'Nome' FROM tb_cursos WHERE ID_curso > 2 ORDER BY nome_curso";

            dgv_curso.DataSource = Banco.dql(vquery);
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseja excluir?", "Excluir?", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                string vquery = "DELETE FROM tb_cursos WHERE ID_curso=" + tb_IDCurso.Text;
                Banco.dml(vquery);
                dgv_curso.Rows.Remove(dgv_curso.CurrentRow);
                MessageBox.Show("Excluido com sucesso!");
            }
        }

        private void dgv_professor_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int contlinhas = dgv.SelectedRows.Count;
            if (contlinhas > 0)
            {

                DataTable dt = new DataTable();
                string vid = dgv.SelectedRows[0].Cells[0].Value.ToString();
                string vquery = "SELECT * FROM tb_cursos WHERE ID_curso=" + vid;

                dt = Banco.dql(vquery);
                tb_IDCurso.Text = dt.Rows[0].Field<Int32>("ID_curso").ToString();
                tb_curso.Text = dt.Rows[0].Field<string>("nome_curso");

            }
        }

        private void F_GestaoCursos_Load(object sender, EventArgs e)
        {
            string vquery = " SELECT ID_curso as 'ID', nome_curso as 'Nome' FROM tb_cursos  WHERE ID_curso > 2 ORDER BY nome_curso";

            dgv_curso.DataSource = Banco.dql(vquery);
            dgv_curso.Columns[0].Width = 45;
            dgv_curso.Columns[1].Width = 347;

            dgv_curso.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv_curso.ClearSelection();
            tb_curso.Clear();
            tb_IDCurso.Clear();
        }
    }
}
