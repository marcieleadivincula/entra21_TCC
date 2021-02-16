using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Domain;

namespace DataAccessLayer
{
    public class EnderecoDAL
    {
        MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
        MySqlCommand cmd = new MySqlCommand();

        /// <summary>
        /// Insere o Endereço no BD. Caso houver erro a função informa.
        /// </summary>
        /// <param name="endereco"></param>
        public string Insert(Endereco endereco)
        {
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO endereco (idLogradouro, numeroCasa, cep) values (@idLogradouro, @numeroCasa, @cep)";
            cmd.Parameters.AddWithValue("@idLogradouro", endereco.Logradouro.Id);
            cmd.Parameters.AddWithValue("@numeroCasa", endereco.NumeroCasa);
            cmd.Parameters.AddWithValue("@cep", endereco.Cep);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Endereço cadastrado com sucesso";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    return ("Endereço já cadastrado.");
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

        /// <summary>
        /// Tenta deletar, caso der certo retorna (Endereço deletado com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns></returns>
        public string Delete(Endereco endereco)
        {
            if (endereco.Id == 0)
            {
                return "Endereçoo informada inválido!";
            }

            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM endereco WHERE idEndereco = @idEndereco";
            cmd.Parameters.AddWithValue("@idEndereco", endereco.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Endereço deletado com êxito!";
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
        /// Tenta atualizar, caso der certo retorna (Endereço atualizado com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns></returns>
        public string Update(Endereco endereco)
        {
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE endereco  SET idLogradouro = @idLogradouro, numeroCasa = @numeroCasa,  cep = @cep WHERE idEndereco = @idEndereco";
            cmd.Parameters.AddWithValue("@idLogradouro", endereco.Logradouro.Id);
            cmd.Parameters.AddWithValue("@numeroCasa", endereco.NumeroCasa);
            cmd.Parameters.AddWithValue("@cep", endereco.Cep);
            cmd.Parameters.AddWithValue("@idEndereco", endereco.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Endereço atualizado com êxito!";
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
        /// Retorna Lista com todos os Enderecos.
        /// </summary>
        /// <returns></returns>
        public List<Endereco> GetAll()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM endereco";
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Endereco> enderecos = new List<Endereco>();

                while (reader.Read())
                {
                    Endereco temp = new Endereco();

                    temp.Logradouro = new Logradouro();

                    temp.Id = Convert.ToInt32(reader["idEndereco"]);
                    temp.Logradouro.Id = Convert.ToInt32(reader["idLogradouro"]);
                    temp.NumeroCasa = Convert.ToInt32(reader["numeroCasa"]);
                    temp.Cep = Convert.ToString(reader["cep"]);

                    enderecos.Add(temp);
                }

                return enderecos;
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
        public Endereco GetById(int idEndereco)
        {
            cmd.Connection = conn;
            cmd.CommandText = $"SELECT * FROM endereco WHERE idEndereco = {idEndereco}";
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Endereco endereco = new Endereco();

                while (reader.Read())
                {
                    endereco.Logradouro = new Logradouro();
                    endereco.Id = Convert.ToInt32(reader["idEndereco"]);
                    endereco.Logradouro.Id = Convert.ToInt32(reader["idLogradouro"]);
                    endereco.NumeroCasa = Convert.ToInt32(reader["numeroCasa"]);
                    endereco.Cep = Convert.ToString(reader["cep"]);
                }

                return endereco;
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
        public Endereco GetLastRegister()
        {
            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM endereco ORDER BY idEndereco DESC limit 1";

            try
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                Endereco endereco = new Endereco();

                while (reader.Read())
                {
                    endereco.Logradouro = new Logradouro();
                    endereco.Id = Convert.ToInt32(reader["idEndereco"]);
                    endereco.Logradouro.Id = Convert.ToInt32(reader["idLogradouro"]);
                    endereco.NumeroCasa = Convert.ToInt32(reader["numeroCasa"]);
                    endereco.Cep = Convert.ToString(reader["cep"]);
                }

                return endereco;
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

        public List<Endereco> GetByLogradouro(Logradouro logradouro)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM endereco WHERE idLogradouro = @idLogradouro";
            cmd.Parameters.AddWithValue("@idLogradouro", logradouro.Id);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Endereco> enderecos = new List<Endereco>();

                while (reader.Read())
                {
                    Endereco temp = new Endereco();
                    temp.Logradouro = new Logradouro();
                    temp.Id = Convert.ToInt32(reader["idEndereco"]);
                    temp.Logradouro.Id = Convert.ToInt32(reader["idLogradouro"]);
                    temp.NumeroCasa = Convert.ToInt32(reader["numeroCasa"]);
                    temp.Cep = Convert.ToString(reader["cep"]);

                    enderecos.Add(temp);
                }

                return enderecos;
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