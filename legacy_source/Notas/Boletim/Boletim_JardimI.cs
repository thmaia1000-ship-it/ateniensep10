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
    public partial class Boletim_JardimI : Form
    {
        public Boletim_JardimI()
        {
            InitializeComponent();
        }

        private void Boletim_JardimI_Load(object sender, EventArgs e)
        {
           
            var vconn = Banco.ConexaoBanco();

            // Consulta para buscar todas as notas dos 53 idmaterias e 4 bimestres de uma vez
            string vqueryNotas = String.Format(@"SELECT idmateria, nota, bimestre FROM tb_notas WHERE idaluno = {0} AND ano_letivo = '{1}' AND bimestre BETWEEN 1 AND 4 AND idmateria BETWEEN 37 AND 88 ORDER BY idmateria, bimestre", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

            DataTable notas = Banco.dql(vqueryNotas);
            vconn.Close();

            string Parecer = String.Format(@"
                SELECT bimestre,observacao FROM tb_observacoes WHERE idaluno = {0} AND ano_letivo = '{1}' AND bimestre BETWEEN 1 AND 4 ORDER BY bimestre", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);
            DataTable parecer = Banco.dql(Parecer);

            // Dicionário para mapear notas originais para abreviações
            Dictionary<string, string> notaMapeada = new Dictionary<string, string>
{
            {"Sim", "S"},
            {"Não", "N"},
            {"As Vezes", "AV"},
            {"Necessita Melhorar", "NM"},
            {"Ótimo", "O"},
            {"Bom", "B"},
            {"Regular", "R"},
        };

            int idmateria = 37;
            string Observacao = "";

            // Loop para percorrer as 53 matérias
            for (int i = 1; i <= 52; i++)
            {
                // Loop para percorrer os 4 bimestres
                for (int bimestre = 1; bimestre <= 4; bimestre++)
                {
                    DataRow[] rows = notas.Select($"idmateria = {idmateria} AND bimestre = {bimestre}");
                    DataRow[] obs = parecer.Select($"bimestre = {bimestre}");

                    if (rows.Length > 0)
                    {
                        if (obs.Length > 0)
                        {
                            Observacao = obs[0].Field<string>("observacao");
                        }
                        string NotaAluno = rows[0].Field<string>("nota");

                        // Verificar se a nota existe no dicionário, caso contrário, manter a nota original
                        if (notaMapeada.TryGetValue(NotaAluno, out string notaAbreviada))
                        {
                            NotaAluno = notaAbreviada;
                        }

                        // Definir os parâmetros do relatório para a combinação atual de matéria e bimestre
                        this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter($"nota{i}_Bim{bimestre}", NotaAluno));
                        this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter($"observacao_Bim{bimestre}", Observacao));
                    }
                    else
                    {
                        // Definir os parâmetros do relatório para o caso em que não há notas para a combinação atual de matéria e bimestre
                        this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter($"nota{i}_Bim{bimestre}", ""));
                        this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter($"observacao_Bim{bimestre}", ""));
                    }
                }
                idmateria++;
            }

            string vqueryinfoNotas = String.Format(@"
                        SELECT tbn.aluno,tbn.professor,tbn.ano_letivo, tba.turno FROM tb_notas as tbn
                        INNER JOIN tb_alunos AS tba ON tba.ID_aluno = tbn.idaluno
                        WHERE tbn.idaluno ={0} AND tbn.ano_letivo='{1}' AND idmateria ={2}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno, 37);
            DataTable info = Banco.dql(vqueryinfoNotas);

            if (info.Rows.Count > 0)
            {
                string nome_aluno = info.Rows[0].Field<string>("aluno");
                string professor = info.Rows[0].Field<string>("professor");
                string turno = info.Rows[0].Field<string>("turno");
                string ano = info.Rows[0].Field<string>("ano_letivo");

                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("nome_aluno", nome_aluno));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("professor", professor));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("turno", turno));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("ano_letivo", ano));
            }

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
                        faltasBimestres[bimestre] = totalFaltasBimestre; // Ajusta para o índice do array (0 a 3)
                        TotalFaltas += count;
                    }
                }
            }

            // Define os parâmetros do relatório para cada bimestre
            for (int i = 0; i < faltasBimestres.Length; i++)
            {
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter($"faltabim{i + 1}", faltasBimestres[i]));
            }
           

            this.reportViewer1.RefreshReport();
        }
    }
}
