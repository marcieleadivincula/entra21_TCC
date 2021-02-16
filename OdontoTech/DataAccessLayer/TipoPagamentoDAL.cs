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
        MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
        MySqlCommand cmd = new MySqlCommand();

        public string Insert(TipoPagamento tipoPagamento)
        {
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO tipopagamento(tipoPagamento) values(@tipoPagamento)";
            cmd.Parameters.AddWithValue("@tipoPagamento", tipoPagamento.Tipo);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Tipo de pagamento cadastrado com sucesso";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    return ("Tipo de pagamento já cadastrado.");
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
        public string Delete(TipoPagamento tipoPagamento)
        {
            if (tipoPagamento.Id == 0)
            {
                return "Tipo de pagamento informado é inválido!";
            }

            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM tipopagamento WHERE idTipoPagamento = @idTipoPagamento";
            cmd.Parameters.AddWithValue("@idTipoPagamento", tipoPagamento.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Tipo de pagamento deletado com êxito!";
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
        public string Update(TipoPagamento tipoPagamento)
        {
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE tipopagamento SET tipoPagamento = @tipoPagamento WHERE idTipoPagamento = @idTipoPagamento";
            cmd.Parameters.AddWithValue("@tipoPagamento", tipoPagamento.Tipo);
            cmd.Parameters.AddWithValue("@idTipoPagamento", tipoPagamento.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Tipo de pagamento atualizado com êxito!";
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
        public List<TipoPagamento> GetAll()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM tipopagamento";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<TipoPagamento> tipoPagamentos = new List<TipoPagamento>();

                while (reader.Read())
                {
                    TipoPagamento temp = new TipoPagamento();

                    
                    temp.Id = Convert.ToInt32(reader["idTipoPagamento"]);
                    temp.Tipo = Convert.ToString(reader["tipoPagamento"]);

                    tipoPagamentos.Add(temp);
                }

                return tipoPagamentos;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                throw new Exception("Erro no Banco de dados.Contate o administrador.");
            }
            finally
            {
                conn.Dispose();
            }
        }
        public TipoPagamento GetById(int idTipoPagamento)
        {
            cmd.Connection = conn;
            cmd.CommandText = $"SELECT * FROM tipopagamento WHERE idTipoPagamento = {idTipoPagamento}";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                TipoPagamento tipoPagamento = new TipoPagamento();

                while (reader.Read())
                {
                    tipoPagamento.Id = Convert.ToInt32(reader["idTipoPagamento"]);
                    tipoPagamento.Tipo = Convert.ToString(reader["tipoPagamento"]);
                }

                return tipoPagamento;
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
                TipoPagamento tipoPagamento = new TipoPagamento();

                while (reader.Read())
                {
                    tipoPagamento.Id = Convert.ToInt32(reader["idTipoPagamento"]);
                    tipoPagamento.Tipo = Convert.ToString(reader["tipoPagamento"]);
                }

                return tipoPagamento;
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
