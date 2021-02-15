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
        public string Insert(Pagamento pagamento)
        {
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO pagamento(dtPagamento, valorPagamento, idTipoPagamento, idPaciente) values(@dtPagamento, @valorPagamento, @idTipoPagamento, @idPaciente)";
            cmd.Parameters.AddWithValue("@dtPagamento", pagamento.DataPagamento);
            cmd.Parameters.AddWithValue("@valorPagamento", pagamento.ValorPagamento);
            cmd.Parameters.AddWithValue("@idTipoPagamento", pagamento.TipoPagamento.Id);
            cmd.Parameters.AddWithValue("@idPaciente", pagamento.Paciente.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Pagamento cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
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
        public string Delete(Pagamento pagamento)
        {
            if (pagamento.Id == 0)
            {
                return "Pagamento informado inválido!";
            }

            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM pagamento WHERE idPagamento = @idPagamento";
            cmd.Parameters.AddWithValue("@idPagamento", pagamento.Id);

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
        public string Update(Pagamento pagamento)
        {
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE pagamento SET dtPagamento = @dtPagamento, valorPagamento = @valorPagamento, idTipoPagamento = @idTipoPagamento, idPaciente = @idPaciente WHERE idPagamento = @idPagamento";
            cmd.Parameters.AddWithValue("@dtPagamento", pagamento.DataPagamento);
            cmd.Parameters.AddWithValue("@valorPagamento", pagamento.ValorPagamento);
            cmd.Parameters.AddWithValue("@idTipoPagamento", pagamento.TipoPagamento.Id);
            cmd.Parameters.AddWithValue("@idPaciente", pagamento.Paciente.Id);
            cmd.Parameters.AddWithValue("@idPagamento", pagamento.Id);

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
        public List<Pagamento> GetAll()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM pagamento";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Pagamento> pagamentos = new List<Pagamento>();

                while (reader.Read())
                {
                    Pagamento temp = new Pagamento();
                    temp.TipoPagamento = new TipoPagamento();
                    temp.Paciente = new Paciente();
                    

                    temp.Id = Convert.ToInt32(reader["idPagamento"]);
                    temp.DataPagamento = Convert.ToDateTime(reader["dtPagamento"]);
                    temp.ValorPagamento = Convert.ToDouble(reader["valorPagamento"]);
                    temp.TipoPagamento.Id = Convert.ToInt32(reader["idTipoPagamento"]);
                    temp.Paciente.Id = Convert.ToInt32(reader["idPaciente"]);

                    pagamentos.Add(temp);
                }

                return pagamentos;
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
        public Pagamento GetById(int idPagamento)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM pagamento WHERE idPagamento = @idPagamento";
            cmd.Parameters.AddWithValue("@idPagamento", idPagamento);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Pagamento pagamento = new Pagamento();

                while (reader.Read())
                {
                    pagamento.TipoPagamento = new TipoPagamento();

                    pagamento.Id = Convert.ToInt32(reader["idPagamento"]);
                    pagamento.DataPagamento = Convert.ToDateTime(reader["dtPagamento"]);
                    pagamento.ValorPagamento = Convert.ToDouble(reader["valorPagamento"]);
                    pagamento.TipoPagamento.Id = Convert.ToInt32(reader["idTipoPagamento"]);
                    pagamento.Paciente.Id = Convert.ToInt32(reader["idPaciente"]);
                }

                return pagamento;
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
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM pagamento ORDER BY idPagamento DESC limit 1";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Pagamento pagamento = new Pagamento();

                while (reader.Read())
                {
                    pagamento.TipoPagamento = new TipoPagamento();

                    pagamento.Id = Convert.ToInt32(reader["idPagamento"]);
                    pagamento.DataPagamento = Convert.ToDateTime(reader["dtPagamento"]);
                    pagamento.ValorPagamento = Convert.ToDouble(reader["valorPagamento"]);
                    pagamento.TipoPagamento.Id = Convert.ToInt32(reader["idTipoPagamento"]);
                    pagamento.Paciente.Id = Convert.ToInt32(reader["idPaciente"]);
                }

                return pagamento;
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
        public List<Pagamento> GetByTipoPagamento(TipoPagamento tipoPagamento)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM pagamento WHERE idTipoPagamento = @idTipoPagamento";
            cmd.Parameters.AddWithValue("@idTipoPagamento", tipoPagamento.Id);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Pagamento> pagamentos = new List<Pagamento>();

                while (reader.Read())
                {
                    Pagamento temp = new Pagamento();
                    temp.TipoPagamento = new TipoPagamento();
                    ;
                    temp.Id = Convert.ToInt32(reader["idPagamento"]);
                    temp.DataPagamento = Convert.ToDateTime(reader["dtPagamento"]);
                    temp.ValorPagamento = Convert.ToDouble(reader["valorPagamento"]);
                    temp.TipoPagamento.Id = Convert.ToInt32(reader["idTipoPagamento"]);
                    temp.Paciente.Id = Convert.ToInt32(reader["idPaciente"]);

                    pagamentos.Add(temp);
                }

                return pagamentos;
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
