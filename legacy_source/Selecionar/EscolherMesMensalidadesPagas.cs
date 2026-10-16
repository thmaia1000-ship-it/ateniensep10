using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Selecionar
{
    public partial class EscolherMesMensalidadesPagas : Form
    {
        public EscolherMesMensalidadesPagas()
        {
            InitializeComponent();
        }

        private void EscolherMesMensalidadesPagas_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> etapa = new Dictionary<string, string>();

            etapa.Add("1", "Janeiro");
            etapa.Add("2", "Fevereiro");
            etapa.Add("3", "Março");
            etapa.Add("4", "Abril");
            etapa.Add("5", "Maio");
            etapa.Add("6", "Junho");
            etapa.Add("7", "Julho");
            etapa.Add("8", "Agosto");
            etapa.Add("9", "Setembro");
            etapa.Add("10", "Outubro");
            etapa.Add("11", "Novembro");
            etapa.Add("12", "Dezembro");
            cb_mes.DataSource = new BindingSource(etapa, null);

            cb_mes.DisplayMember = "Value";
            cb_mes.ValueMember = "Key";

            cb_mes.SelectedValue = -1;

            tb_ano.Text = DateTime.Now.ToString("yyyy");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cb_mes.Text != "" && tb_ano.Text != "")
            {
                Globais.Main.PassarMes = cb_mes.SelectedValue.ToString();
                Globais.Main.PassarAno = tb_ano.Text;

                Selecionar.MensalidadeOuCurso mensalidadeOuCurso = new Selecionar.MensalidadeOuCurso();
                mensalidadeOuCurso.Show();

            }
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente número", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
