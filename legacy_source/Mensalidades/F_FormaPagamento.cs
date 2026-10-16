using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar
{
    public partial class F_FormaPagamento : Form
    {
        F_PagarMensalidade f_FormaDePagamento;

        decimal Recebido, Total, Troco, Desconto,Acrescimo;
        int modo;

        public F_FormaPagamento(F_PagarMensalidade f)
        {
            InitializeComponent();
            f_FormaDePagamento = f;

        }

        private void calcular()
        {
            tb_Desconto.Text = string.IsNullOrEmpty(tb_Desconto.Text) ? "0" : tb_Desconto.Text;

            decimal saldoCarteira = ObterSaldoCarteira();
            decimal valorTotal = ObterValorTotal();

            switch (Globais.Main.Modo)
            {
                case "CARTEIRA":
                    AtualizarValoresParaModoCarteira(valorTotal, saldoCarteira);
                    break;
                default:
                    AtualizarValoresGenerico(valorTotal, saldoCarteira);
                    break;
            }

            CalcularTotaisComDesconto();

            // Se a forma de pagamento for "DINHEIRO", calcular o troco
            if (lb_FormaPagamento.Text == "DINHEIRO")
            {
                CalcularTroco();
            }
            else
            {
                // Caso contrário, garantir que o troco seja 0
                tb_Troco.Text = "0,00";
            }
        }

        private void CalcularTroco()
        {
            // Troco é calculado apenas no pagamento via dinheiro
            decimal trocoCalculado = Recebido - decimal.Parse(lb_Total.Text.Replace(".", ""));
            if (trocoCalculado < 0)
            {
                trocoCalculado = 0; // Caso o valor recebido seja menor que o valor total, o troco deve ser zero
            }

            tb_Troco.Text = trocoCalculado.ToString("F2");
        }

        private void CalcularTotaisComDesconto()
        {
            Total = decimal.Parse(lb_Total.Text.Replace(".", ""));
            Recebido = decimal.Parse(tb_Valor.Text.Replace(".", ""));
            Desconto = decimal.Parse(tb_Desconto.Text.Replace(".", ""));
            Acrescimo = int.Parse(tb_acrescimo.Text.Replace(".", ""));

            // Só calcula o desconto se for modo "CRÉDITO"
            if (modo == 2)
            {
                decimal acrescimoCalculado = Recebido * Acrescimo / 100;
                Total = (Total - (Desconto * f_FormaDePagamento.cb_NParcelas.Value)) + acrescimoCalculado;
            }
            else
            {
                Total = Total - (Desconto * f_FormaDePagamento.cb_NParcelas.Value);
            }

            lb_Total.Text = Total.ToString("F2");
            tb_Valor.Text = Recebido.ToString("F2");
        }


        private decimal ObterSaldoCarteira()
        {
            string saldoQuery = $"SELECT saldo_carteira FROM tb_carteira_aluno WHERE idaluno={Globais.Main.PassarIdAluno}";
            DataTable saldocarteira = Banco.dql(saldoQuery);
            return saldocarteira.Rows[0].Field<decimal>("saldo_carteira");
        }

        private decimal ObterValorTotal()
        {
            return Convert.ToDecimal(f_FormaDePagamento.lb_SubTotal.Text.Replace(".", ","));
        }

        private void AtualizarValoresParaModoCarteira(decimal valorTotal, decimal saldoCarteira)
        {
            decimal valor = Math.Max(0, valorTotal - saldoCarteira);
            AtualizarCampos(valor);
        }

        private void AtualizarValoresGenerico(decimal valorTotal, decimal saldoCarteira)
        {
            decimal valor = saldoCarteira < 0 ? valorTotal - saldoCarteira : valorTotal;
            AtualizarCampos(valor);
        }

        private void AtualizarCampos(decimal valor)
        {
            lb_Total.Text = valor.ToString("F2").Replace(".", "");
            //tb_Valor.Text = valor.ToString("N2").Replace(".", ",");
            tb_Troco.Text = "0";
        }

        private void ConfigurarFormaPagamento(string formaPagamento, bool permitirEdicao, Color cor)
        {
            modo = 0;
            lb_desconto.Text = "Desconto";
            lb_RSdesc.Text = formaPagamento == "CRÉDITO" ? "%" : "R$";
            btn_Salvar.Enabled = true;
            gpb_FormaPag.Enabled = true;
            lb_FormaPagamento.Text = formaPagamento;
            lb_FormaPagamento.ForeColor = cor;
            tb_Valor.Enabled = permitirEdicao;
            tb_Valor.Cursor = permitirEdicao ? Cursors.IBeam : Cursors.No;
            tb_Troco.Text = "0,00";
            tb_Desconto.Text = "0";
            tb_Valor.Text = f_FormaDePagamento.lb_SubTotal.Text;
            lb_Total.Text = f_FormaDePagamento.lb_SubTotal.Text;

            if (Globais.nivel >= 4)
            {
                //tb_Desconto.Enabled = true;
            }
            else
            {
                //tb_Desconto.Enabled = false;
            }
        }

        private void DescontoAutomatico()
        {
            DateTime dataAtual = DateTime.Today;
            int parcelasSelecionadas = (int)f_FormaDePagamento.cb_NParcelas.Value;

            string TipoContrato = String.Format(@"
            SELECT parcelas_pagas, turno, data_gerada, data_inicio, ano_letivo, n_parcelas 
            FROM tb_mensalidades 
            WHERE ID_Mensalidade={0}", Globais.Main.PassarID_Mensalidade);
            DataTable contratos = Banco.dql(TipoContrato);

            string contrato = contratos.Rows[0].Field<string>("turno");
            string parcelasPagas = contratos.Rows[0].Field<Int32>("parcelas_pagas").ToString();
            string totalParcelas = contratos.Rows[0].Field<Int32>("n_parcelas").ToString();
            int anoLetivo = contratos.Rows[0].Field<int>("ano_letivo");
            DateTime dataGerada = contratos.Rows[0].Field<DateTime>("data_gerada");
            DateTime data_inicio = contratos.Rows[0].Field<DateTime>("data_inicio");

            DateTime limiteContrato;
            DateTime limiteContrato2;

            if (anoLetivo == 2026)
            {
                // Datas de referência para 2026
                limiteContrato = DateTime.Parse("2025-12-30");
                limiteContrato2 = DateTime.Parse("2026-01-30");
            }
            else
            {
                // Datas de referência para 2027
                limiteContrato = DateTime.Parse("2026-10-02");
                limiteContrato2 = DateTime.Parse("2026-10-02");
            }

            bool dentroPrimeiroLimite = dataGerada <= limiteContrato;
            bool dentroSegundoLimite = dataGerada > limiteContrato && dataGerada <= limiteContrato2;

            // Identifica parcelas já pagas
            var parcelasPagasArray = parcelasPagas.Split(',').Where(x => !string.IsNullOrEmpty(x)).Select(int.Parse).ToHashSet();

            decimal totalDesconto = 0.00m;

            for (int i = 1; i <= parcelasSelecionadas; i++)
            {
                int parcelaAtual = parcelasPagasArray.Any() ? parcelasPagasArray.Max() + i : i;

                if (parcelaAtual > Int32.Parse(totalParcelas))
                    break;

                int mesParcela = (data_inicio.Month + parcelaAtual - 1) % 12;
                int anoParcela = data_inicio.Year + (data_inicio.Month + parcelaAtual - 1) / 12;
                if (mesParcela == 0)
                {
                    mesParcela = 12;
                    anoParcela--;
                }

                DateTime dataLimiteParcela = DateTime.Parse(CalcularQuintoDiaUtil(mesParcela, anoParcela));

                if (dataAtual <= dataLimiteParcela)
                {
                    decimal desconto = CalcularDesconto(parcelasPagas, contrato, dentroPrimeiroLimite, dentroSegundoLimite, anoLetivo);
                    totalDesconto += desconto;
                }
                else
                {
                    if (parcelasPagas == "0")
                    {
                        decimal desconto = CalcularDesconto(parcelasPagas, contrato, dentroPrimeiroLimite, dentroSegundoLimite, anoLetivo);
                        totalDesconto += desconto;
                    }
                }
            }

            tb_Desconto.Text = totalDesconto.ToString("N2");

            // Exceção para Sobrinhos Iury
            int ID_aluno = Int32.Parse(f_FormaDePagamento.tb_Aluno.Tag.ToString());
            if (ID_aluno == 139 || ID_aluno == 157)
            {
                tb_Desconto.Text = (230.00m * f_FormaDePagamento.cb_NParcelas.Value).ToString("N2");
            }
        }

        // Função para calcular o desconto com base no turno, ano letivo e condições
        private decimal CalcularDesconto(string parcelasPagas, string tipoContrato, bool dentroPrimeiroLimite, bool dentroSegundoLimite, int anoLetivo)
        {
            decimal desconto = 0.00m;
            bool primeiraMensalidade = parcelasPagas == "0" || parcelasPagas == "";

            if (anoLetivo == 2026)
            {
                // Valores novos de 2026
                if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                {
                    if (tipoContrato == "MATUTINO" || tipoContrato == "VESPERTINO")
                    {
                        desconto = primeiraMensalidade
                            ? (dentroPrimeiroLimite ? 150.00m : dentroSegundoLimite ? 150.00m : 0.00m)
                            : (dentroPrimeiroLimite ? 150.00m : dentroSegundoLimite ? 100.00m : 50.00m);
                    }
                    else if (tipoContrato == "INTEGRAL")
                    {
                        desconto = primeiraMensalidade
                            ? (dentroPrimeiroLimite ? 1100.00m : dentroSegundoLimite ? 1100.00m : 0.00m)
                            : (dentroPrimeiroLimite ? 250.00m : dentroSegundoLimite ? 200.00m : 100.00m);
                    }
                    else // Meio período
                    {
                        desconto = primeiraMensalidade
                            ? (dentroPrimeiroLimite ? 550.00m : dentroSegundoLimite ? 550.00m : 0.00m)
                            : (dentroPrimeiroLimite ? 200.00m : dentroSegundoLimite ? 150.00m : 100.00m);
                    }
                }
                else // Crédito ou débito
                {
                    if (tipoContrato == "MATUTINO" || tipoContrato == "VESPERTINO")
                    {
                        desconto = primeiraMensalidade
                            ? (dentroPrimeiroLimite ? 50.00m : dentroSegundoLimite ? 50.00m : 0.00m)
                            : 0.00m;
                    }
                    else if (tipoContrato == "INTEGRAL")
                    {
                        desconto = primeiraMensalidade
                            ? (dentroPrimeiroLimite ? 900.00m : dentroSegundoLimite ? 900.00m : 0.00m)
                            : 0.00m;
                    }
                    else // Meio período
                    {
                        desconto = primeiraMensalidade
                            ? (dentroPrimeiroLimite ? 350.00m : dentroSegundoLimite ? 350.00m : 0.00m)
                            : 0.00m;
                    }
                }
            }
            else
            {
                // Valores de 2027
                if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                {
                    if (tipoContrato == "MATUTINO" || tipoContrato == "VESPERTINO")
                    {
                        desconto = primeiraMensalidade
                            ? (dentroPrimeiroLimite ? 300.00m : dentroSegundoLimite ? 300.00m : 30.00m)
                            : (dentroPrimeiroLimite ? 200.00m : dentroSegundoLimite ? 200.00m : 30.00m);
                    }
                    else if (tipoContrato == "INTEGRAL")
                    {
                        desconto = primeiraMensalidade
                            ? (dentroPrimeiroLimite ? 1100.00m : dentroSegundoLimite ? 1100.00m : 100.00m)
                            : (dentroPrimeiroLimite ? 300.00m : dentroSegundoLimite ? 300.00m : 100.00m);
                    }
                    else // Meio período
                    {
                        desconto = primeiraMensalidade
                            ? (dentroPrimeiroLimite ? 700.00m : dentroSegundoLimite ? 700.00m : 50.00m)
                            : (dentroPrimeiroLimite ? 200.00m : dentroSegundoLimite ? 200.00m : 50.00m);
                    }
                }
                else // Crédito ou débito
                {
                    if (tipoContrato == "MATUTINO" || tipoContrato == "VESPERTINO")
                    {
                        desconto = primeiraMensalidade
                            ? (dentroPrimeiroLimite ? 100.00m : dentroSegundoLimite ? 100.00m : 0.00m)
                            : 0.00m;
                    }
                    else if (tipoContrato == "INTEGRAL")
                    {
                        desconto = primeiraMensalidade
                            ? (dentroPrimeiroLimite ? 1000.00m : dentroSegundoLimite ? 1000.00m : 0.00m)
                            : 0.00m;
                    }
                    else // Meio período
                    {
                        desconto = primeiraMensalidade
                            ? (dentroPrimeiroLimite ? 400.00m : dentroSegundoLimite ? 400.00m : 0.00m)
                            : 0.00m;
                    }
                }
            }

            return desconto;
        }



        private void btn_Dinheiro_Click(object sender, EventArgs e)
        {
            ConfigurarFormaPagamento("DINHEIRO", true, Color.Green);
            DescontoAutomatico();
            calcular();
            tb_Valor.Text = Total.ToString("F2");
            calcular();
            tb_acrescimo.Visible = false;
            tb_Desconto.Visible = true;
        }

        private void btn_Pix_Click(object sender, EventArgs e)
        {
            ConfigurarFormaPagamento("PIX", false, Color.Green);
            DescontoAutomatico();
            calcular();
            tb_Valor.Text = Total.ToString("F2");
            calcular();
            tb_acrescimo.Visible = false;
            tb_Desconto.Visible = true;

        }

        private void btn_Debito_Click(object sender, EventArgs e)
        {
            ConfigurarFormaPagamento("DÉBITO", false, Color.Green);
            DescontoAutomatico();
            calcular();
            tb_Valor.Text = Total.ToString("F2");
            calcular();
            tb_acrescimo.Visible = false;
            tb_Desconto.Visible = true;
        }

        private void btn_Credito_Click(object sender, EventArgs e)
        {
            ConfigurarFormaPagamento("CRÉDITO", false, Color.Green);

            if (MessageBox.Show("A VISTA?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                lb_RSdesc.Text = "%";
                lb_desconto.Text = "Acréscimo %";
                tb_Desconto.Visible = false;
                tb_acrescimo.Visible = true;
                modo = 2;
            }
            else
            {
                lb_RSdesc.Text = "R$";
                lb_desconto.Text = "Desconto";
                tb_Desconto.Visible = true;
                tb_acrescimo.Visible = false;
                //tb_Desconto.Enabled = f_FormaDePagamento.dgv_Parcelas.RowCount >= 10;
            }
            DescontoAutomatico();
            calcular();
            tb_Valor.Text = Total.ToString("F2");
            calcular();
        }

        private void tb_Desconto_Leave(object sender, EventArgs e)
        {
            if (tb_Desconto.Text == "")
            {
                tb_Desconto.Text = "0";
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            tb_Desconto.Text = "0";
            tb_Troco.Text = "0,00";
            tb_acrescimo.Text = "0";
            btn_Salvar.Enabled = false;
            gpb_FormaPag.Enabled = false;
            tb_Valor.Text = f_FormaDePagamento.lb_SubTotal.Text;
            lb_Total.Text = f_FormaDePagamento.lb_SubTotal.Text;
        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
            //F_ReciboInterdigitus f_ReciboInterdigitus = new F_ReciboInterdigitus(this);
            //f_ReciboInterdigitus.Show();

        }

        private void tb_Desconto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_outros.Checked == true)
            {
                if(f_FormaDePagamento.cb_NParcelas.Value == 1)
                {
                
                modo = 1;
                //tb_Desconto.Enabled = false;
                //tb_Valor.Enabled = false;

                string Mensalidades = String.Format(@"SELECT IFNULL (MAX(mensalidades_paga),0) as mensalidades_pagas FROM tb_caixa WHERE descricao = 'Mensalidade' AND idaluno ={0} AND idmensalidade ={1}", f_FormaDePagamento.tb_Aluno.Tag, Globais.Main.PassarID_Mensalidade);

                DataTable mensalidades = Banco.dql(Mensalidades);

                string Mensalidades_Pagas = mensalidades.Rows[0].Field<Int64>("mensalidades_pagas").ToString();
                int Mensalidade_Paga = Convert.ToInt32(Mensalidades_Pagas) + Convert.ToInt32(f_FormaDePagamento.cb_NParcelas.Text);
                Globais.Main.PassarMensalidades_paga = Mensalidade_Paga.ToString();
                
                    Caixa.F_DuasFormas f_DuasFormas = new Caixa.F_DuasFormas(this);
                    f_DuasFormas.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Não é possível pagar mais de uma mensalidade com duas formas de pagamento","Mensagem do Sistema", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    chk_outros.Checked = false;
                }

            }
            else
            {
                modo = 0;
                tb_Desconto.Enabled = true;
                tb_Valor.Enabled = true;
                if (Globais.Main.PassarForma1 != "" && Globais.Main.PassarForma2 != "")
                {
                    Globais.Main.PassarForma1 = "";
                    Globais.Main.PassarForma2 = "";
                }
            }
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
        }

        private void btn_Calc_Click(object sender, EventArgs e)
        {
            calcular();
        }

        private void tb_acrescimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente número", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void F_FormaPagamento_Load(object sender, EventArgs e)
        {
            btn_Salvar.Enabled = false;
            gpb_FormaPag.Enabled = false;
            tb_Valor.Text = f_FormaDePagamento.lb_SubTotal.Text.Replace(".", "");
            lb_Total.Text = f_FormaDePagamento.lb_SubTotal.Text;


            tb_Desconto.Text = "0";
            tb_Troco.Text = "0,00";

            lb_nomeUsuario.Text = Globais.Main.PassarUsuario;

            string SaldoCarteira = String.Format(@"
                SELECT saldo_carteira
                FROM tb_carteira_aluno
                WHERE idaluno={0}", Globais.Main.PassarIdAluno);
            DataTable saldocarteira = Banco.dql(SaldoCarteira);

            decimal Saldo_Carteira = saldocarteira.Rows[0].Field<decimal>("saldo_carteira");

            if (Saldo_Carteira > 0)
            {
                if (MessageBox.Show("O Aluno(a) possui " + Saldo_Carteira.ToString("C") + " de saldo. Deseja Usar?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    decimal ValorTotal = Convert.ToDecimal(f_FormaDePagamento.lb_SubTotal.Text.Replace(".",","));
                    Globais.Main.Modo = "CARTEIRA";
                    if (ValorTotal > Saldo_Carteira)
                    {
                        decimal Valor = ValorTotal - Saldo_Carteira;
                        lb_Total.Text = Valor.ToString();
                        tb_Valor.Text = Valor.ToString().Replace(".", "");
                    }

                    else
                    {
                        lb_Total.Text = "0,00";
                        tb_Valor.Text = "0,00";
                    }
                }
                else
                {
                    Globais.Main.Modo = "";
                }
            }
            else if (Saldo_Carteira < 0)
            {
                decimal ValorTotal = Convert.ToDecimal(f_FormaDePagamento.lb_SubTotal.Text.Replace(".", ","));
                decimal Valor = ValorTotal - Saldo_Carteira;
                lb_Total.Text = Valor.ToString();
                tb_Valor.Text = Valor.ToString().Replace(".", "");
                Globais.Main.Modo = "CARTEIRA NEGATIVA";
            }

            //f_FormaDePagamento.dgv_Parcelas.RowCount >= 10 clausula antiga do if vvvv
            if (Globais.nivel >=4)
            {
                //tb_Desconto.Enabled = true;
            }
            else
            {
                //tb_Desconto.Enabled = false;
            }

            String.Format(@"SELECT turno FROM tb_mensalidades WHERE idaluno={0}", Globais.Main.PassarID_Mensalidade);

        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            calcular();
            if (modo == 2)
            {
                modo = 0;
            }
            string Data = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime Horario = DateTime.Now;
            if (MessageBox.Show("CONFIRMAR O RECEBIMENTO DA MENSALIDADE?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Globais.Main.PassarData = "";
                Globais.Main.PassarHorario = "";
                Globais.Main.PassarCaixa = lb_Total.Text;

                int Minuto = 0;

                for (int i = 1; i <= f_FormaDePagamento.cb_NParcelas.Value; i++)
                {
                    var vcon = Banco.ConexaoBanco();
                    string DescontarMensalidade = String.Format(@"UPDATE tb_mensalidades 
                                    SET 
                                    saldo_devedor= saldo_devedor - valor_parcela,
                                    parcelas_pagas = parcelas_pagas + 1
                                    WHERE ID_mensalidade={0}" , Globais.Main.PassarID_Mensalidade);
                    Banco.dml(DescontarMensalidade);
                    vcon.Close();

                    decimal Valor_Total = Convert.ToDecimal(lb_Total.Text) / f_FormaDePagamento.cb_NParcelas.Value;

                    if (modo == 0)
                    {
                        Minuto = Minuto + 1;
                        DateTime MinutoHorario = Horario.AddMinutes(Minuto);

                        string Mensalidades = String.Format(@"SELECT COALESCE((SELECT mensalidades_paga FROM tb_caixa WHERE idaluno = {0}  AND idmensalidade = {1}  ORDER BY mensalidades_paga DESC LIMIT 1), 0) as mensalidades_pagas", Globais.Main.PassarIdAluno, Globais.Main.PassarID_Mensalidade);

                        DataTable mensalidades = Banco.dql(Mensalidades);

                        string Mensalidades_Pagas = "0";
                        if (mensalidades.Rows.Count > 0)
                        {
                            Mensalidades_Pagas = mensalidades.Rows[0].Field<Int64>("mensalidades_pagas").ToString();
                        }

                        if (mensalidades.Rows.Count > 0)
                        {
                            Mensalidades_Pagas = mensalidades.Rows[0].Field<Int64>("mensalidades_pagas").ToString();
                        }

                        int Mensalidade_Paga = Convert.ToInt32(Mensalidades_Pagas) + 1;
                        Globais.Main.PassarMensalidades_paga = Mensalidade_Paga.ToString();

                        Globais.Main.PassarForma = lb_FormaPagamento.Text;
                        Globais.Main.PassarForma1 = "";
                        Globais.Main.PassarForma2 = "";
                        string Entrada = "ENTRADA";
                        string Mensalidade = "Mensalidade";
                        var vconn = Banco.ConexaoBanco();
                        string CaixaPagamento = String.Format(@"INSERT INTO
                        tb_caixa (valor_total,forma,tipo_movimentacao,descricao,usuario,data,horario,nome,curso,idaluno,mensalidades_paga,idmensalidade)
                        VALUES('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10},{11})", Valor_Total.ToString().Replace(",", "."), lb_FormaPagamento.Text, Entrada, Mensalidade, lb_nomeUsuario.Text, Data, MinutoHorario.ToString("HH:mm"), Globais.Main.PassarAluno, f_FormaDePagamento.lb_Cursando.Text, f_FormaDePagamento.tb_Aluno.Tag, Mensalidade_Paga, Globais.Main.PassarID_Mensalidade);
                        Banco.dml(CaixaPagamento);
                        vconn.Close();
                    }
                    if (Globais.Main.Modo == "CARTEIRA" || Globais.Main.Modo == "CARTEIRA NEGATIVA")
                    {
                        string SaldoCarteira = String.Format(@"
                        SELECT saldo_carteira
                        FROM tb_carteira_aluno
                        WHERE idaluno={0}", Globais.Main.PassarIdAluno);
                        DataTable saldocarteira = Banco.dql(SaldoCarteira);

                        decimal Saldo_Carteira = saldocarteira.Rows[0].Field<decimal>("saldo_carteira");


                        string QueryAtualizarSaldo = String.Format(@"UPDATE tb_carteira_aluno SET saldo_carteira= saldo_carteira -'" + Saldo_Carteira.ToString() + "' WHERE idaluno ={0}", Globais.Main.PassarIdAluno);
                        Banco.dml(QueryAtualizarSaldo);

                        if (Globais.Main.Modo == "CARTEIRA")
                        {
                            string queryInsertCarteira = String.Format(@"
                            INSERT INTO 
                            tb_carteira (nome_aluno,valor_total,tipo,descricao,idaluno,data_gerada,usuario)  
                            VALUES ('{0}','{1}','{2}','{3}',{4},'{5}','{6}')", f_FormaDePagamento.tb_Aluno.Text, Saldo_Carteira.ToString().Replace("-", ""), "SAIDA", "Mensalidade", Globais.Main.PassarIdAluno, Data, Globais.Main.PassarUsuario);

                            Banco.dml(queryInsertCarteira);
                        }
                        else if (Globais.Main.Modo == "CARTEIRA NEGATIVA")
                        {
                            string queryInsertCarteira = String.Format(@"
                            INSERT INTO 
                            tb_carteira (nome_aluno,valor_total,tipo,descricao,idaluno,data_gerada,usuario)  
                            VALUES ('{0}','{1}','{2}','{3}',{4},'{5}','{6}')", f_FormaDePagamento.tb_Aluno.Text, Saldo_Carteira.ToString().Replace("-", ""), "ENTRADA", "Mensalidade", Globais.Main.PassarIdAluno, Data, Globais.Main.PassarUsuario);

                            Banco.dml(queryInsertCarteira);

                        }

                        Globais.Main.Modo = "";
                    }
                }

                MessageBox.Show("Pagamento de mensalidade Confirmado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                string CodigoVenda = String.Format(@"SELECT IFNULL (MAX(ID_caixa),0) as codigo, descricao FROM tb_caixa");

                DataTable Codigovenda = Banco.dql(CodigoVenda);

                Globais.Main.PassarIdCaixa = Codigovenda.Rows[0].Field<Int64>("codigo").ToString();
                Globais.Main.PassarDesc = Codigovenda.Rows[0].Field<string>("descricao");

                Mensalidades.SelecionarRecibo selecionar = new Mensalidades.SelecionarRecibo();
                selecionar.ShowDialog();

                Close();
                
            }

        }

        // Lista de feriados fixos (dia e mês) no Brasil
        private static List<DateTime> FeriadosFixos(int ano)
        {
            return new List<DateTime>
        {
            new DateTime(ano, 1, 1),   // Confraternização Universal
            new DateTime(ano, 4, 21),  // Tiradentes
            new DateTime(ano, 5, 1),   // Dia do Trabalho
            new DateTime(ano, 9, 7),   // Independência do Brasil
            new DateTime(ano, 10, 12), // Nossa Senhora Aparecida
            new DateTime(ano, 11, 2),  // Finados
            new DateTime(ano, 11, 15), // Proclamação da República
            new DateTime(ano, 12, 25),  // Natal

            // Feriados regionais de Manaus (Amazonas)
            new DateTime(ano, 9, 5),   // Elevação do Amazonas à categoria de província
            new DateTime(ano, 10, 24),  // Aniversário de Manaus
            // Carnaval
            new DateTime(ano, 3, 3),
            new DateTime(ano, 3, 4),
            new DateTime(ano, 3, 5),
        };
        }

        private string CalcularQuintoDiaUtil(int mes, int ano)
        {
            DateTime data = new DateTime(ano, mes, 1);
            int diaUtilCount = 0;

            List<DateTime> feriados = FeriadosFixos(ano);

            while (diaUtilCount < 5)
            {
                // Verifica se não é final de semana e nem feriado
                if (data.DayOfWeek != DayOfWeek.Saturday && data.DayOfWeek != DayOfWeek.Sunday && !feriados.Contains(data))
                {
                    diaUtilCount++;
                }

                if (diaUtilCount < 5)
                {
                    data = data.AddDays(1);
                }
            }

            return data.ToString("dd/MM/yyyy");
        }

    }
}
