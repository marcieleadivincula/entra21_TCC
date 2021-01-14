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
    class EstoqueDAL
    {
        public void Inserir(Estoque Estoque)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO estoque (idProduto,qtdProduto,dtEntrada,dtSaida) values (@idProduto,@qtdProduto,@dtEntrada@dtSaida)";

            cmd.Parameters.AddWithValue("@idProduto", Estoque.Produto.Id);
            cmd.Parameters.AddWithValue("@qtdProduto", Estoque.QtdProduto);
            cmd.Parameters.AddWithValue("@dtEntrada", Estoque.DataEntrada);
            cmd.Parameters.AddWithValue("@dtSaida", Estoque.DataSaida); 


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    throw new Exception("Estoque já cadastrado.");
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
