using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Domain;

namespace DataAccessLayer
{
    public class CidadeDAL
    {
        MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
        MySqlCommand cmd = new MySqlCommand();

        public string Inserir(Cidade cidade)
        {
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO cidade (nomeCidade,idEstado) values (@nomeCidade,@idEstado)";

            cmd.Parameters.AddWithValue("@nomeCidade", cidade.Nome);
            cmd.Parameters.AddWithValue("@idEstado", cidade.Estado.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Cidade cadastrada com sucesso";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    return ("Cidade já cadastrado.");
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
        public string Deletar(Cidade cidade)
        {
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM cidade WHERE idCidade = @ID";
            cmd.Parameters.AddWithValue("@ID", cidade.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Cidade deletada com êxito!";
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
        public string Atualizar(Cidade cidade)
        {
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE cidade SET nomeCidade = @nomeCidade WHERE idCidade = @idCidade";
            cmd.Parameters.AddWithValue("@nomeCidade", cidade.Nome);
            cmd.Parameters.AddWithValue("@idCidade", cidade.Id);
    
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Cidade atualizada com êxito!";
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
        public List<Cidade> SelecionaTodos()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM cidade";
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Cidade> Cidades = new List<Cidade>();
                while (reader.Read())
                {
                    Cidade temp = new Cidade();

                    temp.Id = Convert.ToInt32(reader["idCidade"]);
                    temp.Nome = Convert.ToString(reader["nomeCidade"]);
                    temp.Estado.Id = Convert.ToInt32(reader["idEstado"]);
           

                    Cidades.Add(temp);
                }
                return Cidades;
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
        public Cidade GetByID(int id)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM cidade WHERE idCidade = @ID";
            cmd.Parameters.AddWithValue("@ID", id);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Cidade temp = new Cidade();

                while (reader.Read())
                {


                    temp.Id = Convert.ToInt32(reader["idCidade"]);
                    temp.Nome = Convert.ToString(reader["nomeCidade"]);
                    temp.Estado.Id = Convert.ToInt32(reader["idEstado"]);


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
    }
}
