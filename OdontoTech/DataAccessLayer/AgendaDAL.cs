using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Domain;

namespace DataAccessLayer
{
    public class AgendaDAL
    {
        MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
        MySqlCommand cmd = new MySqlCommand();
        public string Insert(Agenda agenda)
        {
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO agenda(idPaciente, idColaborador, dtAgenda) values(@idPaciente, @idColaborador, @dtAgenda)";
            cmd.Parameters.AddWithValue("@idPaciente", agenda.Paciente.Id);
            cmd.Parameters.AddWithValue("@idColaborador", agenda.Colaborador.Id);
            cmd.Parameters.AddWithValue("@dtAgenda", agenda.DtAgenda);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Agenda cadastrada com sucesso";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    return ("Agenda já cadastrado.");
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
        public string Delete(Agenda agenda)
        {
            if (agenda.Id == 0)
            {
                return "Agenda informada inválido!";
            }

            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM agenda WHERE idAgenda = @idAgenda";
            cmd.Parameters.AddWithValue("@idAgenda", agenda.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Agenda deletada com êxito!";
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
        public string Update(Agenda agenda)
        {
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE agenda SET idPaciente = @idPaciente, idColaborador = @idColaborador, dtAgenda = @dtAgenda WHERE idAgenda = @idAgenda";
            cmd.Parameters.AddWithValue("@idPaciente", agenda.Paciente.Id);
            cmd.Parameters.AddWithValue("@idColaborador", agenda.Colaborador.Id);
            cmd.Parameters.AddWithValue("@dtAgenda", agenda.DtAgenda);
            cmd.Parameters.AddWithValue("@idAgenda", agenda.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Agenda atualizada com êxito!";
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
        public List<Agenda> GetAll()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM agenda";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Agenda> agendas = new List<Agenda>();

                while (reader.Read())
                {
                    Agenda temp = new Agenda();

                    temp.Paciente = new Paciente();
                    temp.Colaborador = new Colaborador();

                    temp.Id = Convert.ToInt32(reader["idAgenda"]);
                    temp.Paciente.Id = Convert.ToInt32(reader["idPaciente"]);
                    temp.Colaborador.Id = Convert.ToInt32(reader["idColaborador"]);
                    temp.DtAgenda = Convert.ToDateTime(reader["dtAgenda"]);

                    agendas.Add(temp);
                }

                return agendas;
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
        public Agenda GetById(int idAgenda)
        {
            cmd.Connection = conn;
            cmd.CommandText = $"SELECT * FROM agenda WHERE idAgenda = {idAgenda}";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Agenda agenda = new Agenda();

                while (reader.Read())
                {
                    agenda.Paciente = new Paciente();
                    agenda.Colaborador = new Colaborador();

                    agenda.Id = Convert.ToInt32(reader["idAgenda"]);
                    agenda.Paciente.Id = Convert.ToInt32(reader["idPaciente"]);
                    agenda.Colaborador.Id = Convert.ToInt32(reader["idColaborador"]);
                    agenda.DtAgenda = Convert.ToDateTime(reader["dtAgenda"]);
                }

                return agenda;
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
        public Agenda GetLastRegister()
        {
            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM agenda ORDER BY idAgenda DESC limit 1";

            try
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                Agenda agenda = new Agenda();

                while (reader.Read())
                {
                    agenda.Paciente = new Paciente();
                    agenda.Colaborador = new Colaborador();

                    agenda.Id = Convert.ToInt32(reader["idAgenda"]);
                    agenda.Paciente.Id = Convert.ToInt32(reader["idPaciente"]);
                    agenda.Colaborador.Id = Convert.ToInt32(reader["idColaborador"]);
                    agenda.DtAgenda = Convert.ToDateTime(reader["dtAgenda"]);
                }

                return agenda;
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

        public List<Agenda> GetByPaciente(Paciente paciente)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM agenda WHERE idPaciente = @idPaciente";
            cmd.Parameters.AddWithValue("@idPaciente", paciente.Id);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Agenda> agendas = new List<Agenda>();

                while (reader.Read())
                {
                    Agenda temp = new Agenda();

                    temp.Paciente = new Paciente();
                    temp.Colaborador = new Colaborador();

                    temp.Id = Convert.ToInt32(reader["idAgenda"]);
                    temp.Paciente.Id = Convert.ToInt32(reader["idPaciente"]);
                    temp.Colaborador.Id = Convert.ToInt32(reader["idColaborador"]);
                    temp.DtAgenda = Convert.ToDateTime(reader["dtAgenda"]);

                    agendas.Add(temp);
                }

                return agendas;
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

        public List<Agenda> GetByColaborador(Colaborador colaborador)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM agenda WHERE idColaborador = @idColaborador";
            cmd.Parameters.AddWithValue("@idColaborador", colaborador.Id);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Agenda> agendas = new List<Agenda>();

                while (reader.Read())
                {
                    Agenda temp = new Agenda();

                    temp.Paciente = new Paciente();
                    temp.Colaborador = new Colaborador();

                    temp.Id = Convert.ToInt32(reader["idAgenda"]);
                    temp.Paciente.Id = Convert.ToInt32(reader["idPaciente"]);
                    temp.Colaborador.Id = Convert.ToInt32(reader["idColaborador"]);
                    temp.DtAgenda = Convert.ToDateTime(reader["dtAgenda"]);

                    agendas.Add(temp);
                }

                return agendas;
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
