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
    public partial class F_Horarios : Form
    {
        public F_Horarios()
        {
            InitializeComponent();
        }

        private void F_Horarios_Load(object sender, EventArgs e)
        {
            string vquery = " SELECT ID_horario as 'ID', horario as 'Horário' FROM tb_horarios ORDER BY horario";
               
            dgv_horarios.DataSource = Banco.dql(vquery);
            dgv_horarios.Columns[0].Width = 60;
            dgv_horarios.Columns[1].Width = 170;
            
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgv_horarios_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int contlinhas = dgv.SelectedRows.Count;
            if (contlinhas > 0)
            {

                DataTable dt = new DataTable();
                string vid = dgv.SelectedRows[0].Cells[0].Value.ToString();
                string vquery = "SELECT * FROM tb_horarios WHERE ID_horario=" + vid;

                dt = Banco.dql(vquery);
                tb_idHorario.Text = dt.Rows[0].Field<Int32>("ID_horario").ToString();
                mtb_dscHorario.Text= dt.Rows[0].Field<string>("horario");

            }
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            tb_idHorario.Clear();
            mtb_dscHorario.Clear();
            mtb_dscHorario.Focus();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            string vquery;
            if (tb_idHorario.Text == "")
            {
                vquery = "INSERT INTO tb_horarios (horario) VALUES ('" + mtb_dscHorario.Text + "')";
            }else
            {
                vquery = "UPDATE tb_horarios SET horario='" + mtb_dscHorario.Text + "' WHERE ID_horario=" + tb_idHorario.Text;
            }
                Banco.dml(vquery);
                vquery = " SELECT ID_horario as 'ID', horario as 'Horário' FROM tb_horarios ORDER BY horario";

                dgv_horarios.DataSource = Banco.dql(vquery);
            
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseja excluir?", "Excluir?", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                string vquery = "DELETE FROM tb_horarios WHERE ID_horario=" + tb_idHorario.Text;
                Banco.dml(vquery);
                dgv_horarios.Rows.Remove(dgv_horarios.CurrentRow);

            }
        }
    }
}
