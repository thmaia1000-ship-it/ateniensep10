using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.declaracoes
{
    public partial class Transferencia : Form
    {
        public Transferencia()
        {
            InitializeComponent();
        }

        private void btn_gerar_Click(object sender, EventArgs e)
        {
            Globais.Main.PassarData = dtp_Data.Value.ToString("dd' de 'MMMM' de 'yyyy");

            Close();
        }

        private void Transferencia_Load(object sender, EventArgs e)
        {
            Globais.Main.PassarData = dtp_Data.Value.ToString("dd' de 'MMMM' de 'yyyy");
        }
    }
}
