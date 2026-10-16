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

namespace Escolar
{
    internal class Banco
    {

        //public static MySqlConnection conexao;

        public static MySqlConnection ConexaoBanco()

        {
            MySqlConnection conexao = new MySqlConnection();
            conexao.ConnectionString = "server=localhost; database=sistema_escolar; user id=maia; password=123; port=3306;";
            conexao.Open();

            return conexao;
            
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

        public static DataTable dql(string sql)//DataQueryLanguage
        {
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                
                    cmd.CommandText = sql;
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

        public static void dml(string q,string msgOK=null, string msgERRO=null)//DataManipulationLanguage (Insert, Delete, Update)
        
        {
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();

                cmd.CommandText = q;
                da = new MySqlDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                vcon.Close();
                if (msgOK != null)
                {
                    MessageBox.Show(msgOK);
                }
            }
            catch (Exception ex)
            {
                if(msgERRO != null)
                {
                    MessageBox.Show(msgERRO + "\n" + ex.Message);
                }
                throw ex;

            }
        }




        ////////////////////FUNÇÕES DO FORM f_GestãoUsuarios

        public static DataTable ObterUsuariosIdNome()

        {
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();

                cmd.CommandText = "SELECT ID_usuario as 'ID Usuário', nome_usuario as 'Nome Usuário' FROM tb_usuarios";
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

        public static DataTable ObterDadosUsuario(string id)

        {
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();

                cmd.CommandText = "SELECT * FROM tb_usuarios WHERE ID_usuario=" + id;
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

        public static void AtualizarUsuario(Usuario u)

        {
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();

                cmd.CommandText = "UPDATE tb_usuarios SET nome_usuario='"+u.nome+"',username='" + u.username + "',sebga='" + u.senha + "',status='" + u.status + "',nivel_usuario= "+u.nivel+ " WHERE ID_usuario=" + u.id;
                da = new MySqlDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                vcon.Close();
             

            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public static void DeletarUsuario(string id)

        {
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();

                cmd.CommandText = "DELETE FROM tb_usuarios WHERE ID_usuario= " + id;
                da = new MySqlDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                vcon.Close();

             
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }


        ////////////////////FIM FUNÇÕES FORM f_GestãoUsuarios

        ////////////////////FUNÇÕES DO FORM f_novoUsuario

        public static void NovoUsuario(Usuario u)
        {

            if (exiteUsername (u))
            {
                MessageBox.Show("Username já existe");
                return;
            }
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "INSERT INTO tb_usuarios (nome_usuario, username, senha, status, nivel_usuario) VALUES (@nome, @username, @senha, @status, @nivel)";
                cmd.Parameters.AddWithValue("@nome", u.nome);
                cmd.Parameters.AddWithValue("@username", u.username);
                cmd.Parameters.AddWithValue("@senha", u.senha);
                cmd.Parameters.AddWithValue("@status", u.status);
                cmd.Parameters.AddWithValue("@nivel", u.nivel);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Novo Usuário inserido com Sucesso!");
                vcon.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir Novo Usuário");
                
            }

        }



        //////////////////// FIM FUNÇÕES FORM

        //////////////////// ROTINAS GERAIS
       
        public static bool exiteUsername(Usuario u)
        {

            bool res;
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();

            var vcon = ConexaoBanco();
            var cmd = vcon.CreateCommand();
            cmd.CommandText = "SELECT username FROM tb_usuarios WHERE username='" + u.username+"'";
            da = new MySqlDataAdapter(cmd.CommandText, vcon);
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                res = true;
            }
            else
            {
               res = false;
            }

            vcon.Close();
            return res;
        }

        
    }
}
