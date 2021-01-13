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
    class PacienteDAL
    {
        public void Inserir(Paciente paciente)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO paciente (idPaciente,nome,sobrenome,rg,cpf,dtNascimento,obs,idEndereco) values (@idPaciente,@nome,@sobrenome,@rg,@cpf,@dtNascimento,@obs,@idEndereco)";
            cmd.Parameters.AddWithValue("@idPaciente", paciente.Id);
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
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    throw new Exception("Paciente já cadastrado.");
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
    }
}
