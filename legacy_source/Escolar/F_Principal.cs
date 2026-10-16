using Escolar.Caixa;
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
    public partial class F_Principal : Form
    {

        public F_Principal()
        {
            InitializeComponent();
            F_Login f_Login = new F_Login(this);
            f_Login.ShowDialog();

        }

        private void abreForm(int nivel, Form f)
        {
            if (Globais.logado)
            {

                if (Globais.nivel >= nivel)
                //Procedimentos
                {
                    
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Acesso não permitido");
                }

            }
            else
            {
                MessageBox.Show("É necessário ter um usuário logado");
            }
        }


        private void logonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Login f_Login = new F_Login(this);
            f_Login.ShowDialog();
        }

        private void logoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lb_acesso.Text = "0";
            lb_nomeUsuario.Text = "---";
            //pb_ledLogado.Image = Properties.Resources.png_transparent_light_computer_icons_menu_bar_button_macos_light_light_mac_led;
            Globais.nivel = 0;
            Globais.logado = false;
        }
        private void gestãoDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_GestaoUsuarios f_GestaoUsuarios = new F_GestaoUsuarios();
            abreForm(2, f_GestaoUsuarios);
        }  

        
        private void novoUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_NovoUsuario f_NovoUsuario = new F_NovoUsuario();
            f_NovoUsuario.Show();
        }

        

        private void mátriculaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_NovoAluno f_NovoAluno = new F_NovoAluno();
            abreForm(2, f_NovoAluno);
        }

        private void consultarMatrículasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_GestaoAlunos f_GestaoAlunos = new F_GestaoAlunos();
            abreForm(2, f_GestaoAlunos);
        }

        private void turmasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_GestaoTurmas f_GestaoTurmas = new F_GestaoTurmas();
            abreForm(2, f_GestaoTurmas);
        }

        

        private void professoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_GestaoProfessores f_GestaoProfessores = new F_GestaoProfessores();
            abreForm(2, f_GestaoProfessores);
        }

        private void boletimEscolarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_BoletimEscolar f_BoletimEscolar = new F_BoletimEscolar();
            abreForm(2, f_BoletimEscolar);
        }

        private void gerarMensalidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_GerarMensalidade f_GerarMensalidade = new F_GerarMensalidade();
            abreForm(2, f_GerarMensalidade);
        }

        private void caixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            F_PagarMensalidade f_Caixa = new F_PagarMensalidade();
            abreForm(2, f_Caixa);

        }



        private void cursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Cursos f_Cursos = new F_Cursos();
            abreForm(2, f_Cursos);
        }

        private void matériasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Materias f_materias = new F_Materias();
            abreForm(2, f_materias);
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_ContratoNormal f_ContratoNormal = new F_ContratoNormal();
            abreForm(2, f_ContratoNormal);
        }

        private void caixaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            F_Caixa f_Caixa = new F_Caixa();
            abreForm(2, f_Caixa);
        }
    }
}
