﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data.SqlClient;
using Domain;
namespace DataAccessLayer
{
    public class AtendimentoDAL
    {

        /// <summary>
        /// Insere o Endereço no BD. Caso houver erro a função informa.
        /// </summary>
        /// <param name="Atendimento"></param>
        public string Inserir(Atendimento Atendimento)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO atendimento (idPaciente,idColaborador) values (@idPaciente,@idColaborador)";
  
            cmd.Parameters.AddWithValue("@idPaciente", Atendimento.Paciente.Id);
            cmd.Parameters.AddWithValue("@idColaborador", Atendimento.Colaborador.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Atendimento inserido com sucesso";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    return ("Atendimento já cadastrado.");
                }
                else
                {
                    return("Erro no Banco de dados. Contate o administrador.");
                }
            }
            finally
            {
                conn.Dispose();
            }
        }

        /// <summary>
        /// Tenta deletar, caso der certo retorna (Atendimento deletado com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="Atendimento"></param>
        /// <returns></returns>
        public string Deletar(Atendimento Atendimento)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM atendimento WHERE idAtendimento = @ID";
            cmd.Parameters.AddWithValue("@ID", Atendimento.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Atendimento deletado com êxito!";
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
        /// Tenta atualizar, caso der certo retorna (Atendimento atualizado com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns></returns>
        public string Atualizar(Atendimento Atendimento)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE atendimento SET idPaciente = @idPacientem, SET idColaborador = @idColaborador WHERE idAtendimento = @idAtendimento";
            cmd.Parameters.AddWithValue("@idPacientem", Atendimento.Paciente.Id);
            cmd.Parameters.AddWithValue("@idColaborador", Atendimento.Colaborador.Id);
            cmd.Parameters.AddWithValue("@idAtendimento", Atendimento.Id );

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Atendimento atualizado com êxito!";
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
        /// retorna lista com todos os atendimentos 
        /// </summary>
        /// <returns></returns>
        public List<Atendimento> SelecionaTodos()
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM atendimento";
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Atendimento> Atendimentos = new List<Atendimento>();
                while (reader.Read())
                {
                    Atendimento temp = new Atendimento();

                    temp.Id = Convert.ToInt32(reader["idAtendimento"]);
                    temp.Paciente.Id = Convert.ToInt32(reader["idPaciente"]);
                    temp.Colaborador.Id = Convert.ToInt32(reader["idColaborador"]);

                    Atendimentos.Add(temp);
                }
                return Atendimentos;
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
