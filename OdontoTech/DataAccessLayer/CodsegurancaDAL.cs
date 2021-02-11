using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Domain;

namespace DataAccessLayer
{
    class CodsegurancaDAL
    {
        MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
        MySqlCommand cmd = new MySqlCommand();
        public string Insert(string codigo, string email)
        {
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO codseguranca (Codigo,Email) values (@Codigo,@Email)";
            cmd.Parameters.AddWithValue("@Codigo", codigo);
            cmd.Parameters.AddWithValue("@Email", email);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Codigo foi enviado";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    return ("Codigo ja usado.");
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
        public string GetCODByEmail(string Email)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM codseguranca WHERE Email = @Email";
            cmd.Parameters.AddWithValue("@Email", Email);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                string cod = "";

                while (reader.Read())
                {
                    cod = Convert.ToString(reader["Codigo"]);
                }

                return cod;
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
        public string DeleteByEmail(string email)
        {
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM codseguranca WHERE Email = @Email";
            cmd.Parameters.AddWithValue("@Email", email);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Solicitação deletado com êxito!";
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
