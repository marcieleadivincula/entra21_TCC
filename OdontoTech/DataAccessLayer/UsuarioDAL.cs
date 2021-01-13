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
    class UsuarioDAL
    {
        public void Inserir(Usuario usuario)
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
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    throw new Exception("Usuario já cadastrado.");
                }
                else
                {
                    throw new Exception("Erro no Banco de dados. Contate o administrador.");
                }
            }
            finally
            {
                conn.Dispose();
            }
        }
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
        public string Atualizar(Usuario usuario)
        {

            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE usuario SET login = @login, SET senha = @senha, SET idColaborador = @idColaborador WHERE idUsuario = @idUsuario";
            cmd.Parameters.AddWithValue("@idUsuario", usuario.Id);
            cmd.Parameters.AddWithValue("@login", usuario.Login);
            cmd.Parameters.AddWithValue("@senha", usuario.Senha);
            cmd.Parameters.AddWithValue("@idColaborador", usuario.Colaborador.Id);

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
    }
}
