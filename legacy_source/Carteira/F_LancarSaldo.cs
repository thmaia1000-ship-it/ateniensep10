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

namespace Escolar.Carteira
{
    public partial class F_LancarSaldo : Form
    {
        F_GestaoAlunos f_GestaoAlunos;
        public F_LancarSaldo(F_GestaoAlunos f)
        {
            InitializeComponent();
            f_GestaoAlunos = f;
        }

        private void AtualizarDgv()
        {
            tb_aluno.Text = f_GestaoAlunos.tb_Aluno.Text;

            var vcon = Banco.ConexaoBanco();
            MySqlCommand cm = new MySqlCommand();
            cm.CommandText = "SELECT valor_total as 'Valor',tipo as 'Tipo', data_gerada as 'Data', descricao as 'Referente', usuario as 'Atendente', ID_carteira FROM tb_carteira WHERE idaluno = ('" + Globais.Main.PassarIdAluno + "%')";

            cm.Connection = vcon;
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cm;
            da.Fill(dt);
            dgv_Carteira.DataSource = dt;
            dgv_Carteira.Columns[0].Width = 160;
            dgv_Carteira.Columns[1].Width = 140;
            dgv_Carteira.Columns[2].Width = 120;
            dgv_Carteira.Columns[3].Width = 152;
            dgv_Carteira.Columns[4].Width = 102;
            dgv_Carteira.Columns[5].Visible = false;

            dgv_Carteira.Columns[0].DefaultCellStyle.Format = "C";
            dgv_Carteira.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Carteira.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            string SaldoCarteira = String.Format(@"
                SELECT saldo_carteira
                FROM tb_carteira_aluno
                WHERE idaluno={0}", Globais.Main.PassarIdAluno);
            DataTable saldocarteira = Banco.dql(SaldoCarteira);


            lb_Saldo.Text = saldocarteira.Rows[0].Field<decimal>("saldo_carteira").ToString("C");

            vcon.Close();

            dgv_Carteira.ClearSelection();
        }

        private void F_LancarSaldo_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> etapa = new Dictionary<string, string>();

            etapa.Add("ENTRADA", "ENTRADA");
            etapa.Add("SAIDA", "SAIDA");
            etapa.Add("TAXA", "TAXA");
            etapa.Add("MULTA", "MULTA");
            cb_tipo.DataSource = new BindingSource(etapa, null);
            cb_tipo.DisplayMember = "Value";
            cb_tipo.ValueMember = "Key";

            AtualizarDgv();
            tb_valor.Clear();
            cb_tipo.SelectedValue = -1;
            tb_descricao.Text = "";
        }

        private void btn_lancar_Click(object sender, EventArgs e)
        {
            if (tb_valor.Text == "")
            {
                MessageBox.Show("Informe o Valor!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_valor.Focus();
            }
            else if (cb_tipo.Text == "")
            {
                MessageBox.Show("Informe o Tipo!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cb_tipo.Focus();
            }
            else if (MessageBox.Show(cb_tipo.SelectedValue.ToString() + " Adicionadar a carteira?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string Data = DateTime.Now.ToString("yyyy-MM-dd");

                string queryInsertCarteira = String.Format(@"
                INSERT INTO 
                    tb_carteira (nome_aluno,valor_total,tipo,descricao,idaluno,data_gerada,usuario)  
                VALUES ('{0}','{1}','{2}','{3}',{4},'{5}','{6}')", tb_aluno.Text, tb_valor.Text.Replace(",","."), cb_tipo.SelectedValue, tb_descricao.Text.ToUpper(), Globais.Main.PassarIdAluno, Data, Globais.Main.PassarUsuario);

                Banco.dml(queryInsertCarteira);
                MessageBox.Show(cb_tipo.SelectedValue.ToString() + " Adicionada a carteira!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (cb_tipo.SelectedValue.ToString() == "ENTRADA")
                {
                    string QueryAtualizarSaldo = String.Format(@"UPDATE tb_carteira_aluno SET saldo_carteira= saldo_carteira +'" + tb_valor.Text.Replace(",", ".") + "' WHERE idaluno ={0}", Globais.Main.PassarIdAluno);

                    Banco.dml(QueryAtualizarSaldo);
                }
                else
                {
                    string QueryAtualizarSaldo = String.Format(@"UPDATE tb_carteira_aluno SET saldo_carteira= saldo_carteira -'" + tb_valor.Text.Replace(",", ".") + "' WHERE idaluno ={0}", Globais.Main.PassarIdAluno);

                    Banco.dml(QueryAtualizarSaldo);
                }
                AtualizarDgv();
                tb_valor.Clear();
                tb_descricao.Clear();
                cb_tipo.SelectedValue = -1;
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

        private void dgv_Carteira_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.SelectedRows.Count > 0)
            {
                Globais.Main.PassarIdCarteira = dgv.Rows[dgv.SelectedRows[0].Index].Cells[5].Value.ToString();

                tb_valor.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString().Replace("R$ ","").Replace(".", "");
                cb_tipo.SelectedValue = dgv.Rows[dgv.SelectedRows[0].Index].Cells[1].Value.ToString();
                tb_descricao.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[3].Value.ToString();
            }
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja excluir este registro??", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            else
            {
                string ValorCarteira = String.Format(@"SELECT valor_total, tipo FROM tb_carteira WHERE ID_carteira ={0}", Globais.Main.PassarIdCarteira);
                DataTable dt = Banco.dql(ValorCarteira);
                string tipo = dt.Rows[0].Field<string>("tipo");
                decimal Valor = dt.Rows[0].Field<decimal>("valor_total");

                if (tipo == "ENTRADA")
                {
                    string QueryAtualizarSaldo = String.Format(@"UPDATE tb_carteira_aluno SET saldo_carteira= saldo_carteira -'" + Valor + "' WHERE idaluno ={0}", Globais.Main.PassarIdAluno);

                    Banco.dml(QueryAtualizarSaldo);
                }
                else
                {
                    string QueryAtualizarSaldo = String.Format(@"UPDATE tb_carteira_aluno SET saldo_carteira= saldo_carteira +'" + Valor + "' WHERE idaluno ={0}", Globais.Main.PassarIdAluno);

                    Banco.dml(QueryAtualizarSaldo);
                }

                string vqueryExcluirAluno = String.Format(@"
                DELETE FROM
                    tb_carteira
                WHERE
                    ID_carteira={0}
                 ", Globais.Main.PassarIdCarteira);
                Banco.dml(vqueryExcluirAluno);
                dgv_Carteira.Rows.Remove(dgv_Carteira.CurrentRow);

                MessageBox.Show("Registro excluído", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizarDgv();
            }
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            
        }
    }
}
