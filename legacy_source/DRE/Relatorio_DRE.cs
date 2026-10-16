using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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
using iText.StyledXmlParser.Jsoup.Nodes;

namespace Escolar.DRE
{
    public partial class Relatorio_DRE : Form
    {
        public Relatorio_DRE()
        {
            InitializeComponent();
        }

        decimal valor_faturamento, valor_impostos, valor_variaveis, valor_fixas, valor_pessoas, valor_prolabore, LucroBruto, LucroOperacional,LucroLiquido;

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

            iText.Layout.Document doc = new iText.Layout.Document(pdf, PageSize.A4);


            PdfFont timesRoman = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
            doc.SetFont(timesRoman);

            Paragraph paragrafo1 = new Paragraph("DRE Gerencial")
                .SetFont(timesRoman)
                .SetFontSize(25)
                .SetBold()
                .SetTextAlignment(TextAlignment.CENTER);

            Paragraph paragrafo2 = new Paragraph("Período: " + dtp_data1.Value.ToShortDateString() + " Até " + dtp_data2.Value.ToShortDateString())
                .SetFont(timesRoman)
                .SetFontSize(10);

            Table tabela = new Table(new float[] { 100f, 100f})
                .SetWidth(UnitValue.CreatePercentValue(100))
                .SetFixedLayout()
                .SetBorder(Border.NO_BORDER);


            tabela.AddHeaderCell(new Cell(1, 2)  // Mescla as duas colunas
            .Add(new Paragraph("DEMONSTRAÇÃO DE RESULTADO DO EXERCÍCIO"))
            .SetFont(timesRoman)
            .SetFontSize(12)
            .SetBold()
            .SetTextAlignment(TextAlignment.CENTER));

            tabela.AddCell(new Cell().Add(new Paragraph("(-)FATURAMENTO")).SetFont(timesRoman).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(iText.Kernel.Colors.ColorConstants.LIGHT_GRAY));
            tabela.AddCell(new Cell().Add(new Paragraph(valor_faturamento.ToString("C"))).SetFont(timesRoman).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(iText.Kernel.Colors.ColorConstants.LIGHT_GRAY));
            tabela.AddCell(new Cell().Add(new Paragraph("(-)Impostos")).SetFont(timesRoman).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER));
            tabela.AddCell(new Cell().Add(new Paragraph(valor_impostos.ToString("C"))).SetFont(timesRoman).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER));
            
            tabela.AddCell(new Cell().Add(new Paragraph("(-)LUCRO BRUTO")).SetFont(timesRoman).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(iText.Kernel.Colors.ColorConstants.LIGHT_GRAY));
            tabela.AddCell(new Cell().Add(new Paragraph(LucroBruto.ToString("C"))).SetFont(timesRoman).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(iText.Kernel.Colors.ColorConstants.LIGHT_GRAY));
            tabela.AddCell(new Cell().Add(new Paragraph("(-)Despesas Variáveis")).SetFont(timesRoman).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER));
            tabela.AddCell(new Cell().Add(new Paragraph(valor_variaveis.ToString("C"))).SetFont(timesRoman).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER));
            
            tabela.AddCell(new Cell().Add(new Paragraph("(-)LUCRO OPERACIONAL")).SetFont(timesRoman).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(iText.Kernel.Colors.ColorConstants.LIGHT_GRAY));
            tabela.AddCell(new Cell().Add(new Paragraph(LucroOperacional.ToString("C"))).SetFont(timesRoman).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(iText.Kernel.Colors.ColorConstants.LIGHT_GRAY));
            tabela.AddCell(new Cell().Add(new Paragraph("(-)Despesas Fixas")).SetFont(timesRoman).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER));
            tabela.AddCell(new Cell().Add(new Paragraph(valor_fixas.ToString("C"))).SetFont(timesRoman).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER));
            tabela.AddCell(new Cell().Add(new Paragraph("(-)Gasto com Pessoas")).SetFont(timesRoman).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER));
            tabela.AddCell(new Cell().Add(new Paragraph(valor_pessoas.ToString("C"))).SetFont(timesRoman).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER));
            tabela.AddCell(new Cell().Add(new Paragraph("(-)Prolabore")).SetFont(timesRoman).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER));
            tabela.AddCell(new Cell().Add(new Paragraph(valor_prolabore.ToString("C"))).SetFont(timesRoman).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER));

            tabela.AddCell(new Cell().Add(new Paragraph("(-)LUCRO LÍQUIDO")).SetFont(timesRoman).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(iText.Kernel.Colors.ColorConstants.LIGHT_GRAY));
            tabela.AddCell(new Cell().Add(new Paragraph(LucroLiquido.ToString("C"))).SetFont(timesRoman).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(iText.Kernel.Colors.ColorConstants.LIGHT_GRAY));


            Paragraph paragrafoDataGerada = new Paragraph("Relatório Gerado em: " + DateTime.Today.ToShortDateString() + " às " + DateTime.Now.ToShortTimeString())
                .SetFont(timesRoman)
                .SetFontSize(8);

            doc.Add(paragrafo1);
            doc.Add(paragrafo2);
            doc.Add(tabela);
            doc.Add(paragrafoDataGerada);

            //Adicionando gráfico ao PDF
            string caminhoImagem = Globais.caminho + "grafico.png";

            grafico.Width = 1600;
            grafico.Height = 800;

            foreach (var legend in grafico.Legends)
            {
                legend.Font = new Font("Arial", 24, FontStyle.Bold);
            }

            grafico.Titles[0].Font = new Font("Arial", 28, FontStyle.Bold);

            grafico.SaveImage(caminhoImagem, System.Drawing.Imaging.ImageFormat.Png);

            if (System.IO.File.Exists(caminhoImagem))
            {
                doc.Add(new Paragraph("\n").SetFontSize(12));

                iText.Layout.Element.Image img = new iText.Layout.Element.Image(ImageDataFactory.Create(caminhoImagem));

                float proporcao = (float)grafico.Width / grafico.Height;
                float largura = 500;
                float altura = largura / proporcao;

                img.SetWidth(largura);
                img.SetHeight(altura);

                img.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                doc.Add(img);
                System.IO.File.Delete(caminhoImagem);
            }

            PdfPage lastPage = pdf.GetLastPage();
            PdfCanvas canvas = new PdfCanvas(lastPage);
            canvas.BeginText();
            canvas.SetFontAndSize(timesRoman, 7);
            canvas.MoveText(300, 20);
            canvas.ShowText("Escola Infantil Ateniense - Master Escolar - BR3 Tecnologia © " + DateTime.Today.Year + " - Todos os direitos reservados.");
            canvas.EndText();

            grafico.Width = 382;
            grafico.Height = 248;

            //Grafico voltando a configurações padroões
            Graficos();

            doc.Close();
            System.Diagnostics.Process.Start(Globais.caminho + @"\Relatorio.pdf");

        }

        private void Graficos()
        {
            // Calcular o valor total
            decimal valor_total = valor_faturamento + valor_impostos + valor_variaveis + valor_fixas + valor_pessoas + valor_prolabore;
            grafico.Titles.Clear();

            // Criando a série do gráfico
            Series serie = new Series("Vendas");
            serie.ChartType = SeriesChartType.Doughnut; // Define o tipo de gráfico (Rosca)

            // Adicionando dados ao gráfico com os nomes corretos
            serie.Points.AddXY("Faturamento", valor_faturamento);
            serie.Points.AddXY("Impostos", valor_impostos);
            serie.Points.AddXY("Despesas Variáveis", valor_variaveis);
            serie.Points.AddXY("Despesas Fixas", valor_fixas);
            serie.Points.AddXY("Gasto com Pessoas", valor_pessoas);
            serie.Points.AddXY("Prolabore", valor_prolabore);

            serie.IsValueShownAsLabel = false; // Impede exibição dos valores dentro das fatias

            var titulo = new Title();
            titulo.Font = new Font("Arial", 16, FontStyle.Bold);
            titulo.ForeColor = Color.Black;
            titulo.Text = "Relatório DRE Gráfico";
            grafico.Titles.Add(titulo);

            // Calculando a porcentagem e aplicando dentro das fatias
            foreach (DataPoint ponto in serie.Points)
            {
                decimal valor = (decimal)ponto.YValues[0]; // Valor do ponto
                decimal porcentagem = (valor / valor_total) * 100; // Calculando a porcentagem

                // Definindo o texto dentro das fatias como porcentagem
                ponto.Label = $" "; // Colocando a porcentagem dentro da fatia
            }

            // Ativando efeito 3D
            grafico.ChartAreas[0].Area3DStyle.Enable3D = false;

            // Definindo cores específicas para cada ponto
            Color[] cores = new Color[]
            {
                Color.SpringGreen,        // Faturamento
                Color.HotPink,       // Impostos
                Color.Chocolate,      // Despesas Variáveis
                Color.Goldenrod,     // Despesas Fixas
                Color.Yellow,     // Gasto com Pessoas
                Color.DarkTurquoise      // Prolabore
            };

            int i = 0;
            // Adicionando bordas às fatias para destacar melhor
            foreach (DataPoint ponto in serie.Points)
            {
                ponto.BorderColor = System.Drawing.Color.Black;
                ponto.BorderWidth = 1;

                // Definindo a cor de cada ponto (fatias)
                ponto.Color = cores[i]; // Atribuindo a cor à fatia
                i++;
            }

            // Personalizando a legenda para mostrar apenas os nomes (sem a porcentagem)
            grafico.Legends[0].Enabled = true;
            grafico.Legends[0].Font = new Font("Arial", 10, FontStyle.Bold);
            grafico.Legends[0].BackColor = System.Drawing.Color.Transparent;
            grafico.Legends[0].IsTextAutoFit = true; // Ajuste para o texto não cortar

            // Definir nome e porcentagem na legenda
            foreach (DataPoint ponto in serie.Points)
            {
                decimal valor = (decimal)ponto.YValues[0]; // Valor do ponto
                decimal porcentagem = (valor / valor_total) * 100; // Calculando a porcentagem

                ponto.LegendText = $"{ponto.AxisLabel} ({porcentagem:F1}%)"; // Nome + Porcentagem na legenda
            }

            grafico.BackColor = Color.Transparent; // Fundo do gráfico
            grafico.ChartAreas[0].BackColor = Color.Transparent; // Fundo da área de desenho
            grafico.Legends[0].BackColor = Color.Transparent; // Fundo da legenda

            // Limpando séries antigas e adicionando a nova série estilizada
            grafico.Series.Clear();
            grafico.Series.Add(serie);
        }

        private void Filtrar()
        {
            dgv_DRE.Rows.Clear();

            string data1 = dtp_data1.Value.ToString("yyyy-MM-dd");
            string data2 = dtp_data2.Value.ToString("yyyy-MM-dd");

            //Faturamento================
            string vQueryFaturamento = String.Format($@"
            SELECT COALESCE(SUM(valor_total), 0) AS 'faturamento' 
            FROM tb_caixa WHERE (data BETWEEN '{data1}' AND '{data2}') 
            AND tipo_movimentacao != 'SAIDA'");

            DataTable faturamento = Banco.dql(vQueryFaturamento);

            valor_faturamento = faturamento.Rows[0].Field<Decimal>("faturamento");

            //Impostos===================
            string vQueryImpostos = String.Format($@"
            SELECT COALESCE(SUM(valor), 0) AS 'impostos' 
            FROM tb_despesas WHERE (data BETWEEN '{data1}' AND '{data2}') 
            AND tipo = 'Impostos'");

            DataTable impostos = Banco.dql(vQueryImpostos);

            valor_impostos = impostos.Rows[0].Field<Decimal>("impostos");

            //Variaveis==================
            string vQueryVariaveis = String.Format($@"
            SELECT COALESCE(SUM(valor), 0) AS 'variaveis' 
            FROM tb_despesas WHERE (data BETWEEN '{data1}' AND '{data2}') 
            AND tipo = 'Despesas Variáveis'");

            DataTable variaveis = Banco.dql(vQueryVariaveis);

            valor_variaveis = variaveis.Rows[0].Field<Decimal>("variaveis");

            //Fixas ======================
            string vQueryFixas = String.Format($@"
            SELECT COALESCE(SUM(valor), 0) AS 'fixas' 
            FROM tb_despesas WHERE tipo = 'Despesas Fixas'");

            DataTable fixas = Banco.dql(vQueryFixas);

            valor_fixas = fixas.Rows[0].Field<Decimal>("fixas");
            int mes1 = dtp_data1.Value.Month;
            int mes2 = dtp_data2.Value.Month;
            int ano1 = dtp_data1.Value.Year;
            int ano2 = dtp_data2.Value.Year;

            int mesesTotais = (ano2 - ano1) * 12 + (mes2 - mes1 + 1);

            valor_fixas = valor_fixas * mesesTotais;

            //Pessoas ======================
            string vQueryPessoas = String.Format($@"
            SELECT COALESCE(SUM(valor), 0) AS 'pessoas' 
            FROM tb_despesas WHERE (data BETWEEN '{data1}' AND '{data2}') 
            AND tipo = 'Gastos com Pessoas'");

            DataTable pessoas = Banco.dql(vQueryPessoas);

            valor_pessoas = pessoas.Rows[0].Field<Decimal>("pessoas");

            //Pessoas ======================
            string vQueryProlabore = String.Format($@"
            SELECT COALESCE(SUM(valor), 0) AS 'prolabore' 
            FROM tb_despesas WHERE (data BETWEEN '{data1}' AND '{data2}') 
            AND tipo = 'Prolabore'");

            DataTable prolabore = Banco.dql(vQueryProlabore);

            valor_prolabore = prolabore.Rows[0].Field<Decimal>("prolabore");

            LucroBruto = (valor_faturamento - valor_impostos);
            LucroOperacional = (LucroBruto - valor_variaveis);
            LucroLiquido = (LucroOperacional - (valor_fixas - valor_pessoas - valor_prolabore));

            dgv_DRE.Rows.Add("(-)FATURAMENTO", valor_faturamento.ToString("C"));
            dgv_DRE.Rows.Add("(-)Impostos", valor_impostos.ToString("C"));
            dgv_DRE.Rows.Add("(-)LUCRO BRUTO", LucroBruto.ToString("C"));
            dgv_DRE.Rows.Add("(-)Despesas Variáveis", valor_variaveis.ToString("C"));
            dgv_DRE.Rows.Add("(-)LUCRO OPERACIONAL", LucroOperacional.ToString("C"));
            dgv_DRE.Rows.Add("(-)Despesas Fixas", valor_fixas.ToString("C"));
            dgv_DRE.Rows.Add("(-)Gasto com Pessoas", valor_pessoas.ToString("C"));
            dgv_DRE.Rows.Add("(-)Prolabore", valor_prolabore.ToString("C"));
            dgv_DRE.Rows.Add("(-)LUCRO LÍQUIDO", LucroLiquido.ToString("C"));

            dgv_DRE.Rows[0].DefaultCellStyle.Font = new Font(dgv_DRE.Font, FontStyle.Bold); // Negrito
            dgv_DRE.Rows[0].DefaultCellStyle.BackColor = Color.LightGray; // Fundo cinza

            dgv_DRE.Rows[2].DefaultCellStyle.Font = new Font(dgv_DRE.Font, FontStyle.Bold); // Negrito
            dgv_DRE.Rows[2].DefaultCellStyle.BackColor = Color.LightGray; // Fundo cinza

            dgv_DRE.Rows[4].DefaultCellStyle.Font = new Font(dgv_DRE.Font, FontStyle.Bold); // Negrito
            dgv_DRE.Rows[4].DefaultCellStyle.BackColor = Color.LightGray; // Fundo cinza

            dgv_DRE.Rows[8].DefaultCellStyle.Font = new Font(dgv_DRE.Font, FontStyle.Bold); // Negrito
            dgv_DRE.Rows[8].DefaultCellStyle.BackColor = Color.LightGray; // Fundo cinza

            dgv_DRE.ClearSelection();

            Graficos();
        }

        private void Relatorio_DRE_Load(object sender, EventArgs e)
        {
            DateTime data = DateTime.Today;
            DateTime primeiroDiaDoMes = new DateTime(data.Year, data.Month, 1);
            DateTime ultimoDiaDoMes = new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month));

            dtp_data1.Value = primeiroDiaDoMes;
            dtp_data2.Value = ultimoDiaDoMes;

            Filtrar();
        }

        private void btn_filtrar_Click(object sender, EventArgs e)
        {
            Filtrar();
        }
    }
}
