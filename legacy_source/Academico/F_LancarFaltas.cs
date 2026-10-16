using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Academico
{
    public partial class F_LancarFaltas : Form
    {
        F_BoletimEscolar f_BoletimEscolar;
        public F_LancarFaltas(F_BoletimEscolar f)
        {
            InitializeComponent();
            f_BoletimEscolar = f;
        }

        private void btn_faltas_Click(object sender, EventArgs e)
        {

            if (tb_faltas1.Text != "" || tb_faltas2.Text != "" || tb_faltas3.Text != "" || tb_faltas4.Text != "" )
            {
                string queryAtualizarFalta = String.Format(@"UPDATE tb_faltas SET faltas1='{0}',faltas2='{1}',faltas3='{2}',faltas4='{3}' WHERE ano_letivo='{4}' AND idaluno={5}", tb_faltas1.Text, tb_faltas2.Text, tb_faltas3.Text, tb_faltas4.Text, f_BoletimEscolar.cb_AnoLetivo.SelectedValue, f_BoletimEscolar.tb_Aluno.Tag.ToString());
                Banco.dml(queryAtualizarFalta);
                MessageBox.Show("Faltas Atualizadas com sucesso!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            
            else
            {
                string queryInsertFalta = String.Format(@"
                 INSERT INTO 
                 tb_faltas (faltas1,faltas2,faltas3,faltas4,ano_letivo,idaluno)  
                 VALUES ('{0}','{1}','{2}','{3}','{4}',{5})", tb_faltas1.Text, tb_faltas2.Text, tb_faltas3.Text, tb_faltas4.Text, f_BoletimEscolar.cb_AnoLetivo.SelectedValue, f_BoletimEscolar.tb_Aluno.Tag.ToString());
                Banco.dml(queryInsertFalta);
                MessageBox.Show("Faltas Lançadas com sucesso!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }

        

        }

        private void F_LancarFaltas_Load(object sender, EventArgs e)
        {
            var vcon = Banco.ConexaoBanco();
            string FaltasBimestre = String.Format(@"SELECT faltas1,faltas2,faltas3,faltas4 FROM tb_faltas WHERE ano_letivo='{0}' AND idaluno={1}", f_BoletimEscolar.cb_AnoLetivo.SelectedValue, f_BoletimEscolar.tb_Aluno.Tag.ToString());
            DataTable faltas = Banco.dql(FaltasBimestre);
            vcon.Close();
            if (faltas.Rows.Count > 0)
            {
                tb_faltas1.Text = faltas.Rows[0].Field<string>("faltas1");
                tb_faltas2.Text = faltas.Rows[0].Field<string>("faltas2");
                tb_faltas3.Text = faltas.Rows[0].Field<string>("faltas3");
                tb_faltas4.Text = faltas.Rows[0].Field<string>("faltas4");
            }
            else
            {
                tb_faltas1.Text = "";
                tb_faltas2.Text = "";
                tb_faltas3.Text = "";
                tb_faltas4.Text = "";
            }
        }
    }
}
