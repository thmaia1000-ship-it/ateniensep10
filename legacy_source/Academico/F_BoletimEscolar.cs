using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Escolar.Selecionar;
using MySql.Data.MySqlClient;

namespace Escolar
{
    public partial class F_BoletimEscolar : Form
    {
        string vqueryDGV;
        string idSelecionado = "";
        int modo, editar;
        private void abreForm(int nivel, Form b)
        {
            if (Globais.logado)
            {

                if (Globais.nivel >= nivel)
                //Procedimentos
                {

                    b.ShowDialog();
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
        public F_BoletimEscolar()
        {
            InitializeComponent();

        }

        private void CalcularMedia()
        {
            string total;
            double aprovacao;

            if (tb_nota1.Text != "" && tb_nota2.Text != "" && tb_nota3.Text != "" && tb_nota4.Text != "")
            {
                total = (double.Parse(tb_nota1.Text) + double.Parse(tb_nota2.Text) + double.Parse(tb_nota3.Text) + double.Parse(tb_nota4.Text)).ToString();
                tb_media.Text = (double.Parse(total) / 4).ToString("F");
                aprovacao = double.Parse(tb_media.Text);
                if (aprovacao >= 6)
                {
                    lb_resultado.ForeColor = Color.Green;
                    lb_resultado.Text = "APROVADO(A)";
                }
                else
                {
                    lb_resultado.ForeColor = Color.Orange;
                    lb_resultado.Text = "RECUPERAÇÃO(A)";
                }

            }
            else
            {
                tb_media.Text = "";
            }
        }

        private void NotaObrigatoria()

        {
            MessageBox.Show("Campo obrigatório");
            lb_obgnota1.ForeColor = Color.Red;
            lb_obgnota2.ForeColor = Color.Red;
            lb_obgnota3.ForeColor = Color.Red;
            lb_obgnota4.ForeColor = Color.Red;
            lb_obgnota1.Text = "*";
            lb_obgnota2.Text = "*";
            lb_obgnota3.Text = "*";
            lb_obgnota4.Text = "*";

        }



        private void F_BoletimEscolar_Load(object sender, EventArgs e)
        {
            btn_faltas.Enabled = false;
            lb_recup.Visible = false;
            tb_recup.Visible = false;
            lb_obgnota1.Text = "";
            lb_obgnota2.Text = "";
            lb_obgnota3.Text = "";
            lb_obgnota4.Text = "";
            lb_resultado.Text = "";
            lb_obgAluno.Text = "";
            lb_obgProfessor.Text = "";
            lb_resultadoFinal.Text = "";
            tb_MediaFinal.Visible = false;
            lb_mediafinal.Visible = false;


            string vqueryCursos = @"
                SELECT
                ID_curso,
                nome_curso
   
                 FROM
                      tb_cursos
                 ORDER BY
                      nome_curso";
            cb_cursos.Items.Clear();
            cb_cursos.DataSource = Banco.dql(vqueryCursos);
            cb_cursos.DisplayMember = "nome_curso";
            cb_cursos.ValueMember = "ID_curso";

            cb_materia.SelectedValue = -1;
            cb_cursos.SelectedValue = -1;

            Dictionary<string, string> ano = new Dictionary<string, string>();

            ano.Add("2020", "2020");
            ano.Add("2021", "2021");
            ano.Add("2022", "2022");
            ano.Add("2023", "2023");
            ano.Add("2024", "2024");
            ano.Add("2025", "2025");
            ano.Add("2026", "2026");
            ano.Add("2027", "2027");
            ano.Add("2028", "2028");
            ano.Add("2029", "2029");
            ano.Add("2030", "2030");
            ano.Add("2031", "2031");
            ano.Add("2032", "2032");
            ano.Add("2033", "2033");
            ano.Add("2034", "2034");
            ano.Add("2035", "2035");
            ano.Add("2036", "2036");
            ano.Add("2037", "2037");
            ano.Add("2038", "2038");
            ano.Add("2039", "2039");
            ano.Add("2040", "2040");
            ano.Add("2041", "2041");
            ano.Add("2042", "2042");
            ano.Add("2043", "2043");
            ano.Add("2044", "2044");
            ano.Add("2045", "2045");
            ano.Add("2046", "2046");
            ano.Add("2047", "2047");
            ano.Add("2048", "2048");
            ano.Add("2049", "2049");
            ano.Add("2050", "2050");
            cb_AnoLetivo.DataSource = new BindingSource(ano, null);
            cb_AnoLetivo.DisplayMember = "Value";
            cb_AnoLetivo.ValueMember = "Key";

            string AnoAtual = DateTime.Now.ToString("yyyy");
            cb_AnoLetivo.SelectedValue = AnoAtual;

            tb_MediaFinal.Visible = false;

        }

        private void btn_selecionarAluno_Click(object sender, EventArgs e)
        {
            F_SelecionarAlunoBoletim f_SelecionarAlunoBoletim = new F_SelecionarAlunoBoletim(this);
            f_SelecionarAlunoBoletim.ShowDialog();
        }

        private void btn_selecionarProfessor_Click(object sender, EventArgs e)
        {
            F_SelcionarProfessorBoletim f_SelcionarProfessorBoletim = new F_SelcionarProfessorBoletim(this);
            f_SelcionarProfessorBoletim.ShowDialog();
        }

        private void cb_materia_SelectedIndexChanged(object sender, EventArgs e)
        {

            lb_materia.Text = cb_materia.Text.ToString();
        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {


            if (tb_Aluno.TextLength == 0)
            {
                lb_obgAluno.Text = "*";
                lb_obgAluno.ForeColor = Color.Red;
                MessageBox.Show("Você precisa definir o Aluno(a)!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (cb_AnoLetivo.Text == "")
            {

                MessageBox.Show("Você precisa definir o Ano Letivo!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cb_AnoLetivo.Focus();
            }


            if (MessageBox.Show("Lançar nota?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


                var vcon = Banco.ConexaoBanco();
                if (tb_nota1.Text != "" && tb_nota2.Text != "" && tb_nota3.Text != "" && tb_nota4.Text != "")
                {
                    CalcularMedia();
                }
                if (modo == 1)
                {
                    if (tb_recup.Text != "")
                    {
                        vcon = Banco.ConexaoBanco();
                        decimal media_total, recuperacao, media;
                        recuperacao = Convert.ToDecimal(tb_recup.Text);
                        media = Convert.ToDecimal(tb_media.Text);
                        if (recuperacao > media)
                        {
                            media_total = recuperacao + media;
                            decimal media_final = media_total / 2;
                            string queryAtualizarNota = String.Format(@"UPDATE tb_notas SET nota1='{0}',nota2='{1}',nota3='{2}',nota4='{3}',media='{4}',situacao='{5}',recuperacao='{6}',media_final='{7}' WHERE ID_nota={8}", tb_nota1.Text, tb_nota2.Text, tb_nota3.Text, tb_nota4.Text, tb_media.Text, lb_resultado.Text, recuperacao.ToString("F"), media_final.ToString("F"), idSelecionado);
                            Banco.dml(queryAtualizarNota);
                            
                            tb_recup.Text = "";
                        }
                        else
                        {
                            media_total = media + recuperacao;
                            decimal media_final = media_total / 2;
                            string queryAtualizarNota = String.Format(@"UPDATE tb_notas SET nota1='{0}',nota2='{1}',nota3='{2}',nota4='{3}',media='{4}',situacao='{5}',recuperacao='{6}',media_final='{7}' WHERE ID_nota={8}", tb_nota1.Text, tb_nota2.Text, tb_nota3.Text, tb_nota4.Text, tb_media.Text, lb_resultado.Text, recuperacao.ToString("F"), media_final.ToString("F"), idSelecionado);
                            Banco.dml(queryAtualizarNota);
                            tb_recup.Text = "";
                        }
                    }
                    else
                    {


                        string queryAtualizarNota = String.Format(@"UPDATE tb_notas SET nota1='{0}',nota2='{1}',nota3='{2}',nota4='{3}',media='{4}',situacao='{5}' WHERE ID_nota={6}", tb_nota1.Text, tb_nota2.Text, tb_nota3.Text, tb_nota4.Text, tb_media.Text, lb_resultado.Text, idSelecionado);

                        Banco.dml(queryAtualizarNota);
                    }
                    vcon = Banco.ConexaoBanco();

                    MySqlCommand cm = new MySqlCommand();
                    cm.CommandText = String.Format(@"
                           SELECT
                           materia as 'Materia',
                           nota1 as '1 BIM',
                           nota2 as '2 BIM',
                           nota3 as '3 BIM',
                           nota4 as '4 BIM',
                           media as 'Media',
                           recuperacao as 'Rec',
                           media_final as 'Media Final',
                           professor as 'Professor(a)',
                           ID_nota
                           FROM tb_notas
                           WHERE idaluno=" + tb_Aluno.Tag);

                    cm.Connection = vcon;
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    DataTable dt = new DataTable();
                    da.SelectCommand = cm;
                    da.Fill(dt);
                    dgv_Notas.DataSource = dt;
                    vcon.Close();
                    dgv_Notas.ClearSelection();
                    dgv_Notas.Columns[0].Width = 140;
                    dgv_Notas.Columns[1].Width = 50;
                    dgv_Notas.Columns[2].Width = 50;
                    dgv_Notas.Columns[3].Width = 50;
                    dgv_Notas.Columns[4].Width = 50;
                    dgv_Notas.Columns[5].Width = 45;
                    dgv_Notas.Columns[6].Width = 45;
                    dgv_Notas.Columns[7].Width = 45;
                    dgv_Notas.Columns[8].Width = 145;
                    dgv_Notas.Columns[9].Visible = false;
                    modo = 0;

                    
                }
                else if (editar == 1)
                {

                    vcon = Banco.ConexaoBanco();


                    string queryAtualizarNota = String.Format(@"UPDATE tb_notas SET nota1='{0}',nota2='{1}',nota3='{2}',nota4='{3}',media='{4}',situacao='{5}' WHERE ID_nota={6}", tb_nota1.Text, tb_nota2.Text, tb_nota3.Text, tb_nota4.Text, tb_media.Text, lb_resultado.Text, idSelecionado);
                    Banco.dml(queryAtualizarNota);
                   
                    vcon = Banco.ConexaoBanco();

                    MySqlCommand cm = new MySqlCommand();
                    cm.CommandText = String.Format(@"
                           SELECT
                           materia as 'Materia',
                           nota1 as '1 BIM',
                           nota2 as '2 BIM',
                           nota3 as '3 BIM',
                           nota4 as '4 BIM',
                           media as 'Media',
                           recuperacao as 'Rec',
                           media_final as 'Media Final',
                           professor as 'Professor(a)',
                           ID_nota
                           FROM tb_notas
                           WHERE idaluno=" + tb_Aluno.Tag);

                    cm.Connection = vcon;
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    DataTable dt = new DataTable();
                    da.SelectCommand = cm;
                    da.Fill(dt);
                    dgv_Notas.DataSource = dt;
                    vcon.Close();
                    dgv_Notas.ClearSelection();
                    dgv_Notas.Columns[0].Width = 140;
                    dgv_Notas.Columns[1].Width = 50;
                    dgv_Notas.Columns[2].Width = 50;
                    dgv_Notas.Columns[3].Width = 50;
                    dgv_Notas.Columns[4].Width = 50;
                    dgv_Notas.Columns[5].Width = 45;
                    dgv_Notas.Columns[6].Width = 45;
                    dgv_Notas.Columns[7].Width = 45;
                    dgv_Notas.Columns[8].Width = 145;
                    dgv_Notas.Columns[9].Visible = false;
                    editar = 0;
                }

                else {
                    string data_gerada = DateTime.Now.ToString("yyyy-MM-dd");
                    string queryInsertNota = String.Format(@"
                        INSERT INTO 
                        tb_notas (aluno,materia,professor,nota1,nota2,nota3,nota4,media,situacao,ano_letivo,idaluno,idcurso,idmateria,idprofessor,data_gerada,usuario)  
                        VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',{10},{11},{12},{13},'{14}','{15}')",
                tb_Aluno.Text, cb_materia.Text, tb_Professor.Text, tb_nota1.Text, tb_nota2.Text, tb_nota3.Text, tb_nota4.Text,
                tb_media.Text, lb_resultado.Text, cb_AnoLetivo.Text, tb_Aluno.Tag.ToString(), cb_cursos.SelectedValue,
                cb_materia.SelectedValue, tb_Professor.Tag.ToString(), data_gerada,Globais.Main.PassarUsuario.ToUpper());

                    Banco.dml(queryInsertNota);

                    
                    MessageBox.Show("Nota Lançada com sucesso!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    vcon = Banco.ConexaoBanco();

                    MySqlCommand cm = new MySqlCommand();
                    cm.CommandText = String.Format(@"
                   SELECT
                   materia as 'Materia',
                   nota1 as '1 BIM',
                   nota2 as '2 BIM',
                   nota3 as '3 BIM',
                   nota4 as '4 BIM',
                   media as 'Media',
                   recuperacao as 'Rec',
                   media_final as 'Media Final',
                   professor as 'Professor(a)',
                   ID_nota
                   FROM tb_notas
                   WHERE idaluno=" + tb_Aluno.Tag);

                    cm.Connection = vcon;
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    DataTable dt = new DataTable();
                    da.SelectCommand = cm;
                    da.Fill(dt);
                    dgv_Notas.DataSource = dt;
                    vcon.Close();
                    dgv_Notas.ClearSelection();
                    dgv_Notas.Columns[0].Width = 140;
                    dgv_Notas.Columns[1].Width = 50;
                    dgv_Notas.Columns[2].Width = 50;
                    dgv_Notas.Columns[3].Width = 50;
                    dgv_Notas.Columns[4].Width = 50;
                    dgv_Notas.Columns[5].Width = 45;
                    dgv_Notas.Columns[6].Width = 45;
                    dgv_Notas.Columns[7].Width = 45;
                    dgv_Notas.Columns[8].Width = 145;
                    dgv_Notas.Columns[9].Visible = false;
                }
            }
        }


        private void tb_nota1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero e virgula", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente uma virgula", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_nota2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero e virgula", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente uma virgula", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            tb_Aluno.Clear();
            tb_Professor.Clear();
            tb_nota1.Clear();
            tb_nota2.Clear();
            tb_media.Clear();
            lb_resultado.Text = "";
            lb_obgnota1.Text = "";
            lb_obgnota2.Text = "";
            lb_obgAluno.Text = "";
            lb_obgProfessor.Text = "";
            cb_materia.SelectedValue = -1;
            cb_cursos.SelectedValue = -1;
            for (int i = 0; i < dgv_Notas.RowCount; i++)
            {
                dgv_Notas.Rows[i].DataGridView.Columns.Clear();
            }

        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            F_ImprimirBoletim f_ImprimirBoletim = new F_ImprimirBoletim();
            f_ImprimirBoletim.ShowDialog();
        }

        private void cb_cursos_SelectionChangeCommitted(object sender, EventArgs e)
        {

            vqueryDGV = string.Format(@"SELECT ID_materia, materia
                        FROM tb_materias
                        WHERE idcurso=" + cb_cursos.SelectedValue);
            cb_materia.DataSource = Banco.dql(vqueryDGV);
            cb_materia.DisplayMember = "materia";
            cb_materia.ValueMember = "ID_materia";
        }

        private void btn_Calc_Click(object sender, EventArgs e)
        {
            CalcularMedia();
        }

        private void dgv_Notas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void dgv_Notas_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.SelectedRows.Count > 0)
            {
                idSelecionado = dgv.Rows[dgv.SelectedRows[0].Index].Cells[9].Value.ToString();
                modo = 1;

                //cb_cursos.SelectedValue = dgv.Rows[dgv.SelectedRows[0].Index].Cells[1].Value.ToString();
                tb_nota1.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[1].Value.ToString();
                tb_nota2.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[2].Value.ToString();
                tb_nota3.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[3].Value.ToString();
                tb_nota4.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[4].Value.ToString();
                tb_media.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[5].Value.ToString();

                

                if (tb_media.Text != "" && Convert.ToDecimal(tb_media.Text) < 6)
                {
                    lb_mediaparcial.Text = "Média";
                    this.lb_mediaparcial.Location = new Point(32, 401);
                    lb_media1.Visible = false;
                    lb_media2.Visible = false;
                    lb_media3.Visible = false;
                    lb_media4.Visible = false;
                    tb_nota1.Visible = false;
                    tb_nota2.Visible = false;
                    tb_nota3.Visible = false;
                    tb_nota4.Visible = false;
                    lb_recup.Visible = true;
                    tb_recup.Visible = true;

                    tb_MediaFinal.Visible = true;
                    lb_mediafinal.Visible = true;
                    tb_MediaFinal.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[7].Value.ToString();
                    tb_recup.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[6].Value.ToString();


                }
                else
                {
                    lb_mediaparcial.Text = "Média Final";
                    this.lb_mediaparcial.Location = new Point(12, 401);
                    lb_resultadoFinal.Text = "";
                    tb_MediaFinal.Visible = false;
                    lb_mediafinal.Visible = false;

                    lb_media1.Visible = true;
                    lb_media2.Visible = true;
                    lb_media3.Visible = true;
                    lb_media4.Visible = true;
                    tb_nota1.Visible = true;
                    tb_nota2.Visible = true;
                    tb_nota3.Visible = true;
                    tb_nota4.Visible = true;
                    lb_recup.Visible = false;
                    tb_recup.Visible = false;
                    tb_media.Visible = true;

                    string Recuperacao = "0,00";
                    string queryAtualizarNota = String.Format(@"UPDATE tb_notas SET media_final='{0}',recuperacao='{1}',situacao='{2}' WHERE ID_nota={3}", tb_media.Text, Recuperacao, lb_resultado.Text, idSelecionado);
                    Banco.dml(queryAtualizarNota);
                } }

            else
            {
                modo = 0;
                tb_nota1.Text = "";
                tb_nota2.Text = "";
                tb_nota3.Text = "";
                tb_nota4.Text = "";
                tb_media.Text = "";
                lb_media1.Visible = true;
                lb_media2.Visible = true;
                lb_media3.Visible = true;
                lb_media4.Visible = true;
                tb_nota1.Visible = true;
                tb_nota2.Visible = true;
                tb_nota3.Visible = true;
                tb_nota4.Visible = true;
                lb_recup.Visible = false;
                tb_recup.Visible = false;
            }
        
            if (tb_media.Text != "")
            {
                if (Convert.ToDecimal(tb_media.Text) >= 6)
                {
                    lb_resultado.ForeColor = Color.Green;
                    lb_resultado.Text = "APROVADO(A)";
                }
                else
                {
                    lb_resultado.ForeColor = Color.Orange;
                    lb_resultado.Text = "RECUPERAÇÃO";
                }
            }
            else
            {
                lb_resultado.Text = "";
            }
            if (tb_MediaFinal.Text != "" && tb_MediaFinal.Visible == true)
            {
                lb_resultadoFinal.Visible = true;
                
                if (Convert.ToDecimal(tb_MediaFinal.Text) >= 6)
                {
                    lb_resultadoFinal.ForeColor = Color.Green;
                    lb_resultadoFinal.Text = "APROVADO(A)";
                }
                else
                {
                    lb_resultadoFinal.ForeColor = Color.Red;
                    lb_resultadoFinal.Text = "REPROVADO(A)";
                }
            }
            else
            {
                lb_resultadoFinal.Text = "";
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja excluir os dados deste Aluno?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            string vqueryExcluirNota = String.Format(@"
                DELETE FROM
                    tb_notas
                WHERE
                    ID_nota={0}
                 ", idSelecionado);
            Banco.dml(vqueryExcluirNota);
            dgv_Notas.Rows.Remove(dgv_Notas.CurrentRow);
            MessageBox.Show("Nota excluída", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cb_materia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tb_nota1.Text = "";
            tb_nota2.Text = "";
            tb_nota3.Text = "";
            tb_nota4.Text = "";
            tb_media.Text = "";
            lb_resultado.Text = "";
            lb_materia.ForeColor = Color.Green;
        }

        private void tb_nota3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero e virgula", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente uma virgula", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_nota4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero e virgula", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente uma virgula", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_faltas_Click(object sender, EventArgs e)
        {
            if(tb_Aluno.Text != "")
            { 
            Academico.F_LancarFaltas f_LancarFaltas = new Academico.F_LancarFaltas(this);
            f_LancarFaltas.ShowDialog();
            }
            else
            {
                MessageBox.Show("É preciso escolher um Aluno(a)","Mensagem do sistema", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            editar = 1;
            lb_media1.Visible = true;
            lb_media2.Visible = true;
            lb_media3.Visible = true;
            lb_media4.Visible = true;
            tb_nota1.Visible = true;
            tb_nota2.Visible = true;
            tb_nota3.Visible = true;
            tb_nota4.Visible = true;
            lb_recup.Visible = false;
            tb_recup.Visible = false;
            tb_nota1.Focus();
        }
    }
}