using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Bimestre
{
    public partial class Definir_Bimestre : Form
    {
        public Definir_Bimestre()
        {
            InitializeComponent();
        }

        private void Definir_Bimestre_Load(object sender, EventArgs e)
        {
            string Bimestres = String.Format(@"SELECT ID_bimestre,data_inicio, data_fim FROM tb_bimestres ORDER BY ID_bimestre");

            DataTable bim = Banco.dql(Bimestres);

            data1_bim1.Value = DateTime.Parse(bim.Rows[0].Field<DateTime>("data_inicio").ToString());
            data2_bim1.Value = DateTime.Parse(bim.Rows[0].Field<DateTime>("data_fim").ToString());

            data1_bim2.Value = DateTime.Parse(bim.Rows[1].Field<DateTime>("data_inicio").ToString());
            data2_bim2.Value = DateTime.Parse(bim.Rows[1].Field<DateTime>("data_fim").ToString());

            data1_bim3.Value = DateTime.Parse(bim.Rows[2].Field<DateTime>("data_inicio").ToString());
            data2_bim3.Value = DateTime.Parse(bim.Rows[2].Field<DateTime>("data_fim").ToString());

            data1_bim4.Value = DateTime.Parse(bim.Rows[3].Field<DateTime>("data_inicio").ToString());
            data2_bim4.Value = DateTime.Parse(bim.Rows[3].Field<DateTime>("data_fim").ToString());
        }

        private void btn_definir_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Deseja salvar estes dados?", "Mensagem do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            else
            {

                string MudarBim1 = String.Format(@"UPDATE tb_bimestres SET data_inicio='{0}',data_fim='{1}' WHERE ID_bimestre ={2}", data1_bim1.Value.ToString("yyyy-MM-dd"), data2_bim1.Value.ToString("yyyy-MM-dd"), 1);

                Banco.dml(MudarBim1);

                string MudarBim2 = String.Format(@"UPDATE tb_bimestres SET data_inicio='{0}',data_fim='{1}' WHERE ID_bimestre ={2}", data1_bim2.Value.ToString("yyyy-MM-dd"), data2_bim2.Value.ToString("yyyy-MM-dd"), 2);

                Banco.dml(MudarBim2);

                string MudarBim3 = String.Format(@"UPDATE tb_bimestres SET data_inicio='{0}',data_fim='{1}' WHERE ID_bimestre ={2}", data1_bim3.Value.ToString("yyyy-MM-dd"), data2_bim3.Value.ToString("yyyy-MM-dd"), 3);

                Banco.dml(MudarBim3);

                string MudarBim4 = String.Format(@"UPDATE tb_bimestres SET data_inicio='{0}',data_fim='{1}' WHERE ID_bimestre ={2}", data1_bim4.Value.ToString("yyyy-MM-dd"), data2_bim4.Value.ToString("yyyy-MM-dd"), 4);

                Banco.dml(MudarBim4);

                MessageBox.Show("Bimestres Definidos com sucesso!","Mensagem do Sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
        }
    }
}
