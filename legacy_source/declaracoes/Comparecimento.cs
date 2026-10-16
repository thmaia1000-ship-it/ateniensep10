using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.declaracoes
{
    public partial class Comparecimento : Form
    {
        public Comparecimento()
        {
            InitializeComponent();
        }

        private void Comparecimento_Load(object sender, EventArgs e)
        {
            tb_aluno.Text = Globais.Main.PassarAluno;
            tb_aluno.Tag = Globais.Main.PassarIdAluno;


            Dictionary<string, string> etapa = new Dictionary<string, string>();

            etapa.Add("MATERNAL I", "MATERNAL I");
            etapa.Add("MATERNAL II", "MATERNAL II");
            etapa.Add("JARDIM I", "JARDIM I");
            etapa.Add("JARDIM II", "JARDIM II");
            etapa.Add("1° ANO", "1° ANO");
            cb_Etapa.DataSource = new BindingSource(etapa, null);
            cb_Etapa.DisplayMember = "Value";
            cb_Etapa.ValueMember = "Key";

            cb_Etapa.SelectedValue = -1;

        }

        private void gerarButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_resp.Text) && !string.IsNullOrEmpty(cb_Etapa.Text))
            {
                impressao.declaracao_comparecimento comp = new impressao.declaracao_comparecimento(this);
                comp.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Preencha todos os campos!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
