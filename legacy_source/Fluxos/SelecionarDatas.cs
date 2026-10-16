using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Fluxos
{
    public partial class SelecionarDatas : Form
    {
        public SelecionarDatas()
        {
            InitializeComponent();
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Globais.Main.PassarData1 = dtp_Data1.Value.ToString("yyyy-MM-dd");
            Globais.Main.PassarData2 = dtp_Data2.Value.ToString("yyyy-MM-dd");

            if (Globais.Main.PassarTipo == "CAIXA")
            {
                F_Fluxo f_FluxoCaixa = new F_Fluxo();
                f_FluxoCaixa.Show();
            }
            else if (Globais.Main.PassarTipo == "VENDA")
            {
                Fluxos.FluxoProdutos fluxoVendas = new Fluxos.FluxoProdutos();
                fluxoVendas.Show();
            }
            Close();
        }
    }
}
