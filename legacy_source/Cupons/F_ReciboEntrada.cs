using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Caixa
{
    public partial class F_ReciboEntrada : Form
    {
        public F_ReciboEntrada()
        {
            InitializeComponent();
        }

        private void F_ReciboEntrada_Load(object sender, EventArgs e)
        {
            if (Globais.Main.Modo == "0")
            {
                string Data = DateTime.Now.ToString("dd/MM/yyyy");
                string Hora = DateTime.Now.ToString("HH:mm");
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("data", Data + " " + Hora));

                var vcon = Banco.ConexaoBanco();
                string Responsavel = String.Format(@"
            SELECT nome FROM tb_responsavel_financeiro
            WHERE idaluno =" + Globais.Main.PassarIdAluno);

                DataTable respFinan = Banco.dql(Responsavel);
                vcon.Close();

                string Nome_Responsavel = respFinan.Rows[0].Field<string>("nome");

                vcon = Banco.ConexaoBanco();
                string parcelas = String.Format(@"
                SELECT parcelas_pagas, n_parcelas FROM tb_mensalidades
                WHERE idaluno =" + Globais.Main.PassarIdAluno);

                DataTable parcela = Banco.dql(parcelas);
                vcon.Close();

                string max_parcelas = parcela.Rows[0].Field<string>("n_parcelas");
                string parcelas_pagas = parcela.Rows[0].Field<string>("parcelas_pagas");

                string CodigoVenda = String.Format(@"SELECT IFNULL (MAX(ID_caixa),0) as codigo FROM tb_caixa");

                DataTable Codigovenda = Banco.dql(CodigoVenda);

                string Codigo = Codigovenda.Rows[0].Field<Int64>("codigo").ToString();

                if (Globais.Main.PassarForma1 != "" && Globais.Main.PassarForma2 != "")
                {
                    string forma_pagamento = Globais.Main.PassarForma1 + "/" + Globais.Main.PassarForma2;

                    this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pagamento", forma_pagamento));
                }
                else
                {
                    this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pagamento", Globais.Main.PassarForma1.ToUpper()));
                }

                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("nome_aluno", Globais.Main.PassarAluno.ToUpper()));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("responsavel_financeiro", Nome_Responsavel.ToUpper()));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("atendente", Globais.Main.PassarUsuario.ToUpper()));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("descricao", Globais.Main.PassarDesc));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("codigo", Codigo));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("recibo", decimal.Parse(Globais.Main.PassarCaixa.Replace(".", ",")).ToString("C")));

                this.reportViewer1.RefreshReport();
            }
            else
            {

                var vcon = Banco.ConexaoBanco();
                string curso = String.Format(@"
                SELECT 
                ID_caixa,
                nome,
                valor_total,
                usuario,
                data,
                horario,
                forma,
                descricao,
                idaluno
                FROM tb_caixa WHERE ID_caixa= " + Globais.Main.PassarIdCaixa);

                DataTable dt = Banco.dql(curso);
                vcon.Close();

                Globais.Main.PassarForma1 = "";
                Globais.Main.PassarForma2 = "";

                string Nome_Aluno = dt.Rows[0].Field<string>("nome");
                Globais.Main.PassarCaixa = dt.Rows[0].Field<decimal>("valor_total").ToString("C");
                string usuario = dt.Rows[0].Field<string>("usuario");
                string descricao = dt.Rows[0].Field<string>("descricao");
                Globais.Main.PassarForma = dt.Rows[0].Field<string>("forma");
                string ID_ALUNO = dt.Rows[0].Field<Int32>("idaluno").ToString();
                string Data = dt.Rows[0].Field<DateTime>("data").ToString("dd/MM/yyyy");
                string ID_Caixa = dt.Rows[0].Field<Int32>("ID_caixa").ToString();

                string VerificarDuasFormas = String.Format(@"
                            SELECT
                            ID_caixa,
                            valor_total,
                            descricao,
                            forma,
                            nome,
                            usuario,
                            data,
                            horario
                            FROM tb_caixa
                            WHERE ID_caixa={0}", Convert.ToInt32(Globais.Main.PassarIdCaixa) + 1);
                DataTable verificarduasFormas = Banco.dql(VerificarDuasFormas);
                if (verificarduasFormas.Rows.Count > 0)
                {
                    if (verificarduasFormas.Rows[0].Field<DateTime>("data").ToString() == dt.Rows[0].Field<DateTime>("data").ToString() && verificarduasFormas.Rows[0].Field<string>("horario") == dt.Rows[0].Field<string>("horario"))
                    {
                        Globais.Main.PassarForma = "";
                        Globais.Main.PassarForma1 = dt.Rows[0].Field<string>("forma");
                        Globais.Main.PassarForma2 = verificarduasFormas.Rows[0].Field<string>("forma");
                        decimal Valor1 = dt.Rows[0].Field<decimal>("valor_total");
                        decimal Valor2 = verificarduasFormas.Rows[0].Field<decimal>("valor_total");
                        decimal ValorTotal = Valor1 + Valor2;
                        Globais.Main.PassarCaixa = ValorTotal.ToString();
                    }
                }
                string Responsavel = String.Format(@"SELECT nome FROM tb_responsavel_financeiro WHERE idaluno ={0}", ID_ALUNO);
                DataTable resp = Banco.dql(Responsavel);

                string Nome_Responsavel = resp.Rows[0].Field<string>("nome");

                if (Globais.Main.PassarForma1 != "" && Globais.Main.PassarForma2 != "")
                {
                    string forma_pagamento = Globais.Main.PassarForma1 + "/" + Globais.Main.PassarForma2;

                    this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pagamento", forma_pagamento));
                }
                else
                {
                    this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pagamento", Globais.Main.PassarForma1.ToUpper()));
                }

                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("nome_aluno", Nome_Aluno));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("responsavel_financeiro", Nome_Responsavel));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("codigo", ID_Caixa));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("atendente", usuario));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("descricao", descricao));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("data", Data));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("recibo", Globais.Main.PassarCaixa));

                Globais.Main.PassarForma1 = "";
                Globais.Main.PassarForma2 = "";

                this.reportViewer1.RefreshReport();
            }
        }
    }
}
