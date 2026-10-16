
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

namespace Escolar.declaracoes.selecionar
{
    public partial class SelecionarAlunoRecisao : Form
    {
        public SelecionarAlunoRecisao()
        {
            InitializeComponent();
        }


        private void Buscar()
        {
            var vcon = Banco.ConexaoBanco();

            MySqlCommand cm = new MySqlCommand();

            cm.CommandText = $@"SELECT 
                                tba.ID_aluno as 'ID',
                                tbm.ID_mensalidade as 'ID_mensalidade',
                                tba.nome_aluno AS 'Aluno(a)',
                                tba.etapa as 'Etapa'
                                FROM tb_alunos AS tba
                                INNER JOIN tb_mensalidades as tbm ON tbm.idaluno = tba.ID_aluno
                                WHERE tba.nome_aluno LIKE '{tb_pesquisa.Text}%' AND tbm.ano_letivo = {cb_ano.SelectedValue}
                                ORDER BY tba.nome_aluno";

            cm.Connection = vcon;
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cm;
            da.Fill(dt);
            dgv_SelecionarAluno.DataSource = dt;
            vcon.Close();

            dgv_SelecionarAluno.Columns[1].Visible = false;
            dgv_SelecionarAluno.Columns[0].Width = 55;
            dgv_SelecionarAluno.Columns[2].Width = 563;
            dgv_SelecionarAluno.Columns[3].Width = 110;
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgv_SelecionarAluno_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            Globais.Main.PassarIdAluno = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
            Globais.Main.PassarID_Mensalidade = dgv.Rows[dgv.SelectedRows[0].Index].Cells[1].Value.ToString();

            Declaracao_RecisaoContrato recisao = new Declaracao_RecisaoContrato();
            recisao.ShowDialog();

            Close();
        }

        private void SelecionarAlunoRecisao_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> ano = new Dictionary<string, string>();

            ano.Add("2022", "2022");
            ano.Add("2023", "2023");
            ano.Add("2024", "2024");
            ano.Add("2025", "2025");
            ano.Add("2026", "2026");
            ano.Add("2027", "2027");
            ano.Add("2028", "2028");
            ano.Add("2029", "2029");
            ano.Add("2030", "2030");
            cb_ano.DataSource = new BindingSource(ano, null);
            cb_ano.DisplayMember = "Value";
            cb_ano.ValueMember = "Key";

            cb_ano.SelectedValue = DateTime.Now.ToString("yyyy");
        }

        private void cb_ano_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}
