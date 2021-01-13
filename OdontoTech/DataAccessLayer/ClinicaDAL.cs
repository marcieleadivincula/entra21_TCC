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
    class ClinicaDAL
    {
        /// <summary>
        /// Insere a Clinica no BD. Caso houver erro a função informa.
        /// </summary>
        /// <param name="clinica"></param>
        public void Inserir(Clinica clinica)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO clinica (idClinica,nomeClinica,dtInauguracao,idEndereco) values (@idClinica,@nomeClinica,@dtInauguracao,@idEndereco)";
            cmd.Parameters.AddWithValue("@idClinica", clinica.Id);
            cmd.Parameters.AddWithValue("@nomeClinica", clinica.nNome);
            cmd.Parameters.AddWithValue("@dtInauguracao", Convert.ToString(clinica.DataInauguracao));
            cmd.Parameters.AddWithValue("@idEndereco", clinica.Endereco.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    throw new Exception("Clinica já cadastrada.");
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
        /// <summary>
        /// Tenta deletar, caso der certo retorna (Clinica deletads com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="clinica"></param>
        /// <returns></returns>
        public string Deletar(Clinica clinica)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM clinica WHERE idClinica = @ID";
            cmd.Parameters.AddWithValue("@ID", clinica.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Clinica deletada com êxito!";
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
