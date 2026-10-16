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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using static Escolar.Banco;

namespace Escolar
{
    public partial class F_ContratoNormal : Form
    {
        public F_ContratoNormal()
        {
            InitializeComponent();
        }

        private async void F_ContratoNormal_Load(object sender, EventArgs e)
        {

            using (F_Loading loading = new F_Loading("Gerando contrato..."))
            {
                loading.Owner = this;
                loading.Show();
                loading.BringToFront();
                loading.Refresh();

                try
                {
                    await CarregarDadosContratoAsync();

                    crystalReportViewer1.ReportSource = ContratoNormal1;

                    await Task.Run(async () => await ExportarEnviarContratoAsync());

                    loading.Close();

                    MessageBox.Show("Contrato enviado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    loading.Close();
                    MessageBox.Show($"Erro ao criar contrato: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task CarregarDadosContratoAsync()
        {
            await Task.Run(() =>
            {
                // Executa as consultas no banco em thread separada
                CarregarDadosContrato();
            });
        }

        private void CarregarDadosContrato()
        {
            //======================================================================
            string dia = DateTime.Now.ToString("dd");
            string mes = DateTime.Now.ToString("MMMM");
            string ano = DateTime.Now.ToString("yyyy");

            string data = dia + " de " + mes + " de " + ano;
            //Data e Ano
            ContratoNormal1.SetParameterValue("data", data);
            ContratoNormal1.SetParameterValue("ano", Globais.Main.PassarAno);

            //Nome Aluno / Responsável Financeiro
            var vcon = Banco.ConexaoBanco();
            string Aluno = String.Format(@"
            SELECT nome_aluno,turno 
            FROM tb_alunos 
            WHERE ID_aluno ={0}", Globais.Main.PassarIdAluno);

            DataTable aluno = Banco.dql(Aluno);
            vcon.Close();

            Nome_aluno = aluno.Rows[0].Field<string>("nome_aluno");
            string turno = aluno.Rows[0].Field<string>("turno");

            string Etapa = String.Format(@"
            SELECT tbe.nome_etapa,n_parcelas,parcelas_pagas,valor_parcela,valor_total, idresponsavel
            FROM tb_etapas as tbe
            INNER JOIN tb_mensalidades as tbm
            ON tbm.idturma = tbe.ID_etapa 
            WHERE tbm.ID_mensalidade = {0}", Globais.Main.PassarID_Mensalidade);

            DataTable etapa = Banco.dql(Etapa);

            string serie = etapa.Rows[0].Field<string>("nome_etapa");
            int n_parcelas = etapa.Rows[0].Field<Int32>("n_parcelas");
            decimal valor_parcela = etapa.Rows[0].Field<Decimal>("valor_parcela");
            int idresponsavel = etapa.Rows[0].Field<Int32>("idresponsavel");
            decimal valor_anual = 0;

            for (int i = 0; i < n_parcelas; i++)
            {
                valor_anual += etapa.Rows[0].Field<Decimal>("valor_parcela");
            }

            ContratoNormal1.SetParameterValue("nome_aluno", Nome_aluno.ToUpper());
            ContratoNormal1.SetParameterValue("turno", turno.ToUpper());
            ContratoNormal1.SetParameterValue("etapa", serie.ToUpper());

            ContratoNormal1.SetParameterValue("n_parcelas", n_parcelas);
            ContratoNormal1.SetParameterValue("valor_parcela", valor_parcela.ToString("C"));
            ContratoNormal1.SetParameterValue("extenso", Conversor.EscreverExtensoNum(n_parcelas));

            ContratoNormal1.SetParameterValue("valor_anual", valor_anual.ToString("C"));

            vcon = Banco.ConexaoBanco();
            string RespFinan = String.Format(@"
            SELECT nome,parentesco,cpf,rg,rua,bairro,numero,orgao_emissor 
            FROM tb_responsavel_financeiro 
            WHERE ID_responsavel_financeiro = {0}", idresponsavel);

            DataTable financeiro = Banco.dql(RespFinan);
            vcon.Close();

            string NomeResp = financeiro.Rows[0].Field<string>("nome");
            string cpf = financeiro.Rows[0].Field<string>("cpf");
            string rg = financeiro.Rows[0].Field<string>("rg");
            string rua = financeiro.Rows[0].Field<string>("rua");
            string bairro = financeiro.Rows[0].Field<string>("bairro");
            string numero = financeiro.Rows[0].Field<string>("numero");
            string orgao_emissor = financeiro.Rows[0].Field<string>("orgao_emissor");

            ContratoNormal1.SetParameterValue("nome", NomeResp.ToUpper());
            ContratoNormal1.SetParameterValue("cpf", cpf);
            ContratoNormal1.SetParameterValue("rg", rg);
            ContratoNormal1.SetParameterValue("orgao_expedidor", orgao_emissor);
            ContratoNormal1.SetParameterValue("endereco", rua + " Nº " + numero + " - " + bairro);
        }

        string Nome_aluno = "";

        private async Task ExportarEnviarContratoAsync()
        {
            // Exporta contrato para PDF temporário

            string nomeFormatado = Regex.Replace(new string(Nome_aluno.Replace(" ", "_").Normalize(NormalizationForm.FormD).Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray()), @"[^a-zA-Z0-9_]", "");
            string nomeArquivoContrato = $"Contrato_NORMAL_{nomeFormatado}_NaoAssinado.pdf";
            string tempFileContrato = Path.Combine(Path.GetTempPath(), nomeArquivoContrato);

            await Task.Run(() => ContratoNormal1.ExportToDisk(ExportFormatType.PortableDocFormat, tempFileContrato));

            // Cria arquivo temporário para o regulamento interno
            string nomeArquivoRegulamento = "REGULAMENTO_INTERNO.pdf";
            string tempFileRegulamento = Path.Combine(Path.GetTempPath(), nomeArquivoRegulamento);

            // Extrai o regulamento interno como recurso
            await ExtrairRegulamentoInterno(tempFileRegulamento);

            string destinoFTP = $"{Globais.Main.PassarIdAluno}/contratos/{Globais.Main.PassarAno}/";

            // Faz upload de ambos os arquivos
            await Task.Run(() =>
            {
                CriarPastaFTP(Globais.Main.PassarIdAluno);
                UploadContratoFTP(tempFileContrato, destinoFTP, "Contrato");
                UploadContratoFTP(tempFileRegulamento, destinoFTP, "Regulamento Interno");
            });

            // Limpeza dos arquivos temporários
            if (File.Exists(tempFileContrato))
                File.Delete(tempFileContrato);
            if (File.Exists(tempFileRegulamento))
                File.Delete(tempFileRegulamento);
        }

        // Método específico para extrair o regulamento interno
        private async Task ExtrairRegulamentoInterno(string caminhoDestino)
        {
            try
            {
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();

                // Tenta os nomes mais comuns (ajuste conforme o diagnóstico)
                string[] possiveisNomes = {
            "Escolar.REGULAMENTO_INTERNO.pdf",
            "Escolar.REGULAMENTO_INTERNO",
            "YourProjectName.REGULAMENTO_INTERNO.pdf",
            "REGULAMENTO_INTERNO.pdf",
            "REGULAMENTO_INTERNO"
        };

                string nomeRecursoEncontrado = null;

                // Procura qual nome existe realmente
                foreach (string nome in possiveisNomes)
                {
                    if (assembly.GetManifestResourceStream(nome) != null)
                    {
                        nomeRecursoEncontrado = nome;
                        break;
                    }
                }

                if (nomeRecursoEncontrado == null)
                {
                    // Lista todos os recursos disponíveis para debug
                    string[] todosRecursos = assembly.GetManifestResourceNames();
                    string recursosDisponiveis = string.Join("\n", todosRecursos);

                    MessageBox.Show($"Regulamento interno não encontrado!\nRecursos disponíveis:\n{recursosDisponiveis}",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (Stream stream = assembly.GetManifestResourceStream(nomeRecursoEncontrado))
                {
                    using (FileStream fileStream = new FileStream(caminhoDestino, FileMode.Create))
                    {
                        await stream.CopyToAsync(fileStream);
                    }
                }

                // Verifica se o arquivo foi criado com sucesso
                if (File.Exists(caminhoDestino))
                {
                    FileInfo info = new FileInfo(caminhoDestino);
                    if (info.Length == 0)
                    {
                        MessageBox.Show("Arquivo do regulamento interno está vazio!", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao extrair regulamento interno: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void UploadContratoFTP(string arquivoLocal, string destinoFTP, string tipo)
        {
            // (Mantido igual ao seu código original)
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

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileContents, 0, fileContents.Length);
                }

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    // Upload bem sucedido
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar CONTRATO:  " + ex.Message, "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CriarPastaFTP(string idSelecionado)
        {
            // (Mantido igual ao seu código original)
            string pastaAluno = idSelecionado;
            string[] subPastas = { "", "documentos", "contratos", $"contratos/{Globais.Main.PassarAno}" };
            bool algumaCriada = false;

            foreach (string sub in subPastas)
            {
                string caminhoFTP = string.IsNullOrEmpty(sub) ? pastaAluno : $"{pastaAluno}/{sub}";

                if (!PastaExisteFTP(caminhoFTP))
                {
                    FtpWebRequest criarPasta = Banco.ConexaoFTP.CriarConexao(caminhoFTP, WebRequestMethods.Ftp.MakeDirectory);
                    using (var resp = (FtpWebResponse)criarPasta.GetResponse()) { }
                    algumaCriada = true;
                }
            }

            AtualizarBancoFTP(pastaAluno);
        }

        private void AtualizarBancoFTP(string pastaAluno)
        {
            // (Mantido igual ao seu código original)
            string vqueryVerifica = $"SELECT COUNT(*) FROM tb_caminhoftp WHERE idaluno={pastaAluno}";
            DataTable dt = Banco.dql(vqueryVerifica);

            int count = Convert.ToInt32(dt.Rows[0][0]);

            if (count > 0)
            {
                return;
            }
            else
            {
                string insertQuery = $@"
            INSERT INTO tb_caminhoftp (idaluno, data_gerada, usuario)
            VALUES ({pastaAluno}, '{DateTime.Today:yyyy-MM-dd}', '{Globais.Main.PassarUsuario}')";
                Banco.dml(insertQuery);
            }
        }

        private bool PastaExisteFTP(string caminhoFTP)
        {
            // (Mantido igual ao seu código original)
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