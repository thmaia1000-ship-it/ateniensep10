using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace Escolar
{
    public partial class F_GestaoTurmas : Form
    {
        string idSelecionado;
        int modo = 0; //0= Padrao, 1 = Edição, 2 = Inserção
        string vqueryDGV;



        public F_GestaoTurmas()
        {
            InitializeComponent();
        }

        private void F_GestaoTurmas_Load(object sender, EventArgs e)
        {
            vqueryDGV = "SELECT ID_turma as 'ID', turma as 'Turma', turno as 'Turno' FROM tb_turmas";
            dgv_turmas.DataSource = Banco.dql(vqueryDGV);
            dgv_turmas.Columns[0].Width = 40;
            dgv_turmas.Columns[1].Width = 175;
            dgv_turmas.Columns[2].Width = 85;

            //Popular COMBOBOX STATUS ( Ativa = A  PARALISADA = P Cancelada = C)
            Dictionary<string, string> st = new Dictionary<string, string>();
            st.Add("A", "Ativa");
            st.Add("P", "Paralisada");
            st.Add("C", "Cancelada");
            cb_Status.Items.Clear();
            cb_Status.DataSource = new BindingSource(st, null);
            cb_Status.DisplayMember = "Value ";
            cb_Status.ValueMember = "Key";

            //Popular COMBOBOX TURNO

            Dictionary<string, string> t = new Dictionary<string, string>();
            t.Add("Matutino", "Matutino");
            t.Add("Vespertino", "Vespertino");
            t.Add("Noturno", "Noturno");
            cb_Turno.Items.Clear();
            cb_Turno.DataSource = new BindingSource(t, null);
            cb_Turno.DisplayMember = "Value ";
            cb_Turno.ValueMember = "Key";
        }

        private void dgv_turmas_SelectionChanged(object sender, EventArgs e)
        {


            DataGridView dgv = (DataGridView)sender;
            int contlinhas = dgv.SelectedRows.Count;
            if (contlinhas > 0)
            {
                modo = 0;
                idSelecionado = dgv_turmas.Rows[dgv_turmas.SelectedRows[0].Index].Cells[0].Value.ToString();
                string vqueryCampos = "SELECT turma, sala, turno, max_alunos, status_turma FROM tb_turmas WHERE ID_turma=" + idSelecionado;
                DataTable dt = Banco.dql(vqueryCampos);
                tb_dscTurmas.Text = dt.Rows[0].Field<string>("turma");   
                tb_Sala.Text = dt.Rows[0].Field<string>("sala");
                n_maxAlunos.Value = dt.Rows[0].Field<Int32>("max_alunos");
                cb_Status.SelectedValue = dt.Rows[0].Field<string>("status_turma");
                cb_Turno.SelectedValue = dt.Rows[0].Field<string>("turno");
                tb_vagas.Text = CalcVagas();
                
            }
        }

        private string CalcVagas()
        {
            //CALCULO DE VAGAS

            string queryVagas = String.Format("SELECT count(ID_aluno) as 'contVagas' FROM tb_alunos WHERE idturma={0}", idSelecionado);
            DataTable dt = Banco.dql(queryVagas);
            int vagas = Int32.Parse(Math.Round(n_maxAlunos.Value, 0).ToString());
            vagas -= Int32.Parse(dt.Rows[0].Field<Int64>("contVagas").ToString());

            return vagas.ToString();
        }                

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_novaTurma_Click(object sender, EventArgs e)
        {
            tb_dscTurmas.Clear();
            n_maxAlunos.Value = 0;
            cb_Status.SelectedIndex = -1;
            cb_Turno.SelectedIndex = -1;
            tb_dscTurmas.Focus();
            tb_vagas.Clear();
            tb_Sala.Clear();
            modo = 2;

        }

        private void btn_salvarTurma_Click(object sender, EventArgs e)
        {

            if (modo != 0) {
                string queryTurma ="";
                string msg = "";
                    if (modo == 1)
                {
                    msg = "Dados Alterados";
                    queryTurma = String.Format("UPDATE tb_turmas SET turma='{0}', sala='{1}', turno='{2}', max_alunos={3}, status_turma='{4}' WHERE ID_turma={5}", tb_dscTurmas.Text, tb_Sala.Text, cb_Turno.SelectedValue, Int32.Parse(Math.Round(n_maxAlunos.Value, 0).ToString()), cb_Status.SelectedValue, idSelecionado);

                } else
                {
                    msg = "Dados Cadastrados";
                    queryTurma = String.Format("INSERT INTO tb_turmas (turma, sala, turno, max_alunos, status_turma) VALUES ('{0}','{1}','{2}',{3},'{4}')", tb_dscTurmas.Text, tb_Sala.Text, cb_Turno.SelectedValue, Int32.Parse(Math.Round(n_maxAlunos.Value, 0).ToString()),cb_Status.SelectedValue);

                }
                int linha = dgv_turmas.SelectedRows[0].Index;
                 
                Banco.dml(queryTurma);
                if (modo == 1) 
                {
                    dgv_turmas[1, linha].Value = tb_dscTurmas.Text;
                    dgv_turmas[2, linha].Value = cb_Turno.Text;
                    tb_vagas.Text = CalcVagas();
                }
                else 
                {
                    dgv_turmas.DataSource = Banco.dql(vqueryDGV);
                }

                MessageBox.Show(msg);


            }
        }
        private void btn_excluirTurma_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseja excluir?", "Excluir?", MessageBoxButtons.YesNo);
            if(res == DialogResult.Yes)
            {
                string queryExcluirTurma = String.Format("DELETE FROM tb_turmas WHERE ID_turma={0}", idSelecionado);
                Banco.dml(queryExcluirTurma);
                dgv_turmas.Rows.Remove(dgv_turmas.CurrentRow);
            }
        }

        private void tb_dscTurmas_SizeChanged(object sender, EventArgs e)
        {
            if (modo == 0)
            {
                modo = 1;
            }

            }

        private void cb_Professor_SizeChanged(object sender, EventArgs e)
        {
            if (modo == 0)
            {
                modo = 1;
            }
        }

        private void n_maxAlunos_ValueChanged(object sender, EventArgs e)
        {
            if (modo == 0)
            {
                modo = 1;
            }
            CalcVagas();
        }

        private void cb_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modo == 0)
            {
                modo = 1;
            }
        }

        private void cb_Horário_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modo == 0)
            {
                modo = 1;
            }
        }

        private void btn_impTurma_Click(object sender, EventArgs e)
        {
            string nomeArquivo = Globais.caminho + @"\turma.pdf";
            FileStream arquivoPDF = new FileStream(nomeArquivo, FileMode.Create);    
            Document doc = new Document(PageSize.A4);
            PdfWriter escritorPDF = PdfWriter.GetInstance(doc, arquivoPDF);

            string dados = "";

            Paragraph paragrafo1 = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Bold)); ;

            paragrafo1.Alignment = Element.ALIGN_CENTER;
            paragrafo1.Add("Relatório de Turmas \n \n");


            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Globais.caminho + @"\LogoAteniense.png");
            logo.ScaleToFit(110f, 120f);
            logo.Alignment = Element.ALIGN_LEFT;
            //logo.SetAbsolutePosition(100f, 700f); //X, - Y

            PdfPTable tabela = new PdfPTable(2);//Colunas
            tabela.DefaultCell.FixedHeight = 20;

            tabela.AddCell("ID");
            tabela.AddCell("Turma");

            DataTable dtTurmas = Banco.dql(vqueryDGV);
            for (int i = 0; i < dtTurmas.Rows.Count; i++)
            {

                tabela.AddCell(dtTurmas.Rows[i].Field<Int32>("ID").ToString());
                tabela.AddCell(dtTurmas.Rows[i].Field<string>("Turma"));
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
                System.Diagnostics.Process.Start(Globais.caminho + @"\turma.pdf") ;
            }

        }
    } 
}
