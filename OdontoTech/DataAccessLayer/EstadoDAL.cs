using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Domain;

namespace DataAccessLayer
{
    public class EstadoDAL
    {
        MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
        MySqlCommand cmd = new MySqlCommand();

        /// <summary>
        /// Insere o  Estado no BD. Caso houver erro a função informa.
        /// </summary>
        /// <param name="estado"></param>
        public string Insert(Estado estado)
        {
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
                if (ex.Message.Contains("Duplicate"))
                {
                    return ("Estado já cadastrado.");
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

        /// <summary>
        ///  Tenta deletar, caso der certo retorna (Estado deletado com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public string Delete(Estado estado)
        {
            if (estado.Id == 0)
            {
                return "Estado informado inválido!";
            }

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
        public string Update(Estado estado)
        {
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                return "Erro no Banco de dados.Contate o administrador.";
            }
            finally
            {
                conn.Dispose();
            }
          
        }
        public List<Estado> GetAll()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM estado";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Estado> estados = new List<Estado>();

                while (reader.Read())
                {
                    Estado temp = new Estado();

                    temp.Pais = new Pais();

                    temp.Id = Convert.ToInt32(reader["idEstado"]);
                    temp.Nome = Convert.ToString(reader["nomeEstado"]);
                    temp.Pais.Id = Convert.ToInt32(reader["idPais"]);

                    estados.Add(temp);
                }

                return estados;
            }
            catch (Exception ex)
            {
                //Debug.print();
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                throw new Exception("Erro no Banco de dados.Contate o administrador.");
            }
            finally
            {
                conn.Dispose();
            }
        }
        public Estado GetById(int idEstado)
        {
            cmd.Connection = conn;
            cmd.CommandText = $"SELECT * FROM estado WHERE idEstado = {idEstado}";


            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Estado estado = new Estado();

                while (reader.Read())
                {

                    estado.Pais = new Pais();

                    estado.Id = Convert.ToInt32(reader["idEstado"]);
                    estado.Nome = Convert.ToString(reader["nomeEstado"]);
                    estado.Pais.Id = Convert.ToInt32(reader["idPais"]);
                }

                return estado;
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
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM estado ORDER BY idEstado DESC limit 1";

            try
            {
                conn.Open();
               MySqlDataReader reader = cmd.ExecuteReader();
                Estado estado = new Estado();

                while (reader.Read())
                {

                    estado.Pais = new Pais();

                    estado.Id = Convert.ToInt32(reader["idEstado"]);
                    estado.Nome = Convert.ToString(reader["nomeEstado"]);
                    estado.Pais.Id = Convert.ToInt32(reader["idPais"]);
                }

                return estado;
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
        public List<Estado> GetByPais(Pais pais)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM estado WHERE idPais = @idPais";
            cmd.Parameters.AddWithValue("@ID", pais.Id);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Estado> estados = new List<Estado>();

                while (reader.Read())
                {
                    Estado temp = new Estado();

                    temp.Pais = new Pais();

                    temp.Id = Convert.ToInt32(reader["idEstado"]);
                    temp.Nome = Convert.ToString(reader["nomeEstado"]);
                    temp.Pais.Id = Convert.ToInt32(reader["idPais"]);

                    estados.Add(temp);
                }

                return estados;
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

        public List<Estado> GetByNamePais(Pais pais)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM estado e INNER JOIN pais p ON e.idPais = p.idPais WHERE e.idPais = @idPais and p.nomePais = @nomePais";
            cmd.Parameters.AddWithValue("@nomePais", pais.Nome);
            cmd.Parameters.AddWithValue("@idPais", pais.Id);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Estado> estados = new List<Estado>();

                while (reader.Read())
                {
                    Estado temp = new Estado();

                    temp.Pais = new Pais();

                    temp.Id = Convert.ToInt32(reader["idEstado"]);
                    temp.Nome = Convert.ToString(reader["nomeEstado"]);
                    temp.Pais.Id = Convert.ToInt32(reader["idPais"]);
                    temp.Pais.Nome = Convert.ToString(reader["nomePais"]);

                    estados.Add(temp);
                }

                return estados;
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
