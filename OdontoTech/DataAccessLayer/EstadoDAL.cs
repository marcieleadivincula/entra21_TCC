using MySql.Data.MySqlClient;
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
    public class EstadoDAL
    {
        /// <summary>
        /// Insere o  Estado no BD. Caso houver erro a função informa.
        /// </summary>
        /// <param name="estado"></param>
        public string Inserir(Estado estado)
        {
            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO estado (nomeEstado,idPais) values (@nomeEstado,@idPais)";
      
            cmd.Parameters.AddWithValue("@nomeEstado", estado.Nome);
            cmd.Parameters.AddWithValue("@idPais", estado.Pais.Id);


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Estado cadastrado com sucesso";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    return ("Estado já cadastrado.");
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


        /// <summary>
        ///  Tenta deletar, caso der certo retorna (Estado deletado com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public string Deletar(Estado estado)
        {
            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM estado WHERE idEstado = @ID";
            cmd.Parameters.AddWithValue("@ID", estado.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Estado deletado com êxito!";
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

        /// <summary>
        /// Tenta atualizar, caso der certo retorna (Estado atualizado com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public string Atualizar(Estado estado)
        {

            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE estado SET nomeEstado = @nomeEstado WHERE idEstado = @idEstado";
            cmd.Parameters.AddWithValue("@nomeEstado", estado.Nome);
            cmd.Parameters.AddWithValue("@idEstado", estado.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Estado atualizado com êxito!";
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
        public List<Estado> SelecionaTodos()
        {
            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM estado";
            try
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<Estado> Estados = new List<Estado>();
                while (reader.Read())
                {
                    Estado temp = new Estado();

                    temp.Id = Convert.ToInt32(reader["idEstado"]);
                    temp.Nome = Convert.ToString(reader["nomeEstado"]);
                    temp.Pais.Id = Convert.ToInt32(reader["idPais"]);

                    Estados.Add(temp);
                }
                return Estados;
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
        public Estado GetByID(int id)
        {
            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM estado WHERE idEstado = @ID";
            cmd.Parameters.AddWithValue("@ID", id);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Estado temp = new Estado();

                while (reader.Read())
                {

                    temp.Id = Convert.ToInt32(reader["idEstado"]);
                    temp.Nome = Convert.ToString(reader["nomeEstado"]);
                    temp.Pais.Id = Convert.ToInt32(reader["idPais"]);

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
        public Estado GetLastRegister()
        {
            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand command = new MySqlCommand(); ;
            command.Connection = conn;
            command.CommandText = "SELECT * FROM estado ORDER BY idEstado DESC limit 1";

            try
            {
                conn.Open();
               MySqlDataReader reader = command.ExecuteReader();
                Estado Estado = new Estado();

                while (reader.Read())
                {
                    Estado temp = new Estado();


                    temp.Id = Convert.ToInt32(reader["idEstado"]);
                    temp.Nome = Convert.ToString(reader["nomeEstado"]);
                    temp.Pais.Id = Convert.ToInt32(reader["idPais"]);



                    Estado = temp;
                }

                return Estado;
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
