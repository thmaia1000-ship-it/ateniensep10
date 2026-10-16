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
    public partial class FluxoProdutos : Form
    {
        public FluxoProdutos()
        {
            InitializeComponent();
        }

        private void FluxoProdutos_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'dbatenienseVendas.tb_vendas'. Você pode movê-la ou removê-la conforme necessário.
            this.tb_produtosTableAdapter.FluxoProduto(this.dbatenienseVendas.tb_produtos, Convert.ToDateTime(Globais.Main.PassarData1), Convert.ToDateTime(Globais.Main.PassarData2));

            string Data = DateTime.Now.ToString("dd/MM/yyyy");
            string Hora = DateTime.Now.ToString("HH:mm:ss");

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("data", Convert.ToDateTime(Globais.Main.PassarData1).ToString("dd/MM/yyyy") + " à " + Convert.ToDateTime(Globais.Main.PassarData2).ToString("dd/MM/yyyy")));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("hora", Hora));

            //Entrada Crédito
            var vconn = Banco.ConexaoBanco();
            string EntradaTotalCredito = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_caixa
            WHERE forma = 'CRÉDITO'
            AND data BETWEEN '{0}' AND '{1}'  AND tipo_movimentacao = 'VENDA'", Globais.Main.PassarData1, Globais.Main.PassarData2);
            DataTable Credito = Banco.dql(EntradaTotalCredito);

            //Entrada Débito
            vconn = Banco.ConexaoBanco();
            string EntradaTotalDebito = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total 
            FROM tb_caixa
            WHERE forma = 'DÉBITO'
            AND data BETWEEN '{0}' AND '{1}'  AND tipo_movimentacao = 'VENDA'", Globais.Main.PassarData1, Globais.Main.PassarData2);
            DataTable Debito = Banco.dql(EntradaTotalDebito);
            vconn.Close();

            //Entrada Dinheiro
            vconn = Banco.ConexaoBanco();
            string EntradaTotalDinheiro = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_caixa
            WHERE forma = 'DINHEIRO'
            AND data BETWEEN '{0}' AND '{1}'  AND tipo_movimentacao = 'VENDA'", Globais.Main.PassarData1, Globais.Main.PassarData2);
            DataTable dinheiro = Banco.dql(EntradaTotalDinheiro);
            vconn.Close();

            //Entrada PIX
            vconn = Banco.ConexaoBanco();
            string EntradaTotalPIX = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_caixa
            WHERE forma = 'PIX'
            AND data BETWEEN '{0}' AND '{1}'  AND tipo_movimentacao = 'VENDA'", Globais.Main.PassarData1, Globais.Main.PassarData2);
            DataTable pix = Banco.dql(EntradaTotalPIX);
            vconn.Close();

            vconn = Banco.ConexaoBanco();
            string Vendas = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_caixa
            WHERE tipo_movimentacao = 'VENDA'
            AND data BETWEEN '{0}' AND '{1}'", Globais.Main.PassarData1, Globais.Main.PassarData2);
            DataTable vendas = Banco.dql(Vendas);
            vconn.Close();
            //Entradas

            decimal EntradaCredito = Credito.Rows[0].Field<decimal>("total");
            decimal EntradaDebito = Debito.Rows[0].Field<decimal>("total");
            decimal EntradaDinheiro = dinheiro.Rows[0].Field<decimal>("total");
            decimal EntradaPIX = pix.Rows[0].Field<decimal>("total");
            decimal VendasTotal = vendas.Rows[0].Field<decimal>("total");

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dinheiro", EntradaDinheiro.ToString("C")));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pix", EntradaPIX.ToString("C")));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("debito", EntradaDebito.ToString("C")));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("credito", EntradaCredito.ToString("C")));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("total", VendasTotal.ToString("C")));

            this.reportViewer1.RefreshReport();
        }
    }
}
