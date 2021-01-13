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
    public class TipoProcedimentoDAL
    {
        /// <summary>
        /// Insere o  TipoProcedimento no BD. Caso houver erro a função informa.
        /// </summary>
        /// <param name="TipoProcedimento"></param>
        public void Inserir(TipoProcedimento TipoProcedimento)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO tipoprocedimento (nomeTipoProcedimento,valorProcedimento) values (@idTipoProcedimento,@nomeTipoProcedimento,@valorProcedimento)";
          
            cmd.Parameters.AddWithValue("@nomeTipoProcedimento", TipoProcedimento.Nome);
            cmd.Parameters.AddWithValue("@valorProcedimento", TipoProcedimento.Valor);


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    throw new Exception("Tipo Procedimento já cadastrado.");
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
        ///  Tenta deletar, caso der certo retorna (Tipo Procedimento deletado com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="TipoProcedimento"></param>
        /// <returns></returns>
        public string Deletar(TipoProcedimento TipoProcedimento)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM tipoprocedimento WHERE idTipoProcedimento = @ID";
            cmd.Parameters.AddWithValue("@ID", TipoProcedimento.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Tipo Procedimento deletado com êxito!";
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
        /// Tenta atualizar, caso der certo retorna (TipoProcedimento atualizado com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="TipoProcedimento"></param>
        /// <returns></returns>
        public string Atualizar(TipoProcedimento TipoProcedimento)
        {

            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE tipoprocedimento SET nomeTipoProcedimento = @nomeTipoProcedimento, SET valorProcedimento = @valorProcedimento WHERE idTipoProcedimento = @idTipoProcedimento";
            cmd.Parameters.AddWithValue("@nomeTipoProcedimento", TipoProcedimento.Nome);
            cmd.Parameters.AddWithValue("@valorProcedimento", TipoProcedimento.Valor);
            cmd.Parameters.AddWithValue("@idTipoProcedimento", TipoProcedimento.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "TipoProcedimento atualizado com êxito!";
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
        /// retorna lista de tiposprocedimentos
        /// </summary>
        /// <returns></returns>
        public List<TipoProcedimento> SelecionaTodos()
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM tipoprocedimento";
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<TipoProcedimento> TipoProcedimentos = new List<TipoProcedimento>();
                while (reader.Read())
                {
                    TipoProcedimento temp = new TipoProcedimento();

                    temp.Id = Convert.ToInt32(reader["idTipoProcedimento"]);
                    temp.Nome = Convert.ToString(reader["nomeTipoProcedimento"]);
                    temp.Valor = Convert.ToInt32(reader["valorProcedimento"]);

                    TipoProcedimentos.Add(temp);
                }
                return TipoProcedimentos;
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
