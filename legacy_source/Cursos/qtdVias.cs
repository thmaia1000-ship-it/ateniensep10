using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Cursos
{
    public partial class qtdVias : Form
    {
        public qtdVias()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Leave(object sender, EventArgs e)
        {

        }

        private void btn_Cupom_Leave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Reverter animação ao perder foco para as cores padrão
                btn.BackColor = Color.SeaGreen;
                btn.ForeColor = Color.Snow;
            }
        }

        private void btn_Cupom_Enter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Simular animação de MouseOver ao ganhar foco
                btn.BackColor = Color.Turquoise;
            }
        }

        private void btn_Recibo_Enter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Simular animação de MouseOver ao ganhar foco
                btn.BackColor = Color.Turquoise;
            }
        }

        private void btn_Recibo_Leave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Reverter animação ao perder foco para as cores padrão
                btn.BackColor = Color.OrangeRed;
                btn.ForeColor = Color.Snow;
            }
        }

        private void btn_Cupom_Click(object sender, EventArgs e)
        {
            if (Globais.Main.TipoRecibo == "CUPOM")
            {
                Caixa.F_ReciboAtenienseDois f_ReciboAtenienseDois = new Caixa.F_ReciboAtenienseDois();
                f_ReciboAtenienseDois.ShowDialog();

            }
            else
            {
                Cupons.F_ReciboMensalidadeDois recibo = new Cupons.F_ReciboMensalidadeDois();
                recibo.ShowDialog();
            }

            Close();
        }

        private void btn_Recibo_Click(object sender, EventArgs e)
        {
            if (Globais.Main.TipoRecibo == "CUPOM")
            {
                Cupons.F_CupomAtenienseUm f_ReciboAtenienseUm = new Cupons.F_CupomAtenienseUm();
                f_ReciboAtenienseUm.ShowDialog();
            }
            else
            {
                Cupons.reportviewer.F_ReciboMensalidade recibo = new Cupons.reportviewer.F_ReciboMensalidade();
                recibo.ShowDialog();

            }
            Close();
        }
    }
}
