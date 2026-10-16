using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Faltas
{
    public partial class GerarDiarioClasse : Form
    {
        public GerarDiarioClasse()
        {
            InitializeComponent();
        }


        private void GerarDiarioClasse_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> ano = new Dictionary<string, string>();

            ano.Add("2020", "2020");
            ano.Add("2021", "2021");
            ano.Add("2022", "2022");
            ano.Add("2023", "2023");
            ano.Add("2024", "2024");
            ano.Add("2025", "2025");
            ano.Add("2026", "2026");
            ano.Add("2027", "2027");
            ano.Add("2028", "2028");
            ano.Add("2029", "2029");
            ano.Add("2030", "2030");
            cb_ano.DataSource = new BindingSource(ano, null);
            cb_ano.DisplayMember = "Value";
            cb_ano.ValueMember = "Key";

            string AnoAtual = DateTime.Today.Year.ToString();
            cb_ano.SelectedValue = AnoAtual;

            Dictionary<string, string> mes = new Dictionary<string, string>();

            mes.Add("1", "JANEIRO");
            mes.Add("2", "FEVEREIRO");
            mes.Add("3", "MARÇO");
            mes.Add("4", "ABRIL");
            mes.Add("5", "MAIO");
            mes.Add("6", "JUNHO");
            mes.Add("7", "JULHO");
            mes.Add("8", "AGOSTO");
            mes.Add("9", "SETEMBRO");
            mes.Add("10", "OUTUBRO");
            mes.Add("11", "NOVEMBRO");
            mes.Add("12", "DEZEMBRO");
            cb_mes.DataSource = new BindingSource(mes, null);
            cb_mes.DisplayMember = "Value";
            cb_mes.ValueMember = "Key";

            string MesAtual = DateTime.Today.Month.ToString();
            cb_mes.SelectedValue = MesAtual;


            //POPULAR COMBOBOX Turma
            string vqueryTurmas = String.Format(@"
                SELECT
                ID_turma,
                nome_turma
                FROM tb_turmas
                WHERE ID_turma >= 1
                AND ano_letivo='{0}'", cb_ano.SelectedValue);

            cb_turma.DataSource = Banco.dql(vqueryTurmas);
            cb_turma.DisplayMember = "nome_turma";
            cb_turma.ValueMember = "ID_turma";

            cb_turma.SelectedValue = -1;
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            diario_classe diario_Classe = new diario_classe(this);
            diario_Classe.ShowDialog();

            Close();
        }
    }
}
