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
    public partial class F_SelecionarCurso : Form
    {
        F_NovoAluno formNovoAluno;

        public F_SelecionarCurso(F_NovoAluno f)
        {
            InitializeComponent();
            formNovoAluno = f;

        }



        private void F_SelecionarTurma_Load(object sender, EventArgs e)
        {
            string queryTurma = String.Format(@"

            SELECT  
                tbc.ID_curso as 'ID',
                tbc.nome_curso as 'Turma'

            FROM 
            tb_cursos as tbc
    
            ORDER BY tbc.nome_curso;
");

            dgv_SelecionarTurma.DataSource = Banco.dql(queryTurma);
            //Largura Coluna
            dgv_SelecionarTurma.Columns[0].Width = 25;
            dgv_SelecionarTurma.Columns[1].Width = 500;


        }

        private void dgv_SelecionarTurma_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

                //formNovoAluno.tb_Curso.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[1].Value.ToString();
                //formNovoAluno.tb_Curso.Tag = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
                
                Close();
        }
    }
}
