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
    public partial class F_CarneAteniense : Form
    {
        public F_CarneAteniense()
        {
            InitializeComponent();
        }

        private void F_CarneAteniense_Load(object sender, EventArgs e)
        {
            string DiaUtiL = "5° DIA ÚTIL";

            var vcon = Banco.ConexaoBanco();
            string ValorDocumento = String.Format(@"
            SELECT valor_parcela FROM tb_mensalidades WHERE idaluno ={0} AND ano_letivo={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);
            DataTable vd = Banco.dql(ValorDocumento);
            vcon.Close();


            string ValorDoc = vd.Rows[0].Field<decimal>("valor_parcela").ToString("C");

            vcon = Banco.ConexaoBanco();
            string NParcelas = String.Format(@"
            SELECT n_parcelas FROM tb_mensalidades WHERE idaluno ={0} AND ano_letivo={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

            DataTable nParcelas = Banco.dql(NParcelas);

            vcon.Close();

            int MaxParcelas = nParcelas.Rows[0].Field<Int32>("n_parcelas");

            vcon = Banco.ConexaoBanco();
            string Pagador = String.Format(@"
            SELECT tba.nome_aluno,tbc.nome_curso, tbf.nome,tbf.cpf, tbf.rua, tbf.numero, tbf.cep,tba.cidade, tba.UF FROM tb_responsavel_financeiro as tbf, tb_alunos as tba, tb_cursos as tbc WHERE tbf.idaluno ={0} AND tba.ID_aluno={0} AND tba.idcurso = tbc.ID_curso", Globais.Main.PassarIdAluno);

            DataTable pagador = Banco.dql(Pagador);
            vcon.Close();


            string Nome = pagador.Rows[0].Field<string>("nome").ToUpper();
            string Nome_Aluno = pagador.Rows[0].Field<string>("nome_aluno").ToUpper();
            string CPF = pagador.Rows[0].Field<string>("cpf");
            string Rua = pagador.Rows[0].Field<string>("rua");
            string Numero = pagador.Rows[0].Field<string>("numero");
            string cidade = pagador.Rows[0].Field<string>("cidade");
            string UF = pagador.Rows[0].Field<string>("UF");
            string Cep = pagador.Rows[0].Field<string>("cep");
            string Nome_Curso = pagador.Rows[0].Field<string>("nome_curso");

            vcon = Banco.ConexaoBanco();
            string Mes01 = String.Format(@"
            SELECT date_add(data_inicio, interval 0 month) as vencimento FROM tb_mensalidades WHERE idaluno ={0} AND ano_letivo={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

            DataTable mes01 = Banco.dql(Mes01);
            vcon.Close();

            string DataVenc01 = mes01.Rows[0].Field<DateTime>("vencimento").ToString(DiaUtiL+" MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes02 = String.Format(@"
            SELECT date_add(data_inicio, interval 1 month) as vencimento FROM tb_mensalidades WHERE idaluno ={0} AND ano_letivo={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

            DataTable mes02 = Banco.dql(Mes02);
            vcon.Close();

            string DataVenc02 = mes02.Rows[0].Field<DateTime>("vencimento").ToString(DiaUtiL + " MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes03 = String.Format(@"
            SELECT date_add(data_inicio, interval 2 month) as vencimento FROM tb_mensalidades WHERE idaluno ={0} AND ano_letivo={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

            DataTable mes03 = Banco.dql(Mes03);
            vcon.Close();

            string DataVenc03 = mes03.Rows[0].Field<DateTime>("vencimento").ToString(DiaUtiL + " MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes04 = String.Format(@"
            SELECT date_add(data_inicio, interval 3 month) as vencimento FROM tb_mensalidades WHERE idaluno ={0} AND ano_letivo={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

            DataTable mes04 = Banco.dql(Mes04);
            vcon.Close();

            string DataVenc04 = mes04.Rows[0].Field<DateTime>("vencimento").ToString(DiaUtiL + " MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes05 = String.Format(@"
            SELECT date_add(data_inicio, interval 4 month) as vencimento FROM tb_mensalidades WHERE idaluno ={0} AND ano_letivo={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

            DataTable mes05 = Banco.dql(Mes05);
            vcon.Close();

            string DataVenc05 = mes05.Rows[0].Field<DateTime>("vencimento").ToString(DiaUtiL + " MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes06 = String.Format(@"
            SELECT date_add(data_inicio, interval 5 month) as vencimento FROM tb_mensalidades WHERE idaluno ={0} AND ano_letivo={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

            DataTable mes06 = Banco.dql(Mes06);
            vcon.Close();

            string DataVenc06 = mes06.Rows[0].Field<DateTime>("vencimento").ToString(DiaUtiL + " MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes07 = String.Format(@"
            SELECT date_add(data_inicio, interval 6 month) as vencimento FROM tb_mensalidades WHERE idaluno ={0} AND ano_letivo={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

            DataTable mes07 = Banco.dql(Mes07);
            vcon.Close();

            string DataVenc07 = mes07.Rows[0].Field<DateTime>("vencimento").ToString(DiaUtiL + " MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes08 = String.Format(@"
            SELECT date_add(data_inicio, interval 7 month) as vencimento FROM tb_mensalidades WHERE idaluno ={0} AND ano_letivo={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

            DataTable mes08 = Banco.dql(Mes08);
            vcon.Close();

            string DataVenc08 = mes08.Rows[0].Field<DateTime>("vencimento").ToString(DiaUtiL + " MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes09 = String.Format(@"
            SELECT date_add(data_inicio, interval 8  month) as vencimento FROM tb_mensalidades WHERE idaluno ={0} AND ano_letivo={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

            DataTable mes09 = Banco.dql(Mes09);
            vcon.Close();

            string DataVenc09 = mes09.Rows[0].Field<DateTime>("vencimento").ToString(DiaUtiL + " MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes10 = String.Format(@"
            SELECT date_add(data_inicio, interval 9 month) as vencimento FROM tb_mensalidades WHERE idaluno ={0} AND ano_letivo={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

            DataTable mes10 = Banco.dql(Mes10);
            vcon.Close();

            string DataVenc10 = mes10.Rows[0].Field<DateTime>("vencimento").ToString(DiaUtiL + " MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes11 = String.Format(@"
            SELECT date_add(data_inicio, interval 10 month) as vencimento FROM tb_mensalidades WHERE idaluno ={0} AND ano_letivo={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

            DataTable mes11 = Banco.dql(Mes11);
            vcon.Close();

            string DataVenc11 = mes11.Rows[0].Field<DateTime>("vencimento").ToString(DiaUtiL + " MM/yyyy");

            vcon = Banco.ConexaoBanco();
            string Mes12 = String.Format(@"
            SELECT date_add(data_inicio, interval 11 month) as vencimento FROM tb_mensalidades WHERE idaluno ={0} AND ano_letivo={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

            DataTable mes12 = Banco.dql(Mes12);
            vcon.Close();

            string DataVenc12 = mes12.Rows[0].Field<DateTime>("vencimento").ToString(DiaUtiL + " MM/yyyy");

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("nome_escola", "ESCOLA INFANTIL ATENIENSE"));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("max_parcelas", MaxParcelas.ToString()));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("valor_documento", ValorDoc));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pagador", Nome));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("cpf", CPF));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("rua", Rua));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("numero", Numero));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("uf", UF));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("cidade", cidade));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("cep", Cep));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("nome_aluno", Nome_Aluno));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("nome_curso", Nome_Curso));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento1", DataVenc01));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento2", DataVenc02));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento3", DataVenc03));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento4", DataVenc04));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento5", DataVenc05));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento6", DataVenc06));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento7", DataVenc07));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento8", DataVenc08));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento9", DataVenc09));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento10", DataVenc10));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento11", DataVenc11));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("vencimento12", DataVenc12));
            this.reportViewer1.RefreshReport();
        }
    }
}
