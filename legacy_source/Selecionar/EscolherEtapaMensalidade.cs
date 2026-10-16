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
    public partial class EscolherEtapaMensalidade : Form
    {
        public EscolherEtapaMensalidade()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Globais.Main.Modo = "Etapa";
            Globais.Main.PassarCurso = "MATERNAL I";
            Fluxos.MensalidadesPagas f_MensalidadesPagas = new Fluxos.MensalidadesPagas();
            f_MensalidadesPagas.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Globais.Main.Modo = "Etapa";
            Globais.Main.PassarCurso = "MATERNAL II";
            Fluxos.MensalidadesPagas f_MensalidadesPagas = new Fluxos.MensalidadesPagas();
            f_MensalidadesPagas.ShowDialog();
        }

        private void btn_jardim1_Click(object sender, EventArgs e)
        {
            Globais.Main.Modo = "Etapa";
            Globais.Main.PassarCurso = "JARDIM I";
            Fluxos.MensalidadesPagas f_MensalidadesPagas = new Fluxos.MensalidadesPagas();
            f_MensalidadesPagas.ShowDialog();
        }

        private void btn_jardim2_Click(object sender, EventArgs e)
        {
            Globais.Main.Modo = "Etapa";
            Globais.Main.PassarCurso = "JARDIM II";
            Fluxos.MensalidadesPagas f_MensalidadesPagas = new Fluxos.MensalidadesPagas();
            f_MensalidadesPagas.ShowDialog();
        }

        private void btn_1ano_Click(object sender, EventArgs e)
        {
            Globais.Main.Modo = "Etapa";
            Globais.Main.PassarCurso = "1° ANO";
            Fluxos.MensalidadesPagas f_MensalidadesPagas = new Fluxos.MensalidadesPagas();
            f_MensalidadesPagas.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Globais.Main.Modo = "Geral";
            Fluxos.MensalidadesPagas f_MensalidadesPagas = new Fluxos.MensalidadesPagas();
            f_MensalidadesPagas.ShowDialog();
        }
    }
}
