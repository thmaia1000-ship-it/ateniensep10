using System;
using System.Data;
using System.IO;
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Kernel.Pdf.Canvas;

namespace Escolar.Caixa
{
    public partial class MensalidadesReceber : Form
    {

        int data;

        public MensalidadesReceber()
        {
            InitializeComponent();
        }



        string ano_letivo = DateTime.Now.ToString("yyyy");

        private void MensalidadesReceber_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> ano = new Dictionary<string, string>();

            ano.Add("2020", "2020");
            ano.Add("2021", "2021");
            ano.Add("2022", "2022");
            ano.Add("2023", "2023");
            ano.Add("2024", "2024");
            ano.Add("2025", "2025");
            ano.Add("2026", "2026");
            ano.Add("2027", "2027");
            ano.Add("2028", "2028");
            ano.Add("2029", "2029");
            ano.Add("2030", "2030");
            ano.Add("2031", "2031");
            ano.Add("2032", "2032");
            ano.Add("2033", "2033");
            ano.Add("2034", "2034");
            ano.Add("2035", "2035");
            ano.Add("2036", "2036");
            ano.Add("2037", "2037");
            ano.Add("2038", "2038");
            ano.Add("2039", "2039");
            ano.Add("2040", "2040");
            ano.Add("2041", "2041");
            ano.Add("2042", "2042");
            ano.Add("2043", "2043");
            ano.Add("2044", "2044");
            ano.Add("2045", "2045");
            ano.Add("2046", "2046");
            ano.Add("2047", "2047");
            ano.Add("2048", "2048");
            ano.Add("2049", "2049");
            ano.Add("2050", "2050");
            cb_ano.DataSource = new BindingSource(ano, null);
            cb_ano.DisplayMember = "Value";
            cb_ano.ValueMember = "Key";

            cb_ano.SelectedValue = ano_letivo;

            Dictionary<string, string> etapa = new Dictionary<string, string>();

            etapa.Add("TODAS", "TODAS");
            etapa.Add("MATERNAL I", "MATERNAL I");
            etapa.Add("MATERNAL II", "MATERNAL II");
            etapa.Add("JARDIM I", "JARDIM I");
            etapa.Add("JARDIM II", "JARDIM II");
            etapa.Add("1° ANO", "1° ANO");
            cb_Filtrar.DataSource = new BindingSource(etapa, null);
            cb_Filtrar.DisplayMember = "Value";
            cb_Filtrar.ValueMember = "Key";

            var vcon = Banco.ConexaoBanco();
            string queryInadimplentes = String.Format(@"
            SELECT
                tba.nome_aluno AS 'Aluno(a)',
                DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL tbm.parcelas_pagas MONTH), INTERVAL -2 DAY) AS 'Venceu',
                GREATEST(0, LEAST(
                    tbm.n_parcelas - tbm.parcelas_pagas, 
                    TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE())
                )) AS 'Atrasadas',
                tbm.valor_parcela * 
                IF(
                    GREATEST(0, LEAST(
                        tbm.n_parcelas - tbm.parcelas_pagas, 
                        TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE())
                    )) = 0, 
                    1, 
                    GREATEST(0, LEAST(
                        tbm.n_parcelas - tbm.parcelas_pagas, 
                        TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE())
                    ))
                ) AS 'Receber',
                tba.etapa AS 'Turma',
                tba.telefone AS 'Telefone'
            FROM
                tb_mensalidades AS tbm
            INNER JOIN
                tb_alunos AS tba ON tba.ID_aluno = tbm.idaluno
            WHERE
                (TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE()) > 0
                OR MONTH(DATE_ADD(tbm.data_inicio, INTERVAL tbm.parcelas_pagas MONTH)) = MONTH(CURDATE()))
                AND YEAR(DATE_ADD(tbm.data_inicio, INTERVAL tbm.parcelas_pagas MONTH)) = {0}
                AND tbm.ano_letivo = {0}
                AND tbm.parcelas_pagas != tbm.n_parcelas
            ORDER BY
                tba.nome_aluno
            ", ano_letivo);

            dgv_inadimplentes.DataSource = Banco.dql(queryInadimplentes);

            decimal total = 0;

            foreach (DataGridViewRow row in dgv_inadimplentes.Rows)
            {
                // Verificar se a célula na coluna 2 existe
                if (row.Cells.Count > 2 && row.Cells[3].Value != null && decimal.TryParse(row.Cells[3].Value.ToString(), out decimal valorParcela))
                {
                    total += valorParcela;
                }
            }

            lb_TOTAL.Text = total.ToString("C2");

            dgv_inadimplentes.Columns[0].Width = 256;
            dgv_inadimplentes.Columns[1].Width = 70;
            dgv_inadimplentes.Columns[2].Width = 70;
            dgv_inadimplentes.Columns[3].Width = 90;
            dgv_inadimplentes.Columns[4].Width = 70;
            dgv_inadimplentes.Columns[5].Width = 86;

            dgv_inadimplentes.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_inadimplentes.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_inadimplentes.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv_inadimplentes.Columns[3].DefaultCellStyle.Format = "C";

        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            ano_letivo = cb_ano.SelectedValue.ToString();

            if (cb_Filtrar.SelectedValue.ToString() != "TODAS")
            {
                var vcon = Banco.ConexaoBanco();
                string queryInadimplentes = String.Format(@"
            SELECT
                            tba.nome_aluno AS 'Aluno(a)',
                            DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL tbm.parcelas_pagas MONTH), INTERVAL -2 DAY) AS 'Venceu',
                            GREATEST(0, LEAST(
                                tbm.n_parcelas - tbm.parcelas_pagas, 
                                TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE())
                            )) AS 'Atrasadas',
                            tbm.valor_parcela * 
            IF(
                GREATEST(0, LEAST(
                    tbm.n_parcelas - tbm.parcelas_pagas, 
                    TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE())
                )) = 0, 
                1, 
                GREATEST(0, LEAST(
                    tbm.n_parcelas - tbm.parcelas_pagas, 
                    TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE())
                ))
            ) AS 'Receber',
                            tba.etapa AS 'Turma',
                            tba.telefone AS 'Telefone'
                        FROM
                            tb_mensalidades AS tbm
                        INNER JOIN
                            tb_alunos AS tba ON tba.ID_aluno = tbm.idaluno
                        WHERE
                            (TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE()) > 0
                            OR MONTH(DATE_ADD(tbm.data_inicio, INTERVAL tbm.parcelas_pagas MONTH)) = MONTH(CURDATE()))
                            AND YEAR(DATE_ADD(tbm.data_inicio, INTERVAL tbm.parcelas_pagas MONTH)) = {0}
                            AND tbm.ano_letivo = {0}
                            AND tba.etapa = '{1}' 
                            AND tbm.parcelas_pagas != tbm.n_parcelas
                        ORDER BY
                            tba.nome_aluno
            ", ano_letivo, cb_Filtrar.SelectedValue.ToString());

                dgv_inadimplentes.DataSource = Banco.dql(queryInadimplentes);

                DataTable dtTurmas = Banco.dql(queryInadimplentes);

                string nomeArquivo = Globais.caminho + @"\Inadimplentes.pdf";
                PdfWriter escritorPDF = new PdfWriter(nomeArquivo);
                PdfDocument pdf = new PdfDocument(escritorPDF);

                Document doc = new Document(pdf, PageSize.A4);

                // Use a fonte "times new roman" integrada
                PdfFont timesRoman = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
                doc.SetFont(timesRoman);

                // Restante do código...

                string dados = "";

                Paragraph paragrafo1 = new Paragraph("Mensalidades a Receber")
                    .SetFont(timesRoman)
                    .SetFontSize(25)
                    .SetBold()
                    .SetTextAlignment(TextAlignment.CENTER);

                Paragraph paragrafo2 = new Paragraph("Valor Total: " + lb_TOTAL.Text + "\n \n")
                    .SetFont(timesRoman)
                    .SetFontSize(12)
                    .SetBold();



                Table tabela = new Table(new float[] { 200, 50f, 25f, 60f, 70f, 70f })
                    .SetWidth(UnitValue.CreatePercentValue(100))
                    .SetFixedLayout()
                    .SetBorder(Border.NO_BORDER);

                // Restante do código...

                // Adicionar cabeçalhos da tabela
                tabela.AddHeaderCell(new Cell().Add(new Paragraph("Aluno")).SetFont(timesRoman).SetFontSize(10).SetBold().SetTextAlignment(TextAlignment.CENTER));
                tabela.AddHeaderCell(new Cell().Add(new Paragraph("Venceu")).SetFont(timesRoman).SetFontSize(10).SetBold().SetTextAlignment(TextAlignment.CENTER));
                tabela.AddHeaderCell(new Cell().Add(new Paragraph("A.")).SetFont(timesRoman).SetFontSize(10).SetBold().SetTextAlignment(TextAlignment.CENTER));
                tabela.AddHeaderCell(new Cell().Add(new Paragraph("Valor")).SetFont(timesRoman).SetFontSize(10).SetBold().SetTextAlignment(TextAlignment.CENTER));
                tabela.AddHeaderCell(new Cell().Add(new Paragraph("Turma")).SetFont(timesRoman).SetFontSize(10).SetBold().SetTextAlignment(TextAlignment.CENTER));
                tabela.AddHeaderCell(new Cell().Add(new Paragraph("Telefone")).SetFont(timesRoman).SetFontSize(10).SetBold().SetTextAlignment(TextAlignment.CENTER));


                // Adicionar os dados à tabela
                foreach (DataRow row in dtTurmas.Rows)
                {
                    Cell nomeAlunoCell = new Cell()
                    .Add(new Paragraph(row["Aluno(a)"].ToString()))
                    .SetFont(timesRoman)
                    .SetFontSize(10)
                    .SetWidth(50) // Definir largura da célula
                    .SetHeight(15); // Definir altura da célula
                    tabela.AddCell(nomeAlunoCell);


                    Cell VenceuCell = new Cell().Add(new Paragraph(Convert.ToDateTime(row["Venceu"]).ToString("dd/MM/yyyy")))
                    .SetFont(timesRoman)
                    .SetFontSize(10)
                    .SetWidth(20) // Definir largura da célula
                    .SetHeight(15) // Definir altura da célula
                    .SetTextAlignment(TextAlignment.CENTER);
                    tabela.AddCell(VenceuCell);

                    Cell AtrasadasCell = new Cell().Add(new Paragraph(row["Atrasadas"].ToString()))
                   .SetFont(timesRoman)
                   .SetFontSize(10)
                   .SetWidth(10) // Definir largura da célula
                   .SetHeight(15) // Definir altura da célula
                   .SetTextAlignment(TextAlignment.CENTER);
                    tabela.AddCell(AtrasadasCell);

                    Cell InadimplencaCell = new Cell().Add(new Paragraph(Convert.ToDecimal(row["Receber"]).ToString("C")))
                    .SetFont(timesRoman)
                    .SetFontSize(10)
                    .SetWidth(30) // Definir largura da célula
                    .SetHeight(15) // Definir altura da célula
                    .SetTextAlignment(TextAlignment.CENTER);
                    tabela.AddCell(InadimplencaCell);

                    Cell TurmaCell = new Cell().Add(new Paragraph(row["Turma"].ToString()))
                    .SetFont(timesRoman)
                    .SetFontSize(10)
                    .SetWidth(30) // Definir largura da célula
                    .SetHeight(15) // Definir altura da célula
                    .SetTextAlignment(TextAlignment.CENTER);
                    tabela.AddCell(TurmaCell);

                    Cell TelefoneCell = new Cell().Add(new Paragraph(row["Telefone"].ToString()))
                    .SetFont(timesRoman)
                    .SetFontSize(10)
                    .SetWidth(30) // Definir largura da célula
                    .SetHeight(15) // Definir altura da célula
                    .SetTextAlignment(TextAlignment.CENTER);
                    tabela.AddCell(TelefoneCell);


                }
                doc.Add(paragrafo1);
                doc.Add(paragrafo2);
                doc.Add(tabela);

                // Após fechar o documento, vamos editar o rodapé na última página
                PdfPage lastPage = pdf.GetLastPage(); // Pega a última página
                PdfCanvas canvas = new PdfCanvas(lastPage); // Cria o canvas para a última página

                // Após fechar o documento, vamos editar o rodapé
                canvas.BeginText();
                canvas.SetFontAndSize(timesRoman, 7);
                canvas.MoveText(300, 20); // Ajuste a posição no rodapé
                canvas.ShowText("Escola Infantil Ateniense - Master Escolar - BR3 Tecnologia © " + DateTime.Today.Year + "- Todos os direitos reservados. ");
                canvas.EndText();

                PdfPage FirstPage = pdf.GetFirstPage(); // Pega a Primeira página

                doc.Close();

                System.Diagnostics.Process.Start(Globais.caminho + @"\Inadimplentes.pdf");
            }

            else
            {
                var vcon = Banco.ConexaoBanco();
                string queryInadimplentes = String.Format(@"
                SELECT
                    tba.nome_aluno AS 'Aluno(a)',
                    DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL tbm.parcelas_pagas MONTH), INTERVAL -2 DAY) AS 'Venceu',
                    GREATEST(0, LEAST(
                        tbm.n_parcelas - tbm.parcelas_pagas, 
                        TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE())
                    )) AS 'Atrasadas',
                    tbm.valor_parcela * 
    IF(
        GREATEST(0, LEAST(
            tbm.n_parcelas - tbm.parcelas_pagas, 
            TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE())
        )) = 0, 
        1, 
        GREATEST(0, LEAST(
            tbm.n_parcelas - tbm.parcelas_pagas, 
            TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE())
        ))
    ) AS 'Receber',
                    tba.etapa AS 'Turma',
                    tba.telefone AS 'Telefone'
                FROM
                    tb_mensalidades AS tbm
                INNER JOIN
                    tb_alunos AS tba ON tba.ID_aluno = tbm.idaluno
                WHERE
                    (TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE()) > 0
                    OR MONTH(DATE_ADD(tbm.data_inicio, INTERVAL tbm.parcelas_pagas MONTH)) = MONTH(CURDATE()))
                    AND YEAR(DATE_ADD(tbm.data_inicio, INTERVAL tbm.parcelas_pagas MONTH)) = {0}
                    AND tbm.ano_letivo = {0}
                    AND tbm.parcelas_pagas != tbm.n_parcelas
                ORDER BY
                    tba.nome_aluno
            ", ano_letivo);

                dgv_inadimplentes.DataSource = Banco.dql(queryInadimplentes);
                DataTable dtTurmas = Banco.dql(queryInadimplentes);

                string nomeArquivo = Globais.caminho + @"\Inadimplentes.pdf";
                PdfWriter escritorPDF = new PdfWriter(nomeArquivo);
                PdfDocument pdf = new PdfDocument(escritorPDF);

                Document doc = new Document(pdf, PageSize.A4);

                // Use a fonte "times new roman" integrada
                PdfFont timesRoman = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
                doc.SetFont(timesRoman);

                // Restante do código...

                string dados = "";

                Paragraph paragrafo1 = new Paragraph("Mensalidades a Receber")
                    .SetFont(timesRoman)
                    .SetFontSize(25)
                    .SetBold()
                    .SetTextAlignment(TextAlignment.CENTER);

                Paragraph paragrafo2 = new Paragraph("Valor Total: " + lb_TOTAL.Text + "\n \n")
                    .SetFont(timesRoman)
                    .SetFontSize(12)
                    .SetBold();



                Table tabela = new Table(new float[] { 200f, 50f, 25f, 60f, 70f, 70f })
                    .SetWidth(UnitValue.CreatePercentValue(100))
                    .SetFixedLayout()
                    .SetBorder(Border.NO_BORDER);

                // Restante do código...

                // Adicionar cabeçalhos da tabela
                tabela.AddHeaderCell(new Cell().Add(new Paragraph("Aluno")).SetFont(timesRoman).SetFontSize(10).SetBold().SetTextAlignment(TextAlignment.CENTER));
                tabela.AddHeaderCell(new Cell().Add(new Paragraph("Venceu")).SetFont(timesRoman).SetFontSize(10).SetBold().SetTextAlignment(TextAlignment.CENTER));
                tabela.AddHeaderCell(new Cell().Add(new Paragraph("A.")).SetFont(timesRoman).SetFontSize(10).SetBold().SetTextAlignment(TextAlignment.CENTER));
                tabela.AddHeaderCell(new Cell().Add(new Paragraph("Valor")).SetFont(timesRoman).SetFontSize(10).SetBold().SetTextAlignment(TextAlignment.CENTER));
                tabela.AddHeaderCell(new Cell().Add(new Paragraph("Turma")).SetFont(timesRoman).SetFontSize(10).SetBold().SetTextAlignment(TextAlignment.CENTER));
                tabela.AddHeaderCell(new Cell().Add(new Paragraph("Telefone")).SetFont(timesRoman).SetFontSize(10).SetBold().SetTextAlignment(TextAlignment.CENTER));

                // Adicionar os dados à tabela
                foreach (DataRow row in dtTurmas.Rows)
                {
                    Cell nomeAlunoCell = new Cell()
                    .Add(new Paragraph(row["Aluno(a)"].ToString()))
                    .SetFont(timesRoman)
                    .SetFontSize(10)
                    .SetWidth(50) // Definir largura da célula
                    .SetHeight(15); // Definir altura da célula
                    tabela.AddCell(nomeAlunoCell);


                    Cell VenceuCell = new Cell().Add(new Paragraph(Convert.ToDateTime(row["Venceu"]).ToString("dd/MM/yyyy")))
                    .SetFont(timesRoman)
                    .SetFontSize(10)
                    .SetWidth(20) // Definir largura da célula
                    .SetHeight(15) // Definir altura da célula
                    .SetTextAlignment(TextAlignment.CENTER);
                    tabela.AddCell(VenceuCell);

                    Cell AtrasadasCell = new Cell().Add(new Paragraph(row["Atrasadas"].ToString()))
                   .SetFont(timesRoman)
                   .SetFontSize(10)
                   .SetWidth(10) // Definir largura da célula
                   .SetHeight(15) // Definir altura da célula
                   .SetTextAlignment(TextAlignment.CENTER);
                    tabela.AddCell(AtrasadasCell);

                    Cell InadimplencaCell = new Cell().Add(new Paragraph(Convert.ToDecimal(row["Receber"]).ToString("C")))
                    .SetFont(timesRoman)
                    .SetFontSize(10)
                    .SetWidth(30) // Definir largura da célula
                    .SetHeight(15) // Definir altura da célula
                    .SetTextAlignment(TextAlignment.CENTER);
                    tabela.AddCell(InadimplencaCell);

                    Cell TurmaCell = new Cell().Add(new Paragraph(row["Turma"].ToString()))
                    .SetFont(timesRoman)
                    .SetFontSize(10)
                    .SetWidth(30) // Definir largura da célula
                    .SetHeight(15) // Definir altura da célula
                    .SetTextAlignment(TextAlignment.CENTER);
                    tabela.AddCell(TurmaCell);

                    Cell TelefoneCell = new Cell().Add(new Paragraph(row["Telefone"].ToString()))
                    .SetFont(timesRoman)
                    .SetFontSize(10)
                    .SetWidth(30) // Definir largura da célula
                    .SetHeight(15) // Definir altura da célula
                    .SetTextAlignment(TextAlignment.CENTER);
                    tabela.AddCell(TelefoneCell);


                }
                doc.Add(paragrafo1);
                doc.Add(paragrafo2);
                doc.Add(tabela);

                // Após fechar o documento, vamos editar o rodapé na última página
                PdfPage lastPage = pdf.GetLastPage(); // Pega a última página
                PdfCanvas canvas = new PdfCanvas(lastPage); // Cria o canvas para a última página

                // Após fechar o documento, vamos editar o rodapé
                canvas.BeginText();
                canvas.SetFontAndSize(timesRoman, 7);
                canvas.MoveText(300, 20); // Ajuste a posição no rodapé
                canvas.ShowText("Escola Infantil Ateniense - Master Escolar - BR3 Tecnologia © " + DateTime.Today.Year + "- Todos os direitos reservados. ");
                canvas.EndText();

                PdfPage FirstPage = pdf.GetFirstPage(); // Pega a Primeira página

                doc.Close();

                System.Diagnostics.Process.Start(Globais.caminho + @"\Inadimplentes.pdf");
            }
        }

        private void cb_Filtrar_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ano_letivo = cb_ano.SelectedValue.ToString();

            if (cb_Filtrar.SelectedValue.ToString() != "TODAS")
            {
            var vcon = Banco.ConexaoBanco();
                string queryInadimplentes = String.Format(@"
            SELECT
                            tba.nome_aluno AS 'Aluno(a)',
                            DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL tbm.parcelas_pagas MONTH), INTERVAL -2 DAY) AS 'Venceu',
                            GREATEST(0, LEAST(
                                tbm.n_parcelas - tbm.parcelas_pagas, 
                                TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE())
                            )) AS 'Atrasadas',
                            tbm.valor_parcela * 
            IF(
                GREATEST(0, LEAST(
                    tbm.n_parcelas - tbm.parcelas_pagas, 
                    TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE())
                )) = 0, 
                1, 
                GREATEST(0, LEAST(
                    tbm.n_parcelas - tbm.parcelas_pagas, 
                    TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE())
                ))
            ) AS 'Receber',
                            tba.etapa AS 'Turma',
                            tba.telefone AS 'Telefone'
                        FROM
                            tb_mensalidades AS tbm
                        INNER JOIN
                            tb_alunos AS tba ON tba.ID_aluno = tbm.idaluno
                        WHERE
                            (TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE()) > 0
                            OR MONTH(DATE_ADD(tbm.data_inicio, INTERVAL tbm.parcelas_pagas MONTH)) = MONTH(CURDATE()))
                            AND YEAR(DATE_ADD(tbm.data_inicio, INTERVAL tbm.parcelas_pagas MONTH)) = {0}
                            AND tbm.ano_letivo = {0}
                            AND tba.etapa = '{1}' 
                            AND tbm.parcelas_pagas != tbm.n_parcelas
                        ORDER BY
                            tba.nome_aluno
            ", ano_letivo, cb_Filtrar.SelectedValue.ToString());

                dgv_inadimplentes.DataSource = Banco.dql(queryInadimplentes);

                decimal total = 0;

                foreach (DataGridViewRow row in dgv_inadimplentes.Rows)
                {
                    // Verificar se a célula na coluna 2 existe
                    if (row.Cells.Count > 2 && row.Cells[3].Value != null && decimal.TryParse(row.Cells[3].Value.ToString(), out decimal valorParcela))
                    {
                        total += valorParcela;
                    }
                }

                lb_TOTAL.Text = total.ToString("C2");

                dgv_inadimplentes.Columns[0].Width = 256;
                dgv_inadimplentes.Columns[1].Width = 70;
                dgv_inadimplentes.Columns[2].Width = 70;
                dgv_inadimplentes.Columns[3].Width = 90;
                dgv_inadimplentes.Columns[4].Width = 70;
                dgv_inadimplentes.Columns[5].Width = 86;

                dgv_inadimplentes.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_inadimplentes.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_inadimplentes.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_inadimplentes.Columns[3].DefaultCellStyle.Format = "C";

            }
            else
            {
                var vcon = Banco.ConexaoBanco();
                string queryInadimplentes = String.Format(@"
                SELECT
                                tba.nome_aluno AS 'Aluno(a)',
                                DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL tbm.parcelas_pagas MONTH), INTERVAL -2 DAY) AS 'Venceu',
                                GREATEST(0, LEAST(
                                    tbm.n_parcelas - tbm.parcelas_pagas, 
                                    TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE())
                                )) AS 'Atrasadas',
                                tbm.valor_parcela * 
                IF(
                    GREATEST(0, LEAST(
                        tbm.n_parcelas - tbm.parcelas_pagas, 
                        TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE())
                    )) = 0, 
                    1, 
                    GREATEST(0, LEAST(
                        tbm.n_parcelas - tbm.parcelas_pagas, 
                        TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE())
                    ))
                ) AS 'Receber',
                                tba.etapa AS 'Turma',
                                tba.telefone AS 'Telefone'
                            FROM
                                tb_mensalidades AS tbm
                            INNER JOIN
                                tb_alunos AS tba ON tba.ID_aluno = tbm.idaluno
                            WHERE
                                (TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE()) > 0
                                OR MONTH(DATE_ADD(tbm.data_inicio, INTERVAL tbm.parcelas_pagas MONTH)) = MONTH(CURDATE()))
                                AND YEAR(DATE_ADD(tbm.data_inicio, INTERVAL tbm.parcelas_pagas MONTH)) = {0}
                                AND tbm.ano_letivo = {0}
                                AND tbm.parcelas_pagas != tbm.n_parcelas
                            ORDER BY
                                tba.nome_aluno
            ", ano_letivo);

                dgv_inadimplentes.DataSource = Banco.dql(queryInadimplentes);

                decimal total = 0;

                foreach (DataGridViewRow row in dgv_inadimplentes.Rows)
                {
                    // Verificar se a célula na coluna 2 existe
                    if (row.Cells.Count > 2 && row.Cells[3].Value != null && decimal.TryParse(row.Cells[3].Value.ToString(), out decimal valorParcela))
                    {
                        total += valorParcela;
                    }
                }

                lb_TOTAL.Text = total.ToString("C2");

                dgv_inadimplentes.Columns[0].Width = 256;
                dgv_inadimplentes.Columns[1].Width = 70;
                dgv_inadimplentes.Columns[2].Width = 70;
                dgv_inadimplentes.Columns[3].Width = 90;
                dgv_inadimplentes.Columns[4].Width = 70;
                dgv_inadimplentes.Columns[5].Width = 86;

                dgv_inadimplentes.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_inadimplentes.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_inadimplentes.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_inadimplentes.Columns[3].DefaultCellStyle.Format = "C";
            }
        }

        private void cb_ano_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ano_letivo = cb_ano.SelectedValue.ToString();

            if (cb_Filtrar.SelectedValue.ToString() != "TODAS")
            {
                var vcon = Banco.ConexaoBanco();
                string queryInadimplentes = String.Format(@"
            SELECT
                            tba.nome_aluno AS 'Aluno(a)',
                            DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL tbm.parcelas_pagas MONTH), INTERVAL -2 DAY) AS 'Venceu',
                            GREATEST(0, LEAST(
                                tbm.n_parcelas - tbm.parcelas_pagas, 
                                TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE())
                            )) AS 'Atrasadas',
                            tbm.valor_parcela * 
            IF(
                GREATEST(0, LEAST(
                    tbm.n_parcelas - tbm.parcelas_pagas, 
                    TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE())
                )) = 0, 
                1, 
                GREATEST(0, LEAST(
                    tbm.n_parcelas - tbm.parcelas_pagas, 
                    TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE())
                ))
            ) AS 'Receber',
                            tba.etapa AS 'Turma',
                            tba.telefone AS 'Telefone'
                        FROM
                            tb_mensalidades AS tbm
                        INNER JOIN
                            tb_alunos AS tba ON tba.ID_aluno = tbm.idaluno
                        WHERE
                            (TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE()) > 0
                            OR MONTH(DATE_ADD(tbm.data_inicio, INTERVAL tbm.parcelas_pagas MONTH)) = MONTH(CURDATE()))
                            AND YEAR(DATE_ADD(tbm.data_inicio, INTERVAL tbm.parcelas_pagas MONTH)) = {0}
                            AND tbm.ano_letivo = {0}
                            AND tba.etapa = '{1}' 
                            AND tbm.parcelas_pagas != tbm.n_parcelas
                        ORDER BY
                            tba.nome_aluno
            ", ano_letivo, cb_Filtrar.SelectedValue.ToString());

                dgv_inadimplentes.DataSource = Banco.dql(queryInadimplentes);

                decimal total = 0;

                foreach (DataGridViewRow row in dgv_inadimplentes.Rows)
                {
                    // Verificar se a célula na coluna 2 existe
                    if (row.Cells.Count > 2 && row.Cells[3].Value != null && decimal.TryParse(row.Cells[3].Value.ToString(), out decimal valorParcela))
                    {
                        total += valorParcela;
                    }
                }

                lb_TOTAL.Text = total.ToString("C2");

                dgv_inadimplentes.Columns[0].Width = 256;
                dgv_inadimplentes.Columns[1].Width = 70;
                dgv_inadimplentes.Columns[2].Width = 70;
                dgv_inadimplentes.Columns[3].Width = 90;
                dgv_inadimplentes.Columns[4].Width = 70;
                dgv_inadimplentes.Columns[5].Width = 86;

                dgv_inadimplentes.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_inadimplentes.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_inadimplentes.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_inadimplentes.Columns[3].DefaultCellStyle.Format = "C";

            }
            else
            {
                var vcon = Banco.ConexaoBanco();
                string queryInadimplentes = String.Format(@"
                SELECT
                                tba.nome_aluno AS 'Aluno(a)',
                                DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL tbm.parcelas_pagas MONTH), INTERVAL -2 DAY) AS 'Venceu',
                                GREATEST(0, LEAST(
                                    tbm.n_parcelas - tbm.parcelas_pagas, 
                                    TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE())
                                )) AS 'Atrasadas',
                                tbm.valor_parcela * 
                IF(
                    GREATEST(0, LEAST(
                        tbm.n_parcelas - tbm.parcelas_pagas, 
                        TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE())
                    )) = 0, 
                    1, 
                    GREATEST(0, LEAST(
                        tbm.n_parcelas - tbm.parcelas_pagas, 
                        TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE())
                    ))
                ) AS 'Receber',
                                tba.etapa AS 'Turma',
                                tba.telefone AS 'Telefone'
                            FROM
                                tb_mensalidades AS tbm
                            INNER JOIN
                                tb_alunos AS tba ON tba.ID_aluno = tbm.idaluno
                            WHERE
                                (TIMESTAMPDIFF(MONTH, DATE_ADD(DATE_ADD(tbm.data_inicio, INTERVAL -2 DAY), INTERVAL tbm.parcelas_pagas - 1 MONTH), CURDATE()) > 0
                                OR MONTH(DATE_ADD(tbm.data_inicio, INTERVAL tbm.parcelas_pagas MONTH)) = MONTH(CURDATE()))
                                AND YEAR(DATE_ADD(tbm.data_inicio, INTERVAL tbm.parcelas_pagas MONTH)) = {0}
                                AND tbm.ano_letivo = {0}
                                AND tbm.parcelas_pagas != tbm.n_parcelas
                            ORDER BY
                                tba.nome_aluno
            ", ano_letivo);

                dgv_inadimplentes.DataSource = Banco.dql(queryInadimplentes);

                decimal total = 0;

                foreach (DataGridViewRow row in dgv_inadimplentes.Rows)
                {
                    // Verificar se a célula na coluna 2 existe
                    if (row.Cells.Count > 2 && row.Cells[3].Value != null && decimal.TryParse(row.Cells[3].Value.ToString(), out decimal valorParcela))
                    {
                        total += valorParcela;
                    }
                }

                lb_TOTAL.Text = total.ToString("C2");

                dgv_inadimplentes.Columns[0].Width = 256;
                dgv_inadimplentes.Columns[1].Width = 70;
                dgv_inadimplentes.Columns[2].Width = 70;
                dgv_inadimplentes.Columns[3].Width = 90;
                dgv_inadimplentes.Columns[4].Width = 70;
                dgv_inadimplentes.Columns[5].Width = 86;

                dgv_inadimplentes.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_inadimplentes.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_inadimplentes.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_inadimplentes.Columns[3].DefaultCellStyle.Format = "C";
            }
        }
    }
}
