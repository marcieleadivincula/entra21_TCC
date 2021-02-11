using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data.SqlClient;
using Domain;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
    public class UsuarioDAL
    {
        MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
        MySqlCommand cmd = new MySqlCommand();

        /// <summary>
        /// Insere o  Usuario no BD. Caso houver erro a função informa.
        /// </summary>
        /// <param name="usuario"></param>
        public string Inserir(Usuario usuario)
        {
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO usuario (login, senha, idColaborador) values (@login, @senha, @idColaborador)";
            cmd.Parameters.AddWithValue("@login", usuario.Login);
            cmd.Parameters.AddWithValue("@senha", usuario.Senha);
            cmd.Parameters.AddWithValue("@idColaborador", usuario.Colaborador.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Usuário cadastrado com sucesso";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    return ("Usuário já cadastrado.");
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
            if (usuario.Id == 0)
            {
                return "Usuário informado inválido!";
            }

            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM usuario WHERE idUsuario = @idUsuario";
            cmd.Parameters.AddWithValue("@idUsuario", usuario.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Usuário deletado com êxito!";
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

            cmd.Connection = conn;
            cmd.CommandText = "UPDATE usuario SET login = @login,  senha = @senha, idColaborador = @idColaborador WHERE idUsuario = @idUsuario";
            cmd.Parameters.AddWithValue("@login", usuario.Login);
            cmd.Parameters.AddWithValue("@senha", usuario.Senha);
            cmd.Parameters.AddWithValue("@idColaborador", usuario.Colaborador.Id);
            cmd.Parameters.AddWithValue("@idUsuario", usuario.Id);


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Usuário atualizado com êxito!";
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
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM usuario";
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Usuario> usuarios = new List<Usuario>();

                while (reader.Read())
                {
                    Usuario temp = new Usuario();
                    temp.Id = Convert.ToInt32(reader["idUsuario"]);
                    temp.Login = Convert.ToString(reader["login"]);
                    temp.Senha = Convert.ToString(reader["senha"]);
                    temp.Colaborador.Id = Convert.ToInt32(reader["idColaborador"]);

                    usuarios.Add(temp);
                }

                return usuarios;
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
            using (MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING))
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT idUsuario FROM usuario where login = @login AND senha = @senha";
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        usuarioId = Convert.ToInt32(reader["idUsuario"]);
                    }
                }
            }

            return usuarioId != null;
        }

        public bool VerificaLogin(string login, string senha)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT idUsuario FROM usuario where login = @login AND senha = @senha";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public Usuario GetByID(int idUsuario)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM usuario WHERE idUsuario = @idUsuario";
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Usuario usuario = new Usuario();

                while (reader.Read())
                {
                    usuario.Colaborador = new Colaborador();

                    usuario.Id = Convert.ToInt32(reader["idUsuario"]);
                    usuario.Login = Convert.ToString(reader["login"]);
                    usuario.Senha = Convert.ToString(reader["senha"]);
                    usuario.Colaborador.Id = Convert.ToInt32(reader["idColaborador"]);
                }

                return usuario;
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
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM usuario ORDER BY idUsuario DESC limit 1";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Usuario usuario = new Usuario();

                while (reader.Read())
                {
                    usuario.Colaborador = new Colaborador();

                    usuario.Id = Convert.ToInt32(reader["idUsuario"]);
                    usuario.Login = Convert.ToString(reader["login"]);
                    usuario.Senha = Convert.ToString(reader["senha"]);
                    usuario.Colaborador.Id = Convert.ToInt32(reader["idColaborador"]);
                }

                return usuario;
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
        public List<Usuario> GetByColaborador(Colaborador colaborador)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM usuario WHERE idColaborador = @idColaborador";
            cmd.Parameters.AddWithValue("@idColaborador", colaborador.Id);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Usuario> usuarios = new List<Usuario>();

                while (reader.Read())
                {
                    Usuario temp = new Usuario();
                    temp.Colaborador = new Colaborador();

                    temp.Id = Convert.ToInt32(reader["idUsuario"]);
                    temp.Login = Convert.ToString(reader["login"]);
                    temp.Senha = Convert.ToString(reader["senha"]);
                    temp.Colaborador.Id = Convert.ToInt32(reader["idColaborador"]);

                    usuarios.Add(temp);
                }

                return usuarios;
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

        public Usuario Autenticar(string login, string password)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT idUsuario FROM usuario where login = @login AND senha = @senha";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", password);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Usuario usuario = new Usuario();

                while (reader.Read())
                {
                    usuario.Colaborador = new Colaborador();

                    usuario.Id = Convert.ToInt32(reader["idUsuario"]);
                    usuario.Login = Convert.ToString(reader["login"]);
                    usuario.Senha = Convert.ToString(reader["senha"]);
                    usuario.Colaborador.Id = Convert.ToInt32(reader["idColaborador"]);
                }

                return usuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Erro no Banco de dados. Contate o administrador.");
            }
            finally
            {
                conn.Dispose();
            }
        }
        public Usuario GetInfosByEmail(string email)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM usuario where login = @login";
            cmd.Parameters.AddWithValue("@login", email);
           

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Usuario usuario = new Usuario();

                while (reader.Read())
                {
                    usuario.Colaborador = new Colaborador();
                    usuario.Id = Convert.ToInt32(reader["idUsuario"]);
                    usuario.Login = Convert.ToString(reader["login"]);
                    usuario.Senha = Convert.ToString(reader["senha"]);
                    usuario.Colaborador.Id = Convert.ToInt32(reader["idColaborador"]);
                }

                return usuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Erro no Banco de dados. Contate o administrador.");
            }
            finally
            {
                conn.Dispose();
            }
        }
    }

}
