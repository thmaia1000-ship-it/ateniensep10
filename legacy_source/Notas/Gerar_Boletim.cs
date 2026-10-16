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
    public partial class Gerar_Boletim : Form
    {
        public Gerar_Boletim()
        {
            InitializeComponent();
        }

        string idSelecionado = "";

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            Selecionar.SelecionarAluno selecionarAluno = new Selecionar.SelecionarAluno(this);
            selecionarAluno.Show();
        }

        private void Lancar_Notas_Load(object sender, EventArgs e)
        {
            bimestre1.Checked = true;
            Globais.Main.PassarBimestre = 1;

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

            lb_nota.Visible = false;
            tb_nota.Visible = false;

        }

        private void Atualizar()
        {
            if (tb_aluno.Text != "")
            {

                dgv_Notas.Rows.Clear();

                string Notas = String.Format(@"
                SELECT ID_nota,nota, materia FROM tb_notas WHERE idaluno ={0} AND bimestre ={1} AND idetapa={2} AND ano_letivo ='{3}' ORDER BY idmateria", tb_aluno.Tag, Globais.Main.PassarBimestre, Globais.Main.PassarIDEtapa, Globais.Main.PassarAno);
                DataTable notas = Banco.dql(Notas);


                

                int Linha = -1;

                if (notas.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;

                    for (int i = 1; i <= notas.Rows.Count; i++)
                    {
                        Linha = Linha + 1;

                        dgv_Notas.Rows.Add(notas.Rows[Linha].Field<string>("nota"), notas.Rows[Linha].Field<string>("materia"), notas.Rows[Linha].Field<Int32>("ID_nota"));

                    }

                    if (Globais.Main.PassarIDEtapa == 1)
                    {
                        if (notas.Rows.Count < 35)
                        {
                            MessageBox.Show("O Aluno(a) não possui todas as notas lançadas no " + Globais.Main.PassarBimestre + "º Bimestre", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                        }
                    }
                    else if (Globais.Main.PassarIDEtapa == 2)
                    {
                        if (notas.Rows.Count < 52)
                        {
                            MessageBox.Show("O Aluno(a) não possui todas as notas lançadas no " + Globais.Main.PassarBimestre + "º Bimestre", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                        }
                    }
                    else if (Globais.Main.PassarIDEtapa == 3)
                    {
                        if (notas.Rows.Count < 29)
                        {
                            MessageBox.Show("O Aluno(a) não possui todas as notas lançadas no " + Globais.Main.PassarBimestre + "º Bimestre", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                        }
                    }
                    else if (Globais.Main.PassarIDEtapa == 4)
                    {
                        if (notas.Rows.Count < 8)
                        {
                            MessageBox.Show("O Aluno(a) não possui todas as notas lançadas no " + Globais.Main.PassarBimestre + "º Bimestre", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        lb_nota.Visible = true;
                        tb_nota.Visible = true;
                    }

                }
                dgv_Notas.ClearSelection();
            }
        }

        private void dgv_Notas_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.SelectedRows.Count > 0)
            {
                cb_conceito.SelectedValue = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
                idSelecionado = dgv.Rows[dgv.SelectedRows[0].Index].Cells[2].Value.ToString();

                cb_conceito.Enabled = false;

                string materia = dgv.Rows[dgv.SelectedRows[0].Index].Cells[1].Value.ToString();

                lb_nota.Text = "Notas";
                if (materia == "PORTUGUÊS")
                {
                    tb_nota.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
                }
                else if (materia == "HISTÓRIA")
                {
                    tb_nota.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
                }
                else if (materia == "GEOGRAFIA")
                {
                    tb_nota.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
                }
                else if (materia == "CIÊNCIAS")
                {
                    tb_nota.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
                }
                else if (materia == "MATEMÁTICA")
                {
                    tb_nota.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
                }
                else if (materia == "ARTES")
                {
                    tb_nota.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
                }
                else if (materia == "EDUCAÇÃO FÍSICA")
                {
                    tb_nota.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
                }
                else if (materia == "LÍNGUA ESTRANGEIRA")
                {
                    tb_nota.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
                }
                else
                {
                    tb_nota.Text = "";
                    tb_nota.Enabled = false;
                    cb_conceito.Enabled = true;
                }

            }
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (dgv_Notas.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Deseja alterar estes dados?", "Salvar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    string Notas = String.Format(@"
                    SELECT * FROM tb_notas WHERE ID_nota={0} ORDER BY idmateria",idSelecionado);
                    DataTable notas = Banco.dql(Notas);

                    string nota_antiga = notas.Rows[0].Field<string>("nota");
                    string nota_nova = "";

                    string Ano = DateTime.Now.ToString("yyyy");

                    if (tb_nota.Enabled != true && cb_conceito.Enabled == true)
                    {
                        string EditarNota = String.Format(@"UPDATE tb_notas SET nota='{0}' WHERE ID_nota ={1}", cb_conceito.SelectedValue.ToString(), idSelecionado);
                        Banco.dml(EditarNota);

                        nota_nova = cb_conceito.Text;
                    }
                    else
                    {
                        string EditarNota = String.Format(@"UPDATE tb_notas SET nota='{0}' WHERE ID_nota ={1}", tb_nota.Text.Replace(",","."), idSelecionado);
                        Banco.dml(EditarNota);

                        nota_nova = tb_nota.Text;
                    }

                    string acao = "UPDATE";
                    string tabela_afetada = "tb_notas";
                    int id_registro = Convert.ToInt32(idSelecionado);
                    string data_hora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string detalhes = $"Editou a nota de {nota_antiga} para {nota_nova}";

                    Banco.log(acao, tabela_afetada, id_registro, detalhes, data_hora); // Inserindo dados na Log

                    MessageBox.Show("Dados Alterados com sucesso!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                    Atualizar();
                }
            }
            else
            {
                MessageBox.Show("Selecione uma Nota!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            Globais.Main.PassarIdAluno = tb_aluno.Tag.ToString();
            if (Globais.Main.PassarIDEtapa == 1 || Globais.Main.PassarIDEtapa == 5)
            {
                Boletim.Boletim_Maternal boletim = new Boletim.Boletim_Maternal();
                boletim.Show();
            }
            else if (Globais.Main.PassarIDEtapa == 5)
            {
                Boletim.Boletim_Maternal boletim = new Boletim.Boletim_Maternal();
                boletim.Show();
            }
            else if (Globais.Main.PassarIDEtapa == 2)
            {
                Boletim.Boletim_JardimI boletim = new Boletim.Boletim_JardimI();
                boletim.Show();
            }
            else if (Globais.Main.PassarIDEtapa == 3)
            {
                Boletim.Boletim_JardimII boletim = new Boletim.Boletim_JardimII();
                boletim.Show();
            }
            else if (Globais.Main.PassarIDEtapa == 4)
            {
                Boletim.BoletimNotas boletim = new Boletim.BoletimNotas();
                boletim.Show();
            }
            
        }

        private void bimestre4_CheckedChanged(object sender, EventArgs e)
        {
            Globais.Main.PassarBimestre = 4;
            Atualizar();
        }

        private void bimestre3_CheckedChanged(object sender, EventArgs e)
        {
            Globais.Main.PassarBimestre = 3;
            Atualizar();
        }

        private void bimestre2_CheckedChanged(object sender, EventArgs e)
        {
            Globais.Main.PassarBimestre = 2;
            Atualizar();
        }

        private void bimestre1_CheckedChanged(object sender, EventArgs e)
        {
            Globais.Main.PassarBimestre = 1;
            Atualizar();
        }

        private void tb_nota_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente número e virgula", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente uma virgula", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
