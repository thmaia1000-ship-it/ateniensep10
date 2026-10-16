using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Escolar
{
    public partial class F_SelecionarAlunoGerarMensalidade : Form
    {

        F_GerarMensalidade f_GerarMensalidade;

        public F_SelecionarAlunoGerarMensalidade(F_GerarMensalidade f)
        {
            InitializeComponent();
            f_GerarMensalidade = f;
        }

        private void abreForm(int nivel, Form f)
        {
            if (Globais.logado)
            {

                if (Globais.nivel >= nivel)
                //Procedimentos
                {

                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Acesso não permitido");
                }

            }
            else
            {
                MessageBox.Show("É necessário ter um usuário logado");
            }
        }

        private void dgv_SelecionarAluno_DoubleClick(object sender, EventArgs e)
        {
                DataGridView dgv = (DataGridView)sender;

                f_GerarMensalidade.tb_Aluno.Tag = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
                f_GerarMensalidade.tb_Aluno.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[1].Value.ToString();
                f_GerarMensalidade.tb_curso.Tag = dgv.Rows[dgv.SelectedRows[0].Index].Cells[2].Value.ToString();

            Globais.Main.PassarIdAluno = f_GerarMensalidade.tb_Aluno.Tag.ToString();

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

            f_GerarMensalidade.cb_respFinan.DataSource = Banco.dql(ResponsavelFinanceiro);
            f_GerarMensalidade.cb_respFinan.DisplayMember = "nome";
            f_GerarMensalidade.cb_respFinan.ValueMember = "ID_responsavel_financeiro";

            var vcon = Banco.ConexaoBanco();
            string NomeCurso = String.Format(@"
                        SELECT
                        nome_curso
                        FROM tb_cursos
                        WHERE ID_curso =" + f_GerarMensalidade.tb_curso.Tag);

            DataTable dt = Banco.dql(NomeCurso);
            vcon.Close();

                if (dt.Rows.Count > 0)
                {
                    f_GerarMensalidade.tb_curso.Text = dt.Rows[0].Field<string>("nome_curso");

                    Close();
                }
                else
                {
                    MessageBox.Show("Este Aluno(a) não possui um Curso cadastrado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text != "")
            {

                var vcon = Banco.ConexaoBanco();

                MySqlCommand cm = new MySqlCommand();
                cm.CommandText = "SELECT ID_aluno as 'ID', nome_aluno as 'Aluno', idcurso FROM tb_alunos WHERE nome_aluno LIKE ('" + tb_pesquisa.Text + "%')";

                cm.Connection = vcon;
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cm;
                da.Fill(dt);
                dgv_SelecionarAluno.DataSource = dt;
                vcon.Close();
                dgv_SelecionarAluno.Columns[2].Visible = false;
                dgv_SelecionarAluno.Columns[0].Width = 55;
                dgv_SelecionarAluno.Columns[1].Width = 533;
                dgv_SelecionarAluno.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else
            {
                MessageBox.Show("Preencha o campo nome para pesquisar");
                tb_pesquisa.Focus();
            }
        }

        private void F_SelecionarAlunoGerarMensalidade_Load(object sender, EventArgs e)
        {
           
        }
    }
}
