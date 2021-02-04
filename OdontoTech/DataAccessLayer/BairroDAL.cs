﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using MySql.Data.MySqlClient;
using Domain;

namespace DataAccessLayer
{
    public class BairroDAL
    {
        MySqlConnection conn = new MySqlConnection(DBConfig.CONNECTION_STRING);
        MySqlCommand cmd = new MySqlCommand();

        public string Inserir(Bairro bairro)
        {
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO bairro (nomeBairro,idCidade) values (@nomeBairro,@idCidade)";

            cmd.Parameters.AddWithValue("@nomeBairro", bairro.Nome);
            cmd.Parameters.AddWithValue("@idCidade", bairro.Cidade.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Bairro cadastrado com sucesso";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    return ("Bairro já cadastrado.");
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
        public string Deletar(Bairro bairro)
        {
            
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM bairro WHERE idBairro = @ID";
            cmd.Parameters.AddWithValue("@ID", bairro.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Bairro deletado com êxito!";
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
        public string Atualizar(Bairro bairro)
        {
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE bairro SET nomeBairro = @nomeBairro WHERE idBairro = @idBairro";
            cmd.Parameters.AddWithValue("@idBairro", bairro.Id );
            cmd.Parameters.AddWithValue("@nomeBairro", bairro.Nome );

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Bairro atualizado com êxito!";
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
        public List<Bairro> SelecionaTodos()
        {           
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM bairro";
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Bairro> Bairros = new List<Bairro>();
                while (reader.Read())
                {
                    Bairro temp = new Bairro();

                    temp.Id = Convert.ToInt32(reader["idBairro"]);
                    temp.Nome = Convert.ToString(reader["nomeBairro"]);
                    temp.Cidade.Id = Convert.ToInt32(reader["idCidade"]);
    

                    Bairros.Add(temp);
                }
                return Bairros;
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
        public Bairro GetByID(int id)
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM bairro WHERE idBairro = @ID";
            cmd.Parameters.AddWithValue("@ID", id);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Bairro temp = new Bairro();

                while (reader.Read())
                {

                    temp.Id = Convert.ToInt32(reader["idBairro"]);
                    temp.Nome = Convert.ToString(reader["nomeBairro"]);
                    temp.Cidade.Id = Convert.ToInt32(reader["idCidade"]);


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
    }
}
