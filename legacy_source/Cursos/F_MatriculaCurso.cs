using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Cadastros
{
    public partial class F_MatriculaCurso : Form
    {
        public F_MatriculaCurso()
        {
            InitializeComponent();
        }

        decimal Valor, Nparcelas, TotalParcelado, Entrada, ValorDesconto;
        string DataAtual;

        private void btn_BuscarAluno_Click(object sender, EventArgs e)
        {
            Selecionar.F_SelecionarAlunoCurso f_SelecionarAlunoCurso = new Selecionar.F_SelecionarAlunoCurso(this);
            f_SelecionarAlunoCurso.ShowDialog();
        }

        private void F_MatriculaCurso_Load(object sender, EventArgs e)
        {
            lb_obgAluno.Text = "";
            tb_Aluno.Text = "Busque aqui o Aluno(a)";
            tb_Valor.Clear();
            cb_Parcelas.Text = "1";
            lb_ObgValor.Text = "";

            string Cursos = @"
                SELECT 
                ID_curso,
                nome_curso
                FROM tb_cursos WHERE ID_curso > 2 ORDER BY nome_Curso";
            cb_curso.Items.Clear();
            cb_curso.DataSource = Banco.dql(Cursos);
            cb_curso.DisplayMember = "nome_Curso";
            cb_curso.ValueMember = "ID_curso";

            cb_curso.SelectedValue = -1;


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
            cb_ano.DataSource = new BindingSource(ano, null);
            cb_ano.DisplayMember = "Value";
            cb_ano.ValueMember = "Key";

            string AnoAtual = DateTime.Now.ToString("yyyy");
            cb_ano.SelectedValue = AnoAtual;
        }

        private void btn_Parcelas_Click(object sender, EventArgs e)
        {
            if (cb_Parcelas.Text != "" && tb_Valor.Text != "")
            {

                dgv_Parcelas.Rows.Clear();

                Valor = decimal.Parse(tb_Valor.Text);
                Nparcelas = decimal.Parse(cb_Parcelas.Text);

                //ValorDesconto = Valor - Entrada;
                TotalParcelado = Valor / Nparcelas;
                TotalParcelado = Math.Round(TotalParcelado, 2);

                string dia = "07";
                DataAtual = dtp_Data.Value.ToString(dia + "/MM/yyyy");
                //DataAtual = dtp_Data.Value.ToShortDateString();

                DateTime dt = Convert.ToDateTime(DataAtual);

                for (int i = 1; i <= Nparcelas; i++)
                {
                    dt = dt.AddMonths(1);
                    string Dia_Util = "5° Dia útil";
                    //dgv_Parcelas.Rows.Add(i, dt.ToShortDateString(), TotalParcelado);
                    dgv_Parcelas.Rows.Add(i, TotalParcelado, dt.ToShortDateString(), Dia_Util);
                    dgv_Parcelas.Columns[2].Visible = false;

                }
            }
            else
            {
                MessageBox.Show("Todos os campos precisam ser preenchidos ", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            if (cb_Parcelas.Text != "" && tb_Valor.Text != "")
            {

                dgv_Parcelas.Rows.Clear();

                Valor = decimal.Parse(tb_Valor.Text);
                //Entrada = decimal.Parse(tb_entrada.Text);
                Nparcelas = decimal.Parse(cb_Parcelas.Text);

                //ValorDesconto = Valor - Entrada;
                TotalParcelado = Valor / Nparcelas;
                TotalParcelado = Math.Round(TotalParcelado, 2);

                string dia = "07";
                DataAtual = dtp_Data.Value.ToString(dia + "/MM/yyyy");
                //DataAtual = dtp_Data.Value.ToShortDateString();

                DateTime dt = Convert.ToDateTime(DataAtual);

                for (int i = 1; i <= Nparcelas; i++)
                {
                    dt = dt.AddMonths(1);
                    string Dia_Util = "5° Dia útil";
                    //dgv_Parcelas.Rows.Add(i, dt.ToShortDateString(), TotalParcelado);
                    dgv_Parcelas.Rows.Add(i, TotalParcelado, dt.ToShortDateString(), Dia_Util);
                    dgv_Parcelas.Columns[2].Visible = false;

                }
            }
            else
            {
                MessageBox.Show("Todos os campos precisam ser preenchidos ", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (tb_Aluno.Tag.ToString() != "" && tb_Valor.Text != "")

            {
                lb_obgAluno.Text = "";
                lb_ObgValor.Text = "";
                if (MessageBox.Show("DESEJA GERAR A MENSALIDADE?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var vcon = Banco.ConexaoBanco();
                    string vquery = String.Format(@"SELECT ID_aluno,etapa,turno FROM tb_alunos WHERE ID_aluno={0}", tb_Aluno.Tag);

                    DataTable dt = Banco.dql(vquery);

                    string etapa = dt.Rows[0].Field<string>("etapa");
                    string turno = dt.Rows[0].Field<string>("turno");
                    int idturma = 0;
                    if (etapa == "MATERNAL I")
                    {
                        idturma = 1;
                    }
                    else if (etapa == "MATERNAL II")
                    {
                        idturma = 1;
                    }
                    else if (etapa == "JARDIM I")
                    {
                        idturma = 2;
                    }
                    else if (etapa == "JARDIM II")
                    {
                        idturma = 3;
                    }
                    else if (etapa == "1° ANO")
                    {
                        idturma = 4;
                    }

                    string DataPagar = dgv_Parcelas.Rows[0].Cells[2].Value.ToString();
                    string DataFim = dgv_Parcelas.Rows[dgv_Parcelas.Rows.Count - 1].Cells[2].Value.ToString();

                    DateTime pagar = Convert.ToDateTime(DataPagar);
                    DateTime fim = Convert.ToDateTime(DataFim);

                    vcon = Banco.ConexaoBanco();
                    //ValorParcelado = dgv_Parcelas.Rows[0].Cells[2].Value.ToString();

                    string Data = DateTime.Now.ToString("yyyy-MM-dd");
                    string Horario = DateTime.Now.ToString("hh:mm");

                    string dia = "09";
                    DataAtual = dtp_Data.Value.ToString("yyyy-MM-" + dia);

                    string RegistrarMensalidade = String.Format(@"INSERT INTO
                    tb_mensalidades_cursos ( valor_total,saldo_devedor,valor_parcela,data_inicio,n_parcelas,parcelas_pagas,curso,idaluno,data_gerada,usuario,ano_letivo,idturma,turno, idresponsavel)
                    VALUES('{0}', '{1}','{2}','{3}',{4},{5},{6},{7},'{8}','{9}',{10},{11},'{12}',{13})", Valor.ToString().Replace(".", "").Replace(",", "."), Valor.ToString().Replace(".", "").Replace(",", "."), TotalParcelado.ToString().Replace(".", "").Replace(",", "."), DataAtual, cb_Parcelas.Text,0,cb_curso.SelectedValue.ToString(),tb_Aluno.Tag.ToString(),Data, Globais.Main.PassarUsuario,cb_ano.SelectedValue.ToString(),idturma,turno, cb_respFinan.SelectedValue);
                    Banco.dml(RegistrarMensalidade);

                    vcon.Close();

                    MessageBox.Show("Mensalidade Registrada com sucesso!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information); ;

                    vcon.Close();


                }
                tb_Aluno.Text = "Busque aqui o Aluno(a)";
                tb_Valor.Clear();
                cb_Parcelas.Text = "1";
                //tb_entrada.Text = "0";
                for (int i = 0; i < dgv_Parcelas.RowCount; i++)
                {
                    dgv_Parcelas.Rows[i].DataGridView.Rows.Clear();
                }



            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            tb_Aluno.Text = "Busque aqui o Aluno(a)";
            tb_Valor.Clear();
            cb_Parcelas.Text = "1";
            lb_obgAluno.Text = "";
            lb_ObgValor.Text = "";
            for (int i = 0; i < dgv_Parcelas.RowCount; i++)
            {
                dgv_Parcelas.Rows[i].DataGridView.Rows.Clear();
            }
        }
    }
    
}
