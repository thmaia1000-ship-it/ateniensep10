using CrystalDecisions.CrystalReports.Engine;
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
    public partial class Declaracao_RecisaoContrato : Form
    {
        public Declaracao_RecisaoContrato()
        {
            InitializeComponent();
        }


        public static string DataPorExtenso(DateTime data)
        {
            string[] meses = { "janeiro", "fevereiro", "março", "abril", "maio", "junho",
                       "julho", "agosto", "setembro", "outubro", "novembro", "dezembro" };

            return $"{data.Day} de {meses[data.Month - 1]} de {data.Year}";
        }

        private async void Declaracao_RecisaoContrato_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.Tag as string == "carregando") return;
                this.Tag = "carregando";

                string idMensalidade = Globais.Main.PassarID_Mensalidade;

                DataTable aluno = null;

                await Task.Run(() =>
                {
                    using (var vcon = Banco.ConexaoBanco())
                    {
                        string sql = String.Format(@"
                    SELECT 
                        tbm.data_gerada,
                        tba.nome_aluno,
                        tbe.nome_etapa,
                        tbm.turno,
                        tbm.ano_letivo
                    FROM tb_mensalidades as tbm
                        INNER JOIN tb_alunos as tba ON tba.ID_aluno = tbm.idaluno
                        INNER JOIN tb_etapas as tbe ON tbe.ID_etapa = tbm.idturma
                    WHERE tbm.ID_mensalidade = {0}
                ", idMensalidade);

                        aluno = Banco.dql(sql);
                    }
                });

                if (aluno == null || aluno.Rows.Count == 0)
                {
                    MessageBox.Show("Nenhum dado encontrado.");
                    return;
                }

                string nome_aluno = aluno.Rows[0].Field<string>("nome_aluno");
                string turno = aluno.Rows[0].Field<string>("turno");
                string turma = aluno.Rows[0].Field<string>("nome_etapa");
                string ano_letivo = aluno.Rows[0].Field<Int32>("ano_letivo").ToString();
                string data_contrato = DataPorExtenso(aluno.Rows[0].Field<DateTime>("data_gerada"));


                RecisaoContrato1.SetParameterValue("nome_aluno", nome_aluno);
                RecisaoContrato1.SetParameterValue("data_contrato", data_contrato);
                RecisaoContrato1.SetParameterValue("turma", turma);
                RecisaoContrato1.SetParameterValue("turno", turno);
                RecisaoContrato1.SetParameterValue("ano_letivo", ano_letivo);


                crystalReportViewer1.ReportSource = RecisaoContrato1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar relatório:\n\n" +
                    ex.Message +
                    "\n\nStackTrace:\n" +
                    ex.StackTrace +
                    "\n\nInnerException:\n" +
                    ex.InnerException?.Message
                );
            }
            finally
            {
                this.Tag = null;
            }
        }

        // Libera o relatório ao fechar o form
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            try
            {
                if (crystalReportViewer1.ReportSource is ReportDocument rpt)
                {
                    rpt.Close();
                    rpt.Dispose();
                }
                crystalReportViewer1.ReportSource = null;
            }
            catch { }
            base.OnFormClosed(e);
        }
    }
}
