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
            dgv_professor.Columns[0].Width = 35;
            dgv_professor.Columns[1].Width = 270;
            dgv_professor.Columns[2].Width = 100;

            dgv_professor.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv_professor.ClearSelection();
            tb_idProfessor.Clear();
            tb_NomeProfessor.Clear();
            mtb_Telefone.Clear();
            tb_NomeProfessor.Focus();
            tb_senha.Clear();
            tb_username.Clear();
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
                tb_username.Text = dt.Rows[0].Field<string>("username");
                tb_senha.Text = dt.Rows[0].Field<string>("senha");
                tb_senha.PasswordChar = '*';

            }
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            tb_idProfessor.Clear();
            tb_NomeProfessor.Clear();
            mtb_Telefone.Clear();
            tb_NomeProfessor.Focus();
            tb_senha.Clear();
            tb_username.Clear();

            dgv_professor.ClearSelection();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            string vquery;
            if (tb_idProfessor.Text == "")
            {
                if(tb_NomeProfessor.Text != "" && tb_username.Text != "" && tb_senha.Text != "")
                {
                    vquery = "INSERT INTO tb_professores (nome_professor, telefone,username,senha) VALUES ('" + tb_NomeProfessor.Text + "','" + mtb_Telefone.Text + "','" + tb_username.Text + "','" + tb_senha.Text + "')";
                    Banco.dml(vquery);
                    MessageBox.Show("Professor(a) cadastrado com sucesso!","Mensagem do Sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                   
                }
                else
                {
                    MessageBox.Show("Preencha todos os dados", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                vquery = "UPDATE tb_professores SET nome_professor='" + tb_NomeProfessor.Text + "', telefone='" + mtb_Telefone.Text + "', username='" + tb_username.Text + "', senha='" + tb_senha.Text + "' WHERE ID_professor=" + tb_idProfessor.Text;
                Banco.dml(vquery);
                MessageBox.Show("Dados alterados com sucesso!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            vquery = " SELECT ID_professor as 'ID', nome_professor as 'Nome', telefone as 'Telefone' FROM tb_professores ORDER BY nome_professor";

            dgv_professor.DataSource = Banco.dql(vquery);

            dgv_professor.ClearSelection();
            tb_idProfessor.Clear();
            tb_NomeProfessor.Clear();
            mtb_Telefone.Clear();
            tb_NomeProfessor.Focus();
            tb_senha.Clear();
            tb_username.Clear();

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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (tb_senha.PasswordChar == '*')
            {
                tb_senha.PasswordChar = '\0'; // Caractere vazio
                checkBox1.Text = "Ocultar";
            }
            else
            {
                tb_senha.PasswordChar = '*';
                checkBox1.Text = "Mostrar";
            }
        }
    }
    }

