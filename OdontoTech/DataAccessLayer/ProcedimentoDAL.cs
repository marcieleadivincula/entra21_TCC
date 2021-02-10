using System;
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
        MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
        MySqlCommand cmd = new MySqlCommand();

        /// <summary>
        /// Inserir procedimento
        /// </summary>
        /// <param name="procedimento"></param>
        public string Inserir(Procedimento procedimento)
        {
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
                if (ex.Message.Contains("Duplicate"))
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
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM procedimento WHERE idProcedimento = @ID";
            cmd.Parameters.AddWithValue("@ID", procedimento.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Procedimento deletado com êxito!";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "Erro no Banco de dados. Contate o administrador.";
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
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE procedimento SET nomeProcedimento = @nomeProcedimento, dsProcedimento = @dsProcedimento, idTipoProcedimento = @idTipoProcedimento WHERE idProcedimento = @idProcedimento";
            cmd.Parameters.AddWithValue("@nomeProcedimento", procedimento.Nome);
            cmd.Parameters.AddWithValue("@dsProcedimento", procedimento.DescricaoProcedimento);
            cmd.Parameters.AddWithValue("@idTipoProcedimento", procedimento.TipoProcedimento.Id);
            cmd.Parameters.AddWithValue("@idProcedimento", procedimento.Id);

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
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM procedimento";
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
        public Procedimento GetByID(int id)
        {
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
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM procedimento ORDER BY idProcedimento DESC limit 1";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Procedimento procedimento = new Procedimento();

                while (reader.Read())
                {
                    Procedimento temp = new Procedimento();

                    temp.Id = Convert.ToInt32(reader["idProcedimento"]);
                    temp.Nome = Convert.ToString(reader["nomeProcedimento"]);
                    temp.DescricaoProcedimento = Convert.ToString(reader["dsProcedimento"]);
                    temp.TipoProcedimento.Id = Convert.ToInt32(reader["idTipoProcedimento"]);


                    procedimento = temp;
                }

                return procedimento;
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

        public List<Atendimento> GetAtendimentos(int idProcedimento)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM atendimentoprocedimentos ap INNER JOIN atendimento a ON ap.idAtendimento = a.idAtendimento WHERE ap.idProcedimento = @ID";
            cmd.Parameters.AddWithValue("@ID", idProcedimento);

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
    }
}
