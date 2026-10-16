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
    public partial class F_EscolherRespAcad : Form
    {
        public F_EscolherRespAcad()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Globais.Main.PassarRespAcad = cb_respAcad.SelectedValue.ToString();

            this.Close();
        }

        private void F_EscolherRespAcad_Load(object sender, EventArgs e)
        {
            //POPULAR COMBOBOX
            string ResponsavelAcademico = String.Format(@"
                    SELECT
                    ID_responsavel_academico,
                    nome,
                    cpf,
                    rg,
                    nacionalidade,
                    rua,
                    bairro,
                    numero,
                    cep,
                    orgao_emissor
                    FROM
                        tb_responsavel_academico
                    WHERE idaluno={0} ORDER BY ID_responsavel_academico DESC LIMIT 10", Globais.Main.PassarIdAluno);

            cb_respAcad.DataSource = Banco.dql(ResponsavelAcademico);
            cb_respAcad.DisplayMember = "nome";
            cb_respAcad.ValueMember = "ID_responsavel_academico";
        }
    }
}
