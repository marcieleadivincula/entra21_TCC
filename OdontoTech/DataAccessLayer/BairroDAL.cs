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
    class BairroDAL
    {
        public void Inserir(Bairro bairro)
        {

            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO bairro (nomeBairro,idCidade) values (@nomeBairro,@idCidade)";

            cmd.Parameters.AddWithValue("@nomeBairro", bairro.Nome);
            cmd.Parameters.AddWithValue("@idCidade", bairro.cidade.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    throw new Exception("Bairro já cadastrado.");
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
    }
}
