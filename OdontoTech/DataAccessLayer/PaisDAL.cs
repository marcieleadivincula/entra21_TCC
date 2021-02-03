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
    public class PaisDAL
    {
        public string Inserir(Pais pais)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
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
                if (ex.Message.Contains("UNIQUE"))
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
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
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

            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE procedimento SET nomePais = @nomePais WHERE idPais = @idPais";
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
                return "Erro no Banco de dados.Contate o administrador.";
            }
            finally
            {
                conn.Dispose();
            }
        }
        public List<Pais> SelecionaTodos()
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM pais";
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Pais> Paiss = new List<Pais>();
                while (reader.Read())
                {
                    Pais temp = new Pais();

                    temp.Id = Convert.ToInt32(reader["idPais"]);
                    temp.Nome = Convert.ToString(reader["nomePais"]);
          

                    Paiss.Add(temp);
                }
                return Paiss;
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
        public Pais GetByID(int id)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM pais WHERE idPais = @ID";
            cmd.Parameters.AddWithValue("@ID", id);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Pais temp = new Pais();

                while (reader.Read())
                {

                    temp.Id = Convert.ToInt32(reader["idPais"]);
                    temp.Nome = Convert.ToString(reader["nomePais"]);


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
        public Pais GetLastRegister()
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM pais ORDER BY idPais DESC limit 1";

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                Pais Pais = new Pais();

                while (reader.Read())
                {
                    Pais temp = new Pais();


                    temp.Id = Convert.ToInt32(reader["idPais"]);
                    temp.Nome = Convert.ToString(reader["nomePais"]);

                    Pais = temp;
                }

                return Pais;
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
