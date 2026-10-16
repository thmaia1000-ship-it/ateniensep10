using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.declaracoes.impressao
{
    public partial class declaracao_frequencia : Form
    {
        public declaracao_frequencia()
        {
            InitializeComponent();
        }

        private void declaracao_frequencia_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("nome_aluno", Globais.Main.PassarAluno));

            string Dia_Hoje = DateTime.Now.ToString("dd");
            string Mes_Hoje = DateTime.Now.ToString("MMMM");
            string Ano_Hoje = DateTime.Now.ToString("yyyy");

            string Data_Hoje = "Manaus " + Dia_Hoje + " de " + Mes_Hoje.ToUpper() + " de " + Ano_Hoje;

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("data", Data_Hoje));


            string dados = "", escola = "";

            /*if (serie != "1° ANO")
            {

                dados = @"                             Rua: Rosalind Franklin, Nº 25 – Parque 10 - CEP: 69.054-731
                             Resolução Nº 021 / 99 – CEE / AM - CNPJ: 35.062.987 / 0001 - 53
                             Email: ceateniensep10 @hotmail.com
                             Telefone: (92) 9 8450 - 3988";

                escola = "               ESCOLA INFANTIL ATENIENSE";
            }
            else
            {

                dados = @"                             Rua: Afonso Albuquerque ou Trav S3,nº 209- Japiim - CEP: 69.078-450 
                            Resolução Nº 021/99 – CEE/ AM - CNPJ: 63.671.366/0001-02
                            Email: ceateniense@hotmail.com
                            Telefone: (92) 9 8479-9171";

                escola = "               CENTRO EDUCACIONAL ATENIENSE";
            }*/

            dados = @"                             Rua: Rosalind Franklin, Nº 25 – Parque 10 - CEP: 69.054-731
                             Resolução Nº 021 / 99 – CEE / AM - CNPJ: 35.062.987 / 0001 - 53
                             Email: ceateniensep10 @hotmail.com
                             Telefone: (92) 9 8450 - 3988";

            escola = "               ESCOLA INFANTIL ATENIENSE";

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("nomeEscola", escola));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dadosEscola", dados));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("turma", Globais.Main.PassarEtapa));

            this.reportViewer1.RefreshReport();
        }
    }
}
