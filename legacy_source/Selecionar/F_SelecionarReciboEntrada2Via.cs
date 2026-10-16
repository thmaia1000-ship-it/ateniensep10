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
    public partial class F_SelecionarReciboEntrada2Via : Form
    {
        public F_SelecionarReciboEntrada2Via()
        {
            InitializeComponent();
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text != "")
            {

                var vcon = Banco.ConexaoBanco();

                MySqlCommand cm = new MySqlCommand();
                cm.CommandText = "SELECT ID_caixa as 'ID', nome as 'Nome', tipo_movimentacao as 'Tipo', valor_total as 'Valor' FROM tb_caixa WHERE tipo_movimentacao != 'SAIDA' AND ID_caixa LIKE ('" + tb_pesquisa.Text + "%') OR nome LIKE ('" + tb_pesquisa.Text + "%')";

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

            //string VerificarTipo = dgv.Rows[dgv.SelectedRows[0].Index].Cells[2].Value.ToString();
            Globais.Main.PassarIdCaixa = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
            Globais.Main.Modo = "1";

            var vcon = Banco.ConexaoBanco();
            string Verificar = String.Format(@"SELECT idaluno,tipo_movimentacao,descricao,idmensalidade FROM tb_caixa WHERE ID_caixa={0}", Globais.Main.PassarIdCaixa);
            DataTable verificar = Banco.dql(Verificar);
            vcon.Close();

            string tipo_movimentacao = verificar.Rows[0].Field<string>("tipo_movimentacao");
            string descricao = verificar.Rows[0].Field<string>("descricao");
            string IDaluno = verificar.Rows[0].Field<Int32>("idaluno").ToString();

            if (!verificar.Rows[0].IsNull("idmensalidade"))
            {
                Globais.Main.PassarID_Mensalidade = verificar.Rows[0].Field<Int32>("idmensalidade").ToString();
            }
            if (tipo_movimentacao == "ENTRADA" && descricao != "Mensalidade" && descricao != "Mensalidade Curso")
            {
                vcon = Banco.ConexaoBanco();
                string Aluno = String.Format(@"
                            SELECT
                            valor_total,
                            descricao,
                            nome,
                            usuario,
                            data
                            FROM tb_caixa
                            WHERE tipo_movimentacao = 'ENTRADA' AND ID_caixa=" + Globais.Main.PassarIdCaixa);

                DataTable DadosAluno = Banco.dql(Aluno);
                vcon.Close();

                if (DadosAluno.Rows.Count > 0)
                {
                    Caixa.F_ReciboEntrada f_ReciboEntrada = new Caixa.F_ReciboEntrada();
                    f_ReciboEntrada.ShowDialog();
                    Close();
                }
            }

            else if (tipo_movimentacao == "ENTRADA" && descricao == "Mensalidade" || descricao == "Mensalidade Curso")
            {
                string Nome_curso = String.Format(@"SELECT curso FROM tb_caixa WHERE ID_caixa={0}", Globais.Main.PassarIdCaixa);
                DataTable nome_curso = Banco.dql(Nome_curso);

                string Curso = nome_curso.Rows[0].Field<string>("curso").ToUpper();
                Globais.Main.PassarNomeCurso = Curso;

                string idcurso = String.Format(@"SELECT ID_curso FROM tb_cursos WHERE nome_curso='{0}'", Curso);
                DataTable id_curso = Banco.dql(idcurso);

                Globais.Main.PassarCurso = id_curso.Rows[0].Field<Int32>("ID_curso").ToString();

                if (descricao == "Mensalidade Curso")
                {
                    Globais.Main.Modo = "2";
                }
                Globais.Main.PassarIdAluno = IDaluno;

                vcon = Banco.ConexaoBanco();
                string MensalidadeCaixa = String.Format(@"
                            SELECT
                            ID_caixa,
                            valor_total,
                            descricao,
                            forma,
                            nome,
                            usuario,
                            data,
                            horario,
                            idaluno,
                            mensalidades_paga,
                            idmensalidade
                            FROM tb_caixa
                            WHERE ID_caixa={0} AND curso='{1}'", Globais.Main.PassarIdCaixa, Curso);

                DataTable DadosMensalidadeCaixa = Banco.dql(MensalidadeCaixa);

                Globais.Main.PassarForma1 = "";
                Globais.Main.PassarForma2 = "";
                Globais.Main.PassarForma = DadosMensalidadeCaixa.Rows[0].Field<string>("forma");
                Globais.Main.PassarCaixa = DadosMensalidadeCaixa.Rows[0].Field<decimal>("valor_total").ToString();
                Globais.Main.PassarIdCaixa = DadosMensalidadeCaixa.Rows[0].Field<Int32>("ID_caixa").ToString();
                Globais.Main.PassarData = DadosMensalidadeCaixa.Rows[0].Field<DateTime>("data").ToString("dd/MM/yyyy");
                Globais.Main.PassarHorario = DadosMensalidadeCaixa.Rows[0].Field<string>("horario");
                Globais.Main.PassarMensalidades_paga = DadosMensalidadeCaixa.Rows[0].Field<Int32>("mensalidades_paga").ToString();
                Globais.Main.PassarID_Mensalidade = DadosMensalidadeCaixa.Rows[0].Field<Int32>("idmensalidade").ToString();
                Globais.Main.PassarDesc = DadosMensalidadeCaixa.Rows[0].Field<string>("descricao");
                string idaluno = DadosMensalidadeCaixa.Rows[0].Field<Int32>("idaluno").ToString();

                string VerificarDuasFormas = String.Format(@"
                            SELECT
                            idforma2
                            FROM tb_caixa
                            WHERE ID_caixa={0}", Convert.ToInt32(Globais.Main.PassarIdCaixa));
                DataTable verificarduasFormas = Banco.dql(VerificarDuasFormas);

                int idforma2 = verificarduasFormas.Rows[0].Field<Int32>("idforma2");

                if(idforma2 != 0)
                {
                            VerificarDuasFormas = String.Format(@"
                            SELECT
                            forma,
                            valor_total
                            FROM tb_caixa
                            WHERE ID_caixa={0}", idforma2);
                            verificarduasFormas = Banco.dql(VerificarDuasFormas);

                        Globais.Main.PassarForma = "";
                        Globais.Main.PassarForma1 = DadosMensalidadeCaixa.Rows[0].Field<string>("forma");
                        Globais.Main.PassarForma2 = verificarduasFormas.Rows[0].Field<string>("forma");
                        decimal Valor1 = DadosMensalidadeCaixa.Rows[0].Field<decimal>("valor_total");
                        decimal Valor2 = verificarduasFormas.Rows[0].Field<decimal>("valor_total");
                        decimal ValorTotal = Valor1 + Valor2;
                        Globais.Main.PassarCaixa = ValorTotal.ToString();

                }
                string Aluno = String.Format(@"
                           SELECT
                           nome_aluno
                           FROM tb_alunos
                           WHERE ID_aluno ={0} ", IDaluno);

                DataTable DadosAluno = Banco.dql(Aluno);

                Globais.Main.PassarAluno = DadosAluno.Rows[0].Field<string>("nome_aluno");



                Mensalidades.SelecionarRecibo selecionar = new Mensalidades.SelecionarRecibo();
                selecionar.ShowDialog();

                Close();
            }

            else if (tipo_movimentacao == "VENDA")
            {

                vcon = Banco.ConexaoBanco();
                string CodigoVenda = String.Format(@"
                            SELECT
                            ID_caixa,
                            codigovenda,
                            forma,
                            nome,
                            idaluno,
                            observacao,
                            data,
                            horario
                            FROM tb_caixa
                            WHERE ID_caixa=" + Globais.Main.PassarIdCaixa);

                DataTable Codigo = Banco.dql(CodigoVenda);
                vcon.Close();

                Globais.Main.PassarCodigoVenda = Codigo.Rows[0].Field<Int32>("codigovenda").ToString();
                Globais.Main.PassarForma = Codigo.Rows[0].Field<string>("forma");
                Globais.Main.PassarIdAluno = Codigo.Rows[0].Field<Int32>("idaluno").ToString();
                Globais.Main.PassarDesc = Codigo.Rows[0].Field<string>("observacao");
                Globais.Main.PassarIdCaixa = Codigo.Rows[0].Field<Int32>("ID_caixa").ToString();
                Globais.Main.PassarHorario = Codigo.Rows[0].Field<string>("horario");
                Globais.Main.PassarData = Codigo.Rows[0].Field<DateTime>("data").ToString("dd/MM/yyyy");
                Globais.Main.PassarForma1 = "";
                Globais.Main.PassarForma2 = "";

                if (Codigo.Rows.Count > 0)
                {
                    vcon = Banco.ConexaoBanco();
                    string Pagante = String.Format(@"
                            SELECT
                            nome
                            FROM tb_vendas
                            WHERE codigovenda=" + Globais.Main.PassarCodigoVenda);

                    DataTable pagante = Banco.dql(Pagante);
                    vcon.Close();

                    Globais.Main.PassarPagante = pagante.Rows[0].Field<string>("nome");

                    Mensalidades.qtdVias vias = new Mensalidades.qtdVias();
                    vias.ShowDialog();

                    Close();
                }

            }
            else
            {
                MessageBox.Show("O ID selecionado é uma SAÍDA!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
