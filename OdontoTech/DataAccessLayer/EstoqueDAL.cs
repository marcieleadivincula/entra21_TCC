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
        public string Inserir(Estoque Estoque)
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
                return "Estoque inserido com sucesso";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    return ("Estoque já cadastrado.");
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
        public string Deletar(Estoque estoque)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
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
                return "Erro no Banco de dados.Contate o administrador.";
            }
            finally
            {
                conn.Dispose();
            }
        }
        public string Atualizar(Estoque Estoque)
        {

            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE estoque SET idProduto = @idProduto, SET qtdProduto = @qtdProduto, SET dtEntrada = @dtEntrada, SET dtSaida = @dtSaida WHERE idEstoque = @idEstoque";

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
            catch (Exception)
            {
                return "Erro no Banco de dados.Contate o administrador.";
            }
            finally
            {
                conn.Dispose();
            }

        }
        public List<Estoque> SelecionaTodos()
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM estoque";
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
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
                throw new Exception("Erro no Banco de dados.Contate o administrador.");
            }
            finally
            {
                conn.Dispose();
            }
        }
    }
}
