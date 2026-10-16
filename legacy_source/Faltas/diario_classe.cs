using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Faltas
{
    public partial class diario_classe : Form
    {
        GerarDiarioClasse f_Gerardiario;
        public diario_classe(GerarDiarioClasse f)
        {
            InitializeComponent();
            f_Gerardiario = f;

        }

        string LimparTexto(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return "";

            // Remove caracteres indesejados (exceto letras, números, espaços e acentos comuns)
            string textoLimpo = Regex.Replace(texto, @"[^a-zA-Z0-9À-ÿ\s~^´ç]", "");

            // Remove quebras de linha
            textoLimpo = textoLimpo.Replace("\n", " ").Replace("\r", " ");

            return textoLimpo.Trim();
        }

        private void diario_classe_Load(object sender, EventArgs e)
        {
            int mes = Convert.ToInt32(f_Gerardiario.cb_mes.SelectedValue);
            int ano = Convert.ToInt32(f_Gerardiario.cb_ano.SelectedValue);

            DateTime ultimoDiaDoMes = new DateTime(ano, mes, DateTime.DaysInMonth(ano, mes));

            string nome_aluno, total_faltas = "";
            string lista_nomes = "";
            string lista_dias = "";
            string faltas1 = "";
            int ID_aluno = 0;
            int CountFaltas = 0;
            string planejamento = "";

            // Obter os alunos
            string vQueryAlunos = $@"
            SELECT 
            tba.ID_aluno,
            tba.nome_aluno,
            tba.datanasc,
            tba.turno,
            tbc.nome_curso
        FROM tb_alunos AS tba
        INNER JOIN tb_cursos AS tbc 
            ON tba.idcurso = tbc.ID_curso
        INNER JOIN tb_alunos_turmas AS tbt 
            ON tba.ID_aluno = tbt.idaluno
        WHERE 
            tbt.idturma = {f_Gerardiario.cb_turma.SelectedValue}
        ORDER BY 
            tba.nome_aluno";

            DataTable aluno = Banco.dql(vQueryAlunos);

            // Obter dados diario
            string vQueryDiario = $@"
            SELECT 
                tbd.data_diario,
                REPLACE(REPLACE(REPLACE(tbd.conteudos, '\n', ' '), '\r', ' '), ';', '') AS conteudos
            FROM 
                tb_diario as tbd
            INNER JOIn tb_turmas as tbt ON tbt.ID_turma = {f_Gerardiario.cb_turma.SelectedValue}
            WHERE 
                tbd.serie = tbt.serie
                AND tbd.ano_letivo = {f_Gerardiario.cb_ano.SelectedValue}
                AND MONTH(tbd.data_diario) = {f_Gerardiario.cb_mes.SelectedValue}
                AND YEAR(tbd.data_diario) = {f_Gerardiario.cb_ano.SelectedValue}
            ORDER BY 
                tbd.data_diario";

            DataTable diario = Banco.dql(vQueryDiario);

            for (int i = 0; i < 32; i++)
            {
                // Inicializar array de 31 dias com ";"
                CountFaltas = 0;
                string[] faltasDias = new string[31];
                for (int dia = 0; dia < 31; dia++)
                {
                    faltasDias[dia] = ";";
                }
                
                if(aluno.Rows.Count > i)
                {
                    // Obter o ID e nome do aluno atual
                    ID_aluno = aluno.Rows[i].Field<int>("ID_aluno");
                    string data_nasc = aluno.Rows[i].Field<DateTime>("datanasc").ToString("dd/MM/yyyy");
                    string turno = aluno.Rows[i].Field<string>("turno");
                    nome_aluno = aluno.Rows[i].Field<string>("nome_aluno") + " " + data_nasc + " ("+ turno+ ");";
                    lista_nomes += nome_aluno;

                    // Query para buscar faltas apenas para o aluno atual
                    string vqueryFaltas = $@"
                    SELECT 
                        tbf.status,
                        DAY(tbf.data_gerada) AS dia
                    FROM 
                        tb_faltas_historico AS tbf
                    WHERE 
                        tbf.idaluno = {ID_aluno}
                        AND MONTH(tbf.data_gerada) = {f_Gerardiario.cb_mes.SelectedValue}
                        AND YEAR(tbf.data_gerada) = {f_Gerardiario.cb_ano.SelectedValue}
                        AND tbf.ano_letivo = {f_Gerardiario.cb_ano.SelectedValue}
                        AND tbf.idturma = {f_Gerardiario.cb_turma.SelectedValue}
                    ORDER BY 
                        tbf.data_gerada";

                    DataTable faltas = Banco.dql(vqueryFaltas);

                    // Atribuir status de falta aos dias correspondentes
                    foreach (DataRow faltaRow in faltas.Rows)
                    {
                        int dia = 0;
                        string status = "";

                        // Validar e converter o dia
                        if (int.TryParse(faltaRow["dia"].ToString(), out dia))
                        {
                            dia--; // Ajustar para índice do array
                        }
                        else
                        {
                            continue; // Ignorar linha inválida
                        }

                        // Obter o status e substituir PRESENTE/FALTOU por P/F
                        status = Convert.ToString(faltaRow["status"]);
                        if (status == "PRESENTE") 
                        {
                            status = "P;";
                        }
                        else if (status == "FALTOU")
                        {
                            status = "F;";
                            CountFaltas++;
                        }

                        // Atribuir o status ao dia correspondente
                        if (dia >= 0 && dia < 31) // Garantir que está dentro do intervalo
                        {
                            faltasDias[dia] = status;
                        }
                    }

                    // Adicionar os status ao parâmetro faltas1
                    faltas1 += string.Join("", faltasDias);
                    //total_faltas += string.Join("", CountFaltas + ";");
                    total_faltas += CountFaltas.ToString() + ";";

                }
                else
                {
                    ID_aluno = 0;
                    lista_nomes = lista_nomes + ";";
                    // Adicionar 31 vezes ";" para garantir a estrutura correta
                    faltas1 += new string(';', 31);
                    total_faltas = total_faltas + ";";
                }

                //Diário =============================

                if(diario.Rows.Count > i)
                {
                    string data_diario = diario.Rows[i].Field<DateTime>("data_diario").ToString("dd/MM/yyyy") +";";
                    string conteudo = diario.Rows[i].Field<string>("conteudos") + ";";
                    lista_dias += data_diario;
                    planejamento += conteudo;
                }
                else
                {
                    lista_dias = lista_dias + ";";
                    planejamento = planejamento + ";";
                }
            }


            string Curso = aluno.Rows[0].Field<string>("nome_curso") ?? "";

            // Configurar os parâmetros no ReportViewer
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("nome_aluno", lista_nomes));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("faltas1", faltas1));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("total_faltas", total_faltas));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dia_aula", lista_dias));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("planejamento", planejamento));

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("mes", f_Gerardiario.cb_mes.Text));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("ano_letivo", f_Gerardiario.cb_ano.Text));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("turma", f_Gerardiario.cb_turma.Text));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("curso", Curso));

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("data_encerrada", ultimoDiaDoMes.ToString("dd 'de' MMMM 'de' yyyy")));


            this.reportViewer1.RefreshReport();

        }
    }
}
