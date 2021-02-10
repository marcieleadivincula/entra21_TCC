using System;
using System.Collections.Generic;
using Domain;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
    public class PacienteDAL
    {
        MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
        MySqlCommand cmd = new MySqlCommand();

        public string Inserir(Paciente paciente)
        {
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO paciente(nome,sobrenome,rg,cpf,dtNascimento,obs,idEndereco) values(@nome, @sobrenome, @rg, @cpf, @dtNascimento, @obs, @idEndereco)";
            cmd.Parameters.AddWithValue("@nome", paciente.Nome);
            cmd.Parameters.AddWithValue("@sobrenome",paciente.Sobrenome );
            cmd.Parameters.AddWithValue("@rg", paciente.Rg);
            cmd.Parameters.AddWithValue("@cpf", paciente.Cpf );
            cmd.Parameters.AddWithValue("@dtNascimento", paciente.DataNascimento);
            cmd.Parameters.AddWithValue("@obs", paciente.Observacao);
            cmd.Parameters.AddWithValue("@idEndereco", paciente.Endereco.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return ("Paciente cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    return ("Paciente já cadastrado.");
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
        public string Deletar(Paciente paciente)
        {
            if (paciente.Id == 0)
            {
                return "Paciente informado inválido!";

            }

            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM paciente WHERE idPaciente = @idPaciente";
            cmd.Parameters.AddWithValue("@idPaciente", paciente.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Paciente deletado com êxito!";
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
        public string Atualizar(Paciente paciente)
        {

            cmd.Connection = conn;
            cmd.CommandText = "UPDATE paciente SET nome = @nome,  sobrenome = @sobrenome,  rg = @rg,  cpf = @cpf,  dtNascimento = @dtNascimento,  obs = @obs, idEndereco = @idEndereco WHERE idPaciente = @idPaciente";
            cmd.Parameters.AddWithValue("@nome", paciente.Nome);
            cmd.Parameters.AddWithValue("@sobrenome", paciente.Sobrenome);
            cmd.Parameters.AddWithValue("@rg", paciente.Rg);
            cmd.Parameters.AddWithValue("@cpf", paciente.Cpf);
            cmd.Parameters.AddWithValue("@dtNascimento", paciente.DataNascimento);
            cmd.Parameters.AddWithValue("@obs", paciente.Observacao);
            cmd.Parameters.AddWithValue("@idEndereco", paciente.Endereco.Id);
            cmd.Parameters.AddWithValue("@idPaciente", paciente.Id);
  
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Paciente atualizado com êxito!";
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
        public List<Paciente> SelecionaTodos()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM paciente";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Paciente> pacientes = new List<Paciente>();

                while (reader.Read())
                {
                    Paciente temp = new Paciente();
                    temp.Id = Convert.ToInt32(reader["idPaciente"]);
                    temp.Nome = Convert.ToString(reader["nome"]);
                    temp.Sobrenome = Convert.ToString(reader["sobrenome"]);
                    temp.Rg = Convert.ToString(reader["rg"]);
                    temp.Cpf = Convert.ToString(reader["cpf"]);
                    temp.DataNascimento = Convert.ToDateTime(reader["dtNascimento"]);
                    temp.Observacao = Convert.ToString(reader["obs"]);
                    temp.Endereco.Id = Convert.ToInt32(reader["idEndereco"]);

                    pacientes.Add(temp);
                }

                return pacientes;
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
        public Paciente GetByID(int idPaciente)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM paciente WHERE idPaciente = @idPaciente";
            cmd.Parameters.AddWithValue("@idPaciente", idPaciente);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Paciente paciente = new Paciente();

                while (reader.Read())
                {
                    paciente.Id = Convert.ToInt32(reader["idPaciente"]);
                    paciente.Nome = Convert.ToString(reader["nome"]);
                    paciente.Sobrenome = Convert.ToString(reader["sobrenome"]);
                    paciente.Rg = Convert.ToString(reader["rg"]);
                    paciente.Cpf = Convert.ToString(reader["cpf"]);
                    paciente.DataNascimento = Convert.ToDateTime(reader["dtNascimento"]);
                    paciente.Observacao = Convert.ToString(reader["obs"]);
                    paciente.Endereco.Id = Convert.ToInt32(reader["idEndereco"]);
                }

                return paciente;
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
        public Paciente GetLastRegister()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM paciente ORDER BY idPaciente DESC limit 1";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Paciente paciente = new Paciente();

                while (reader.Read())
                {
                    paciente.Id = Convert.ToInt32(reader["idPaciente"]);
                    paciente.Nome = Convert.ToString(reader["nome"]);
                    paciente.Sobrenome = Convert.ToString(reader["sobrenome"]);
                    paciente.Rg = Convert.ToString(reader["rg"]);
                    paciente.Cpf = Convert.ToString(reader["cpf"]);
                    paciente.DataNascimento = Convert.ToDateTime(reader["dtNascimento"]);
                    paciente.Observacao = Convert.ToString(reader["obs"]);
                    paciente.Endereco.Id = Convert.ToInt32(reader["idEndereco"]);
                }

                return paciente;
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
