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
    public partial class MensalidadeOuCurso : Form
    {
        public MensalidadeOuCurso()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Globais.Main.Modo != "Mensalidades Receber")
            {
                Selecionar.EscolherEtapaMensalidade escolherEtapaMensalidade = new EscolherEtapaMensalidade();
                escolherEtapaMensalidade.Show();
            }
            else
            {
                Caixa.MensalidadesReceber mensalidades = new Caixa.MensalidadesReceber();
                mensalidades.Show();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Globais.Main.Modo != "Mensalidades Receber")
            {
                Selecionar.EscolherCursoMensalidade escolherCursoMensalidade = new EscolherCursoMensalidade();
                escolherCursoMensalidade.Show();
            }
            else
            {
                Caixa.MensalidadesReceber_Curso mensalidadesReceber_Curso = new Caixa.MensalidadesReceber_Curso();
                mensalidadesReceber_Curso.Show();
                
            }
        }

        private void MensalidadeOuCurso_Load(object sender, EventArgs e)
        {

        }

        private void MensalidadeOuCurso_Leave(object sender, EventArgs e)
        {
        }

        private void MensalidadeOuCurso_FormClosing(object sender, FormClosingEventArgs e)
        {
            Globais.Main.Modo = "";
        }
    }
}
