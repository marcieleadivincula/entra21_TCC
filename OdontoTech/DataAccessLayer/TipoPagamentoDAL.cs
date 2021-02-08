using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data.SqlClient;
using Domain;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
    public class TipoPagamentoDAL
    {
        public string Inserir(TipoPagamento tipoPagamento)
        {

            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO tipopagamento (tipoPagamento) values (@tipoPagamento)";

            cmd.Parameters.AddWithValue("@tipoPagamento", tipoPagamento.Tipo);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Tipo pagamento cadastrado com sucesso";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    return ("Tipo Pagamento já cadastrado.");
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
        public string Deletar(TipoPagamento tipoPagamento)
        {
            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand cmd = new MySqlCommand();
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

            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand cmd = new MySqlCommand();

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
            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM tipopagamento";
            try
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
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
        public TipoPagamento GetByID(int id)
        {
            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM tipopagamento WHERE idTipoPagamento = @ID";
            cmd.Parameters.AddWithValue("@ID", id);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                TipoPagamento temp = new TipoPagamento();

                while (reader.Read())
                {
                    temp.Id = Convert.ToInt32(reader["idTipoPagamento"]);
                    temp.Tipo = Convert.ToString(reader["tipoPagamento"]);


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
        public TipoPagamento GetLastRegister()
        {
            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM tipopagamento ORDER BY idTipoPagamento DESC limit 1";

            try
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                TipoPagamento TipoPagamento = new TipoPagamento();

                while (reader.Read())
                {
                    TipoPagamento temp = new TipoPagamento();

                    temp.Id = Convert.ToInt32(reader["idTipoPagamento"]);
                    temp.Tipo = Convert.ToString(reader["tipoPagamento"]);

                    TipoPagamento = temp;
                }

                return TipoPagamento;
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
