using System;
using System.Collections.Generic;
using Domain;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
    public class PaisDAL
    {
        MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
        MySqlCommand cmd = new MySqlCommand();
        public string Insert(Pais pais)
        {
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO pais (nomePais) values (@nomePais)";
            cmd.Parameters.AddWithValue("@nomePais", pais.Nome);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "País cadastrado com sucesso";
            }
            catch (Exception ex)
            {                
                if (ex.Message.Contains("Duplicate"))
                {
                    return ("País já cadastrado.");
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
        public string Delete(Pais pais)
        {
            if (pais.Id == 0)
            {
                return "País informado inválido!";
            }

            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM pais WHERE idPais = @ID";
            cmd.Parameters.AddWithValue("@ID", pais.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "País deletado com êxito!";
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
        public string Update(Pais pais)
        {
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE pais SET nomePais = @nomePais WHERE idPais = @idPais";
            cmd.Parameters.AddWithValue("@nomePais", pais.Nome);
            cmd.Parameters.AddWithValue("@idPais", pais.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "País atualizado com êxito!";
            }
            catch (Exception)
            {
                return "Erro no Banco de dados. Contate o administrador.";
            }
            finally
            {
                conn.Dispose();
            }
        }
        public List<Pais> GetAll()
        {            
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM pais";
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Pais> pais = new List<Pais>();

                while (reader.Read())
                {
                    Pais temp = new Pais();
                    temp.Id = Convert.ToInt32(reader["idPais"]);
                    temp.Nome = Convert.ToString(reader["nomePais"]);

                    pais.Add(temp);
                }

                return pais;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                throw new Exception("Erro no Banco de dados.Contate o administrador.");
            }
            finally
            {
                conn.Dispose();
            }
        }
        public Pais GetById(int idPais)
        {            
            cmd.Connection = conn;
            cmd.CommandText = $"SELECT * FROM pais WHERE idPais = {idPais}";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Pais pais = new Pais();

                while (reader.Read())
                {
                    pais.Id = Convert.ToInt32(reader["idPais"]);
                    pais.Nome = Convert.ToString(reader["nomePais"]);
                }

                return pais;
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
        public Pais GetLastRegister()
        {
           
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM pais ORDER BY idPais DESC limit 1";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Pais pais = new Pais();

                while (reader.Read())
                {
                    pais.Id = Convert.ToInt32(reader["idPais"]);
                    pais.Nome = Convert.ToString(reader["nomePais"]);
                }

                return pais;
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
