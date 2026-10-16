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
    public partial class F_Vendas : Form
    {
        decimal Valor, Valor_Total, Valor_Desconto, Valor_Acrescimo;
        int Desconto,Quantidade,Acrescimo;
        string idSelecionado = "";
        public F_Vendas()
        {
            InitializeComponent();
        }

        private void Calcular()
        {
            Desconto = Int32.Parse(tb_desconto.Text);
            Acrescimo = Int32.Parse(tb_acrescimo.Text);
            Valor = dgv_Produto.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells[valor_venda.Name].Value ?? 0));

            if (lb_ValorAcrescimo.Visible == true)
            {
                Valor_Acrescimo = Acrescimo * Valor / 100;

                Valor_Total = Valor + Valor_Acrescimo;

                lb_ValorAcrescimo.Text = Valor_Acrescimo.ToString("C");
                lb_ValorTotal.Text = Valor_Total.ToString("N");
                lb_ValorAcrescimo.Location = new Point(882,365);
                lb_acresc.Location = new Point(731,365);
            }
            else
            {
                Valor_Desconto = Desconto * Valor / 100;

                Valor_Total = Valor - Valor_Desconto;

                lb_ValorDesconto.Text = Valor_Desconto.ToString("C");
                lb_ValorTotal.Text = Valor_Total.ToString("N");
            }
        }

        private void Adicionar()
        {
            if (lb_nome_produto.Text != "")
            {
                int VerificarEstoque = Convert.ToInt32(lb_estoque.Text);
                int VerificarQuantidade = Convert.ToInt32(npd_quantidade.Text);
                int Estoque = VerificarEstoque - VerificarQuantidade;
                if (Estoque < 0)
                {
                    MessageBox.Show("Sem estoque!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Valor = decimal.Parse(lb_ValorVenda.Text);
                    Quantidade = Int32.Parse(npd_quantidade.Text);

                    Valor = Valor * Quantidade;

                    dgv_Produto.Rows.Add(lb_nome_produto.Text, npd_quantidade.Text, Valor.ToString("N"), lb_IDProduto.Text);
                    dgv_Produto.Columns[3].Visible = false;

                    lb_ValorTotal.Text = dgv_Produto.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells[valor_venda.Name].Value ?? 0)).ToString("C");

                }
                tb_Produto.SelectedValue = -1;
                lb_nome_produto.Text = "";
                npd_quantidade.Value = 1;
                lb_IDProduto.Text = "";
                lb_estoque.Text = "";
                lb_ValorVenda.Text = "";
            }
            else
            {
                MessageBox.Show("Adicione um produto!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Remover()
        {
            if (dgv_Produto.Rows.Count > 0)
            {
                dgv_Produto.Rows.Remove(dgv_Produto.CurrentRow);

                lb_ValorTotal.Text = dgv_Produto.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells[valor_venda.Name].Value ?? 0)).ToString("C");
                lb_ValorDesconto.Text = "";

                dgv_Produto.ClearSelection();
            }
        }

        private void btn_Produto_Click(object sender, EventArgs e)
        {
            Selecionar.F_SelecionarProduto f_SelecionarProduto = new Selecionar.F_SelecionarProduto(this);
            f_SelecionarProduto.ShowDialog();
        }

        private void F_Vendas_Load(object sender, EventArgs e)
        {
            tb_acrescimo.Text = "0";
            lb_estoque.Text = "";
            lb_nome_produto.Text = "";
            lb_ValorVenda.Text = "";
            tb_desconto.Text = "0";
            lb_ValorDesconto.Text = "";
            lb_ValorTotal.Text = "";
            lb_IDProduto.Text = "";
            lb_IDRespFinan.Text = "";
            lb_cpf.Text = "";
            lb_NomeResp.Text = "";

            string vqueryProdutos = @"
                SELECT 
                ID_produto,
                produto,
                descricao,
                valor_custo,
                valor_venda
                FROM tb_produtos as tba ORDER BY produto";
            tb_Produto.Items.Clear();
            tb_Produto.DataSource = Banco.dql(vqueryProdutos);
            tb_Produto.DisplayMember = "produto";
            tb_Produto.ValueMember = "ID_produto";

            tb_Produto.SelectedValue = -1;
            dgv_Produto.Columns[3].Visible = false;
        }


        private void btn_Receber_Click(object sender, EventArgs e)
        {

            if (tb_nome.Text != "" && tb_pagador.Text != "")
            {
                if (dgv_Produto.Rows.Count > 0)
                {
                    Globais.Main.PassarIdAluno = tb_nome.Tag.ToString();
                    Globais.Main.PassarAluno = tb_nome.Text;
                    Globais.Main.PassarPagante = tb_pagador.Text;

                    if (MessageBox.Show("Fechar Venda?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Calcular();
                        
                        F_Pagamento_FrenteCaixa f_Pagamento_FrenteCaixa = new F_Pagamento_FrenteCaixa(this);
                        f_Pagamento_FrenteCaixa.ShowDialog();

                    }

                }
                else
                {
                    MessageBox.Show("Adicione o produto!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Informe o Aluno(a) e o Pagador!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_Aluno_Click(object sender, EventArgs e)
        {
            Selecionar.F_SelecionarAlunoProduto f_SelecionarAlunoProduto = new Selecionar.F_SelecionarAlunoProduto(this);
            f_SelecionarAlunoProduto.ShowDialog();
        }

        private void dgv_Produto_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.SelectedRows.Count > 0)
            {
                idSelecionado = dgv.Rows[dgv.SelectedRows[0].Index].Cells[3].Value.ToString();

                var vcon = Banco.ConexaoBanco();
                string vquery = String.Format(@"
            SELECT
                ID_produto,
                produto,
                descricao,
                valor_venda,
                estoque
                FROM tb_produtos
                WHERE ID_produto =" + idSelecionado);

                DataTable dt = Banco.dql(vquery);

                vcon.Close();

                string descricao = "  Descrição: ";
                lb_nome_produto.Text = dt.Rows[0].Field<string>("produto");
                //tb_descricao.Text = descricao + dt.Rows[0].Field<string>("descricao");
                lb_ValorVenda.Text = dt.Rows[0].Field<decimal>("valor_venda").ToString();
                lb_estoque.Text = dt.Rows[0].Field<Int32>("estoque").ToString();
                lb_IDProduto.Text = dt.Rows[0].Field<Int32>("ID_produto").ToString();

                npd_quantidade.Value = 1;
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            dgv_Produto.Rows.Clear();

            tb_Produto.Text = "";
            tb_nome.Text = "";
            npd_quantidade.Value = 1;
            lb_IDProduto.Text = "";
            lb_nome_produto.Text = "";
            lb_estoque.Text = "";
            lb_ValorVenda.Text = "";
            //tb_descricao.Text = "  Descrição:";
            lb_IDRespFinan.Text = "";
            lb_NomeResp.Text = "";
            lb_cpf.Text = "";
            //lb_Endereco.Text = "";
            lb_ValorDesconto.Text = "";
            lb_ValorTotal.Text = "";
            tb_desconto.Text = "0";
        }

        private void F_Vendas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Remover();
            }

            if (e.KeyCode == Keys.Enter)
            {
                Adicionar();
            }

            if(e.KeyCode == Keys.F2)
            {
                Selecionar.F_SelecionarAlunoProduto f_SelecionarAlunoProduto = new Selecionar.F_SelecionarAlunoProduto(this);
                f_SelecionarAlunoProduto.ShowDialog();
            }

        }

        private void btn_Adicionar_Click(object sender, EventArgs e)
        {
            Adicionar();
        }

        private void btn_Remover_Click(object sender, EventArgs e)
        {
            Remover();
        }

        private void btn_acrescimo_Click(object sender, EventArgs e)
        {
            tb_desconto.Text = "0";
            lb_desc.Visible = false;
            lb_ValorDesconto.Visible = false;
            lb_acresc.Visible = true;
            lb_ValorAcrescimo.Visible = true;
            Calcular();
        }


        private void btn_Descontar_Click(object sender, EventArgs e)
        {
            tb_acrescimo.Text = "0";
            lb_desc.Visible = true;
            lb_ValorDesconto.Visible = true;
            lb_acresc.Visible = false;
            lb_ValorAcrescimo.Visible = false;
            Calcular();
        }

        private void tb_Produto_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            var vcon = Banco.ConexaoBanco();
            string vquery = String.Format(@"
            SELECT
                ID_produto,
                produto,
                descricao,
                valor_venda,
                estoque
                FROM tb_produtos
                WHERE ID_produto =" + tb_Produto.SelectedValue.ToString());

            DataTable dt = Banco.dql(vquery);

            vcon.Close();

            string descricao = "  Descrição: ";
            lb_nome_produto.Text = dt.Rows[0].Field<string>("produto");
            //tb_descricao.Text = descricao + dt.Rows[0].Field<string>("descricao");
            lb_ValorVenda.Text = dt.Rows[0].Field<decimal>("valor_venda").ToString();
            lb_estoque.Text = dt.Rows[0].Field<Int32>("estoque").ToString();
            lb_IDProduto.Text = dt.Rows[0].Field<Int32>("ID_produto").ToString();
            dgv_Produto.ClearSelection();
        }

  

        private void tb_desconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente número", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_desconto_Leave(object sender, EventArgs e)
        {
            if (tb_desconto.Text == "")
            {
                tb_desconto.Text = "0";
            }
        }
    }
}
