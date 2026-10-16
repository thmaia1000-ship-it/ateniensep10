using iTextSharp.text.pdf.qrcode;
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
    public partial class F_Materias : Form
    {
        string vqueryDGV;
        int modo = 0;
        string idSelecionado;
        public F_Materias()
        {
            InitializeComponent();
        }

        private void F_Materias_Load(object sender, EventArgs e)
        {
            //POPULAR COMBOBOX Cursos
            
                tb_Materia.Enabled = false;
                string vqueryCursos = @"
                SELECT
                ID_curso,
                nome_curso
   
                 FROM
                      tb_cursos
                 ORDER BY
                      nome_curso";
                cb_cursos.Items.Clear();
                cb_cursos.DataSource = Banco.dql(vqueryCursos);
                cb_cursos.DisplayMember = "nome_curso";
                cb_cursos.ValueMember = "ID_curso";
            
            //EXIBIR MATÉRIAS E CURSOS

            vqueryDGV = string.Format(@"SELECT ID_materia as 'ID', materia as 'Materia'
                        FROM tb_materias
                        WHERE idcurso="+ cb_cursos.SelectedValue);
            dgv_cursos.DataSource = Banco.dql(vqueryDGV);
            dgv_cursos.Columns[0].Width = 40;
            dgv_cursos.Columns[1].Width = 340;
            modo = 0;
        }

        private void dgv_cursos_SelectionChanged(object sender, EventArgs e)
        {
            tb_Materia.Enabled = false;
            DataGridView dgv = (DataGridView)sender;
            int contlinhas = dgv.SelectedRows.Count;
            if (contlinhas > 0)
            {
                modo = 0;
                idSelecionado = dgv_cursos.Rows[dgv_cursos.SelectedRows[0].Index].Cells[0].Value.ToString();
                string vqueryCursos = "SELECT materia FROM tb_materias WHERE ID_materia=" + idSelecionado;
                DataTable dt = Banco.dql(vqueryCursos);
                tb_Materia.Text = dt.Rows[0].Field<string>("materia");

            }
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            tb_Materia.Enabled = true;
            tb_Materia.Clear();
            modo = 2;
            MessageBox.Show("Defina o nome da Matéria que deseja criar!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tb_Materia.Focus();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Deseja salvar dados?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (modo != 0)
                {
                    string queryTurma = "" ;
                
            
                    if (modo == 1)
                    {

                queryTurma = String.Format("UPDATE tb_materias SET materia='{0}', idcurso={1} WHERE ID_materia={2}", tb_Materia.Text, cb_cursos.SelectedValue,idSelecionado);
                MessageBox.Show("Dados atualizados!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Banco.dml(queryTurma);

            }
            else
            {
                queryTurma = String.Format("INSERT INTO tb_materias (materia,idcurso) VALUES ('{0}',{1})", tb_Materia.Text, cb_cursos.SelectedValue);
                MessageBox.Show("Dados atualizados!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Banco.dml(queryTurma);

            }

                    // int linha = dgv_cursos.SelectedRows[0].Index;


                    if (modo == 1)
                    {
                        vqueryDGV = string.Format(@"SELECT ID_materia as 'ID', materia as 'Materia'
                        FROM tb_materias
                        WHERE idcurso=" + cb_cursos.SelectedValue);
                        dgv_cursos.DataSource = Banco.dql(vqueryDGV);
                        dgv_cursos.Columns[0].Width = 40;
                        dgv_cursos.Columns[1].Width = 340;
                    }
                    else
                    {
                        dgv_cursos.DataSource = Banco.dql(vqueryDGV);
                    }

                }
            }
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseja excluir?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                string queryExcluirTurma = String.Format("DELETE FROM tb_materias WHERE ID_materia={0}", idSelecionado);
                Banco.dml(queryExcluirTurma);
                dgv_cursos.Rows.Remove(dgv_cursos.CurrentRow);
                MessageBox.Show("Dados removidos com sucesso!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void tb_Materia_TextChanged(object sender, EventArgs e)
        {
            if (modo == 0)
            {
                modo = 1;
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            tb_Materia.Enabled = true;
        }

        private void cb_cursos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            vqueryDGV = string.Format(@"SELECT ID_materia as 'ID', materia as 'Materia'
                        FROM tb_materias
                        WHERE idcurso=" + cb_cursos.SelectedValue);
            dgv_cursos.DataSource = Banco.dql(vqueryDGV);
            dgv_cursos.Columns[0].Width = 40;
            dgv_cursos.Columns[1].Width = 340;
        }
    }
}
