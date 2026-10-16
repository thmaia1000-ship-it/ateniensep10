using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Escolar
{
    public partial class F_GestaoAlunos : Form
    {
        string vqueryDGV = "";
        string turmaAtual = "";
        string idSelecionado = "";
        string IdResponsavelAcademico = "";
        string turma = "";
        int linha = 0;
        string vqueryAlunos = "";

        public F_GestaoAlunos()
        {
            InitializeComponent();
        }



        private void F_GestaoAlunos_Load(object sender, EventArgs e)
        {
     
            //POPULAR COMBOBOX TURMAS
            string vqueryTurmas = @"
                SELECT
                ID_turma,
                turma
   
                 FROM
                      tb_turmas
                 ORDER BY
                      turma";


            cb_Turmas.Items.Clear();
            cb_Turmas.DataSource = Banco.dql(vqueryTurmas);
            cb_Turmas.DisplayMember = "turma";
            cb_Turmas.ValueMember = "ID_turma";

            //idSelecionado = dgv_GestaoAlunos.Rows[0].Cells[0].Value.ToString();


            // Popular ComboBox 


            Dictionary<string, string> sexo = new Dictionary<string, string>();

            sexo.Add("M", "Masculino");
            sexo.Add("F", "Feminino");
            cb_sexo.DataSource = new BindingSource(sexo, null);
            cb_sexo.DisplayMember = "Value";
            cb_sexo.ValueMember = "Key";

            Dictionary<string, string> cor = new Dictionary<string, string>();

            cor.Add("Amarelo", "Amarelo");
            cor.Add("Branco", "Branco");
            cor.Add("Indígena", "Indígena");
            cor.Add("Negro", "Negro");
            cor.Add("Pardo", "Pardo");
            cb_cor.DataSource = new BindingSource(cor, null);
            cb_cor.DisplayMember = "Value";
            cb_cor.ValueMember = "Key";

            Dictionary<string, string> uf = new Dictionary<string, string>();


            uf.Add("AC", "AC");
            uf.Add("AL", "AL");
            uf.Add("AP", "AP");
            uf.Add("AM", "AM");
            uf.Add("BA", "BA");
            uf.Add("CE", "CE");
            uf.Add("DF", "DF");
            uf.Add("ES", "ES");
            uf.Add("GO", "GO");
            uf.Add("MA", "MA");
            uf.Add("MT", "MT");
            uf.Add("MS", "MS");
            uf.Add("MG", "MG");
            uf.Add("PA", "PA");
            uf.Add("PB", "PB");
            uf.Add("PR", "PR");
            uf.Add("PE", "PE");
            uf.Add("PI", "PI");
            uf.Add("RJ", "RJ");
            uf.Add("RN", "RN");
            uf.Add("RS", "RS");
            uf.Add("RO", "RO");
            uf.Add("RR", "RR");
            uf.Add("SC", "SC");
            uf.Add("SP", "SP");
            uf.Add("SE", "SE");
            uf.Add("TO", "TO");

            cb_UF.DataSource = new BindingSource(uf, null);
            cb_UF.DisplayMember = "Value";
            cb_UF.ValueMember = "Key";

        }

        private void btn_Salvar_Click(object sender, EventArgs e)

        {
            if (MessageBox.Show("Deseja salvar estes dados?", "Salvar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            else
            {
                linha = dgv_GestaoAlunos.SelectedRows[0].Index;
                string queryAtualizarAluno = String.Format(@"UPDATE tb_alunos SET nome_aluno='{0}', datanasc='{1}', sexo='{2}', cor='{3}', cidade='{4}',nacionalidade='{5}',UF='{6}',rua='{7}',bairro='{8}',cep='{9}',numero={10},zona='{11}',telefone='{12}',vive_com='{13}',doenca='{14}',emergencia='{15}',mae='{16}',pai='{17}',responsavel1='{18}',responsavel2='{19}',idturma={20} WHERE ID_aluno={21}", tb_Aluno.Text, mstb_DataNasc.Text, cb_sexo.SelectedValue, cb_cor.SelectedValue, tb_Cidade.Text, tb_Nacionalidade.Text, cb_UF.SelectedValue, tb_Rua.Text, tb_BairroEnd.Text, tb_CEPEnd.Text, tb_NumeroEnd.Text.ToString(), tb_Zona.Text, mstb_TelefoneEnd.Text, tb_ViveCom.Text, tb_DescDoenca.Text, tb_Emergencia.Text, tb_Mae.Text, tb_Pai.Text, tb_OutroResp1.Text, tb_OutroResp2.Text, cb_Turmas.SelectedValue.ToString(), idSelecionado);

                Banco.dml(queryAtualizarAluno);
                dgv_GestaoAlunos[1, linha].Value = tb_Aluno.Text;
                MessageBox.Show("Alterado com sucesso");

            }
        }



        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja excluir os dados deste Aluno?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            string vqueryExcluirAluno = String.Format(@"
                DELETE FROM
                    tb_alunos
                WHERE
                    ID_aluno={0}
                 ", idSelecionado);
            Banco.dml(vqueryExcluirAluno);
            dgv_GestaoAlunos.Rows.Remove(dgv_GestaoAlunos.CurrentRow);
            MessageBox.Show("Aluno excluído");
        }
    


    private void btn_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgv_GestaoAlunos_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.SelectedRows.Count > 0)
            {

                idSelecionado = dgv_GestaoAlunos.Rows[0].Cells[0].Value.ToString();
                tb_Aluno.Text = dgv_GestaoAlunos.Rows[dgv_GestaoAlunos.SelectedRows[0].Index].Cells[1].Value.ToString();
                idSelecionado = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();

                string vqueryCampos = String.Format(@"
                SELECT
                    ID_aluno,
                    nome_aluno,
                    datanasc,
                    sexo,
                    cor,
                    cidade,
                    UF,
                    nacionalidade,
                    rua,
                    bairro,
                    cep,
                    numero,
                    zona,
                    telefone,
                    vive_com,
                    doenca,
                    emergencia,
                    mae,
                    pai,
                    responsavel1,
                    responsavel2,
                    idturma
                FROM
                    tb_alunos
                WHERE ID_aluno={0}
                 ", idSelecionado);
                DataTable dt = Banco.dql(vqueryCampos);
                tb_Aluno.Text = dt.Rows[0].Field<string>("nome_aluno");
                mstb_DataNasc.Text = dt.Rows[0].Field<string>("datanasc");
                cb_sexo.SelectedValue = dt.Rows[0].Field<string>("sexo");
                cb_cor.SelectedValue = dt.Rows[0].Field<string>("cor");
                tb_Cidade.Text = dt.Rows[0].Field<string>("cidade");
                cb_UF.SelectedValue = dt.Rows[0].Field<string>("UF");
                tb_Nacionalidade.Text = dt.Rows[0].Field<string>("nacionalidade");
                tb_Rua.Text = dt.Rows[0].Field<string>("rua");
                tb_BairroEnd.Text = dt.Rows[0].Field<string>("bairro");
                tb_CEPEnd.Text = dt.Rows[0].Field<string>("cep");
                tb_NumeroEnd.Text = dt.Rows[0].Field<Int32>("numero").ToString();
                tb_Zona.Text = dt.Rows[0].Field<string>("zona");
                mstb_TelefoneEnd.Text = dt.Rows[0].Field<string>("telefone");
                tb_ViveCom.Text = dt.Rows[0].Field<string>("vive_com");
                tb_DescDoenca.Text = dt.Rows[0].Field<string>("doenca");
                tb_Emergencia.Text = dt.Rows[0].Field<string>("emergencia");
                tb_Mae.Text = dt.Rows[0].Field<string>("mae");
                tb_Pai.Text = dt.Rows[0].Field<string>("pai");
                tb_OutroResp1.Text = dt.Rows[0].Field<string>("responsavel1");
                tb_OutroResp2.Text = dt.Rows[0].Field<string>("responsavel2");
                cb_Turmas.SelectedValue = dt.Rows[0].Field<Int32>("idturma");
                turmaAtual = cb_Turmas.Text;

            }
        }

        

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text != "")
            {

                var vcon = Banco.ConexaoBanco();

                MySqlCommand cm = new MySqlCommand();
                cm.CommandText = "SELECT ID_aluno as 'ID', nome_aluno as 'Aluno' FROM tb_alunos WHERE nome_aluno LIKE ('%" + tb_pesquisa.Text + "%')";

                cm.Connection = vcon;
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cm;
                da.Fill(dt);
                dgv_GestaoAlunos.DataSource = dt;
                dgv_GestaoAlunos.Columns[0].Width = 25;
                dgv_GestaoAlunos.Columns[1].Width = 235;
                vcon.Close();
            }
            else
            {
                MessageBox.Show("Preencha o campo nome para pesquisar");
            }
        }

        private void btn_Relatório_Click(object sender, EventArgs e)
        {
            string nomeArquivo = Globais.caminho + @"\alunos.pdf";
            FileStream arquivoPDF = new FileStream(nomeArquivo, FileMode.Create);
            Document doc = new Document(PageSize.A4);
            PdfWriter escritorPDF = PdfWriter.GetInstance(doc, arquivoPDF);

            string dados = "";

            Paragraph paragrafo1 = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Bold)); ;

            paragrafo1.Alignment = Element.ALIGN_CENTER;
            paragrafo1.Add("Relatório de Alunos \n \n");


            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Globais.caminho + @"\LogoAteniense.png");
            logo.ScaleToFit(110f, 120f);
            logo.Alignment = Element.ALIGN_LEFT;
            //logo.SetAbsolutePosition(100f, 700f); //X, - Y

            PdfPTable tabela = new PdfPTable(6);//Colunas
            tabela.DefaultCell.FixedHeight = 20;
            

            tabela.AddCell("ID");
            tabela.AddCell("Aluno");
            tabela.AddCell("Turma");
            tabela.AddCell("Sexo");
            tabela.AddCell("Mãe");
            tabela.AddCell("Pai");

            vqueryAlunos = @"SELECT tba.ID_aluno as 'ID', tba.nome_aluno as 'Aluno', tba.sexo as 'Sexo', tba.mae as 'Mãe',tba.pai as 'Pai',tbt.turma as 'Turma'
                            FROM tb_alunos as tba 
                            INNER JOIN tb_turmas as tbt 
                            on tbt.ID_turma = tba.idturma;";

            DataTable dtTurmas = Banco.dql(vqueryAlunos);
            for (int i = 0; i < dtTurmas.Rows.Count; i++)
            {

                tabela.AddCell(dtTurmas.Rows[i].Field<Int32>("ID").ToString());
                tabela.AddCell(dtTurmas.Rows[i].Field<string>("Aluno"));
                tabela.AddCell(dtTurmas.Rows[i].Field<string>("Sexo"));
                tabela.AddCell(dtTurmas.Rows[i].Field<string>("Mãe"));
                tabela.AddCell(dtTurmas.Rows[i].Field<string>("Pai"));
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
                System.Diagnostics.Process.Start(Globais.caminho + @"\alunos.pdf");
            }
        }
    }
}