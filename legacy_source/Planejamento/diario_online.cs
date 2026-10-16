using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Diario
{
    public partial class diario_online : Form
    {
        public diario_online()
        {
            InitializeComponent();
        }

        private void diario_online_Load(object sender, EventArgs e)
        {

            if(Globais.nivel == 5)
            {
                btn_salvar.Visible = true;
                tb_professor.Enabled = true;
                tb_compCurricular.Enabled = true;
                tb_data.Enabled = true;
                cb_etapa.Enabled = true;
                tb_ativiadePercepcao.Enabled = true;
                tb_objetivos.Enabled = true;
                tb_conteudo.Enabled = true;
                tb_desenvolvimento.Enabled = true;
                tb_atividadeSala.Enabled = true;
                tb_atividadeCasa.Enabled = true;
                tb_recursos.Enabled = true;
                tb_avaliacao.Enabled = true;

            }
            else
            {
                btn_salvar.Visible = false;
            }

            Dictionary<string, string> etapa = new Dictionary<string, string>();

            etapa.Add("MATERNAL", "MATERNAL");
            etapa.Add("JARDIM I", "JARDIM I");
            etapa.Add("JARDIM II", "JARDIM II");
            etapa.Add("1° ANO", "1° ANO");
            cb_etapa.DataSource = new BindingSource(etapa, null);
            cb_etapa.DisplayMember = "Value";
            cb_etapa.ValueMember = "Key";

            string vqueryCampos = String.Format(@"
            SELECT
            nome_professor,
            comp_curricular,
            data_diario,
            serie,
            atividades_percepcao,
            objetivos,
            conteudos,
            desenvolvimento,
            atividade_sala,
            atividade_casa,
            recursos,
            avaliacao
            FROM
            tb_diario
            WHERE ID_diario={0}", Globais.Main.PassarIDDiario);

            DataTable dt = Banco.dql(vqueryCampos);
            tb_professor.Text = dt.Rows[0].Field<string>("nome_professor");
            tb_compCurricular.Text = dt.Rows[0].Field<string>("comp_curricular");
            tb_data.Text = dt.Rows[0].Field<DateTime>("data_diario").ToString("dd/MM/yyyy");
            cb_etapa.SelectedValue = dt.Rows[0].Field<string>("serie");
            tb_ativiadePercepcao.Text = SubstituirPontoVirgulaPorQuebraDeLinha(dt.Rows[0].Field<string>("atividades_percepcao"));
            tb_objetivos.Text = SubstituirPontoVirgulaPorQuebraDeLinha(dt.Rows[0].Field<string>("objetivos"));
            tb_conteudo.Text = SubstituirPontoVirgulaPorQuebraDeLinha(dt.Rows[0].Field<string>("conteudos"));
            tb_desenvolvimento.Text = SubstituirPontoVirgulaPorQuebraDeLinha(dt.Rows[0].Field<string>("desenvolvimento"));
            tb_atividadeSala.Text = SubstituirPontoVirgulaPorQuebraDeLinha(dt.Rows[0].Field<string>("atividade_sala"));
            tb_atividadeCasa.Text = SubstituirPontoVirgulaPorQuebraDeLinha(dt.Rows[0].Field<string>("atividade_casa"));
            tb_recursos.Text = SubstituirPontoVirgulaPorQuebraDeLinha(dt.Rows[0].Field<string>("recursos"));
            tb_avaliacao.Text = SubstituirPontoVirgulaPorQuebraDeLinha(dt.Rows[0].Field<string>("avaliacao"));

        }

        private string SubstituirPontoVirgulaPorQuebraDeLinha(string input)
        {
            return input.Replace(";", Environment.NewLine);
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            documento_Diario documento_Diario = new documento_Diario();
            documento_Diario.Show();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            string data_diario = Convert.ToDateTime(tb_data.Text).ToString("yyyy-MM-dd");

            string queryAtualizarDiario = String.Format(@"
            UPDATE tb_diario 
            SET 
            nome_professor = '{0}',
            comp_curricular = '{1}',
            data_diario = '{2}',
            serie = '{3}',
            atividades_percepcao = '{4}',
            objetivos = '{5}',
            conteudos = '{6}',
            desenvolvimento = '{7}',
            atividade_sala = '{8}',
            atividade_casa = '{9}',
            recursos = '{10}',
            avaliacao = '{11}'
            WHERE ID_diario = {12}",
            tb_professor.Text,
            tb_compCurricular.Text,
            data_diario,
            cb_etapa.SelectedValue.ToString(),
            tb_ativiadePercepcao.Text,
            tb_objetivos.Text,
            tb_conteudo.Text,
            tb_desenvolvimento.Text,
            tb_atividadeSala.Text,
            tb_atividadeSala.Text,
            tb_recursos.Text,
            tb_avaliacao.Text,
            Globais.Main.PassarIDDiario);

            Banco.dml(queryAtualizarDiario);

            MessageBox.Show("Dados Alterados com sucesso!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
