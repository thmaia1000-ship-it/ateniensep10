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
using System.Configuration;

namespace Escolar
{
    public partial class F_GerarMensalidade : Form
    {
        
        public F_GerarMensalidade()
        {
            InitializeComponent();
        }

        decimal Valor, Nparcelas, TotalParcelado, ValorDesconto, Entrada;

        private void abreForm(int nivel, Form f)
        {
            if (Globais.logado)
            {

                if (Globais.nivel >= nivel)
                //Procedimentos
                {

                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Acesso não permitido");
                }

            }
            else
            {
                MessageBox.Show("É necessário ter um usuário logado");
            }
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            F_SelecionarAlunoGerarMensalidade f_SelecionarAlunoGerarMensalidade = new F_SelecionarAlunoGerarMensalidade(this);
            f_SelecionarAlunoGerarMensalidade.ShowDialog();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            tb_Aluno.Text = "Busque aqui o Aluno(a)";
            tb_entrada.Text = "0";
            tb_Valor.Clear();
            cb_Parcelas.Text = "1";
            lb_obgAluno.Text = "";
            lb_ObgValor.Text = "";
            for (int i = 0; i < dgv_Parcelas.RowCount; i++)
            {
                dgv_Parcelas.Rows[i].DataGridView.Rows.Clear();
            }
        }

        private void F_GerarMensalidade_Load(object sender, EventArgs e)
        {
            lb_obgAluno.Text = "";
            tb_entrada.Text = "0";
            tb_Aluno.Text = "Busque aqui o Aluno(a)";
            tb_Valor.Clear();
            cb_Parcelas.Text = "1";
            lb_ObgValor.Text = "";

        }

        string DataAtual;

        private void btn_Parcelas_Click(object sender, EventArgs e)
        {
            if (cb_Parcelas.Text != "" && tb_Valor.Text != "" && tb_entrada.Text !="")
            {
                dgv_Parcelas.Rows.Clear();

                Valor = decimal.Parse(tb_Valor.Text);
                Entrada = decimal.Parse(tb_entrada.Text);
                Nparcelas = decimal.Parse(cb_Parcelas.Text);

                ValorDesconto = Valor - Entrada;
                TotalParcelado = ValorDesconto / Nparcelas;
                TotalParcelado = Math.Round(TotalParcelado, 2);


                DataAtual = dtp_Data.Value.ToShortDateString();
                //DataAtual = DateTime.Now.ToShortDateString();

                DateTime dt = Convert.ToDateTime(DataAtual);

                for (int i = 1; i <= Nparcelas; i++)
                {
                    dt = dt.AddMonths(1);

                    //dgv_Parcelas.Rows.Add(i, dt.ToShortDateString(), TotalParcelado);
                    dgv_Parcelas.Rows.Add(i, TotalParcelado, dt.ToShortDateString());
                }
            }
            else
            {
                MessageBox.Show("Todos os campos precisam ser preenchidos ", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
           
            if (tb_Aluno.Tag.ToString() != "" && tb_Valor.Text != "")
     
            {
                lb_obgAluno.Text = "";
                lb_ObgValor.Text = "";
                if (MessageBox.Show("CONFIRMAR O RECEBIMENTO DA MENSALIDADE?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string DataFim;
                var vcon = Banco.ConexaoBanco();
                DataFim = dgv_Parcelas.Rows[dgv_Parcelas.Rows.Count - 1].Cells[2].Value.ToString();
                //ValorParcelado = dgv_Parcelas.Rows[0].Cells[2].Value.ToString();

                string RegistrarMensalidade = String.Format(@"INSERT INTO
                    tb_mensalidades (entrada,n_parcelas, valor_total,valor_parcela,data_inicio,data_fim,parcelas_pagas,idaluno)
                    VALUES('{0}', '{1}','{2}','{3}','{4}','{5}','{6}',{7})", Entrada, cb_Parcelas.Text, Valor, TotalParcelado,dtp_Data.Text, DataFim,0, tb_Aluno.Tag.ToString());
                Banco.dml(RegistrarMensalidade);

                MessageBox.Show("Mensalidade Cadastrada com sucesso!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information); ;

                vcon.Close();
            }

            tb_Aluno.Text = "Busque aqui o Aluno(a)";
            tb_entrada.Text = "0";
            tb_Valor.Clear();
            cb_Parcelas.Text = "1";
            for (int i = 0; i < dgv_Parcelas.RowCount; i++)
            {
                dgv_Parcelas.Rows[i].DataGridView.Rows.Clear();
            }
        }
            else
            {
                MessageBox.Show("Aluno e Valor devem ser preenchidos", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                lb_obgAluno.Text = "*";
                lb_obgAluno.ForeColor = Color.Red;
                lb_ObgValor.Text = "*";
                lb_ObgValor.ForeColor = Color.Red;

            }
        }

    }
}

