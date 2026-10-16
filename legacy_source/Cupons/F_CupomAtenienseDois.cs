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
    public partial class F_ReciboAtenienseDois : Form
    {
        public F_ReciboAtenienseDois()
        {
            InitializeComponent();
        }

        string Etapa = "";
        string Turno = "";
        string ano_letivo = "";
        string Nome_Responsavel = "";

        private void F_ReciboAteniense_Load(object sender, EventArgs e)
        {
            if (Globais.Main.PassarData == "" && Globais.Main.PassarHorario == "")
            {
                string Data = DateTime.Now.ToString("dd/MM/yyyy");
                string Hora = DateTime.Now.ToString("HH:mm");
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("data", Data + " " + Hora));

            }
            else
            {
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("data", Globais.Main.PassarData + " " + Globais.Main.PassarHorario));
            }

            var vcon = Banco.ConexaoBanco();
            

            if (Globais.Main.PassarDesc == "Mensalidade")
            {
                string Serie = String.Format(@"
                SELECT 
                tbe.nome_etapa,
                tbm.turno,
                tbm.ano_letivo,
                tbm.idresponsavel
                FROM tb_mensalidades as tbm
                INNER JOIN tb_etapas as tbe
                ON tbe.ID_etapa = tbm.idturma  
                WHERE tbm.ID_mensalidade ={0}", Globais.Main.PassarID_Mensalidade);
                DataTable serie = Banco.dql(Serie);
                vcon.Close();

                if (serie.Rows.Count > 0)
                {
                    Etapa = serie.Rows[0].Field<string>("nome_etapa");
                    Turno = serie.Rows[0].Field<string>("turno");
                    ano_letivo = serie.Rows[0].Field<Int32>("ano_letivo").ToString();
                    int idResp = serie.Rows[0].Field<Int32>("idresponsavel");

                    string Responsavel = String.Format(@"
                    SELECT nome FROM tb_responsavel_financeiro
                    WHERE ID_responsavel_financeiro =" + idResp);

                    DataTable respFinan = Banco.dql(Responsavel);
                    vcon.Close();

                    Nome_Responsavel = respFinan.Rows[0].Field<string>("nome");

                }

            }
            else if (Globais.Main.PassarDesc == "Mensalidade Curso")
            {
                string Serie = String.Format(@"
                SELECT 
                tbe.nome_etapa,
                tbm.turno,
                tbm.ano_letivo,
                 tbm.idresponsavel
                FROM tb_mensalidades_cursos as tbm
                INNER JOIN tb_etapas as tbe
                ON tbe.ID_etapa = tbm.idturma  
                WHERE tbm.ID_mensalidade_curso={0}", Globais.Main.PassarID_Mensalidade);
                DataTable serie = Banco.dql(Serie);
                vcon.Close();

                if (serie.Rows.Count > 0)
                {
                    Etapa = serie.Rows[0].Field<string>("nome_etapa");
                    Turno = serie.Rows[0].Field<string>("turno");
                    ano_letivo = serie.Rows[0].Field<Int32>("ano_letivo").ToString();
                    int idResp = serie.Rows[0].Field<Int32>("idresponsavel");

                    string Responsavel = String.Format(@"
                    SELECT nome FROM tb_responsavel_financeiro
                    WHERE ID_responsavel_financeiro =" + idResp);

                    DataTable respFinan = Banco.dql(Responsavel);
                    vcon.Close();

                    Nome_Responsavel = respFinan.Rows[0].Field<string>("nome");
                }
            }
            else
            {

                string ID_aluno = String.Format(@"SELECT idaluno FROM tb_caixa WHERE ID_caixa={0}", Globais.Main.PassarIdCaixa);
                DataTable ID_Aluno = Banco.dql(ID_aluno);

                int idaluno = ID_Aluno.Rows[0].Field<Int32>("idaluno");

                string Nome_Turma = String.Format(@"SELECT etapa,turno,ano_letivo FROM tb_alunos WHERE ID_aluno={0}", idaluno);
                DataTable Nome_turma = Banco.dql(Nome_Turma);

                Etapa = Nome_turma.Rows[0].Field<string>("etapa");
                Turno = Nome_turma.Rows[0].Field<string>("turno");
                ano_letivo = Nome_turma.Rows[0].Field<Int32>("ano_letivo").ToString();

            }

            int max_parcelas, parcelas_pagas;
            DateTime DataInicio;

            if (Globais.Main.Modo != "2")
            {
                vcon = Banco.ConexaoBanco();
                string parcelas = String.Format(@"
                SELECT parcelas_pagas, n_parcelas,data_inicio FROM tb_mensalidades WHERE ID_mensalidade={0}", Globais.Main.PassarID_Mensalidade);

                    DataTable parcela = Banco.dql(parcelas);
                vcon.Close();

                max_parcelas = parcela.Rows[0].Field<Int32>("n_parcelas");
                parcelas_pagas = parcela.Rows[0].Field<Int32>("parcelas_pagas");
                DataInicio = parcela.Rows[0].Field<DateTime>("data_inicio");
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("mensalidade", "Mensalidade"));
            }
            else
            {
                vcon = Banco.ConexaoBanco();
                string parcelas = String.Format(@"
                SELECT parcelas_pagas, n_parcelas,data_inicio,curso FROM tb_mensalidades_cursos WHERE idaluno= {0} AND ID_mensalidade_curso={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarID_Mensalidade);

                DataTable parcela = Banco.dql(parcelas);
                vcon.Close();

                max_parcelas = parcela.Rows[0].Field<Int32>("n_parcelas");
                parcelas_pagas = parcela.Rows[0].Field<Int32>("parcelas_pagas");
                DataInicio = parcela.Rows[0].Field<DateTime>("data_inicio");

                int ID_curso = parcela.Rows[0].Field<Int32>("curso");

                string Nome_curso = String.Format(@"SELECT nome_curso FROM tb_cursos WHERE ID_curso={0}", ID_curso);
                DataTable nome_curso = Banco.dql(Nome_curso);

                string Curso = nome_curso.Rows[0].Field<string>("nome_curso").ToUpper();
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("mensalidade", Curso));
                Globais.Main.Modo = "";
            }


            if (Globais.Main.PassarMensalidades_paga == "")
            {
               string DataInicioo = DataInicio.AddMonths(parcelas_pagas).ToString("MMM");

                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("parcelas_pagas", DataInicioo));
            }
            else 
            { 
                DataInicio = DataInicio.AddMonths(Convert.ToInt32(Globais.Main.PassarMensalidades_paga));
                string MesParcelas = DataInicio.AddMonths(-1).ToString("MMM");

                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("parcelas_pagas", MesParcelas));
            }

            if (Globais.Main.PassarForma1 != "" && Globais.Main.PassarForma2 != "")
            {
                string forma_pagamento = Globais.Main.PassarForma1 + "/" + Globais.Main.PassarForma2;

                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pagamento", forma_pagamento));
            }
            else
            {
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pagamento", Globais.Main.PassarForma.ToUpper()));
            }

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("nome_aluno", Globais.Main.PassarAluno.ToUpper()));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("responsavel_financeiro", Nome_Responsavel.ToUpper()));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("atendente", Globais.Main.PassarUsuario.ToUpper()));
            
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("max_parcelas", max_parcelas.ToString()));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("codigo", Globais.Main.PassarIdCaixa));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("recibo", decimal.Parse(Globais.Main.PassarCaixa.Replace(".", ",")).ToString("C")));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("etapa", Etapa.ToUpper()));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("turno", Turno.ToUpper()));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("ano_letivo", ano_letivo));

            Globais.Main.PassarMensalidades_paga = "";
            this.reportViewer1.RefreshReport();
        }
    }
}
