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
    public partial class Boletim_JardimII : Form
    {
        public Boletim_JardimII()
        {
            InitializeComponent();
        }

        private void Boletim_JardimII_Load(object sender, EventArgs e)
        {
            
            var vconn = Banco.ConexaoBanco();

            // 1. Consulta das notas (matérias de 90 a 118)
            string vqueryNotas = String.Format(@"
    SELECT idmateria, nota, bimestre 
    FROM tb_notas 
    WHERE idaluno = {0} AND ano_letivo = '{1}' 
      AND bimestre BETWEEN 1 AND 4 
      AND idmateria BETWEEN 90 AND 118 
    ORDER BY idmateria, bimestre", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

            DataTable notas = Banco.dql(vqueryNotas);

            // 2. Consulta dos pareceres/observações
            string Parecer = String.Format(@"
    SELECT bimestre, observacao 
    FROM tb_observacoes 
    WHERE idaluno = {0} AND ano_letivo = '{1}' 
      AND bimestre BETWEEN 1 AND 4 
    ORDER BY bimestre", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

            DataTable parecer = Banco.dql(Parecer);
            vconn.Close();

            // 3. Definir as observações dos 4 bimestres PRIMEIRO (uma única vez por bimestre)
            for (int bimestre = 1; bimestre <= 4; bimestre++)
            {
                DataRow[] obs = parecer.Select($"bimestre = {bimestre}");
                string txtObservacao = obs.Length > 0 ? obs[0].Field<string>("observacao") : "";

                // Define o parâmetro de observação uma única vez por bimestre
                this.reportViewer1.LocalReport.SetParameters(
                    new Microsoft.Reporting.WinForms.ReportParameter($"observacao_Bim{bimestre}", txtObservacao)
                );
            }

            // Dicionário de mapeamento das notas
            Dictionary<string, string> notaMapeada = new Dictionary<string, string>
{
    {"Sim", "S"},
    {"Não", "N"},
    {"As Vezes", "AV"},
    {"Necessita Melhorar", "NM"},
    {"Ótimo", "O"},
    {"Bom", "B"},
    {"Regular", "R"}
};

            int idmateria = 90;

            // 4. Preencher as notas das 29 matérias (IDs 90 ao 118) nos 4 bimestres
            for (int i = 1; i <= 29; i++)
            {
                for (int bimestre = 1; bimestre <= 4; bimestre++)
                {
                    DataRow[] rows = notas.Select($"idmateria = {idmateria} AND bimestre = {bimestre}");

                    string NotaAluno = "";
                    if (rows.Length > 0)
                    {
                        NotaAluno = rows[0].Field<string>("nota");

                        if (notaMapeada.TryGetValue(NotaAluno, out string notaAbreviada))
                        {
                            NotaAluno = notaAbreviada;
                        }
                    }

                    // Define o parâmetro da nota da matéria 'i' (1 a 29) no 'bimestre' (1 a 4)
                    this.reportViewer1.LocalReport.SetParameters(
                        new Microsoft.Reporting.WinForms.ReportParameter($"nota{i}_Bim{bimestre}", NotaAluno)
                    );
                }
                idmateria++;
            }

            string vqueryinfoNotas = String.Format(@"
                        SELECT tbn.aluno,tbn.professor,tbn.ano_letivo, tba.turno FROM tb_notas as tbn
                        INNER JOIN tb_alunos AS tba ON tba.ID_aluno = tbn.idaluno
                        WHERE tbn.idaluno ={0} AND tbn.ano_letivo='{1}' AND idmateria ={2}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno, 90);
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
