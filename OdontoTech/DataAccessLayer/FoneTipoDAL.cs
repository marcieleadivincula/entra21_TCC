using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Domain;

namespace DataAccessLayer
{
    public class FoneTipoDAL
    {
        MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
        MySqlCommand cmd = new MySqlCommand();
        public string Insert(FoneTipo foneTipo)
        {
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO foneTipo(tipo) values(@tipo)";
            cmd.Parameters.AddWithValue("@tipo", foneTipo.Tipo);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Tipo de telefone cadastrado com sucesso";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    return ("Tipo de telefone já cadastrada.");
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
        public string Delete(FoneTipo foneTipo)
        {
            if (foneTipo.Id == 0)
            {
                return "Tipo de telefone informado é inválido!";
            }

            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM foneTipo WHERE idFoneTipo = @idFoneTipo";
            cmd.Parameters.AddWithValue("@idFoneTipo", foneTipo.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Tipo de telefone deletado com êxito!";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "Erro no Banco de dados.Contate o administrador.";
            }
            finally
            {
                conn.Dispose();
            }
        }
        public string Update(FoneTipo foneTipo)
        {
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE foneTipo SET tipo = @tipo WHERE idFoneTipo = @idFoneTipo";
            cmd.Parameters.AddWithValue("@tipo", foneTipo.Tipo);
            cmd.Parameters.AddWithValue("@idFoneTipo", foneTipo.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Tipo de telefone atualizado com êxito!";
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
        public List<FoneTipo> GetAll()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM foneTipo";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<FoneTipo> foneTipos = new List<FoneTipo>();

                while (reader.Read())
                {
                    FoneTipo temp = new FoneTipo();
                    temp.Id = Convert.ToInt32(reader["idFoneTipo"]);
                    temp.Tipo = Convert.ToString(reader["tipo"]);

                    foneTipos.Add(temp);
                }

                return foneTipos;
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
        public FoneTipo GetById(int idFoneTipo)
        {
            cmd.Connection = conn;
            cmd.CommandText = $"SELECT * FROM foneTipo WHERE idFoneTipo = {idFoneTipo}";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                FoneTipo foneTipo = new FoneTipo();

                while (reader.Read())
                {
                    foneTipo.Id = Convert.ToInt32(reader["idFoneTipo"]);
                    foneTipo.Tipo = Convert.ToString(reader["tipo"]);
                }

                return foneTipo;
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
        public FoneTipo GetLastRegister()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM foneTipo ORDER BY idFoneTipo DESC limit 1";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                FoneTipo foneTipo = new FoneTipo();

                while (reader.Read())
                {
                    foneTipo.Id = Convert.ToInt32(reader["idFoneTipo"]);
                    foneTipo.Tipo = Convert.ToString(reader["tipo"]);
                }

                return foneTipo;
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
