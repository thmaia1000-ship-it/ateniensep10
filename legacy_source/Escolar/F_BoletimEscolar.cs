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

namespace Escolar
{
    public partial class F_BoletimEscolar : Form
    {
        
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

            if (tb_nota1.TextLength == 0)
            {
                NotaObrigatoria();
            }
            else if (string.IsNullOrWhiteSpace(tb_nota1.Text))
            {
                NotaObrigatoria();
            }
            else if (tb_nota2.TextLength == 0)
            {
                NotaObrigatoria();
            }
            else if (string.IsNullOrWhiteSpace(tb_nota2.Text))
            {
                NotaObrigatoria();
            }
            else if (tb_nota3.TextLength == 0)
            {
                NotaObrigatoria();
            }
            else if (string.IsNullOrWhiteSpace(tb_nota3.Text))
            {
                NotaObrigatoria();
            }
            else if (tb_nota4.TextLength == 0)
            {
                NotaObrigatoria();
            }
            else if (string.IsNullOrWhiteSpace(tb_nota4.Text))
            {
                NotaObrigatoria();
            }
            else
            {
                total = (double.Parse(tb_nota1.Text) + double.Parse(tb_nota2.Text) + double.Parse(tb_nota3.Text) + double.Parse(tb_nota4.Text)).ToString();
                tb_media.Text = (double.Parse(total) / 4).ToString("F");
                aprovacao = double.Parse(tb_media.Text);
                if (aprovacao >= 6)
                {
                    lb_resultado.ForeColor = Color.Green;
                    lb_resultado.Text = "APROVADO";
                }
                else
                {
                    lb_resultado.ForeColor = Color.Red;
                    lb_resultado.Text = "REPROVADO";
                }

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
            lb_obgnota1.Text = "";
            lb_obgnota2.Text = "";
            lb_obgnota3.Text = "";
            lb_obgnota4.Text = "";
            lb_materia.Text = "";
            lb_resultado.Text = "";
            lb_obgAluno.Text = "";
            lb_obgProfessor.Text = "";

            //POPULAR COMBOBOX TURMAS

            string vqueryTurmas = @"
                SELECT
                ID_materia,
                materia

                 FROM
                      tb_materias
                 ORDER BY
                      materia";


            cb_materia.Items.Clear();
            cb_materia.DataSource = Banco.dql(vqueryTurmas);
            cb_materia.DisplayMember = "materia";
            cb_materia.ValueMember = "ID_materia";

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
            lb_materia.ForeColor = Color.Green;
        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {

            if (tb_Aluno.TextLength == 0)
            {
                lb_obgAluno.Text = "*";
                lb_obgAluno.ForeColor = Color.Red;
                MessageBox.Show("Você precisa definir o Aluno");
                btn_selecionarAluno.Focus();

            }
            else if (tb_Professor.TextLength == 0)
            {
                lb_obgProfessor.Text = "*";
                lb_obgProfessor.ForeColor = Color.Red;
                MessageBox.Show("Você precisa definir o Professor");
                btn_selecionarProfessor.Focus();
            }

            else if (tb_nota1.TextLength == 0)
            {
                CalcularMedia();
            }

            else if (tb_nota2.TextLength == 0)
            {
                CalcularMedia();
            }

            else if (tb_nota3.TextLength == 0)
            {
                CalcularMedia();
            }

            else if (tb_nota4.TextLength == 0)
            {
                CalcularMedia();
            }
            else
            {
                CalcularMedia();
                if (MessageBox.Show("Deseja Lançar nota?", "Lançar", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    string queryInsertNota = String.Format(@"
                INSERT INTO 
                    tb_notas (aluno,turma,materia,professor,nota,situacao,idaluno,idturma,idmateria,idprofessor)  
                VALUES ('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7},{8},{9})", tb_Aluno.Text, tb_turma.Text, cb_materia.Text, tb_Professor.Text, tb_media.Text, lb_resultado.Text, tb_Aluno.Tag.ToString(), tb_turma.Tag.ToString(), cb_materia.SelectedValue, tb_Professor.Tag.ToString());

                    Banco.dml(queryInsertNota);
                    MessageBox.Show("Nota Lançada com sucesso!");
                }
            }
        }
    
        

        private void tb_nota1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero e virgula");
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente uma virgula");
            }
        }

        private void tb_nota2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero e virgula");
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente uma virgula");
            }
        }

        private void tb_nota3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero e virgula");
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente uma virgula");
            }
        }

        private void tb_nota4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero e virgula");
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente uma virgula");
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
            tb_sala.Clear();
            tb_turno.Clear();
            tb_turma.Clear();
            tb_nota1.Clear();
            tb_nota2.Clear();
            tb_nota3.Clear();
            tb_nota4.Clear();
            tb_media.Clear();
            lb_materia.Text = "";
            lb_resultado.Text = "";
            lb_obgnota1.Text = "";
            lb_obgnota2.Text = "";
            lb_obgnota3.Text = "";
            lb_obgnota4.Text = "";
            lb_obgAluno.Text = "";
            lb_obgProfessor.Text = "";

        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            F_ImprimirBoletim f_ImprimirBoletim = new F_ImprimirBoletim(this);
            f_ImprimirBoletim.ShowDialog();
        }
    } 
}
