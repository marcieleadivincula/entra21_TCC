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

        public string Inserir(Logradouro logradouro)
        {
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO logradouro (nomeLogradouro,idBairro) values (@nomeLogradouro,@idBairro)";

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
        public string Deletar(Logradouro logradouro)
        {
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
        public string Atualizar(Logradouro logradouro)
        {

            cmd.Connection = conn;
            cmd.CommandText = "UPDATE logradouro SET nomeLogradouro = @nomeLogradouro WHERE idLogradouro = @idLogradouro";

            cmd.Parameters.AddWithValue("@idLogradouro", logradouro.Id);
            cmd.Parameters.AddWithValue("@idBairro", logradouro.Bairro.Id);
            cmd.Parameters.AddWithValue("@nomeLogradouro", logradouro.Nome);

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

        public List<Logradouro> SelecionaTodos()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM logradouro";
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Logradouro> Logradouros = new List<Logradouro>();
                while (reader.Read())
                {
                    Logradouro temp = new Logradouro();

                    temp.Id = Convert.ToInt32(reader["idLogradouro"]);
                    temp.Nome = Convert.ToString(reader["nomeLogradouro"]);
                    temp.Bairro.Id = Convert.ToInt32(reader["idBairro"]);
                
                    

                    Logradouros.Add(temp);
                }
                return Logradouros;
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
        public Logradouro GetByID(int id)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM logradouro WHERE idLogradouro = @ID";
            cmd.Parameters.AddWithValue("@ID", id);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Logradouro temp = new Logradouro();

                while (reader.Read())
                {

                    temp.Id = Convert.ToInt32(reader["idLogradouro"]);
                    temp.Nome = Convert.ToString(reader["nomeLogradouro"]);
                    temp.Bairro.Id = Convert.ToInt32(reader["idBairro"]);

                }
                return temp;
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
                Logradouro Logradouro = new Logradouro();

                while (reader.Read())
                {
                    Logradouro temp = new Logradouro();

                    temp.Id = Convert.ToInt32(reader["idLogradouro"]);
                    temp.Nome = Convert.ToString(reader["nomeLogradouro"]);
                    temp.Bairro.Id = Convert.ToInt32(reader["idBairro"]);

                    Logradouro = temp;
                }

                return Logradouro;
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
