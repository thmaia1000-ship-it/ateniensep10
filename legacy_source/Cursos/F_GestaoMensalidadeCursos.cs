using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Gestão
{
    public partial class F_GestaoMensalidadeCursos : Form
    {
        public F_GestaoMensalidadeCursos()
        {
            InitializeComponent();
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (tb_valor_parcela.Text != "")
            {
                string vqueryCampos = String.Format(@"
                 SELECT
                ID_mensalidade_curso,
                n_parcelas,
                valor_parcela,
                saldo_devedor,
                valor_total,
                data_inicio,
                parcelas_pagas,
                curso
                FROM tb_mensalidades_cursos
                WHERE idaluno={0} AND ID_mensalidade_curso={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarID_Mensalidade);

                DataTable dt = Banco.dql(vqueryCampos);

                int Parcelas_Pagas = dt.Rows[0].Field<Int32>("parcelas_pagas");
                decimal Valor_total = Convert.ToDecimal(tb_valor_parcela.Text) * nupd_parcelas.Value;
                decimal Saldo_devedor = Valor_total - Convert.ToDecimal(tb_valor_parcela.Text) * Parcelas_Pagas;
                string ID_mensalidade = dt.Rows[0].Field<Int32>("ID_mensalidade_curso").ToString();
                int n_parcelas = Parcelas_Pagas + Convert.ToInt32(nupd_parcelas.Value);

                string queryAtualizarMensalidade = String.Format(@"UPDATE tb_mensalidades_cursos SET n_parcelas={0},valor_total='{1}', saldo_devedor='{2}',valor_parcela='{3}' WHERE ID_mensalidade_curso={4}", n_parcelas, Valor_total.ToString().Replace(".", "").Replace(",", "."), Saldo_devedor.ToString().Replace(".", "").Replace(",", "."), tb_valor_parcela.Text.Replace(".", "").Replace(",", "."), ID_mensalidade);

                Banco.dml(queryAtualizarMensalidade);

                MessageBox.Show("Dados Alterados com sucesso!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                Close();

            }
            else
            {
                MessageBox.Show("Valor da Mensalidade é Obrigatório");
            }
        }

        private void F_GestaoMensalidadeCursos_Load(object sender, EventArgs e)
        {
            string vqueryCampos = String.Format(@"
                 SELECT
                n_parcelas,
                valor_parcela,
                saldo_devedor,
                valor_total,
                data_inicio,
                parcelas_pagas,
                curso
                FROM tb_mensalidades_cursos
                WHERE idaluno={0} AND ID_mensalidade_curso={1}", Globais.Main.PassarIdAluno,Globais.Main.PassarID_Mensalidade);

            DataTable dt = Banco.dql(vqueryCampos);
            tb_valor_parcela.Text = dt.Rows[0].Field<decimal>("valor_parcela").ToString().Replace(".", ",");
            nupd_parcelas.Value = Convert.ToInt32(dt.Rows[0].Field<Int32>("n_parcelas"));
        }

        private void tb_valor_parcela_KeyPress(object sender, KeyPressEventArgs e)
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
