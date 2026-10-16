using Microsoft.Reporting.Map.WebForms.BingMaps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Escolar
{
    public partial class F_ReciboMensalidade : Form
    {
        F_FormaPagamento f_Recibo;

        public F_ReciboMensalidade(F_FormaPagamento r)
        {
            InitializeComponent();
            f_Recibo = r;
        }


        private void F_ReciboMensalidade_Load(object sender, EventArgs e)
        {
            var vcon = Banco.ConexaoBanco();
            string vquery = String.Format(@"
            SELECT
                parcelas_pagas
                FROM tb_mensalidades
                WHERE idaluno =" + Globais.Main.PassarParcelas);

            DataTable dt = Banco.dql(vquery);
            vcon.Close();
            

            parcelas_pagas.Text = dt.Rows[0].Field<string>("parcelas_pagas").ToString();


            decimal valor = Convert.ToDecimal(f_Recibo.lb_Total.Text);

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("recibo", decimal.Parse(f_Recibo.lb_Total.Text).ToString("C")));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("nome_aluno", Globais.Main.PassarAluno));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pagamento", f_Recibo.lb_FormaPagamento.Text));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("responsavel_financeiro", Globais.Main.PassarIdAluno));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("extenso", Conversor.EscreverExtenso(valor)));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("parcelas_pagas", parcelas_pagas.Text));


            this.reportViewer1.RefreshReport();
        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
            
            if (reportViewer1.PrintDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Close();
            }
        }
    }
}
