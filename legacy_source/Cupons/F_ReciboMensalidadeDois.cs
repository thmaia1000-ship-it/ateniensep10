using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Cupons
{
    public partial class F_ReciboMensalidadeDois : Form
    {
        public F_ReciboMensalidadeDois()
        {
            InitializeComponent();
        }

        string Etapa = "";
        string Turno = "";
        string AnoLetivo = "";
        string NomeResponsavel = "";

        private void F_ReciboMensalidadeDois_Load(object sender, EventArgs e)
        {

            CarregarDataCabecalho();
            CarregarDadosAlunoOuMensalidade();
            CarregarParcelas();
            CarregarFormasPagamento();
            CarregarParametrosFinais();
        }
        private void CarregarDataCabecalho()
        {
            string data = $"MANAUS, {DateTime.Now:dd} DE {DateTime.Now:MMMM} DE {DateTime.Now:yyyy} ÀS {DateTime.Now:HH:mm}";
            reportViewer1.LocalReport.SetParameters(
                new Microsoft.Reporting.WinForms.ReportParameter("data", data)
            );
        }

        private void CarregarDadosAlunoOuMensalidade()
        {
            if (Globais.Main.PassarDesc == "Mensalidade")
                CarregarMensalidadeNormal();
            else if (Globais.Main.PassarDesc == "Mensalidade Curso")
                CarregarMensalidadeCurso();
            else
                CarregarDadosCaixa();
        }

        private void CarregarMensalidadeNormal()
        {
            string sql = $@"
                SELECT tbe.nome_etapa, tbm.ano_letivo, tbm.idresponsavel
                FROM tb_mensalidades tbm
                INNER JOIN tb_etapas tbe ON tbe.ID_etapa = tbm.idturma  
                WHERE tbm.ID_mensalidade = {Globais.Main.PassarID_Mensalidade}";


            DataTable tabela = Banco.dql(sql);
            if (tabela.Rows.Count == 0) return;

            Etapa = tabela.Rows[0].Field<string>("nome_etapa");
            AnoLetivo = tabela.Rows[0].Field<int>("ano_letivo").ToString();
            NomeResponsavel = BuscarResponsavel(tabela.Rows[0].Field<int>("idresponsavel"));
        }

        private void CarregarMensalidadeCurso()
        {
            string sql = $@"
                SELECT tbe.nome_etapa, tbm.turno, tbm.ano_letivo, tbm.idresponsavel
                FROM tb_mensalidades_cursos tbm
                INNER JOIN tb_etapas tbe ON tbe.ID_etapa = tbm.idturma  
                WHERE tbm.ID_mensalidade_curso = {Globais.Main.PassarID_Mensalidade}";

            DataTable tabela = Banco.dql(sql);
            if (tabela.Rows.Count == 0) return;

            Etapa = tabela.Rows[0].Field<string>("nome_etapa");
            Turno = tabela.Rows[0].Field<string>("turno");
            AnoLetivo = tabela.Rows[0].Field<int>("ano_letivo").ToString();
            NomeResponsavel = BuscarResponsavel(tabela.Rows[0].Field<int>("idresponsavel"));
        }

        private void CarregarDadosCaixa()
        {
            string sqlAluno = $"SELECT idaluno FROM tb_caixa WHERE ID_caixa = {Globais.Main.PassarIdCaixa}";
            int idAluno = Banco.dql(sqlAluno).Rows[0].Field<int>("idaluno");

            string sqlTurma = $"SELECT etapa, turno, ano_letivo FROM tb_alunos WHERE ID_aluno = {idAluno}";
            DataTable tabela = Banco.dql(sqlTurma);

            Etapa = tabela.Rows[0].Field<string>("etapa");
            Turno = tabela.Rows[0].Field<string>("turno");
            AnoLetivo = tabela.Rows[0].Field<int>("ano_letivo").ToString();
        }

        private string BuscarResponsavel(int id)
        {
            string sql = $"SELECT nome FROM tb_responsavel_financeiro WHERE ID_responsavel_financeiro = {id}";
            DataTable tabela = Banco.dql(sql);
            return tabela.Rows.Count > 0 ? tabela.Rows[0].Field<string>("nome") : "";
        }

        private void CarregarParcelas()
        {
            string sql;
            DataTable tabela;

            if (Globais.Main.Modo != "2")
            {
                sql = $@"
                    SELECT parcelas_pagas, n_parcelas, data_inicio 
                    FROM tb_mensalidades 
                    WHERE ID_mensalidade = {Globais.Main.PassarID_Mensalidade}";
            }
            else
            {
                sql = $@"
                    SELECT parcelas_pagas, n_parcelas, data_inicio, curso
                    FROM tb_mensalidades_cursos
                    WHERE ID_mensalidade_curso = {Globais.Main.PassarID_Mensalidade}";
            }

            tabela = Banco.dql(sql);

            int pagas = tabela.Rows[0].Field<int>("parcelas_pagas");
            DateTime inicio = tabela.Rows[0].Field<DateTime>("data_inicio");

            string[] meses =
            {
                "JANEIRO","FEVEREIRO","MARÇO","ABRIL","MAIO","JUNHO",
                "JULHO","AGOSTO","SETEMBRO","OUTUBRO","NOVEMBRO","DEZEMBRO"
            };

            if (Globais.Main.PassarMensalidades_paga == "")
            {
                string mes = meses[inicio.AddMonths(pagas).Month - 1];
                reportViewer1.LocalReport.SetParameters(
                    new Microsoft.Reporting.WinForms.ReportParameter("mes", mes)
                );
            }
            else
            {
                int alvo = int.Parse(Globais.Main.PassarMensalidades_paga);

                string mes = meses[inicio.AddMonths(alvo - 1).Month - 1];
                reportViewer1.LocalReport.SetParameters(
                    new Microsoft.Reporting.WinForms.ReportParameter("mes", mes)
                );
            }
        }

        private void CarregarFormasPagamento()
        {
            string f1 = "", f2 = "", f3 = "", f4 = "";

            if (!string.IsNullOrEmpty(Globais.Main.PassarForma1) &&
                !string.IsNullOrEmpty(Globais.Main.PassarForma2))
            {
                Globais.Main.PassarForma1.ToUpper();
                Globais.Main.PassarForma2.ToUpper();

                if (Globais.Main.PassarForma1 == "DINHEIRO" || Globais.Main.PassarForma2 == "DINHEIRO") f1 = "X";
                if (Globais.Main.PassarForma1 == "PIX" || Globais.Main.PassarForma2 == "PIX") f2 = "X";
                if (Globais.Main.PassarForma1 == "DÉBITO" || Globais.Main.PassarForma2 == "DÉBITO") f3 = "X";
                if (Globais.Main.PassarForma1 == "CRÉDITO" || Globais.Main.PassarForma2 == "CRÉDITO") f4 = "X";

                reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("f1", f1));
                reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("f2", f2));
                reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("f3", f3));
                reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("f4", f4));

            }
            else
            {

                if (Globais.Main.PassarForma == "DINHEIRO") f1 = "X";
                if (Globais.Main.PassarForma == "PIX") f2 = "X";
                if (Globais.Main.PassarForma == "DÉBITO") f3 = "X";
                if (Globais.Main.PassarForma == "CRÉDITO") f4 = "X";

                reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("f1", f1));
                reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("f2", f2));
                reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("f3", f3));
                reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("f4", f4));
            }
        }

        private void CarregarParametrosFinais()
        {
            reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("nome_aluno", Globais.Main.PassarAluno.ToUpper()));
            reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("responsavel", NomeResponsavel.ToUpper()));
            reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("codigo", Globais.Main.PassarIdCaixa));
            reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("recibo",
                decimal.Parse(Globais.Main.PassarCaixa.Replace(".", ",")).ToString("C")));

            if (Globais.Main.Modo != "2")
            {
                reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("serie", $"DO {Etapa.ToUpper()}"));
            }
            else
            {

                reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("serie", $"DO CURSO DE {Globais.Main.PassarNomeCurso.ToUpper()}"));
            }

            reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("valor_extenso", Conversor.EscreverExtenso(Decimal.Parse(Globais.Main.PassarCaixa))));


            Globais.Main.PassarMensalidades_paga = "";
            reportViewer1.RefreshReport();
        }
    }
}
