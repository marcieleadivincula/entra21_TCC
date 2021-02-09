using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Domain;

namespace DataAccessLayer
{
    public class ClinicaDAL
    {

        MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
        MySqlCommand cmd = new MySqlCommand();
        /// <summary>
        /// Insere a Clinica no BD. Caso houver erro a função informa.
        /// </summary>
        /// <param name="clinica"></param>
        public string Inserir(Clinica clinica)
        {
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO clinica (nomeClinica,dtInauguracao,idEndereco) values (@nomeClinica,@dtInauguracao,@idEndereco)";

            cmd.Parameters.AddWithValue("@nomeClinica", clinica.Nome);
            cmd.Parameters.AddWithValue("@dtInauguracao", clinica.DataInauguracao);
            cmd.Parameters.AddWithValue("@idEndereco", clinica.Endereco.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Clínica cadastrada com sucesso";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    return "Clínica já cadastrada.";
                }
                else
                {
                    return "Erro no Banco de dados. Contate o administrador.";
                }
            }
            finally
            {
                conn.Dispose();
            }
        }
        /// <summary>
        /// Tenta deletar, caso der certo retorna (Clinica deletads com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="clinica"></param>
        /// <returns></returns>
        public string Deletar(Clinica clinica)
        {            
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM clinica WHERE idClinica = @ID";
            cmd.Parameters.AddWithValue("@ID", clinica.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Clínica deletada com êxito!";
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
        /// Tenta atualizar, caso der certo retorna (Clinica atualizada com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="clinica"></param>
        /// <returns></returns>
        public string Atualizar(Clinica clinica)
        {
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE clinica SET nomeClinica = @nomeClinica, dtInauguracao = @dtInauguracao WHERE idClinica = @idClinica";
            cmd.Parameters.AddWithValue("@idClinica", clinica.Id);
            cmd.Parameters.AddWithValue("@nomeClinica", clinica.Nome);
            cmd.Parameters.AddWithValue("@dtInauguracao", clinica.DataInauguracao);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Clínica atualizada com êxito!";
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
        /// Retorna Lista com todas as clinicas
        /// </summary>
        /// <returns></returns>
        public List<Clinica> SelecionaTodos()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM clinica";
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Clinica> Clinicas = new List<Clinica>();
                while (reader.Read())
                {
                    Clinica temp = new Clinica();

                    temp.Id = Convert.ToInt32(reader["idClinica"]);
                    temp.Nome = Convert.ToString(reader["nomeClinica"]);
                    temp.DataInauguracao = Convert.ToDateTime(reader["dtInauguracao"]);
                    temp.Endereco.Id = Convert.ToInt32(reader["idEndereco"]);

                    Clinicas.Add(temp);
                }
                return Clinicas;
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
        public Clinica GetByID(int id)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM clinica WHERE idClinica = @ID";
            cmd.Parameters.AddWithValue("@ID", id);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Clinica temp = new Clinica();

                while (reader.Read())
                {


                    temp.Id = Convert.ToInt32(reader["idClinica"]);
                    temp.Nome = Convert.ToString(reader["nomeClinica"]);
                    temp.DataInauguracao = Convert.ToDateTime(reader["dtInauguracao"]);
                    temp.Endereco.Id = Convert.ToInt32(reader["idEndereco"]);


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
        public Clinica GetLastRegister()
        {
            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM clinica ORDER BY idClinica DESC limit 1";

            try
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                Clinica Clinica = new Clinica();

                while (reader.Read())
                {
                    Clinica temp = new Clinica();


                    temp.Id = Convert.ToInt32(reader["idClinica"]);
                    temp.Nome = Convert.ToString(reader["nomeClinica"]);
                    temp.DataInauguracao = Convert.ToDateTime(reader["dtInauguracao"]);
                    temp.Endereco.Id = Convert.ToInt32(reader["idEndereco"]);


                    Clinica = temp;
                }

                return Clinica;
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
