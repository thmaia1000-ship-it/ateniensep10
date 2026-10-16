using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar
{
    public partial class F_ResponsavelAcademico : Form
    {
        public F_ResponsavelAcademico()
        {
            InitializeComponent();
        }

        private void F_ResponsavelAcademico_Load(object sender, EventArgs e)
        {
            
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
                    
                    //Criar conta no app

                    string Data_Hoje = DateTime.Now.ToString("yyyy-MM-dd");

                    string ultimo_Resp = String.Format(@"SELECT ID_responsavel_academico FROM tb_responsavel_academico WHERE idaluno={0}", tb_aluno.Tag);
                    DataTable responsavel = Banco.dql(ultimo_Resp);

                    int ID_responsavel = responsavel.Rows[0].Field<Int32>("ID_responsavel_academico");

                    string ContaAPP = String.Format(@"INSERT INTO
                        tb_contas (nome_aluno,cpf,senha,idaluno,idresponsavel,usuario,data_gerada)
                        VALUES('{0}', '{1}','{2}',{3},{4},'{5}','{6}')", tb_aluno.Text, tb_cpf.Text, tb_cpf.Text, tb_aluno.Tag, ID_responsavel, Globais.Main.PassarUsuario, Data_Hoje);
                        Banco.dml(ContaAPP);

                    string queryVerificarResponsavelFinanceiro = String.Format (@"SELECT nome FROM tb_responsavel_financeiro WHERE idaluno="+ tb_aluno.Tag.ToString());
                    DataTable verificarresp = Banco.dql(queryVerificarResponsavelFinanceiro);

                    MessageBox.Show("Responsável Acadêmico inserido!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    if (verificarresp.Rows.Count > 0)
                    {
                        if (Globais.Main.Modo == "Matricula")
                        {
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
                            f_ResponsavelFinanceiro.ShowDialog();
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
            SelecionarAlunoAcademico SelecionarAlunoAcademico = new SelecionarAlunoAcademico(this);
            SelecionarAlunoAcademico.ShowDialog();
        }
    }
}
