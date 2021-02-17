using System;
using System.Collections.Generic;
using Domain;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
    public class ContatoDAL
    {
        MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
        MySqlCommand cmd = new MySqlCommand();
        public string Insert(Contato contato)
        {
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO contato(fone, idFoneTipo, email, idPaciente, idColaborador) values(@fone, @idFoneTipo, @email, @idPaciente, @idColaborador)";
            cmd.Parameters.AddWithValue("@fone", contato.Fone);
            cmd.Parameters.AddWithValue("@idFoneTipo", contato.FoneTipo.Id);
            cmd.Parameters.AddWithValue("@email", contato.Email);
            cmd.Parameters.AddWithValue("@idPaciente", contato.Paciente.Id);
            cmd.Parameters.AddWithValue("@idColaborador", contato.Colaborador.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return ("Contato cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    return ("Contato já cadastrado.");
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
        public string Delete(Contato contato)
        {
            if (contato.Id == 0)
            {
                return "Contato informado inválido!";

            }

            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM contato WHERE idContato = @idContato";
            cmd.Parameters.AddWithValue("@idContato", contato.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Contato deletado com êxito!";
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
        public string Update(Contato contato)
        {

            cmd.Connection = conn;
            cmd.CommandText = "UPDATE contato SET fone = @fone,  idFoneTipo = @idFoneTipo,  email = @email,  idPaciente = @idPaciente,  idColaborador = @idColaborador WHERE idContato = @idContato";
            cmd.Parameters.AddWithValue("@fone", contato.Fone);
            cmd.Parameters.AddWithValue("@idFoneTipo", contato.FoneTipo.Id);
            cmd.Parameters.AddWithValue("@email", contato.Email);
            cmd.Parameters.AddWithValue("@idPaciente", contato.Paciente.Id);
            cmd.Parameters.AddWithValue("@idColaborador", contato.Colaborador.Id);
            cmd.Parameters.AddWithValue("@idContato", contato.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Contato atualizado com êxito!";
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
        public List<Contato> GetAll()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM contato";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Contato> contatos = new List<Contato>();

                while (reader.Read())
                {
                    Contato temp = new Contato();
                    temp.Id = Convert.ToInt32(reader["idContato"]);
                    temp.Fone = Convert.ToString(reader["fone"]);
                    temp.FoneTipo.Id = Convert.ToInt32(reader["idFoneTipo"]);
                    temp.Email = Convert.ToString(reader["email"]);
                    temp.Paciente.Id = Convert.ToInt32(reader["idPaciente"]);
                    temp.Colaborador.Id = Convert.ToInt32(reader["idColaborador"]);

                    contatos.Add(temp);
                }

                return contatos;
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
        /// <summary>
        /// Retorna Paciente.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Contato GetById(int idContato)
        {
            cmd.Connection = conn;
            cmd.CommandText = $"SELECT * FROM contato WHERE idContato = {idContato}";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Contato contato = new Contato();

                while (reader.Read())
                {
                    contato.Id = Convert.ToInt32(reader["idContato"]);
                    contato.Fone = Convert.ToString(reader["fone"]);
                    contato.FoneTipo.Id = Convert.ToInt32(reader["idFoneTipo"]);
                    contato.Email = Convert.ToString(reader["email"]);
                    contato.Paciente.Id = Convert.ToInt32(reader["idPaciente"]);
                    contato.Colaborador.Id = Convert.ToInt32(reader["idColaborador"]);
                }

                return contato;
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
        public Contato GetLastRegister()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM contato ORDER BY idContato DESC limit 1";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Contato contato = new Contato();

                while (reader.Read())
                {
                    contato.Id = Convert.ToInt32(reader["idContato"]);
                    contato.Fone = Convert.ToString(reader["fone"]);
                    contato.FoneTipo.Id = Convert.ToInt32(reader["idFoneTipo"]);
                    contato.Email = Convert.ToString(reader["email"]);
                    contato.Paciente.Id = Convert.ToInt32(reader["idPaciente"]);
                    contato.Colaborador.Id = Convert.ToInt32(reader["idColaborador"]);
                }

                return contato;
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

        public List<Contato> GetByColaborador(Colaborador colaborador)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM contato WHERE idColaborador = @idColaborador";
            cmd.Parameters.AddWithValue("@idColaborador", colaborador.Id);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Contato> contatos = new List<Contato>();

                while (reader.Read())
                {
                    Contato temp = new Contato();
                    temp.Id = Convert.ToInt32(reader["idContato"]);
                    temp.Fone = Convert.ToString(reader["fone"]);
                    temp.FoneTipo.Id = Convert.ToInt32(reader["idFoneTipo"]);
                    temp.Email = Convert.ToString(reader["email"]);
                    temp.Paciente.Id = Convert.ToInt32(reader["idPaciente"]);
                    temp.Colaborador.Id = Convert.ToInt32(reader["idColaborador"]);

                    contatos.Add(temp);
                }

                return contatos;
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

        public List<Contato> GetByPaciente(Paciente paciente)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM contato WHERE idPaciente = @idPaciente";
            cmd.Parameters.AddWithValue("@idPaciente", paciente.Id);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Contato> contatos = new List<Contato>();

                while (reader.Read())
                {
                    Contato temp = new Contato();
                    temp.Id = Convert.ToInt32(reader["idContato"]);
                    temp.Fone = Convert.ToString(reader["fone"]);
                    temp.FoneTipo.Id = Convert.ToInt32(reader["idFoneTipo"]);
                    temp.Email = Convert.ToString(reader["email"]);
                    temp.Paciente.Id = Convert.ToInt32(reader["idPaciente"]);
                    temp.Colaborador.Id = Convert.ToInt32(reader["idColaborador"]);

                    contatos.Add(temp);
                }

                return contatos;
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
