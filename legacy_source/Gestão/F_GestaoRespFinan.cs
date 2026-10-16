using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Gestão
{
    public partial class F_GestaoRespFinan : Form
    {
        string idSelecionadoAcad = "";
        string idSelecionadoFinan = "";
        public F_GestaoRespFinan()
        {
            InitializeComponent();
        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja salvar estes dados?", "Salvar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            else
            {
                string queryAtualizarRespAcademico = String.Format(@"UPDATE tb_responsavel_academico SET nome='{0}',cpf='{1}',rg='{2}',nacionalidade='{3}',rua='{4}',bairro='{5}',numero='{6}',cep='{7}',orgao_emissor='{8}' WHERE ID_responsavel_academico={9}", cb_respAcad.Text.ToUpper(),tb_cpf.Text,tb_rg.Text,tb_Nacionalidade.Text,tb_rua.Text,tb_Bairro.Text,tb_NumeroEnd.Text,tb_CEPEnd.Text,tb_expedidorAcad.Text ,idSelecionadoAcad);

                Banco.dml(queryAtualizarRespAcademico);

                string queryAtualizarRespFinanceiro= String.Format(@"UPDATE tb_responsavel_financeiro SET nome='{0}',cpf='{1}',rg='{2}',nacionalidade='{3}',rua='{4}',bairro='{5}',numero='{6}',cep='{7}',orgao_emissor='{8}' WHERE ID_responsavel_financeiro={9}",cb_respFinan.Text.ToUpper(),tb_cpfFinan.Text, tb_rgFinan.Text,tb_nacionalidadeFinan.Text,tb_ruaFinan.Text,tb_bairroFinan.Text,tb_numeroFinan.Text,tb_cepFinan.Text,tb_expedidorFinan.Text, idSelecionadoFinan);

                Banco.dml(queryAtualizarRespFinanceiro);

                //Atualizar conta App

                string queryAtualizarConta = String.Format(@"UPDATE tb_contas SET cpf='{0}',senha='{1}' WHERE idresponsavel={2}", cb_respAcad.Text.Replace(".", "").Replace("-", ""), tb_cpf.Text.Replace(".", "").Replace("-", ""), idSelecionadoAcad);

                Banco.dml(queryAtualizarConta);

                queryAtualizarConta = String.Format(@"UPDATE tb_contas SET cpf='{0}',senha='{1}' WHERE idresponsavel={2}", tb_cpfFinan.Text.Replace(".", "").Replace("-", ""), tb_cpfFinan.Text.Replace(".", "").Replace("-", ""), idSelecionadoFinan);

                Banco.dml(queryAtualizarConta);

                MessageBox.Show("Dados Alterados com sucesso!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                Close();
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja excluir os dados do Responsável Financeiro?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            else
            {
            
            string vqueryExcluirAluno = String.Format(@"
                DELETE FROM
                    tb_responsavel_financeiro
                WHERE
                    idaluno={0}
                 ", Globais.Main.PassarIdAluno);
            Banco.dml(vqueryExcluirAluno);
            MessageBox.Show("Responsável Financeiro excluído", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AtualizarAcad()
        {
            string ResponsavelAcademico = String.Format(@"
            SELECT
                ID_responsavel_academico,
                nome,
                cpf,
                rg,
                nacionalidade,
                rua,
                bairro,
                numero,
                cep,
                orgao_emissor
            FROM tb_responsavel_academico
            WHERE ID_responsavel_academico={0}
        ", cb_respAcad.SelectedValue);

            DataTable respAcad = Banco.dql(ResponsavelAcademico);
            if (respAcad.Rows.Count > 0)
            {
                tb_cpf.Text = respAcad.Rows[0].Field<string>("CPF");
                tb_rg.Text = respAcad.Rows[0].Field<string>("RG");
                tb_Nacionalidade.Text = respAcad.Rows[0].Field<string>("nacionalidade");
                tb_rua.Text = respAcad.Rows[0].Field<string>("rua");
                tb_Bairro.Text = respAcad.Rows[0].Field<string>("bairro");
                tb_NumeroEnd.Text = respAcad.Rows[0].Field<string>("numero");
                tb_CEPEnd.Text = respAcad.Rows[0].Field<string>("cep");
                idSelecionadoAcad = respAcad.Rows[0].Field<Int32>("ID_responsavel_academico").ToString();
                tb_expedidorAcad.Text = respAcad.Rows[0].Field<string>("orgao_emissor");
            }
            else
            {
                MessageBox.Show("Este aluno não possui um responsável Academico cadastrado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
        private void AtualizarFinan()
        {

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
                    WHERE ID_responsavel_financeiro ={0}
                 ", cb_respFinan.SelectedValue);

            DataTable respFinan = Banco.dql(ResponsavelFinanceiro);
            if (respFinan.Rows.Count > 0)
            {
                tb_cpfFinan.Text = respFinan.Rows[0].Field<string>("CPF");
                tb_rgFinan.Text = respFinan.Rows[0].Field<string>("RG");
                tb_nacionalidadeFinan.Text = respFinan.Rows[0].Field<string>("nacionalidade");
                tb_ruaFinan.Text = respFinan.Rows[0].Field<string>("rua");
                tb_bairroFinan.Text = respFinan.Rows[0].Field<string>("bairro");
                tb_numeroFinan.Text = respFinan.Rows[0].Field<string>("numero");
                tb_cepFinan.Text = respFinan.Rows[0].Field<string>("cep");
                idSelecionadoFinan = respFinan.Rows[0].Field<Int32>("ID_responsavel_financeiro").ToString();
                tb_expedidorFinan.Text = respFinan.Rows[0].Field<string>("orgao_emissor");
            }
            else
            {
                MessageBox.Show("Este aluno não possui um responsável Financeiro cadastrado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
        private void F_GestaoRespFinan_Load(object sender, EventArgs e)
        {
            Combobox();
        }

        private void btn_excluirRespAcad_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja excluir os dados do Responsável Acadêmico?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            else
            {
                string vqueryExcluirAluno = String.Format(@"
                DELETE FROM
                    tb_responsavel_academico
                WHERE
                    idaluno={0}
                 ", Globais.Main.PassarIdAluno);
                Banco.dml(vqueryExcluirAluno);
                MessageBox.Show("Responsável Acadêmico excluído", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void cb_respFinan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AtualizarFinan();
        }

        private void cb_respAcad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AtualizarAcad();
        }

        private void novoAcadButton_Click(object sender, EventArgs e)
        {
            F_ResponsavelAcademico f_ResponsavelAcademico = new F_ResponsavelAcademico();
            f_ResponsavelAcademico.ShowDialog();
            Combobox();
        }

        private void novoFinanButton_Click(object sender, EventArgs e)
        {
            F_ResponsavelFinanceiro f_ResponsavelFinanceiro = new F_ResponsavelFinanceiro();
            f_ResponsavelFinanceiro.ShowDialog();

            Combobox();
        }

        private void Combobox()
        {
            //POPULAR COMBOBOX
            string ResponsavelAcademico = String.Format(@"
                    SELECT
                    ID_responsavel_academico,
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
                        tb_responsavel_academico
                    WHERE idaluno={0} ORDER BY ID_responsavel_academico DESC LIMIT 10", Globais.Main.PassarIdAluno);

            cb_respAcad.DataSource = Banco.dql(ResponsavelAcademico);
            cb_respAcad.DisplayMember = "nome";
            cb_respAcad.ValueMember = "ID_responsavel_academico";

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

            cb_respFinan.DataSource = Banco.dql(ResponsavelFinanceiro);
            cb_respFinan.DisplayMember = "nome";
            cb_respFinan.ValueMember = "ID_responsavel_financeiro";

            AtualizarFinan();
            AtualizarAcad();
        }
    }
}
