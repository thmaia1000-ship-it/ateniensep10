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
    public partial class F_ResponsavelFinanceiro : Form
    {
       
        public F_ResponsavelFinanceiro()
        {
            InitializeComponent();
        }

        private void abreForm(int nivel, Form p)
        {
            if (Globais.logado)
            {

                if (Globais.nivel >= nivel)
                //Procedimentos
                {

                   p.ShowDialog();
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

        private void ResponsavelFinanceiro_Load(object sender, EventArgs e)
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
                string data = DateTime.Now.ToString("yyyy-MM-dd");
                if (MessageBox.Show("Deseja Confirmar o cadastro?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string queryInsertResponsavelFinanceiro = String.Format(@"
                    INSERT INTO 
                        tb_responsavel_financeiro (nome,cpf,rg,nacionalidade,rua,bairro,numero,cep,idaluno,orgao_emissor)  
                    VALUES ('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')",
                   tb_nome.Text.ToUpper(), tb_cpf.Text, tb_rg.Text, tb_Nacionalidade.Text, tb_rua.Text, tb_Bairro.Text, tb_NumeroEnd.Text, tb_CEPEnd.Text, tb_aluno.Tag, tb_expedidor.Text);

                    Banco.dml(queryInsertResponsavelFinanceiro);

                    // Cria carteira
                    string CarteiraAluno = String.Format(@"INSERT INTO
                        tb_carteira_aluno(nome_aluno, saldo_carteira, idaluno, data_gerada, usuario)
                        VALUES('{0}','{1}',{2},'{3}','{4}')", tb_aluno.Text.ToUpper(), 0.00, tb_aluno.Tag.ToString(), data, Globais.Main.PassarUsuario.ToUpper());
                    Banco.dml(CarteiraAluno);

                    //Pegar o Id do responsável
                    string ultimo_Resp = String.Format(@"SELECT ID_responsavel_financeiro FROM tb_responsavel_financeiro WHERE idaluno={0}", tb_aluno.Tag);
                    DataTable responsavel = Banco.dql(ultimo_Resp);

                    int ID_responsavel = responsavel.Rows[0].Field<Int32>("ID_responsavel_financeiro");

                    //Cria conta APP
                    string ContaAPP = String.Format(@"INSERT INTO
                        tb_contas (nome_aluno,cpf,senha,idaluno,idresponsavel,usuario,data_gerada)
                        VALUES('{0}', '{1}','{2}',{3},{4},'{5}','{6}')", tb_aluno.Text, tb_cpf.Text, tb_cpf.Text, tb_aluno.Tag, ID_responsavel, Globais.Main.PassarUsuario, DateTime.Now.ToString("yyyy-MM-dd"));
                    Banco.dml(ContaAPP);

                    MessageBox.Show("Responsável Financeiro inserido!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string queryVerificarResponsavelAcademico = String.Format(@"SELECT nome FROM tb_responsavel_academico WHERE idaluno=" + tb_aluno.Tag.ToString());
                    DataTable verificarresp = Banco.dql(queryVerificarResponsavelAcademico);
                    if (verificarresp.Rows.Count > 0)
                    {
                        Close();
                    }
                    else
                    {
                        if (MessageBox.Show("O Responsável Acadêmico é o mesmo?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Cadastros.F_ResponsavelAcademico2 F_ResponsavelAcademico = new Cadastros.F_ResponsavelAcademico2(this);
                            F_ResponsavelAcademico.ShowDialog();
                            Close();
                        }
                        else
                        {
                            F_ResponsavelAcademico F_ResponsavelAcademico = new F_ResponsavelAcademico();
                            F_ResponsavelAcademico.ShowDialog();
                            Close();
                        }

                    }
                }

            }
           
            
        }

        private void btn_aluno_Click(object sender, EventArgs e)
        {
            SelecionarAlunoFinanceiro SelecionarAlunoFinanceiro = new SelecionarAlunoFinanceiro(this);
            SelecionarAlunoFinanceiro.ShowDialog();
        }
    }
}
