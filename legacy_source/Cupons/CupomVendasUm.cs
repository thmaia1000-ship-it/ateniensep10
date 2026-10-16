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
    public partial class CupomVendasUm : Form
    {
        public CupomVendasUm()
        {
            InitializeComponent();
        }

        private void CupomVendasUm_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'dbatenienseVendas.tb_vendas'. Você pode movê-la ou removê-la conforme necessário.
            this.tb_vendasTableAdapter.Fill(this.dbatenienseVendas.tb_vendas, Convert.ToInt32(Globais.Main.PassarCodigoVenda));

            // TESTAR DataRow[] dRows = dbateniensejpVendas.Tables["tabela"].Select(" nome = 'nome'");

            if (Globais.Main.PassarData == "" && Globais.Main.PassarHorario == "")
            {
                string Data = DateTime.Now.ToString("dd/MM/yyyy");
                string Horario = DateTime.Now.ToString("HH:mm");
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("data", Data + " " + Horario));
            }
            else
            {
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("data", Globais.Main.PassarData + " " + Globais.Main.PassarHorario));
            }

            var vcon = Banco.ConexaoBanco();

            string Total = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_vendas
            WHERE codigovenda={0}", Globais.Main.PassarCodigoVenda);
            DataTable total = Banco.dql(Total);
            vcon.Close();

            decimal Valor_total = total.Rows[0].Field<decimal>("total");

            string NomeAluno = String.Format(@"
            SELECT 
            nome_aluno
            FROM tb_alunos
            WHERE ID_aluno={0}", Globais.Main.PassarIdAluno);
            DataTable Nome_aluno = Banco.dql(NomeAluno);
            vcon.Close();

            Globais.Main.PassarAluno = Nome_aluno.Rows[0].Field<string>("nome_aluno");

            string ID_caixa = String.Format(@"SELECT ID_caixa FROM tb_caixa WHERE codigovenda ={0}", Globais.Main.PassarCodigoVenda);

            DataTable id_caixa = Banco.dql(ID_caixa);

            Globais.Main.PassarIdCaixa = id_caixa.Rows[0].Field<Int32>("ID_caixa").ToString();

            if (Globais.Main.PassarForma1 != "" && Globais.Main.PassarForma2 != "")
            {
                string forma_pagamento = Globais.Main.PassarForma1 + "/" + Globais.Main.PassarForma2;

                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("forma_pagamento", forma_pagamento));
            }
            else
            {
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("forma_pagamento", Globais.Main.PassarForma));
            }

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("atendente", Globais.Main.PassarUsuario.ToUpper()));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("codigovenda", Globais.Main.PassarIdCaixa));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("nome_aluno", Globais.Main.PassarAluno));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("valor_total", Valor_total.ToString("C")));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pagante", Globais.Main.PassarPagante.ToUpper()));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("observacoes", Globais.Main.PassarDesc));

            // --- INÍCIO DA CORREÇÃO ---
            this.reportViewer1.LocalReport.DataSources.Clear();
            Microsoft.Reporting.WinForms.ReportDataSource rds = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", (DataTable)this.dbatenienseVendas.tb_vendas);
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            // --- FIM DA CORREÇÃO ---

            this.reportViewer1.RefreshReport();

            Globais.Main.PassarCodigoVenda = "";
            Globais.Main.PassarData = "";
            Globais.Main.PassarHorario = "";
        }
    }
}