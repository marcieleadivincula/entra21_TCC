using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Domain;

namespace DataAccessLayer
{
    public class LogradouroDAL
    {

        MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
        MySqlCommand cmd = new MySqlCommand();
        public string Insert(Logradouro logradouro)
        {
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO logradouro (nomeLogradouro,idBairro) values (@nomeLogradouro, @idBairro)";
            cmd.Parameters.AddWithValue("@nomeLogradouro", logradouro.Nome);
            cmd.Parameters.AddWithValue("@idBairro", logradouro.Bairro.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Logradouro cadastrado com sucesso";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    return ("Logradouro já cadastrado.");
                }
                else
                {
                    Console.WriteLine(ex);
                    return ("Erro no Banco de dados. Contate o administrador.");
                }
            }
            finally
            {
                conn.Dispose();
            }

        }
        public string Delete(Logradouro logradouro)
        {
            if (logradouro.Id == 0)
            {
                return "Logradouro informada inválido!";
            }

            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM logradouro WHERE idLogradouro = @ID";
            cmd.Parameters.AddWithValue("@ID", logradouro.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Logradouro deletado com êxito!";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "Erro no Banco de dados. Contate o administrador.";
            }
            finally
            {
                conn.Dispose();
            }
        }
        public string Update(Logradouro logradouro)
        {
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE logradouro SET nomeLogradouro = @nomeLogradouro, idBairro = @idBairro WHERE idLogradouro = @idLogradouro";
            cmd.Parameters.AddWithValue("@nomeLogradouro", logradouro.Nome);
            cmd.Parameters.AddWithValue("@idBairro", logradouro.Bairro.Id);
            cmd.Parameters.AddWithValue("@idLogradouro", logradouro.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Logradouro atualizado com êxito!";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "Erro no Banco de dados. Contate o administrador.";
            }
            finally
            {
                conn.Dispose();
            }

        }

        public List<Logradouro> GetAll()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM logradouro";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Logradouro> logradouros = new List<Logradouro>();

                while (reader.Read())
                {
                    Logradouro temp = new Logradouro();

                    temp.Bairro = new Bairro();
                    temp.Id = Convert.ToInt32(reader["idLogradouro"]);
                    temp.Nome = Convert.ToString(reader["nomeLogradouro"]);
                    temp.Bairro.Id = Convert.ToInt32(reader["idBairro"]);

                    logradouros.Add(temp);
                }

                return logradouros;
            }
            catch (Exception)
            {
                throw new Exception("Erro no Banco de dados. Contate o administrador.");
            }
            finally
            {
                conn.Dispose();
            }
        }
        public Logradouro GetByID(int idLogradouro)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM logradouro WHERE idLogradouro = @ID";
            cmd.Parameters.AddWithValue("@ID", idLogradouro);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Logradouro logradouro = new Logradouro();

                while (reader.Read())
                {
                    logradouro.Bairro = new Bairro();
                    logradouro.Id = Convert.ToInt32(reader["idLogradouro"]);
                    logradouro.Nome = Convert.ToString(reader["nomeLogradouro"]);
                    logradouro.Bairro.Id = Convert.ToInt32(reader["idBairro"]);
                }

                return logradouro;
            }
            catch (Exception)
            {
                throw new Exception("Erro no Banco de dados. Contate o administrador.");
            }
            finally
            {
                conn.Dispose();
            }
        }
        public Logradouro GetLastRegister()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM logradouro ORDER BY idLogradouro DESC limit 1";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Logradouro logradouro = new Logradouro();

                while (reader.Read())
                {
                    logradouro.Bairro = new Bairro();
                    logradouro.Id = Convert.ToInt32(reader["idLogradouro"]);
                    logradouro.Nome = Convert.ToString(reader["nomeLogradouro"]);
                    logradouro.Bairro.Id = Convert.ToInt32(reader["idBairro"]);
                }

                return logradouro;
            }
            catch (Exception)
            {
                throw new Exception("Erro no Banco de dados. Contate o administrador.");
            }
            finally
            {
                conn.Dispose();
            }
        }

        public List<Logradouro> GetByBairro(Bairro bairro)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM logradouro WHERE idBairro = @idBairro";
            cmd.Parameters.AddWithValue("@idBairro", bairro.Id);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Logradouro> logradouros = new List<Logradouro>();

                while (reader.Read())
                {
                    Logradouro temp = new Logradouro();
                    temp.Bairro = new Bairro();
                    temp.Id = Convert.ToInt32(reader["idLogradouro"]);
                    temp.Nome = Convert.ToString(reader["nomeLogradouro"]);
                    temp.Bairro.Id = Convert.ToInt32(reader["idBairro"]);

                    logradouros.Add(temp);
                }

                return logradouros;
            }
            catch (Exception)
            {
                throw new Exception("Erro no Banco de dados. Contate o administrador.");
            }
            finally
            {
                conn.Dispose();
            }
        }
    }
}
