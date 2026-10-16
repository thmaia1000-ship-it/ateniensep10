using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.GerarContratos
{
    public partial class F_Ano_Carne : Form
    {
        public F_Ano_Carne()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tb_ano.TextLength == 4)
            {
                Globais.Main.PassarAno = tb_ano.Text;
                Caixa.F_CarneAteniense carne = new Caixa.F_CarneAteniense();
                carne.ShowDialog();
                Close();

            }
            else
            {
                MessageBox.Show("Insira o Ano para gerar a ficha!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_ano.Focus();
            }
        }
    }
}
