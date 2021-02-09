using System;
using System.Collections.Generic;
using Domain;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
    public class PagamentoDAL
    {
        MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
        MySqlCommand cmd = new MySqlCommand();

        public string Inserir(Pagamento Pagamento)
        {
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
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE pagamento SET dtPagamento = @dtPagamento WHERE idPagamento = @idPagamento";
            cmd.Parameters.AddWithValue("@idPagamento", Pagamento.Id);
            cmd.Parameters.AddWithValue("@dtPagamento", Pagamento.DataPagamento);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Pagamento atualizado com êxito!";
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
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM pagamento";
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
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
        public Pagamento GetByID(int id)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM pagamento WHERE idPagamento = @ID";
            cmd.Parameters.AddWithValue("@ID", id);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Pagamento temp = new Pagamento();

                while (reader.Read())
                {

                    temp.Id = Convert.ToInt32(reader["idPagamento"]);
                    temp.DataPagamento = Convert.ToDateTime(reader["dtPagamento"]);
                    temp.TipoPagamento.Id = Convert.ToInt32(reader["idTipoPagamento"]);

                }
                return temp;
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
        public Pagamento GetLastRegister()
        {
            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand command = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM pagamento ORDER BY idPagamento DESC limit 1";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Pagamento Pagamento = new Pagamento();

                while (reader.Read())
                {
                    Pagamento temp = new Pagamento();

                    temp.Id = Convert.ToInt32(reader["idPagamento"]);
                    temp.DataPagamento = Convert.ToDateTime(reader["dtPagamento"]);
                    temp.TipoPagamento.Id = Convert.ToInt32(reader["idTipoPagamento"]);

                    Pagamento = temp;
                }

                return Pagamento;
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
