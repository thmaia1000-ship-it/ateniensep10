using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Selecionar
{
    public partial class EscolherCursoMensalidade : Form
    {
        public EscolherCursoMensalidade()
        {
            InitializeComponent();
        }

        private void btn_geral_Click(object sender, EventArgs e)
        {
            Globais.Main.Modo = "Geral";
            Cursos.MensalidadesPagasCurso mensalidadesPagasCurso = new Cursos.MensalidadesPagasCurso();
            mensalidadesPagasCurso.ShowDialog();
        }

        private void btn_danca_Click(object sender, EventArgs e)
        {
            Globais.Main.Modo = "Curso";
            Globais.Main.PassarCurso = "DANÇA";
            Cursos.MensalidadesPagasCurso mensalidadesPagasCurso = new Cursos.MensalidadesPagasCurso();
            mensalidadesPagasCurso.ShowDialog();
        }

        private void btn_judo_Click(object sender, EventArgs e)
        {
            Globais.Main.Modo = "Curso";
            Globais.Main.PassarCurso = "JUDÔ";
            Cursos.MensalidadesPagasCurso mensalidadesPagasCurso = new Cursos.MensalidadesPagasCurso();
            mensalidadesPagasCurso.ShowDialog();
        }

        private void btn_futebol_Click(object sender, EventArgs e)
        {
            Globais.Main.Modo = "Curso";
            Globais.Main.PassarCurso = "FUTEBOL";
            Cursos.MensalidadesPagasCurso mensalidadesPagasCurso = new Cursos.MensalidadesPagasCurso();
            mensalidadesPagasCurso.ShowDialog();
        }

        private void btn_formatura_Click(object sender, EventArgs e)
        {
            Globais.Main.Modo = "Curso";
            Globais.Main.PassarCurso = "FORMATURA";
            Cursos.MensalidadesPagasCurso mensalidadesPagasCurso = new Cursos.MensalidadesPagasCurso();
            mensalidadesPagasCurso.ShowDialog();
        }
    }
}
