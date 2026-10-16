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
    public partial class MensalidadesPagasCurso : Form
    {
        public MensalidadesPagasCurso()
        {
            InitializeComponent();
        }

        private void MensalidadesPagasCurso_Load(object sender, EventArgs e)
        {
            string Hora = DateTime.Now.ToString("HH:mm:ss");
            if (Globais.Main.Modo == "Geral")
            {
                this.tb_caixaTableAdapter.FillByCursos(this.dbatenienseDataSet.tb_caixa, Convert.ToInt32(Globais.Main.PassarMes), Convert.ToInt32(Globais.Main.PassarAno));

                DateTime Mes = Convert.ToDateTime(Globais.Main.PassarAno + "-12-01");
                Mes = Mes.AddMonths((Convert.ToInt32(Globais.Main.PassarMes)));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("mes", Mes.ToString("MMMM").ToUpper()));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("ano_letivo", Globais.Main.PassarAno));


                //Entrada Crédito
                var vconn = Banco.ConexaoBanco();
                string EntradaTotalCredito = String.Format(@"
                SELECT IFNULL(SUM(valor_total),0) as total  
                FROM tb_caixa
                WHERE forma = 'CRÉDITO'
                AND MONTH(data) ={0} AND YEAR(data) ={1} AND descricao = 'Mensalidade Curso'", Globais.Main.PassarMes, Globais.Main.PassarAno);
                DataTable Credito = Banco.dql(EntradaTotalCredito);
                vconn.Close();

                //Entrada Débito
                vconn = Banco.ConexaoBanco();
                string EntradaTotalDebito = String.Format(@"
                SELECT IFNULL(SUM(valor_total),0) as total 
                FROM tb_caixa
                WHERE forma = 'DÉBITO'
                AND MONTH(data) ={0} AND YEAR(data) ={1} AND descricao = 'Mensalidade Curso'", Globais.Main.PassarMes, Globais.Main.PassarAno);
                DataTable Debito = Banco.dql(EntradaTotalDebito);
                vconn.Close();

                //Entrada Dinheiro
                vconn = Banco.ConexaoBanco();
                string EntradaTotalDinheiro = String.Format(@"
                SELECT IFNULL(SUM(valor_total),0) as total  
                FROM tb_caixa
                WHERE forma = 'DINHEIRO'
                AND MONTH(data) ={0} AND YEAR(data) ={1} AND descricao = 'Mensalidade Curso'", Globais.Main.PassarMes, Globais.Main.PassarAno);
                DataTable dinheiro = Banco.dql(EntradaTotalDinheiro);
                vconn.Close();
                //Entrada PIX
                vconn = Banco.ConexaoBanco();
                string EntradaTotalPIX = String.Format(@"
                SELECT IFNULL(SUM(valor_total),0) as total  
                FROM tb_caixa
                WHERE forma = 'PIX'
                AND MONTH(data) ={0} AND YEAR(data) ={1} AND descricao = 'Mensalidade Curso'", Globais.Main.PassarMes, Globais.Main.PassarAno);
                DataTable pix = Banco.dql(EntradaTotalPIX);
                vconn.Close();

                vconn = Banco.ConexaoBanco();
                string SubtotalDiaEntradas = String.Format(@"
                SELECT IFNULL(SUM(valor_total),0) as total  
                FROM tb_caixa
                WHERE descricao = 'Mensalidade Curso'
                AND MONTH(data) ={0} AND YEAR(data) ={1}", Globais.Main.PassarMes, Globais.Main.PassarAno);
                DataTable subtotalEntradas = Banco.dql(SubtotalDiaEntradas);
                vconn.Close();

                //Entradas

                decimal EntradaCredito = Credito.Rows[0].Field<decimal>("total");
                decimal EntradaDebito = Debito.Rows[0].Field<decimal>("total");
                decimal EntradaDinheiro = dinheiro.Rows[0].Field<decimal>("total");
                decimal EntradaPIX = pix.Rows[0].Field<decimal>("total");
                decimal Entradas = subtotalEntradas.Rows[0].Field<decimal>("total");

                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("credito", EntradaCredito.ToString("C")));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("debito", EntradaDebito.ToString("C")));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dinheiro", EntradaDinheiro.ToString("C")));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pix", EntradaPIX.ToString("C")));


                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("total", Entradas.ToString("C")));
            }
            else
            {
                this.tb_caixaTableAdapter.FillByMensalidadesCurso(this.dbatenienseDataSet.tb_caixa, Convert.ToInt32(Globais.Main.PassarMes), Convert.ToInt32(Globais.Main.PassarAno),Globais.Main.PassarCurso);

                DateTime Mes = Convert.ToDateTime(Globais.Main.PassarAno + "-12-01");
                Mes = Mes.AddMonths((Convert.ToInt32(Globais.Main.PassarMes)));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("mes", Mes.ToString("MMMM").ToUpper()));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("ano_letivo", Globais.Main.PassarAno));


                //Entrada Crédito
                var vconn = Banco.ConexaoBanco();
                string EntradaTotalCredito = String.Format(@"
                SELECT IFNULL(SUM(valor_total),0) as total  
                FROM tb_caixa
                WHERE forma = 'CRÉDITO'
                AND MONTH(data) ={0} AND YEAR(data) ={1} AND descricao = 'Mensalidade Curso' AND curso ='{2}'", Globais.Main.PassarMes, Globais.Main.PassarAno,Globais.Main.PassarCurso);
                DataTable Credito = Banco.dql(EntradaTotalCredito);
                vconn.Close();

                //Entrada Débito
                vconn = Banco.ConexaoBanco();
                string EntradaTotalDebito = String.Format(@"
                SELECT IFNULL(SUM(valor_total),0) as total 
                FROM tb_caixa
                WHERE forma = 'DÉBITO'
                AND MONTH(data) ={0} AND YEAR(data) ={1} AND descricao = 'Mensalidade Curso' AND curso ='{2}'", Globais.Main.PassarMes, Globais.Main.PassarAno, Globais.Main.PassarCurso);
                DataTable Debito = Banco.dql(EntradaTotalDebito);
                vconn.Close();

                //Entrada Dinheiro
                vconn = Banco.ConexaoBanco();
                string EntradaTotalDinheiro = String.Format(@"
                SELECT IFNULL(SUM(valor_total),0) as total  
                FROM tb_caixa
                WHERE forma = 'DINHEIRO'
                AND MONTH(data) ={0} AND YEAR(data) ={1} AND descricao = 'Mensalidade Curso' AND curso ='{2}'", Globais.Main.PassarMes, Globais.Main.PassarAno, Globais.Main.PassarCurso);
                DataTable dinheiro = Banco.dql(EntradaTotalDinheiro);
                vconn.Close();
                //Entrada PIX
                vconn = Banco.ConexaoBanco();
                string EntradaTotalPIX = String.Format(@"
                SELECT IFNULL(SUM(valor_total),0) as total  
                FROM tb_caixa
                WHERE forma = 'PIX'
                AND MONTH(data) ={0} AND YEAR(data) ={1} AND descricao = 'Mensalidade Curso' AND curso ='{2}'", Globais.Main.PassarMes, Globais.Main.PassarAno, Globais.Main.PassarCurso);
                DataTable pix = Banco.dql(EntradaTotalPIX);
                vconn.Close();

                vconn = Banco.ConexaoBanco();
                string SubtotalDiaEntradas = String.Format(@"
                SELECT IFNULL(SUM(valor_total),0) as total  
                FROM tb_caixa
                WHERE descricao = 'Mensalidade Curso'
                AND MONTH(data) ={0} AND YEAR(data) ={1} AND curso ='{2}'", Globais.Main.PassarMes, Globais.Main.PassarAno, Globais.Main.PassarCurso);
                DataTable subtotalEntradas = Banco.dql(SubtotalDiaEntradas);
                vconn.Close();

                //Entradas

                decimal EntradaCredito = Credito.Rows[0].Field<decimal>("total");
                decimal EntradaDebito = Debito.Rows[0].Field<decimal>("total");
                decimal EntradaDinheiro = dinheiro.Rows[0].Field<decimal>("total");
                decimal EntradaPIX = pix.Rows[0].Field<decimal>("total");
                decimal Entradas = subtotalEntradas.Rows[0].Field<decimal>("total");

                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("credito", EntradaCredito.ToString("C")));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("debito", EntradaDebito.ToString("C")));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dinheiro", EntradaDinheiro.ToString("C")));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pix", EntradaPIX.ToString("C")));


                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("total", Entradas.ToString("C")));
            }


            Globais.Main.Modo = "";
            Globais.Main.PassarCurso = "";
            this.reportViewer1.RefreshReport();
        }
    }
}
