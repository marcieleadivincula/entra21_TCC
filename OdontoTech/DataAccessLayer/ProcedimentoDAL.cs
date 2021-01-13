using Domain;
using System;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    class ProcedimentoDAL
    {
        /// <summary>
        /// Inserir procedimento
        /// </summary>
        /// <param name="procedimento"></param>
        public void Inserir(Procedimento procedimento)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO procedimento (idProcedimento,nomeProcedimento,dsProcedimento,idTipoProcedimento) values (@idProcedimento,@nomeProcedimento,@dsProcedimento,@idTipoProcedimento)";
            cmd.Parameters.AddWithValue("@idProcedimento", procedimento.Id);
            cmd.Parameters.AddWithValue("@nomeProcedimento", procedimento.Nome);
            cmd.Parameters.AddWithValue("@dsProcedimento", procedimento.DescricaoProcedimento);
            cmd.Parameters.AddWithValue("@idTipoProcedimento", procedimento.TipoProcedimento.Id);


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    throw new Exception("Procedimento já cadastrado.");
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
        /// Tenta deletar, caso der certo retorna (Procedimento deletado com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="procedimento"></param>
        /// <returns></returns>
        public string Deletar(Procedimento procedimento)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM procedimento WHERE idProcedimento = @ID";
            cmd.Parameters.AddWithValue("@ID", procedimento.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Procedimento deletado com êxito!";
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
