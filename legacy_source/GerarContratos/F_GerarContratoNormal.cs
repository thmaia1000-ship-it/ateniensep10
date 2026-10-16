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
    public partial class F_GerarContratoNormal : Form
    {
        public F_GerarContratoNormal()
        {
            InitializeComponent();
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text != "")
            {

                var vcon = Banco.ConexaoBanco();

                MySqlCommand cm = new MySqlCommand();
                cm.CommandText = @"
                SELECT 
                tba.ID_aluno as 'ID',
                tba.nome_aluno as 'Aluno',
                tbm.valor_parcela as 'Parcela',
                tbm.turno as 'Contrato',
                tbm.ano_letivo as 'Ano',
                tbm.ID_mensalidade as 'ID'
                FROM tb_alunos as tba 
                INNER JOIN tb_mensalidades as tbm
                ON tba.ID_aluno = tbm.idaluno
                WHERE tba.nome_aluno LIKE ('" + tb_pesquisa.Text + "%') ";

                cm.Connection = vcon;
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cm;
                da.Fill(dt);
                dgv_SelecionarAluno.DataSource = dt;
                vcon.Close();
                dgv_SelecionarAluno.Columns[0].Width = 55;
                dgv_SelecionarAluno.Columns[1].Width = 227;
                dgv_SelecionarAluno.Columns[2].Width = 60;
                dgv_SelecionarAluno.Columns[3].Width = 148;
                dgv_SelecionarAluno.Columns[4].Width = 60;
                dgv_SelecionarAluno.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_SelecionarAluno.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_SelecionarAluno.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_SelecionarAluno.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_SelecionarAluno.Columns[5].Visible = false;
            }
            else
            {
                MessageBox.Show("Preencha o campo nome para pesquisar", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_pesquisa.Focus();
            }
        }

        private void dgv_SelecionarAluno_DoubleClick(object sender, EventArgs e)
        {
            Globais.Main.PassarParcelas = "";

            DataGridView dgv = (DataGridView)sender;

            Globais.Main.PassarIdAluno = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
            Globais.Main.PassarID_Mensalidade = dgv.Rows[dgv.SelectedRows[0].Index].Cells[5].Value.ToString();
            Globais.Main.PassarAno = dgv.Rows[dgv.SelectedRows[0].Index].Cells[4].Value.ToString();
            string tipoContrato = dgv.Rows[dgv.SelectedRows[0].Index].Cells[3].Value.ToString();

            if(tipoContrato == "MATUTINO" || tipoContrato == "VESPERTINO")
            {
                Globais.Main.PassarContrato = "NORMAL";
                if (Globais.Main.PassarAno == "2027")
                {
                    F_Contrato2027 contrato = new F_Contrato2027();
                    contrato.Show();
                }
                else
                {
                    F_ContratoNormal contrato = new F_ContratoNormal();
                    contrato.Show();
                }
               
            }
            else if(tipoContrato == "INTEGRAL")
            {
                Globais.Main.PassarContrato = "INTEGRAL";
                if (Globais.Main.PassarAno == "2027")
                {
                    F_Contrato2027 contrato = new F_Contrato2027();
                    contrato.Show();
                }
                else
                {
                    F_ContratoIntegral contrato = new F_ContratoIntegral();
                    contrato.Show();
                }
              
            }
            else
            {
                Globais.Main.PassarContrato = "M. PERÍODO";

                if (Globais.Main.PassarAno == "2027")
                {
                    F_Contrato2027 contrato = new F_Contrato2027();
                    contrato.Show();
                }
                else
                {
                    F_ContratoMeioPeriodo contrato = new F_ContratoMeioPeriodo();
                    contrato.Show();
                }
               
            }
            
        }

        private void F_GerarContratoNormal_Load(object sender, EventArgs e)
        {

        }
    }
}
