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
    public partial class F_ReciboInterdigitus : Form
    {
        F_FormaPagamento f_ReciboInterdigitus;
        public F_ReciboInterdigitus(F_FormaPagamento f)
        {
            InitializeComponent();
            f_ReciboInterdigitus = f;
        }

        private void F_ReciboInterdigitus_Load(object sender, EventArgs e)
        {
            var vcon = Banco.ConexaoBanco();
            string vencimento = String.Format(@"SELECT SUBSTRING(data_inicio, 1,2) AS vencimento FROM tb_mensalidades          

                WHERE idaluno =" + Globais.Main.PassarParcelas);

            DataTable dt = Banco.dql(vencimento);
            vcon.Close();


            lb_vencimento.Text = dt.Rows[0].Field<string>("vencimento").ToString();

            vcon = Banco.ConexaoBanco();
            string parcelas = String.Format(@"
            SELECT
                parcelas_pagas
                FROM tb_mensalidades
                WHERE idaluno =" + Globais.Main.PassarParcelas);

            DataTable dtt = Banco.dql(parcelas);
            vcon.Close();


            n_parcelas.Text = dtt.Rows[0].Field<string>("parcelas_pagas").ToString();

            

            vcon = Banco.ConexaoBanco();
            string devedor = String.Format(@"
            SELECT
                valor_total
                FROM tb_mensalidades
                WHERE idaluno =" + Globais.Main.PassarParcelas);

            DataTable dttt = Banco.dql(devedor);
            vcon.Close();

            lb_SaldoDevedor.Text = dttt.Rows[0].Field<decimal>("valor_total").ToString();

            vcon = Banco.ConexaoBanco();
            string teste = String.Format(@"
            SELECT SUBSTRING(data_inicio, 4,2)+parcelas_pagas AS vencimento FROM tb_mensalidades          
                WHERE idaluno =" + Globais.Main.PassarParcelas);

            DataTable dtttt = Banco.dql(teste);
            vcon.Close();


            lb_mes.Text = dtttt.Rows[0].Field<double>("vencimento").ToString();


            if (Convert.ToInt32(lb_mes.Text) > 24)
            {
                int Mes = Convert.ToInt32(lb_mes.Text) - 24;
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("mes", Mes.ToString()));
            }
            else if(Convert.ToInt32(lb_mes.Text) > 12)
            {
                int Mes = Convert.ToInt32(lb_mes.Text) - 12;
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("mes", Mes.ToString()));
            }
            
            else
            {
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("mes", lb_mes.Text));
            }
            vcon = Banco.ConexaoBanco();
            string teste2 = String.Format(@"
            SELECT SUBSTRING(data_inicio, 7,4) AS ano_vencimento FROM tb_mensalidades          
                WHERE idaluno =" + Globais.Main.PassarParcelas);

            DataTable dttttt = Banco.dql(teste2);
            vcon.Close();

            lb_Anovencimento.Text = dttttt.Rows[0].Field<string>("ano_vencimento");
            //decimal valor = Convert.ToDecimal(f_ReciboInterdigitus.lb_Total.Text);

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento", lb_vencimento.Text));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("parcelas_pagas", n_parcelas.Text));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("recibo", decimal.Parse(f_ReciboInterdigitus.lb_Total.Text).ToString("C")));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("nome_aluno", Globais.Main.PassarAluno));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("saldo_devedor", decimal.Parse(lb_SaldoDevedor.Text).ToString("C")));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("usuario", Globais.Main.PassarUsuario));
           
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("ano", lb_Anovencimento.Text));
            //this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("extenso", Conversor.EscreverExtenso(valor)));

            this.reportViewer1.RefreshReport();
        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            if (reportViewer1.PrintDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Close();
            }
        }
    }
}
