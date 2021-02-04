using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data.SqlClient;
using Domain;

namespace DataAccessLayer
{
    public class UsuarioDAL
    {
        /// <summary>
        /// Insere o  Usuario no BD. Caso houver erro a função informa.
        /// </summary>
        /// <param name="usuario"></param>
        public string Inserir(Usuario usuario)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO usuario (login,senha,idColaborador) values (@login,@senha,@idColaborador)";

            cmd.Parameters.AddWithValue("@login", usuario.Login);
            cmd.Parameters.AddWithValue("@senha", usuario.Senha );
            cmd.Parameters.AddWithValue("@idColaborador", usuario.Colaborador.Id );

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Usuario cadastrado com sucesso";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    return ("Usuario já cadastrado.");
                }
                else
                {
                    return ("Erro no Banco de dados. Contate o administrador.");
                }
            }
            finally
            {
                conn.Dispose();
            }
        }
        /// <summary>
        /// Tenta deletar, caso der certo retorna (Usuario deletado com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public string Deletar(Usuario usuario)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM usuario WHERE idUsuario = @ID";
            cmd.Parameters.AddWithValue("@ID", usuario.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Tipo Usuario deletado com êxito!";
            }
            catch (Exception)
            {
                return "Erro no Banco de dados.Contate o administrador.";
            }
            finally
            {
                conn.Dispose();
            }
        }
        /// <summary>
        /// Tenta atualizar, caso der certo retorna (Usuario atualizado com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public string Atualizar(Usuario usuario)
        {

            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE usuario SET login = @login,  senha = @senha WHERE idUsuario = @idUsuario";
            cmd.Parameters.AddWithValue("@idUsuario", usuario.Id);
            cmd.Parameters.AddWithValue("@login", usuario.Login);
            cmd.Parameters.AddWithValue("@senha", usuario.Senha);


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Usuario atualizado com êxito!";
            }
            catch (Exception)
            {
                return "Erro no Banco de dados.Contate o administrador.";
            }
            finally
            {
                conn.Dispose();
            }

        }
        /// <summary>
        /// Retorna Lista Com Todos os usuarios do BD.
        /// </summary>
        /// <returns></returns>
        public List<Usuario> SelecionaTodos()
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM usuario";
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Usuario> Usuarios = new List<Usuario>();
                while (reader.Read())
                {
                    Usuario temp = new Usuario();

                    temp.Id = Convert.ToInt32(reader["idUsuario"]);
                    temp.Login = Convert.ToString(reader["login"]);
                    temp.Senha = Convert.ToString(reader["senha"]);
                    temp.Colaborador.Id = Convert.ToInt32(reader["idColaborador"]);

                    Usuarios.Add(temp);
                }
                return Usuarios;
            }
            catch (Exception)
            {
                throw new Exception("Erro no Banco de dados.Contate o administrador.");
            }
            finally
            {
                conn.Dispose();
            }
        }

        public bool EhFuncionarioCadastrado(string login, string senha)
        {
            long? usuarioId = null;
            using (SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = "SELECT idUsuario FROM usuario where login = @login AND senha = @senha";
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@senha", senha);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        usuarioId = Convert.ToInt32(reader["idUsuario"]);
                    }
                }
            }
                
            return usuarioId != null;
        }
        public Usuario GetByID(int id)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM usuario WHERE idUsuario = @ID";
            cmd.Parameters.AddWithValue("@ID", id);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Usuario temp = new Usuario();

                while (reader.Read())
                {
                    temp.Id = Convert.ToInt32(reader["idUsuario"]);
                    temp.Login = Convert.ToString(reader["login"]);
                    temp.Senha = Convert.ToString(reader["senha"]);
                    temp.Colaborador.Id = Convert.ToInt32(reader["idColaborador"]);
                }
                return temp;
            }
            catch (Exception)
            {
                throw new Exception("Erro no Banco de dados.Contate o administrador.");
            }
            finally
            {
                conn.Dispose();
            }
        }
        public Usuario GetLastRegister()
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM usuario ORDER BY idUsuario DESC limit 1";

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                Usuario Usuario = new Usuario();

                while (reader.Read())
                {
                    Usuario temp = new Usuario();

                    temp.Id = Convert.ToInt32(reader["idUsuario"]);
                    temp.Login = Convert.ToString(reader["login"]);
                    temp.Senha = Convert.ToString(reader["senha"]);
                    temp.Colaborador.Id = Convert.ToInt32(reader["idColaborador"]);

                    Usuario = temp;
                }

                return Usuario;
            }
            catch (Exception)
            {
                throw new Exception("Erro no Banco de dados.Contate o administrador.");
            }
            finally
            {
                conn.Dispose();
            }
        }
    }
}
