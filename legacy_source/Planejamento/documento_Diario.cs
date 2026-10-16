using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Diario
{
    public partial class documento_Diario : Form
    {
        public documento_Diario()
        {
            InitializeComponent();
        }

        private void documento_Diario_Load(object sender, EventArgs e)
        {


            string vqueryCampos = String.Format(@"
            SELECT
            nome_professor,
            comp_curricular,
            data_diario,
            serie,
            atividades_percepcao,
            objetivos,
            conteudos,
            desenvolvimento,
            atividade_sala,
            atividade_casa,
            recursos,
            avaliacao
            FROM
            tb_diario
            WHERE ID_diario={0}", Globais.Main.PassarIDDiario);

            DataTable dt = Banco.dql(vqueryCampos);
            string professor = dt.Rows[0].Field<string>("nome_professor");
            string comp_curricular = dt.Rows[0].Field<string>("comp_curricular");
            string data_diario = dt.Rows[0].Field<DateTime>("data_diario").ToString("dd/MM/yyyy");
            string etapa = dt.Rows[0].Field<string>("serie");
            string atividades_percepcao = dt.Rows[0].Field<string>("atividades_percepcao");
            string objetivos = dt.Rows[0].Field<string>("objetivos");
            string conteudos = dt.Rows[0].Field<string>("conteudos");
            string desenvolvimento = dt.Rows[0].Field<string>("desenvolvimento");
            string atividade_sala = dt.Rows[0].Field<string>("atividade_sala");
            string atividade_casa = dt.Rows[0].Field<string>("atividade_casa");
            string recursos = dt.Rows[0].Field<string>("recursos");
            string avaliacao = dt.Rows[0].Field<string>("avaliacao");


            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("professor", professor));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("comp_curricular", comp_curricular));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("data_diario", data_diario));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("serie", etapa));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("atividades_percepcao", atividades_percepcao));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("objetivos", objetivos));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("conteudos", conteudos));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("desenvolvimento", desenvolvimento));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("atividade_sala", atividade_sala));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("atividade_casa", atividade_casa));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("recursos", recursos));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("avaliacao", avaliacao));


            this.reportViewer1.RefreshReport();

        }

        private string SubstituirPontoVirgulaPorQuebraDeLinha(string input)
        {
            return input.Replace(";", Environment.NewLine);
        }
    }
}
