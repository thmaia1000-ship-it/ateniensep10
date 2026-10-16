using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Turmas
{
    public partial class AdicionarAluno : Form
    {
        public AdicionarAluno()
        {
            InitializeComponent();
        }

        public string Etapa;

        private void Atualizar()
        {


            //POPULAR COMBOBOX Turma
            string vqueryTurmas = String.Format(@"
                SELECT
                ID_turma,
                nome_turma
                 FROM tb_turmas
                     WHERE ID_turma > 0 AND ano_letivo={0} ORDER BY nome_turma", cb_ano.Text);


            cb_turma.DataSource = Banco.dql(vqueryTurmas);
            cb_turma.DisplayMember = "nome_turma";
            cb_turma.ValueMember = "ID_turma";

        }



        private void btn_Aluno_Click(object sender, EventArgs e)
        {
            Turmas.SelecionarAluno selecionar = new Turmas.SelecionarAluno(this);
            selecionar.Show();
        }

        private void btn_nova_turma_Click(object sender, EventArgs e)
        {
            CadastroTurma cadastroTurma = new CadastroTurma();
            cadastroTurma.ShowDialog();

            Atualizar();
        }

        private void GestaoTurmas_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> ano = new Dictionary<string, string>();

            ano.Add("2025", "2025");
            ano.Add("2026", "2026");
            ano.Add("2027", "2027");
            ano.Add("2028", "2028");
            ano.Add("2029", "2029");
            ano.Add("2030", "2030");

            cb_ano.DataSource = new BindingSource(ano, null);
            cb_ano.DisplayMember = "Value";
            cb_ano.ValueMember = "Key";

            string AnoAtual = DateTime.Now.ToString("yyyy");
            cb_ano.SelectedValue = AnoAtual;

           
            lb_professor.Text = "";
            lb_turno.Text = "";

            cb_turma.SelectedValue = -1;

            Atualizar();

        }

        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            Adicionar();
        }

        private void btn_remover_Click(object sender, EventArgs e)
        {
            Remover();
        }

        private void Adicionar()
        {
            if (tb_nome.Text != "")
            {
                dgv_Turmas.Rows.Add(tb_nome.Text, Etapa, tb_nome.Tag);
                //dgv_Turmas.Columns[2].Visible = false;


                string InsertTurma = String.Format(@"INSERT INTO tb_alunos_turmas (idturma, idaluno, ano_letivo) VALUES ({0}, {1},{2})", cb_turma.SelectedValue, tb_nome.Tag,cb_ano.SelectedValue);

                Banco.dml(InsertTurma);

                string CalcQuantidade = String.Format(@"
                    SELECT 
                        COUNT(*) AS 'Total',
                        t.serie
                    FROM tb_alunos_turmas at
                    INNER JOIN tb_alunos a 
                        ON a.ID_aluno = at.idaluno
                    INNER JOIN tb_turmas t 
                        ON t.ID_turma = at.idturma
                    WHERE t.ID_turma = {0} LIMIT 1", cb_turma.SelectedValue);
                DataTable dt = Banco.dql(CalcQuantidade);

                string qtd_total = dt.Rows[0].Field<Int64>("Total").ToString();

                string AtlzQuantidade = String.Format(@"UPDATE tb_turmas SET qtd_alunos={0},idetapa={1} WHERE ID_turma ={2}", qtd_total, idetapa, cb_turma.SelectedValue);

                Banco.dml(AtlzQuantidade);

                string AtlzEtapa = String.Format(@"UPDATE tb_alunos SET etapa='{0}' WHERE ID_aluno={1}", dt.Rows[0].Field<string>("serie"), tb_nome.Tag);

                Banco.dml(AtlzEtapa);

                ListaAlunos();

            }
            else
            {
                MessageBox.Show("Selecione um Aluno(a)!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_Aluno.Focus();
            }
        }

        private void Remover()
        {

            if (dgv_Turmas.Rows.Count > 0)
            {
                if (MessageBox.Show("Deseja Remover o Aluno(a) da Turma?", "Salvar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    int idAluno = Convert.ToInt32(dgv_Turmas.SelectedRows[0].Cells["id_aluno"].Value);

                    string InsertTurma = String.Format(@"DELETE FROM tb_alunos_turmas WHERE idturma={0} AND idaluno ={1} AND ano_letivo = {2}", cb_turma.SelectedValue, idAluno,cb_ano.SelectedValue);

                    Banco.dml(InsertTurma);

                    dgv_Turmas.Rows.Remove(dgv_Turmas.CurrentRow);
                    MessageBox.Show("Aluno(a) Removido com sucesso!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information); ;

                    dgv_Turmas.ClearSelection();

                    ListaAlunos();

                }
            }
            else
            {
                MessageBox.Show("Selecione");
            }
        }

        int idetapa;
        private void cb_turma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dgv_Turmas.Columns[2].Visible = false;

            dgv_Turmas.Rows.Clear();

            ListaAlunos();

        }

        private void ListaAlunos()
        {
            dgv_Turmas.Rows.Clear();

            string vqueryCampos = String.Format(@"
				SELECT
                tba.ID_aluno,
                tba.nome_aluno,
                tba.etapa,
                tbp.nome_professor,
                tbt.turno,
                tbt.idetapa
                FROM tb_turmas as tbt
                INNER JOIN tb_professores as tbp
                ON tbp.ID_professor = tbt.idprofessor
                INNER JOIN tb_alunos_turmas as tat
                ON tat.idturma = tbt.ID_turma
                INNER JOIN tb_alunos as tba
                ON tba.ID_aluno = tat.idaluno
                WHERE tbt.ID_turma = {0} ORDER BY tba.nome_aluno", cb_turma.SelectedValue);

            DataTable dt = Banco.dql(vqueryCampos);

            if (dt.Rows.Count == 0) return;

            lb_turno.Text = dt.Rows[0].Field<string>("turno");
            lb_professor.Text = dt.Rows[0].Field<string>("nome_professor");
            idetapa = dt.Rows[0].Field<Int32>("idetapa");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv_Turmas.Rows.Add(dt.Rows[i].Field<string>("nome_aluno"), dt.Rows[i].Field<string>("etapa"), dt.Rows[i].Field<Int32>("ID_aluno"));
            }

            dgv_Turmas.ClearSelection();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if (cb_turma.Text != "")
            {
                if (dgv_Turmas.Rows.Count > 0)
                {
                    if (MessageBox.Show("Deseja salvar estes dados?", "Salvar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        for (int i = 0; i < dgv_Turmas.Rows.Count; i++)
                        {
                            if (dgv_Turmas.Rows[i].Cells["id_aluno"].Value != null)
                            {
                                int ID_aluno = Convert.ToInt32(dgv_Turmas.Rows[i].Cells["id_aluno"].Value);

                                string InsertTurma = String.Format(@"INSERT INTO tb_alunos_turmas (idturma, idaluno) VALUES ({0}, {1})", cb_turma.SelectedValue, ID_aluno);

                                Banco.dml(InsertTurma);

                            }
                        }
                        string CalcQuantidade = String.Format(@"
                    SELECT 
                        COUNT(*) AS 'Total'
                    FROM tb_alunos_turmas at
                    INNER JOIN tb_alunos a 
                        ON a.ID_aluno = at.idaluno
                    INNER JOIN tb_turmas t 
                        ON t.ID_turma = at.idturma
                    WHERE t.ID_turma = {0} LIMIT 1", cb_turma.SelectedValue);
                        DataTable dt = Banco.dql(CalcQuantidade);

                        string qtd_total = dt.Rows[0].Field<Int64>("Total").ToString();

                        string AtlzQuantidade = String.Format(@"UPDATE tb_turmas SET qtd_alunos={0},idetapa={1} WHERE ID_turma ={2}", qtd_total, idetapa, cb_turma.SelectedValue);

                        Banco.dml(AtlzQuantidade);

                        MessageBox.Show("Dados Alterados com sucesso!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ListaAlunos();
                    }
                }
                else
                {
                    MessageBox.Show("Selecione um Aluno(a)!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btn_adicionar.Focus();
                }
            }
            else
            {
                MessageBox.Show("Selecione uma Turma!","Mensagem do Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                cb_turma.Focus();
            }
        }

        private void cb_ano_SelectionChangeCommitted(object sender, EventArgs e)
        {
             Atualizar();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            EditarTurma editarTurma = new EditarTurma(this);
            editarTurma.ShowDialog();

            Atualizar();
        }
    }
}
