using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Escolar.Banco;

namespace Escolar.Cadastros
{
    public partial class CadastrarImagem : Form
    {
        public CadastrarImagem()
        {
            InitializeComponent();
        }

        private VideoCaptureDevice videoSource;
        private FilterInfoCollection videoDevices;

        // ========================== UPLOAD DA IMAGEM ==========================
        public async Task UploadImageToFTP(string filePath)
        {
            using (F_Loading loading = new F_Loading("Enviando imagem..."))
            {
                loading.Owner = this;
                loading.Show();
                loading.BringToFront();
                loading.Refresh();

                try
                {
                    string nomeAluno = Globais.Main.PassarAluno;
                    if (string.IsNullOrWhiteSpace(nomeAluno))
                    {
                        MessageBox.Show("Selecione um Aluno", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Nome do arquivo sempre baseado no nome do aluno
                    string nomeArquivo = $"{nomeAluno.Replace(" ", "_")}.jpg";
                    string caminhoRelativoFTP = $"{Globais.Main.PassarIdAluno}/{nomeArquivo}";

                    // Envia o arquivo para o FTP em background
                    await Task.Run(() =>
                    {
                        FtpWebRequest request = ConexaoFTP.CriarConexao(caminhoRelativoFTP, WebRequestMethods.Ftp.UploadFile);
                        byte[] fileContents = File.ReadAllBytes(filePath);
                        request.ContentLength = fileContents.Length;

                        using (Stream requestStream = request.GetRequestStream())
                        {
                            requestStream.Write(fileContents, 0, fileContents.Length);
                        }

                        using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                        {
                            // Upload bem sucedido
                        }
                    });

                    loading.Close();
                    MessageBox.Show("Imagem enviada com sucesso!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Carrega a imagem com loading também
                    await CarregarImagemNoPictureBox(caminhoRelativoFTP, foto_aluno);
                }
                catch (Exception ex)
                {
                    loading.Close();
                    MessageBox.Show($"Erro ao enviar imagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ========================== CARREGAR IMAGEM ==========================
        public async Task CarregarImagemNoPictureBox(string caminhoRelativoFTP, PictureBox pictureBox)
        {
            using (F_Loading loading = new F_Loading("Carregando imagem..."))
            {
                loading.Owner = this;
                loading.Show();
                loading.BringToFront();
                loading.Refresh();

                try
                {
                    if (string.IsNullOrEmpty(caminhoRelativoFTP))
                    {
                        LimparPictureBox(pictureBox);
                        return;
                    }

                    await Task.Run(() =>
                    {
                        FtpWebRequest request = ConexaoFTP.CriarConexao(caminhoRelativoFTP, WebRequestMethods.Ftp.DownloadFile);
                        request.UsePassive = true;
                        request.KeepAlive = false;
                        request.Timeout = 15000; // 15 segundos de timeout

                        using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                        using (Stream responseStream = response.GetResponseStream())
                        using (MemoryStream ms = new MemoryStream())
                        {
                            responseStream.CopyTo(ms);
                            ms.Position = 0;

                            var img = System.Drawing.Image.FromStream(ms);

                            pictureBox.Invoke(new Action(() =>
                            {
                                pictureBox.Image = img;
                                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                            }));
                        }
                    });

                    loading.Close();
                }
                catch (WebException ex) when (ex.Response is FtpWebResponse ftpResponse &&
                                             ftpResponse.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    loading.Close();
                    // ERRO 550 - Comportamento normal, não mostra erro
                    LimparPictureBox(pictureBox);
                }
                catch (Exception ex)
                {
                    loading.Close();
                    LimparPictureBox(pictureBox);

                    // Mostra erro apenas se for algo inesperado
                    if (!ex.Message.Contains("550"))
                    {
                        MessageBox.Show($"Erro ao carregar imagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LimparPictureBox(PictureBox pictureBox)
        {
            if (pictureBox.InvokeRequired)
            {
                pictureBox.Invoke(new Action(() => LimparPictureBox(pictureBox)));
                return;
            }

            pictureBox.Image = null;
        }

        // ========================== EVENTOS DA CÂMERA ==========================
        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Exibe o frame atual no PictureBox
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
            foto_aluno.Image = frame;
        }

        private async void btn_capturar_Click(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                try
                {
                    // Salva a imagem capturada no disco
                    string nomeAluno = Globais.Main.PassarAluno;
                    if (string.IsNullOrWhiteSpace(nomeAluno))
                    {
                        MessageBox.Show("Selecione um aluno!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string fileName = $"{nomeAluno.Replace(" ", "_")}.jpg";
                    string filePath = Path.Combine(Path.GetTempPath(), fileName);

                    foto_aluno.Image.Save(filePath, ImageFormat.Jpeg);

                    await UploadImageToFTP(filePath);

                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao capturar a foto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Para a câmera após capturar
                    if (videoSource != null && videoSource.IsRunning)
                    {
                        videoSource.SignalToStop();
                        videoSource = null;
                    }
                    Close();
                }
            }
            else
            {
                MessageBox.Show("A câmera não está ativa!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CadastrarImagem_Load(object sender, EventArgs e)
        {
            try
            {
                // Lista os dispositivos de vídeo disponíveis
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                {
                    MessageBox.Show("Nenhuma câmera encontrada no sistema. Verifique se uma câmera está conectada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btn_capturar.Enabled = false;
                    return;
                }

                // Preenche o ComboBox com as câmeras
                foreach (FilterInfo device in videoDevices)
                {
                    camera.Items.Add(device.Name);
                }
                camera.SelectedIndex = 0;

                btn_capturar.Enabled = true;

                // Inicia a primeira câmera
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += VideoSource_NewFrame;
                videoSource.Start();

                foto_aluno.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir a câmera: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void camera_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                // Para a câmera atual antes de trocar
                if (videoSource != null && videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource.WaitForStop();
                }

                int index = camera.SelectedIndex;

                // Inicia a nova câmera
                videoSource = new VideoCaptureDevice(videoDevices[index].MonikerString);
                videoSource.NewFrame += VideoSource_NewFrame;
                videoSource.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao trocar de câmera: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CadastrarImagem_FormClosing(object sender, FormClosingEventArgs e)
        {
            PararCamera();
        }

        private void CadastrarImagem_FormClosed(object sender, FormClosedEventArgs e)
        {
            PararCamera();
        }

        private void PararCamera()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
                videoSource = null;
            }
        }
    }
}