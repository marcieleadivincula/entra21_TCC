using MySql.Data.MySqlClient;
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
    public class AtendimentoDAL
    {
        MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
        MySqlCommand cmd = new MySqlCommand();

        /// <summary>
        /// Insere o Endereço no BD. Caso houver erro a função informa.
        /// </summary>
        /// <param name="atendimento"></param>
        public string Insert(Atendimento atendimento)
        {
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO atendimento (idPaciente,idColaborador) values (@idPaciente,@idColaborador)";

            cmd.Parameters.AddWithValue("@idPaciente", atendimento.Paciente.Id);
            cmd.Parameters.AddWithValue("@idColaborador", atendimento.Colaborador.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Atendimento cadastrado com sucesso";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    return ("Atendimento já cadastrado.");
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
        public string Delete(Atendimento Atendimento)
        {
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
        public string Update(Atendimento Atendimento)
        {
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE atendimento SET idPaciente = @idPaciente, idColaborador = @idColaborador WHERE idAtendimento = @idAtendimento";
            cmd.Parameters.AddWithValue("@idPaciente", Atendimento.Paciente.Id);
            cmd.Parameters.AddWithValue("@idColaborador", Atendimento.Colaborador.Id);
            cmd.Parameters.AddWithValue("@idAtendimento", Atendimento.Id);

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
        public List<Atendimento> GetAll()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM atendimento";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Atendimento> atendimentos = new List<Atendimento>();

                while (reader.Read())
                {
                    Atendimento temp = new Atendimento();

                    temp.Id = Convert.ToInt32(reader["idAtendimento"]);
                    temp.Paciente.Id = Convert.ToInt32(reader["idPaciente"]);
                    temp.Colaborador.Id = Convert.ToInt32(reader["idColaborador"]);

                    atendimentos.Add(temp);
                }
                return atendimentos;
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
        public Atendimento GetById(int id)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM atendimento WHERE idAtendimento = @Id";
            cmd.Parameters.AddWithValue("@Id", id);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Atendimento atendimento = new Atendimento();

                while (reader.Read())
                {
                    Atendimento temp = new Atendimento();

                    temp.Id = Convert.ToInt32(reader["idAtendimento"]);
                    temp.Paciente.Id = Convert.ToInt32(reader["idPaciente"]);
                    temp.Colaborador.Id = Convert.ToInt32(reader["idColaborador"]);

                    atendimento = temp;
                }

                return atendimento;
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
        public Atendimento GetLastRegister()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM atendimento ORDER BY idAtendimento DESC limit 1";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Atendimento atendimento = new Atendimento();

                while (reader.Read())
                {
                    Atendimento temp = new Atendimento();

                    temp.Id = Convert.ToInt32(reader["idAtendimento"]);
                    temp.Paciente.Id = Convert.ToInt32(reader["idPaciente"]);
                    temp.Colaborador.Id = Convert.ToInt32(reader["idColaborador"]);

                    atendimento = temp;
                }

                return atendimento;
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
        public List<Procedimento> GetProcedimentos(int idAtendimento)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM atendimentoprocedimentos ap INNER JOIN procedimento p ON ap.idProcedimento = p.idProcedimento WHERE ap.idAtendimento = @ID";
            cmd.Parameters.AddWithValue("@ID", idAtendimento);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Procedimento> procedimentos = new List<Procedimento>();

                while (reader.Read())
                {
                    Procedimento temp = new Procedimento();

                    temp.Id = Convert.ToInt32(reader["idProcedimento"]);
                    temp.Nome = Convert.ToString(reader["nomeProcedimento"]);
                    temp.DescricaoProcedimento = Convert.ToString(reader["dsProcedimento"]);
                    temp.TipoProcedimento.Id = Convert.ToInt32(reader["idTipoProcedimento"]);

                    procedimentos.Add(temp);
                }
                return procedimentos;
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
