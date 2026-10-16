using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Escolar.Caixa
{
    public partial class F_CarneInterdigitus : Form
    {
        public F_CarneInterdigitus()
        {
            InitializeComponent();
        }

        private void F_CarneInterdigitus_Load(object sender, EventArgs e)
        {

            var vcon = Banco.ConexaoBanco();
            string parcelas = String.Format(@"
            SELECT
                parcelas_pagas
                FROM tb_mensalidades
                WHERE idaluno =" + Globais.Main.PassarAluno);

            DataTable dtt = Banco.dql(parcelas);
            vcon.Close();

            string ParcelasPagas = dtt.Rows[0].Field<string>("parcelas_pagas").ToString();

            vcon = Banco.ConexaoBanco();
            string NParcelas = String.Format(@"
            SELECT n_parcelas FROM tb_mensalidades WHERE idaluno =" + Globais.Main.PassarAluno);

            DataTable nParcelas = Banco.dql(NParcelas);
            vcon.Close();

            string MaxParcelas = nParcelas.Rows[0].Field<string>("n_parcelas");

            vcon = Banco.ConexaoBanco();
            string ValorDocumento = String.Format(@"
            SELECT valor_parcela FROM tb_mensalidades WHERE idaluno =" + Globais.Main.PassarAluno);

            DataTable vd = Banco.dql(ValorDocumento);
            vcon.Close();

            string ValorDoc = vd.Rows[0].Field<decimal>("valor_parcela").ToString("C");

            vcon = Banco.ConexaoBanco();
            string Pagador = String.Format(@"
            SELECT nome_aluno,cpf, rua, numero, cep, cidade, UF FROM tb_alunos WHERE ID_aluno =" + Globais.Main.PassarAluno);

            DataTable pagador = Banco.dql(Pagador);
            vcon.Close();

            string Nome = pagador.Rows[0].Field<string>("nome_aluno").ToUpper();
            string CPF = pagador.Rows[0].Field<string>("cpf");
            string Rua = pagador.Rows[0].Field<string>("rua");
            string Numero = pagador.Rows[0].Field<string>("numero");
            string Cep = pagador.Rows[0].Field<string>("cep");
            string Cidade = pagador.Rows[0].Field<string>("cidade");
            string UF = pagador.Rows[0].Field<string>("UF");

            vcon = Banco.ConexaoBanco();
            string Mes01 = String.Format(@"
            SELECT date_add(data_inicio, interval 1 month) as vencimento FROM tb_mensalidades WHERE idaluno =" + Globais.Main.PassarAluno);

            DataTable mes01 = Banco.dql(Mes01);
            vcon.Close();

            string DataVenc01 = mes01.Rows[0].Field<DateTime>("vencimento").ToString("dd/MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes02 = String.Format(@"
            SELECT date_add(data_inicio, interval 2 month) as vencimento FROM tb_mensalidades WHERE idaluno =" + Globais.Main.PassarAluno);

            DataTable mes02 = Banco.dql(Mes02);
            vcon.Close();

            string DataVenc02 = mes02.Rows[0].Field<DateTime>("vencimento").ToString("dd/MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes03 = String.Format(@"
            SELECT date_add(data_inicio, interval 3 month) as vencimento FROM tb_mensalidades WHERE idaluno =" + Globais.Main.PassarAluno);

            DataTable mes03 = Banco.dql(Mes03);
            vcon.Close();

            string DataVenc03 = mes03.Rows[0].Field<DateTime>("vencimento").ToString("dd/MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes04 = String.Format(@"
            SELECT date_add(data_inicio, interval 4 month) as vencimento FROM tb_mensalidades WHERE idaluno =" + Globais.Main.PassarAluno);

            DataTable mes04 = Banco.dql(Mes04);
            vcon.Close();

            string DataVenc04 = mes04.Rows[0].Field<DateTime>("vencimento").ToString("dd/MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes05 = String.Format(@"
            SELECT date_add(data_inicio, interval 5 month) as vencimento FROM tb_mensalidades WHERE idaluno =" + Globais.Main.PassarAluno);

            DataTable mes05 = Banco.dql(Mes05);
            vcon.Close();

            string DataVenc05 = mes05.Rows[0].Field<DateTime>("vencimento").ToString("dd/MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes06 = String.Format(@"
            SELECT date_add(data_inicio, interval 6 month) as vencimento FROM tb_mensalidades WHERE idaluno =" + Globais.Main.PassarAluno);

            DataTable mes06 = Banco.dql(Mes06);
            vcon.Close();

            string DataVenc06 = mes06.Rows[0].Field<DateTime>("vencimento").ToString("dd/MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes07 = String.Format(@"
            SELECT date_add(data_inicio, interval 7 month) as vencimento FROM tb_mensalidades WHERE idaluno =" + Globais.Main.PassarAluno);

            DataTable mes07 = Banco.dql(Mes07);
            vcon.Close();

            string DataVenc07 = mes07.Rows[0].Field<DateTime>("vencimento").ToString("dd/MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes08 = String.Format(@"
            SELECT date_add(data_inicio, interval 8 month) as vencimento FROM tb_mensalidades WHERE idaluno =" + Globais.Main.PassarAluno);

            DataTable mes08 = Banco.dql(Mes08);
            vcon.Close();

            string DataVenc08 = mes08.Rows[0].Field<DateTime>("vencimento").ToString("dd/MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes09 = String.Format(@"
            SELECT date_add(data_inicio, interval 9  month) as vencimento FROM tb_mensalidades WHERE idaluno =" + Globais.Main.PassarAluno);

            DataTable mes09 = Banco.dql(Mes09);
            vcon.Close();

            string DataVenc09 = mes09.Rows[0].Field<DateTime>("vencimento").ToString("dd/MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes10 = String.Format(@"
            SELECT date_add(data_inicio, interval 10 month) as vencimento FROM tb_mensalidades WHERE idaluno =" + Globais.Main.PassarAluno);

            DataTable mes10 = Banco.dql(Mes10);
            vcon.Close();

            string DataVenc10 = mes10.Rows[0].Field<DateTime>("vencimento").ToString("dd/MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes11 = String.Format(@"
            SELECT date_add(data_inicio, interval 11 month) as vencimento FROM tb_mensalidades WHERE idaluno =" + Globais.Main.PassarAluno);

            DataTable mes11 = Banco.dql(Mes11);
            vcon.Close();

            string DataVenc11 = mes11.Rows[0].Field<DateTime>("vencimento").ToString("dd/MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes12 = String.Format(@"
            SELECT date_add(data_inicio, interval 12 month) as vencimento FROM tb_mensalidades WHERE idaluno =" + Globais.Main.PassarAluno);

            DataTable mes12 = Banco.dql(Mes12);
            vcon.Close();

            string DataVenc12 = mes12.Rows[0].Field<DateTime>("vencimento").ToString("dd/MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes13 = String.Format(@"
            SELECT date_add(data_inicio, interval 13 month) as vencimento FROM tb_mensalidades WHERE idaluno =" + Globais.Main.PassarAluno);

            DataTable mes13 = Banco.dql(Mes13);
            vcon.Close();

            string DataVenc13 = mes13.Rows[0].Field<DateTime>("vencimento").ToString("dd/MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes14 = String.Format(@"
            SELECT date_add(data_inicio, interval 14 month) as vencimento FROM tb_mensalidades WHERE idaluno =" + Globais.Main.PassarAluno);

            DataTable mes14 = Banco.dql(Mes14);
            vcon.Close();

            string DataVenc14 = mes14.Rows[0].Field<DateTime>("vencimento").ToString("dd/MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes15 = String.Format(@"
            SELECT date_add(data_inicio, interval 15 month) as vencimento FROM tb_mensalidades WHERE idaluno =" + Globais.Main.PassarAluno);

            DataTable mes15 = Banco.dql(Mes15);
            vcon.Close();

            string DataVenc15 = mes15.Rows[0].Field<DateTime>("vencimento").ToString("dd/MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes16 = String.Format(@"
            SELECT date_add(data_inicio, interval 16 month) as vencimento FROM tb_mensalidades WHERE idaluno =" + Globais.Main.PassarAluno);

            DataTable mes16 = Banco.dql(Mes16);
            vcon.Close();

            string DataVenc16 = mes16.Rows[0].Field<DateTime>("vencimento").ToString("dd/MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes17 = String.Format(@"
            SELECT date_add(data_inicio, interval 17 month) as vencimento FROM tb_mensalidades WHERE idaluno =" + Globais.Main.PassarAluno);

            DataTable mes17 = Banco.dql(Mes17);
            vcon.Close();

            string DataVenc17 = mes17.Rows[0].Field<DateTime>("vencimento").ToString("dd/MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes18 = String.Format(@"
            SELECT date_add(data_inicio, interval 18 month) as vencimento FROM tb_mensalidades WHERE idaluno =" + Globais.Main.PassarAluno);

            DataTable mes18 = Banco.dql(Mes18);
            vcon.Close();

            string DataVenc18 = mes18.Rows[0].Field<DateTime>("vencimento").ToString("dd/MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes19 = String.Format(@"
            SELECT date_add(data_inicio, interval 19 month) as vencimento FROM tb_mensalidades WHERE idaluno =" + Globais.Main.PassarAluno);

            DataTable mes19 = Banco.dql(Mes19);
            vcon.Close();

            string DataVenc19 = mes19.Rows[0].Field<DateTime>("vencimento").ToString("dd/MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes20 = String.Format(@"
            SELECT date_add(data_inicio, interval 20 month) as vencimento FROM tb_mensalidades WHERE idaluno =" + Globais.Main.PassarAluno);

            DataTable mes20 = Banco.dql(Mes20);
            vcon.Close();

            string DataVenc20 = mes20.Rows[0].Field<DateTime>("vencimento").ToString("dd/MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes21 = String.Format(@"
            SELECT date_add(data_inicio, interval 21 month) as vencimento FROM tb_mensalidades WHERE idaluno =" + Globais.Main.PassarAluno);

            DataTable mes21 = Banco.dql(Mes21);
            vcon.Close();

            string DataVenc21 = mes21.Rows[0].Field<DateTime>("vencimento").ToString("dd/MM/yyyy");


           //this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("parcelas_pagas", ParcelasPagas));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("max_parcelas", MaxParcelas));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("valor_documento", ValorDoc));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pagador", Nome));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("cpf", CPF));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("rua", Rua));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("numero", Numero));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("cep", Cep));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("cidade", Cidade));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("uf", UF));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("max_parcelas", MaxParcelas));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento1", DataVenc01));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento2", DataVenc02));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento3", DataVenc03));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento4", DataVenc04));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento5", DataVenc05));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento6", DataVenc06));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento7", DataVenc07));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento8", DataVenc08));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento9", DataVenc09));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento10", DataVenc10));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento11", DataVenc11));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento12", DataVenc12));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento13", DataVenc13));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento14", DataVenc14));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento15", DataVenc15));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento16", DataVenc16));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento17", DataVenc17));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento18", DataVenc18));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento19", DataVenc19));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento20", DataVenc20));
            this.EnfermagemDigitus.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento21", DataVenc21));


            this.EnfermagemDigitus.RefreshReport();
        }

       
    }
}
