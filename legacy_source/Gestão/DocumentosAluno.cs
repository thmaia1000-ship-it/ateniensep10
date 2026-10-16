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

namespace Escolar.Gestão
{
    public partial class DocumentosAluno : Form
    {
        public DocumentosAluno()
        {
            InitializeComponent();
        }

        private string idAluno;
        private string caminhoAtual;
        private string caminhoDocumento;

        private string FormatFileSize(long bytes)
        {
            if (bytes < 1024)
                return $"{bytes} B";
            else if (bytes < 1024 * 1024)
                return $"{bytes / 1024.0:N0} KB";
            else if (bytes < 1024L * 1024L * 1024L)
                return $"{bytes / 1024.0 / 1024.0:N2} MB";
            else
                return $"{bytes / 1024.0 / 1024.0 / 1024.0:N2} GB";
        }

        private DataTable ListarFTP(string caminho, bool listarPastas)
        {
            System.Net.FtpWebRequest request = ConexaoFTP.CriarConexao(caminho, WebRequestMethods.Ftp.ListDirectoryDetails);
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                DataTable tabela = new DataTable();
                tabela.Columns.Add("Nome");
                tabela.Columns.Add("Data");
                tabela.Columns.Add("Tamanho");
                tabela.Columns.Add("Tipo");

                string linha;
                while ((linha = reader.ReadLine()) != null)
                {
                    string[] partes = linha.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (partes.Length < 9) continue;

                    bool isDir = linha.StartsWith("d"); // 'd' no início indica diretório
                    string nome = string.Join(" ", partes.Skip(8));

                    if (listarPastas && isDir)
                    {
                        tabela.Rows.Add(nome, "-", "-", "Pasta");
                    }
                    else if (!listarPastas && !isDir)
                    {
                        string tamanho = partes[4];
                        long tamanhoBytes = long.TryParse(tamanho, out long tb) ? tb : 0;

                        string dataStr = $"{partes[5]} {partes[6]} {partes[7]}";
                        DateTime dataArquivo;
                        if (!DateTime.TryParseExact(
                                dataStr,
                                new[] { "MMM dd HH:mm", "MMM dd yyyy" },
                                System.Globalization.CultureInfo.InvariantCulture,
                                System.Globalization.DateTimeStyles.None,
                                out dataArquivo))
                            dataArquivo = DateTime.MinValue;

                        if (!dataStr.Contains(DateTime.Now.Year.ToString()) && dataStr.Contains(":"))
                        {
                            dataArquivo = new DateTime(
                                DateTime.Now.Year,
                                dataArquivo.Month,
                                dataArquivo.Day,
                                dataArquivo.Hour,
                                dataArquivo.Minute,
                                0
                            );
                        }

                        tabela.Rows.Add(nome, dataArquivo.ToString("dd/MM/yyyy HH:mm"), FormatFileSize(tamanhoBytes), "Arquivo");

                    }
                }

                return tabela;
            }

        }

        private void AjustarColunas()
        {
            AjustarColunasDataGrid(dgvContratos);
            AjustarColunasDataGrid(dgvDocumentos);
        }

        private void AjustarColunasDataGrid(DataGridView dgv)
        {
            if (dgv.Columns.Contains("Nome"))
                dgv.Columns["Nome"].Width = 239;

            if (dgv.Columns.Contains("Data"))
                dgv.Columns["Data"].Width = 100;

            if (dgv.Columns.Contains("Tamanho"))
                dgv.Columns["Tamanho"].Width = 70;

            if (dgv.Columns.Contains("Tipo"))
                dgv.Columns["Tipo"].Width = 50;

            // Adiciona coluna de lixeira apenas se não existir
            if (!dgv.Columns.Contains("Excluir"))
            {
                DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn
                {
                    Name = "Excluir",
                    HeaderText = "Excluir",
                    Width = 50,
                    Text = "",
                    UseColumnTextForButtonValue = false
                };
                dgv.Columns.Add(btnCol);
            }

            // Garante que a coluna de lixeira fique sempre por último
            dgv.Columns["Excluir"].DisplayIndex = dgv.Columns.Count - 1;

            dgv.ClearSelection();
        }


        private void CarregarAnosContratos()
        {
            string caminho = $"{idAluno}/contratos/";
            caminhoAtual = caminho;
            dgvContratos.DataSource = ListarFTP(caminho, true);
            AjustarColunas();
        }

        private void CarregarArquivosDocumentos()
        {
            string caminho = $"{idAluno}/documentos/";
            DataTable arquivos = ListarFTP($"{idAluno}/documentos/", false);
            caminhoDocumento = caminho;
            dgvDocumentos.DataSource = arquivos;
            AjustarColunas(); // aqui também
        }

        private void SalvarArquivoFTP(string nomeArquivo, string caminho)
        {
            try
            {
                // Pega a extensão do arquivo
                string extensao = Path.GetExtension(nomeArquivo); // ex: ".jpg", ".pdf"
                if (string.IsNullOrEmpty(extensao))
                    extensao = ""; // caso não tenha extensão

                SaveFileDialog saveFile = new SaveFileDialog
                {
                    FileName = Path.GetFileNameWithoutExtension(nomeArquivo), // só o nome
                    Filter = $"Arquivos (*{extensao})|*{extensao}|Todos os Arquivos (*.*)|*.*"
                };

                if (saveFile.ShowDialog() != DialogResult.OK)
                    return;

                // Garante que a extensão correta seja adicionada
                string caminhoDestino = saveFile.FileName;
                if (Path.GetExtension(caminhoDestino).ToLower() != extensao.ToLower())
                {
                    caminhoDestino += extensao;
                }

                string urlArquivo = ConexaoFTP.ftpUrl + "/" + caminho + nomeArquivo;

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(urlArquivo);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(ConexaoFTP.ftpUser, ConexaoFTP.ftpPassword);

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (Stream responseStream = response.GetResponseStream())
                using (FileStream fs = new FileStream(caminhoDestino, FileMode.Create))
                {
                    responseStream.CopyTo(fs);
                }

                MessageBox.Show("Download concluído com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro no download: {ex.Message}");
            }
        }


        private void voltarButton_Click(object sender, EventArgs e)
        {
            if (caminhoAtual.EndsWith("contratos/")) return;
            CarregarAnosContratos();

            lbAno.Text = "Contratos";
        }

        private void contratosADDButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lbAno.Text))
            {
                MessageBox.Show("Selecione primeiro a pasta de um ano.");
                return;
            }
            UploadArquivo(caminhoAtual, "Contrato");
        }

        private void DocumentosADDButton_Click(object sender, EventArgs e)
        {
            UploadArquivo(caminhoDocumento, "Documento");
        }

        private void DocumentosAluno_Load(object sender, EventArgs e)
        {
            idAluno = Globais.Main.PassarIdAluno;

            CarregarAnosContratos();
            CarregarArquivosDocumentos();
        }

        private void dgvContratos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;


            string nome = dgvContratos.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
            string tipo = dgvContratos.Rows[e.RowIndex].Cells["Tipo"].Value.ToString();

            if (tipo == "Pasta")
            {
                caminhoAtual = $"{caminhoAtual}{nome}/";
                dgvContratos.DataSource = ListarFTP(caminhoAtual, false); // entra e lista arquivos
                AjustarColunas();
                lbAno.Text = $"Contratos {nome}";
            }
            else if (tipo == "Arquivo")
            {
                SalvarArquivoFTP(nome, caminhoAtual);
            }
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nome = dgvDocumentos.Rows[e.RowIndex].Cells["Nome"].Value.ToString();

            SalvarArquivoFTP(nome, caminhoDocumento);
        }

        private void dgvContratos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dgvContratos.Columns["Excluir"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);

                // Só desenhar lixeira para arquivos
                string tipo = dgvContratos.Rows[e.RowIndex].Cells["Tipo"].Value.ToString();
                if (tipo == "Arquivo")
                {
                    Image img = Properties.Resources.lata_de_lixo;
                    int x = e.CellBounds.Left + (e.CellBounds.Width - img.Width) / 2;
                    int y = e.CellBounds.Top + (e.CellBounds.Height - img.Height) / 2;
                    e.Graphics.DrawImage(img, new Rectangle(x, y, img.Width, img.Height));
                }

                e.Handled = true;
            }
        }
        private void dgvContratos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvContratos.Columns["Excluir"].Index && e.RowIndex >= 0)
            {
                string tipo = dgvContratos.Rows[e.RowIndex].Cells["Tipo"].Value.ToString();
                if (tipo != "Arquivo") return;

                string nomeArquivo = dgvContratos.Rows[e.RowIndex].Cells["Nome"].Value.ToString();

                DialogResult dr = MessageBox.Show($"Deseja realmente excluir o arquivo '{nomeArquivo}'?",
                    "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    ExcluirArquivoFTP(nomeArquivo, caminhoAtual);

                    // Atualiza a lista
                    dgvContratos.DataSource = ListarFTP(caminhoAtual, false);
                    AjustarColunas();
                }
            }
        }
        private void dgvDocumentos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dgvDocumentos.Columns["Excluir"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);

                // Só desenhar lixeira para arquivos
                string tipo = dgvDocumentos.Rows[e.RowIndex].Cells["Tipo"].Value.ToString();
                if (tipo == "Arquivo")
                {
                    Image img = Properties.Resources.lata_de_lixo;
                    int x = e.CellBounds.Left + (e.CellBounds.Width - img.Width) / 2;
                    int y = e.CellBounds.Top + (e.CellBounds.Height - img.Height) / 2;
                    e.Graphics.DrawImage(img, new Rectangle(x, y, img.Width, img.Height));
                }

                e.Handled = true;
            }
        }

        private void dgvDocumentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDocumentos.Columns[e.ColumnIndex].Name == "Excluir")
            {
                string tipo = dgvDocumentos.Rows[e.RowIndex].Cells["Tipo"].Value.ToString();
                if (tipo != "Arquivo") return;

                string nomeArquivo = dgvDocumentos.Rows[e.RowIndex].Cells["Nome"].Value.ToString();

                DialogResult dr = MessageBox.Show($"Deseja realmente excluir o arquivo '{nomeArquivo}'?",
                    "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    ExcluirArquivoFTP(nomeArquivo, caminhoDocumento);

                    // Atualiza a lista correta
                    dgvDocumentos.DataSource = ListarFTP(caminhoDocumento, false);
                    AjustarColunas();
                }
            }
        }

        private void ExcluirArquivoFTP(string nomeArquivo, string caminho)
        {
            try
            {
                string urlArquivo = ConexaoFTP.ftpUrl + "/" + caminho + nomeArquivo;

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(urlArquivo);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = new NetworkCredential(ConexaoFTP.ftpUser, ConexaoFTP.ftpPassword);

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    MessageBox.Show($"Arquivo '{nomeArquivo}' excluído com sucesso!",
                        "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UploadArquivo(string destinoFTP, string tipo)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Selecione um arquivo para enviar";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string arquivoLocal = ofd.FileName;
                    string nomeArquivo = Path.GetFileName(arquivoLocal);

                    // Garante barra no final do destino
                    if (!destinoFTP.EndsWith("/"))
                        destinoFTP += "/";

                    // Monta caminho remoto corretamente e escapa caracteres especiais
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
                            MessageBox.Show($"{tipo} enviado com sucesso!");
                        }

                        // Atualiza o DataGridView após upload
                        if (destinoFTP.ToLower().Contains("contratos"))
                            dgvContratos.DataSource = ListarFTP(destinoFTP, false);
                        else
                            dgvDocumentos.DataSource = ListarFTP(destinoFTP, false);

                        AjustarColunas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao enviar arquivo: " + ex.Message);
                    }
                }
            }
        }
    }
}
