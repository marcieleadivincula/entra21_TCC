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
    class EstadoDAL
    {
        /// <summary>
        /// Insere o  Estado no BD. Caso houver erro a função informa.
        /// </summary>
        /// <param name="estado"></param>
        public void Inserir(Estado estado)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO estado (idEstado,nomeEstado,idPais) values (@idEstado,@nomeEstado,@idPais)";
            cmd.Parameters.AddWithValue("@idEstado", estado.Id);
            cmd.Parameters.AddWithValue("@nomeEstado", estado.Nome);
            cmd.Parameters.AddWithValue("@idPais", estado.Pais.Id);


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    throw new Exception("Estado já cadastrado.");
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
        ///  Tenta deletar, caso der certo retorna (Estado deletado com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public string Deletar(Estado estado)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM estado WHERE idEstado = @ID";
            cmd.Parameters.AddWithValue("@ID", estado.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Estado deletado com êxito!";
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
        /// Tenta atualizar, caso der certo retorna (Estado atualizado com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public string Atualizar(Estado estado)
        {

            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE estado SET nomeProduto = @nomeProduto, SET idPais = @idPais WHERE idProduto = @idProduto";
            cmd.Parameters.AddWithValue("@nomeEstado", estado.Nome);
            cmd.Parameters.AddWithValue("@idPais", estado.Pais.Id);
            cmd.Parameters.AddWithValue("@idEstado", estado.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Estado atualizado com êxito!";
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
    }
}
