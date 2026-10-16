using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Gestão
{
    public partial class F_Observacoes : Form
    {
        public F_Observacoes()
        {
            InitializeComponent();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            string queryAtualizarOBS = String.Format(@"UPDATE tb_alunos SET observacao='{0}' WHERE ID_aluno={1}", tb_Obs.Text,Globais.Main.PassarIdAluno);

            Banco.dml(queryAtualizarOBS);
            MessageBox.Show("Dados Atualizados!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void F_Observacoes_Load(object sender, EventArgs e)
        {
            string vqueryCampos = String.Format(@"
                 SELECT
                    observacao
                FROM
                    tb_alunos
                WHERE ID_aluno={0}
                 ", Globais.Main.PassarIdAluno);
            DataTable dt = Banco.dql(vqueryCampos);
            tb_Obs.Text = dt.Rows[0].Field<string>("observacao");
        }
    }
}
