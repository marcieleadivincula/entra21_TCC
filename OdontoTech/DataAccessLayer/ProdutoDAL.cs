using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data.SqlClient;
using Domain;
using MySql.Data.MySqlClient;


namespace DataAccessLayer
{
    public class ProdutoDAL
    {
        /// <summary>
        /// Insere o  Produto no BD. Caso houver erro a função informa.
        /// </summary>
        /// <param name="produto"></param>
        public string Inserir(Produto produto)
        {
            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO produto (nomeProduto,idTipoEmbalagem,precoProduto,dtCompra) values (@nomeProduto,@idTipoEmbalagem,@precoProduto,@dtCompra)";
           
            cmd.Parameters.AddWithValue("@nomeProduto", produto.Nome);
            cmd.Parameters.AddWithValue("@idTipoEmbalagem", produto.TipoEmbalagem.Id);
            cmd.Parameters.AddWithValue("@precoProduto", produto.Preco);
            cmd.Parameters.AddWithValue("@dtCompra", Convert.ToString(produto.DataCompra));

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Produto cadastrado com sucesso";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
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
        public string Deletar(Produto produto)
        {
            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM produto WHERE idProduto = @ID";
            cmd.Parameters.AddWithValue("@ID", produto.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Produto deletado com êxito!";
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
        ///  Tenta atualizar, caso der certo retorna (Produto atualizado com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        public string Atualizar(Produto produto)
        {

            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE produto SET nomeProduto = @nomeProduto, precoProduto = @precoProduto,  dtCompra = @dtCompra WHERE idProduto = @idProduto";
            cmd.Parameters.AddWithValue("@idProduto", produto.Id);
            cmd.Parameters.AddWithValue("@nomeProduto", produto.Nome);
            cmd.Parameters.AddWithValue("@precoProduto", produto.Preco);
            cmd.Parameters.AddWithValue("@dtCompra", Convert.ToString(produto.DataCompra));

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Produto atualizado com êxito!";
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
        public List<Produto> SelecionaTodos()
        {
            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM produto";
            try
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<Produto> Produtos = new List<Produto>();
                while (reader.Read())
                {
                    Produto temp = new Produto();

                    temp.Id = Convert.ToInt32(reader["idProduto"]);
                    temp.Nome = Convert.ToString(reader["nomeProduto"]);
                    temp.TipoEmbalagem.Id = Convert.ToInt32(reader["idTipoEmbalagem"]);
                    temp.Preco = Convert.ToDouble(reader["precoProduto"]);
                    temp.DataCompra = Convert.ToDateTime(reader["dtCompra"]);


                    Produtos.Add(temp);
                }
                return Produtos;
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
        public Produto GetByID(int id)
        {
            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM produto WHERE idProduto = @ID";
            cmd.Parameters.AddWithValue("@ID", id);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Produto temp = new Produto();

                while (reader.Read())
                {

                    temp.Id = Convert.ToInt32(reader["idProduto"]);
                    temp.Nome = Convert.ToString(reader["nomeProduto"]);
                    temp.TipoEmbalagem.Id = Convert.ToInt32(reader["idTipoEmbalagem"]);
                    temp.Preco = Convert.ToDouble(reader["precoProduto"]);
                    temp.DataCompra = Convert.ToDateTime(reader["dtCompra"]);

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
        public Produto GetLastRegister()
        {
            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM produto ORDER BY idProduto DESC limit 1";

            try
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                Produto Produto = new Produto();

                while (reader.Read())
                {
                    Produto temp = new Produto();

                    temp.Id = Convert.ToInt32(reader["idProduto"]);
                    temp.Nome = Convert.ToString(reader["nomeProduto"]);
                    temp.TipoEmbalagem.Id = Convert.ToInt32(reader["idTipoEmbalagem"]);
                    temp.Preco = Convert.ToDouble(reader["precoProduto"]);
                    temp.DataCompra = Convert.ToDateTime(reader["dtCompra"]);


                    Produto = temp;
                }

                return Produto;
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
