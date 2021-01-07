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
    class AtendimentoDAL
    {

        /// <summary>
        /// Insere o Endereço no BD. Caso houver erro a função informa.
        /// </summary>
        /// <param name="Atendimento"></param>
        public void Inserir(Atendimento Atendimento)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO atendimento (idAtendimento,idPaciente,idColaborador) values (@idAtendimento,@idPaciente,@idColaborador)";
            cmd.Parameters.AddWithValue("@idAtendimento", Atendimento.Id);
            cmd.Parameters.AddWithValue("@idPaciente", Atendimento.Paciente.Id);
            cmd.Parameters.AddWithValue("@idColaborador", Atendimento.Colaborador.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    throw new Exception("Atendimento já cadastrado.");
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
