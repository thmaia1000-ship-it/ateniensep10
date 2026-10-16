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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Caixa
{
    public partial class F_Inadimplencia : Form
    {
        public F_Inadimplencia()
        {
            InitializeComponent();
        }

        int data;



        private void F_Inadimplencia_Load(object sender, EventArgs e)
        {

            Dictionary<string, string> ano = new Dictionary<string, string>();

            ano.Add("2023", "2023");
            ano.Add("2024", "2024");
            ano.Add("2025", "2025");
            ano.Add("2026", "2026");
            ano.Add("2027", "2027");
            ano.Add("2028", "2028");
            ano.Add("2029", "2029");
            ano.Add("2030", "2030");
            cb_ano.DataSource = new BindingSource(ano, null);
            cb_ano.DisplayMember = "Value";
            cb_ano.ValueMember = "Key";

            cb_ano.SelectedValue = DateTime.Now.ToString("yyyy");

            var vcon = Banco.ConexaoBanco();
            string queryInadimplentes = String.Format(@"
             SELECT 
            tba.nome_aluno AS Aluno,
            DATE_ADD(tbm.data_inicio, INTERVAL tbm.parcelas_pagas DAY) AS Venceu,
            CASE 
                WHEN tbm.ano_letivo = 2023 THEN GREATEST(TIMESTAMPDIFF(MONTH, tbm.data_inicio, NOW()) - tbm.parcelas_pagas, 0)
                WHEN tbm.ano_letivo = 2024 THEN GREATEST(TIMESTAMPDIFF(MONTH, tbm.data_inicio, NOW()) - tbm.parcelas_pagas + 1, 0)
                ELSE 0
            END AS Atrasadas,
            tbm.valor_parcela * CASE 
                WHEN tbm.ano_letivo = 2023 THEN GREATEST(TIMESTAMPDIFF(MONTH, tbm.data_inicio, NOW()) - tbm.parcelas_pagas, 0)
                WHEN tbm.ano_letivo = 2024 THEN GREATEST(TIMESTAMPDIFF(MONTH, tbm.data_inicio, NOW()) - tbm.parcelas_pagas + 1, 0)
                ELSE 0
            END AS Inadimplencia,
            tba.telefone AS Telefone
        FROM 
            tb_mensalidades AS tbm
        INNER JOIN tb_alunos AS tba ON tba.ID_aluno = tbm.idaluno
        WHERE 
            DATE_ADD(tbm.data_inicio, INTERVAL tbm.parcelas_pagas MONTH) < NOW()
            AND TIMESTAMPDIFF(MONTH, tbm.data_inicio, NOW()) >= tbm.parcelas_pagas
            AND tbm.ano_letivo = {0}
            AND tbm.n_parcelas != tbm.parcelas_pagas
        ORDER BY Venceu", cb_ano.SelectedValue.ToString());

            dgv_inadimplentes.DataSource = Banco.dql(queryInadimplentes);

            // Variável para armazenar o total
            decimal totalInadimplentes = 0;

            // Loop através das linhas do DataGridView
            foreach (DataGridViewRow row in dgv_inadimplentes.Rows)
            {
                // Verifica se a linha não é nova (em caso de um DataGridView editável)
                if (!row.IsNewRow)
                {
                    // Tenta converter o valor da coluna [3] para decimal e adiciona ao total
                    if (decimal.TryParse(row.Cells[3].Value.ToString(), out decimal valor))
                    {
                        totalInadimplentes += valor;
                    }
                }
            }

            // Define o valor total no label com a formatação de moeda
            lb_TOTAL.Text = totalInadimplentes.ToString("C2");


            dgv_inadimplentes.Columns[0].Width = 210;
            dgv_inadimplentes.Columns[1].Width = 75;
            dgv_inadimplentes.Columns[2].Width = 70;
            dgv_inadimplentes.Columns[3].Width = 100;
            dgv_inadimplentes.Columns[4].Width = 86;

            dgv_inadimplentes.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_inadimplentes.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_inadimplentes.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv_inadimplentes.Columns[3].DefaultCellStyle.Format = "C";
        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            var vcon = Banco.ConexaoBanco();
            string queryInadimplentes = String.Format(@"
             SELECT 
            tba.nome_aluno AS Aluno,
            DATE_ADD(tbm.data_inicio, INTERVAL tbm.parcelas_pagas DAY) AS Venceu,
            CASE 
                WHEN tbm.ano_letivo = 2023 THEN GREATEST(TIMESTAMPDIFF(MONTH, tbm.data_inicio, NOW()) - tbm.parcelas_pagas, 0)
                WHEN tbm.ano_letivo = 2024 THEN GREATEST(TIMESTAMPDIFF(MONTH, tbm.data_inicio, NOW()) - tbm.parcelas_pagas + 1, 0)
                ELSE 0
            END AS Atrasadas,
            tbm.valor_parcela * CASE 
                WHEN tbm.ano_letivo = 2023 THEN GREATEST(TIMESTAMPDIFF(MONTH, tbm.data_inicio, NOW()) - tbm.parcelas_pagas, 0)
                WHEN tbm.ano_letivo = 2024 THEN GREATEST(TIMESTAMPDIFF(MONTH, tbm.data_inicio, NOW()) - tbm.parcelas_pagas + 1, 0)
                ELSE 0
            END AS Inadimplencia,
            tba.telefone AS Telefone
        FROM 
            tb_mensalidades AS tbm
        INNER JOIN tb_alunos AS tba ON tba.ID_aluno = tbm.idaluno
        WHERE 
            DATE_ADD(tbm.data_inicio, INTERVAL tbm.parcelas_pagas MONTH) < NOW()
            AND TIMESTAMPDIFF(MONTH, tbm.data_inicio, NOW()) >= tbm.parcelas_pagas
            AND tbm.ano_letivo = {0}
            AND tbm.n_parcelas != tbm.parcelas_pagas
        ORDER BY Venceu", cb_ano.SelectedValue.ToString());

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

            Paragraph paragrafo1 = new Paragraph("Inadimplência")
                .SetFont(timesRoman)
                .SetFontSize(25)
                .SetBold()
                .SetTextAlignment(TextAlignment.CENTER);

            Paragraph paragrafo2 = new Paragraph("Valor Total: " + lb_TOTAL.Text + "\n \n")
                .SetFont(timesRoman)
                .SetFontSize(12)
                .SetBold();



            Table tabela = new Table(new float[] { 270f, 50f, 25f, 60f, 70f})
                .SetWidth(UnitValue.CreatePercentValue(100))
                .SetFixedLayout()
                .SetBorder(Border.NO_BORDER);

            // Restante do código...

            // Adicionar os dados à tabela
            foreach (DataRow row in dtTurmas.Rows)
            {
                Cell nomeAlunoCell = new Cell()
                .Add(new Paragraph(row["Aluno"].ToString()))
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

                Cell InadimplencaCell = new Cell().Add(new Paragraph(Convert.ToDecimal(row["Inadimplencia"]).ToString("C")))
                .SetFont(timesRoman)
                .SetFontSize(10)
                .SetWidth(30) // Definir largura da célula
                .SetHeight(15) // Definir altura da célula
                .SetTextAlignment(TextAlignment.CENTER);
                tabela.AddCell(InadimplencaCell);

                

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

            doc.Close();

            System.Diagnostics.Process.Start(Globais.caminho + @"\Inadimplentes.pdf");

        }

        private void cb_ano_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var vcon = Banco.ConexaoBanco();
            string queryInadimplentes = String.Format(@"
            
             SELECT 
            tba.nome_aluno AS Aluno,
            DATE_ADD(tbm.data_inicio, INTERVAL tbm.parcelas_pagas DAY) AS Venceu,
            CASE 
                WHEN tbm.ano_letivo = 2023 THEN GREATEST(TIMESTAMPDIFF(MONTH, tbm.data_inicio, NOW()) - tbm.parcelas_pagas, 0)
                WHEN tbm.ano_letivo = 2024 THEN GREATEST(TIMESTAMPDIFF(MONTH, tbm.data_inicio, NOW()) - tbm.parcelas_pagas + 1, 0)
                ELSE 0
            END AS Atrasadas,
            tbm.valor_parcela * CASE 
                WHEN tbm.ano_letivo = 2023 THEN GREATEST(TIMESTAMPDIFF(MONTH, tbm.data_inicio, NOW()) - tbm.parcelas_pagas, 0)
                WHEN tbm.ano_letivo = 2024 THEN GREATEST(TIMESTAMPDIFF(MONTH, tbm.data_inicio, NOW()) - tbm.parcelas_pagas + 1, 0)
                ELSE 0
            END AS Inadimplencia,
            tba.telefone AS Telefone
        FROM 
            tb_mensalidades AS tbm
        INNER JOIN tb_alunos AS tba ON tba.ID_aluno = tbm.idaluno
        WHERE 
            DATE_ADD(tbm.data_inicio, INTERVAL tbm.parcelas_pagas MONTH) < NOW()
            AND TIMESTAMPDIFF(MONTH, tbm.data_inicio, NOW()) >= tbm.parcelas_pagas
            AND tbm.ano_letivo = {0}
            AND tbm.n_parcelas != tbm.parcelas_pagas
        ORDER BY Venceu", cb_ano.SelectedValue.ToString());

            dgv_inadimplentes.DataSource = Banco.dql(queryInadimplentes);
            // Variável para armazenar o total
            decimal totalInadimplentes = 0;

            // Loop através das linhas do DataGridView
            foreach (DataGridViewRow row in dgv_inadimplentes.Rows)
            {
                // Verifica se a linha não é nova (em caso de um DataGridView editável)
                if (!row.IsNewRow)
                {
                    // Tenta converter o valor da coluna [3] para decimal e adiciona ao total
                    if (decimal.TryParse(row.Cells[3].Value.ToString(), out decimal valor))
                    {
                        totalInadimplentes += valor;
                    }
                }
            }

            // Define o valor total no label com a formatação de moeda
            lb_TOTAL.Text = totalInadimplentes.ToString("C2");


            dgv_inadimplentes.Columns[0].Width = 210;
            dgv_inadimplentes.Columns[1].Width = 75;
            dgv_inadimplentes.Columns[2].Width = 70;
            dgv_inadimplentes.Columns[3].Width = 100;
            dgv_inadimplentes.Columns[4].Width = 86;

            dgv_inadimplentes.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_inadimplentes.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_inadimplentes.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv_inadimplentes.Columns[3].DefaultCellStyle.Format = "C";
        }
    }
}
