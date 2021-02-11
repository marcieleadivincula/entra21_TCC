using System;
using System.Collections.Generic;
using Domain;
using MySql.Data.MySqlClient;


namespace DataAccessLayer
{
    public class ProdutoDAL
    {
        MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
        MySqlCommand cmd = new MySqlCommand();

        /// <summary>
        /// Insere o  Produto no BD. Caso houver erro a função informa.
        /// </summary>
        /// <param name="produto"></param>
        public string Insert(Produto produto)
        {
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO produto(nomeProduto, idTipoEmbalagem, precoProduto, dtCompra) values(@nomeProduto, @idTipoEmbalagem, @precoProduto, @dtCompra)";
            cmd.Parameters.AddWithValue("@nomeProduto", produto.Nome);
            cmd.Parameters.AddWithValue("@idTipoEmbalagem", produto.TipoEmbalagem.Id);
            cmd.Parameters.AddWithValue("@precoProduto", produto.Preco);
            cmd.Parameters.AddWithValue("@dtCompra", produto.DataCompra);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Produto cadastrado com sucesso !";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    return ("Produto já cadastrado.");
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
        /// Tenta deletar, caso der certo retorna (Produto deletado com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        public string Delete(Produto produto)
        {
            if (produto.Id == 0)
            {
                return "Produto informado inválido!";
            }

            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM produto WHERE idProduto = @idProduto";
            cmd.Parameters.AddWithValue("@idProduto", produto.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Produto deletado com êxito!";
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
        /// <summary>
        ///  Tenta atualizar, caso der certo retorna (Produto atualizado com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        public string Update(Produto produto)
        {
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE produto SET nomeProduto = @nomeProduto, idTipoEmbalagem = @idTipoEmbalagem, precoProduto = @precoProduto,  dtCompra = @dtCompra WHERE idProduto = @idProduto";
            cmd.Parameters.AddWithValue("@nomeProduto", produto.Nome);
            cmd.Parameters.AddWithValue("@idTipoEmbalagem", produto.TipoEmbalagem.Id);
            cmd.Parameters.AddWithValue("@precoProduto", produto.Preco);
            cmd.Parameters.AddWithValue("@dtCompra", produto.DataCompra);
            cmd.Parameters.AddWithValue("@idProduto", produto.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Produto atualizado com êxito!";
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
        public List<Produto> GetAll()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM produto";
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Produto> produtos = new List<Produto>();

                while (reader.Read())
                {
                    Produto temp = new Produto();
                    temp.Id = Convert.ToInt32(reader["idProduto"]);
                    temp.Nome = Convert.ToString(reader["nomeProduto"]);
                    temp.TipoEmbalagem.Id = Convert.ToInt32(reader["idTipoEmbalagem"]);
                    temp.Preco = Convert.ToDouble(reader["precoProduto"]);
                    temp.DataCompra = Convert.ToDateTime(reader["dtCompra"]);

                    produtos.Add(temp);
                }

                return produtos;
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
        public Produto GetById(int idProduto)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM produto WHERE idProduto = @idProduto";
            cmd.Parameters.AddWithValue("@idProduto", idProduto);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Produto produto = new Produto();

                while (reader.Read())
                {
                    produto.Id = Convert.ToInt32(reader["idProduto"]);
                    produto.Nome = Convert.ToString(reader["nomeProduto"]);
                    produto.TipoEmbalagem.Id = Convert.ToInt32(reader["idTipoEmbalagem"]);
                    produto.Preco = Convert.ToDouble(reader["precoProduto"]);
                    produto.DataCompra = Convert.ToDateTime(reader["dtCompra"]);
                }

                return produto;
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
        public Produto GetLastRegister()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM produto ORDER BY idProduto DESC limit 1";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Produto produto = new Produto();

                while (reader.Read())
                {
                    produto.Id = Convert.ToInt32(reader["idProduto"]);
                    produto.Nome = Convert.ToString(reader["nomeProduto"]);
                    produto.TipoEmbalagem.Id = Convert.ToInt32(reader["idTipoEmbalagem"]);
                    produto.Preco = Convert.ToDouble(reader["precoProduto"]);
                    produto.DataCompra = Convert.ToDateTime(reader["dtCompra"]);
                }

                return produto;
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
        public List<Produto> GetByTipoEmbalagem(TipoEmbalagem tipoEmbalagem)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM produto WHERE idTipoEmbalagem = @idTipoEmbalagem";
            cmd.Parameters.AddWithValue("@idTipoEmbalagem", tipoEmbalagem.Id);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Produto> produtos = new List<Produto>();

                while (reader.Read())
                {
                    Produto temp = new Produto();
                    temp.Id = Convert.ToInt32(reader["idProduto"]);
                    temp.Nome = Convert.ToString(reader["nomeProduto"]);
                    temp.TipoEmbalagem.Id = Convert.ToInt32(reader["idTipoEmbalagem"]);
                    temp.Preco = Convert.ToDouble(reader["precoProduto"]);
                    temp.DataCompra = Convert.ToDateTime(reader["dtCompra"]);

                    produtos.Add(temp);
                }

                return produtos;
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
