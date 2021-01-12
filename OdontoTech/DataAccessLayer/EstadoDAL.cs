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
    class EstadoDAL
    {
        public void Inserir(Estado estado)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO estado (idEstado,nomeEstado,idPais) values (@idEstado,@nomeEstado,@idPais)";
            cmd.Parameters.AddWithValue("@idEstado", estado.Id);
            cmd.Parameters.AddWithValue("@nomeEstado", estado.Nome);
            cmd.Parameters.AddWithValue("@idPais", estado.Pais.Id);


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    throw new Exception("Estado já cadastrado.");
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
    }
}
