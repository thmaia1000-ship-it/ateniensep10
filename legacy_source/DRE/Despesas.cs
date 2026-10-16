using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Kernel.Font;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Image;
using iText.Layout.Borders;
using iText.Kernel.Geom;
using iText.IO.Font.Constants;
using iText.Html2pdf.Resolver.Font;
using iText.Layout.Font;
using iText.IO.Font;
using iText.Kernel.Events;
using iText.Kernel.Pdf.Canvas;

namespace Escolar.DRE
{
    public partial class Despesas : Form
    {
        public Despesas()
        {
            InitializeComponent();
        }

        string idSelecionado = "";

        private void Atualizar()
        {
            dgv_despesas.Rows.Clear();

            string data1 = dtp_data1.Value.ToString("yyyy-MM-dd");
            string data2 = dtp_data2.Value.ToString("yyyy-MM-dd");

            string vqueryDespesas = $@"
            SELECT 
            ID_despesa,
            tipo,
            descricao,
            valor,
            data,
            observacoes
            FROM tb_despesas WHERE (data BETWEEN '{data1}' AND '{data2}') OR tipo = 'Despesas Fixas'";

            DataTable despesas = Banco.dql(vqueryDespesas);


            for (int i = 0; i < despesas.Rows.Count; i++)
            {
                int ID_despesa = despesas.Rows[i].Field<Int32>("ID_despesa");
                string tipo = despesas.Rows[i].Field<string>("tipo");
                string descricao = despesas.Rows[i].Field<string>("descricao");
                string valor = despesas.Rows[i].Field<Decimal>("valor").ToString("C");
                string data = despesas.Rows[i].Field<DateTime>("data").ToString("dd/MM/yyyy");
                string observacoes = despesas.Rows[i].Field<string>("observacoes");

                dgv_despesas.Rows.Add(ID_despesa, tipo, descricao, valor, data, observacoes);
            }

            dgv_despesas.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_despesas.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_despesas.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv_despesas.ClearSelection();
        }

        private void Despesas_Load(object sender, EventArgs e)
        {
            DateTime data = DateTime.Today;
            DateTime primeiroDiaDoMes = new DateTime(data.Year, data.Month, 1);
            DateTime ultimoDiaDoMes = new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month));

            dtp_data1.Value = primeiroDiaDoMes;
            dtp_data2.Value = ultimoDiaDoMes;

            Atualizar();

        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            F_NovaDespesa f_NovaDespesa = new F_NovaDespesa();
            f_NovaDespesa.ShowDialog();

            Atualizar();
        }

        private void btn_remover_Click(object sender, EventArgs e)
        {
            if(idSelecionado != "")
            {
                if (MessageBox.Show("Excluir Despesa?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string vQueryDelete = $"DELETE FROM tb_despesas WHERE ID_despesa={idSelecionado}";
                    Banco.dml(vQueryDelete);

                    Atualizar();
                }
            }
            else
            {
                MessageBox.Show("Selecione uma Despesa!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_despesas_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.SelectedRows.Count > 0)
            {
                idSelecionado = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
            }
            else
            {
                idSelecionado = "";
            }
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            string data1 = dtp_data1.Value.ToString("yyyy-MM-dd");
            string data2 = dtp_data2.Value.ToString("yyyy-MM-dd");

            var vcon = Banco.ConexaoBanco();
                string vqueryDespesas = $@"
                SELECT 
                ID_despesa,
                tipo,
                descricao,
                valor,
                data,
                observacoes
                FROM tb_despesas WHERE (data BETWEEN '{data1}' AND '{data2}') OR tipo = 'Despesas Fixas'";

                DataTable dtDespesas = Banco.dql(vqueryDespesas);

                string nomeArquivo = Globais.caminho + @"\Relatorio.pdf";
                PdfWriter escritorPDF = new PdfWriter(nomeArquivo);
                PdfDocument pdf = new PdfDocument(escritorPDF);

                Document doc = new Document(pdf, PageSize.A4);

                // Use a fonte "times new roman" integrada
                PdfFont timesRoman = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
                doc.SetFont(timesRoman);

                // Restante do código...

                string dados = "";

                Paragraph paragrafo1 = new Paragraph("Relatório Despesas")
                    .SetFont(timesRoman)
                    .SetFontSize(25)
                    .SetBold()
                    .SetTextAlignment(TextAlignment.CENTER);

            Paragraph paragrafo2 = new Paragraph("Período: "+ dtp_data1.Value.ToShortDateString() + " Até " + dtp_data2.Value.ToShortDateString())
                    .SetFont(timesRoman)
                    .SetFontSize(10);


            //200, 50f, 25f, 60f, 70f, 70f
            Table tabela = new Table(new float[] { 80, 60f, 100f, 160f, 140f })
                    .SetWidth(UnitValue.CreatePercentValue(100))
                    .SetFixedLayout()
                    .SetBorder(Border.NO_BORDER);

            // Restante do código...

            // Adicionar os dados à tabela

            // Adicionar cabeçalhos da tabela
            tabela.AddHeaderCell(new Cell().Add(new Paragraph("Valor")).SetFont(timesRoman).SetFontSize(12).SetBold().SetTextAlignment(TextAlignment.CENTER));
            tabela.AddHeaderCell(new Cell().Add(new Paragraph("Data")).SetFont(timesRoman).SetFontSize(12).SetBold().SetTextAlignment(TextAlignment.CENTER));
            tabela.AddHeaderCell(new Cell().Add(new Paragraph("Tipo")).SetFont(timesRoman).SetFontSize(12).SetBold().SetTextAlignment(TextAlignment.CENTER));
            tabela.AddHeaderCell(new Cell().Add(new Paragraph("Descrição")).SetFont(timesRoman).SetFontSize(12).SetBold().SetTextAlignment(TextAlignment.CENTER));
            tabela.AddHeaderCell(new Cell().Add(new Paragraph("Observações")).SetFont(timesRoman).SetFontSize(12).SetBold().SetTextAlignment(TextAlignment.CENTER));

            decimal ValorTotal = 0;

            foreach (DataRow row in dtDespesas.Rows)
            {
                decimal valor = Convert.ToDecimal(row["valor"]);

                // Se for uma despesa fixa, multiplica pelo número de meses
                if (row["tipo"].ToString() == "Despesas Fixas")
                {
                    int mes1 = dtp_data1.Value.Month;
                    int mes2 = dtp_data2.Value.Month;
                    int ano1 = dtp_data1.Value.Year;
                    int ano2 = dtp_data2.Value.Year;

                    // Calculando o número total de meses no intervalo
                    int mesesTotais = (ano2 - ano1) * 12 + (mes2 - mes1 + 1);

                    // Multiplicando o valor das despesas fixas pelo número de meses
                    valor = valor * mesesTotais;
                }

                ValorTotal += valor;

                // Adicionando células à tabela
                Cell InadimplencaCell = new Cell().Add(new Paragraph(valor.ToString("C")))
                    .SetFont(timesRoman)
                    .SetFontSize(10)
                    .SetWidth(30) // Definir largura da célula
                    .SetHeight(15) // Definir altura da célula
                    .SetTextAlignment(TextAlignment.CENTER);
                tabela.AddCell(InadimplencaCell);

                Cell VenceuCell = new Cell().Add(new Paragraph(Convert.ToDateTime(row["data"]).ToString("dd/MM/yyyy")))
                    .SetFont(timesRoman)
                    .SetFontSize(10)
                    .SetWidth(20) // Definir largura da célula
                    .SetHeight(15) // Definir altura da célula
                    .SetTextAlignment(TextAlignment.CENTER);
                tabela.AddCell(VenceuCell);

                Cell nomeAlunoCell = new Cell()
                    .Add(new Paragraph(row["tipo"].ToString()))
                    .SetFont(timesRoman)
                    .SetFontSize(10)
                    .SetWidth(50) // Definir largura da célula
                    .SetHeight(15); // Definir altura da célula
                tabela.AddCell(nomeAlunoCell);

                Cell TurmaCell = new Cell().Add(new Paragraph(row["descricao"].ToString()))
                    .SetFont(timesRoman)
                    .SetFontSize(10)
                    .SetWidth(30) // Definir largura da célula
                    .SetHeight(15); // Definir altura da célula
                tabela.AddCell(TurmaCell);

                Cell TelefoneCell = new Cell().Add(new Paragraph(row["observacoes"].ToString()))
                    .SetFont(timesRoman)
                    .SetFontSize(10)
                    .SetWidth(30) // Definir largura da célula
                    .SetHeight(15); // Definir altura da célula
                tabela.AddCell(TelefoneCell);
            }


            Paragraph paragrafoValorTotal = new Paragraph("Valor Total: " + ValorTotal.ToString("C") + "\n")
                   .SetFont(timesRoman)
                   .SetFontSize(12)
                   .SetBold();

            Paragraph paragrafoDataGerada = new Paragraph("Relatório Gerado em: " + DateTime.Today.ToShortDateString() + " às " + DateTime.Now.ToShortTimeString())
                    .SetFont(timesRoman)
                    .SetFontSize(8);

                doc.Add(paragrafo1);
                doc.Add(paragrafoValorTotal);
                doc.Add(paragrafo2);
                doc.Add(tabela);
                doc.Add(paragrafoDataGerada);

            // Após fechar o documento, vamos editar o rodapé na última página
            PdfPage lastPage = pdf.GetLastPage(); // Pega a última página
            PdfCanvas canvas = new PdfCanvas(lastPage); // Cria o canvas para a última página

            // Após fechar o documento, vamos editar o rodapé
            canvas.BeginText();
            canvas.SetFontAndSize(timesRoman, 7);
            canvas.MoveText(300, 20); // Ajuste a posição no rodapé
            canvas.ShowText("Escola Infantil Ateniense - Master Escolar - BR3 Tecnologia © "+ DateTime.Today.Year +"- Todos os direitos reservados. ");
            canvas.EndText();

            PdfPage FirstPage = pdf.GetFirstPage(); // Pega a Primeira página


            doc.Close();

            System.Diagnostics.Process.Start(Globais.caminho + @"\Relatorio.pdf");
        }

        private void btn_filtrar_Click(object sender, EventArgs e)
        {
            Atualizar();
        }
    }
}
