using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Domain;

namespace DataAccessLayer
{
    public class DespesaDAL
    {
        MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
        MySqlCommand cmd = new MySqlCommand();
        public string Insert(Despesa despesa)
        {
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO despesa (dtDespesa,valor,descricao) values (@DtDespesa,@Valor,@Descricao)";

            cmd.Parameters.AddWithValue("@DtDespesa", despesa.Data);
            cmd.Parameters.AddWithValue("@Valor", despesa.Valor);
            cmd.Parameters.AddWithValue("@Descricao", despesa.Descricao);


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Despesa cadastrada com sucesso!";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    return ("Despesa já cadastrado.");
                }
                else
                {
                    Console.WriteLine(ex);
                    return ("Erro no Banco de dados. Contate o administrador.");
                }
            }
            finally
            {
                conn.Dispose();
            }
        }
        public string Update(Despesa despesa)
        {
            cmd.Connection = conn;
            cmd.CommandText = $"UPDATE despesa SET dtDespesa = @dtDespesa, valor = @valor, descricao = @descricao WHERE idDespesa = {despesa.idDespesa}";
            cmd.Parameters.AddWithValue("@dtDespesa", despesa.Data);
            cmd.Parameters.AddWithValue("@valor", despesa.Valor);
            cmd.Parameters.AddWithValue("@descricao", despesa.Descricao);
            cmd.Parameters.AddWithValue("@idDespesa", despesa.idDespesa);


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Despesa atualizada com êxito!";
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
        public string Delete(Despesa despesa)
        {

            cmd.Connection = conn;
            cmd.CommandText = $"DELETE FROM despesa WHERE idDespesa = {despesa.idDespesa}";


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Despesa deletada com êxito!";
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

        public List<Despesa> GetAll()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM despesa";
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Despesa> despesas = new List<Despesa>();

                while (reader.Read())
                {
                    Despesa temp = new Despesa();

           
                    temp.idDespesa = Convert.ToInt32(reader["idDespesa"]);
                    temp.Data = Convert.ToDateTime(reader["dtDespesa"]);
                    temp.Descricao = Convert.ToString(reader["descricao"]);
                    temp.Valor = Convert.ToDouble(reader["valor"]);


                    despesas.Add(temp);
                }

                return despesas;
            }
            catch (Exception)
            {
                throw new Exception("Erro no Banco de dados. Contate o administrador.");
            }
            finally
            {
                conn.Dispose();
            }
        }
    }
}
