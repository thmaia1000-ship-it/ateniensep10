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
    public partial class GestaoUsuarios : Form
    {
        public GestaoUsuarios()
        {
            InitializeComponent();
        }

        string idSelecionado = "";
        private void GestaoUsuarios_Load(object sender, EventArgs e)
        {
            string vquery = "SELECT ID_usuario as 'ID',nome_usuario as 'Nome' FROM tb_usuarios WHERE ID_usuario > 1 ORDER BY ID_usuario";

            dgv_usuarios.DataSource = Banco.dql(vquery);
            dgv_usuarios.Columns[0].Width = 35;
            dgv_usuarios.Columns[1].Width = 220;

            dgv_usuarios.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv_usuarios.ClearSelection();
        }

        private void dgv_usuarios_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.SelectedRows.Count > 0)
            {
                idSelecionado = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();

                string vqueryCampos = String.Format(@"
                SELECT
                ID_usuario,
                nome_usuario,
                username,
                senha,
                nivel_usuario
                FROM
                  tb_usuarios
                WHERE ID_usuario={0}
                 ", idSelecionado);

                DataTable dt = Banco.dql(vqueryCampos);
                tb_nome.Text = dt.Rows[0].Field<string>("nome_usuario");
                tb_username.Text = dt.Rows[0].Field<string>("username");
                tb_senha.Text = dt.Rows[0].Field<string>("senha");
                nivel.Value = dt.Rows[0].Field<Int32>("nivel_usuario");
                tb_id.Text = dt.Rows[0].Field<Int32>("ID_usuario").ToString();
                tb_senha.PasswordChar = '*';
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

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            string vquery;
            if (tb_id.Text == "")
            {
                if (tb_nome.Text != "" && tb_username.Text != "" && tb_senha.Text != "")
                {
                    vquery = "INSERT INTO tb_usuarios (nome_usuario,nivel_usuario,username,senha) VALUES ('" + tb_nome.Text + "','" + nivel.Value + "','" + tb_username.Text + "','" + tb_senha.Text + "')";
                    Banco.dml(vquery);
                    MessageBox.Show("Usuário cadastrado com sucesso!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Preencha todos os dados", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                vquery = "UPDATE tb_usuarios SET nome_usuario='" + tb_nome.Text + "', nivel_usuario='" + nivel.Value + "', username='" + tb_username.Text + "', senha='" + tb_senha.Text + "' WHERE ID_usuario=" + tb_id.Text;
                Banco.dml(vquery);
                MessageBox.Show("Dados alterados com sucesso!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            vquery = "SELECT ID_usuario as 'ID',nome_usuario as 'Nome' FROM tb_usuarios WHERE ID_usuario > 1 ORDER BY ID_usuario";

            dgv_usuarios.DataSource = Banco.dql(vquery);
            dgv_usuarios.Columns[0].Width = 35;
            dgv_usuarios.Columns[1].Width = 220;

            dgv_usuarios.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv_usuarios.ClearSelection();
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            tb_id.Clear();
            tb_nome.Clear();
            tb_username.Clear();
            tb_senha.Clear();
            dgv_usuarios.ClearSelection();
            nivel.Value = 1;
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseja excluir?", "Excluir?", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                if (dgv_usuarios.Rows.Count > 0)
                {
                    string vquery = "DELETE FROM tb_usuarios WHERE ID_usuario=" + tb_id.Text;
                    Banco.dml(vquery);
                    dgv_usuarios.Rows.Remove(dgv_usuarios.CurrentRow);
                    MessageBox.Show("Excluido com sucesso!");
                }
                
            }
        }
    }
}
