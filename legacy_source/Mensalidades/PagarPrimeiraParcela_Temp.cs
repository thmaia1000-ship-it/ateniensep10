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
    public partial class PagarPrimeiraParcela_Temp : Form
    {
        public PagarPrimeiraParcela_Temp()
        {
            InitializeComponent();
        }

        int modo;



        private void Matriculas2027()
        {
            //tb_Valor.Enabled = false;
            //tb_Desconto.Enabled = false;

            DateTime data_gerada = DateTime.Now;
            DateTime LimiteContrato = DateTime.Parse("2026-10-02");

            if (data_gerada <= LimiteContrato)
            {
                if (Globais.Main.PassarContrato == "NORMAL")
                {
                    if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                    {
                        tb_Valor.Text = "400,00";
                        tb_Desconto.Text = "300,00";
                    }
                    else
                    {
                        tb_Valor.Text = "600,00";
                        tb_Desconto.Text = "200,00";
                    }
                }
                else if (Globais.Main.PassarContrato == "MEIO P.")
                {
                    if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                    {
                        tb_Valor.Text = "500,00";
                        tb_Desconto.Text = "700,00";
                    }
                    else
                    {
                        tb_Valor.Text = "800,00";
                        tb_Desconto.Text = "400,00";
                    }
                }
                else if (Globais.Main.PassarContrato == "INTEGRAL")
                {
                    if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                    {
                        tb_Valor.Text = "700,00";
                        tb_Desconto.Text = "1100,00";
                    }
                    else
                    {
                        tb_Valor.Text = "800,00";
                        tb_Desconto.Text = "1000,00";
                    }
                }
            }

            else
            {
                if (Globais.Main.PassarContrato == "NORMAL")
                {
                    if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                    {
                        tb_Valor.Text = "400,00";
                        tb_Desconto.Text = "300,00";
                    }
                    else
                    {
                        tb_Valor.Text = "600,00";
                        tb_Desconto.Text = "200,00";
                    }
                }
                else if (Globais.Main.PassarContrato == "MEIO P.")
                {
                    if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                    {
                        tb_Valor.Text = "500,00";
                        tb_Desconto.Text = "700,00";
                    }
                    else
                    {
                        tb_Valor.Text = "800,00";
                        tb_Desconto.Text = "400,00";
                    }
                }
                else if (Globais.Main.PassarContrato == "INTEGRAL")
                {
                    if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                    {
                        tb_Valor.Text = "700,00";
                        tb_Desconto.Text = "1100,00";
                    }
                    else
                    {
                        tb_Valor.Text = "800,00";
                        tb_Desconto.Text = "1000,00";
                    }
                }
            }

        }

        private void Matriculas2026()
        {
            //tb_Valor.Enabled = false;
            //tb_Desconto.Enabled = false;

            DateTime data_gerada = DateTime.Now;
            DateTime LimiteContrato = DateTime.Parse("2025-12-30");
            DateTime limiteContrato2 = DateTime.Parse("2026-01-30");

            if (data_gerada <= LimiteContrato && Globais.Main.PassarTipo == "Rematricula")
            {
                
                if (Globais.Main.PassarContrato == "NORMAL")
                {
                    if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                    {
                        tb_Valor.Text = "400,00";
                        tb_Desconto.Text = "250,00";
                    }
                    else
                    {
                        tb_Valor.Text = "600,00";
                        tb_Desconto.Text = "50,00";
                    }
                }
                else if (Globais.Main.PassarContrato == "MEIO P.")
                {
                    if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                    {
                        tb_Valor.Text = "500,00";
                        tb_Desconto.Text = "650,00";
                    }
                    else
                    {
                        tb_Valor.Text = "800,00";
                        tb_Desconto.Text = "350,00";
                    }
                }
                else if (Globais.Main.PassarContrato == "INTEGRAL")
                {
                    if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                    {
                        tb_Valor.Text = "500,00";
                        tb_Desconto.Text = "1200,00";
                    }
                    else
                    {
                        tb_Valor.Text = "800,00";
                        tb_Desconto.Text = "900,00";
                    }
                }
            }
            else if (data_gerada <= LimiteContrato) // Alunos Novos
            {
                if (Globais.Main.PassarContrato == "NORMAL")
                {
                    if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                    {
                        tb_Valor.Text = "500,00";
                        tb_Desconto.Text = "150,00";
                    }
                    else
                    {
                        tb_Valor.Text = "600,00";
                        tb_Desconto.Text = "50,00";
                    }
                }
                else if (Globais.Main.PassarContrato == "MEIO P.")
                {
                    if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                    {
                        tb_Valor.Text = "600,00";
                        tb_Desconto.Text = "550,00";
                    }
                    else
                    {
                        tb_Valor.Text = "800,00";
                        tb_Desconto.Text = "350,00";
                    }
                }
                else if (Globais.Main.PassarContrato == "INTEGRAL")
                {
                    if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                    {
                        tb_Valor.Text = "600,00";
                        tb_Desconto.Text = "1100,00";
                    }
                    else
                    {
                        tb_Valor.Text = "800,00";
                        tb_Desconto.Text = "900,00";
                    }
                }
            }
            else if (data_gerada <= limiteContrato2)
            {
                if (Globais.Main.PassarContrato == "NORMAL")
                {
                    if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                    {
                        tb_Valor.Text = "500,00";
                        tb_Desconto.Text = "150,00";
                    }
                    else
                    {
                        tb_Valor.Text = "600,00";
                        tb_Desconto.Text = "50,00";
                    }
                }
                else if (Globais.Main.PassarContrato == "MEIO P.")
                {
                    if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                    {
                        tb_Valor.Text = "600,00";
                        tb_Desconto.Text = "550,00";
                    }
                    else
                    {
                        tb_Valor.Text = "800,00";
                        tb_Desconto.Text = "350,00";
                    }
                }
                else if (Globais.Main.PassarContrato == "INTEGRAL")
                {
                    if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                    {
                        tb_Valor.Text = "600,00";
                        tb_Desconto.Text = "1100,00";
                    }
                    else
                    {
                        tb_Valor.Text = "800,00";
                        tb_Desconto.Text = "900,00";
                    }
                }
            }
            else //Fevereiro em diante
            {
                if (Globais.Main.PassarContrato == "NORMAL")
                {
                    if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                    {
                        tb_Valor.Text = "600,00";
                        tb_Desconto.Text = "50,00";
                    }
                    else
                    {
                        tb_Valor.Text = "650,00";
                        tb_Desconto.Text = "0,00";
                    }
                }
                else if (Globais.Main.PassarContrato == "MEIO P.")
                {
                    if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                    {
                        tb_Valor.Text = "1050,00";
                        tb_Desconto.Text = "100,00";
                    }
                    else
                    {
                        tb_Valor.Text = "1150,00";
                        tb_Desconto.Text = "0,00";
                    }
                }
                else if (Globais.Main.PassarContrato == "INTEGRAL")
                {
                    if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                    {
                        tb_Valor.Text = "1600,00";
                        tb_Desconto.Text = "100,00";
                    }
                    else
                    {
                        tb_Valor.Text = "1700,00";
                        tb_Desconto.Text = "0,00";
                    }
                }
            }

        }

        private void Matriculas2025()
        {
            //tb_Valor.Enabled = false;
            //tb_Desconto.Enabled = false;

            DateTime data_gerada = DateTime.Now;
            DateTime LimiteContrato = DateTime.Parse("2024-12-20");
            DateTime limiteContrato2 = DateTime.Parse("2025-01-31");

            if (data_gerada <= LimiteContrato)
            {
                if (Globais.Main.PassarContrato == "NORMAL")
                {
                    if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                    {
                        tb_Valor.Text = "400,00";
                        tb_Desconto.Text = "230,00";
                    }
                    else
                    {
                        tb_Valor.Text = "550,00";
                        tb_Desconto.Text = "80,00";
                    }
                }
                else if (Globais.Main.PassarContrato == "MEIO P.")
                {
                    if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                    {
                        tb_Valor.Text = "600,00";
                        tb_Desconto.Text = "500,00";
                    }
                    else
                    {
                        tb_Valor.Text = "900,00";
                        tb_Desconto.Text = "200,00";
                    }
                }
                else if (Globais.Main.PassarContrato == "INTEGRAL")
                {
                    if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                    {
                        tb_Valor.Text = "800,00";
                        tb_Desconto.Text = "900,00";
                    }
                    else
                    {
                        tb_Valor.Text = "1300,00";
                        tb_Desconto.Text = "400,00";
                    }
                }
            }
            else if (data_gerada <= limiteContrato2 )
            {
                if (Globais.Main.PassarContrato == "NORMAL")
                {
                    if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                    {
                        tb_Valor.Text = "500,00";
                        tb_Desconto.Text = "130,00";
                    }
                    else
                    {
                        tb_Valor.Text = "550,00";
                        tb_Desconto.Text = "80,00";
                    }
                }
                else if (Globais.Main.PassarContrato == "MEIO P.")
                {
                    if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                    {
                        tb_Valor.Text = "700,00";
                        tb_Desconto.Text = "400,00";
                    }
                    else
                    {
                        tb_Valor.Text = "900,00";
                        tb_Desconto.Text = "200,00";
                    }
                }
                else if (Globais.Main.PassarContrato == "INTEGRAL")
                {
                    if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                    {
                        tb_Valor.Text = "900,00";
                        tb_Desconto.Text = "800,00";
                    }
                    else
                    {
                        tb_Valor.Text = "1300,00";
                        tb_Desconto.Text = "400,00";
                    }
                }
            }
            else //Fevereiro em diante
            {
                if (Globais.Main.PassarContrato == "NORMAL")
                {
                    if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                    {
                        tb_Valor.Text = "600,00";
                        tb_Desconto.Text = "30,00";
                    }
                    else
                    {
                        tb_Valor.Text = "630,00";
                        tb_Desconto.Text = "0,00";
                    }
                }
                else if (Globais.Main.PassarContrato == "MEIO P.")
                {
                    if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                    {
                        tb_Valor.Text = "1050,00";
                        tb_Desconto.Text = "50,00";
                    }
                    else
                    {
                        tb_Valor.Text = "1100,00";
                        tb_Desconto.Text = "0,00";
                    }
                }
                else if (Globais.Main.PassarContrato == "INTEGRAL")
                {
                    if (lb_FormaPagamento.Text == "DINHEIRO" || lb_FormaPagamento.Text == "PIX")
                    {
                        tb_Valor.Text = "1600,00";
                        tb_Desconto.Text = "100,00";
                    }
                    else
                    {
                        tb_Valor.Text = "1700,00";
                        tb_Desconto.Text = "0,00";
                    }
                }
            }

        }

        private void btn_Dinheiro_Click(object sender, EventArgs e)
        {
            lb_FormaPagamento.Text = "DINHEIRO";

            if (Globais.Main.PassarAno == "2027")
            {
                Matriculas2027();
            }
            else if (Globais.Main.PassarAno == "2026")
            {
                Matriculas2026();
            }
            else
            {
                Matriculas2025();
            }
        }

        private void btn_Pix_Click(object sender, EventArgs e)
        {
            lb_FormaPagamento.Text = "PIX";
            if (Globais.Main.PassarAno == "2027")
            {
                Matriculas2027();
            }
            else if (Globais.Main.PassarAno == "2026")
            {
                Matriculas2026();
            }
            else
            {
                Matriculas2025();
            }
        }

        private void btn_Debito_Click(object sender, EventArgs e)
        {
            lb_FormaPagamento.Text = "DÉBITO";
            if (Globais.Main.PassarAno == "2027")
            {
                Matriculas2027();
            }
            else if (Globais.Main.PassarAno == "2026")
            {
                Matriculas2026();
            }
            else
            {
                Matriculas2025();
            }
        }

        private void btn_Credito_Click(object sender, EventArgs e)
        {
            lb_FormaPagamento.Text = "CRÉDITO";
            if (Globais.Main.PassarAno == "2027")
            {
                Matriculas2027();
            }
            else if (Globais.Main.PassarAno == "2026")
            {
                Matriculas2026();
            }
            else
            {
                Matriculas2025();
            }
        }

        private void PagarPrimeiraParcela_Temp_Load(object sender, EventArgs e)
        {
            if (Globais.Main.PassarAno == "2027")
            {
                Matriculas2027();
            }
            else if (Globais.Main.PassarAno == "2026")
            {
                Matriculas2026();
            }
            else
            {
                Matriculas2025();
            }

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
                    decimal ValorTotal = Convert.ToDecimal(tb_Valor.Text);
                    Globais.Main.Modo = "CARTEIRA";
                    if (ValorTotal > Saldo_Carteira)
                    {
                        decimal Valor = ValorTotal - Saldo_Carteira;
                        tb_Valor.Text = Valor.ToString();
                    }

                    else
                    {
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
                decimal ValorTotal = Convert.ToDecimal(tb_Valor.Text);
                decimal Valor = ValorTotal - Saldo_Carteira;
                tb_Valor.Text = Valor.ToString();
                Globais.Main.Modo = "CARTEIRA NEGATIVA";
            }
        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {

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
                Globais.Main.PassarCaixa = tb_Valor.Text;

                int Minuto = 0;

                for (int i = 1; i <= 1; i++)
                {
                    var vcon = Banco.ConexaoBanco();
                    string DescontarMensalidade = String.Format(@"
                                    UPDATE tb_mensalidades 
                                    SET 
                                    saldo_devedor= saldo_devedor - valor_parcela,
                                    parcelas_pagas = parcelas_pagas + 1
                                    WHERE idaluno={0} AND ano_letivo={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);
                    Banco.dml(DescontarMensalidade);
                    vcon.Close();

                    decimal Valor_Total = Convert.ToDecimal(tb_Valor.Text);

                    if (modo == 0)
                    {
                        Minuto = Minuto + 1;
                        DateTime MinutoHorario = Horario.AddMinutes(Minuto);

                        string IDMensalidade = String.Format(@"SELECT ID_mensalidade FROM tb_mensalidades WHERE idaluno = {0} AND ano_letivo={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

                        DataTable idmensalidade = Banco.dql(IDMensalidade);

                        int ID_mensalidade = idmensalidade.Rows[0].Field<Int32>("ID_mensalidade");

                        Globais.Main.PassarID_Mensalidade = ID_mensalidade.ToString();
                       
                        int Mensalidade_Paga = 1;
                        Globais.Main.PassarMensalidades_paga = Mensalidade_Paga.ToString();

                        Globais.Main.PassarForma = lb_FormaPagamento.Text;
                        Globais.Main.PassarForma1 = "";
                        Globais.Main.PassarForma2 = "";
                        string Entrada = "ENTRADA";
                        string Mensalidade = "Mensalidade";
                        var vconn = Banco.ConexaoBanco();
                        string CaixaPagamento = String.Format(@"INSERT INTO
                        tb_caixa (valor_total,forma,tipo_movimentacao,descricao,usuario,data,horario,nome,curso,idaluno,mensalidades_paga,idmensalidade)
                        VALUES('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10},{11})", Valor_Total.ToString().Replace(",", "."), lb_FormaPagamento.Text, Entrada, Mensalidade, Globais.Main.PassarUsuario, Data, MinutoHorario.ToString("HH:mm"), Globais.Main.PassarAluno, Globais.Main.PassarCurso, Globais.Main.PassarIdAluno, Mensalidade_Paga, ID_mensalidade);
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


                        string QueryAtualizarSaldo = String.Format(@"UPDATE tb_carteira_aluno SET saldo_carteira= saldo_carteira -'" + Saldo_Carteira.ToString() + "' WHERE idaluno ={0}", Globais.Main.PassarParcelas);
                        Banco.dml(QueryAtualizarSaldo);

                        if (Globais.Main.Modo == "CARTEIRA")
                        {
                            string queryInsertCarteira = String.Format(@"
                            INSERT INTO 
                            tb_carteira (nome_aluno,valor_total,tipo,descricao,idaluno,data_gerada,usuario)  
                            VALUES ('{0}','{1}','{2}','{3}',{4},'{5}','{6}')", Globais.Main.PassarAluno, Saldo_Carteira.ToString().Replace("-", ""), "SAIDA", "Mensalidade", Globais.Main.PassarIdAluno, Data, Globais.Main.PassarUsuario);

                            Banco.dml(queryInsertCarteira);
                        }
                        else if (Globais.Main.Modo == "CARTEIRA NEGATIVA")
                        {
                            string queryInsertCarteira = String.Format(@"
                            INSERT INTO 
                            tb_carteira (nome_aluno,valor_total,tipo,descricao,idaluno,data_gerada,usuario)  
                            VALUES ('{0}','{1}','{2}','{3}',{4},'{5}','{6}')", Globais.Main.PassarAluno, Saldo_Carteira.ToString().Replace("-", ""), "ENTRADA", "Mensalidade", Globais.Main.PassarIdAluno, Data, Globais.Main.PassarUsuario);

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
                Globais.Main.PassarParcelas = Globais.Main.PassarIdAluno;

                Mensalidades.SelecionarRecibo selecionar = new Mensalidades.SelecionarRecibo();
                selecionar.ShowDialog();

                Close();

            }
        }

        private void chk_outros_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_outros.Checked == true)
            {
                
                    modo = 1;
                    //tb_Desconto.Enabled = false;
                    //tb_Valor.Enabled = false;

                    string IDMensalidade = String.Format(@"SELECT ID_mensalidade FROM tb_mensalidades WHERE idaluno = {0}", Globais.Main.PassarIdAluno);

                    DataTable idmensalidade = Banco.dql(IDMensalidade);

                    int ID_mensalidade = idmensalidade.Rows[0].Field<Int32>("ID_mensalidade");


                    string Mensalidades = String.Format(@"SELECT IFNULL (MAX(mensalidades_paga),0) as mensalidades_pagas FROM tb_caixa WHERE descricao = 'Mensalidade' AND idaluno ={0} AND idmensalidade ={1}", Globais.Main.PassarIdAluno, ID_mensalidade);

                    DataTable mensalidades = Banco.dql(Mensalidades);

                    string Mensalidades_Pagas = mensalidades.Rows[0].Field<Int64>("mensalidades_pagas").ToString();
                    int Mensalidade_Paga = Convert.ToInt32(Mensalidades_Pagas) + 1;
                    Globais.Main.PassarMensalidades_paga = Mensalidade_Paga.ToString();
                    Caixa.DuasFormasPrimeiraParcela_Temp f_DuasFormas = new Caixa.DuasFormasPrimeiraParcela_Temp(this);
                    f_DuasFormas.ShowDialog();
                
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

        private void PagarPrimeiraParcela_Temp_FormClosed(object sender, FormClosedEventArgs e)
        {
            Globais.Main.PassarTipo = "";
        }
    }
}
