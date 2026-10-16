using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Escolar.Banco;

namespace Escolar
{
    public partial class TermoResp : Form
    {
        public TermoResp()
        {
            InitializeComponent();
        }

        private async void TermoResp_Load(object sender, EventArgs e)
        {
            using (F_Loading loading = new F_Loading("Carregando termo de responsabilidade..."))
            {
                loading.Owner = this;
                loading.Show();
                loading.BringToFront();
                loading.Refresh();

                try
                {
                    // Carrega todos os dados em background
                    await CarregarDadosFichaAsync();

                    // Mostra o relatório
                    crystalReportViewer1.ReportSource = TermoRESP1;

                    // Exporta e envia para FTP em background
                    await Task.Run(async () => await ExportarEnviarFichaAsync());

                    loading.Close();

                    MessageBox.Show("Termo de Responsabilidade enviado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    loading.Close();
                    MessageBox.Show($"Erro ao carregar ficha: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task CarregarDadosFichaAsync()
        {
            await Task.Run(() =>
            {
                // Executa as consultas no banco em thread separada
                CarregarDadosFicha();
            });
        }

        private void CarregarDadosFicha()
        {
            string data = DateTime.Now.ToString("dd/MM/yyyy");

            // Nome Aluno / Responsável Acadêmico
            string Aluno = String.Format(@"
            SELECT tba.nome_aluno, tbr.nome  FROM tb_alunos as tba INNER JOIN tb_responsavel_academico as tbr ON tbr.idaluno = tba.ID_aluno WHERE tbr.ID_responsavel_academico= {0}", Globais.Main.PassarRespAcad);

            DataTable aluno = Banco.dql(Aluno);

            Nome_aluno = aluno.Rows[0].Field<string>("nome_aluno");
            string nomeResp = aluno.Rows[0].Field<string>("nome");
            // Define os parâmetros do aluno
            TermoRESP1.SetParameterValue("nome_aluno", Nome_aluno.ToUpper());
            TermoRESP1.SetParameterValue("nome_responsavel_acad", nomeResp.ToUpper());
            TermoRESP1.SetParameterValue("data", data);
            TermoRESP1.SetParameterValue("ano_letivo", Globais.Main.PassarAno);
        }

        string Nome_aluno = "";

        private async Task ExportarEnviarFichaAsync()
        {
            // Exporta para PDF temporário
            string nomeFormatado = Regex.Replace(new string(Nome_aluno.Replace(" ", "_").Normalize(NormalizationForm.FormD).Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray()), @"[^a-zA-Z0-9_]", "");
            string nomeArquivo = $"TERMO_{nomeFormatado}_NaoAssinado.pdf";
            string tempFile = Path.Combine(Path.GetTempPath(), nomeArquivo);

            // Exportação também em background
            await Task.Run(() => TermoRESP1.ExportToDisk(ExportFormatType.PortableDocFormat, tempFile));

            string destinoFTP = $"{Globais.Main.PassarIdAluno}/contratos/{Globais.Main.PassarAno}/";

            // Faz upload em segundo plano
            await Task.Run(async () =>
            {
                CriarPastaFTP(Globais.Main.PassarIdAluno);
                await UploadContratoFTP(tempFile, destinoFTP, "Termo");
            });

            // Limpeza do arquivo temporário
            if (File.Exists(tempFile))
                File.Delete(tempFile);
        }

        private async Task UploadContratoFTP(string arquivoLocal, string destinoFTP, string tipo)
        {
            string nomeArquivo = Path.GetFileName(arquivoLocal);

            if (!destinoFTP.EndsWith("/"))
                destinoFTP += "/";

            string caminhoRemoto = ConexaoFTP.ftpUrl + destinoFTP + Uri.EscapeDataString(nomeArquivo);

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(caminhoRemoto);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(ConexaoFTP.ftpUser, ConexaoFTP.ftpPassword);

                byte[] fileContents = File.ReadAllBytes(arquivoLocal);
                request.ContentLength = fileContents.Length;

                using (Stream requestStream = await request.GetRequestStreamAsync())
                {
                    await requestStream.WriteAsync(fileContents, 0, fileContents.Length);
                }

                using (FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync())
                {
                    // Upload bem sucedido
                }
            }
            catch (Exception ex)
            {
                // Usar Invoke para interagir com a UI da thread principal
                if (this.InvokeRequired)
                {
                    var resultObj = this.Invoke(new Func<DialogResult>(() =>
                        MessageBox.Show($"Erro ao salvar TERMO DE RESPONSABILIDADE: {ex.Message}\n\nTentar Novamente?",
                                        "Mensagem do Sistema",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Error)
                    ));

                    // Cast seguro para DialogResult
                    if (resultObj is DialogResult result && result == DialogResult.Yes)
                    {
                        await UploadContratoFTP(arquivoLocal, destinoFTP, tipo);
                    }
                }
                else
                {
                    if (MessageBox.Show($"Erro ao salvar TERMO DE RESPONSABILIDADE: {ex.Message}\n\nTentar Novamente?",
                                        "Mensagem do Sistema",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        await UploadContratoFTP(arquivoLocal, destinoFTP, tipo);
                    }
                }
            }
        }

        private void CriarPastaFTP(string idSelecionado)
        {
            string pastaAluno = idSelecionado;
            string[] subPastas = { "", "documentos", "contratos", $"contratos/{Globais.Main.PassarAno}" };

            foreach (string sub in subPastas)
            {
                string caminhoFTP = string.IsNullOrEmpty(sub) ? pastaAluno : $"{pastaAluno}/{sub}";

                if (!PastaExisteFTP(caminhoFTP))
                {
                    FtpWebRequest criarPasta = Banco.ConexaoFTP.CriarConexao(caminhoFTP, WebRequestMethods.Ftp.MakeDirectory);
                    using (var resp = (FtpWebResponse)criarPasta.GetResponse())
                    {
                        // Garantir que a resposta seja descartada
                    }
                }
            }

            AtualizarBancoFTP(pastaAluno);
        }

        private void AtualizarBancoFTP(string pastaAluno)
        {
            string vqueryVerifica = $"SELECT COUNT(*) FROM tb_caminhoftp WHERE idaluno={pastaAluno}";
            DataTable dt = Banco.dql(vqueryVerifica);

            int count = Convert.ToInt32(dt.Rows[0][0]);

            if (count == 0)
            {
                string insertQuery = $@"
            INSERT INTO tb_caminhoftp (idaluno, data_gerada, usuario)
            VALUES ({pastaAluno}, '{DateTime.Today:yyyy-MM-dd}', '{Globais.Main.PassarUsuario}')";
                Banco.dml(insertQuery);
            }
        }

        private bool PastaExisteFTP(string caminhoFTP)
        {
            try
            {
                FtpWebRequest request = Banco.ConexaoFTP.CriarConexao(caminhoFTP, WebRequestMethods.Ftp.ListDirectory);
                using (var response = (FtpWebResponse)request.GetResponse())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}