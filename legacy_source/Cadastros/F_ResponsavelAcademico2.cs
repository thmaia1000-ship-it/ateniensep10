using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Cadastros
{
    public partial class F_ResponsavelAcademico2 : Form
    {
        F_ResponsavelFinanceiro f_ResponsavelFinanceiro;
        public F_ResponsavelAcademico2(F_ResponsavelFinanceiro f)
        {
            InitializeComponent();
            f_ResponsavelFinanceiro = f;
        }

        private void btn_Gravar_Click(object sender, EventArgs e)
        {
            if (tb_nome.Text == "")
            {
                MessageBox.Show("O Nome do responsável é obrigatório!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_nome.Focus();
            }

            else if (tb_cpf.Text == "")
            {
                MessageBox.Show("Informe a CPF!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_cpf.Focus();
            }
            else if (tb_rg.Text == "")
            {
                MessageBox.Show("Informe o RG!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_rg.Focus();
            }
            else if (tb_Nacionalidade.Text == "")
            {
                MessageBox.Show("Informe a Nascionalidade!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_Nacionalidade.Focus();
            }
            else if (tb_rua.Text == "")
            {
                MessageBox.Show("Informe a Rua!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_rua.Focus();
            }
            else if (tb_Bairro.Text == "")
            {
                MessageBox.Show("Informe o Bairro!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_Bairro.Focus();
            }
            else if (tb_NumeroEnd.Text == "")
            {
                MessageBox.Show("Informe o Número da Casa!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_NumeroEnd.Focus();
            }
            else if (tb_CEPEnd.Text == "")
            {
                MessageBox.Show("Informe o CEP!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_CEPEnd.Focus();
            }
            else if (tb_aluno.Text == "")
            {
                MessageBox.Show("Informe o Aluno(a)!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_aluno.Focus();
            }
            else
            {

                if (MessageBox.Show("Deseja Confirmar o cadastro?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string queryInsertResponsavelFinanceiro = String.Format(@"
                    INSERT INTO 
                        tb_responsavel_academico (nome,cpf,rg,nacionalidade,rua,bairro,numero,cep,idaluno,orgao_emissor)  
                    VALUES ('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')",
                   tb_nome.Text.ToUpper(), tb_cpf.Text, tb_rg.Text, tb_Nacionalidade.Text, tb_rua.Text, tb_Bairro.Text, tb_NumeroEnd.Text, tb_CEPEnd.Text, tb_aluno.Tag, tb_expedidor.Text);

                    Banco.dml(queryInsertResponsavelFinanceiro);
                    MessageBox.Show("Responsável Acadêmico inserido!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    //Criar conta no app

                    string Data_Hoje = DateTime.Now.ToString("yyyy-MM-dd");


                    string ultimo_Resp = String.Format(@"SELECT MAX(ID_responsavel_academico) AS ultimo_id FROM tb_responsavel_academico");
                    DataTable responsavel = Banco.dql(ultimo_Resp);

                    int ID_responsavel = responsavel.Rows[0].Field<Int32>("ultimo_id");

                    string ContaAPP = String.Format(@"INSERT INTO
                        tb_contas (nome_aluno,cpf,senha,idaluno,idresponsavel,usuario,data_gerada)
                        VALUES('{0}', '{1}','{2}',{3},{4},'{5}','{6}')", tb_aluno.Text, tb_cpf.Text, tb_cpf.Text, tb_aluno.Tag, ID_responsavel, Globais.Main.PassarUsuario, Data_Hoje);
                    Banco.dml(ContaAPP);

                    string queryVerificarResponsavelFinanceiro = String.Format(@"SELECT nome FROM tb_responsavel_financeiro WHERE idaluno=" + tb_aluno.Tag.ToString());
                    DataTable verificarresp = Banco.dql(queryVerificarResponsavelFinanceiro);
                    if (verificarresp.Rows.Count > 0)
                    {
                        if (Globais.Main.Modo == "Matricula")
                        {
                            Globais.Main.PassarAluno = tb_aluno.Text;
                            Globais.Main.PassarIdAluno = tb_aluno.Tag.ToString();

                            F_GerarMensalidade f_GerarMensalidade = new F_GerarMensalidade();
                            f_GerarMensalidade.ShowDialog();
                        }
                        Close();
                    }
                    else
                    {
                        if (MessageBox.Show("Este Aluno(a) ainda não possui Responsável Financeiro cadastrado, Deseja cadastrar?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            F_ResponsavelFinanceiro f_ResponsavelFinanceiro = new F_ResponsavelFinanceiro();
                            f_ResponsavelFinanceiro.Show();
                            Close();
                        }
                        else
                        {
                            Close();
                        }
                    }
                }

            }

        }

        private void btn_aluno_Click(object sender, EventArgs e)
        {

            Selecionar.SelecionarAlunoAcademico2 SelecionarAlunoAcademico = new Selecionar.SelecionarAlunoAcademico2(this);
            SelecionarAlunoAcademico.ShowDialog();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            tb_nome.Clear();
            tb_Nacionalidade.Clear();
            tb_rua.Clear();
            tb_Bairro.Clear();
            tb_NumeroEnd.Clear();
            tb_CEPEnd.Clear();
            tb_rg.Clear();
            tb_cpf.Clear();
            tb_aluno.Clear();
        }

        private void F_ResponsavelAcademico2_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> estado = new Dictionary<string, string>();

            estado.Add("Solteiro(a)", "Solteiro(a)");
            estado.Add("Casado(a)", "Casado(a)");
            estado.Add("Seperado(a)", "Seperado(a)");
            estado.Add("Divorciado(a)", "Divorciado(a)");
            estado.Add("Viúvo(a)", "Viúvo(a)");

            tb_nome.Text = f_ResponsavelFinanceiro.tb_nome.Text;
            tb_cpf.Text = f_ResponsavelFinanceiro.tb_cpf.Text;
            tb_rg.Text = f_ResponsavelFinanceiro.tb_rg.Text;
            tb_Nacionalidade.Text = f_ResponsavelFinanceiro.tb_Nacionalidade.Text;
            tb_rua.Text = f_ResponsavelFinanceiro.tb_rua.Text;
            tb_Bairro.Text = f_ResponsavelFinanceiro.tb_Bairro.Text;
            tb_NumeroEnd.Text = f_ResponsavelFinanceiro.tb_NumeroEnd.Text;
            tb_CEPEnd.Text = f_ResponsavelFinanceiro.tb_CEPEnd.Text;
        }
    }
}
