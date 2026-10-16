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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
namespace Escolar
{
    public partial class F_ImprimirBoletim : Form
    {
        F_BoletimEscolar f_ImprimirBoletim;
        string idSelecionado;

        public F_ImprimirBoletim(F_BoletimEscolar b)
        {
            InitializeComponent();
            f_ImprimirBoletim = b;
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (tb_pesquisa.TextLength == 0)
            {
                MessageBox.Show("Preencha o campo nome para pesquisar");
                tb_pesquisa.Focus();
            }
            else if (cb_FiltrarData.Text =="")
            {
                MessageBox.Show("Selecione o ano para pesquisar");
                cb_FiltrarData.Focus();
            }
            else
            {
                var vcon = Banco.ConexaoBanco();

                MySqlCommand cm = new MySqlCommand();
                cm.CommandText = @"
                SELECT 
                idaluno as 'ID',
                aluno as 'Aluno',
                turma as 'Turma',
                materia as 'Matéria',
                professor as 'Professor(a)',
                nota as 'Nota',
                situacao as 'Situação',
                ano as 'Ano'
                FROM tb_notas
                WHERE aluno LIKE ('%" + tb_pesquisa.Text + "%') AND ano LIKE ('%" + cb_FiltrarData.Text.ToString() + "%') ";

                cm.Connection = vcon;
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cm;
                da.Fill(dt);
                dgv_SelecionarAluno.DataSource = dt;
                dgv_SelecionarAluno.Columns[0].Width = 25;
                dgv_SelecionarAluno.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_SelecionarAluno.Columns[1].Width = 294;
                dgv_SelecionarAluno.Columns[2].Width = 40;
                dgv_SelecionarAluno.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_SelecionarAluno.Columns[3].Width = 130;
                dgv_SelecionarAluno.Columns[4].Width = 220;
                dgv_SelecionarAluno.Columns[5].Width = 40;
                dgv_SelecionarAluno.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_SelecionarAluno.Columns[6].Width = 80;
                dgv_SelecionarAluno.Columns[7].Width = 40;
                dgv_SelecionarAluno.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                vcon.Close();
            }
        }

        private void dgv_SelecionarAluno_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            idSelecionado = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();

            string vqueryDGV = (@"SELECT 
                tbn.idaluno as 'ID',
                tbn.aluno as 'Aluno(a)',
                tbn.turma as 'Turma',
                tbn.materia as 'Matéria',
                tbn.professor as 'Professor',
                tbn.nota as 'Nota', 
                tbn.situacao as 'Situação',
                tbn.ano as 'Ano'
                FROM tb_notas as tbn
                WHERE tbn.idaluno AND tbn.idaluno=" + idSelecionado );

            string nomeArquivo = Globais.caminho + @"\Boletim.pdf";
            FileStream arquivoPDF = new FileStream(nomeArquivo, FileMode.Create);
            Document doc = new Document(PageSize.A4);
            PdfWriter escritorPDF = PdfWriter.GetInstance(doc, arquivoPDF);

            string dados = "";

            Paragraph paragrafo1 = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Bold)); ;

            paragrafo1.Alignment = Element.ALIGN_CENTER;
            paragrafo1.Add("BOLETIM \n \n");


            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Globais.caminho + @"\LogoAteniense.png");
            logo.ScaleToFit(110f, 120f);
            logo.Alignment = Element.ALIGN_LEFT;
            //logo.SetAbsolutePosition(100f, 700f); //X, - Y

            PdfPTable tabela = new PdfPTable(7);//Colunas
            tabela.DefaultCell.FixedHeight = 20;

            tabela.AddCell("Aluno(a)");
            tabela.AddCell("Turma");
            tabela.AddCell("Matéria");
            tabela.AddCell("Professor");
            tabela.AddCell("Nota");
            tabela.AddCell("Situação");
            tabela.AddCell("Ano");


            DataTable dtBoletim = Banco.dql(vqueryDGV);
            for (int i = 0; i < dtBoletim.Rows.Count; i++)
            {
                tabela.AddCell(dtBoletim.Rows[i].Field<string>("Aluno(a)"));
                tabela.AddCell(dtBoletim.Rows[i].Field<string>("Turma"));
                tabela.AddCell(dtBoletim.Rows[i].Field<string>("Matéria"));
                tabela.AddCell(dtBoletim.Rows[i].Field<string>("Professor"));
                tabela.AddCell(dtBoletim.Rows[i].Field<string>("Nota"));
                tabela.AddCell(dtBoletim.Rows[i].Field<string>("Situação"));
                tabela.AddCell(dtBoletim.Rows[i].Field<Int32>("Ano").ToString());


            }

            doc.Open();
            doc.Add(logo);
            doc.Add(paragrafo1);
            doc.Add(tabela);
            //doc.Add(paragrafo2);
            doc.Close();

            DialogResult res = MessageBox.Show("Deseja abrir o relatório?", "Relatório", MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(Globais.caminho + @"\Boletim.pdf");
            }
        }
    }
}

