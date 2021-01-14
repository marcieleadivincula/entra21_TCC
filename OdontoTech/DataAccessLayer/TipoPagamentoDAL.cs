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
        public List<TipoPagamento> SelecionaTodos()
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM tipopagamento";
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<TipoPagamento> TipoPagamentos = new List<TipoPagamento>();
                while (reader.Read())
                {
                    TipoPagamento temp = new TipoPagamento();

                    temp.Id = Convert.ToInt32(reader["idTipoPagamento"]);
                    temp.Tipo = Convert.ToString(reader["tipoPagamento"]);
            

                    TipoPagamentos.Add(temp);
                }
                return TipoPagamentos;
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
