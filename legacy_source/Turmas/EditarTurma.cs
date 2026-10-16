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
    public partial class EditarTurma : Form
    {

        AdicionarAluno adicionarAluno;

        public EditarTurma(AdicionarAluno f)
        {
            InitializeComponent();
            adicionarAluno = f;
        }

        private void EditarTurma_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> turno = new Dictionary<string, string>();

            turno.Add("MATUTINO", "MATUTINO");
            turno.Add("VESPERTINO", "VESPERTINO");
            turno.Add("INTEGRAL", "INTEGRAL");
            cb_turno.DataSource = new BindingSource(turno, null);
            cb_turno.DisplayMember = "Value";
            cb_turno.ValueMember = "Key";

            //POPULAR COMBOBOX Professores
            string vqueryTurmas = @"
                SELECT
                ID_professor,
                nome_professor
   
                 FROM
                      tb_professores
                 ORDER BY
                      nome_professor";


            cb_professor.Items.Clear();
            cb_professor.DataSource = Banco.dql(vqueryTurmas);
            cb_professor.DisplayMember = "nome_professor";
            cb_professor.ValueMember = "ID_professor";

            string vqueryCampos = String.Format(@"
                SELECT
                tbt.nome_turma,
                tbt.turno,
                tbt.idprofessor
                FROM tb_turmas as tbt
                WHERE tbt.ID_turma={0}", adicionarAluno.cb_turma.SelectedValue);

            DataTable dt = Banco.dql(vqueryCampos);

            tb_nome.Text = dt.Rows[0].Field<string>("nome_turma");
            cb_turno.SelectedValue = dt.Rows[0].Field<string>("turno");
            cb_professor.SelectedValue = dt.Rows[0].Field<Int32>("idprofessor");
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if (tb_nome.Text != "")
            {
                if (MessageBox.Show("Deseja salvar estes dados?", "Salvar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    string InsertTurma = String.Format(@"UPDATE tb_turmas SET nome_turma='{0}', turno='{1}', idprofessor={2} WHERE ID_turma ={3}", tb_nome.Text, cb_turno.SelectedValue, cb_professor.SelectedValue, adicionarAluno.cb_turma.SelectedValue);

                    Banco.dml(InsertTurma);

                    InsertTurma = String.Format(@"UPDATE tb_professores_turmas SET idprofessor={0} WHERE idturma ={1}", cb_professor.SelectedValue, adicionarAluno.cb_turma.SelectedValue);

                    Banco.dml(InsertTurma);

                    MessageBox.Show("Dados Alterados com sucesso!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Nome da Turma Obrigatório!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_nome.Focus();
            }
        }
    }
}
