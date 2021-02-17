using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Domain;

namespace DataAccessLayer
{
    public class DispesaDAL
    {
        MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
        MySqlCommand cmd = new MySqlCommand();
        public string Insert(Dispesa dispesa)
        {
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO dispesa (Data, Valor, Descricao) values (@Data, @Valor, @Descricao)";

            cmd.Parameters.AddWithValue("@Data", dispesa.Data);
            cmd.Parameters.AddWithValue("@Valor", dispesa.Valor);
            cmd.Parameters.AddWithValue("@Descricao", dispesa.Descricao);


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Dispesa cadastrada com sucesso !";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    return ("Dispesa já cadastrado.");
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

        public string Delete(Dispesa dispesa)
        {

            cmd.Connection = conn;
            cmd.CommandText = $"DELETE FROM dispesa WHERE idMovimentacaofinanceira = {dispesa.idMovimentacaofinanceira}";


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Dispesa deletado com êxito!";
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

        public List<Dispesa> GetAll()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM dispesa";
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Dispesa> dispesas = new List<Dispesa>();

                while (reader.Read())
                {
                    Dispesa temp = new Dispesa();

           
                    temp.idMovimentacaofinanceira = Convert.ToInt32(reader["idMovimentacaofinanceira"]);
                    temp.Data = Convert.ToDateTime(reader["Data"]);
                    temp.Descricao = Convert.ToString(reader["Descricao"]);
                    temp.Valor = Convert.ToDouble(reader["Valor"]);
                 

                    dispesas.Add(temp);
                }

                return dispesas;
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
