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
    public partial class F_Login : Form
    {
        F_Principal form1;
        DataTable dt = new DataTable();


        public F_Login(F_Principal f)
        {
            InitializeComponent();
            form1 = f;
        }

        private void btn_logar_Click(object sender, EventArgs e)
        {

            string username = tb_username.Text;
            string senha = tb_senha.Text;

            if(username == "" || senha == "")
            {

                MessageBox.Show("Usuário ou senha incorretos");
                tb_username.Focus();
                return;

            }

            string sql = "SELECT * FROM tb_usuarios WHERE username='"+username+"' AND senha='"+senha+"'";
            dt = Banco.dql(sql);
            if (dt.Rows.Count ==1)
            {
                form1.lb_acesso.Text = dt.Rows[0].ItemArray[5].ToString();
                form1.lb_nomeUsuario.Text = dt.Rows[0].Field<string>("nome_usuario");

                //form1.pb_ledLogado.Image = Properties.Resources.png_transparent_light_computer_icons_menu_bar_button_macos_light_light_mac_led;
                Globais.nivel= int.Parse(dt.Rows[0].Field<Int32>("nivel_usuario").ToString());
                Globais.logado = true;
                Globais.Main.PassarUsuario = form1.lb_nomeUsuario.Text;

                this.Close();
                MessageBox.Show("Logado com Sucesso!");
            } else
            {
                MessageBox.Show("Usuário ou senha incorreta!");
            }
        }

        

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void f_Login_Load(object sender, EventArgs e)
        {

        }
    }
}
