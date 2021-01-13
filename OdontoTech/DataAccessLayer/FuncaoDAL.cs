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
        public string Atualizar(Funcao funcao)
        {

            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE funcao SET nomeEstado = @nomeEstado, SET salario = @salario, SET comissao = @comissao WHERE idProduto = @idProduto";


            cmd.Parameters.AddWithValue("@nomeEstado", funcao.Nome);
            cmd.Parameters.AddWithValue("@salario", funcao.Salario);
            cmd.Parameters.AddWithValue("@comissao", funcao.Comissao);
            cmd.Parameters.AddWithValue("@idFuncao", funcao.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Funcao atualizado com êxito!";
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
        public List<Funcao> SelecionaTodos()
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM funcao";
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Funcao> Funcaos = new List<Funcao>();
                while (reader.Read())
                {
                    Funcao temp = new Funcao();

                    temp.Id = Convert.ToInt32(reader["idFuncao"]);
                    temp.Nome = Convert.ToString(reader["nomeFuncao"]);
                    temp.Salario = Convert.ToDouble(reader["salario"]);
                    temp.Comissao = Convert.ToDouble(reader["comissao"]);
;

                    Funcaos.Add(temp);
                }
                return Funcaos;
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
