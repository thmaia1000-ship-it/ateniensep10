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

namespace Escolar.GerarContratos
{
    public partial class F_GerarCarne : Form
    {
        public F_GerarCarne()
        {
            InitializeComponent();
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text != "")
            {

                var vcon = Banco.ConexaoBanco();

                MySqlCommand cm = new MySqlCommand();
                cm.CommandText = "SELECT tba.ID_aluno as 'ID', tba.nome_aluno as 'Aluno', tba.datanasc as 'D. Nasc' FROM tb_alunos as tba WHERE nome_aluno LIKE ('" + tb_pesquisa.Text + "%') ";

                cm.Connection = vcon;
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cm;
                da.Fill(dt);
                dgv_SelecionarAluno.DataSource = dt;
                vcon.Close();
                dgv_SelecionarAluno.Columns[0].Width = 55;
                dgv_SelecionarAluno.Columns[1].Width = 400;
                dgv_SelecionarAluno.Columns[2].Width = 100;
                dgv_SelecionarAluno.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else
            {
                MessageBox.Show("Preencha o campo nome para pesquisar", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_pesquisa.Focus();
            }
        }

        private void dgv_SelecionarAluno_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            Globais.Main.PassarIdAluno = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();

            var vcon = Banco.ConexaoBanco();
            string vquery = String.Format(@"
            SELECT
                nome
                FROM tb_responsavel_financeiro
                WHERE idaluno =" + Globais.Main.PassarIdAluno);

            DataTable dt = Banco.dql(vquery);

            string Mensalidade = String.Format(@"
            SELECT
                idaluno
                FROM tb_mensalidades
                WHERE idaluno =" + Globais.Main.PassarIdAluno);

            DataTable mensalidade = Banco.dql(Mensalidade);

            if (dt.Rows.Count > 0)
            {
                if (mensalidade.Rows.Count > 0)
                {
                    GerarContratos.F_Ano_Carne carne = new GerarContratos.F_Ano_Carne();
                    carne.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Este Aluno(a) não possui uma Mensalidade Cadastrada!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            else
            {
                MessageBox.Show("Este Aluno(a) não possui um Responsável Financeiro Cadastrado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
