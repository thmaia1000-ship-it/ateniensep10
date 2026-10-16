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
    public partial class F_GestaoUsuarios : Form
    {
        public F_GestaoUsuarios()
        {
            InitializeComponent();
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void F_GestaoUsuarios_Load(object sender, EventArgs e)
        {
            dgvusuarios.DataSource = Banco.ObterUsuariosIdNome();
            dgvusuarios.Columns[0].Width = 85;
            dgvusuarios.Columns[1].Width = 190;
        }

        private void dgvusuarios_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView) sender;
            int contlinhas = dgv.SelectedRows.Count;

            if(contlinhas> 0)
            {
                DataTable dt = new DataTable();
                string vid = dgv.SelectedRows[0].Cells[0].Value.ToString();
                dt=Banco.ObterDadosUsuario(vid);
                tb_id.Text = dt.Rows[0].Field<Int32>("ID_usuario").ToString();
                tb_nome.Text = dt.Rows[0].Field<string>("nome_usuario").ToString();
                tb_username.Text = dt.Rows[0].Field<string>("username").ToString();
                tb_senha.Text = dt.Rows[0].Field<string>("senha").ToString();
                cb_status.Text = dt.Rows[0].Field<string>("status").ToString();
                n_nivel.Value = dt.Rows[0].Field<Int32>("nivel_usuario");

            }

        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            f_novoUsuario F_NovoUsuario = new f_novoUsuario();
            F_NovoUsuario.ShowDialog();
            dgvusuarios.DataSource = Banco.ObterUsuariosIdNome();

        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {

            int linha = dgvusuarios.SelectedRows[0].Index;
            Usuario u = new Usuario();
            u.id = Convert.ToInt32(tb_id.Text);
            u.nome = tb_nome.Text;
            u.username = tb_username.Text;
            u.senha = tb_senha.Text;
            u.status = cb_status.Text;
            u.nivel = Convert.ToInt32(Math.Round(n_nivel.Value, 0));

            Banco.AtualizarUsuario(u);
            //dgvusuarios.DataSource = Banco.ObterUsuariosIdNome();
            //dgvusuarios.CurrentCell = dgvusuarios[0, linha];
            //dgvusuarios[0, linha].Value = tb_id.Text;
            dgvusuarios[1, linha].Value = tb_nome.Text;
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {

            DialogResult res = MessageBox.Show("Deseja o Usuário?","Excluir?", MessageBoxButtons.YesNo);
            if(res == DialogResult.Yes)
            {
                Banco.DeletarUsuario(tb_id.Text);
                dgvusuarios.Rows.Remove(dgvusuarios.CurrentRow);
            }
        }


    }
}
