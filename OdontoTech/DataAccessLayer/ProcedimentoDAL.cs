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

    }
}
