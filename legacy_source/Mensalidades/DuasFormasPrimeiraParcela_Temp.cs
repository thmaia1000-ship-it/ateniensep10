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
    public partial class DuasFormasPrimeiraParcela_Temp : Form
    {
        PagarPrimeiraParcela_Temp primeiraParcela;
        public DuasFormasPrimeiraParcela_Temp(PagarPrimeiraParcela_Temp f)
        {
            InitializeComponent();
            primeiraParcela = f;
        }

        decimal Valor1, Valor2, Valor_Soma, Valor_Total;

        decimal Valor;
        private void DuasFormasPrimeiraParcela_Temp_Load(object sender, EventArgs e)
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


        private void cb_forma1_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }

        private void cb_forma2_SelectionChangeCommitted(object sender, EventArgs e)
        {
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

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            
            if (tb_Valor1.Text != "" && tb_Valor2.Text != "")
            {
                Valor1 = decimal.Parse(tb_Valor1.Text);
                Valor2 = decimal.Parse(tb_Valor2.Text);

                Valor_Soma = Valor1 + Valor2;
                lb_Total.Text = Valor_Soma.ToString("C");
                Valor = Convert.ToDecimal(primeiraParcela.tb_Valor.Text);

                if (Valor_Soma != Valor)
                {
                    MessageBox.Show("O Valor Precisa ser Igual a " + Convert.ToDecimal(Valor).ToString("C"), "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string ID_aluno = String.Format(@"SELECT idcurso FROM tb_alunos WHERE ID_aluno ={0}", Globais.Main.PassarIdAluno);

                    DataTable dt = Banco.dql(ID_aluno);

                    string idcurso = dt.Rows[0].Field<Int32>("idcurso").ToString();

                    string Curso = String.Format(@"SELECT ID_curso,nome_curso FROM tb_cursos WHERE ID_curso ={0}", idcurso);

                    DataTable Cursando = Banco.dql(Curso);

                    Globais.Main.PassarCurso = Cursando.Rows[0].Field<string>("nome_curso");


                    string IDMensalidade = String.Format(@"SELECT ID_mensalidade FROM tb_mensalidades WHERE idaluno = {0} AND ano_letivo={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

                    DataTable idmensalidade = Banco.dql(IDMensalidade);

                    Globais.Main.PassarID_Mensalidade = idmensalidade.Rows[0].Field<Int32>("ID_mensalidade").ToString();


                    Globais.Main.PassarForma1 = cb_forma1.Text;
                    Globais.Main.PassarForma2 = cb_forma2.Text;

                    string Data = DateTime.Now.ToString("yyyy-MM-dd");
                    string Entrada = "ENTRADA";
                    string Mensalidade = "Mensalidade";
                    string Horario = DateTime.Now.ToString("HH:mm");

                    string vqueryID_Cupom = String.Format(@"SELECT COALESCE(MAX(ID_caixa), 0) AS cupom FROM tb_caixa");

                    DataTable id = Banco.dql(vqueryID_Cupom);

                    int ID_caixa = Convert.ToInt32(id.Rows[0].Field<Int64>("cupom"));

                    var vconn = Banco.ConexaoBanco();
                    string CaixaPagamento1 = String.Format(@"INSERT INTO
                    tb_caixa (valor_total,forma,tipo_movimentacao,descricao,usuario,data,horario,nome,curso,idaluno,mensalidades_paga,idmensalidade,idforma2)
                    VALUES('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10},{11},{12})", tb_Valor1.Text.Replace(",", "."), cb_forma1.Text, Entrada, Mensalidade, Globais.Main.PassarUsuario, Data, Horario, Globais.Main.PassarAluno, Globais.Main.PassarCurso, Globais.Main.PassarIdAluno, Globais.Main.PassarMensalidades_paga, Globais.Main.PassarID_Mensalidade, ID_caixa + 2);
                    Banco.dml(CaixaPagamento1);
                    vconn.Close();

                    vconn = Banco.ConexaoBanco();
                    string CaixaPagamento2 = String.Format(@"INSERT INTO
                    tb_caixa (valor_total,forma,tipo_movimentacao,descricao,usuario,data,horario,nome,curso,idaluno,mensalidades_paga,idmensalidade,idforma2)
                    VALUES('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10},{11},{12})", tb_Valor2.Text.Replace(",", "."), cb_forma2.Text, Entrada, Mensalidade, Globais.Main.PassarUsuario, Data, Horario, Globais.Main.PassarAluno, Globais.Main.PassarCurso, Globais.Main.PassarIdAluno, Globais.Main.PassarMensalidades_paga, Globais.Main.PassarID_Mensalidade, ID_caixa + 1);
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
    }
}
