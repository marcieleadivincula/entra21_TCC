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
    class ProdutoDAL
    {
        /// <summary>
        /// Insere o  Produto no BD. Caso houver erro a função informa.
        /// </summary>
        /// <param name="produto"></param>
        public void inserir(Produto produto)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO produto (idProduto,nomeProduto,idTipoEmbalagem,precoProduto,dtCompra) values (@idProduto,@nomeProduto,@idTipoEmbalagem,@precoProduto,@dtCompra)";
            cmd.Parameters.AddWithValue("@idProduto", produto.Id);
            cmd.Parameters.AddWithValue("@nomeProduto", produto.Nome);
            cmd.Parameters.AddWithValue("@idTipoEmbalagem", produto.TipoEmbalagem.Id);
            cmd.Parameters.AddWithValue("@precoProduto", produto.Preco);
            cmd.Parameters.AddWithValue("@dtCompra", Convert.ToString(produto.DataCompra));

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    throw new Exception("Produto já cadastrado.");
                }
                else
                {
                    throw new Exception("Erro no Banco de dados. Contate o administrador.");
                }
            }
            finally
            {
                conn.Dispose();
            }

        }

    }
}
