using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Domain;
using MySql.Data.MySqlClient;


namespace DataAccessLayer
{
    public class TipoProcedimentoDAL
    {

        MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
        MySqlCommand cmd = new MySqlCommand();

        /// <summary>
        /// Insere o  TipoProcedimento no BD. Caso houver erro a função informa.
        /// </summary>
        /// <param name="TipoProcedimento"></param>
        public string Insert(TipoProcedimento tipoProcedimento)
        {
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO tipoprocedimento(nomeTipoProcedimento, valorProcedimento) values(@nomeTipoProcedimento, @valorProcedimento)";
            cmd.Parameters.AddWithValue("@nomeTipoProcedimento", tipoProcedimento.Nome);
            cmd.Parameters.AddWithValue("@valorProcedimento", tipoProcedimento.Valor);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Tipo de procedimento cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    return ("Tipo de procedimento já cadastrado.");
                }
                else
                {
                    Console.WriteLine(ex);
                    return ("Erro no Banco de dados. Contate o administrador.");
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
        public string Delete(TipoProcedimento tipoProcedimento)
        {
            if (tipoProcedimento.Id == 0)
            {
                return "Tipo de procedimento informado inválido!";
            }

            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM tipoprocedimento WHERE idTipoProcedimento = @idTipoProcedimento";
            cmd.Parameters.AddWithValue("@idTipoProcedimento", tipoProcedimento.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Tipo de procedimento deletado com êxito!";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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
        public string Update(TipoProcedimento tipoProcedimento)
        {
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE tipoprocedimento SET nomeTipoProcedimento = @nomeTipoProcedimento,  valorProcedimento = @valorProcedimento WHERE idTipoProcedimento = @idTipoProcedimento";
            cmd.Parameters.AddWithValue("@nomeTipoProcedimento", tipoProcedimento.Nome);
            cmd.Parameters.AddWithValue("@valorProcedimento", tipoProcedimento.Valor);
            cmd.Parameters.AddWithValue("@idTipoProcedimento", tipoProcedimento.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Tipo de procedimento atualizado com êxito!";
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
        public List<TipoProcedimento> GetAll()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM tipoprocedimento";
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<TipoProcedimento> tiposDeProcedimentos = new List<TipoProcedimento>();

                while (reader.Read())
                {
                    TipoProcedimento temp = new TipoProcedimento();
                    temp.Id = Convert.ToInt32(reader["idTipoProcedimento"]);
                    temp.Nome = Convert.ToString(reader["nomeTipoProcedimento"]);
                    temp.Valor = Convert.ToInt32(reader["valorProcedimento"]);

                    tiposDeProcedimentos.Add(temp);
                }

                return tiposDeProcedimentos;
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
        public TipoProcedimento GetById(int idTipoProcedimento)
        {
            cmd.Connection = conn;
            cmd.CommandText = $"SELECT * FROM tipoprocedimento WHERE idTipoProcedimento = {idTipoProcedimento}";


            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                TipoProcedimento tipoProcedimento = new TipoProcedimento();

                while (reader.Read())
                {
                    tipoProcedimento.Id = Convert.ToInt32(reader["idTipoProcedimento"]);
                    tipoProcedimento.Nome = Convert.ToString(reader["nomeTipoProcedimento"]);
                    tipoProcedimento.Valor = Convert.ToInt32(reader["valorProcedimento"]);
                }

                return tipoProcedimento;
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
        public TipoProcedimento GetLastRegister()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM tipoprocedimento ORDER BY idTipoProcedimento DESC limit 1";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                TipoProcedimento tipoProcedimento = new TipoProcedimento();

                while (reader.Read())
                {
                    tipoProcedimento.Id = Convert.ToInt32(reader["idTipoProcedimento"]);
                    tipoProcedimento.Nome = Convert.ToString(reader["nomeTipoProcedimento"]);
                    tipoProcedimento.Valor = Convert.ToInt32(reader["valorProcedimento"]);
                }

                return tipoProcedimento;
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
