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
    public class ColaboradorDAL
    {
        /// <summary>
        ///  Insere a Colaborador no BD. Caso houver erro a função informa.
        /// </summary>
        /// <param name="colaborador"></param>
        public string Inserir(Colaborador colaborador)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO colaborador (nome,idFuncao,cro,croEstado,dtAdmissao,dtDemissao,idEndereco,idClinica,demitido) values (@nome,@idFuncao,@cro,@croEstado,@dtAdmissao,@dtDemissao,@idEndereco,@idClinica,@ferias,@demitido)";

            cmd.Parameters.AddWithValue("@nome", colaborador.Nome);
            cmd.Parameters.AddWithValue("@idFuncao",colaborador.Funcao.Id);
            cmd.Parameters.AddWithValue("@cro", colaborador.Cro);
            cmd.Parameters.AddWithValue("@croEstado", colaborador.CroEstado);
            cmd.Parameters.AddWithValue("@dtAdmissao", colaborador.DataAdmissao);
            cmd.Parameters.AddWithValue("@dtDemissao", colaborador.DataDemissao);
            cmd.Parameters.AddWithValue("@idEndereco", colaborador.Endereco.Id);
            cmd.Parameters.AddWithValue("@idClinica", colaborador.Clinica.Id );
            cmd.Parameters.AddWithValue("@ferias", colaborador.Ferias);// !
            cmd.Parameters.AddWithValue("@demitido", colaborador.Demitido);// !

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Colaborador cadastrado com sucesso";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    return ("Colaborador já cadastrado.");
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
        ///  Tenta deletar, caso der certo retorna (Colaborador deletads com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="colaborador"></param>
        /// <returns></returns>
        public string Deletar(Colaborador colaborador)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM colaborador WHERE idColaborador = @ID";
            cmd.Parameters.AddWithValue("@ID", colaborador.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Colaborador deletada com êxito!";
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
        /// Tenta atualizar, caso der certo retorna (Colaborador atualizada com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// </summary>
        /// <param name="colaborador"></param>
        /// <returns></returns>
        public string Atualizar(Colaborador colaborador)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE colaborador SET nome = @nome, SET idFuncao = @idFuncao, SET cro = @cro, SET croEstado = @croEstado, SET dtAdmissao = @dtAdmissao, SET dtDemissao = @dtDemissao, SET idEndereco = @idEndereco, SET idClinica = @idClinica, SET ferias = @ferias, SET demitido = @demitido  WHERE idColaborador = @id";
            cmd.Parameters.AddWithValue("@nome", colaborador.Nome);
            cmd.Parameters.AddWithValue("@idFuncao", colaborador.Funcao.Id);
            cmd.Parameters.AddWithValue("@cro", colaborador.Cro);
            cmd.Parameters.AddWithValue("@croEstado", colaborador.CroEstado);
            cmd.Parameters.AddWithValue("@dtAdmissao", colaborador.DataAdmissao);
            cmd.Parameters.AddWithValue("@dtDemissao", colaborador.DataDemissao);
            cmd.Parameters.AddWithValue("@idEndereco", colaborador.Endereco.Id);
            cmd.Parameters.AddWithValue("@idClinica", colaborador.Clinica.Id);
            cmd.Parameters.AddWithValue("@ferias", colaborador.Ferias); // !
            cmd.Parameters.AddWithValue("@demitido", colaborador.Demitido); // !
            cmd.Parameters.AddWithValue("@id", colaborador.Id);


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Colaborador atualizada com êxito!";
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
        /// Retorna Lista Com Colaboradores !
        /// </summary>
        /// <returns></returns>
        public List<Colaborador> SelecionaTodos()
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM endereco";
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Colaborador> Colaboradors = new List<Colaborador>();
                while (reader.Read())
                {
                    Colaborador temp = new Colaborador();

                    temp.Id = Convert.ToInt32(reader["idColaborador"]);
                    temp.Nome = Convert.ToString(reader["nome"]);
                    temp.Funcao.Id = Convert.ToInt32(reader["idFuncao"]);
                    temp.Cro = Convert.ToString(reader["cro"]);
                    temp.CroEstado = Convert.ToString(reader["croEstado"]);
                    temp.DataAdmissao = Convert.ToDateTime(reader["dtAdmissao"]);
                    temp.DataDemissao = Convert.ToDateTime(reader["dtDemissao"]);
                    temp.Endereco.Id = Convert.ToInt32(reader["idColaborador"]);
                    temp.Clinica.Id = Convert.ToInt32(reader["idClinica"]);
                    temp.Ferias = Convert.ToBoolean(reader["ferias"]);
                    temp.Ferias = Convert.ToBoolean(reader["demitido"]);





                    Colaboradors.Add(temp);
                }
                return Colaboradors;
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
