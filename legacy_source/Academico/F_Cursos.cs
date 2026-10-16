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
    public partial class F_Cursos : Form
    {
        string vqueryDGV;
        string idSelecionado;
        int modo = 0; //0= Padrao, 1 = Edição, 2 = Inserção
        public F_Cursos()
        {
            InitializeComponent();
        }

        private void F_Cursos_Load(object sender, EventArgs e)
        {
            tb_Curso.Enabled = false;
            vqueryDGV = "SELECT ID_curso as 'ID', nome_curso as 'Curso' FROM tb_cursos";
            dgv_cursos.DataSource = Banco.dql(vqueryDGV);
            dgv_cursos.Columns[0].Width = 40;
            dgv_cursos.Columns[1].Width = 360;
        }

        private void dgv_cursos_SelectionChanged(object sender, EventArgs e)
        {
            tb_Curso.Enabled = false;
            DataGridView dgv = (DataGridView)sender;
            int contlinhas = dgv.SelectedRows.Count;
            if (contlinhas > 0)
            {
                modo = 0;
                idSelecionado = dgv_cursos.Rows[dgv_cursos.SelectedRows[0].Index].Cells[0].Value.ToString();
                string vqueryCursos = "SELECT nome_curso FROM tb_cursos WHERE ID_curso=" + idSelecionado;
                DataTable dt = Banco.dql(vqueryCursos);
                tb_Curso.Text = dt.Rows[0].Field<string>("nome_curso");
                
            }
        }

        private void btn_novoCurso_Click(object sender, EventArgs e)
        {
            tb_Curso.Enabled = true;
            tb_Curso.Clear();
            modo = 2;
            MessageBox.Show("Defina o nome do Curso que deseja criar!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tb_Curso.Focus();
        }

        private void btn_salvarCurso_Click(object sender, EventArgs e)
        {
            tb_Curso.Enabled = false;
            if (MessageBox.Show("Deseja salvar dados?", "Mensagem do sistema",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
            
            
            if (modo != 0) {
                string queryTurma ="";
                    if (modo == 1)
                   {
                    
                    queryTurma = String.Format("UPDATE tb_cursos SET nome_curso='{0}' WHERE ID_curso={1}", tb_Curso.Text, idSelecionado);
                    MessageBox.Show("Dados atualizados!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Banco.dml(queryTurma);
                   }
                    else
                    {
                    
                    queryTurma = String.Format("INSERT INTO tb_cursos (nome_curso) VALUES ('{0}')", tb_Curso.Text);
                    MessageBox.Show("Dados atualizados!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Banco.dml(queryTurma);

                        if (MessageBox.Show("Deseja criar matérias para este Curso?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            F_Materias f_materias = new F_Materias();
                            f_materias.Show();
                           
                        }
                    }
                    // int linha = dgv_cursos.SelectedRows[0].Index;


                    if (modo == 1)
                    {
                        vqueryDGV = "SELECT ID_curso as 'ID', nome_curso as 'Curso' FROM tb_cursos";
                        dgv_cursos.DataSource = Banco.dql(vqueryDGV);
                        dgv_cursos.Columns[0].Width = 40;
                        dgv_cursos.Columns[1].Width = 360;
                    }
                    else
                    {
                        dgv_cursos.DataSource = Banco.dql(vqueryDGV);
                    }

                }
            }
        }

        private void btn_excluirCurso_Click(object sender, EventArgs e)
        {
            tb_Curso.Enabled = false;
            DialogResult res = MessageBox.Show("Deseja excluir?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                string queryExcluirTurma = String.Format("DELETE FROM tb_cursos WHERE ID_curso={0}", idSelecionado);
                Banco.dml(queryExcluirTurma);
                dgv_cursos.Rows.Remove(dgv_cursos.CurrentRow);
                MessageBox.Show("Dados removidos com sucesso!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        private void tb_Curso_TextChanged(object sender, EventArgs e)
        {
            if (modo == 0)
            {
                modo = 1;
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            tb_Curso.Enabled = true;
        }
    }
    }
