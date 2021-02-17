using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Domain;

namespace DataAccessLayer
{
    public class EstoqueDAL
    {
        MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
        MySqlCommand cmd = new MySqlCommand();
        public string Insert(Estoque estoque)
        {
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO estoque(idProduto, qtdProduto, dtEntrada, dtSaida) values (@idProduto, @qtdProduto, @dtEntrada, @dtSaida)";
            cmd.Parameters.AddWithValue("@idProduto", estoque.Produto.Id);
            cmd.Parameters.AddWithValue("@qtdProduto", estoque.QtdProduto);
            cmd.Parameters.AddWithValue("@dtEntrada", estoque.DataEntrada);
            cmd.Parameters.AddWithValue("@dtSaida", estoque.DataSaida);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Estoque cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    return ("Estoque já cadastrado.");
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
        public string Delete(Estoque estoque)
        {
            if (estoque.Id == 0)
            {
                return "Estoque informado inválido!";
            }

            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM estoque WHERE idEstoque = @idEstoque";
            cmd.Parameters.AddWithValue("@idEstoque", estoque.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Estoque deletado com êxito!";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "Erro no Banco de dados. Contate o administrador.";
            }
            finally
            {
                conn.Dispose();
            }
        }
        public string Update(Estoque estoque)
        {
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE estoque SET idProduto = @idProduto,  qtdProduto = @qtdProduto,  dtEntrada = @dtEntrada,  dtSaida = @dtSaida WHERE idEstoque = @idEstoque";
            cmd.Parameters.AddWithValue("@idProduto", estoque.Produto.Id);
            cmd.Parameters.AddWithValue("@qtdProduto", estoque.QtdProduto);
            cmd.Parameters.AddWithValue("@dtEntrada", estoque.DataEntrada);
            cmd.Parameters.AddWithValue("@dtSaida", estoque.DataSaida);
            cmd.Parameters.AddWithValue("@idEstoque", estoque.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Estoque atualizado com êxito!";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "Erro no Banco de dados. Contate o administrador.";
            }
            finally
            {
                conn.Dispose();
            }

        }
        public List<Estoque> GetAll()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM estoque";
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Estoque> estoques = new List<Estoque>();

                while (reader.Read())
                {
                    Estoque temp = new Estoque();

                    temp.Produto = new Produto();
                    temp.Id = Convert.ToInt32(reader["idEstoque"]);
                    temp.Produto.Id = Convert.ToInt32(reader["idProduto"]);
                    temp.QtdProduto = Convert.ToInt32(reader["qtdProduto"]);
                    temp.DataEntrada = Convert.ToDateTime(reader["dtEntrada"]);
                    temp.DataSaida = Convert.ToDateTime(reader["dtSaida"]);

                    estoques.Add(temp);
                }

                return estoques;
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
        public Estoque GetById(int idEstoque)
        {
            cmd.Connection = conn;
            cmd.CommandText = $"SELECT * FROM estoque WHERE idEstoque = {idEstoque}";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Estoque estoque = new Estoque();

                while (reader.Read())
                {
                    estoque.Produto = new Produto();
                    estoque.Id = Convert.ToInt32(reader["idEstoque"]);
                    estoque.Produto.Id = Convert.ToInt32(reader["idProduto"]);
                    estoque.QtdProduto = Convert.ToInt32(reader["qtdProduto"]);
                    estoque.DataEntrada = Convert.ToDateTime(reader["dtEntrada"]);
                    estoque.DataSaida = Convert.ToDateTime(reader["dtSaida"]);
                }

                return estoque;
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
        public Estoque GetLastRegister()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM estoque ORDER BY idEstoque DESC limit 1";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Estoque estoque = new Estoque();

                while (reader.Read())
                {
                    estoque.Produto = new Produto();
                    estoque.Id = Convert.ToInt32(reader["idEstoque"]);
                    estoque.Produto.Id = Convert.ToInt32(reader["idProduto"]);
                    estoque.QtdProduto = Convert.ToInt32(reader["qtdProduto"]);
                    estoque.DataEntrada = Convert.ToDateTime(reader["dtEntrada"]);
                    estoque.DataSaida = Convert.ToDateTime(reader["dtSaida"]);
                }

                return estoque;
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
        public List<Estoque> GetByProduto(Produto produto)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM estoque WHERE idProduto = @idProduto";
            cmd.Parameters.AddWithValue("@idProduto", produto.Id);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Estoque> estoques = new List<Estoque>();

                while (reader.Read())
                {
                    Estoque temp = new Estoque();
                    temp.Produto = new Produto();
                    temp.Id = Convert.ToInt32(reader["idEstoque"]);
                    temp.Produto.Id = Convert.ToInt32(reader["idProduto"]);
                    temp.QtdProduto = Convert.ToInt32(reader["qtdProduto"]);
                    temp.DataEntrada = Convert.ToDateTime(reader["dtEntrada"]);
                    temp.DataSaida = Convert.ToDateTime(reader["dtSaida"]);

                    estoques.Add(temp);
                }

                return estoques;
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
