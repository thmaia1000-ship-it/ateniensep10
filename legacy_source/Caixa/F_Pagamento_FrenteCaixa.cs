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
    public partial class F_Pagamento_FrenteCaixa : Form
    {
        F_Vendas f_Vendas;

        decimal Valor1, Valor2, Valor_Soma;
        string modo = "";
        string idSelecionado = "";
        string quantidade = "";
        string Produto = "";
        string Valor_Produto = "";

        public F_Pagamento_FrenteCaixa(F_Vendas f)
        {
            InitializeComponent();
            f_Vendas = f;
        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            decimal Valor = decimal.Parse(f_Vendas.lb_ValorTotal.Text);
            string Data = DateTime.Now.ToString("yyyy-MM-dd");
            string Horario = DateTime.Now.ToString("HH:mm");
            string Entrada = "VENDA";
            int Linha = -1;

            string CodigoVenda = String.Format(@"SELECT IFNULL (MAX(codigovenda),0)+1 as codigo FROM tb_vendas");

            DataTable Codigovenda = Banco.dql(CodigoVenda);

            string Codigo = Codigovenda.Rows[0].Field<Int64>("codigo").ToString();

            if (tb_Valor1.Text != "" && tb_Valor2.Text != "")
            {

                string ID_aluno = String.Format(@"SELECT idcurso FROM tb_alunos WHERE ID_aluno =" + f_Vendas.tb_nome.Tag);

                DataTable dt = Banco.dql(ID_aluno);

                string idcurso = dt.Rows[0].Field<Int32>("idcurso").ToString();

                string Curso = String.Format(@"SELECT nome_curso FROM tb_cursos WHERE ID_curso =" + idcurso);

                DataTable Cursando = Banco.dql(Curso);

                Globais.Main.PassarCurso = Cursando.Rows[0].Field<string>("nome_curso");


                Valor1 = decimal.Parse(tb_Valor1.Text);
                Valor2 = decimal.Parse(tb_Valor2.Text);

                Valor_Soma = Valor1 + Valor2;
                lb_Total.Text = Valor_Soma.ToString("C");


                if (Globais.Main.Modo == "CARTEIRA" || Globais.Main.Modo == "CARTEIRA NEGATIVA")
                {
                   
                }
                else
                {
                    if (Valor_Soma < Valor || Valor_Soma > Valor)
                    {
                        MessageBox.Show("O Valor Precisa ser Igual a " + Convert.ToDecimal(f_Vendas.lb_ValorTotal.Text).ToString("C"), "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                
              
                if (modo == "0")
                {
                    Globais.Main.PassarForma = cb_forma1.Text;
                    Globais.Main.PassarForma1 = "";
                    Globais.Main.PassarForma2 = "";
                    Globais.Main.PassarCaixa = Valor_Soma.ToString();
                    Globais.Main.PassarAluno = f_Vendas.tb_nome.Text;
                    Globais.Main.PassarDesc = tb_observacao.Text;

                    string NomeProduto = "";
                    string DescricaoProdutos = "";

                    for (int i = 1; i <= f_Vendas.dgv_Produto.Rows.Count; i++)
                    {
                        Linha = Linha + 1;

                        idSelecionado = f_Vendas.dgv_Produto.Rows[f_Vendas.dgv_Produto.Rows[Linha].Index].Cells[3].Value.ToString();
                        quantidade = f_Vendas.dgv_Produto.Rows[f_Vendas.dgv_Produto.Rows[Linha].Index].Cells[1].Value.ToString();
                        Produto = f_Vendas.dgv_Produto.Rows[f_Vendas.dgv_Produto.Rows[Linha].Index].Cells[0].Value.ToString();
                        Valor_Produto = f_Vendas.dgv_Produto.Rows[f_Vendas.dgv_Produto.Rows[Linha].Index].Cells[2].Value.ToString();

                        DescricaoProdutos = NomeProduto;
                        NomeProduto = DescricaoProdutos + "/" + Produto + " UN " + quantidade;

                        var vconn = Banco.ConexaoBanco();
                        string CaixaPagamento = String.Format(@"INSERT INTO
                        tb_vendas (produto,valor_total,observacao,quantidade,usuario,nome,data_gerada,idcliente,codigovenda,idproduto)
                        VALUES('{0}', '{1}','{2}',{3},'{4}','{5}','{6}',{7},{8},{9})", Produto, Valor_Produto.Replace(".", "").Replace(",", "."), tb_observacao.Text, quantidade, Globais.Main.PassarUsuario, Globais.Main.PassarPagante.ToUpper(), Data, f_Vendas.lb_IDRespFinan.Text, Codigo, idSelecionado);
                        Banco.dml(CaixaPagamento);
                        vconn.Close();

                        string BaixaEstoque = String.Format(@"UPDATE tb_produtos SET estoque= estoque -'" + quantidade + "' WHERE ID_produto ={0}", idSelecionado);
                        Banco.dml(BaixaEstoque);

                    }
                    var vcon = Banco.ConexaoBanco();
                    string CaixaPagamento1 = String.Format(@"INSERT INTO
                    tb_caixa (valor_total,forma,tipo_movimentacao,descricao,usuario,data,horario,nome,curso,idaluno,codigovenda,observacao)
                    VALUES('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10},'{11}')", tb_Valor1.Text.Replace(",", "."), cb_forma1.SelectedValue, Entrada, NomeProduto, Globais.Main.PassarUsuario, Data, Horario, f_Vendas.tb_nome.Text.ToUpper(), Globais.Main.PassarCurso, f_Vendas.tb_nome.Tag.ToString(), Codigo, tb_observacao.Text);
                    Banco.dml(CaixaPagamento1);
                    vcon.Close();

                    MessageBox.Show("VENDA REGISTRADA!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string codigovenda = String.Format(@"SELECT IFNULL (MAX(codigovenda),0) as codigo FROM tb_vendas");

                    DataTable CodVenda = Banco.dql(codigovenda);

                    Globais.Main.PassarCodigoVenda = CodVenda.Rows[0].Field<Int64>("codigo").ToString();


                    if (Globais.Main.Modo == "CARTEIRA" || Globais.Main.Modo == "CARTEIRA NEGATIVA")
                    {
                        string SaldoCarteira = String.Format(@"
                        SELECT saldo_carteira
                        FROM tb_carteira_aluno
                        WHERE idaluno={0}", f_Vendas.tb_nome.Tag);
                        DataTable saldocarteira = Banco.dql(SaldoCarteira);

                        decimal Saldo_Carteira = saldocarteira.Rows[0].Field<decimal>("saldo_carteira");


                        string QueryAtualizarSaldo = String.Format(@"UPDATE tb_carteira_aluno SET saldo_carteira= saldo_carteira -'" + Saldo_Carteira.ToString() + "' WHERE idaluno ={0}", f_Vendas.tb_nome.Tag);
                        Banco.dml(QueryAtualizarSaldo);

                        if (Globais.Main.Modo == "CARTEIRA")
                        {
                            string queryInsertCarteira = String.Format(@"
                            INSERT INTO 
                            tb_carteira (nome_aluno,valor_total,tipo,descricao,idaluno,data_gerada,usuario)  
                            VALUES ('{0}','{1}','{2}','{3}',{4},'{5}','{6}')", f_Vendas.tb_nome.Text, Saldo_Carteira.ToString().Replace("-", ""), "SAIDA", "VENDA", f_Vendas.tb_nome.Tag, Data, Globais.Main.PassarUsuario);

                            Banco.dml(queryInsertCarteira);
                        }
                        else if (Globais.Main.Modo == "CARTEIRA NEGATIVA")
                        {
                            string queryInsertCarteira = String.Format(@"
                            INSERT INTO 
                            tb_carteira (nome_aluno,valor_total,tipo,descricao,idaluno,data_gerada,usuario)  
                            VALUES ('{0}','{1}','{2}','{3}',{4},'{5}','{6}')", f_Vendas.tb_nome.Text, Saldo_Carteira.ToString().Replace("-", ""), "ENTRADA", "VENDA", f_Vendas.tb_nome.Tag, Data, Globais.Main.PassarUsuario);

                            Banco.dml(queryInsertCarteira);

                        }

                        Globais.Main.Modo = "";
                    }



                    if (MessageBox.Show("IMPRIMIR CUPOM?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Mensalidades.qtdVias vias = new Mensalidades.qtdVias();
                        vias.ShowDialog();
                    }
                    Close();

                }
                else if (modo == "1")
                {
                    Globais.Main.PassarForma = "";
                    Globais.Main.PassarForma1 = cb_forma1.Text;
                    Globais.Main.PassarForma2 = cb_forma2.Text;
                    Globais.Main.PassarCaixa = Valor_Soma.ToString();
                    Globais.Main.PassarAluno = f_Vendas.tb_nome.Text;
                    Globais.Main.PassarDesc = tb_observacao.Text;


                    string NomeProduto = "";
                    string DescricaoProdutos = "";

                    for (int i = 1; i <= f_Vendas.dgv_Produto.Rows.Count; i++)
                    {

                        Linha = Linha + 1;

                        idSelecionado = f_Vendas.dgv_Produto.Rows[f_Vendas.dgv_Produto.Rows[Linha].Index].Cells[3].Value.ToString();
                        quantidade = f_Vendas.dgv_Produto.Rows[f_Vendas.dgv_Produto.Rows[Linha].Index].Cells[1].Value.ToString();
                        Produto = f_Vendas.dgv_Produto.Rows[f_Vendas.dgv_Produto.Rows[Linha].Index].Cells[0].Value.ToString();
                        Valor_Produto = f_Vendas.dgv_Produto.Rows[f_Vendas.dgv_Produto.Rows[Linha].Index].Cells[2].Value.ToString();

                        DescricaoProdutos = NomeProduto;
                        NomeProduto = DescricaoProdutos + "/" + Produto + " UN " + quantidade;

                        var vconn = Banco.ConexaoBanco();
                        string CaixaPagamento = String.Format(@"INSERT INTO
                        tb_vendas (produto,valor_total,observacao,quantidade,usuario,nome,data_gerada,idcliente,codigovenda,idproduto)
                        VALUES('{0}', '{1}','{2}',{3},'{4}','{5}','{6}',{7},{8},{9})", Produto, Valor_Produto.Replace(".", "").Replace(",", "."), tb_observacao.Text, quantidade, Globais.Main.PassarUsuario, Globais.Main.PassarPagante.ToUpper(), Data, f_Vendas.lb_IDRespFinan.Text, Codigo, idSelecionado);
                        Banco.dml(CaixaPagamento);
                        vconn.Close();

                        string BaixaEstoque = String.Format(@"UPDATE tb_produtos SET estoque= estoque -'" + quantidade + "' WHERE ID_produto ={0}", idSelecionado);
                        Banco.dml(BaixaEstoque);
                    }

                    var vcon = Banco.ConexaoBanco();
                    string CaixaPagamento1 = String.Format(@"INSERT INTO
                    tb_caixa (valor_total,forma,tipo_movimentacao,descricao,usuario,data,horario,nome,curso,idaluno,codigovenda,observacao)
                    VALUES('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10},'{11}')", tb_Valor1.Text.Replace(",", "."), cb_forma1.SelectedValue, Entrada, NomeProduto, Globais.Main.PassarUsuario, Data, Horario, f_Vendas.tb_nome.Text.ToUpper(), Globais.Main.PassarCurso, f_Vendas.tb_nome.Tag.ToString(), Codigo, tb_observacao.Text);
                    Banco.dml(CaixaPagamento1);
                    vcon.Close();

                    vcon = Banco.ConexaoBanco();
                    string CaixaPagamento2 = String.Format(@"INSERT INTO
                    tb_caixa (valor_total,forma,tipo_movimentacao,descricao,usuario,data,horario,nome,curso,idaluno,codigovenda,observacao)
                    VALUES('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10},'{11}')", tb_Valor2.Text.Replace(",", "."), cb_forma2.SelectedValue, Entrada, NomeProduto, Globais.Main.PassarUsuario, Data, Horario, f_Vendas.tb_nome.Text.ToUpper(), Globais.Main.PassarCurso, f_Vendas.tb_nome.Tag.ToString(), Codigo, tb_observacao.Text);
                    Banco.dml(CaixaPagamento2);
                    vcon.Close();

                    MessageBox.Show("VENDA REGISTRADA!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string codigovenda = String.Format(@"SELECT IFNULL (MAX(codigovenda),0) as codigo FROM tb_vendas");

                    DataTable CodVenda = Banco.dql(codigovenda);

                    Globais.Main.PassarCodigoVenda = CodVenda.Rows[0].Field<Int64>("codigo").ToString();
                    if (MessageBox.Show("IMPRIMIR CUPOM?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Mensalidades.qtdVias vias = new Mensalidades.qtdVias();
                        vias.ShowDialog();
                    }

                    if (Globais.Main.Modo == "CARTEIRA" || Globais.Main.Modo == "CARTEIRA NEGATIVA")
                    {
                        string SaldoCarteira = String.Format(@"
                        SELECT saldo_carteira
                        FROM tb_carteira_aluno
                        WHERE idaluno={0}", f_Vendas.tb_nome.Tag);
                        DataTable saldocarteira = Banco.dql(SaldoCarteira);

                        decimal Saldo_Carteira = saldocarteira.Rows[0].Field<decimal>("saldo_carteira");


                        string QueryAtualizarSaldo = String.Format(@"UPDATE tb_carteira_aluno SET saldo_carteira= saldo_carteira -'" + Saldo_Carteira.ToString() + "' WHERE idaluno ={0}", f_Vendas.tb_nome.Tag);
                        Banco.dml(QueryAtualizarSaldo);

                        if (Globais.Main.Modo == "CARTEIRA")
                        {
                            string queryInsertCarteira = String.Format(@"
                            INSERT INTO 
                            tb_carteira (nome_aluno,valor_total,tipo,descricao,idaluno,data_gerada,usuario)  
                            VALUES ('{0}','{1}','{2}','{3}',{4},'{5}','{6}')", f_Vendas.tb_nome.Text, Saldo_Carteira.ToString().Replace("-", ""), "SAIDA", "VENDA", f_Vendas.tb_nome.Tag, Data, Globais.Main.PassarUsuario);

                            Banco.dml(queryInsertCarteira);
                        }
                        else if (Globais.Main.Modo == "CARTEIRA NEGATIVA")
                        {
                            string queryInsertCarteira = String.Format(@"
                            INSERT INTO 
                            tb_carteira (nome_aluno,valor_total,tipo,descricao,idaluno,data_gerada,usuario)  
                            VALUES ('{0}','{1}','{2}','{3}',{4},'{5}','{6}')", f_Vendas.tb_nome.Text, Saldo_Carteira.ToString().Replace("-", ""), "ENTRADA", "VENDA", f_Vendas.tb_nome.Tag, Data, Globais.Main.PassarUsuario);

                            Banco.dml(queryInsertCarteira);

                        }

                        Globais.Main.Modo = "";
                    }


                    f_Vendas.lb_estoque.Text = "";
                    f_Vendas.lb_nome_produto.Text = "";
                    f_Vendas.lb_ValorVenda.Text = "";
                    f_Vendas.tb_desconto.Text = "0";
                    f_Vendas.lb_ValorDesconto.Text = "";
                    f_Vendas.lb_ValorTotal.Text = "";
                    f_Vendas.lb_IDProduto.Text = "";
                    f_Vendas.lb_IDRespFinan.Text = "";
                    f_Vendas.lb_cpf.Text = "";
                    f_Vendas.lb_NomeResp.Text = "";
                    f_Vendas.tb_nome.Text = "";
                    f_Vendas.tb_nome.Tag = "";
                    f_Vendas.tb_pagador.Text = "";
                    f_Vendas.tb_Produto.SelectedValue = -1;
                    Close();

                }
            }
            else
            {
                MessageBox.Show("Todos os Campos são obrigatórios!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chk_outros_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_outros.Checked == true)
            {
                modo = "1";
                tb_Valor2.Visible = true;
                cb_forma2.Visible = true;
                lb_Cifrao2.Visible = true;
                lb_Forma2.Visible = true;
                lb_Valor2.Visible = true;
                tb_Valor2.Text = "";
                tb_Valor1.Text = "";

            }
            else
            {
                modo = "0";
                tb_Valor2.Visible = false;
                cb_forma2.Visible = false;
                lb_Cifrao2.Visible = false;
                lb_Forma2.Visible = false;
                lb_Valor2.Visible = false;
                tb_Valor2.Text = "0";
                tb_Valor1.Text = f_Vendas.lb_ValorTotal.Text;
            }
        }

        private void F_Pagamento_FrenteCaixa_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> forma = new Dictionary<string, string>();

            forma.Add("PIX", "PIX");
            forma.Add("DINHEIRO", "DINHEIRO");
            forma.Add("DÉBITO", "DÉBITO");
            forma.Add("CRÉDITO", "CRÉDITO");

            cb_forma1.DataSource = new BindingSource(forma, null);
            cb_forma1.DisplayMember = "Value";
            cb_forma1.ValueMember = "Key";
            cb_forma2.DataSource = new BindingSource(forma, null);
            cb_forma2.DisplayMember = "Value";
            cb_forma2.ValueMember = "Key";


            cb_forma2.SelectedValue = -1;

            cb_forma2.Visible = false;
            tb_Valor2.Text = "0";
            tb_Valor2.Visible = false;
            lb_Cifrao2.Visible = false;
            lb_Forma2.Visible = false;
            lb_Valor2.Visible = false;
            modo = "0";
            tb_Valor1.Text = f_Vendas.lb_ValorTotal.Text;
            lb_Total.Text = f_Vendas.lb_ValorTotal.Text;


            string SaldoCarteira = String.Format(@"
                    SELECT saldo_carteira
                    FROM tb_carteira_aluno
                    WHERE idaluno={0}", f_Vendas.tb_nome.Tag);
            DataTable saldocarteira = Banco.dql(SaldoCarteira);

            decimal Saldo_Carteira = saldocarteira.Rows[0].Field<decimal>("saldo_carteira");

            if (Saldo_Carteira > 0)
            {
                if (MessageBox.Show("O Aluno(a) possui " + Saldo_Carteira.ToString("C") + " de saldo. Deseja Usar?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    decimal ValorTotal = Convert.ToDecimal(f_Vendas.lb_ValorTotal.Text.Replace(".", ","));
                    Globais.Main.Modo = "CARTEIRA";
                    if (ValorTotal > Saldo_Carteira)
                    {
                        decimal Valor = ValorTotal - Saldo_Carteira;
                        lb_Total.Text = Valor.ToString();
                        tb_Valor1.Text = Valor.ToString().Replace(".", ",");
                    }

                    else
                    {
                        lb_Total.Text = "0,00";
                        tb_Valor1.Text = "0,00";
                    }
                }
                else
                {
                    Globais.Main.Modo = "";
                }
            }
            else if (Saldo_Carteira < 0)
            {
                decimal ValorTotal = Convert.ToDecimal(f_Vendas.lb_ValorTotal.Text.Replace(".", ","));
                decimal Valor = ValorTotal - Saldo_Carteira;
                lb_Total.Text = Valor.ToString();
                tb_Valor1.Text = Valor.ToString().Replace(".", ",");
                Globais.Main.Modo = "CARTEIRA NEGATIVA";
            }
           
        }

        private void tb_Valor1_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void tb_Valor2_KeyPress(object sender, KeyPressEventArgs e)
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
        }
    }
}
