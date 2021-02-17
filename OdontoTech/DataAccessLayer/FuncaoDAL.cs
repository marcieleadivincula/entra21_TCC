using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Domain;

namespace DataAccessLayer
{
    public class FuncaoDAL
    {
        MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
        MySqlCommand cmd = new MySqlCommand();

        /// <summary>
        /// Insere Funcao caso der erro informa.
        /// </summary>
        /// <param name="Função"></param>
        public string Insert(Funcao funcao)
        {
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO funcao(nomeFuncao, salario, comissao) values(@nomeFuncao, @salario, @comissao)";
            cmd.Parameters.AddWithValue("@nomeFuncao", funcao.Nome);
            cmd.Parameters.AddWithValue("@salario", funcao.Salario);
            cmd.Parameters.AddWithValue("@comissao", funcao.Comissao);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Função cadastrada com sucesso!";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    return ("Função já cadastrada.");
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
        public string Delete(Funcao funcao)
        {
            if (funcao.Id == 0)
            {
                return "Funcao informada inválida!";
            }

            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM funcao WHERE idFuncao = @idFuncao";
            cmd.Parameters.AddWithValue("@idFuncao", funcao.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Função deletada com êxito!";
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
        public string Update(Funcao funcao)
        {

            cmd.Connection = conn;
            cmd.CommandText = "UPDATE funcao SET nomeFuncao = @nomeFuncao, salario = @salario, comissao = @comissao WHERE idFuncao = @idFuncao";
            cmd.Parameters.AddWithValue("@nomeFuncao", funcao.Nome);
            cmd.Parameters.AddWithValue("@salario", funcao.Salario);
            cmd.Parameters.AddWithValue("@comissao", funcao.Comissao);
            cmd.Parameters.AddWithValue("@idFuncao", funcao.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Função atualizado com êxito!";
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
        public List<Funcao> GetAll()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM funcao";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Funcao> funcoes = new List<Funcao>();

                while (reader.Read())
                {
                    Funcao temp = new Funcao();
                    temp.Id = Convert.ToInt32(reader["idFuncao"]);
                    temp.Nome = Convert.ToString(reader["nomeFuncao"]);
                    temp.Salario = Convert.ToDouble(reader["salario"]);
                    temp.Comissao = Convert.ToDouble(reader["comissao"]);

                    funcoes.Add(temp);
                }

                return funcoes;
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
        public Funcao GetById(int idFuncao)
        {
            cmd.Connection = conn;
            cmd.CommandText = $"SELECT * FROM funcao WHERE idFuncao = {idFuncao}";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Funcao funcao = new Funcao();

                while (reader.Read())
                {
                    funcao.Id = Convert.ToInt32(reader["idFuncao"]);
                    funcao.Nome = Convert.ToString(reader["nomeFuncao"]);
                    funcao.Salario = Convert.ToDouble(reader["salario"]);
                    funcao.Comissao = Convert.ToDouble(reader["comissao"]);
                }

                return funcao;
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
        public Funcao GetLastRegister()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM funcao ORDER BY idFuncao DESC limit 1";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Funcao funcao = new Funcao();

                while (reader.Read())
                {
                    funcao.Id = Convert.ToInt32(reader["idFuncao"]);
                    funcao.Nome = Convert.ToString(reader["nomeFuncao"]);
                    funcao.Salario = Convert.ToDouble(reader["salario"]);
                    funcao.Comissao = Convert.ToDouble(reader["comissao"]);
                }

                return funcao;
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
