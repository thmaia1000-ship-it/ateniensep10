using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Mensalidades
{
    public partial class DialogMatricula : Form
    {
        public DialogMatricula()
        {
            InitializeComponent();
        }

        private void matriculaButton_Click(object sender, EventArgs e)
        {
            Globais.Main.PassarTipo = "Matricula";
            F_NovoAluno matricula = new F_NovoAluno();
            matricula.Show();

            this.Close();
        }

        private void rematriculaButton_Click(object sender, EventArgs e)
        {
            Globais.Main.PassarTipo = "Rematricula";
            F_GerarMensalidade gerar = new F_GerarMensalidade();
            gerar.Show();

            this.Close();
        }

        private void DialogMatricula_Load(object sender, EventArgs e)
        {
          
        }
    }
}
