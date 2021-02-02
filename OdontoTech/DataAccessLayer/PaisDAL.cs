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

        public string Inserir(Pais pais)
        {
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO pais (nomePais) values (@nomePais)";
            cmd.Parameters.AddWithValue("@nomePais", pais.Nome);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Pais cadastrado com sucesso";
            }
            catch (Exception ex)
            {                
                if (ex.Message.Contains("Duplicate"))
                {
                    return ("Pais já cadastrado.");
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
        public string Deletar(Pais pais)
        {
            
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM pais WHERE idPais = @ID";
            cmd.Parameters.AddWithValue("@ID", pais.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Pais deletado com êxito!";
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
        public string Atualizar(Pais pais)
        {
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE pais SET nomePais = @nomePais WHERE idPais = @idPais";
            cmd.Parameters.AddWithValue("@nomePais", pais.Nome);
            cmd.Parameters.AddWithValue("@idPais", pais.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Pais atualizado com êxito!";
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
        public List<Pais> SelecionaTodos()
        {            
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM pais";
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Pais> Pais = new List<Pais>();
                while (reader.Read())
                {
                    Pais temp = new Pais();

                    temp.Id = Convert.ToInt32(reader["idPais"]);
                    temp.Nome = Convert.ToString(reader["nomePais"]);
          

                    Pais.Add(temp);
                }
                return Pais;
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
        public Pais SelecionarUltimoID()
        {            
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM pais order by idPais DESC limit 1";
            try
            {
                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                Pais pais = new Pais();

                while (reader.Read())
                {
                    Pais temp = new Pais();

                    temp.Id = Convert.ToInt32(reader["idPais"]);

                    pais = temp;
                }
                return pais;
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
