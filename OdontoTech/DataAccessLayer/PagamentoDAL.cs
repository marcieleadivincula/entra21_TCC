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
        public string Inserir(Pagamento Pagamento)
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
                return "Pagamento cadastrado com sucesso !";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    return ("Pagamento já cadastrado.");
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
        public string Deletar(Pagamento Pagamento)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM pagamento WHERE idPagamento = @ID";
            cmd.Parameters.AddWithValue("@ID", Pagamento.Id);
                
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Pagamento deletado com êxito!";
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
        public string Atualizar(Pagamento Pagamento)
        {

            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE procedimento SET dtPagamento = @dtPagamento, SET idTipoPagamento = @idTipoPagamento WHERE idPagamento = @idPagamento";
            cmd.Parameters.AddWithValue("@idPagamento", Pagamento.Id);
            cmd.Parameters.AddWithValue("@dtPagamento", Pagamento.DataPagamento);
            cmd.Parameters.AddWithValue("@idTipoPagamento", Pagamento.TipoPagamento.Id);


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Pais atualizado com êxito!";
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
        public List<Pagamento> SelecionaTodos()
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM pagamento";
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Pagamento> Pagamentos = new List<Pagamento>();
                while (reader.Read())
                {
                    Pagamento temp = new Pagamento();

                    temp.Id = Convert.ToInt32(reader["idPagamento"]);
                    temp.DataPagamento = Convert.ToDateTime(reader["dtPagamento"]);
                    temp.TipoPagamento.Id = Convert.ToInt32(reader["idTipoPagamento"]);


                    Pagamentos.Add(temp);
                }
                return Pagamentos;
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
