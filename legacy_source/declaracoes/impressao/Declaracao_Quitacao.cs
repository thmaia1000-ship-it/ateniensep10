using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.declaracoes
{
    public partial class Declaracao_Quitacao : Form
    {
        public Declaracao_Quitacao()
        {
            InitializeComponent();
        }

        private void Declaracao_Quitacao_Load(object sender, EventArgs e)
        {

            this.tb_caixa2TableAdapter.Fill(
     this.dbatenienseDataSet.tb_caixa2,
     int.Parse(Globais.Main.PassarIdAluno),   // @idaluno
     Convert.ToInt32(Globais.Main.PassarAno)            // @ano_letivo
 );


            string Meses = String.Format(@"
            SELECT DATE_ADD(data_inicio, INTERVAL (parcelas_pagas - 1) MONTH) AS data_futura,
            data_inicio,
            n_parcelas,
            parcelas_pagas,
            idturma,
            ano_letivo,
            turno,
            idresponsavel
            FROM tb_mensalidades
            WHERE ID_mensalidade ={0}", Globais.Main.PassarID_Mensalidade);
            DataTable meses = Banco.dql(Meses);

            string Mes_Inicio = meses.Rows[0].Field<DateTime>("data_inicio").ToString("MMMM").ToUpper();
            string Mes_Fim = meses.Rows[0].Field<DateTime>("data_futura").ToString("MMMM").ToUpper();
            int n_parcelas = meses.Rows[0].Field<Int32>("n_parcelas");
            int parcelas_pagas = meses.Rows[0].Field<Int32>("parcelas_pagas");
            int idetapa = meses.Rows[0].Field<Int32>("idturma");
            int idresponsavel = meses.Rows[0].Field<Int32>("idresponsavel");
            string Ano_Letivo = meses.Rows[0].Field<Int32>("ano_letivo").ToString();
            string Turno = meses.Rows[0].Field<string>("turno");

            var vconn = Banco.ConexaoBanco();
            string Aluno = String.Format(@"
            SELECT 
            tba.nome_aluno,
            tba.pai,
            tba.mae,
            tba.datanasc,
            tba.cidade,
            tba.UF,
            tba.ano_letivo,
            tba.etapa,
            tba.turno,
            tbf.nome
            FROM tb_alunos as tba
            INNER JOIN tb_responsavel_financeiro as tbf
            ON tbf.ID_responsavel_financeiro = {0}
            WHERE tba.ID_aluno= {1}", idresponsavel, Globais.Main.PassarIdAluno);
            DataTable aluno = Banco.dql(Aluno);
            vconn.Close();

            string Nome_aluno = aluno.Rows[0].Field<string>("nome_aluno");
            string resp_financeiro = aluno.Rows[0].Field<string>("nome");
            string Pai = aluno.Rows[0].Field<string>("pai");
            string Mae = aluno.Rows[0].Field<string>("mae");
            string Data_Nascimento = aluno.Rows[0].Field<DateTime>("datanasc").ToString("dd/MM/yyyy");
            string Cidade = aluno.Rows[0].Field<string>("cidade").ToUpper();
            string UF = aluno.Rows[0].Field<string>("UF");
            string serie = aluno.Rows[0].Field<string>("etapa");



            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("nome_aluno", Nome_aluno));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pai", Pai));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("resp_financeiro", resp_financeiro));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("mae", Mae));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("data_nascimento", Data_Nascimento));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("cidade", Cidade));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("UF", UF));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("variavel1", Globais.Main.Estuda));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("variavel2", Globais.Main.Cursa));



            string Nome_Etapa = String.Format(@"
            SELECT 
            nome_etapa
            FROM tb_etapas
            WHERE ID_etapa ={0}", idetapa);
            DataTable etapa = Banco.dql(Nome_Etapa);


            string nome_etapa = etapa.Rows[0].Field<string>("nome_etapa");

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("etapa", nome_etapa));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("turno", Turno));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("mes_inicio", Mes_Inicio));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("mes_fim", Mes_Fim));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("ano_letivo", Ano_Letivo));

            int quantidade_parcelas = n_parcelas - parcelas_pagas;

            if (quantidade_parcelas > 0)
            {
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("contrato", "Em Andamento"));
            }
            else
            {
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("contrato", "Quitado"));
            }

            string Valores = String.Format(@"
            SELECT 
            valor_parcela
            FROM tb_mensalidades
            WHERE ID_mensalidade ={0}", Globais.Main.PassarID_Mensalidade);
            DataTable valores = Banco.dql(Valores);

            //Entrada PIX
            vconn = Banco.ConexaoBanco();
            string EntradaTotal = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_caixa
            WHERE idaluno={0} AND idmensalidade={1} AND descricao ='Mensalidade'", Globais.Main.PassarIdAluno, Globais.Main.PassarID_Mensalidade);
            DataTable total = Banco.dql(EntradaTotal);
            vconn.Close();

            string Valor_Mensal = valores.Rows[0].Field<decimal>("valor_parcela").ToString("C");
            string Valor_Total = total.Rows[0].Field<decimal>("total").ToString("C");

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pagamento_mensal", Valor_Mensal));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pagamento_anual", Valor_Total));

            string Dia_Hoje = DateTime.Now.ToString("dd");
            string Mes_Hoje = DateTime.Now.ToString("MMMM");
            string Ano_Hoje = DateTime.Now.ToString("yyyy");

            string Data_Hoje = "Manaus " + Dia_Hoje + " de " + Mes_Hoje.ToUpper() + " de " + Ano_Hoje;

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("data_hoje", Data_Hoje));

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

            this.reportViewer1.RefreshReport();
        }
    }
}