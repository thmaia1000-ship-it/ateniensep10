using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Turmas
{
    public partial class CadastroTurma : Form
    {
        public CadastroTurma()
        {
            InitializeComponent();
        }

        private void CadastroTurma_Load(object sender, EventArgs e)
        {

            Dictionary<string, string> ano = new Dictionary<string, string>();


            ano.Add("2025", "2025");
            ano.Add("2026", "2026");
            ano.Add("2027", "2027");
            ano.Add("2028", "2028");
            ano.Add("2029", "2029");
            ano.Add("2030", "2030");

            cb_ano.DataSource = new BindingSource(ano, null);
            cb_ano.DisplayMember = "Value";
            cb_ano.ValueMember = "Key";

            string AnoAtual = DateTime.Now.ToString("yyyy");

            Dictionary<string, string> etapa = new Dictionary<string, string>();

            etapa.Add("1", "MATERNAL I");
            etapa.Add("5", "MATERNAL II");
            etapa.Add("2", "JARDIM I");
            etapa.Add("3", "JARDIM II");
            etapa.Add("4", "1° ANO");
            cb_Etapa.DataSource = new BindingSource(etapa, null);
            cb_Etapa.DisplayMember = "Value";
            cb_Etapa.ValueMember = "Key";

            Dictionary<string, string> turno = new Dictionary<string, string>();

            turno.Add("MATUTINO", "MATUTINO");
            turno.Add("VESPERTINO", "VESPERTINO");
            turno.Add("INTEGRAL", "INTEGRAL");
            cb_turno.DataSource = new BindingSource(turno, null);
            cb_turno.DisplayMember = "Value";
            cb_turno.ValueMember = "Key";

            //POPULAR COMBOBOX Professores
            string vqueryTurmas = @"
                SELECT
                ID_professor,
                nome_professor
   
                 FROM
                      tb_professores
                 ORDER BY
                      nome_professor";


            cb_professor.Items.Clear();
            cb_professor.DataSource = Banco.dql(vqueryTurmas);
            cb_professor.DisplayMember = "nome_professor";
            cb_professor.ValueMember = "ID_professor";
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            string Data = DateTime.Now.ToString("yyyy-MM-dd");
            string ano_letivo = cb_ano.Text;

            string queryInsert = String.Format(@"
                INSERT INTO 
                    tb_turmas (nome_turma,turno,qtd_alunos,idprofessor,ano_letivo,data_gerada,usuario,serie,idetapa)  
                VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", tb_nome.Text, cb_turno.Text, 0, cb_professor.SelectedValue, ano_letivo, Data, Globais.Main.PassarUsuario,cb_Etapa.Text,cb_Etapa.SelectedValue.ToString());

            Banco.dml(queryInsert);

            string UltimaTurma = String.Format(@"SELECT MAX(ID_turma) AS ID FROM tb_turmas");

            DataTable ultima_turma = Banco.dql(UltimaTurma);

            string ID_turma = ultima_turma.Rows[0].Field<Int32>("ID").ToString();

            queryInsert = String.Format(@"
                INSERT INTO 
                    tb_professores_turmas (idprofessor,idturma,data_gerada,usuario)  
                VALUES ({0},{1},'{2}','{3}')", cb_professor.SelectedValue, ID_turma, Data, Globais.Main.PassarUsuario);

            Banco.dml(queryInsert);

            MessageBox.Show("Turma Cadastrada", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
