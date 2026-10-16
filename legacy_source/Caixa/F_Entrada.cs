using Escolar.Selecionar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Caixa
{
    public partial class F_Entrada : Form
    {
        int modo;
        public F_Entrada()
        {
            InitializeComponent();
        }

        private void F_Entrada_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> forma = new Dictionary<string, string>();

            forma.Add("DINHEIRO", "DINHEIRO");
            forma.Add("PIX", "PIX");
            forma.Add("CRÉDITO", "CRÉDITO");
            forma.Add("DÉBITO", "DÉBITO");
            cb_Forma.DataSource = new BindingSource(forma, null);
            cb_Forma.DisplayMember = "Value";
            cb_Forma.ValueMember = "Key";

            string data = DateTime.Now.ToString("dd/MM/yyyy");
            string hora = DateTime.Now.ToString("HH:mm");
            lb_DATA.Text = hora + " " + data;
            lb_atendente.Text = Globais.Main.PassarUsuario;
            tb_valor.Text = "R$ 0,00";

        }

        private void btn_Limpar_Click(object sender, EventArgs e)
        {
            tb_valor.Text = "";
            tb_nome.Text = "";
            tb_descricao.Text = "";
            tb_valor.Text = "R$ 0,00";
            chk_outros.Enabled = false;
        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            string Data = DateTime.Now.ToString("yyyy-MM-dd");
            string Horario = DateTime.Now.ToString("HH:mm");
            string Entrada = "ENTRADA";
            if (modo == 1)
            {
                Globais.Main.PassarCaixa = tb_valor.Text;
                Globais.Main.PassarAluno = tb_nome.Text;
                Globais.Main.PassarIdAluno = tb_nome.Tag.ToString();
                Globais.Main.Modo = "0";
                F_ReciboEntrada f_ReciboEntrada = new F_ReciboEntrada();
                f_ReciboEntrada.ShowDialog();
            }
            else
            {

                if (tb_nome.Text != "" && tb_valor.Text != "" && tb_descricao.Text != "")
                {
                    if (MessageBox.Show("CONFIRMAR ENTRADA?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string PegarCurso = String.Format(@"
                    SELECT idcurso FROM tb_alunos 
                    WHERE ID_aluno={0} ", tb_nome.Tag);
                        DataTable curso = Banco.dql(PegarCurso);

                        string Curso = curso.Rows[0].Field<Int32>("idcurso").ToString();
                        if (Curso == "1")
                        {
                            Globais.Main.PassarCurso = "Educação Infantil";
                        }
                        else if (Curso == "2")
                        {
                            Globais.Main.PassarCurso = "Ensino Fundamental";
                        }

                        var vcon = Banco.ConexaoBanco();
                        string CaixaPagamento = String.Format(@"INSERT INTO
                    tb_caixa (valor_total,forma,tipo_movimentacao,descricao,usuario,data,horario,nome,curso,idaluno)
                    VALUES('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9})", tb_valor.Text, cb_Forma.SelectedValue, Entrada, tb_descricao.Text, Globais.Main.PassarUsuario, Data, Horario, tb_nome.Text.ToUpper(), Globais.Main.PassarCurso, tb_nome.Tag);
                        Banco.dml(CaixaPagamento);
                        vcon.Close();

                        MessageBox.Show("ENTRADA REGISTRADA!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Globais.Main.PassarCaixa = tb_valor.Text;
                        Globais.Main.PassarAluno = tb_nome.Text;
                        Globais.Main.PassarIdAluno = tb_nome.Tag.ToString();
                        Globais.Main.PassarDesc = tb_descricao.Text;
                        Globais.Main.Modo = "0";
                        Globais.Main.PassarForma1 = cb_Forma.Text;
                        Globais.Main.PassarForma2 = "";
                        if (MessageBox.Show("IMPRIMIR CUPOM?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            F_ReciboEntrada f_ReciboEntrada = new F_ReciboEntrada();
                            f_ReciboEntrada.ShowDialog();
                        }

                        tb_valor.Text = "";
                        tb_nome.Text = "";
                        tb_descricao.Text = "";
                        tb_valor.Text = "R$ 0.00";
                    }

                }
                else
                {
                    MessageBox.Show("Todos os campos são obrigatórios!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void tb_valor_KeyPress(object sender, KeyPressEventArgs e)
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
        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            F_SelecionarAlunoEntradaCaixa f_SelecionarAlunoEntradaCaixa = new F_SelecionarAlunoEntradaCaixa(this);
            f_SelecionarAlunoEntradaCaixa.ShowDialog();
        }

        private void btn_BuscarAluno_Click(object sender, EventArgs e)
        {
            F_SelecionarAlunoEntradaCaixa f_SelecionarAlunoEntradaCaixa = new F_SelecionarAlunoEntradaCaixa(this);
            f_SelecionarAlunoEntradaCaixa.ShowDialog();
        }

        private void chk_outros_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_outros.Checked == true)
            {
                modo = 1;
                tb_valor.Enabled = false;
                cb_Forma.Enabled = false;
                tb_descricao.Enabled = false;
                Caixa.F_DuasFormasEntradaCaixa f_DuasFormasEntradaCaixa = new Caixa.F_DuasFormasEntradaCaixa(this);
                f_DuasFormasEntradaCaixa.ShowDialog();

            }
            else
            {
                modo = 0;
                tb_valor.Enabled = true;
                cb_Forma.Enabled = true;
                tb_descricao.Enabled = true;
                if (Globais.Main.PassarForma1 != "" && Globais.Main.PassarForma2 != "")
                {
                    Globais.Main.PassarForma1 = "";
                    Globais.Main.PassarForma2 = "";
                }
            }
        }

        private void tb_valor_Enter(object sender, EventArgs e)
        {
            tb_valor.Text = "";
        }
    }
}
