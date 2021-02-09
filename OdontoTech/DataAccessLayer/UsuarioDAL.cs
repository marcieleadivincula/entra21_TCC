﻿using System;
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
            cmd.CommandText = "INSERT INTO usuario (login,senha,idColaborador) values (@login,@senha,@idColaborador)";

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
            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM usuario WHERE idUsuario = @ID";
            cmd.Parameters.AddWithValue("@ID", usuario.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Tipo Usuário deletado com êxito!";
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
            cmd.CommandText = "UPDATE usuario SET login = @login,  senha = @senha WHERE idUsuario = @idUsuario";
            cmd.Parameters.AddWithValue("@idUsuario", usuario.Id);
            cmd.Parameters.AddWithValue("@login", usuario.Login);
            cmd.Parameters.AddWithValue("@senha", usuario.Senha);


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

        public Usuario GetByID(int id)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM usuario WHERE idUsuario = @ID";
            cmd.Parameters.AddWithValue("@ID", id);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
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
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM usuario ORDER BY idUsuario DESC limit 1";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
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
