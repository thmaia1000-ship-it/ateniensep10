using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Escolar.Banco;

namespace Escolar
{
    public partial class F_FichaIndividual : Form
    {
        public F_FichaIndividual()
        {
            InitializeComponent();
        }

        private async void F_FichaIndividual_Load(object sender, EventArgs e)
        {
            using (F_Loading loading = new F_Loading("Carregando ficha individual..."))
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
                    crystalReportViewer1.ReportSource = GestaoAluno1;

                    // Exporta e envia para FTP em background
                    await Task.Run(async () => await ExportarEnviarFichaAsync());

                    loading.Close();

                    MessageBox.Show("Ficha individual enviada com sucesso!", "Sucesso",
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
            SELECT tba.nome_aluno,tba.datanasc,tba.turno,tba.sexo,tba.cor,tba.cidade,tba.UF,tba.nacionalidade,tba.rua,tba.bairro,tba.cep,tba.numero,tba.telefone,tba.mae,tba.pai,tba.responsavel1,tba.responsavel2,tba.vive_com,tba.doenca,tba.emergencia,tba.zona,tba.etapa,tbc.nome_curso
            FROM tb_alunos as tba, tb_cursos as tbc 
            WHERE tba.idcurso = tbc.ID_curso 
            AND tba.ID_aluno =" + Globais.Main.PassarIdAluno);

            DataTable aluno = Banco.dql(Aluno);

            string Nome_aluno = aluno.Rows[0].Field<string>("nome_aluno");
            string sexo = aluno.Rows[0].Field<string>("sexo");
            string cor = aluno.Rows[0].Field<string>("cor");
            string cidade = aluno.Rows[0].Field<string>("cidade");
            string UF = aluno.Rows[0].Field<string>("UF");
            string nacionalidade_aluno = aluno.Rows[0].Field<string>("nacionalidade");
            string datanasc_aluno = aluno.Rows[0].Field<DateTime>("datanasc").ToString("dd/MM/yyyy");

            string contrato = aluno.Rows[0].Field<string>("turno");
            string etapa = aluno.Rows[0].Field<string>("etapa");
            string nome_curso = aluno.Rows[0].Field<string>("nome_curso");

            string bairro_aluno = aluno.Rows[0].Field<string>("bairro");
            string cep_aluno = aluno.Rows[0].Field<string>("cep");
            string rua_aluno = aluno.Rows[0].Field<string>("rua");
            string numero_casa_aluno = aluno.Rows[0].Field<string>("numero");
            string telefone_casa_aluno = aluno.Rows[0].Field<string>("telefone");
            string mae = aluno.Rows[0].Field<string>("mae");
            string pai = aluno.Rows[0].Field<string>("pai");
            string responsavel1 = aluno.Rows[0].Field<string>("responsavel1");
            string responsavel2 = aluno.Rows[0].Field<string>("responsavel2");
            string zona = aluno.Rows[0].Field<string>("zona");

            string vive_com = aluno.Rows[0].Field<string>("vive_com");
            string doenca = aluno.Rows[0].Field<string>("doenca");
            string emergencia = aluno.Rows[0].Field<string>("emergencia");

            // Define os parâmetros do aluno
            GestaoAluno1.SetParameterValue("nome_aluno", Nome_aluno.ToUpper());
            GestaoAluno1.SetParameterValue("data_nasc_aluno", datanasc_aluno);
            GestaoAluno1.SetParameterValue("sexo", sexo.ToUpper());
            GestaoAluno1.SetParameterValue("cor", cor.ToUpper());
            GestaoAluno1.SetParameterValue("cidade", cidade.ToUpper());
            GestaoAluno1.SetParameterValue("uf", UF.ToUpper());
            GestaoAluno1.SetParameterValue("nacionalidade", nacionalidade_aluno.ToUpper());
            GestaoAluno1.SetParameterValue("rua_aluno", rua_aluno.ToUpper());
            GestaoAluno1.SetParameterValue("bairro_aluno", bairro_aluno.ToUpper());
            GestaoAluno1.SetParameterValue("cep_aluno", cep_aluno.ToUpper());
            GestaoAluno1.SetParameterValue("zona_aluno", zona.ToUpper());
            GestaoAluno1.SetParameterValue("telefone_endereco_aluno", telefone_casa_aluno.ToUpper());
            GestaoAluno1.SetParameterValue("numero_casa_aluno", numero_casa_aluno.ToUpper());
            GestaoAluno1.SetParameterValue("mae", mae.ToUpper());
            GestaoAluno1.SetParameterValue("pai", pai.ToUpper());
            GestaoAluno1.SetParameterValue("outro_responsavel1", responsavel1.ToUpper());
            GestaoAluno1.SetParameterValue("outro_responsavel2", responsavel2.ToUpper());
            GestaoAluno1.SetParameterValue("vive_com", vive_com.ToUpper());
            GestaoAluno1.SetParameterValue("doenca", doenca.ToUpper());
            GestaoAluno1.SetParameterValue("emergencia", emergencia.ToUpper());
            GestaoAluno1.SetParameterValue("contrato", contrato.ToUpper());
            GestaoAluno1.SetParameterValue("etapa", etapa.ToUpper());
            GestaoAluno1.SetParameterValue("curso", nome_curso.ToUpper());

            // Dados do responsável financeiro
            string RespFinan = String.Format(@"
            SELECT nome,parentesco,cpf,rg,data_emissao,datanasc,nacionalidade,estado_civil,profissao,grau_instrucao,rua,bairro,numero,cep,email,telefone 
            FROM tb_responsavel_financeiro 
            WHERE idaluno =" + Globais.Main.PassarIdAluno);

            DataTable financeiro = Banco.dql(RespFinan);

            string NomeResp = financeiro.Rows[0].Field<string>("nome");
            string parentesco = financeiro.Rows[0].Field<string>("parentesco");
            string cpf = financeiro.Rows[0].Field<string>("cpf");
            string rg = financeiro.Rows[0].Field<string>("rg");
            string data_emissao = financeiro.Rows[0].Field<DateTime>("data_emissao").ToString("dd/MM/yyyy");
            string datanasc = financeiro.Rows[0].Field<DateTime>("datanasc").ToString("dd/MM/yyyy");
            string nacionalidade = financeiro.Rows[0].Field<string>("nacionalidade");
            string estado_civil = financeiro.Rows[0].Field<string>("estado_civil");
            string profissao = financeiro.Rows[0].Field<string>("profissao");
            string grau_instrucao = financeiro.Rows[0].Field<string>("grau_instrucao");
            string rua = financeiro.Rows[0].Field<string>("rua");
            string bairro = financeiro.Rows[0].Field<string>("bairro");
            string numero = financeiro.Rows[0].Field<string>("numero");
            string cep = financeiro.Rows[0].Field<string>("cep");
            string email = financeiro.Rows[0].Field<string>("email");
            string telefone = financeiro.Rows[0].Field<string>("telefone");

            // Define os parâmetros do responsável
            GestaoAluno1.SetParameterValue("nome_responsavel_acad", NomeResp.ToUpper());
            GestaoAluno1.SetParameterValue("parentesco", parentesco);
            GestaoAluno1.SetParameterValue("cpf", cpf);
            GestaoAluno1.SetParameterValue("rg", rg);
            GestaoAluno1.SetParameterValue("data_emissao", data_emissao);
            GestaoAluno1.SetParameterValue("data_nasc_responsavel_acad", datanasc);
            GestaoAluno1.SetParameterValue("nacionalidade_responsavel_acad", nacionalidade);
            GestaoAluno1.SetParameterValue("estado_civil", estado_civil);
            GestaoAluno1.SetParameterValue("profissao", profissao);
            GestaoAluno1.SetParameterValue("grau_instrucao", grau_instrucao);
            GestaoAluno1.SetParameterValue("rua_responsavel_acad", rua);
            GestaoAluno1.SetParameterValue("numero_responsavel_acad", numero);
            GestaoAluno1.SetParameterValue("bairro_responsavel_acad", bairro);
            GestaoAluno1.SetParameterValue("cep_responsavel_acad", cep);
            GestaoAluno1.SetParameterValue("telefone_responsavel_acad", telefone);
            GestaoAluno1.SetParameterValue("email", email);

            // Data e Ano
            GestaoAluno1.SetParameterValue("data", data);
            GestaoAluno1.SetParameterValue("ano_letivo", Globais.Main.PassarAno);
        }

        private async Task ExportarEnviarFichaAsync()
        {
            // Exporta para PDF temporário
            string nomeArquivo = "FichaIndividual_NaoAssinado.pdf";
            string tempFile = Path.Combine(Path.GetTempPath(), nomeArquivo);

            // Exportação também em background
            await Task.Run(() => GestaoAluno1.ExportToDisk(ExportFormatType.PortableDocFormat, tempFile));

            string destinoFTP = $"{Globais.Main.PassarIdAluno}/contratos/{Globais.Main.PassarAno}/";

            // Faz upload em segundo plano
            await Task.Run(() =>
            {
                CriarPastaFTP(Globais.Main.PassarIdAluno);
                UploadContratoFTP(tempFile, destinoFTP, "Ficha Individual");
            });

            // Limpeza do arquivo temporário
            if (File.Exists(tempFile))
                File.Delete(tempFile);
        }

        private void UploadContratoFTP(string arquivoLocal, string destinoFTP, string tipo)
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
                MessageBox.Show("Erro ao salvar FICHA INDIVIDUAL:  " + ex.Message, "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    using (var resp = (FtpWebResponse)criarPasta.GetResponse()) { }
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