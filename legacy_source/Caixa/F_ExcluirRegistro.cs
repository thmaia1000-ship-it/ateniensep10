using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Caixa
{
    public partial class F_ExcluirRegistro : Form
    {
        public F_ExcluirRegistro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmar exclusão?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var vcon = Banco.ConexaoBanco();
                string VerificarMensalidade = String.Format(@"SELECT descricao,idaluno,mensalidades_paga,idmensalidade FROM tb_caixa WHERE ID_caixa ={0}", tb_ID.Text);

                DataTable verificarmensalidade = Banco.dql(VerificarMensalidade);
                vcon.Close();
                if (verificarmensalidade.Rows.Count > 0)
                {
                    string DescricaoCaixa = verificarmensalidade.Rows[0].Field<string>("descricao");
                    if (DescricaoCaixa == "Mensalidade")
                    {
                        string ID_Aluno = verificarmensalidade.Rows[0].Field<Int32>("idaluno").ToString();
                        string idmensalidade = verificarmensalidade.Rows[0].Field<Int32>("idmensalidade").ToString();
                        string Mens_Pagas = verificarmensalidade.Rows[0].Field<Int32>("mensalidades_paga").ToString();

                        vcon = Banco.ConexaoBanco();
                        string DescontarMensalidade = String.Format(@"UPDATE tb_mensalidades 
                                    SET 
                                    saldo_devedor= saldo_devedor + valor_parcela,
                                    parcelas_pagas = parcelas_pagas -1
                                    WHERE idaluno={0} AND ID_mensalidade={1}", ID_Aluno,idmensalidade);
                        Banco.dml(DescontarMensalidade);

                        string VerificarPagas = String.Format(@"SELECT ID_caixa FROM tb_caixa WHERE idaluno ={0} AND descricao = 'Mensalidade' AND mensalidades_paga={1} AND idmensalidade={2}", ID_Aluno, Mens_Pagas,idmensalidade);

                        DataTable verificarPagas = Banco.dql(VerificarPagas);

                        if (verificarPagas.Rows.Count > 1)
                        {
                            string ID_DuasFormas = verificarPagas.Rows[0].Field<Int32>("ID_caixa").ToString();

                            string ExlcluirDuasFormas = String.Format(@"DELETE FROM tb_caixa WHERE ID_caixa =" + ID_DuasFormas);

                            Banco.dml(ExlcluirDuasFormas);

                            ID_DuasFormas = verificarPagas.Rows[1].Field<Int32>("ID_caixa").ToString();

                            ExlcluirDuasFormas = String.Format(@"DELETE FROM tb_caixa WHERE ID_caixa =" + ID_DuasFormas);

                            Banco.dml(ExlcluirDuasFormas);
                        }

                        MessageBox.Show("Pagamento de mensalidade Cancelado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        vcon.Close();
                    }
                    else if (DescricaoCaixa == "Mensalidade Curso")
                    {
                        string Nome_curso = String.Format(@"SELECT curso,idmensalidade FROM tb_caixa WHERE ID_caixa={0}", tb_ID.Text);
                        DataTable nome_curso = Banco.dql(Nome_curso);

                        string Curso = nome_curso.Rows[0].Field<string>("curso").ToUpper();
                        string idmensalidade = nome_curso.Rows[0].Field<Int32>("idmensalidade").ToString();

                        string idcurso = String.Format(@"SELECT ID_curso FROM tb_cursos WHERE nome_curso='{0}'", Curso);
                        DataTable id_curso = Banco.dql(idcurso);

                        string ID_curso = id_curso.Rows[0].Field<Int32>("ID_curso").ToString();
                        string Mens_Pagas = verificarmensalidade.Rows[0].Field<Int32>("mensalidades_paga").ToString();

                        string ID_Aluno = verificarmensalidade.Rows[0].Field<Int32>("idaluno").ToString();

                        vcon = Banco.ConexaoBanco();
                        string DescontarMensalidade = string.Format(@"UPDATE tb_mensalidades_cursos 
                                    SET 
                                    saldo_devedor= saldo_devedor + valor_parcela,
                                    parcelas_pagas = parcelas_pagas -1
                                    WHERE idaluno={0} AND curso='{1}' AND ID_mensalidade_curso={2}", ID_Aluno, ID_curso,idmensalidade);
                        Banco.dml(DescontarMensalidade);

                        string VerificarPagas = String.Format(@"SELECT ID_caixa FROM tb_caixa WHERE idaluno ={0} AND descricao = 'Mensalidade Curso' AND mensalidades_paga={1} AND idmensalidade={2}", ID_Aluno, Mens_Pagas,idmensalidade);

                        DataTable verificarPagas = Banco.dql(VerificarPagas);

                        if (verificarPagas.Rows.Count > 1)
                        {
                            string ID_DuasFormas = verificarPagas.Rows[0].Field<Int32>("ID_caixa").ToString();

                            string ExlcluirDuasFormas = String.Format(@"DELETE FROM tb_caixa WHERE ID_caixa =" + ID_DuasFormas);

                            Banco.dml(ExlcluirDuasFormas);

                            ID_DuasFormas = verificarPagas.Rows[1].Field<Int32>("ID_caixa").ToString();

                            ExlcluirDuasFormas = String.Format(@"DELETE FROM tb_caixa WHERE ID_caixa =" + ID_DuasFormas);

                            Banco.dml(ExlcluirDuasFormas);
                        }

                        MessageBox.Show("Pagamento de mensalidade Cancelado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        vcon.Close();
                    }
                }

                vcon = Banco.ConexaoBanco();
                string VerificarVenda = String.Format(@"SELECT tipo_movimentacao,codigovenda FROM tb_caixa WHERE ID_caixa ={0}", tb_ID.Text);

                DataTable verificarvenda = Banco.dql(VerificarVenda);
                vcon.Close();
                if (verificarvenda.Rows.Count > 0)
                {
                    string Tipo = verificarvenda.Rows[0].Field<string>("tipo_movimentacao");


                    if (Tipo == "VENDA")
                    {
                        string CodigoVenda = verificarvenda.Rows[0].Field<Int32>("codigovenda").ToString();
                        string Quantidade_Linhas = String.Format(@"SELECT COUNT(codigovenda) as codigovenda FROM tb_vendas WHERE codigovenda={0}", CodigoVenda);

                        DataTable quantidade_linhas = Banco.dql(Quantidade_Linhas);

                        string Linhas = quantidade_linhas.Rows[0].Field<Int64>("codigovenda").ToString();

                        string Vendas = String.Format(@"SELECT idproduto,quantidade FROM tb_vendas WHERE codigovenda={0}", CodigoVenda);

                        DataTable vendas = Banco.dql(Vendas);

                        int Linha = -1;
                        int quantidade, idProduto;
                        for (int i = 1; i <= Convert.ToInt64(Linhas); i++)
                        {
                            Linha = Linha + 1;

                            idProduto = vendas.Rows[Linha].Field<Int32>("idproduto");
                            quantidade = vendas.Rows[Linha].Field<Int32>("quantidade");

                            var vconn = Banco.ConexaoBanco();
                            string BaixaEstoque = String.Format(@"UPDATE tb_produtos SET estoque= estoque +'" + quantidade + "' WHERE ID_produto ={0}", idProduto);
                            Banco.dml(BaixaEstoque);
                            vconn.Close();
                        }
                    }

                }
                string ExcluirRegistro = String.Format(@"DELETE FROM tb_caixa WHERE ID_caixa =" + tb_ID.Text);
                MessageBox.Show("Exclusão feita com sucesso!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Banco.dml(ExcluirRegistro);
                Close();
            }
        }

        private void tb_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente número", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
