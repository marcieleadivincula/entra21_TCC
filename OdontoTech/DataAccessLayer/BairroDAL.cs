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
    public class BairroDAL
    {
        public string Inserir(Bairro bairro)
        {

            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO bairro (nomeBairro,idCidade) values (@nomeBairro,@idCidade)";

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
                if (ex.Message.Contains("UNIQUE"))
                {
                    return ("Bairro já cadastrado.");
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
        public string Deletar(Bairro bairro)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
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
        public string Atualizar(Bairro bairro)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE bairro SET nomeBairro = @nomeBairro, SET idCidade = @idCidade WHERE idBairro = @idBairro";
            cmd.Parameters.AddWithValue("@idBairro", bairro.Id );
            cmd.Parameters.AddWithValue("@nomeBairro", bairro.Nome );
            cmd.Parameters.AddWithValue("@idCidade",bairro.Cidade.Id );


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Bairro atualizada com êxito!";
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
        public List<Bairro> SelecionaTodos()
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM bairro";
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Bairro> Bairros = new List<Bairro>();
                while (reader.Read())
                {
                    Bairro temp = new Bairro();

                    temp.Id = Convert.ToInt32(reader["idBairro"]);
                    temp.Nome = Convert.ToString(reader["nomeBairro"]);
                    temp.Cidade.Id = Convert.ToInt32(reader["idCidade"]);
    

                    Bairros.Add(temp);
                }
                return Bairros;
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
