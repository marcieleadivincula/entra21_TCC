using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Domain;

namespace DataAccessLayer
{
    public class ColaboradorDAL
    {

        MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
        MySqlCommand cmd = new MySqlCommand();

        /// <summary>
        ///  Insere a Colaborador no BD. Caso houver erro a função informa.
        /// </summary>
        /// <param name="colaborador"></param>
        public string Inserir(Colaborador colaborador)
        {
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO colaborador(nome, idFuncao, cro, croEstado, dtAdmissao, dtDemissao, idEndereco, idClinica, ferias, demitido) values(@nome, @idFuncao, @cro, @croEstado, @dtAdmissao, @dtDemissao, @idEndereco, @idClinica, @ferias, @demitido)";
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
                return "Colaborador cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    
                    return ("Colaborador já cadastrado.");
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
        /// <summary>
        ///  Tenta deletar, caso der certo retorna (Colaborador deletads com êxito!) se não (Erro no Banco de dados. Contate o administrador.)
        /// </summary>
        /// <param name="colaborador"></param>
        /// <returns></returns>
        public string Deletar(Colaborador colaborador)
        {
            if (colaborador.Id == 0)
            {
                return "Colaborador informado inválido!";
            }

            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM colaborador WHERE idColaborador = @idColaborador";
            cmd.Parameters.AddWithValue("@idColaborador", colaborador.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Colaborador deletado com êxito!";
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
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE colaborador SET nome = @nome, cro = @cro,  croEstado = @croEstado,  dtAdmissao = @dtAdmissao,  dtDemissao = @dtDemissao, idEndereco = @idEndereco, idClinica = @idClinica, ferias = @ferias,  demitido = @demitido  WHERE idColaborador = @idColaborador";

            cmd.Parameters.AddWithValue("@nome", colaborador.Nome);
            cmd.Parameters.AddWithValue("@cro", colaborador.Cro);
            cmd.Parameters.AddWithValue("@croEstado", colaborador.CroEstado);
            cmd.Parameters.AddWithValue("@dtAdmissao", colaborador.DataAdmissao);
            cmd.Parameters.AddWithValue("@dtDemissao", colaborador.DataDemissao);
            cmd.Parameters.AddWithValue("@idEndereco", colaborador.Endereco.Id);
            cmd.Parameters.AddWithValue("@idClinica", colaborador.Clinica.Id);
            cmd.Parameters.AddWithValue("@ferias", colaborador.Ferias); // !
            cmd.Parameters.AddWithValue("@demitido", colaborador.Demitido); // !
            cmd.Parameters.AddWithValue("@idColaborador", colaborador.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Colaborador atualizado com êxito!";
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
        /// <summary>
        /// Retorna Lista Com Colaboradores !
        /// </summary>
        /// <returns></returns>
        public List<Colaborador> SelecionaTodos()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM colaborador";
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Colaborador> colaboradores = new List<Colaborador>();

                while (reader.Read())
                {
                    Colaborador temp = new Colaborador();

                    temp.Funcao = new Funcao();
                    temp.Endereco = new Endereco();
                    temp.Clinica = new Clinica();

                    temp.Id = Convert.ToInt32(reader["idColaborador"]);
                    temp.Nome = Convert.ToString(reader["nome"]);
                    temp.Funcao.Id = Convert.ToInt32(reader["idFuncao"]);
                    temp.Cro = Convert.ToString(reader["cro"]);
                    temp.CroEstado = Convert.ToString(reader["croEstado"]);
                    temp.DataAdmissao = Convert.ToDateTime(reader["dtAdmissao"]);
                    temp.DataDemissao = Convert.ToDateTime(reader["dtDemissao"]);
                    temp.Endereco.Id = Convert.ToInt32(reader["idEndereco"]);
                    temp.Clinica.Id = Convert.ToInt32(reader["idClinica"]);
                    temp.Ferias = Convert.ToBoolean(reader["ferias"]);
                    temp.Demitido = Convert.ToBoolean(reader["demitido"]);

                    colaboradores.Add(temp);
                }

                return colaboradores;
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
        public Colaborador GetByID(int idColaborador)
        {
            cmd.Connection = conn;
            
            cmd.CommandText = $"SELECT * FROM colaborador WHERE idColaborador = {idColaborador}";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Colaborador colaborador = new Colaborador();

                while (reader.Read())
                {
                    colaborador.Funcao = new Funcao();
                    colaborador.Endereco = new Endereco();
                    colaborador.Clinica = new Clinica();

                    colaborador.Id = Convert.ToInt32(reader["idColaborador"]);
                    colaborador.Nome = Convert.ToString(reader["nome"]);
                    colaborador.Funcao.Id = Convert.ToInt32(reader["idFuncao"]);
                    colaborador.Cro = Convert.ToString(reader["cro"]);
                    colaborador.CroEstado = Convert.ToString(reader["croEstado"]);
                    colaborador.DataAdmissao = Convert.ToDateTime(reader["dtAdmissao"]);
                    colaborador.DataDemissao = Convert.ToDateTime(reader["dtDemissao"]);
                    colaborador.Endereco.Id = Convert.ToInt32(reader["idEndereco"]);
                    colaborador.Clinica.Id = Convert.ToInt32(reader["idClinica"]);
                    colaborador.Ferias = Convert.ToBoolean(reader["ferias"]);
                    colaborador.Ferias = Convert.ToBoolean(reader["demitido"]);
                }

                return colaborador;
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
        public Colaborador GetLastRegister()
        {
            MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
            MySqlCommand command  = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM colaborador ORDER BY idColaborador DESC limit 1";

            try
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                Colaborador colaborador = new Colaborador();

                while (reader.Read())
                {
                    colaborador.Funcao = new Funcao();
                    colaborador.Endereco = new Endereco();
                    colaborador.Clinica = new Clinica();

                    colaborador.Id = Convert.ToInt32(reader["idColaborador"]);
                    colaborador.Nome = Convert.ToString(reader["nome"]);
                    colaborador.Funcao.Id = Convert.ToInt32(reader["idFuncao"]);
                    colaborador.Cro = Convert.ToString(reader["cro"]);
                    colaborador.CroEstado = Convert.ToString(reader["croEstado"]);
                    colaborador.DataAdmissao = Convert.ToDateTime(reader["dtAdmissao"]);
                    colaborador.DataDemissao = Convert.ToDateTime(reader["dtDemissao"]);
                    colaborador.Endereco.Id = Convert.ToInt32(reader["idEndereco"]);
                    colaborador.Clinica.Id = Convert.ToInt32(reader["idClinica"]);
                    colaborador.Ferias = Convert.ToBoolean(reader["ferias"]);
                    colaborador.Ferias = Convert.ToBoolean(reader["demitido"]);
                }

                return colaborador;
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
