using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Notas.Boletim
{
    public partial class BoletimNotas : Form
    {
        public BoletimNotas()
        {
            InitializeComponent();
        }

        private void BoletimNotas_Load(object sender, EventArgs e)
        {
            var vconn = Banco.ConexaoBanco();

            // Consulta para buscar todas as notas dos 8 idmaterias e 4 bimestres de uma vez
            string vqueryNotas = String.Format(@"
            SELECT 
            tbn.idmateria,
            tbn.nota,
            tbn.bimestre,
            tbn.professor,
            tbn.aluno,
            tbn.ano_letivo,
            tba.turno,
            tbn.idetapa
            FROM tb_notas as tbn
            INNER JOIN tb_alunos as tba
            ON tbn.idaluno = tba.ID_aluno
            WHERE tbn.idaluno = {0}
            AND tbn.ano_letivo = '{1}'
            AND tbn.bimestre BETWEEN 1 AND 4
            AND tbn.idmateria BETWEEN 153 AND 160
            AND tbn.idetapa={2}
            ORDER BY tbn.idmateria, tbn.bimestre", Globais.Main.PassarIdAluno, Globais.Main.PassarAno, Globais.Main.PassarIDEtapa);
           
            DataTable notas = Banco.dql(vqueryNotas);

                string nome_aluno = notas.Rows[0].Field<string>("aluno");
                string nome_professor = notas.Rows[0].Field<string>("professor");
                string ano_letivo = notas.Rows[0].Field<string>("ano_letivo");
                string turno = notas.Rows[0].Field<string>("turno");
            
            vconn.Close();

            int idmateria = 153;

            // Loop para percorrer as 8 matérias
            for (int i = 1; i <= 8; i++)
            {
                // Loop para percorrer os 4 bimestres
                for (int bimestre = 1; bimestre <= 4; bimestre++)
                {
                    DataRow[] rows = notas.Select($"idmateria = {idmateria} AND bimestre = {bimestre}");

                    if (rows.Length > 0)
                    {
                        string NotaAluno =rows[0].Field<string>("nota").Replace(".", ",");

                        // Definir os parâmetros do relatório para a combinação atual de matéria e bimestre 
                        if (idmateria == 153)
                        {
                            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter($"portugues_bim{bimestre}", Convert.ToDecimal(NotaAluno).ToString("F1")));
                        }
                        else if (idmateria == 154)
                        {
                            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter($"historia_bim{bimestre}", Convert.ToDecimal(NotaAluno).ToString("F1")));
                        }
                        else if (idmateria == 155)
                        {
                            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter($"geografia_bim{bimestre}", Convert.ToDecimal(NotaAluno).ToString("F1")));
                        }
                        else if (idmateria == 156)
                        {
                            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter($"ciencias_bim{bimestre}", Convert.ToDecimal(NotaAluno).ToString("F1")));
                        }
                        else if (idmateria == 157)
                        {
                            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter($"matematica_bim{bimestre}", Convert.ToDecimal(NotaAluno).ToString("F1")));
                        }
                        else if (idmateria == 158)
                        {
                            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter($"artes_bim{bimestre}", Convert.ToDecimal(NotaAluno).ToString("F1")));
                        }
                        else if (idmateria == 159)
                        {
                            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter($"edfisica_bim{bimestre}", Convert.ToDecimal(NotaAluno).ToString("F1")));
                        }
                        else if (idmateria == 160)
                        {
                            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter($"lingua_estrangeira_bim{bimestre}", Convert.ToDecimal(NotaAluno).ToString("F1")));
                        }
                    }
                    else
                    {
                        // Definir os parâmetros do relatório para o caso em que não há notas para a combinação atual de matéria e bimestre
                        if (idmateria == 153)
                        {
                            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter($"portugues_bim{bimestre}", ""));
                        }
                        else if (idmateria == 154)
                        {
                            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter($"historia_bim{bimestre}", ""));
                        }
                        else if (idmateria == 155)
                        {
                            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter($"geografia_bim{bimestre}", ""));
                        }
                        else if (idmateria == 156)
                        {
                            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter($"ciencias_bim{bimestre}", ""));
                        }
                        else if (idmateria == 157)
                        {
                            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter($"matematica_bim{bimestre}", ""));
                        }
                        else if (idmateria == 158)
                        {
                            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter($"artes_bim{bimestre}", ""));
                        }
                        else if (idmateria == 159)
                        {
                            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter($"edfisica_bim{bimestre}", ""));
                        }
                        else if (idmateria == 160)
                        {
                            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter($"lingua_estrangeira_bim{bimestre}", ""));
                        }
                    }
                }
                idmateria++;
            }

            string vqueryAluno = String.Format(@"SELECT etapa FROM tb_alunos WHERE ID_aluno = {0}", Globais.Main.PassarIdAluno);
            DataTable aluno = Banco.dql(vqueryAluno);
            string etapa = aluno.Rows[0].Field<string>("etapa").ToString();

            // Construção da query para retornar as faltas por bimestre
            string vqueryFaltas = String.Format(@"
            SELECT 
                bimestre, COUNT(*) AS total_faltas
            FROM 
                tb_faltas_historico 
            WHERE 
                status = 'FALTOU' AND idaluno = {0} AND idetapa = {1} AND ano_letivo = {2}
            GROUP BY 
                bimestre
            ORDER BY 
                bimestre",
                Globais.Main.PassarIdAluno, Globais.Main.PassarIDEtapa, Globais.Main.PassarAno);

            // Executa a consulta e obtém o resultado
            DataTable faltas = Banco.dql(vqueryFaltas);

            // Cria um array para armazenar os parâmetros dos bimestres
            string[] faltasBimestres = new string[4];

            // Inicializa o array com strings vazias
            for (int i = 0; i < faltasBimestres.Length; i++)
            {
                faltasBimestres[i] = "";
            }

            int TotalFaltas = 0;

            // Verifica se o resultado tem ao menos uma linha
            if (faltas.Rows.Count > 0)
            {
                // Loop através das linhas do DataTable para preencher os parâmetros
                foreach (DataRow row in faltas.Rows)
                {
                    int bimestre = Convert.ToInt32(row["bimestre"]);
                    string totalFaltasBimestre = row["total_faltas"].ToString();

                    // Adiciona o valor ao índice correspondente do array, se houver faltas
                    if (int.TryParse(totalFaltasBimestre, out int count) && count > 0)
                    {
                        faltasBimestres[bimestre] = totalFaltasBimestre; // Ajusta para o índice do array (0 a 3) faltasBimestres[bimestre - 1] = totalFaltasBimestre
                        TotalFaltas += count;
                    }
                }
            }

            // Define os parâmetros do relatório para cada bimestre
            for (int i = 0; i < faltasBimestres.Length; i++)
            {
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter($"faltabim{i + 1}", faltasBimestres[i]));
            }
            if(faltas.Rows.Count == 4)
            {
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("falta_total", TotalFaltas.ToString()));
            }

            // Lista para armazenar os parâmetros de cada matéria
            List<string> materias = new List<string> { "portugues", "historia", "geografia", "ciencias", "matematica", "artes", "edfisica", "lingua_estrangeira" };

            foreach (string materia in materias)
            {
                double totalNotas = 0;
                int contagemNotas = 0;

                for (int bimestre = 1; bimestre <= 4; bimestre++)
                {
                    // Constrói o nome do parâmetro dinamicamente
                    string nomeDoParametro = $"{materia}_bim{bimestre}";

                    // Verifica se o parâmetro existe
                    if (this.reportViewer1.LocalReport.GetParameters().Any(p => p.Name == nomeDoParametro))
                    {
                        // Obtém o valor do parâmetro
                        var parametro = this.reportViewer1.LocalReport.GetParameters().First(p => p.Name == nomeDoParametro).Values.First();

                        // Verifica se o valor não é vazio ou nulo e tenta converter para double
                        if (!string.IsNullOrEmpty(parametro) && double.TryParse(parametro, out double valorDoParametro))
                        {
                            // Adiciona ao total
                            totalNotas += valorDoParametro;
                            contagemNotas++; // Incrementa a contagem de notas válidas
                        }
                    }
                }

                // Só define o parâmetro "materia_mf" se houver exatamente 4 notas
                if (contagemNotas == 4)
                {
                    double media = totalNotas / 4;
                    this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter($"{materia}_mf", media.ToString("F1")));
                }
            }

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("nome_aluno", nome_aluno));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("nome_professor", nome_professor));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("turno", turno));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("ano_letivo", ano_letivo));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("etapa", etapa));

            /*string vqueryGrafico = String.Format(@"
            SELECT 
                tbn.bimestre,
                CONCAT(tbn.bimestre, 'º Bimestre')            AS descricao_bimestre,
                AVG(CAST(tbn.nota AS DECIMAL(10,2)))          AS media_bimestre
            FROM tb_notas AS tbn
            WHERE tbn.idaluno    = {0}
              AND tbn.ano_letivo = '{1}'
              AND tbn.idetapa    = {2}
              AND tbn.bimestre BETWEEN 1 AND 4
              AND tbn.idmateria BETWEEN 153 AND 160
            GROUP BY tbn.bimestre
            ORDER BY tbn.bimestre",
            Globais.Main.PassarIdAluno,
            Globais.Main.PassarAno,
            Globais.Main.PassarIDEtapa);

            DataTable dtEvolucao = Banco.dql(vqueryGrafico);

            this.reportViewer1.LocalReport.DataSources.Add(
                new Microsoft.Reporting.WinForms.ReportDataSource(
                    "dbatenienseDataSet",   // nome do DataSource no RDLC
                    dtEvolucao));
            */
            this.reportViewer1.RefreshReport();
        }
    }
}
