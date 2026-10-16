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
    public partial class F_GestaoMensalidade : Form
    {
        public F_GestaoMensalidade()
        {
            
            InitializeComponent();
        }

        private void btn_Editar_Click_1(object sender, EventArgs e)
        {
            if (tb_valor_parcela.Text != "" && cb_Etapa.Text != "" && cb_Turno.Text != "")
            {
                string vqueryCampos = String.Format(@"
                SELECT
                ID_mensalidade,
                n_parcelas,
                valor_parcela,
                saldo_devedor,
                valor_total,
                data_inicio,
                parcelas_pagas,
                idaluno,
                curso
                FROM tb_mensalidades
                WHERE ID_mensalidade={0}", Globais.Main.PassarID_Mensalidade);

                DataTable dt = Banco.dql(vqueryCampos);

                int Parcelas_Pagas = dt.Rows[0].Field<Int32>("parcelas_pagas");
                int idaluno = dt.Rows[0].Field<Int32>("idaluno");

                //Operação para pegar o Valor total do contrato. Calculando o valor da parcela e da quantidade nova de parcelas.
                decimal Valor_total = Convert.ToDecimal(tb_valor_parcela.Text) * nupd_parcelas.Value;

                //Soma de quantidade total de parcelas
                int n_parcelas = Parcelas_Pagas + Convert.ToInt32(nupd_parcelas.Value);


                int idetapa = 0;

                if (cb_Etapa.Text == "MATERNAL I")
                {
                    idetapa = 1;
                }
                else if (cb_Etapa.Text == "MATERNAL II")
                {
                    idetapa = 5;
                }
                else if (cb_Etapa.Text == "JARDIM I")
                {
                    idetapa = 2;
                }
                else if (cb_Etapa.Text == "JARDIM II")
                {
                    idetapa = 3;
                }
                else if (cb_Etapa.Text == "1° ANO")
                {
                    idetapa = 4;
                }

                //UPDATE Dados Mensalidade
                string queryAtualizarMensalidade = String.Format(@"UPDATE tb_mensalidades SET valor_total='{0}', saldo_devedor='{1}',valor_parcela='{2}',n_parcelas='{3}',turno='{4}', idturma={5} WHERE ID_mensalidade={6}", Valor_total.ToString().Replace(".", "").Replace(",", "."), Valor_total.ToString().Replace(".", "").Replace(",", "."), tb_valor_parcela.Text.Replace(".", "").Replace(",", "."), n_parcelas, cb_Turno.SelectedValue.ToString(), idetapa, Globais.Main.PassarID_Mensalidade);

                Banco.dml(queryAtualizarMensalidade);

                queryAtualizarMensalidade = String.Format(@"UPDATE tb_alunos SET turno='{0}',etapa='{1}' WHERE ID_aluno={2}", cb_Turno.Text, cb_Etapa.Text, idaluno);

                Banco.dml(queryAtualizarMensalidade);

                MessageBox.Show("Dados Alterados com sucesso!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information); ;


                Globais.Main.PassarParcelas = nupd_parcelas.Value.ToString();

                //Nome Aluno / Responsável Financeiro
                var vcon = Banco.ConexaoBanco();
                string Aluno = String.Format(@"
                SELECT turno
                FROM tb_alunos
                WHERE ID_aluno={0}", Globais.Main.PassarIdAluno);

                DataTable aluno = Banco.dql(Aluno);
                vcon.Close();

                string Contrato = aluno.Rows[0].Field<string>("turno");

                if (Contrato == "MATUTINO" || Contrato == "VESPERTINO")
                {
                    Globais.Main.PassarParcelas = nupd_parcelas.Value.ToString();
                    GerarContratos.F_Ano_PeriodoNormal f_ano = new GerarContratos.F_Ano_PeriodoNormal();
                    f_ano.ShowDialog();
                }
                else if (Contrato == "MATUTINO M. PERIODO" || Contrato == "VESPERTINO M. PERIODO")
                {
                    Globais.Main.PassarParcelas = nupd_parcelas.Value.ToString();
                    GerarContratos.F_Ano_MeioPeriodo f_ano = new GerarContratos.F_Ano_MeioPeriodo();
                    f_ano.ShowDialog();
                }
                else if (Contrato == "INTEGRAL")
                {
                    Globais.Main.PassarParcelas = nupd_parcelas.Value.ToString();
                    GerarContratos.F_Ano_PeriodoIntegral f_ano = new GerarContratos.F_Ano_PeriodoIntegral();
                    f_ano.ShowDialog();
                }
                Close();

            }
            else
            {
                MessageBox.Show("Valor da Mensalidade é Obrigatório");
            }
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

        private void F_GestaoMensalidade_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> turno = new Dictionary<string, string>();

            turno.Add("MATUTINO", "MATUTINO");
            turno.Add("VESPERTINO", "VESPERTINO");
            turno.Add("MATUTINO M. PERIODO", "MATUTINO M. PERIODO");
            turno.Add("VESPERTINO M. PERIODO", "VESPERTINO M. PERIODO");
            turno.Add("INTEGRAL", "INTEGRAL");
            cb_Turno.DataSource = new BindingSource(turno, null);
            cb_Turno.DisplayMember = "Value";
            cb_Turno.ValueMember = "Key";


            Dictionary<string, string> etapas = new Dictionary<string, string>();

            etapas.Add("MATERNAL I", "MATERNAL I");
            etapas.Add("MATERNAL II", "MATERNAL II");
            etapas.Add("JARDIM I", "JARDIM I");
            etapas.Add("JARDIM II", "JARDIM II");
            etapas.Add("1° ANO", "1° ANO");
            etapas.Add("2° ANO", "2° ANO");
            etapas.Add("3° ANO", "3° ANO");
            etapas.Add("4° ANO", "4° ANO");
            etapas.Add("5° ANO", "5° ANO");
            cb_Etapa.DataSource = new BindingSource(etapas, null);
            cb_Etapa.DisplayMember = "Value";
            cb_Etapa.ValueMember = "Key";

            string vqueryCampos = String.Format(@"
                SELECT
                n_parcelas,
                valor_parcela,
                valor_total,
                turno,
                idturma,
                parcelas_pagas,
                curso,
                idaluno
                FROM tb_mensalidades
                WHERE ID_mensalidade={0}", Globais.Main.PassarID_Mensalidade);

            DataTable dt = Banco.dql(vqueryCampos);

            int idaluno = dt.Rows[0].Field<Int32>("idaluno");
            int idturma = dt.Rows[0].Field<Int32>("idturma");

            string DadosAluno = String.Format(@"
                SELECT
                nome_aluno
                FROM tb_alunos
                WHERE ID_aluno={0}", idaluno);

            DataTable dados_aluno = Banco.dql(DadosAluno);

            string Etapa = String.Format(@"
                SELECT
                nome_etapa
                FROM tb_etapas
                WHERE ID_etapa={0}", idturma);

            DataTable etapa = Banco.dql(Etapa);

            //Coletando Nome do Aluno / Etapa do Aluno
            tb_Aluno.Text = dados_aluno.Rows[0].Field<string>("nome_aluno").ToUpper();
            cb_Etapa.SelectedValue = etapa.Rows[0].Field<string>("nome_etapa");

            //Dados da Mensalidade
            tb_valor_parcela.Text = dt.Rows[0].Field<decimal>("valor_parcela").ToString().Replace(".", ",");
            nupd_parcelas.Value = dt.Rows[0].Field<Int32>("n_parcelas");

            cb_Turno.SelectedValue = dt.Rows[0].Field<string>("turno");
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
