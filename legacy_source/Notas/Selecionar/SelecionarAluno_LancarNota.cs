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

namespace Escolar.Notas.Selecionar
{
    public partial class SelecionarAluno_LancarNota : Form
    {
        Lancar_notas lancar_Notas;

        public SelecionarAluno_LancarNota(Lancar_notas f)
        {
            InitializeComponent();
            lancar_Notas = f;
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text != "")
            {

                var vcon = Banco.ConexaoBanco();

                MySqlCommand cm = new MySqlCommand();
                cm.CommandText = "SELECT ID_aluno as 'ID', nome_aluno as 'Aluno', etapa as 'Etapa' FROM tb_alunos WHERE nome_aluno LIKE ('" + tb_pesquisa.Text + "%')";

                cm.Connection = vcon;
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cm;
                da.Fill(dt);
                dgv_SelecionarAluno.DataSource = dt;
                vcon.Close();

                dgv_SelecionarAluno.Columns[0].Width = 55;
                dgv_SelecionarAluno.Columns[1].Width = 433;
                dgv_SelecionarAluno.Columns[2].Width = 110;

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

            lancar_Notas.tb_aluno.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[1].Value.ToString();
            lancar_Notas.tb_aluno.Tag = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();

            lancar_Notas.dgv_Notas.Rows.Clear();

            string Nome_Etapa = dgv.Rows[dgv.SelectedRows[0].Index].Cells[2].Value.ToString();

            Globais.Main.PassarIDEtapa = 0;

            if (Nome_Etapa == "MATERNAL I")
            {
                Globais.Main.PassarIDEtapa = 1;
            }
            else if (Nome_Etapa == "MATERNAL II")
            {
                Globais.Main.PassarIDEtapa = 5;
            }
            else if (Nome_Etapa == "JARDIM I")
            {
                Globais.Main.PassarIDEtapa = 2;
            }
            else if (Nome_Etapa == "JARDIM II")
            {
                Globais.Main.PassarIDEtapa = 3;
            }
            else if (Nome_Etapa == "1° ANO")
            {
                Globais.Main.PassarIDEtapa = 4;
            }

            string Ano = DateTime.Now.ToString("yyyy");

            string Notas = String.Format(@"
                SELECT ID_nota,nota, materia, observacao,idmateria FROM tb_notas WHERE idaluno ={0} AND bimestre ={1} AND idetapa={2} AND ano_letivo ='{3}' ORDER BY idmateria", lancar_Notas.tb_aluno.Tag, Globais.Main.PassarBimestre, Globais.Main.PassarIDEtapa, Ano);
            DataTable notas = Banco.dql(Notas);

            int Linha = -1;

            if (notas.Rows.Count > 0)
            {
                lancar_Notas.tb_observacao.Enabled = true;
                for (int i = 1; i <= notas.Rows.Count; i++)
                {
                    Linha = Linha + 1;

                    lancar_Notas.dgv_Notas.Rows.Add(notas.Rows[Linha].Field<string>("nota"), notas.Rows[Linha].Field<string>("materia"), notas.Rows[Linha].Field<Int32>("idmateria"));
                }

                if (Globais.Main.PassarIDEtapa == 1)
                {
                    if (notas.Rows.Count == 36)
                    {
                        MessageBox.Show("O Aluno(a) já possui todas as notas lançadas no " + Globais.Main.PassarBimestre + "º Bimestre", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lancar_Notas.btn_lancar.Enabled = false;
                    }
                }
                else if (Globais.Main.PassarIDEtapa == 2)
                {
                    if (notas.Rows.Count == 53)
                    {
                        MessageBox.Show("O Aluno(a) já possui todas as notas lançadas no " + Globais.Main.PassarBimestre + "º Bimestre", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lancar_Notas.btn_lancar.Enabled = false;
                    }
                }
                else if (Globais.Main.PassarIDEtapa == 3)
                {
                    if (notas.Rows.Count == 33)
                    {
                        MessageBox.Show("O Aluno(a) já possui todas as notas lançadas no " + Globais.Main.PassarBimestre + "º Bimestre", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lancar_Notas.btn_lancar.Enabled = false;
                    }
                }
                else if (Globais.Main.PassarIDEtapa == 4)
                {
                    if (notas.Rows.Count == 30)
                    {
                        MessageBox.Show("O Aluno(a) já possui todas as notas lançadas no " + Globais.Main.PassarBimestre + "º Bimestre", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lancar_Notas.btn_lancar.Enabled = false;
                    }
                }
            }

            lancar_Notas.dgv_Notas.ClearSelection();

            //POPULAR COMBOBOX TURMAS
            string vqueryTurmas = String.Format(@"
                SELECT
                ID_materia,
                materia
                 FROM
                      tb_materias
                WHERE
                idetapa={0}
                 ORDER BY
                      ID_materia", Globais.Main.PassarIDEtapa);

            //lancar_Notas.cb_materia.Items.Clear();
            lancar_Notas.cb_materia.DataSource = Banco.dql(vqueryTurmas);
            lancar_Notas.cb_materia.DisplayMember = "materia";
            lancar_Notas.cb_materia.ValueMember = "ID_materia";

            lancar_Notas.cb_materia.Enabled = true;

            lancar_Notas.cb_materia.SelectedValue = -1;
            lancar_Notas.cb_conceito.SelectedValue = 1;

            Close();
        }

        private void SelecionarAluno_LancarNota_Load(object sender, EventArgs e)
        {

        }
    }
}
