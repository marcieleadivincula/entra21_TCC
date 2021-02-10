using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Domain;

namespace DataAccessLayer
{
    public class BairroDAL
    {
        MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
        MySqlCommand cmd = new MySqlCommand();
        public string Insert(Bairro bairro)
        {
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO bairro(nomeBairro, idCidade) values(@nomeBairro, @idCidade)";
            cmd.Parameters.AddWithValue("@nomeBairro", bairro.Nome);
            cmd.Parameters.AddWithValue("@idCidade", bairro.Cidade.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Bairro cadastrado com sucesso";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    return ("Bairro já cadastrado.");
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
        public string Delete(Bairro bairro)
        {
            if (bairro.Id == 0)
            {
                return "Bairro informada inválido!";
            }

            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM bairro WHERE idBairro = @ID";
            cmd.Parameters.AddWithValue("@ID", bairro.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Bairro deletado com êxito!";
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
        public string Update(Bairro bairro)
        {
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE bairro SET nomeBairro = @nomeBairro, idCidade = @idCidade WHERE idBairro = @idBairro";
            cmd.Parameters.AddWithValue("@nomeBairro", bairro.Nome);
            cmd.Parameters.AddWithValue("@idCidade", bairro.Cidade.Id);
            cmd.Parameters.AddWithValue("@idBairro", bairro.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Bairro atualizado com êxito!";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "Erro no Banco de dados.Contate o administrador.";
            }
            finally
            {
                conn.Dispose();
            }
        }
        public List<Bairro> GetAll()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM bairro";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Bairro> bairros = new List<Bairro>();

                while (reader.Read())
                {
                    Bairro temp = new Bairro();

                    temp.Cidade = new Cidade();
                    temp.Id = Convert.ToInt32(reader["idBairro"]);
                    temp.Nome = Convert.ToString(reader["nomeBairro"]);
                    temp.Cidade.Id = Convert.ToInt32(reader["idCidade"]);

                    bairros.Add(temp);
                }

                return bairros;
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
        public Bairro GetById(int idBairro)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM bairro WHERE idBairro = @idBairro";
            cmd.Parameters.AddWithValue("@idBairro", idBairro);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Bairro bairro = new Bairro();

                while (reader.Read())
                {

                    bairro.Cidade = new Cidade();

                    bairro.Id = Convert.ToInt32(reader["idBairro"]);
                    bairro.Nome = Convert.ToString(reader["nomeBairro"]);
                    bairro.Cidade.Id = Convert.ToInt32(reader["idCidade"]);
                }

                return bairro;
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
        public Bairro GetLastRegister()
        {
            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM bairro ORDER BY idBairro DESC limit 1";

            try
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                Bairro bairro = new Bairro();

                while (reader.Read())
                {
                    bairro.Cidade = new Cidade();

                    bairro.Id = Convert.ToInt32(reader["idBairro"]);
                    bairro.Nome = Convert.ToString(reader["nomeBairro"]);
                    bairro.Cidade.Id = Convert.ToInt32(reader["idCidade"]);
                }

                return bairro;
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

        public List<Bairro> GetByCidade(Cidade cidade)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM bairro WHERE idCidade = @idCidade";
            cmd.Parameters.AddWithValue("@idCidade", cidade.Id);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Bairro> bairros = new List<Bairro>();

                while (reader.Read())
                {
                    Bairro temp = new Bairro();

                    temp.Cidade = new Cidade();

                    temp.Id = Convert.ToInt32(reader["idBairro"]);
                    temp.Nome = Convert.ToString(reader["nomeBairro"]);
                    temp.Cidade.Id = Convert.ToInt32(reader["idCidade"]);

                    bairros.Add(temp);
                }

                return bairros;
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
