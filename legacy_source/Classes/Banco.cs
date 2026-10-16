using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Net;
using System.Threading;

namespace Escolar
{
    internal class Banco
    {

        //public static MySqlConnection conexao;

        public static MySqlConnection ConexaoBanco()

        {
            MySqlConnection conexao = new MySqlConnection();
            conexao.ConnectionString = "server=179.188.16.41; database=dbateniense; user id=dbateniense; password=w!@6QCWStbLyqv; port=3306;";
            //conexao.ConnectionString = "server=localhost; database=dbateniense; user id=root; password=; port=3306;";
            return conexao;
            
        }

        public static class ConexaoFTP
        {
            public static string ftpUrl = "ftp://ftp.agenciabr3.com.br/public_html/Ateniense/P10/alunos/";
            public static string ftpUser = "agenciabr31";
            public static string ftpPassword = "1010@Agenciabr";

            /// <summary>
            /// Cria uma conexão FTP robusta com tratamento específico para erros 550 e timeouts
            /// </summary>
            public static FtpWebRequest CriarConexao(string fileName, string metodoFtp, int tentativas = 3)
            {
                string ftpFullUrl = $"{ftpUrl}{fileName}";
                Exception ultimoErro = null;

                for (int i = 0; i < tentativas; i++)
                {
                    try
                    {
                        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpFullUrl);
                        request.Method = metodoFtp;
                        request.Credentials = new NetworkCredential(ftpUser, ftpPassword);
                        request.UseBinary = true;
                        request.UsePassive = true;   // modo passivo evita bloqueios de firewall
                        request.KeepAlive = false;   // encerra a conexão após cada operação
                        request.EnableSsl = false;   // desative se não usar FTPS

                        // Configurações de timeout mais robustas
                        request.Timeout = 30000;     // 30 segundos para conexão
                        request.ReadWriteTimeout = 45000; // 45 segundos para operações de leitura/escrita

                        // Para operações de download/upload, definir ContentLength pode ajudar
                        if (metodoFtp == WebRequestMethods.Ftp.UploadFile)
                        {
                            request.ContentLength = 0; // Será ajustado posteriormente
                        }

                        return request;
                    }
                    catch (WebException ex)
                    {
                        ultimoErro = ex;

                        // Log do erro para debug
                        Console.WriteLine($"Tentativa {i + 1} falhou: {ex.Status} - {ex.Message}");

                        // Tratamento específico para erro 550 (arquivo não encontrado/sem acesso)
                        if (ex.Response is FtpWebResponse ftpResponse)
                        {
                            if (ftpResponse.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                            {
                                // Não adianta tentar novamente para erro de arquivo não encontrado
                                throw new Exception($"Arquivo não encontrado ou sem permissão de acesso: {fileName}", ex);
                            }
                        }

                        // Tratamento específico para timeout
                        if (ex.Status == WebExceptionStatus.Timeout)
                        {
                            if (i < tentativas - 1)
                            {
                                // Espera progressivamente mais a cada tentativa
                                int delay = (i + 1) * 5000; // 5s, 10s, 15s...
                                Console.WriteLine($"Timeout detectado. Aguardando {delay}ms antes da próxima tentativa...");
                                Thread.Sleep(delay);
                                continue;
                            }
                        }

                        // Para outros erros, espera antes de tentar novamente
                        if (i < tentativas - 1)
                        {
                            int delay = 10000; // 10 segundos
                            Console.WriteLine($"Aguardando {delay}ms antes da próxima tentativa...");
                            Thread.Sleep(delay);
                        }
                    }
                    catch (Exception ex)
                    {
                        ultimoErro = ex;
                        if (i < tentativas - 1)
                        {
                            Thread.Sleep(10000);
                        }
                    }
                }

                throw new Exception($"Falha ao conectar ao FTP após {tentativas} tentativas. Último erro: {ultimoErro?.Message}", ultimoErro);
            }
        }

        public static DataTable ObterTodosUsuarios()

        {
           MySqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
               
                    cmd.CommandText = "SELECT * FROM tb_usuarios";
                    da = new MySqlDataAdapter(cmd.CommandText, vcon);
                    da.Fill(dt);
                    vcon.Close();
                    return dt;
                    
            }
            catch(Exception ex)
            {

                throw ex;

            }
        }
        public static DataTable log(string acao, string tabela_afetada, int id_registro, string detalhes,string data_hora)//Inserie na log
        {
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();

                cmd.CommandText = $@"INSERT INTO 
                        log_sistema(usuario, acao, tabela_afetada, id_registro, detalhes, data_hora)
                    VALUES('{Globais.Main.PassarUsuario}', '{acao}', '{tabela_afetada}',{ id_registro},'{detalhes}','{data_hora}')";
                da = new MySqlDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public static DataTable dql(string sql)
        {
            DataTable dt = new DataTable();

            try
            {
                using (var vcon = ConexaoBanco()) // conexão é fechada automaticamente
                {
                    vcon.Open();
                    using (var cmd = new MySqlCommand(sql, vcon))
                    {
                        using (var da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar consulta DQL: " + ex.Message, ex);
            }
        }


        public static void dml(string q, string msgOK = null, string msgERRO = null)
        {
            try
            {
                using (var vcon = ConexaoBanco())
                {
                    vcon.Open();
                    using (var cmd = new MySqlCommand(q, vcon))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                if (!string.IsNullOrEmpty(msgOK))
                    MessageBox.Show(msgOK);
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(msgERRO))
                    MessageBox.Show(msgERRO + "\n" + ex.Message);

                throw new Exception("Erro ao executar DML: " + ex.Message, ex);
            }
        }



        ////////////////////FIM FUNÇÕES FORM f_GestãoUsuarios

        ////////////////////FUNÇÕES DO FORM f_novoUsuario

        public static void NovoUsuario(Usuario u)
        {
            if (exiteUsername(u))
            {
                MessageBox.Show("Username já existe", "Mensagem do sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var vcon = ConexaoBanco())
                {
                    vcon.Open();

                    var cmd = new MySqlCommand(
                        "INSERT INTO tb_usuarios (nome_usuario, username, senha, nivel_usuario) " +
                        "VALUES (@nome, @username, @senha, @nivel)",
                        vcon
                    );

                    cmd.Parameters.AddWithValue("@nome", u.nome);
                    cmd.Parameters.AddWithValue("@username", u.username);
                    cmd.Parameters.AddWithValue("@senha", u.senha);
                    cmd.Parameters.AddWithValue("@nivel", u.nivel);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Novo Usuário inserido com Sucesso!",
                    "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir Novo Usuário:\n\n" + ex.Message,
                    "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //////////////////// FIM FUNÇÕES FORM

        //////////////////// ROTINAS GERAIS

        public static bool exiteUsername(Usuario u)
        {
            using (var vcon = ConexaoBanco())
            {
                vcon.Open();

                var cmd = new MySqlCommand(
                    "SELECT COUNT(*) FROM tb_usuarios WHERE username = @username",
                    vcon
                );
                cmd.Parameters.AddWithValue("@username", u.username);

                int qtd = Convert.ToInt32(cmd.ExecuteScalar());
                return qtd > 0;
            }
        }

    }
}
