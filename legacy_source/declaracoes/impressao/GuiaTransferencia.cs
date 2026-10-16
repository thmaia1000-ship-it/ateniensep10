using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
namespace Escolar.declaracoes.impressao
{
    public partial class GuiaTransferencia : Form
    {
        public GuiaTransferencia()
        {
            InitializeComponent();
        }

        private bool VerificarBimestres = false;
        private void MediaNotas()
        {
            double[] VetorTotais = new double[8];
            int[] VetorIDs = { 153, 154, 155, 156, 157, 158, 159, 160 };

            for (int i = 0; i < VetorIDs.Length; i++)
            {
                double somaNotas = 0;
                int quantidadeNotas = 0;

                string query = $@"
                  SELECT nota
                  FROM tb_notas
                  WHERE idaluno = {Globais.Main.PassarIdAluno}
                  AND idetapa = 4
                  AND idmateria = {VetorIDs[i]}";

                DataTable notas = Banco.dql(query);

                foreach (DataRow linha in notas.Rows)
                {
                    if (double.TryParse(linha["nota"].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out double valorNota))
                    {
                        somaNotas += valorNota;
                        quantidadeNotas++;
                    }
                }

                if (quantidadeNotas > 0)
                {
                    VetorTotais[i] = somaNotas / quantidadeNotas;
                    if (quantidadeNotas == 4)
                    {
                        VerificarBimestres = true;
                    }
                }
                else
                {
                    VetorTotais[i] = 0;
                }

            }

            if (VerificarBimestres)
            {
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("notaPortugues", VetorTotais[0].ToString("F1")));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("notaHistoria", VetorTotais[1].ToString("F1")));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("notaGeografia", VetorTotais[2].ToString("F1")));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("notaCiencias", VetorTotais[3].ToString("F1")));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("notaMatematica", VetorTotais[4].ToString("F1")));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("notaArtes", VetorTotais[5].ToString("F1")));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("notaEdFisica", VetorTotais[6].ToString("F1")));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("notaLingEstrangeira", VetorTotais[7].ToString("F1")));

                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("rf_1", "C"));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("rf_2", "U"));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("rf_3", "R"));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("rf_4", "S"));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("rf_5", "O"));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("rf_6", "U"));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("rf_7", ""));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("rf_8", ""));

                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("status", "APTO para cursar o 2º ANO"));
            }
            else
            {
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("notaPortugues", "C"));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("notaHistoria", "U"));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("notaGeografia", "R"));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("notaCiencias", "S"));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("notaMatematica", "A"));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("notaArtes", "N"));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("notaEdFisica", "D"));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("notaLingEstrangeira", "O"));

                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("rf_1", "C"));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("rf_2", "U"));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("rf_3", "R"));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("rf_4", "S"));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("rf_5", "A"));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("rf_6", "N"));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("rf_7", "D"));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("rf_8", "O"));

                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("status", "CURSANDO o 1º ANO"));
            }
        }

        private void GuiaTransferencia_Load(object sender, EventArgs e)
        {
            //Informações do Aluno

            string Aluno = String.Format($@"
            SELECT 
            nome_aluno,
            datanasc,
            cidade,
            uf,
            ano_letivo
            FROM tb_alunos
            WHERE ID_aluno= {Globais.Main.PassarIdAluno}");
            DataTable aluno = Banco.dql(Aluno);

            string Nome_aluno = aluno.Rows[0].Field<string>("nome_aluno");
            string dataNasc = aluno.Rows[0].Field<DateTime>("datanasc").ToString("dd' de 'MMMM' de 'yyyy");
            string cidade = aluno.Rows[0].Field<string>("cidade");
            string UF = aluno.Rows[0].Field<string>("uf");
            int ano_letivo = aluno.Rows[0].Field<Int32>("ano_letivo");
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("nome_aluno", Nome_aluno));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("data_nascimento", dataNasc));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("cidade", cidade));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("uf", UF));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("ano_letivo", ano_letivo.ToString()));

            MediaNotas();

            string data_atual = DateTime.Now.ToString("dd' de 'MMMM' de 'yyyy");
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("data_atual", data_atual));

            this.reportViewer1.RefreshReport();

            Transferencia transferencia = new Transferencia();
            transferencia.ShowDialog();


            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("data_cursou", Globais.Main.PassarData));

            this.reportViewer1.RefreshReport();

            Globais.Main.PassarIdAluno = "";
            Globais.Main.PassarData = "";
        }
    }
}
