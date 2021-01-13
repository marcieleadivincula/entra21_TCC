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
    class TipoProcedimentoDAL
    {
        /// <summary>
        /// Insere o  TipoProcedimento no BD. Caso houver erro a função informa.
        /// </summary>
        /// <param name="TipoProcedimento"></param>
        public void Inserir(TipoProcedimento TipoProcedimento)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO tipoprocedimento (idTipoProcedimento,nomeTipoProcedimento,valorProcedimento) values (@idTipoProcedimento,@nomeTipoProcedimento,@valorProcedimento)";
            cmd.Parameters.AddWithValue("@idTipoProcedimento", TipoProcedimento.Id);
            cmd.Parameters.AddWithValue("@nomeTipoProcedimento", TipoProcedimento.Nome);
            cmd.Parameters.AddWithValue("@valorProcedimento", TipoProcedimento.Valor);


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    throw new Exception("Tipo Procedimento já cadastrado.");
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
