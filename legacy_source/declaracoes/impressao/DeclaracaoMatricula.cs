using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Academico
{
    public partial class DeclaracaoMatricula : Form
    {
        public DeclaracaoMatricula()
        {
            InitializeComponent();
        }

        private void DeclaracaoMatricula_Load(object sender, EventArgs e)
        {
            string DiaHoje = DateTime.Now.ToString("dd");
            string MesHoje = DateTime.Now.ToString("MMMM");
            string AnoHoje = DateTime.Now.ToString("yyyy");
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("data", "Manaus " +DiaHoje+ " de " +MesHoje+ " de " + AnoHoje ));


            var vconn = Banco.ConexaoBanco();
            string Aluno = String.Format(@"
            SELECT 
            nome_aluno,
            pai,
            mae,
            datanasc,
            cidade,
            UF,
            etapa,
            turno
            FROM tb_alunos
            WHERE ID_aluno ={0}", Globais.Main.PassarIdAluno);
            DataTable dadosAluno = Banco.dql(Aluno);
            vconn.Close();

            string nome_aluno = dadosAluno.Rows[0].Field<string>("nome_aluno");
            string pai = dadosAluno.Rows[0].Field<string>("pai");
            string mae = dadosAluno.Rows[0].Field<string>("mae");
            string cidade = dadosAluno.Rows[0].Field<string>("cidade");
            string UF = dadosAluno.Rows[0].Field<string>("UF");
            string etapa = dadosAluno.Rows[0].Field<string>("etapa");
            string turno = dadosAluno.Rows[0].Field<string>("turno");
            string data_nascimento = dadosAluno.Rows[0].Field<DateTime>("datanasc").ToString("dd/MM/yyyy");

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("nome_aluno", nome_aluno));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pai", pai));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("mae", mae));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("cidade", cidade));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("UF", UF));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("etapa", etapa));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("turno", turno));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("variavel1", Globais.Main.Estuda));

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("data_nascimento", data_nascimento));

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

            if (turno == "MATUTINO")
            {
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("horario", "07:00h às 11:00h"));
            }
            else if (turno == "VESPERTINO")
            {
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("horario", "13:00h às 17:00h"));
            }
            else if (turno == "INTEGRAL")
            {
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("horario", "07:00h às 17:00h"));
            }
            else if (turno == "MATUTINO M. PERIODO")
            {
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("horario", "07:00h às 13:00h"));
            }
            else if (turno == "VESPERTINO M. PERIODO")
            {
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("horario", "11:00h às 17:00h"));
            }

            this.reportViewer1.RefreshReport();
        }
    }
}
