using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Notas
{
    public partial class Lancar_notas : Form
    {
        public Lancar_notas()
        {
            InitializeComponent();
        }

        string idSelecionado = "";

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            Selecionar.SelecionarAluno_LancarNota selecionarAluno_LancarNota = new Selecionar.SelecionarAluno_LancarNota(this);
            selecionarAluno_LancarNota.Show();
        }

        private void Atualizar()
        {

            if (tb_aluno.Text != "")
            {

                dgv_Notas.Rows.Clear();

                string Ano = DateTime.Now.ToString("yyyy");

                string Notas = String.Format(@"
                SELECT ID_nota,nota, materia, observacao,idmateria FROM tb_notas WHERE idaluno ={0} AND bimestre ={1} AND idetapa={2} AND ano_letivo ='{3}' ORDER BY idmateria", tb_aluno.Tag, Globais.Main.PassarBimestre, Globais.Main.PassarIDEtapa, Ano);
                DataTable notas = Banco.dql(Notas);

                int Linha = -1;

                if (notas.Rows.Count > 0)
                {

                    for (int i = 1; i <= notas.Rows.Count; i++)
                    {
                        Linha = Linha + 1;

                        dgv_Notas.Rows.Add(notas.Rows[Linha].Field<string>("nota"), notas.Rows[Linha].Field<string>("materia"),notas.Rows[Linha].Field<Int32>("idmateria"));

                    }
                    if (Globais.Main.PassarIDEtapa == 1)
                    {
                        if (notas.Rows.Count == 36)
                        {
                            MessageBox.Show("O Aluno(a) já possui todas as notas lançadas no " + Globais.Main.PassarBimestre + "º Bimestre", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btn_lancar.Enabled = false;
                        }
                    }
                    else if (Globais.Main.PassarIDEtapa == 2)
                    {
                        if (notas.Rows.Count == 53)
                        {
                            MessageBox.Show("O Aluno(a) já possui todas as notas lançadas no " + Globais.Main.PassarBimestre + "º Bimestre", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btn_lancar.Enabled = false;
                        }
                    }
                    else if (Globais.Main.PassarIDEtapa == 3)
                    {
                        if (notas.Rows.Count == 33)
                        {
                            MessageBox.Show("O Aluno(a) já possui todas as notas lançadas no " + Globais.Main.PassarBimestre + "º Bimestre", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btn_lancar.Enabled = false;
                        }
                    }
                    else if (Globais.Main.PassarIDEtapa == 4)
                    {
                        if (notas.Rows.Count == 30)
                        {
                            MessageBox.Show("O Aluno(a) já possui todas as notas lançadas no " + Globais.Main.PassarBimestre + "º Bimestre", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btn_lancar.Enabled = false;
                        }
                    }


                }
                else
                {
                    tb_observacao.Clear();
                }
                dgv_Notas.ClearSelection();
            }
        }

        private void Lancar_notas_Load(object sender, EventArgs e)
        {
            bimestre1.Checked = true;
            Globais.Main.PassarBimestre = 1;

            cb_materia.Enabled = false;

            Dictionary<string, string> etapa = new Dictionary<string, string>();

            etapa.Add("Não", "Não");
            etapa.Add("Sim", "Sim");
            etapa.Add("As Vezes", "As Vezes");
            etapa.Add("Necessita Melhorar", "Necessita Melhorar");
            etapa.Add("Ótimo", "Ótimo");
            etapa.Add("Bom", "Bom");
            etapa.Add("Regular", "Regular");
            cb_conceito.DataSource = new BindingSource(etapa, null);
            cb_conceito.DisplayMember = "Value";
            cb_conceito.ValueMember = "Key";

            cb_conceito.SelectedValue = -1;

            //POPULAR COMBOBOX
            string vqueryTurmas = String.Format(@"
                SELECT
                ID_professor,
                nome_professor
                 FROM
                      tb_professores
                 ORDER BY
                      nome_professor");

            cb_professor.Items.Clear();
            cb_professor.DataSource = Banco.dql(vqueryTurmas);
            cb_professor.DisplayMember = "nome_professor";
            cb_professor.ValueMember = "ID_professor";

            cb_professor.SelectedValue = -1;

        }

        private void btn_lancar_Click(object sender, EventArgs e)
        {
            string valorSelecionado = cb_materia.SelectedValue.ToString();
            bool alunoJaPossuiNota = false;

            for (int i = 0; i < dgv_Notas.Rows.Count; i++)
            {
                string valorDaLinha = dgv_Notas.Rows[i].Cells[2].Value.ToString();

                if (valorSelecionado == valorDaLinha)
                {
                    alunoJaPossuiNota = true;
                    break; // Se encontrou uma correspondência, pode parar o loop, não precisa continuar verificando as outras linhas.
                }
            }

            if (alunoJaPossuiNota)
            {
                MessageBox.Show("O Aluno(a) já possui nota lançada nessa matéria!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int idcurso = 0;

                if (MessageBox.Show("Lançar nota?", "Mensagem do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (Globais.Main.PassarIDEtapa == 4)
                    {
                        idcurso = 2;
                    }
                    else
                    {
                        idcurso = 1;
                    }

                    string Ano = DateTime.Now.ToString("yyyy");
                    string data_gerada = DateTime.Now.ToString("yyyy-MM-dd");

                    string queryInsertNota = String.Format(@"
                    INSERT INTO 
                        tb_notas (aluno,professor,materia,nota,observacao,bimestre,idaluno,idcurso,idmateria,idetapa,idprofessor,ano_letivo,data_gerada,usuario)  
                    VALUES ('{0}','{1}','{2}','{3}','{4}',{5},{6},{7},{8},{9},{10},'{11}','{12}','{13}')", tb_aluno.Text,cb_professor.Text,cb_materia.Text,cb_conceito.SelectedValue.ToString(),tb_observacao.Text,Globais.Main.PassarBimestre,tb_aluno.Tag,idcurso,cb_materia.SelectedValue.ToString(),Globais.Main.PassarIDEtapa,cb_professor.SelectedValue.ToString(),Ano,data_gerada,Globais.Main.PassarUsuario);

                    Banco.dml(queryInsertNota);
                    MessageBox.Show("Nota Cadastrada", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Atualizar();
                    cb_conceito.SelectedValue = -1;
                }
            }
        }

        private void bimestre1_Click(object sender, EventArgs e)
        {
            Globais.Main.PassarBimestre = 1;
            btn_lancar.Enabled = true;
            Atualizar();
        }

        private void bimestre2_Click(object sender, EventArgs e)
        {
            Globais.Main.PassarBimestre = 2;
            btn_lancar.Enabled = true;
            Atualizar();
        }

        private void bimestre3_Click(object sender, EventArgs e)
        {
            Globais.Main.PassarBimestre = 3;
            btn_lancar.Enabled = true;
            Atualizar();
        }

        private void bimestre4_Click(object sender, EventArgs e)
        {
            Globais.Main.PassarBimestre = 4;
            btn_lancar.Enabled = true;
            Atualizar();
        }

        private void dgv_Notas_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.SelectedRows.Count > 0)
            {
                cb_conceito.SelectedValue = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
                idSelecionado = dgv.Rows[dgv.SelectedRows[0].Index].Cells[2].Value.ToString();
            }
        }

        private void cb_materia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cb_conceito.SelectedValue = 1;
        }
    }
}
