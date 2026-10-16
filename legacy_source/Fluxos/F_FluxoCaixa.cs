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
    public partial class F_Fluxo : Form
    {
        public F_Fluxo()
        {
            InitializeComponent();
        }

        private void F_Fluxo_Load(object sender, EventArgs e)
        {
            string Hora = DateTime.Now.ToString("HH:mm:ss");

            this.tb_caixa1TableAdapter.Fill(this.dbatenienseDataSet.tb_caixa1, Convert.ToDateTime(Globais.Main.PassarData1), Convert.ToDateTime(Globais.Main.PassarData2));

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("data", Convert.ToDateTime(Globais.Main.PassarData1).ToString("dd/MM/yyyy") + " à " + Convert.ToDateTime(Globais.Main.PassarData2).ToString("dd/MM/yyyy")));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("hora", Hora));


            //Entrada Crédito
            var vconn = Banco.ConexaoBanco();
            string EntradaTotalCredito = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_caixa
            WHERE forma = 'CRÉDITO'
            AND data BETWEEN '{0}' AND '{1}' AND tipo_movimentacao = 'ENTRADA'", Globais.Main.PassarData1, Globais.Main.PassarData2);
            DataTable Credito = Banco.dql(EntradaTotalCredito);
            vconn.Close();

            //Saida Crédito
            vconn = Banco.ConexaoBanco();
            string SaidaTotalCredito = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_caixa
            WHERE forma = 'CRÉDITO'
            AND data BETWEEN '{0}' AND '{1}' AND tipo_movimentacao = 'SAIDA'", Globais.Main.PassarData1, Globais.Main.PassarData2);
            DataTable saidacredito = Banco.dql(SaidaTotalCredito);
            vconn.Close();

            //Entrada Débito
            vconn = Banco.ConexaoBanco();
            string EntradaTotalDebito = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total 
            FROM tb_caixa
            WHERE forma = 'DÉBITO'
            AND data BETWEEN '{0}' AND '{1}' AND tipo_movimentacao = 'ENTRADA'", Globais.Main.PassarData1, Globais.Main.PassarData2);
            DataTable Debito = Banco.dql(EntradaTotalDebito);
            vconn.Close();

            //Saida Débito
            vconn = Banco.ConexaoBanco();
            string SaidaTotalDebito = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_caixa
            WHERE forma = 'DÉBITO'
            AND data BETWEEN '{0}' AND '{1}' AND tipo_movimentacao = 'SAIDA'", Globais.Main.PassarData1, Globais.Main.PassarData2);
            DataTable saidadebito = Banco.dql(SaidaTotalDebito);
            vconn.Close();

            //Entrada Dinheiro
            vconn = Banco.ConexaoBanco();
            string EntradaTotalDinheiro = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_caixa
            WHERE forma = 'DINHEIRO'
            AND data BETWEEN '{0}' AND '{1}' AND tipo_movimentacao = 'ENTRADA'", Globais.Main.PassarData1, Globais.Main.PassarData2);
            DataTable dinheiro = Banco.dql(EntradaTotalDinheiro);
            vconn.Close();

            //Saida Dinheiro
            vconn = Banco.ConexaoBanco();
            string SaidaTotalDinheiro = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_caixa
            WHERE forma = 'DINHEIRO'
            AND data BETWEEN '{0}' AND '{1}' AND tipo_movimentacao = 'SAIDA'", Globais.Main.PassarData1, Globais.Main.PassarData2);
            DataTable saidadinheiro = Banco.dql(SaidaTotalDinheiro);
            vconn.Close();

            //Entrada PIX
            vconn = Banco.ConexaoBanco();
            string EntradaTotalPIX = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_caixa
            WHERE forma = 'PIX'
            AND data BETWEEN '{0}' AND '{1}' AND tipo_movimentacao = 'ENTRADA'", Globais.Main.PassarData1, Globais.Main.PassarData2);
            DataTable pix = Banco.dql(EntradaTotalPIX);
            vconn.Close();

            //Saida PIX
            vconn = Banco.ConexaoBanco();
            string SaidaTotalPIX = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_caixa
            WHERE forma = 'PIX'
            AND data BETWEEN '{0}' AND '{1}' AND tipo_movimentacao = 'SAIDA'", Globais.Main.PassarData1, Globais.Main.PassarData2);
            DataTable saidapix = Banco.dql(SaidaTotalPIX);
            vconn.Close();

            vconn = Banco.ConexaoBanco();
            string SubtotalDiaEntradas = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_caixa
            WHERE tipo_movimentacao = 'ENTRADA'
            AND data BETWEEN '{0}' AND '{1}'", Globais.Main.PassarData1, Globais.Main.PassarData2);
            DataTable subtotalEntradas = Banco.dql(SubtotalDiaEntradas);
            vconn.Close();

            vconn = Banco.ConexaoBanco();
            string Saida = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_caixa
            WHERE tipo_movimentacao = 'SAIDA'
            AND data BETWEEN '{0}' AND '{1}'", Globais.Main.PassarData1, Globais.Main.PassarData2);
            DataTable saida = Banco.dql(Saida);
            vconn.Close();

            vconn = Banco.ConexaoBanco();
            string Vendas = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_caixa
            WHERE tipo_movimentacao = 'VENDA'
            AND data BETWEEN '{0}' AND '{1}'", Globais.Main.PassarData1, Globais.Main.PassarData2);
            DataTable vendas = Banco.dql(Vendas);
            vconn.Close();

            //Venda Crédito
            vconn = Banco.ConexaoBanco();
            string VendaTotalCredito = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_caixa
            WHERE tipo_movimentacao = 'VENDA' AND forma = 'CRÉDITO'
            AND data BETWEEN '{0}' AND '{1}'", Globais.Main.PassarData1, Globais.Main.PassarData2);
            DataTable VendaCredito = Banco.dql(VendaTotalCredito);
            vconn.Close();

            //Entrada Débito
            vconn = Banco.ConexaoBanco();
            string VendaTotalDebito = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total 
            FROM tb_caixa
            WHERE tipo_movimentacao = 'VENDA' AND forma = 'DÉBITO'
            AND data BETWEEN '{0}' AND '{1}'", Globais.Main.PassarData1, Globais.Main.PassarData2);
            DataTable VendaDebito = Banco.dql(VendaTotalDebito);
            vconn.Close();

            //Entrada Dinheiro
            vconn = Banco.ConexaoBanco();
            string VendaTotalDinheiro = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_caixa
            WHERE tipo_movimentacao = 'VENDA' AND forma = 'DINHEIRO'
            AND data BETWEEN '{0}' AND '{1}'", Globais.Main.PassarData1, Globais.Main.PassarData2);
            DataTable Vendadinheiro = Banco.dql(VendaTotalDinheiro);
            vconn.Close();

            //Entrada PIX
            vconn = Banco.ConexaoBanco();
            string VendaTotalPIX = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_caixa
            WHERE tipo_movimentacao = 'VENDA' AND forma = 'PIX'
            AND data BETWEEN '{0}' AND '{1}'", Globais.Main.PassarData1, Globais.Main.PassarData2);
            DataTable Vendapix = Banco.dql(VendaTotalPIX);
            vconn.Close();

            //Entradas

            decimal EntradaCredito = Credito.Rows[0].Field<decimal>("total");
            decimal EntradaDebito = Debito.Rows[0].Field<decimal>("total");
            decimal EntradaDinheiro = dinheiro.Rows[0].Field<decimal>("total");
            decimal EntradaPIX = pix.Rows[0].Field<decimal>("total");

            decimal VendasCredito = VendaCredito.Rows[0].Field<decimal>("total");
            decimal VendasDebito = VendaDebito.Rows[0].Field<decimal>("total");
            decimal VendasDinheiro = Vendadinheiro.Rows[0].Field<decimal>("total");
            decimal VendasPIX = Vendapix.Rows[0].Field<decimal>("total");


            decimal Entradas = subtotalEntradas.Rows[0].Field<decimal>("total");
            decimal Vendass = vendas.Rows[0].Field<decimal>("total");
            string EntradaTotal = (Entradas + Vendass).ToString("C");


            //Saidas

            decimal SaidaCredito = saidacredito.Rows[0].Field<decimal>("total");
            decimal SaidaDebito = saidadebito.Rows[0].Field<decimal>("total");
            decimal SaidaDinheiro = saidadinheiro.Rows[0].Field<decimal>("total");
            decimal SaidaPIX = saidapix.Rows[0].Field<decimal>("total");
            decimal Saidas = saida.Rows[0].Field<decimal>("total");
            string SaidaTotal = saida.Rows[0].Field<decimal>("total").ToString("C");

            //Vendas

            decimal ValorCredito = VendasCredito + EntradaCredito - SaidaCredito;
            decimal ValorDebito = VendasDebito + EntradaDebito - SaidaDebito;
            decimal ValorDinheiro = VendasDinheiro + EntradaDinheiro - SaidaDinheiro;
            decimal ValorPIX = VendasPIX + EntradaPIX - SaidaPIX;
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("credito", ValorCredito.ToString("C"))); 
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("debito", ValorDebito.ToString("C")));        
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dinheiro", ValorDinheiro.ToString("C")));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pix", ValorPIX.ToString("C")));

           
            decimal ENTRADAS, SAIDAS, VENDAS;
            ENTRADAS = Entradas;
            SAIDAS = Saidas;
            VENDAS = Vendass;

            decimal ValorTotal = ENTRADAS - SAIDAS;
            ValorTotal = ValorTotal + VENDAS;

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("total", ValorTotal.ToString("C")));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("entrada", EntradaTotal));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("saida", SaidaTotal));

            this.reportViewer1.RefreshReport();
        }
    }
}
