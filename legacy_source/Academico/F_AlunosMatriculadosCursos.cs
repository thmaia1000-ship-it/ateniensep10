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

namespace Escolar.Academico
{
    public partial class F_AlunosMatriculadosCursos : Form
    {
        public F_AlunosMatriculadosCursos()
        {
            InitializeComponent();
        }

        private void F_AlunosMatriculadosCursos_Load(object sender, EventArgs e)
        {

            Dictionary<string, string> ano_letivo = new Dictionary<string, string>();

            ano_letivo.Add("2023", "2023");
            ano_letivo.Add("2024", "2024");
            ano_letivo.Add("2025", "2025");
            ano_letivo.Add("2026", "2026");
            ano_letivo.Add("2027", "2027");
            ano_letivo.Add("2028", "2028");
            ano_letivo.Add("2029", "2029");
            ano_letivo.Add("2030", "2030");
            ano_letivo.Add("2031", "2031");
            ano_letivo.Add("2032", "2032");
            cb_ano.DataSource = new BindingSource(ano_letivo, null);
            cb_ano.DisplayMember = "Value";
            cb_ano.ValueMember = "Key";

            cb_ano.SelectedValue = DateTime.Now.ToString("yyyy");

            var vcon = Banco.ConexaoBanco();
            string queryAlunos = String.Format(@"SELECT 
                                                tba.nome_aluno,
                                                tbc.nome_curso, 
                                                tbmc.data_gerada 
                                                FROM tb_alunos as tba,
                                                tb_mensalidades_cursos as tbmc,
                                                tb_cursos as tbc
                                                WHERE tbmc.idaluno = tba.ID_aluno
                                                AND tbmc.curso = tbc.ID_curso AND tbmc.ano_letivo={0}
                                                ORDER BY tbc.nome_curso,tba.nome_aluno", cb_ano.SelectedValue);

            dgv_Alunos.DataSource = Banco.dql(queryAlunos);

            string TotalAlunos = String.Format(@"SELECT count(*) as 'Total' FROM tb_alunos as tba,tb_mensalidades_cursos as tbmc WHERE tbmc.idaluno = tba.ID_aluno AND tbmc.ano_letivo={0}", cb_ano.SelectedValue);

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
            string queryAlunos = String.Format(@"
                    SELECT 
                    tba.nome_aluno,
                    tbc.nome_curso, 
                    tbmc.data_gerada 
                    FROM tb_alunos as tba,
                    tb_mensalidades_cursos as tbmc,
                    tb_cursos as tbc
                    WHERE tbmc.idaluno = tba.ID_aluno
                    AND tbmc.curso = tbc.ID_curso AND tbmc.ano_letivo={0}
                    ORDER BY tbc.nome_curso,tba.nome_aluno", cb_ano.SelectedValue);
            DataTable dtTurmas = Banco.dql(queryAlunos);

            string TotalDanca = String.Format(@"SELECT count(*) as 'Total' FROM tb_mensalidades_cursos as tbmc WHERE tbmc.curso = 3 AND tbmc.ano_letivo={0}", cb_ano.SelectedValue);
            string TotalJudo = String.Format(@"SELECT count(*) as 'Total' FROM tb_mensalidades_cursos as tbmc WHERE tbmc.curso = 4 AND tbmc.ano_letivo={0}", cb_ano.SelectedValue);
            string TotalFutebol = String.Format(@"SELECT count(*) as 'Total' FROM tb_mensalidades_cursos as tbmc WHERE tbmc.curso = 5 AND tbmc.ano_letivo={0}", cb_ano.SelectedValue);
            string TotalFormatura = String.Format(@"SELECT count(*) as 'Total' FROM tb_mensalidades_cursos as tbmc WHERE tbmc.curso = 6 AND tbmc.ano_letivo={0}", cb_ano.SelectedValue);

            DataTable totalDanca = Banco.dql(TotalDanca);
            DataTable totalJudo = Banco.dql(TotalJudo);
            DataTable totalFutebol = Banco.dql(TotalFutebol);
            DataTable totalFormatura = Banco.dql(TotalFormatura);

            Int64 DANCA = totalDanca.Rows[0].Field<Int64>("total");
            Int64 JUDO = totalJudo.Rows[0].Field<Int64>("total");
            Int64 FUTEBOL = totalFutebol.Rows[0].Field<Int64>("total");
            Int64 FORMATURA = totalFormatura.Rows[0].Field<Int64>("total");



            string nomeArquivo = Globais.caminho + @"\Alunos.pdf";
            PdfWriter escritorPDF = new PdfWriter(nomeArquivo);
            PdfDocument pdf = new PdfDocument(escritorPDF);

            Document doc = new Document(pdf, PageSize.A4);

            // Use a fonte "times new roman" integrada
            PdfFont timesRoman = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
            doc.SetFont(timesRoman);

            // Restante do código...

            string dados = "";

            Paragraph paragrafo1 = new Paragraph("RELATÓRIO DE ALUNOS MATRICULADOS")
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

            // Restante do código...

            // Adicionar os dados à tabela


            Cell Danca = new Cell().Add(new Paragraph("QUANTIDADE DANÇA: " + DANCA + " #############################################"))
                  .SetFont(timesRoman)
                  .SetFontSize(10)
                  .SetWidth(10) // Definir largura da célula
                  .SetHeight(15) // Definir altura da célula
                  .SetTextAlignment(TextAlignment.CENTER);
            tabela.AddCell(Danca);
            Cell DancaSerie = new Cell().Add(new Paragraph("############"))
                  .SetFont(timesRoman)
                  .SetFontSize(10)
                  .SetWidth(10) // Definir largura da célula
                  .SetHeight(15) // Definir altura da célula
                  .SetTextAlignment(TextAlignment.CENTER);
            tabela.AddCell(DancaSerie);

            Cell DancaMatricula = new Cell().Add(new Paragraph("############"))
           .SetFont(timesRoman)
           .SetFontSize(10)
           .SetWidth(10) // Definir largura da célula
           .SetHeight(15) // Definir altura da célula
           .SetTextAlignment(TextAlignment.CENTER);
            tabela.AddCell(DancaMatricula);

            int i = 0;

            foreach (DataRow row in dtTurmas.Rows)
            {

                i++;

                Cell nomeAlunoCell = new Cell()
                .Add(new Paragraph(row["nome_aluno"].ToString()))
                .SetFont(timesRoman)
                .SetFontSize(10)
                .SetWidth(50) // Definir largura da célula
                .SetHeight(15); // Definir altura da célula
                tabela.AddCell(nomeAlunoCell);


                Cell EtapaCell = new Cell().Add(new Paragraph(row["nome_curso"].ToString()))
                .SetFont(timesRoman)
                .SetFontSize(10)
                .SetWidth(10) // Definir largura da célula
                .SetHeight(15) // Definir altura da célula
                .SetTextAlignment(TextAlignment.CENTER);
                tabela.AddCell(EtapaCell);

                Cell DataCell = new Cell().Add(new Paragraph(Convert.ToDateTime(row["data_gerada"]).ToString("dd/MM/yyyy")))
                .SetFont(timesRoman)
                .SetFontSize(10)
                .SetWidth(20) // Definir largura da célula
                .SetHeight(15) // Definir altura da célula
                .SetTextAlignment(TextAlignment.CENTER);
                tabela.AddCell(DataCell);

                if (i == DANCA)
                {
                    Cell Jardim1 = new Cell().Add(new Paragraph("QUANTIDADE FORMATURA: " + FORMATURA + " #########################################"))
                   .SetFont(timesRoman)
                   .SetFontSize(10)
                   .SetWidth(10) // Definir largura da célula
                   .SetHeight(15) // Definir altura da célula
                   .SetTextAlignment(TextAlignment.CENTER);
                    tabela.AddCell(Jardim1);

                    Cell Etapa = new Cell().Add(new Paragraph("############"))
                   .SetFont(timesRoman)
                   .SetFontSize(10)
                   .SetWidth(10) // Definir largura da célula
                   .SetHeight(15) // Definir altura da célula
                   .SetTextAlignment(TextAlignment.CENTER);
                    tabela.AddCell(Etapa);

                    Cell Matricula = new Cell().Add(new Paragraph("############"))
                   .SetFont(timesRoman)
                   .SetFontSize(10)
                   .SetWidth(10) // Definir largura da célula
                   .SetHeight(15) // Definir altura da célula
                   .SetTextAlignment(TextAlignment.CENTER);
                    tabela.AddCell(Matricula);
                }

                else if (i == DANCA + FORMATURA)
                {
                    Cell Jardim2 = new Cell().Add(new Paragraph("QUANTIDADE FUTEBOL: " + FUTEBOL + " #########################################"))
                   .SetFont(timesRoman)
                   .SetFontSize(10)
                   .SetWidth(10) // Definir largura da célula
                   .SetHeight(15) // Definir altura da célula
                   .SetTextAlignment(TextAlignment.CENTER);
                    tabela.AddCell(Jardim2);

                    Cell Etapa = new Cell().Add(new Paragraph("############"))
                   .SetFont(timesRoman)
                   .SetFontSize(10)
                   .SetWidth(10) // Definir largura da célula
                   .SetHeight(15) // Definir altura da célula
                   .SetTextAlignment(TextAlignment.CENTER);
                    tabela.AddCell(Etapa);

                    Cell Matricula = new Cell().Add(new Paragraph("############"))
                   .SetFont(timesRoman)
                   .SetFontSize(10)
                   .SetWidth(10) // Definir largura da célula
                   .SetHeight(15) // Definir altura da célula
                   .SetTextAlignment(TextAlignment.CENTER);
                    tabela.AddCell(Matricula);

                }
                else if (i == DANCA + FORMATURA + FUTEBOL)
                {
                    Cell Maternal1 = new Cell().Add(new Paragraph("QUANTIDADE JUDÔ: " + JUDO + " #########################################"))
                   .SetFont(timesRoman)
                   .SetFontSize(10)
                   .SetWidth(10) // Definir largura da célula
                   .SetHeight(15) // Definir altura da célula
                   .SetTextAlignment(TextAlignment.CENTER);
                    tabela.AddCell(Maternal1);

                    Cell Etapa = new Cell().Add(new Paragraph("############"))
                   .SetFont(timesRoman)
                   .SetFontSize(10)
                   .SetWidth(10) // Definir largura da célula
                   .SetHeight(15) // Definir altura da célula
                   .SetTextAlignment(TextAlignment.CENTER);
                    tabela.AddCell(Etapa);

                    Cell Matricula = new Cell().Add(new Paragraph("############"))
                   .SetFont(timesRoman)
                   .SetFontSize(10)
                   .SetWidth(10) // Definir largura da célula
                   .SetHeight(15) // Definir altura da célula
                   .SetTextAlignment(TextAlignment.CENTER);
                    tabela.AddCell(Matricula);
                }

            }

            doc.Add(paragrafo1);
            doc.Add(paragrafo2);
            doc.Add(tabela);

            doc.Close();

            System.Diagnostics.Process.Start(Globais.caminho + @"\Alunos.pdf");

        }

        private void cb_ano_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var vcon = Banco.ConexaoBanco();
            string queryAlunos = String.Format(@"SELECT 
                                                tba.nome_aluno,
                                                tbc.nome_curso, 
                                                tbmc.data_gerada 
                                                FROM tb_alunos as tba,
                                                tb_mensalidades_cursos as tbmc,
                                                tb_cursos as tbc
                                                WHERE tbmc.idaluno = tba.ID_aluno
                                                AND tbmc.curso = tbc.ID_curso AND tbmc.ano_letivo={0}
                                                ORDER BY tbc.nome_curso,tba.nome_aluno", cb_ano.SelectedValue);

            dgv_Alunos.DataSource = Banco.dql(queryAlunos);

            string TotalAlunos = String.Format(@"SELECT count(*) as 'Total' FROM tb_alunos as tba,tb_mensalidades_cursos as tbmc WHERE tbmc.idaluno = tba.ID_aluno AND tbmc.ano_letivo={0}", cb_ano.Text);

            DataTable dt = Banco.dql(TotalAlunos);

            lb_TotalAlunos.Text = dt.Rows[0].Field<Int64>("total").ToString();

            dgv_Alunos.Columns[0].Width = 548;
            dgv_Alunos.Columns[1].Width = 150;
            dgv_Alunos.Columns[2].Width = 130;

            dgv_Alunos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Alunos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
