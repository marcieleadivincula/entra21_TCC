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
    public class LogradouroDAL
    {
        public void Inserir(Logradouro logradouro)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO logradouro (nomeLogradouro,idBairro) values (@nomeLogradouro,@idBairro)";

            cmd.Parameters.AddWithValue("@nomeLogradouro", logradouro.Nome);
            cmd.Parameters.AddWithValue("@idBairro", logradouro.Bairro.Id);



            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    throw new Exception("Logradouro já cadastrado.");
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
        public string Deletar(Logradouro logradouro)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM logradouro WHERE idLogradouro = @ID";
            cmd.Parameters.AddWithValue("@ID", logradouro.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Logradouro deletado com êxito!";
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
        public string Atualizar(Logradouro logradouro)
        {

            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE logradouro SET nomeLogradouro = @nomeLogradouro, SET idBairro = @idBairro WHERE idLogradouro = @idLogradouro";


            cmd.Parameters.AddWithValue("@idLogradouro", logradouro.Nome);
            cmd.Parameters.AddWithValue("@nomeLogradouro", logradouro.Nome);
            cmd.Parameters.AddWithValue("@idBairro", logradouro.Bairro.Id);


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Logradouro atualizado com êxito!";
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

        public List<Funcao> SelecionaTodos()
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM logradouro";
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
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
                throw new Exception("Erro no Banco de dados.Contate o administrador.");
            }
            finally
            {
                conn.Dispose();
            }
        }
    }
}
