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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Escolar
{
    public partial class F_ImprimirBoletim : Form
    {

        public F_ImprimirBoletim()
        {
            InitializeComponent();
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (tb_pesquisa.TextLength == 0)
            {
                MessageBox.Show("Preencha o campo nome para pesquisar","Mensagem do sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                tb_pesquisa.Focus();
            }
            else if (cb_FiltrarAno.Text =="")
            {
                MessageBox.Show("Selecione o Ano Letivo para pesquisar", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cb_FiltrarAno.Focus();
            }
            else
            {
                var vcon = Banco.ConexaoBanco();

                MySqlCommand cm = new MySqlCommand();
                cm.CommandText = @"
                SELECT 
                tba.ID_aluno as 'ID',
                tba.nome_aluno as 'Nome',
                tbn.ano_letivo as 'Ano Letivo'  
                FROM tb_notas as tbn, tb_alunos as tba
                WHERE tba.ID_aluno = tbn.idaluno AND tba.nome_aluno LIKE ('" + tb_pesquisa.Text + "%') AND tbn.ano_letivo LIKE ('%" + cb_FiltrarAno.SelectedValue.ToString() + "%') LIMIT 1";
                cm.Connection = vcon;
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cm;
                da.Fill(dt);
                dgv_SelecionarAluno.DataSource = dt;
                dgv_SelecionarAluno.Columns[0].Width = 55;
                dgv_SelecionarAluno.Columns[1].Width = 405;
                dgv_SelecionarAluno.Columns[2].Width = 85;

                if (dt.Rows.Count > 0)
                {
                    
                    btn_Imprimir.Enabled = true;
                   
                }

                dgv_SelecionarAluno.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                vcon.Close();
            }
        }

        private void dgv_SelecionarAluno_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Gerar Boletim?", "Mensagem do sistema", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes )
            {
                F_BoletimAteniense f_BoletimAteniense = new F_BoletimAteniense(this);
                f_BoletimAteniense.ShowDialog();
            }
            else
            {
                return;
            }
           
        }

        private void dgv_SelecionarAluno_SelectionChanged(object sender, EventArgs e)
        {
            btn_Imprimir.Enabled = true;
        }

        private void F_ImprimirBoletim_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> ano = new Dictionary<string, string>();

            ano.Add("2020", "2020");
            ano.Add("2021", "2021");
            ano.Add("2022", "2022");
            ano.Add("2023", "2023");
            ano.Add("2024", "2024");
            ano.Add("2025", "2025");
            ano.Add("2026", "2026");
            ano.Add("2027", "2027");
            ano.Add("2028", "2028");
            ano.Add("2029", "2029");
            ano.Add("2030", "2030");
            ano.Add("2031", "2031");
            ano.Add("2032", "2032");
            ano.Add("2033", "2033");
            ano.Add("2034", "2034");
            ano.Add("2035", "2035");
            ano.Add("2036", "2036");
            ano.Add("2037", "2037");
            ano.Add("2038", "2038");
            ano.Add("2039", "2039");
            ano.Add("2040", "2040");
            ano.Add("2041", "2041");
            ano.Add("2042", "2042");
            ano.Add("2043", "2043");
            ano.Add("2044", "2044");
            ano.Add("2045", "2045");
            ano.Add("2046", "2046");
            ano.Add("2047", "2047");
            ano.Add("2048", "2048");
            ano.Add("2049", "2049");
            ano.Add("2050", "2050");
            cb_FiltrarAno.DataSource = new BindingSource(ano, null);
            cb_FiltrarAno.DisplayMember = "Value";
            cb_FiltrarAno.ValueMember = "Key";

            cb_FiltrarAno.SelectedValue = -1;
            btn_Imprimir.Enabled = false;
        }

        private void cb_FiltrarCurso_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var vcon = Banco.ConexaoBanco();

                MySqlCommand cm = new MySqlCommand();
                cm.CommandText = @"
                SELECT 
                tba.ID_aluno as 'ID',
                tba.nome_aluno as 'Nome',
                tbn.ano_letivo as 'Ano Letivo'  
                FROM tb_notas as tbn, tb_alunos as tba
                WHERE tba.ID_aluno = tbn.idaluno AND tba.nome_aluno LIKE ('" + tb_pesquisa.Text + "%') AND tbn.ano_letivo LIKE ('%" + cb_FiltrarAno.SelectedValue.ToString() + "%') LIMIT 1";
            cm.Connection = vcon;
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cm;
                da.Fill(dt);
                dgv_SelecionarAluno.DataSource = dt;
                dgv_SelecionarAluno.Columns[0].Width = 55;
                dgv_SelecionarAluno.Columns[1].Width = 405;
                dgv_SelecionarAluno.Columns[2].Width = 85;

            if (dt.Rows.Count > 0)
                {
                
                btn_Imprimir.Enabled = true;
                
            }

                dgv_SelecionarAluno.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                vcon.Close();
            
            }
    }
}

