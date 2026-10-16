using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;

namespace Escolar.Notas.Boletim
{
    public partial class Parecer : Form
    {
        public Parecer()
        {
            InitializeComponent();
        }

        private void Parecer_Load(object sender, EventArgs e)
        {
            List<ReportParameter> parametrosRelatorio = new List<ReportParameter>();

            // A SOLUÇÃO: Inicializar o array com "0" em vez de vazio ("")
            string[] faltasBimestres = new string[4] { "0", "0", "0", "0" };
            string[] observacoesBimestres = new string[4] { "", "", "", "" };

            string nomeAluno = "";
            string nomeProfessor = "";
            string turma = "";
            bool temParecer = false;

            string queryFaltas = @"
                SELECT bimestre, COUNT(*) AS total_faltas
                FROM tb_faltas_historico 
                WHERE status = 'FALTOU' 
                  AND idaluno = @idAluno 
                  AND idetapa = @idEtapa 
                  AND ano_letivo = @anoLetivo  
                  AND bimestre BETWEEN 1 AND 4
                GROUP BY bimestre";

            string queryParecer = @"
                SELECT tbo.bimestre, tbo.observacao, tbo.nome_aluno, tbp.nome_professor, tbe.nome_etapa
                FROM tb_observacoes as tbo
                INNER JOIN tb_professores as tbp ON tbp.ID_professor = tbo.idprofessor
                INNER JOIN tb_etapas as tbe ON tbe.ID_etapa = tbo.idetapa
                WHERE tbo.idaluno = @idAluno 
                  AND tbo.ano_letivo = @anoLetivo 
                  AND tbo.bimestre BETWEEN 1 AND 4";

            using (var vcon = Banco.ConexaoBanco())
            {
                if (vcon.State == ConnectionState.Closed) vcon.Open();

                // 1. Ler Faltas
                using (var cmdFaltas = new MySqlCommand(queryFaltas, vcon))
                {
                    cmdFaltas.Parameters.AddWithValue("@idAluno", Globais.Main.PassarIdAluno);
                    cmdFaltas.Parameters.AddWithValue("@idEtapa", Globais.Main.PassarIDEtapa);
                    cmdFaltas.Parameters.AddWithValue("@anoLetivo", Globais.Main.PassarAno);

                    using (var readerFaltas = cmdFaltas.ExecuteReader())
                    {
                        while (readerFaltas.Read())
                        {
                            int bimestre = Convert.ToInt32(readerFaltas["bimestre"]);
                            int countFaltas = Convert.ToInt32(readerFaltas["total_faltas"]);

                            // Apenas atualiza se tiver mais de 0, senão mantém o "0" original
                            if (countFaltas > 0)
                            {
                                faltasBimestres[bimestre - 1] = countFaltas.ToString();
                            }
                        }
                    }
                }

                // 2. Ler Parecer e Dados do Aluno
                using (var cmdParecer = new MySqlCommand(queryParecer, vcon))
                {
                    cmdParecer.Parameters.AddWithValue("@idAluno", Globais.Main.PassarIdAluno);
                    cmdParecer.Parameters.AddWithValue("@anoLetivo", Globais.Main.PassarAno);

                    using (var readerParecer = cmdParecer.ExecuteReader())
                    {
                        while (readerParecer.Read())
                        {
                            temParecer = true;
                            int bimestre = Convert.ToInt32(readerParecer["bimestre"]);
                            observacoesBimestres[bimestre - 1] = readerParecer["observacao"].ToString();

                            // Preenche os dados gerais (nome, professor, turma) apenas uma vez
                            if (string.IsNullOrEmpty(nomeAluno))
                            {
                                nomeAluno = readerParecer["nome_aluno"].ToString();
                                nomeProfessor = readerParecer["nome_professor"].ToString();
                                turma = readerParecer["nome_etapa"].ToString();
                            }
                        }
                    }
                }
            }

            // 3. Verifica se encontrou pareceres para gerar o relatório
            if (temParecer)
            {
                parametrosRelatorio.Add(new ReportParameter("nome_aluno", nomeAluno));
                parametrosRelatorio.Add(new ReportParameter("professor", nomeProfessor));
                parametrosRelatorio.Add(new ReportParameter("turma", turma));
                parametrosRelatorio.Add(new ReportParameter("ano_letivo", Globais.Main.PassarAno));

                // Adiciona faltas e observações de uma vez só
                for (int i = 0; i < 4; i++)
                {
                    parametrosRelatorio.Add(new ReportParameter($"faltasbim{i + 1}", faltasBimestres[i]));
                    parametrosRelatorio.Add(new ReportParameter($"observacao_Bim{i + 1}", observacoesBimestres[i]));
                }

                this.reportViewer1.LocalReport.SetParameters(parametrosRelatorio);
                this.reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("O Aluno não possui nenhum parecer lançado.", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Evita que o relatório fique quebrado/em branco na tela caso falte dados
            }
        }
    }
}