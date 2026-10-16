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
    public partial class F_Loading : Form
    {
        public F_Loading(string texto)
        {
            InitializeComponent();
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Aguarde...";

            label.Text = texto;
        }

        private string mensagemPersonalizada;

        private void F_Loading_Load(object sender, EventArgs e)
        {
          
        }
    }
}
