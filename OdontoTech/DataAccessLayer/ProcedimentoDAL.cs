﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data.SqlClient;
using Domain;
using MySql.Data.MySqlClient;
namespace DataAccessLayer
{
    public class ProcedimentoDAL
    {
        /// <summary>
        /// Inserir procedimento
        /// </summary>
        /// <param name="procedimento"></param>
        public string Inserir(Procedimento procedimento)
        {
            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO procedimento (nomeProcedimento,dsProcedimento,idTipoProcedimento) values (@nomeProcedimento,@dsProcedimento,@idTipoProcedimento)";
            
            cmd.Parameters.AddWithValue("@nomeProcedimento", procedimento.Nome);
            cmd.Parameters.AddWithValue("@dsProcedimento", procedimento.DescricaoProcedimento);
            cmd.Parameters.AddWithValue("@idTipoProcedimento", procedimento.TipoProcedimento.Id);


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Procedimento cadastrado com sucesso";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    return ("Procedimento já cadastrado.");
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
        /// Tenta deletar, caso der certo retorna (Procedimento deletado com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="procedimento"></param>
        /// <returns></returns>
        public string Deletar(Procedimento procedimento)
        {
            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM procedimento WHERE idProcedimento = @ID";
            cmd.Parameters.AddWithValue("@ID", procedimento.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Procedimento deletado com êxito!";
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
        /// Tenta atualizar, caso der certo retorna (Procedimento atualizado com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="procedimento"></param>
        /// <returns></returns>
        public string Atualizar(Procedimento procedimento)
        {

            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE procedimento SET nomeProcedimento = @nomeProcedimento, dsProcedimento = @dsProcedimento WHERE idProcedimento = @idProcedimento";
            cmd.Parameters.AddWithValue("@idProcedimento", procedimento.Id);
            cmd.Parameters.AddWithValue("@nomeProcedimento", procedimento.Nome);
            cmd.Parameters.AddWithValue("@dsProcedimento", procedimento.DescricaoProcedimento);


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Procedimento atualizado com êxito!";
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
        /// retorna lista com todos os Procedimentos 
        /// </summary>
        /// <returns></returns>
        public List<Procedimento> SelecionaTodos()
        {
            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM procedimento";
            try
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<Procedimento> Procedimentos = new List<Procedimento>();
                while (reader.Read())
                {
                    Procedimento temp = new Procedimento();

                    temp.Id = Convert.ToInt32(reader["idProcedimento"]);
                    temp.Nome = Convert.ToString(reader["nomeProcedimento"]);
                    temp.DescricaoProcedimento = Convert.ToString(reader["dsProcedimento"]);
                    temp.TipoProcedimento.Id = Convert.ToInt32(reader["idTipoProcedimento"]);
                 


                    Procedimentos.Add(temp);
                }
                return Procedimentos;
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
        public Procedimento GetByID(int id)
        {
            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM procedimento WHERE idProcedimento = @ID";
            cmd.Parameters.AddWithValue("@ID", id);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Procedimento temp = new Procedimento();

                while (reader.Read())
                {

                    temp.Id = Convert.ToInt32(reader["idProcedimento"]);
                    temp.Nome = Convert.ToString(reader["nomeProcedimento"]);
                    temp.DescricaoProcedimento = Convert.ToString(reader["dsProcedimento"]);
                    temp.TipoProcedimento.Id = Convert.ToInt32(reader["idTipoProcedimento"]);

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
        public Procedimento GetLastRegister()
        {
            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM procedimento ORDER BY idProcedimento DESC limit 1";

            try
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                Procedimento Procedimento = new Procedimento();

                while (reader.Read())
                {
                    Procedimento temp = new Procedimento();

                    temp.Id = Convert.ToInt32(reader["idProcedimento"]);
                    temp.Nome = Convert.ToString(reader["nomeProcedimento"]);
                    temp.DescricaoProcedimento = Convert.ToString(reader["dsProcedimento"]);
                    temp.TipoProcedimento.Id = Convert.ToInt32(reader["idTipoProcedimento"]);


                    Procedimento = temp;
                }

                return Procedimento;
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
