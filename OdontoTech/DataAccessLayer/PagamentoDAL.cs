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
    class PagamentoDAL
    {
        public void Inserir(Pagamento Pagamento)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO pagamento (dtPagamento,idTipoPagamento) values (@dtPagamento,@idTipoPagamento)";

            cmd.Parameters.AddWithValue("@idTipoPagamento", Pagamento.TipoPagamento.Id);
            cmd.Parameters.AddWithValue("@dtPagamento", Pagamento.DataPagamento);


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    throw new Exception("Pagamento já cadastrado.");
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
