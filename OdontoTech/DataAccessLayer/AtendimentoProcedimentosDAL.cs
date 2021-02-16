using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Domain;

namespace DataAccessLayer
{
    public class AtendimentoProcedimentosDAL
    {
        MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
        MySqlCommand cmd = new MySqlCommand();

        /// <summary>
        /// Insere o Endereço no BD. Caso houver erro a função informa.
        /// </summary>
        /// <param name="atendimento"></param>
        public string Insert(AtendimentoProcedimentos atendimentoProcedimentos)
        {
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO atendimentoprocedimentos(idProcedimento,idAtendimento, qtdProcedimento) values (@idProcedimento, @idAtendimento, @qtdProcedimento)";
            cmd.Parameters.AddWithValue("@idProcedimento", atendimentoProcedimentos.Procedimento.Id);
            cmd.Parameters.AddWithValue("@idAtendimento", atendimentoProcedimentos.Atendimento.Id);
            cmd.Parameters.AddWithValue("@qtdProcedimento", atendimentoProcedimentos.QtdProcedimento);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Registro cadastrado com sucesso";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    return ("Registro já cadastrado.");
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
        /// Tenta deletar, caso der certo retorna (Atendimento deletado com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="Atendimento"></param>
        /// <returns></returns>
        public string Delete(AtendimentoProcedimentos atendimentoProcedimentos)
        {
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM atendimentoprocedimentos WHERE idAtendimento = @ID";
            cmd.Parameters.AddWithValue("@ID", atendimentoProcedimentos.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Registro deletado com êxito!";
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
        public string Update(AtendimentoProcedimentos atendimentoProcedimentos)
        {
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE atendimentoprocedimentos SET idProcedimento = @idProcedimento, idAtendimento = @idAtendimento, qtdProcedimento = @qtdProcedimento WHERE idAtendimentoProcedimento = @idAtendimentoProcedimento";
            cmd.Parameters.AddWithValue("@idProcedimento", atendimentoProcedimentos.Procedimento.Id);
            cmd.Parameters.AddWithValue("@idAtendimento", atendimentoProcedimentos.Atendimento.Id);
            cmd.Parameters.AddWithValue("@qtdProcedimento", atendimentoProcedimentos.QtdProcedimento);
            cmd.Parameters.AddWithValue("@idAtendimentoProcedimento", atendimentoProcedimentos.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Registro atualizado com êxito!";
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
        public List<AtendimentoProcedimentos> GetAll()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM atendimentoprocedimentos";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<AtendimentoProcedimentos> atendimentoProcedimentos = new List<AtendimentoProcedimentos>();

                while (reader.Read())
                {
                    AtendimentoProcedimentos temp = new AtendimentoProcedimentos();

                    temp.Procedimento = new Procedimento();
                    temp.Atendimento = new Atendimento();

                    temp.Id = Convert.ToInt32(reader["idAtendimentoProcedimento"]);
                    temp.Procedimento.Id = Convert.ToInt32(reader["idProcedimento"]);
                    temp.Atendimento.Id = Convert.ToInt32(reader["idAtendimento"]);
                    temp.QtdProcedimento = Convert.ToInt32(reader["qtdProcedimento"]);

                    atendimentoProcedimentos.Add(temp);
                }
                return atendimentoProcedimentos;
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
        public AtendimentoProcedimentos GetById(int idAtendimentoProcedimento)
        {
            cmd.Connection = conn;
            cmd.CommandText = $"SELECT * FROM atendimentoprocedimentos WHERE idAtendimentoProcedimento = {idAtendimentoProcedimento}";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                AtendimentoProcedimentos atendimentoProcedimentos = new AtendimentoProcedimentos();

                while (reader.Read())
                {
                    atendimentoProcedimentos.Procedimento = new Procedimento();
                    atendimentoProcedimentos.Atendimento = new Atendimento();

                    atendimentoProcedimentos.Id = Convert.ToInt32(reader["idAtendimentoProcedimento"]);
                    atendimentoProcedimentos.Procedimento.Id = Convert.ToInt32(reader["idProcedimento"]);
                    atendimentoProcedimentos.Atendimento.Id = Convert.ToInt32(reader["idAtendimento"]);
                    atendimentoProcedimentos.QtdProcedimento = Convert.ToInt32(reader["qtdProcedimento"]);
                }

                return atendimentoProcedimentos;
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
        public AtendimentoProcedimentos GetLastRegister()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM atendimentoProcedimentos ORDER BY idAtendimentoProcedimento DESC limit 1";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                AtendimentoProcedimentos atendimentoProcedimentos = new AtendimentoProcedimentos();

                while (reader.Read())
                {
                    atendimentoProcedimentos.Procedimento = new Procedimento();
                    atendimentoProcedimentos.Atendimento = new Atendimento();

                    atendimentoProcedimentos.Id = Convert.ToInt32(reader["idAtendimentoProcedimento"]);
                    atendimentoProcedimentos.Procedimento.Id = Convert.ToInt32(reader["idProcedimento"]);
                    atendimentoProcedimentos.Atendimento.Id = Convert.ToInt32(reader["idAtendimento"]);
                    atendimentoProcedimentos.QtdProcedimento = Convert.ToInt32(reader["qtdProcedimento"]);
                }

                return atendimentoProcedimentos;
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
