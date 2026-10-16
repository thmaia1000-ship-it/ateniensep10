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
namespace Escolar.Gestão
{
    public partial class AlterarRegistroCaixa : Form
    {

        string idSelecionado = "";

        int linha = 0;

        public AlterarRegistroCaixa()
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
                dgv_GestaoRegistros.DataSource = dt;
                dgv_GestaoRegistros.Columns[0].Width = 45;
                dgv_GestaoRegistros.Columns[1].Width = 294;
                dgv_GestaoRegistros.Columns[2].Width = 75;
                dgv_GestaoRegistros.Columns[3].Width = 70;
                dgv_GestaoRegistros.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                vcon.Close();
            }
            else
            {
                MessageBox.Show("Preencha o campo para pesquisar", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_GestaoAlunos_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.SelectedRows.Count > 0)
            {
                idSelecionado = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();

                string vqueryCampos = String.Format(@"
                 SELECT
                    forma,
                    data,
                    valor_total
                FROM
                    tb_caixa
                WHERE ID_caixa={0}
                 ", idSelecionado);

                DataTable dt = Banco.dql(vqueryCampos);
                cb_forma.SelectedValue = dt.Rows[0].Field<string>("forma");
                dtp_Data.Value = dt.Rows[0].Field<DateTime>("data");
                tb_Valor.Text = dt.Rows[0].Field<decimal>("valor_total").ToString("N"); 

            }
        }

        private void AlterarRegistroCaixa_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> forma = new Dictionary<string, string>();

            forma.Add("CRÉDITO", "CRÉDITO");
            forma.Add("DÉBITO", "DÉBITO");
            forma.Add("DINHEIRO", "DINHEIRO");
            forma.Add("PIX", "PIX");
            cb_forma.DataSource = new BindingSource(forma, null);
            cb_forma.DisplayMember = "Value";
            cb_forma.ValueMember = "Key";
        }

        bool alterar_valor, alterar_forma, alterar_data = false;

        private void Log_Update()
        {
            string Registro = $@"SELECT * FROM tb_caixa WHERE ID_caixa={idSelecionado}";
            DataTable alterar = Banco.dql(Registro);

            string detalhes = "";
            string antigo = "";
            string novo = "";

            string acao = "UPDATE";
            string tabela_afetada = "tb_caixa";
            int id_registro = Convert.ToInt32(idSelecionado);
            string data_hora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            for (int i = 0; i < 3; i++)
            {
                if (alterar_valor)
                {
                    antigo = alterar.Rows[0].Field<Decimal>("valor_total").ToString().Replace(",",".");
                    novo = tb_Valor.Text.Replace(",", ".");
                    detalhes = $"Editou o valor da falta de {antigo} para {novo}";
                    alterar_valor = false;

                    Banco.log(acao, tabela_afetada, id_registro, detalhes, data_hora); // Inserindo dados na Log
                }
                else if (alterar_forma)
                {
                    antigo = alterar.Rows[0].Field<string>("forma");
                    novo = cb_forma.Text;
                    detalhes = $"Editou a forma de {antigo} para {novo}";
                    alterar_forma = false;

                    Banco.log(acao, tabela_afetada, id_registro, detalhes, data_hora); // Inserindo dados na Log
                }
                else if (alterar_data)
                {
                    antigo = alterar.Rows[0].Field<DateTime>("data").ToString("yyyy-MM-dd");
                    novo = dtp_Data.Value.ToString("yyyy-MM-dd");
                    detalhes = $"Editou a data de {antigo} para {novo}";
                    alterar_data = false;

                    Banco.log(acao, tabela_afetada, id_registro, detalhes, data_hora); // Inserindo dados na Log
                }
            }
        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja salvar estes dados?", "Salvar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            else
            {
                Log_Update();
                linha = dgv_GestaoRegistros.SelectedRows[0].Index;
                string AlterarRegistro = String.Format(@"UPDATE tb_caixa SET forma='{0}',valor_total='{1}',data='{2}' WHERE ID_caixa ={3}", cb_forma.SelectedValue.ToString(),tb_Valor.Text.Replace(".", "").Replace(",", "."),dtp_Data.Value.ToString("yyyy-MM-dd"),idSelecionado.ToString());

                Banco.dml(AlterarRegistro);

                MessageBox.Show("Dados Alterados com sucesso!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information); ;

                var vcon = Banco.ConexaoBanco();

                MySqlCommand cm = new MySqlCommand();
                cm.CommandText = "SELECT ID_caixa as 'ID', nome as 'Nome', tipo_movimentacao as 'Tipo', valor_total as 'Valor' FROM tb_caixa WHERE tipo_movimentacao != 'SAIDA' AND ID_caixa LIKE ('" + tb_pesquisa.Text + "%') OR nome LIKE ('" + tb_pesquisa.Text + "%')";

                cm.Connection = vcon;
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cm;
                da.Fill(dt);
                dgv_GestaoRegistros.DataSource = dt;
                dgv_GestaoRegistros.Columns[0].Width = 45;
                dgv_GestaoRegistros.Columns[1].Width = 294;
                dgv_GestaoRegistros.Columns[2].Width = 75;
                dgv_GestaoRegistros.Columns[3].Width = 70;
                dgv_GestaoRegistros.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                vcon.Close();
            }
        }

        private void cb_forma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            alterar_forma = true;
        }

        private void dtp_Data_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dtp_Data_KeyPress(object sender, KeyPressEventArgs e)
        {
            alterar_data = true;
        }

        private void tb_Valor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente número e virgula", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente uma virgula", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            alterar_valor = true;
        }

        private void dtp_Data_Enter(object sender, EventArgs e)
        {
            alterar_data = true;
        }

        private void Log_Delete(string detalhes)
        {
            string acao = "DELETE";
            string tabela_afetada = "tb_caixa";
            int id_registro = Convert.ToInt32(idSelecionado);
            string data_hora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            Banco.log(acao, tabela_afetada, id_registro, detalhes, data_hora); // Inserindo dados na Log

        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmar exclusão?", "Mensagem do sistema",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                // 1. BUSCAR DADOS ANTES DE QUALQUER EXCLUSÃO
                string queryDados = $"SELECT descricao, idaluno, mensalidades_paga, idmensalidade, tipo_movimentacao, codigovenda, idforma2, curso FROM tb_caixa WHERE ID_caixa = {idSelecionado}";
                DataTable dadosCaixa = Banco.dql(queryDados);

                if (dadosCaixa.Rows.Count == 0)
                {
                    MessageBox.Show("Registro não encontrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string descricao = dadosCaixa.Rows[0]["descricao"]?.ToString();

                // 2. PROCESSAR MENSALIDADE (se for o caso)
                if (descricao == "Mensalidade")
                {
                    ProcessarExclusaoMensalidade(dadosCaixa);
                }
                else if (descricao == "Mensalidade Curso")
                {
                    ProcessarExclusaoMensalidadeCurso(dadosCaixa);
                }

                // 3. PROCESSAR VENDA (se for o caso)
                ProcessarExclusaoVenda(dadosCaixa);

                // 4. EXCLUIR SOMENTE O REGISTRO PRINCIPAL
                string excluirRegistro = $"DELETE FROM tb_caixa WHERE ID_caixa = {idSelecionado}";
                Banco.dml(excluirRegistro);

                if (dgv_GestaoRegistros.CurrentRow != null)
                {
                    dgv_GestaoRegistros.Rows.RemoveAt(dgv_GestaoRegistros.CurrentRow.Index);
                }

                MessageBox.Show("Exclusão feita com sucesso!", "Mensagem do sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                Log_Delete($"ERRO na exclusão ID {idSelecionado}: {ex.Message}");
                MessageBox.Show($"Erro ao excluir: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcessarExclusaoMensalidade(DataTable dadosCaixa)
        {
            try
            {
                int idMensalidade = Convert.ToInt32(dadosCaixa.Rows[0]["idmensalidade"]);
                int idAluno = Convert.ToInt32(dadosCaixa.Rows[0]["idaluno"]);
                int mensPaga = Convert.ToInt32(dadosCaixa.Rows[0]["mensalidades_paga"]);

                Log_Delete($"Deletou pagamento da mensalidade {mensPaga} ID: {idMensalidade}");

                // Descontar mensalidade
                string descontarMensalidade = $@"UPDATE tb_mensalidades 
            SET saldo_devedor = saldo_devedor + valor_parcela,
                parcelas_pagas = parcelas_pagas - 1
            WHERE ID_mensalidade = {idMensalidade}";
                Banco.dml(descontarMensalidade);

                // VERIFICAR SE EXISTE PAGAMENTO DIVIDIDO (idforma2)
                int idForma2 = 0;
                if (dadosCaixa.Rows[0]["idforma2"] != DBNull.Value)
                {
                    idForma2 = Convert.ToInt32(dadosCaixa.Rows[0]["idforma2"]);

                    if (idForma2 > 0 && idForma2 != Convert.ToInt32(idSelecionado))
                    {
                        Log_Delete($"Excluindo pagamento da segunda forma (idforma2): {idForma2}");
                        string excluirForma2 = $"DELETE FROM tb_caixa WHERE ID_caixa = {idForma2}";
                        Banco.dml(excluirForma2);
                    }
                }

                MessageBox.Show("Pagamento de mensalidade Cancelado!", "Mensagem do sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao processar mensalidade: {ex.Message}", ex);
            }
        }

        private void ProcessarExclusaoMensalidadeCurso(DataTable dadosCaixa)
        {
            try
            {
                string curso = dadosCaixa.Rows[0]["curso"]?.ToString()?.ToUpper() ?? "";
                int idMensalidade = Convert.ToInt32(dadosCaixa.Rows[0]["idmensalidade"]);
                int idAluno = Convert.ToInt32(dadosCaixa.Rows[0]["idaluno"]);
                int mensPaga = Convert.ToInt32(dadosCaixa.Rows[0]["mensalidades_paga"]);

                // Buscar ID do curso
                string queryIdCurso = $"SELECT ID_curso FROM tb_cursos WHERE nome_curso = '{curso.Replace("'", "''")}'";
                DataTable idCursoDT = Banco.dql(queryIdCurso);

                if (idCursoDT.Rows.Count == 0)
                {
                    throw new Exception($"Curso '{curso}' não encontrado!");
                }

                int idCurso = Convert.ToInt32(idCursoDT.Rows[0]["ID_curso"]);

                Log_Delete($"Deletou pagamento da mensalidade DO CURSO {curso} ID: {idMensalidade}");

                // Descontar mensalidade do curso
                string descontarMensalidade = $@"UPDATE tb_mensalidades_cursos 
            SET saldo_devedor = saldo_devedor + valor_parcela,
                parcelas_pagas = parcelas_pagas - 1
            WHERE idaluno = {idAluno} AND curso = {idCurso}";
                Banco.dml(descontarMensalidade);

                // VERIFICAR SE EXISTE PAGAMENTO DIVIDIDO (idforma2)
                int idForma2 = 0;
                if (dadosCaixa.Rows[0]["idforma2"] != DBNull.Value)
                {
                    idForma2 = Convert.ToInt32(dadosCaixa.Rows[0]["idforma2"]);

                    if (idForma2 > 0 && idForma2 != Convert.ToInt32(idSelecionado))
                    {
                        Log_Delete($"Excluindo pagamento da segunda forma (idforma2): {idForma2}");
                        string excluirForma2 = $"DELETE FROM tb_caixa WHERE ID_caixa = {idForma2}";
                        Banco.dml(excluirForma2);
                    }
                }

                MessageBox.Show("Pagamento de mensalidade Cancelado!", "Mensagem do sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao processar mensalidade do curso: {ex.Message}", ex);
            }
        }

        private void ProcessarExclusaoVenda(DataTable dadosCaixa)
        {
            try
            {
                string tipo = dadosCaixa.Rows[0]["tipo_movimentacao"]?.ToString() ?? "";

                if (tipo == "VENDA")
                {
                    int codigoVenda = Convert.ToInt32(dadosCaixa.Rows[0]["codigovenda"]);
                    Log_Delete($"Deletou o pagamento da venda {codigoVenda}");

                    // Buscar produtos da venda
                    string queryProdutos = $"SELECT idproduto, quantidade FROM tb_vendas WHERE codigovenda = {codigoVenda}";
                    DataTable produtos = Banco.dql(queryProdutos);

                    // Restaurar estoque para cada produto
                    for (int i = 0; i < produtos.Rows.Count; i++)
                    {
                        int idProduto = Convert.ToInt32(produtos.Rows[i]["idproduto"]);
                        int quantidade = Convert.ToInt32(produtos.Rows[i]["quantidade"]);

                        string baixaEstoque = $"UPDATE tb_produtos SET estoque = estoque + {quantidade} WHERE ID_produto = {idProduto}";
                        Banco.dml(baixaEstoque);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao processar venda: {ex.Message}", ex);
            }
        }
    }
}
