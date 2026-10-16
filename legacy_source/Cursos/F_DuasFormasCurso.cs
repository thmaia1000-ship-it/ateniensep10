using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Cursos
{
    public partial class F_DuasFormasCurso : Form
    {
        Cursos.F_FormaPagamentoCurso f_FormaPagamento;

        decimal Valor1, Valor2, Valor_Soma, Valor_Total;

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            decimal Valor = decimal.Parse(f_FormaPagamento.lb_Total.Text.Replace(".", ","));

            if (tb_Valor1.Text != "" && tb_Valor2.Text != "")
            {

                Valor1 = decimal.Parse(tb_Valor1.Text);
                Valor2 = decimal.Parse(tb_Valor2.Text);
                Valor_Total = decimal.Parse(f_FormaPagamento.lb_Total.Text.Replace(".", ","));

                Valor_Soma = Valor1 + Valor2;
                lb_Total.Text = Valor_Soma.ToString("C");

                if (Valor_Soma < Valor || Valor_Soma > Valor)
                {
                    MessageBox.Show("O Valor Precisa ser Igual a " + Convert.ToDecimal(f_FormaPagamento.lb_Total.Text.Replace(".", ",")).ToString("C"), "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    string Curso = String.Format(@"SELECT ID_curso,nome_curso FROM tb_cursos WHERE ID_curso =" + Globais.Main.PassarCurso);

                    DataTable Cursando = Banco.dql(Curso);

                    string IDMensalidade = String.Format(@"SELECT ID_mensalidade_curso FROM tb_mensalidades_cursos WHERE idaluno = {0} AND curso = {1} AND ano_letivo={2}", Globais.Main.PassarIdAluno, Globais.Main.PassarCurso,Globais.Main.PassarAno);

                    DataTable idmensalidade = Banco.dql(IDMensalidade);

                    int ID_mensalidade = idmensalidade.Rows[0].Field<Int32>("ID_mensalidade_curso");

                    string vqueryID_Cupom = String.Format(@"SELECT COALESCE(MAX(ID_caixa), 0) AS cupom FROM tb_caixa");

                    DataTable id = Banco.dql(vqueryID_Cupom);

                    int ID_caixa = Convert.ToInt32(id.Rows[0].Field<Int64>("cupom"));

                    Globais.Main.PassarCurso = Cursando.Rows[0].Field<string>("nome_curso");

                    Globais.Main.PassarForma1 = cb_forma1.Text;
                    Globais.Main.PassarForma2 = cb_forma2.Text;

                    string Data = DateTime.Now.ToString("yyyy-MM-dd");
                    string Entrada = "ENTRADA";
                    string Mensalidade = "Mensalidade Curso";
                    string Horario = DateTime.Now.ToString("HH:mm");

                    var vconn = Banco.ConexaoBanco();
                    string CaixaPagamento1 = String.Format(@"INSERT INTO
                    tb_caixa (valor_total,forma,tipo_movimentacao,descricao,usuario,data,horario,nome,curso,idaluno,mensalidades_paga,idmensalidade,idforma2)
                    VALUES('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10},{11},{12})", tb_Valor1.Text.Replace(",", "."), cb_forma1.Text, Entrada, Mensalidade, Globais.Main.PassarUsuario, Data, Horario, Globais.Main.PassarAluno, Globais.Main.PassarCurso, Globais.Main.PassarIdAluno, Globais.Main.PassarMensalidades_paga, ID_caixa + 2);
                    Banco.dml(CaixaPagamento1);
                    vconn.Close();

                    vconn = Banco.ConexaoBanco();
                    string CaixaPagamento2 = String.Format(@"INSERT INTO
                    tb_caixa (valor_total,forma,tipo_movimentacao,descricao,usuario,data,horario,nome,curso,idaluno,mensalidades_paga,idmensalidade,idforma2)
                    VALUES('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10},{11},{12})", tb_Valor2.Text.Replace(",", "."), cb_forma2.Text, Entrada, Mensalidade, Globais.Main.PassarUsuario, Data, Horario, Globais.Main.PassarAluno, Globais.Main.PassarCurso, Globais.Main.PassarIdAluno, Globais.Main.PassarMensalidades_paga, ID_mensalidade, ID_caixa + 1);
                    Banco.dml(CaixaPagamento2);
                    vconn.Close();

                    Globais.Main.PassarCurso = Cursando.Rows[0].Field<Int32>("ID_curso").ToString();

                    MessageBox.Show("Clique em Receber novamente para imprimir o recibo.", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Close();
                }
            }
            else
            {
                MessageBox.Show("Todos os Campos são obrigatórios!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void F_DuasFormasCurso_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> forma = new Dictionary<string, string>();

            forma.Add("DINHEIRO", "DINHEIRO");
            forma.Add("PIX", "PIX");
            forma.Add("DÉBITO", "DÉBITO");
            forma.Add("CRÉDITO", "CRÉDITO");

            cb_forma1.DataSource = new BindingSource(forma, null);
            cb_forma1.DisplayMember = "Value";
            cb_forma1.ValueMember = "Key";
            cb_forma2.DataSource = new BindingSource(forma, null);
            cb_forma2.DisplayMember = "Value";
            cb_forma2.ValueMember = "Key";
        }

        public F_DuasFormasCurso(F_FormaPagamentoCurso f)
        {
            InitializeComponent();
            f_FormaPagamento = f;
        }

        private void tb_Valor1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb_Valor2_KeyPress(object sender, KeyPressEventArgs e)
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
