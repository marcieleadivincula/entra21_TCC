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
    public class TipoEmbalagemDAL
    {
        /// <summary>
        /// Insere o  Tipo Embalagem no BD. Caso houver erro a função informa.
        /// </summary>
        /// <param name="TipoEmbalagem"></param>
        public string Inserir(TipoEmbalagem TipoEmbalagem)
        {

            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO tipoembalagem (descricao) values (@descricao)";
           
            cmd.Parameters.AddWithValue("@descricao", TipoEmbalagem.Descricao);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Tipo de embalagem cadastrado com sucesso";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    return ("Tipo Embalagem já cadastrada.");
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
        ///  Tenta deletar, caso der certo retorna (Tipo Embalagem deletado com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="TipoEmbalagem"></param>
        /// <returns></returns>
        public string Deletar(TipoEmbalagem TipoEmbalagem)
        {

            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM tipoembalagem WHERE idTipoEmbalagem = @ID";
            cmd.Parameters.AddWithValue("@ID", TipoEmbalagem.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Tipo Embalagem deletado com êxito!";
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

        /// <summary>
        /// Tenta atualizar, caso der certo retorna (TipoEmbalagem atualizado com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="TipoEmbalagem"></param>
        /// <returns></returns>
        public string Atualizar(TipoEmbalagem TipoEmbalagem)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE tipoembalagem SET descricao = @descricao WHERE idTipoEmbalagem = @idTipoEmbalagem";
            cmd.Parameters.AddWithValue("@idTipoEmbalagem", TipoEmbalagem.Id);
            cmd.Parameters.AddWithValue("@descricao", TipoEmbalagem.Descricao);


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "TipoEmbalagem atualizado com êxito!";
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
/// retorna uma lista com todos os tipos de embalagens.
/// </summary>
/// <returns></returns>
        public List<TipoEmbalagem> SelecionaTodos()
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM tipoembalagem";
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<TipoEmbalagem> TipoEmbalagems = new List<TipoEmbalagem>();
                while (reader.Read())
                {
                    TipoEmbalagem temp = new TipoEmbalagem();

                    temp.Id = Convert.ToInt32(reader["idTipoEmbalagem"]);
                    temp.Descricao = Convert.ToString(reader["descricao"]);

                    TipoEmbalagems.Add(temp);
                }
                return TipoEmbalagems;
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
        public TipoEmbalagem GetByID(int id)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM tipoembalagem WHERE idTipoEmbalagem = @ID";
            cmd.Parameters.AddWithValue("@ID", id);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                TipoEmbalagem temp = new TipoEmbalagem();

                while (reader.Read())
                {
                    temp.Id = Convert.ToInt32(reader["idTipoEmbalagem"]);
                    temp.Descricao = Convert.ToString(reader["descricao"]);
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
    }
}
