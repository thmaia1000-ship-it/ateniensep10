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

namespace Escolar.Selecionar
{
    public partial class F_SelecionarReciboSaida2Via : Form
    {
        public F_SelecionarReciboSaida2Via()
        {
            InitializeComponent();
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text != "")
            {

                var vcon = Banco.ConexaoBanco();

                MySqlCommand cm = new MySqlCommand();
                cm.CommandText = "SELECT ID_caixa as 'ID', nome as 'Nome', tipo_movimentacao as 'Tipo', valor_total as 'Valor' FROM tb_caixa WHERE ID_caixa LIKE ('" + tb_pesquisa.Text + "%') OR nome LIKE ('" + tb_pesquisa.Text + "%')";

                cm.Connection = vcon;
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cm;
                da.Fill(dt);
                dgv_SelecionarAluno.DataSource = dt;
                vcon.Close();

                dgv_SelecionarAluno.Columns[0].Width = 55;
                dgv_SelecionarAluno.Columns[1].Width = 313;
                dgv_SelecionarAluno.Columns[2].Width = 120;
                dgv_SelecionarAluno.Columns[3].Width = 100;
                dgv_SelecionarAluno.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else
            {
                MessageBox.Show("Preencha o campo ID para pesquisar");
                tb_pesquisa.Focus();
            }
        }

        private void dgv_SelecionarAluno_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            //f_Entrada.tb_nome.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[1].Value.ToString();
            Globais.Main.PassarIdCaixa = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
            Globais.Main.Modo = "1";
            var vcon = Banco.ConexaoBanco();
            string Aluno = String.Format(@"
                            SELECT
                            valor_total,
                            descricao,
                            nome,
                            usuario,
                            data
                            FROM tb_caixa
                            WHERE tipo_movimentacao = 'SAIDA' AND ID_caixa=" + Globais.Main.PassarIdCaixa);

            DataTable DadosAluno = Banco.dql(Aluno);
            vcon.Close();

            if (DadosAluno.Rows.Count > 0)
            {
                F_ReciboSaida f_ReciboEntrada = new F_ReciboSaida();
                f_ReciboEntrada.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("O ID selecionado é uma ENTRADA!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
