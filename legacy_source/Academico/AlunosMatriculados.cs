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
using iText.Kernel.Colors;

namespace Escolar.Academico
{
    public partial class AlunosMatriculados : Form
    {
        public AlunosMatriculados()
        {
            InitializeComponent();
        }

        private void AlunosMatriculados_Load(object sender, EventArgs e)
        {
            cb_ano.Text = DateTime.Now.ToString("yyyy");

            var vcon = Banco.ConexaoBanco();
            string queryAlunos = String.Format(@"SELECT tba.nome_aluno as 'Aluno(a)', tba.etapa as 'Serie', tba.data_gerada as 'Data Matricula' FROM tb_mensalidades as tbm INNER JOIN tb_alunos as tba ON tba.ID_aluno = tbm.idaluno WHERE tbm.ano_letivo ={0} AND tba.status = '{1}' ORDER BY etapa,nome_aluno", cb_ano.Text, "ATIVO");

            dgv_Alunos.DataSource = Banco.dql(queryAlunos);

            string TotalAlunos = String.Format(@"SELECT count(*) as 'Total' FROM tb_mensalidades as tbm INNER JOIN tb_alunos as tba ON tba.ID_aluno = tbm.idaluno WHERE tbm.ano_letivo ={0} AND tba.status = '{1}'", cb_ano.Text, "ATIVO");

            DataTable dt = Banco.dql(TotalAlunos);

            lb_TotalAlunos.Text = dt.Rows[0].Field<Int64>("total").ToString();

            dgv_Alunos.Columns[0].Width = 548;
            dgv_Alunos.Columns[1].Width = 150;
            dgv_Alunos.Columns[2].Width = 130;

            dgv_Alunos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Alunos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void cb_ano_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var vcon = Banco.ConexaoBanco();
            string queryAlunos = String.Format(@"SELECT tba.nome_aluno as 'Aluno(a)', tba.etapa as 'Serie', tba.data_gerada as 'Data Matricula' FROM tb_mensalidades as tbm INNER JOIN tb_alunos as tba ON tba.ID_aluno = tbm.idaluno WHERE tbm.ano_letivo ={0} AND tba.status = '{1}' ORDER BY etapa,nome_aluno", cb_ano.Text, "ATIVO");

            dgv_Alunos.DataSource = Banco.dql(queryAlunos);

            string TotalAlunos = String.Format(@"SELECT count(*) as 'Total' FROM tb_mensalidades as tbm INNER JOIN tb_alunos as tba ON tba.ID_aluno = tbm.idaluno WHERE tbm.ano_letivo ={0} AND tba.status = '{1}' ORDER BY etapa,nome_aluno", cb_ano.Text, "ATIVO");

            DataTable dt = Banco.dql(TotalAlunos);

            lb_TotalAlunos.Text = dt.Rows[0].Field<Int64>("total").ToString();

            dgv_Alunos.Columns[0].Width = 548;
            dgv_Alunos.Columns[1].Width = 150;
            dgv_Alunos.Columns[2].Width = 130;

            dgv_Alunos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Alunos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            var vcon = Banco.ConexaoBanco();
            string queryAlunos = String.Format(@"SELECT tba.nome_aluno, tba.etapa, tba.data_gerada FROM tb_mensalidades as tbm INNER JOIN tb_alunos as tba ON tba.ID_aluno = tbm.idaluno WHERE tbm.ano_letivo ={0} AND tba.status = '{1}' ORDER BY etapa,nome_aluno", cb_ano.Text, "ATIVO");

            DataTable dtTurmas = Banco.dql(queryAlunos);

            // Suas consultas para contar alunos por turma permanecem iguais
            string TotalMaternalI = String.Format(@"SELECT count(*) as 'Total' FROM tb_mensalidades as tbm INNER JOIN tb_alunos as tba ON tba.ID_aluno = tbm.idaluno WHERE tbm.ano_letivo ={0} AND tba.status = 'ATIVO' AND etapa = 'MATERNAL I'", cb_ano.Text);
            string TotalMaternalII = String.Format(@"SELECT count(*) as 'Total' FROM tb_mensalidades as tbm INNER JOIN tb_alunos as tba ON tba.ID_aluno = tbm.idaluno WHERE tbm.ano_letivo ={0} AND tba.status = 'ATIVO' AND etapa = 'MATERNAL II'", cb_ano.Text);
            string TotalJardimI = String.Format(@"SELECT count(*) as 'Total' FROM tb_mensalidades as tbm INNER JOIN tb_alunos as tba ON tba.ID_aluno = tbm.idaluno WHERE tbm.ano_letivo ={0} AND tba.status = 'ATIVO' AND etapa = 'JARDIM I'", cb_ano.Text);
            string TotalJardimII = String.Format(@"SELECT count(*) as 'Total' FROM tb_mensalidades as tbm INNER JOIN tb_alunos as tba ON tba.ID_aluno = tbm.idaluno WHERE tbm.ano_letivo ={0} AND tba.status = 'ATIVO' AND etapa = 'JARDIM II'", cb_ano.Text);
            string Total1Ano = String.Format(@"SELECT count(*) as 'Total' FROM tb_mensalidades as tbm INNER JOIN tb_alunos as tba ON tba.ID_aluno = tbm.idaluno WHERE tbm.ano_letivo ={0} AND tba.status = 'ATIVO' AND etapa = '1º ANO'", cb_ano.Text);

            DataTable totalMaternalI = Banco.dql(TotalMaternalI);
            DataTable totalMaternalII = Banco.dql(TotalMaternalII);
            DataTable totalJardimI = Banco.dql(TotalJardimI);
            DataTable totalJardimII = Banco.dql(TotalJardimII);
            DataTable total1Ano = Banco.dql(Total1Ano);

            Int64 MATERNALI = totalMaternalI.Rows[0].Field<Int64>("total");
            Int64 MATERNALII = totalMaternalII.Rows[0].Field<Int64>("total");
            Int64 JARDIMI = totalJardimI.Rows[0].Field<Int64>("total");
            Int64 JARDIMII = totalJardimII.Rows[0].Field<Int64>("total");
            Int64 ANO = total1Ano.Rows[0].Field<Int64>("total");

            string nomeArquivo = Globais.caminho + @"\Alunos.pdf";
            PdfWriter escritorPDF = new PdfWriter(nomeArquivo);
            PdfDocument pdf = new PdfDocument(escritorPDF);

            Document doc = new Document(pdf, PageSize.A4);

            // Use a fonte "times new roman" integrada
            PdfFont timesRoman = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
            doc.SetFont(timesRoman);

            string dados = "";

            Paragraph paragrafo1 = new Paragraph("Alunos Matrículados")
                .SetFont(timesRoman)
                .SetFontSize(25)
                .SetBold()
                .SetTextAlignment(TextAlignment.CENTER);

            Paragraph paragrafo2 = new Paragraph("Total Alunos: " + lb_TotalAlunos.Text + "\n \n")
                .SetFont(timesRoman)
                .SetFontSize(12)
                .SetBold();

            Table tabela = new Table(new float[] { 300f, 60f, 55f })
                .SetWidth(UnitValue.CreatePercentValue(100))
                .SetFixedLayout()
                .SetBorder(Border.NO_BORDER);

            // Variável para controlar a turma atual
            string turmaAtual = "";
            bool primeiraLinha = true;

            foreach (DataRow row in dtTurmas.Rows)
            {
                string etapaAtual = row["etapa"].ToString();

                // Se mudou de turma, adiciona o cabeçalho da nova turma
                if (etapaAtual != turmaAtual)
                {
                    turmaAtual = etapaAtual;

                    // Se não for a primeira linha, adiciona uma linha em branco para separar
                    if (!primeiraLinha)
                    {
                        AddEmptyRow(tabela, timesRoman);
                    }
                    primeiraLinha = false;

                    // Adiciona o cabeçalho da turma
                    AddTurmaHeader(tabela, turmaAtual, GetTotalTurma(turmaAtual, ANO, JARDIMI, JARDIMII, MATERNALI, MATERNALII), timesRoman);
                }

                // Adiciona os dados do aluno
                Cell nomeAlunoCell = new Cell()
                    .Add(new Paragraph(row["nome_aluno"].ToString()))
                    .SetFont(timesRoman)
                    .SetFontSize(10)
                    .SetWidth(50)
                    .SetHeight(15);
                tabela.AddCell(nomeAlunoCell);

                Cell EtapaCell = new Cell().Add(new Paragraph(etapaAtual))
                    .SetFont(timesRoman)
                    .SetFontSize(10)
                    .SetWidth(10)
                    .SetHeight(15)
                    .SetTextAlignment(TextAlignment.CENTER);
                tabela.AddCell(EtapaCell);

                Cell DataCell = new Cell().Add(new Paragraph(Convert.ToDateTime(row["data_gerada"]).ToString("dd/MM/yyyy")))
                    .SetFont(timesRoman)
                    .SetFontSize(10)
                    .SetWidth(20)
                    .SetHeight(15)
                    .SetTextAlignment(TextAlignment.CENTER);
                tabela.AddCell(DataCell);
            }

            doc.Add(paragrafo1);
            doc.Add(paragrafo2);
            doc.Add(tabela);
            doc.Close();

            System.Diagnostics.Process.Start(Globais.caminho + @"\Alunos.pdf");
        }

        // Método auxiliar para adicionar cabeçalho de turma
        private void AddTurmaHeader(Table tabela, string turma, Int64 total, PdfFont timesRoman)
        {
            string textoHeader = $"QUANTIDADE {turma}: {total} ";

            // Preenche com # até completar a linha
            while (textoHeader.Length < 80) // Ajuste este valor conforme necessário
            {
                textoHeader += "#";
            }

            Cell headerCell = new Cell(1, 3) // Mescla 3 colunas
                .Add(new Paragraph(textoHeader))
                .SetFont(timesRoman)
                .SetFontSize(10)
                .SetBold()
                .SetTextAlignment(TextAlignment.CENTER)
                .SetBackgroundColor(ColorConstants.LIGHT_GRAY); // Opcional: destaque visual
            tabela.AddCell(headerCell);
        }

        // Método auxiliar para adicionar linha vazia
        private void AddEmptyRow(Table tabela, PdfFont timesRoman)
        {
            Cell emptyCell1 = new Cell().Add(new Paragraph(""))
                .SetFont(timesRoman)
                .SetFontSize(10)
                .SetWidth(50)
                .SetHeight(5);
            tabela.AddCell(emptyCell1);

            Cell emptyCell2 = new Cell().Add(new Paragraph(""))
                .SetFont(timesRoman)
                .SetFontSize(10)
                .SetWidth(10)
                .SetHeight(5);
            tabela.AddCell(emptyCell2);

            Cell emptyCell3 = new Cell().Add(new Paragraph(""))
                .SetFont(timesRoman)
                .SetFontSize(10)
                .SetWidth(20)
                .SetHeight(5);
            tabela.AddCell(emptyCell3);

        }

        // Método auxiliar para obter o total de cada turma
        private Int64 GetTotalTurma(string turma, Int64 ANO, Int64 JARDIMI, Int64 JARDIMII, Int64 MATERNALI, Int64 MATERNALII)
        {
            switch (turma)
            {
                case "1º ANO": return ANO;
                case "JARDIM I": return JARDIMI;
                case "JARDIM II": return JARDIMII;
                case "MATERNAL I": return MATERNALI;
                case "MATERNAL II": return MATERNALII;
                default: return 0;
            }
        }
    }
}
