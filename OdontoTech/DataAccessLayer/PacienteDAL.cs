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
    public class PacienteDAL
    {
        public string Inserir(Paciente paciente)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO paciente (nome,sobrenome,rg,cpf,dtNascimento,obs,idEndereco) values (@nome,@sobrenome,@rg,@cpf,@dtNascimento,@obs,@idEndereco)";
         
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
                if (ex.Message.Contains("UNIQUE"))
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
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM paciente WHERE idPaciente = @ID";
            cmd.Parameters.AddWithValue("@ID", paciente.Id);

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

            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE paciente SET nome = @nome,  sobrenome = @sobrenome,  rg = @rg,  cpf = @cpf,  dtNascimento = @dtNascimento,  obs = @obs WHERE idPaciente = @idPaciente";
            cmd.Parameters.AddWithValue("@idPaciente", paciente.Id);
            cmd.Parameters.AddWithValue("@nome", paciente.Nome);
            cmd.Parameters.AddWithValue("@sobrenome", paciente.Sobrenome);
            cmd.Parameters.AddWithValue("@rg", paciente.Rg);
            cmd.Parameters.AddWithValue("@cpf", paciente.Cpf);
            cmd.Parameters.AddWithValue("@dtNascimento", paciente.DataNascimento);
            cmd.Parameters.AddWithValue("@obs", paciente.Observacao);
  



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
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM paciente";
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Paciente> Pacientes = new List<Paciente>();
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

                    Pacientes.Add(temp);
                }
                return Pacientes;
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
        public Paciente GetByID(int id)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM paciente WHERE idPaciente = @ID";
            cmd.Parameters.AddWithValue("@ID", id);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Paciente temp = new Paciente();

                while (reader.Read())
                {

                    temp.Id = Convert.ToInt32(reader["idPaciente"]);
                    temp.Nome = Convert.ToString(reader["nome"]);
                    temp.Sobrenome = Convert.ToString(reader["sobrenome"]);
                    temp.Rg = Convert.ToString(reader["rg"]);
                    temp.Cpf = Convert.ToString(reader["cpf"]);
                    temp.DataNascimento = Convert.ToDateTime(reader["dtNascimento"]);
                    temp.Observacao = Convert.ToString(reader["obs"]);
                    temp.Endereco.Id = Convert.ToInt32(reader["idEndereco"]);

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
        public Paciente GetLastRegister()
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM paciente ORDER BY idPaciente DESC limit 1";

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                Paciente Paciente = new Paciente();

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

                    Paciente = temp;
                }

                return Paciente;
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
