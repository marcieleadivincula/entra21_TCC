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
    public class TipoPagamentoDAL
    {
        public void Inserir(TipoPagamento tipoPagamento)
        {

            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO tipopagamento (tipoPagamento) values (@tipoPagamento)";

            cmd.Parameters.AddWithValue("@tipoPagamento", tipoPagamento.Tipo);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    throw new Exception("Tipo Pagamento já cadastrado.");
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
        public string Deletar(TipoPagamento tipoPagamento)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM tipopagamento WHERE idTipoPagamento = @ID";
            cmd.Parameters.AddWithValue("@ID", tipoPagamento.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Tipo Procedimento deletado com êxito!";
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
        public string Atualizar(TipoPagamento tipoPagamento)
        {

            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE tipopagamento SET tipoPagamento = @tipoPagamento WHERE idTipoPagamento = @idTipoPagamento";
            cmd.Parameters.AddWithValue("@ID", tipoPagamento.Id);
            cmd.Parameters.AddWithValue("@tipoPagamento", tipoPagamento.Tipo);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "TipoProcedimento atualizado com êxito!";
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
