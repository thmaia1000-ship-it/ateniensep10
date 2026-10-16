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

namespace Escolar.declaracoes.selecionar
{
    public partial class selecionarAluno : Form
    {
        public selecionarAluno()
        {
            InitializeComponent();
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            var vcon = Banco.ConexaoBanco();

            MySqlCommand cm = new MySqlCommand();
            if (Globais.Main.Modo == "TRANSF")
            {
                cm.CommandText = $@"SELECT 
                                DISTINCT tba.ID_aluno as 'ID',	
                                tba.nome_aluno AS 'Aluno(a)',
                                tba.etapa as 'Etapa'
                                FROM tb_alunos AS tba
                                INNER JOIN tb_notas AS tbn ON tbn.idaluno = tba.ID_aluno
                                WHERE tba.nome_aluno LIKE '{tb_pesquisa.Text}%'
                                ORDER BY tba.nome_aluno";
            }
            else
            {
                cm.CommandText = $@"SELECT 
                                DISTINCT tba.ID_aluno as 'ID',	
                                tba.nome_aluno AS 'Aluno(a)',
                                tba.etapa as 'Etapa'
                                FROM tb_alunos AS tba
                                WHERE tba.nome_aluno LIKE '{tb_pesquisa.Text}%'
                                ORDER BY tba.nome_aluno";
            }
            cm.Connection = vcon;
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cm;
            da.Fill(dt);
            dgv_SelecionarAluno.DataSource = dt;
            vcon.Close();

            dgv_SelecionarAluno.Columns[0].Width = 55;
            dgv_SelecionarAluno.Columns[1].Width = 563;
            dgv_SelecionarAluno.Columns[2].Width = 110;
        }

        private void dgv_SelecionarAluno_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            Globais.Main.PassarIdAluno = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
            Globais.Main.PassarAluno = dgv.Rows[dgv.SelectedRows[0].Index].Cells[1].Value.ToString();
            Globais.Main.PassarEtapa = dgv.Rows[dgv.SelectedRows[0].Index].Cells[2].Value.ToString();

            if (Globais.Main.Modo == "TRANSF")
            {
                string etapa = dgv.Rows[dgv.SelectedRows[0].Index].Cells[2].Value.ToString();

                if (etapa == "MATERNAL I" || etapa == "MATERNAL II" || etapa == "JARDIM I" || etapa == "JARDIM II")
                {
                    MessageBox.Show("O Aluno(a) selecionado não é do fundamental I", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    impressao.GuiaTransferencia guia = new impressao.GuiaTransferencia();
                    guia.Show();
                }
            }
            else if (Globais.Main.Modo == "COMP")
            {
                Comparecimento form = new Comparecimento();
                form.ShowDialog();
            }
            else if (Globais.Main.Modo == "FREQ")
            {
                impressao.declaracao_frequencia freq = new impressao.declaracao_frequencia();
                freq.ShowDialog();
            }
            
        }

        private void selecionarAluno_Load(object sender, EventArgs e)
        {

        }

        private void selecionarAluno_FormClosed(object sender, FormClosedEventArgs e)
        {
            Globais.Main.Modo = "";
            Globais.Main.PassarIdAluno = "";
            Globais.Main.PassarAluno = "";
            Globais.Main.PassarEtapa = "";
        }
    }
}
