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

        public string Inserir(Estoque Estoque)
        {
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO estoque (idProduto,qtdProduto,dtEntrada,dtSaida) values (@idProduto,@qtdProduto,@dtEntrada,@dtSaida)";

            cmd.Parameters.AddWithValue("@idProduto", Estoque.Produto.Id);
            cmd.Parameters.AddWithValue("@qtdProduto", Estoque.QtdProduto);
            cmd.Parameters.AddWithValue("@dtEntrada", Estoque.DataEntrada);
            cmd.Parameters.AddWithValue("@dtSaida", Estoque.DataSaida); 


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Estoque cadastrado com sucesso";
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
        public string Deletar(Estoque estoque)
        {
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM estoque WHERE idEstoque = @ID";
            cmd.Parameters.AddWithValue("@ID", estoque.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Estoque deletado com êxito!";
            }
            catch (Exception)
            {
                return "Erro no Banco de dados. Contate o administrador.";
            }
            finally
            {
                conn.Dispose();
            }
        }
        public string Atualizar(Estoque Estoque)
        {
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE estoque SET idProduto = @idProduto,  qtdProduto = @qtdProduto,  dtEntrada = @dtEntrada,  dtSaida = @dtSaida WHERE idEstoque = @idEstoque";

            cmd.Parameters.AddWithValue("@idEstoque", Estoque.Id);
            cmd.Parameters.AddWithValue("@idProduto", Estoque.Produto.Id);
            cmd.Parameters.AddWithValue("@qtdProduto", Estoque.QtdProduto);
            cmd.Parameters.AddWithValue("@dtEntrada", Estoque.DataEntrada);
            cmd.Parameters.AddWithValue("@dtSaida", Estoque.DataSaida);

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
        public List<Estoque> SelecionaTodos()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM estoque";
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Estoque> Estoques = new List<Estoque>();
                while (reader.Read())
                {
                    Estoque temp = new Estoque();

                    temp.Id = Convert.ToInt32(reader["idEstoque"]);
                    temp.Produto.Id = Convert.ToInt32(reader["idProduto"]);
                    temp.QtdProduto = Convert.ToInt32(reader["qtdProduto"]);
                    temp.DataEntrada = Convert.ToDateTime(reader["dtEntrada"]);
                    temp.DataSaida = Convert.ToDateTime(reader["dtEntrada"]);

                    Estoques.Add(temp);
                }
                return Estoques;
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
        public Estoque GetByID(int id)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM estoque WHERE idEstoque = @ID";
            cmd.Parameters.AddWithValue("@ID", id);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Estoque temp = new Estoque();

                while (reader.Read())
                {

                    temp.Id = Convert.ToInt32(reader["idEstoque"]);
                    temp.Produto.Id = Convert.ToInt32(reader["idProduto"]);
                    temp.QtdProduto = Convert.ToInt32(reader["qtdProduto"]);
                    temp.DataEntrada = Convert.ToDateTime(reader["dtEntrada"]);
                    temp.DataSaida = Convert.ToDateTime(reader["dtEntrada"]);

                }
                return temp;
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
                Estoque Estoque = new Estoque();

                while (reader.Read())
                {
                    Estoque temp = new Estoque();

                    temp.Id = Convert.ToInt32(reader["idEstoque"]);
                    temp.Produto.Id = Convert.ToInt32(reader["idProduto"]);
                    temp.QtdProduto = Convert.ToInt32(reader["qtdProduto"]);
                    temp.DataEntrada = Convert.ToDateTime(reader["dtEntrada"]);
                    temp.DataSaida = Convert.ToDateTime(reader["dtEntrada"]);


                    Estoque = temp;
                }

                return Estoque;
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
