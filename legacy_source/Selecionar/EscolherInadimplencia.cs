using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Selecionar
{
    public partial class EscolherInadimplencia : Form
    {
        public EscolherInadimplencia()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Caixa.F_Inadimplencia f_Inadimplencia = new Caixa.F_Inadimplencia();
            f_Inadimplencia.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursos.F_InadimplenciaCursos f_Inadimplencia = new Cursos.F_InadimplenciaCursos();
            f_Inadimplencia.ShowDialog();
        }
    }
}
