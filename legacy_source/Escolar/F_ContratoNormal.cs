using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;
namespace Escolar
{
    public partial class F_ContratoNormal : Form
    {
        public F_ContratoNormal()
        {
            InitializeComponent();
        }

        private void F_ContratoNormal_Load(object sender, EventArgs e)
        {


            this.reportViewer1.RefreshReport();
        }

    }
}