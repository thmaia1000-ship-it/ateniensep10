using Escolar.Caixa;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Selecionar
{
    public partial class F_SelecionarAlunoEntradaCaixa : Form
    {
        F_Entrada f_Entrada;
        public F_SelecionarAlunoEntradaCaixa(F_Entrada f)
        {
            InitializeComponent();
            f_Entrada = f;
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text != "")
            {

                var vcon = Banco.ConexaoBanco();

                MySqlCommand cm = new MySqlCommand();
                cm.CommandText = "SELECT ID_aluno as 'ID', nome_aluno as 'Aluno', datanasc as 'Dt. Nasc' FROM tb_alunos WHERE nome_aluno LIKE ('" + tb_pesquisa.Text + "%')";

                cm.Connection = vcon;
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cm;
                da.Fill(dt);
                dgv_SelecionarAluno.DataSource = dt;
                vcon.Close();

                dgv_SelecionarAluno.Columns[0].Width = 55;
                dgv_SelecionarAluno.Columns[1].Width = 413;
                dgv_SelecionarAluno.Columns[2].Width = 120;
                dgv_SelecionarAluno.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else
            {
                MessageBox.Show("Preencha o campo nome para pesquisar");
                tb_pesquisa.Focus();
            }
        }

        private void dgv_SelecionarAluno_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            f_Entrada.tb_nome.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[1].Value.ToString();
            f_Entrada.tb_nome.Tag = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
            Globais.Main.PassarIdAluno = f_Entrada.tb_nome.Tag.ToString();
            f_Entrada.chk_outros.Enabled = true;
            Close();
        }
    }
}
