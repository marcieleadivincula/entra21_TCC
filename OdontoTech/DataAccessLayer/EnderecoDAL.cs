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
    class EnderecoDAL
    {
        /// <summary>
        /// Insere o Endereço no BD. Caso houver erro a função informa.
        /// </summary>
        /// <param name="endereco"></param>
        public void Inserir(Endereco endereco)
        {

            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO endereco (idEndereco,numeroCasa,cep) values (@idEndereco,@numeroCasa,@cep)";
            cmd.Parameters.AddWithValue("@idEndereco", endereco.Id);
            cmd.Parameters.AddWithValue("@numeroCasa", endereco.NumeroCasa);
            cmd.Parameters.AddWithValue("@cep", endereco.Cep);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    throw new Exception("Endereço já cadastrado.");
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


        /// <summary>
        /// Tenta deletar, caso der certo retorna (Endereço deletado com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns></returns>
        public string Deletar(Endereco endereco)
        {

            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM endereco WHERE idEndereco = @ID";
            cmd.Parameters.AddWithValue("@ID", endereco.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Endereço deletado com êxito!";
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
        /// Tenta atualizar, caso der certo retorna (Endereço atualizado com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns></returns>
        public string Atualizar(Endereco endereco)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE endereco SET idlogradouro = @idlogradouro, SET numeroCasa = @numeroCasa SET cep = @cep WHERE idEndereco = @idEndereco";
            cmd.Parameters.AddWithValue("@idEndereco", endereco.Id);
            cmd.Parameters.AddWithValue("@idlogradouro", endereco.Logradouro.Id);
            cmd.Parameters.AddWithValue("@numeroCasa", endereco.NumeroCasa);
            cmd.Parameters.AddWithValue("@cep", endereco.Cep);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Endereço atualizado com êxito!";
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

        public List<Endereco> SelecionaTodos()
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM MARCA";
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Endereco> enderecos = new List<Endereco>();
                while (reader.Read())
                {
                    Endereco temp = new Endereco();

                    temp.Id = Convert.ToInt32(reader["idEndereco"]);
                    temp.Logradouro.Id = Convert.ToInt32(reader["idLogradouro"]);
                    temp.NumeroCasa = Convert.ToInt32(reader["numeroCasa"]);
                    temp.Cep = Convert.ToString(reader["cep"]);


                    enderecos.Add(temp);
                }
                return enderecos;
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