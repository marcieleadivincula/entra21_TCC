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
    public class FuncaoDAL
    {
        /// <summary>
        /// Insere Funcao caso der erro informa.
        /// </summary>
        /// <param name="funcao"></param>
        public void Inserir(Funcao funcao)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO funcao (nomeFuncao,salario,comissao) values (@nomeFuncao,@salario,@comissao)";

            cmd.Parameters.AddWithValue("@nomeEstado", funcao.Nome);
            cmd.Parameters.AddWithValue("@salario", funcao.Salario);
            cmd.Parameters.AddWithValue("@comissao", funcao.Comissao);


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    throw new Exception("Funcao já cadastrado.");
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
        public string Deletar(Funcao funcao)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM funcao WHERE idFuncao = @ID";
            cmd.Parameters.AddWithValue("@ID", funcao.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Funcao deletado com êxito!";
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
