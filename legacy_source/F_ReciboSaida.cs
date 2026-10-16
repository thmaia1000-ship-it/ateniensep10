using Escolar.Caixa;
using Escolar.Relatorios;
using Google.Protobuf.WellKnownTypes;
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
    public partial class F_ReciboSaida : Form
    {
        public F_ReciboSaida()
        {
            InitializeComponent();
        }

        private void F_ReciboSaida_Load(object sender, EventArgs e)
        {
            if (Globais.Main.Modo != "1")
            {

                string data = DateTime.Now.ToString("dd/MM/yyyy");
                string hora = DateTime.Now.ToString("HH:mm");

                ReciboSaida1.SetParameterValue("data", data);
                ReciboSaida1.SetParameterValue("hora", hora);

                ReciboSaida1.SetParameterValue("valor_total", decimal.Parse(Globais.Main.PassarCaixa.Replace(".", ",")).ToString("C"));
                ReciboSaida1.SetParameterValue("descricao", Globais.Main.PassarDesc);
                ReciboSaida1.SetParameterValue("nome", Globais.Main.PassarAluno.ToUpper());
                ReciboSaida1.SetParameterValue("atendente", Globais.Main.PassarUsuario);
            }
            else
            {
                var vcon = Banco.ConexaoBanco();
                string curso = String.Format(@"
                SELECT 
                nome,
                valor_total,
                descricao,
                usuario,
                data,
                horario
                FROM tb_caixa WHERE ID_caixa= " + Globais.Main.PassarIdCaixa);

                DataTable dt = Banco.dql(curso);
                vcon.Close();

                string Nome_Aluno = dt.Rows[0].Field<string>("nome");
                string Valor_Total = dt.Rows[0].Field<decimal>("valor_total").ToString("C");
                string usuario = dt.Rows[0].Field<string>("usuario");
                string descricao = dt.Rows[0].Field<string>("descricao");
                string Data = dt.Rows[0].Field<DateTime>("data").ToString("dd/MM/yyyy");
                string Horario = dt.Rows[0].Field<string>("horario");

                ReciboSaida1.SetParameterValue("data", Data);
                ReciboSaida1.SetParameterValue("hora", Horario);

                ReciboSaida1.SetParameterValue("valor_total", Valor_Total);
                ReciboSaida1.SetParameterValue("descricao", descricao);
                ReciboSaida1.SetParameterValue("nome", Nome_Aluno.ToUpper());
                ReciboSaida1.SetParameterValue("atendente", usuario);

            }

        }
    }
}
