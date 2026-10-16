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
    public partial class F_SelecionarAlunoCurso : Form
    {
        Cadastros.F_MatriculaCurso f_MatriculaCurso;
        public F_SelecionarAlunoCurso(Cadastros.F_MatriculaCurso f)
        {
            InitializeComponent();
            f_MatriculaCurso = f;
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text != "")
            {

                var vcon = Banco.ConexaoBanco();

                MySqlCommand cm = new MySqlCommand();
                cm.CommandText = "SELECT ID_aluno as 'ID', nome_aluno as 'Aluno' FROM tb_alunos WHERE nome_aluno LIKE ('" + tb_pesquisa.Text + "%')";

                cm.Connection = vcon;
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cm;
                da.Fill(dt);
                dgv_SelecionarAluno.DataSource = dt;
                vcon.Close();

                dgv_SelecionarAluno.Columns[0].Width = 55;
                dgv_SelecionarAluno.Columns[1].Width = 533;
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

            f_MatriculaCurso.tb_Aluno.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[1].Value.ToString();
            f_MatriculaCurso.tb_Aluno.Tag = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();

            Globais.Main.PassarIdAluno = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();

            string ResponsavelFinanceiro = String.Format(@"
                    SELECT
                    ID_responsavel_financeiro,
                    nome,
                    cpf,
                    rg,
                    nacionalidade,
                    rua,
                    bairro,
                    numero,
                    cep,
                    orgao_emissor
                    FROM
                        tb_responsavel_financeiro
                    WHERE idaluno={0} ORDER BY ID_responsavel_financeiro DESC", Globais.Main.PassarIdAluno);

            f_MatriculaCurso.cb_respFinan.DataSource = Banco.dql(ResponsavelFinanceiro);
            f_MatriculaCurso.cb_respFinan.DisplayMember = "nome";
            f_MatriculaCurso.cb_respFinan.ValueMember = "ID_responsavel_financeiro";

            Close();
        }
    }
}
