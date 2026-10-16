using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Escolar.Notas.Boletim; // Referência para abrir o Form do ReportViewer

namespace Escolar.Notas.Selecionar
{
    public partial class SelecionarParecer : Form
    {
        public SelecionarParecer()
        {
            InitializeComponent();
        }

        private void SelecionarParecer_Load(object sender, EventArgs e)
        {
            // 1. Geração dinâmica dos anos letivos
            var anos = new Dictionary<string, string>();
            for (int i = 2022; i <= 2030; i++)
            {
                anos.Add(i.ToString(), i.ToString());
            }

            cb_ano.DataSource = new BindingSource(anos, null);
            cb_ano.DisplayMember = "Value";
            cb_ano.ValueMember = "Key";
            cb_ano.SelectedValue = DateTime.Now.ToString("yyyy");

            // 2. Carregar turmas e dados iniciais
            CarregarTurmas();
            CarregarDados();
        }

        private void CarregarTurmas()
        {
            if (cb_ano.SelectedValue == null) return;

            string queryTurmas = $@"
                SELECT ID_turma, nome_turma 
                FROM tb_turmas 
                WHERE ID_turma >= 1 AND ano_letivo = '{cb_ano.SelectedValue}'";

            cb_turma.DataSource = Banco.dql(queryTurmas);
            cb_turma.DisplayMember = "nome_turma";
            cb_turma.ValueMember = "ID_turma";
        }

        private void CarregarDados(string pesquisa = "")
        {
            if (cb_turma.SelectedValue == null || cb_ano.SelectedValue == null) return;

            // Busca os alunos da turma selecionada (sem necessidade de cruzar com tb_notas)
            string query = @"
                SELECT DISTINCT 
                    tba.ID_aluno AS 'ID',	
                    tba.nome_aluno AS 'Aluno(a)',
                    tba.etapa AS 'Etapa'
                FROM tb_alunos AS tba
                INNER JOIN tb_alunos_turmas AS tbt ON tbt.idaluno = tba.ID_aluno
                WHERE tbt.idturma = @idTurma ";

            if (!string.IsNullOrWhiteSpace(pesquisa))
            {
                query += "AND tba.nome_aluno LIKE @pesquisa ";
            }
            query += "ORDER BY tba.nome_aluno";

            using (var vcon = Banco.ConexaoBanco())
            using (var cm = new MySqlCommand(query, vcon))
            {
                cm.Parameters.AddWithValue("@idTurma", cb_turma.SelectedValue);

                if (!string.IsNullOrWhiteSpace(pesquisa))
                {
                    cm.Parameters.AddWithValue("@pesquisa", pesquisa + "%");
                }

                using (var da = new MySqlDataAdapter(cm))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv_SelecionarParecer.DataSource = dt;
                }
            }

            FormatarGrelha();
        }

        private void FormatarGrelha()
        {
            if (dgv_SelecionarParecer.Columns.Count >= 3)
            {
                dgv_SelecionarParecer.Columns[0].Width = 55;
                dgv_SelecionarParecer.Columns[1].Width = 563;
                dgv_SelecionarParecer.Columns[2].Width = 110;
            }
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            CarregarDados(tb_pesquisa.Text);
        }

        private void cb_turma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void cb_ano_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CarregarTurmas();
            CarregarDados();
        }

        // Evento principal: Clicar no aluno para abrir o relatório
        private void dgv_SelecionarParecer_DoubleClick(object sender, EventArgs e)
        {
            if (dgv_SelecionarParecer.SelectedRows.Count == 0) return;

            DataGridViewRow linhaSelecionada = dgv_SelecionarParecer.SelectedRows[0];

            // 1. Alimentar as variáveis globais que o form 'Parecer' vai utilizar no Load
            Globais.Main.PassarIdAluno = linhaSelecionada.Cells[0].Value.ToString();
            Globais.Main.PassarAno = cb_ano.Text;

            string nomeEtapa = linhaSelecionada.Cells[2].Value.ToString().ToUpper();

            // 2. Definir o ID da Etapa
            switch (nomeEtapa)
            {
                case "MATERNAL I": Globais.Main.PassarIDEtapa = 1; break;
                case "JARDIM I": Globais.Main.PassarIDEtapa = 2; break;
                case "JARDIM II": Globais.Main.PassarIDEtapa = 3; break;
                case "MATERNAL II": Globais.Main.PassarIDEtapa = 5; break;
                case "1° ANO":
                case "1º ANO": Globais.Main.PassarIDEtapa = 4; break;
                default: Globais.Main.PassarIDEtapa = 0; break;
            }

            // 3. Instanciar e abrir o ecrã do ReportViewer (Boletim.Parecer)
            Parecer formParecer = new Parecer();
            formParecer.ShowDialog();
        }
    }
}