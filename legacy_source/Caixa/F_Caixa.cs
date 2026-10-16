using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Caixa
{
    public partial class F_Caixa : Form
    {
        decimal EntradaTotal, SaidaTotal;
        public F_Caixa()
        {
            InitializeComponent();

        }

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
                    MessageBox.Show("Acesso não permitido", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("É necessário ter um usuário logado", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormataçãoDGV()
        {
            //Largura Coluna
            dgv_FluxoCaixa.Columns[0].Width = 80;
            dgv_FluxoCaixa.Columns[1].Width = 140;
            dgv_FluxoCaixa.Columns[2].Width = 110;
            dgv_FluxoCaixa.Columns[3].Width = 120;
            dgv_FluxoCaixa.Columns[4].Width = 360;
            dgv_FluxoCaixa.Columns[5].Width = 215;
            dgv_FluxoCaixa.Columns[6].Width = 130;
            dgv_FluxoCaixa.Columns[7].Width = 80;
            dgv_FluxoCaixa.Columns[8].Width = 120;

            //Centralizar Texto
            dgv_FluxoCaixa.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv_FluxoCaixa.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv_FluxoCaixa.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_FluxoCaixa.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv_FluxoCaixa.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv_FluxoCaixa.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_FluxoCaixa.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_FluxoCaixa.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_FluxoCaixa.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            //Converter Colunas em valores monetários
            dgv_FluxoCaixa.Columns[1].DefaultCellStyle.Format = "C";
            dgv_FluxoCaixa.Columns[2].DefaultCellStyle.Format = "C";
            dgv_FluxoCaixa.Columns[3].DefaultCellStyle.Format = "C";
            dgv_FluxoCaixa.Columns[4].DefaultCellStyle.Format = "C";
        }

        private void Total()
        {
            decimal Valor1, Valor2, Total;

            Valor1 = EntradaTotal;
            Valor2 = SaidaTotal;
            Total = Valor1 - Valor2;
            lb_TOTAL.Text = Total.ToString("C");

        }

        private void Entradas()
        {
            //Entrada Crédito
            string data1 = dtp_Data1.Value.ToString("yyyy-MM-dd");
            string data2 = dtp_Data2.Value.ToString("yyyy-MM-dd");
            string Forma = cb_Forma.SelectedValue.ToString();

            var vconn = Banco.ConexaoBanco();
            string EntradaTotalCredito = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_caixa
            WHERE tipo_movimentacao = 'ENTRADA' AND forma = 'CRÉDITO'
            AND data between '" + data1 + "' and '" + data2 + "'");
            DataTable Credito = Banco.dql(EntradaTotalCredito);
            vconn.Close();

            //Entrada Débito
            vconn = Banco.ConexaoBanco();
            string EntradaTotalDebito = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total 
            FROM tb_caixa
            WHERE tipo_movimentacao = 'ENTRADA' AND forma = 'DÉBITO'
            AND data between '" + data1 + "' and '" + data2 + "'");
            DataTable Debito = Banco.dql(EntradaTotalDebito);
            vconn.Close();

            //Entrada Dinheiro
            vconn = Banco.ConexaoBanco();
            string EntradaTotalDinheiro = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_caixa
            WHERE tipo_movimentacao = 'ENTRADA' AND forma = 'DINHEIRO'
            AND data between '" + data1 + "' and '" + data2 + "'");
            DataTable dinheiro = Banco.dql(EntradaTotalDinheiro);
            vconn.Close();

            //Entrada PIX
            vconn = Banco.ConexaoBanco();
            string EntradaTotalPIX = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_caixa
            WHERE tipo_movimentacao = 'ENTRADA' AND forma = 'PIX'
            AND data between '" + data1 + "' and '" + data2 + "'");
            DataTable pix = Banco.dql(EntradaTotalPIX);
            vconn.Close();

            //Entrada Total
            vconn = Banco.ConexaoBanco();
            string SubtotalDia = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_caixa
            WHERE tipo_movimentacao = 'ENTRADA'
            AND data between '" + data1 + "' and '" + data2 + "'");
            DataTable subtotal = Banco.dql(SubtotalDia);
            vconn.Close();

            //Venda Crédito
            vconn = Banco.ConexaoBanco();
            string VendaTotalCredito = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_caixa
            WHERE tipo_movimentacao = 'VENDA' AND forma = 'CRÉDITO'
            AND data between '" + data1 + "' and '" + data2 + "'");
            DataTable VendaCredito = Banco.dql(VendaTotalCredito);
            vconn.Close();

            //Entrada Débito
            vconn = Banco.ConexaoBanco();
            string VendaTotalDebito = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total 
            FROM tb_caixa
            WHERE tipo_movimentacao = 'VENDA' AND forma = 'DÉBITO'
            AND data between '" + data1 + "' and '" + data2 + "'");
            DataTable VendaDebito = Banco.dql(VendaTotalDebito);
            vconn.Close();

            //Entrada Dinheiro
            vconn = Banco.ConexaoBanco();
            string VendaTotalDinheiro = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_caixa
            WHERE tipo_movimentacao = 'VENDA' AND forma = 'DINHEIRO'
            AND data between '" + data1 + "' and '" + data2 + "'");
            DataTable Vendadinheiro = Banco.dql(VendaTotalDinheiro);
            vconn.Close();

            //Entrada PIX
            vconn = Banco.ConexaoBanco();
            string VendaTotalPIX = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_caixa
            WHERE tipo_movimentacao = 'VENDA' AND forma = 'PIX'
            AND data between '" + data1 + "' and '" + data2 + "'");
            DataTable Vendapix = Banco.dql(VendaTotalPIX);
            vconn.Close();

            vconn = Banco.ConexaoBanco();
            string VendaSubtotalDia = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_caixa
            WHERE tipo_movimentacao = 'VENDA'
            AND data between '" + data1 + "' and '" + data2 + "'");
            DataTable Vendasubtotal = Banco.dql(VendaSubtotalDia);
            vconn.Close();

            decimal ValorCredito, ValorDebito,ValorDinheiro,ValorPix,ValorEntrada;

            ValorCredito = Credito.Rows[0].Field<decimal>("total") + VendaCredito.Rows[0].Field<decimal>("total");
            ValorDebito = Debito.Rows[0].Field<decimal>("total") + VendaDebito.Rows[0].Field<decimal>("total");
            ValorDinheiro = dinheiro.Rows[0].Field<decimal>("total") + Vendadinheiro.Rows[0].Field<decimal>("total");
            ValorPix = pix.Rows[0].Field<decimal>("total") + Vendapix.Rows[0].Field<decimal>("total");
            ValorEntrada = subtotal.Rows[0].Field<decimal>("total") + Vendasubtotal.Rows[0].Field<decimal>("total");

            lb_TotalCredito.Text = ValorCredito.ToString("C");
            lb_TotalDebito.Text = ValorDebito.ToString("C");
            lb_TotalDinheiro.Text = ValorDinheiro.ToString("C");
            lb_TotalPIX.Text = ValorPix.ToString("C");
            lb_EntradaTotal.Text = ValorEntrada.ToString("C");
            EntradaTotal = ValorEntrada;

            if (cb_Forma.Enabled == true)
            {
                vconn = Banco.ConexaoBanco();
                string SubtotalDiaa = String.Format(@"
                SELECT IFNULL(SUM(valor_total),0) as total  
                FROM tb_caixa
                WHERE tipo_movimentacao = 'ENTRADA'
                AND forma='" + Forma + "' AND data BETWEEN '" + data1 + "' AND '" + data2 + "'");
                DataTable subtotaal = Banco.dql(SubtotalDiaa);
                vconn.Close();

                vconn = Banco.ConexaoBanco();
                string VendaSubtotalDiaa = String.Format(@"
                SELECT IFNULL(SUM(valor_total),0) as total  
                FROM tb_caixa
                WHERE tipo_movimentacao = 'VENDA'
                AND forma='" + Forma + "' AND data BETWEEN '" + data1 + "' AND '" + data2 + "'");
                DataTable Vendasubtotaal = Banco.dql(VendaSubtotalDiaa);
                vconn.Close();

                decimal EntradasTotaiss = subtotaal.Rows[0].Field<decimal>("total") + Vendasubtotaal.Rows[0].Field<decimal>("total");

                lb_EntradaTotal.Text = EntradasTotaiss.ToString("C");
                EntradaTotal = EntradasTotaiss;
            }
            else
            {
                return;
            }

        }

        private void Saidas()
        {
            //Saida Crédito
            string data1 = dtp_Data1.Value.ToString("yyyy-MM-dd");
            string data2 = dtp_Data2.Value.ToString("yyyy-MM-dd");
            string Forma = cb_Forma.SelectedValue.ToString();
            string Tipo = cb_tipo.SelectedValue.ToString();

            var vconn = Banco.ConexaoBanco();
            string SubtotalDia = String.Format(@"
            SELECT IFNULL(SUM(valor_total),0) as total  
            FROM tb_caixa
            WHERE tipo_movimentacao = 'SAIDA'
            AND data between '" + data1 + "' and '" + data2 + "'");
            DataTable subtotal = Banco.dql(SubtotalDia);
            vconn.Close();

            lb_SubtotalSaidas.Text = subtotal.Rows[0].Field<decimal>("total").ToString("C");
            SaidaTotal = subtotal.Rows[0].Field<decimal>("total");

            if (cb_Forma.Enabled == true)
            {
                vconn = Banco.ConexaoBanco();
                string SubtotalDiaa = String.Format(@"
                SELECT IFNULL(SUM(valor_total),0) as total  
                FROM tb_caixa
                WHERE  tipo_movimentacao= 'SAIDA'
                AND forma= '" + Forma + "'AND data BETWEEN '" + data1 + "' AND '" + data2 + "'");
                DataTable subtotaal = Banco.dql(SubtotalDiaa);
                vconn.Close();

                lb_SubtotalSaidas.Text = subtotaal.Rows[0].Field<decimal>("total").ToString("C");
                SaidaTotal = subtotal.Rows[0].Field<decimal>("total");
            }
            else
            {
                return;
            }
        }


        private void FiltrarTodos()
        {
            string data1 = dtp_Data1.Value.ToString("yyyy-MM-dd");
            string data2 = dtp_Data2.Value.ToString("yyyy-MM-dd");
            string Forma = cb_Forma.SelectedValue.ToString();
            string Tipo = cb_tipo.SelectedValue.ToString();

            if (cb_tipo.Enabled == true && cb_Forma.Enabled == true)
            {
                string queryFluxoCaixa = String.Format(@"

            SELECT
                ID_caixa as 'ID',
                valor_total as 'Valor',
                forma as 'Forma de Pagamento',
                tipo_movimentacao as 'Movimentacao',
                nome as 'Nome',
                descricao as 'Descricao',
                data as 'Data',
                horario as 'Horario', 
                usuario as 'Usuario'
             FROM tb_caixa
             	WHERE 
    				data BETWEEN '" + data1 + "' AND '" + data2 + "' AND tipo_movimentacao='" + Tipo + "' AND forma='" + Forma + "'ORDER BY tipo_movimentacao");

                dgv_FluxoCaixa.DataSource = Banco.dql(queryFluxoCaixa);
                FormataçãoDGV();
            }

            else if (cb_tipo.Enabled == true && cb_Forma.Enabled == false)
            {
                string queryFluxoCaixa = String.Format(@"

            SELECT
               ID_caixa as 'ID',
                valor_total as 'Valor',
                forma as 'Forma de Pagamento',
                tipo_movimentacao as 'Movimentacao',
                nome as 'Nome',
                descricao as 'Descricao',
                data as 'Data',
                horario as 'Horario', 
                usuario as 'Usuario'
             FROM tb_caixa
             	WHERE 
    				data BETWEEN '" + data1 + "' AND '" + data2 + "' AND tipo_movimentacao='" + Tipo + "'ORDER BY tipo_movimentacao");

                dgv_FluxoCaixa.DataSource = Banco.dql(queryFluxoCaixa);
                FormataçãoDGV();
            }
            else if (cb_tipo.Enabled == false && cb_Forma.Enabled == true)
            {
                string queryFluxoCaixa = String.Format(@"

           SELECT
               ID_caixa as 'ID',
                valor_total as 'Valor',
                forma as 'Forma de Pagamento',
                tipo_movimentacao as 'Movimentacao',
                nome as 'Nome',
                descricao as 'Descricao',
                data as 'Data',
                horario as 'Horario', 
                usuario as 'Usuario'
             FROM tb_caixa
             	WHERE 
    				data BETWEEN '" + data1 + "' AND '" + data2 + "' AND forma='" + Forma + "' ORDER BY tipo_movimentacao");

                dgv_FluxoCaixa.DataSource = Banco.dql(queryFluxoCaixa);
                FormataçãoDGV();
            }
            else
            {
                string queryFluxoCaixa = String.Format(@"

            SELECT
               ID_caixa as 'ID',
                valor_total as 'Valor',
                forma as 'Forma de Pagamento',
                tipo_movimentacao as 'Movimentacao',
                nome as 'Nome',
                descricao as 'Descricao',
                data as 'Data',
                horario as 'Horario', 
                usuario as 'Usuario'
             FROM tb_caixa
             	WHERE 
    				data BETWEEN '" + data1 + "' AND '" + data2 + "'ORDER BY tipo_movimentacao");
                dgv_FluxoCaixa.DataSource = Banco.dql(queryFluxoCaixa);
                FormataçãoDGV();
            }

            Entradas();
            Saidas();
        }

        private void F_Caixa_Load(object sender, EventArgs e)
        {
            if (Globais.nivel == 2)
            {
                btn_Saida.Visible = false;
                btn_corrigir.Visible = false;
            }

            Dictionary<string, string> forma = new Dictionary<string, string>();

            forma.Add("CRÉDITO", "CRÉDITO");
            forma.Add("DÉBITO", "DÉBITO");
            forma.Add("DINHEIRO", "DINHEIRO");
            forma.Add("PIX", "PIX");
            cb_Forma.DataSource = new BindingSource(forma, null);
            cb_Forma.DisplayMember = "Value";
            cb_Forma.ValueMember = "Key";

            Dictionary<string, string> Tipo = new Dictionary<string, string>();

            Tipo.Add("ENTRADA", "ENTRADA");
            Tipo.Add("SAIDA", "SAIDA");
            cb_tipo.DataSource = new BindingSource(Tipo, null);
            cb_tipo.DisplayMember = "Value";
            cb_tipo.ValueMember = "Key";


            cb_Forma.Enabled = false;
            cb_tipo.Enabled = false;
            string data1 = dtp_Data1.Value.ToString("yyyy-MM-dd");
            string data2 = dtp_Data2.Value.ToString("yyyy-MM-dd");

            string queryFluxoCaixa = String.Format(@"
             
            SELECT
                ID_caixa as 'ID',
                valor_total as 'Valor',
                forma as 'Forma de Pagamento',   
                tipo_movimentacao as 'Movimentacao',
                nome as 'Nome',
                descricao as 'Descricao',
                data as 'Data',
                horario as 'Horario', 
                usuario as 'Usuario'
             FROM tb_caixa
             	WHERE 
    				data between '" + data1 + "' and '" + data2 + "'ORDER BY tipo_movimentacao");

            dgv_FluxoCaixa.DataSource = Banco.dql(queryFluxoCaixa);


            FormataçãoDGV();

            Entradas();
            Saidas();
            Total();
        }


        private void Liberar_ComboBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Permitir_FiltroForma.Checked == true)
            {
                cb_Forma.Enabled = true;
                FiltrarTodos();
                Entradas();
                Saidas();
                Total();
            }
            else
            {
                cb_Forma.Enabled = false;
                FiltrarTodos();
                Entradas();
                Saidas();
                Total();
            }
        }


        private void dtp_Data1_ValueChanged(object sender, EventArgs e)
        {
            FiltrarTodos();
            Entradas();
            Saidas();
            Total();
        }
        private void dtp_Data2_ValueChanged(object sender, EventArgs e)
        {
            FiltrarTodos();
            Entradas();
            Saidas();
            Total();
        }

        private void cb_Forma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FiltrarTodos();
            Entradas();
            Saidas();
            Total();

        }

        private void cb_tipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FiltrarTodos();
            Entradas();
            Saidas();
            Total();
        }

        private void Permitir_FiltroTipo_CheckedChanged(object sender, EventArgs e)
        {
            if (Permitir_FiltroTipo.Checked == true)
            {
                cb_tipo.Enabled = true;
                FiltrarTodos();
                Entradas();
                Saidas();
                Total();
            }
            else
            {
                cb_tipo.Enabled = false;
                FiltrarTodos();
                Entradas();
                Saidas();
                Total();
            }
        }

        private void btn_Saida_Click(object sender, EventArgs e)
        {
            F_Saida f_Saida = new F_Saida();
            f_Saida.ShowDialog();
        }

        private void dgv_FluxoCaixa_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgv_FluxoCaixa.ClearSelection();
        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            Globais.Main.PassarTipo = "CAIXA";
            Fluxos.SelecionarDatas selecionarDatas = new Fluxos.SelecionarDatas();
            selecionarDatas.Show();
        }

        private void btn_atualizar_Click(object sender, EventArgs e)
        {
            string data1 = dtp_Data1.Value.ToString("yyyy-MM-dd");
            string data2 = dtp_Data2.Value.ToString("yyyy-MM-dd");
            string queryFluxoCaixa = String.Format(@"
             
            SELECT
                ID_caixa as 'ID',
                valor_total as 'Valor',
                forma as 'Forma de Pagamento',
                tipo_movimentacao as 'Movimentacao',
                nome as 'Nome',
                descricao as 'Descricao',
                data as 'Data',
                horario as 'Horario', 
                usuario as 'Usuario'
             FROM tb_caixa
             	WHERE 
    				data between '" + data1 + "' and '" + data2 + "'ORDER BY tipo_movimentacao");

            dgv_FluxoCaixa.DataSource = Banco.dql(queryFluxoCaixa);
            FormataçãoDGV();

            Entradas();
            Saidas();
            Total();
        }

        private void btn_Corrigir_Click(object sender, EventArgs e)
        {
            F_ExcluirRegistro f_ExcluirRegistro = new F_ExcluirRegistro();
            abreForm(5, f_ExcluirRegistro);
        }

        private void btn_2via_Click(object sender, EventArgs e)
        {
            Selecionar.F_SelecionarReciboEntrada2Via f_SelecionarReciboEntrada2Via = new Selecionar.F_SelecionarReciboEntrada2Via();
            abreForm(2, f_SelecionarReciboEntrada2Via);
        }

        private void btn_2viasaida_Click(object sender, EventArgs e)
        {
            Selecionar.F_SelecionarReciboSaida2Via f_SelecionarReciboSaida2Via = new Selecionar.F_SelecionarReciboSaida2Via();
            abreForm(2, f_SelecionarReciboSaida2Via);
        }

        private void btn_Entrada_Click(object sender, EventArgs e)
        {
            F_Entrada f_Entrada = new F_Entrada();
            f_Entrada.ShowDialog();
        }
    }
}
