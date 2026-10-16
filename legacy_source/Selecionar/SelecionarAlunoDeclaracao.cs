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

namespace Escolar.Selecionar
{
    public partial class SelecionarAlunoDeclaracao : Form
    {
        public SelecionarAlunoDeclaracao()
        {
            InitializeComponent();
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text != "")
            {

                var vcon = Banco.ConexaoBanco();

                MySqlCommand cm = new MySqlCommand();
                cm.CommandText = "SELECT tba.ID_aluno as 'ID', tba.nome_aluno as 'Aluno', tba.datanasc as 'D. Nasc' FROM tb_alunos as tba WHERE nome_aluno LIKE ('" + tb_pesquisa.Text + "%')";

                cm.Connection = vcon;
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cm;
                da.Fill(dt);
                dgv_SelecionarAluno.DataSource = dt;
                vcon.Close();
                dgv_SelecionarAluno.Columns[0].Width = 55;
                dgv_SelecionarAluno.Columns[1].Width = 420;
                dgv_SelecionarAluno.Columns[2].Width = 130;
                dgv_SelecionarAluno.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else
            {
                MessageBox.Show("Preencha o campo nome para pesquisar");
                tb_pesquisa.Focus();
            }
        }

        private void dgv_SelecionarAluno_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            Globais.Main.PassarIdAluno = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
            Globais.Main.PassarAno = cb_ano.SelectedValue.ToString();

            string IDMensalidade = String.Format(@"SELECT ID_mensalidade FROM tb_mensalidades WHERE idaluno = {0} AND ano_letivo={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

            DataTable idmensalidade = Banco.dql(IDMensalidade);


            if (Globais.Main.PassarDeclaracoes == "Matrícula")
            {
                if (MessageBox.Show("O Aluno estuda na instituição?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Globais.Main.Estuda = "Estuda";

                    Academico.DeclaracaoMatricula declaracao_Matricula = new Academico.DeclaracaoMatricula();
                    declaracao_Matricula.Show();
                }
                else
                {
                    Globais.Main.Estuda = "Estudou";

                    Academico.DeclaracaoMatricula declaracao_Matricula = new Academico.DeclaracaoMatricula();
                    declaracao_Matricula.Show();
                }

            }
            else if (Globais.Main.PassarDeclaracoes == "Quitação")
            {

                if (idmensalidade.Rows.Count > 0)
                {
                    Globais.Main.PassarID_Mensalidade = idmensalidade.Rows[0].Field<Int32>("ID_mensalidade").ToString();

                    if (MessageBox.Show("O Aluno estuda na instituição?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Globais.Main.Estuda = "Estuda";
                        Globais.Main.Cursa = "Cursa";

                        declaracoes.Declaracao_Quitacao declaracao_Quitacao = new declaracoes.Declaracao_Quitacao();
                        declaracao_Quitacao.Show();
                    }
                    else
                    {
                        Globais.Main.Estuda = "Estudou";
                        Globais.Main.Cursa = "Cursou";

                        declaracoes.Declaracao_Quitacao declaracao_Quitacao = new declaracoes.Declaracao_Quitacao();
                        declaracao_Quitacao.Show();
                    }

                }
                else
                {
                    MessageBox.Show("O Aluno não possuí mensalidade no ano letivo " + cb_ano.SelectedValue );
                }
            }

        }

        private void SelecionarAlunoDeclaracao_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> ano = new Dictionary<string, string>();

            ano.Add("2022", "2022");
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
        }
    }
}
