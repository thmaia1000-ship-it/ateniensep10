using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.GerarContratos
{
    public partial class F_Ano_MeioPeriodo : Form
    {
        public F_Ano_MeioPeriodo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(tb_ano.TextLength ==4)
            {
                string queryAtualizarAluno = String.Format(@"UPDATE tb_alunos SET ano_letivo={0} WHERE ID_aluno={1}", tb_ano.Text, Globais.Main.PassarIdAluno);

                Banco.dml(queryAtualizarAluno);

                Globais.Main.PassarAno = tb_ano.Text;
                Close();
                F_ContratoMeioPeriodo f_ContratoMeioPeriodo = new F_ContratoMeioPeriodo();
                f_ContratoMeioPeriodo.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Insira o Ano para gerar o contrato!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_ano.Focus();
            }
        }
    }
}
