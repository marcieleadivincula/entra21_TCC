using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Domain;

namespace DataAccessLayer
{
    public class CidadeDAL
    {
        MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
        MySqlCommand cmd = new MySqlCommand();
        public string Insert(Cidade cidade)
        {
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO cidade (nomeCidade,idEstado) values (@nomeCidade,@idEstado)";
            cmd.Parameters.AddWithValue("@nomeCidade", cidade.Nome);
            cmd.Parameters.AddWithValue("@idEstado", cidade.Estado.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Cidade cadastrada com sucesso";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    return ("Cidade já cadastrada.");
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
        public string Delete(Cidade cidade)
        {
            if (cidade.Id == 0)
            {
                return "Cidade informada inválido!";
            }

            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM cidade WHERE idCidade = @ID";
            cmd.Parameters.AddWithValue("@ID", cidade.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Cidade deletada com êxito!";
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
        public string Update(Cidade cidade)
        {
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE cidade SET nomeCidade = @nomeCidade, idEstado = @idEstado WHERE idCidade = @idCidade";
            cmd.Parameters.AddWithValue("@nomeCidade", cidade.Nome);
            cmd.Parameters.AddWithValue("@idEstado", cidade.Estado.Id);
            cmd.Parameters.AddWithValue("@idCidade", cidade.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Cidade atualizada com êxito!";
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
        public List<Cidade> GetAll()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM cidade";
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Cidade> cidades = new List<Cidade>();

                while (reader.Read())
                {
                    Cidade temp = new Cidade();

                    temp.Estado = new Estado();

                    temp.Id = Convert.ToInt32(reader["idCidade"]);
                    temp.Nome = Convert.ToString(reader["nomeCidade"]);
                    temp.Estado.Id = Convert.ToInt32(reader["idEstado"]);

                    cidades.Add(temp);
                }
                return cidades;
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
        public Cidade GetById(int idCidade)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM cidade WHERE idCidade = @ID";
            cmd.Parameters.AddWithValue("@ID", idCidade);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Cidade cidade = new Cidade();

                while (reader.Read())
                {
                    cidade.Estado = new Estado();

                    cidade.Id = Convert.ToInt32(reader["idCidade"]);
                    cidade.Nome = Convert.ToString(reader["nomeCidade"]);
                    cidade.Estado.Id = Convert.ToInt32(reader["idEstado"]);
                }
                return cidade;
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
        public Cidade GetLastRegister()
        {
            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM cidade ORDER BY idCidade DESC limit 1";

            try
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                Cidade cidade = new Cidade();

                while (reader.Read())
                {

                    cidade.Estado = new Estado();

                    cidade.Id = Convert.ToInt32(reader["idCidade"]);
                    cidade.Nome = Convert.ToString(reader["nomeCidade"]);
                    cidade.Estado.Id = Convert.ToInt32(reader["idEstado"]);
                }
                return cidade;
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
        public List<Cidade> GetByEstado(Estado estado)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM cidade WHERE idEstado = @idEstado";
            cmd.Parameters.AddWithValue("@ID", estado.Id);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Cidade> cidades = new List<Cidade>();

                while (reader.Read())
                {
                    Cidade temp = new Cidade();

                    temp.Estado = new Estado();

                    temp.Id = Convert.ToInt32(reader["idCidade"]);
                    temp.Nome = Convert.ToString(reader["nomeCidade"]);
                    temp.Estado.Id = Convert.ToInt32(reader["idEstado"]);

                    cidades.Add(temp);
                }

                return cidades;
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
