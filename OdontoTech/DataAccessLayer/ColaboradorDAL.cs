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
        public void Inserir(Colaborador colaborador)
        {
            SqlConnection conn = new SqlConnection(DBConfig.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO colaborador (nome,idFuncao,cro,croEstado,dtAdmissao,dtDemissao,idEndereco,idClinica,demitido) values (@nome,@idFuncao,@cro,@croEstado,@dtAdmissao,@dtDemissao,@idEndereco,@idClinica,@ferias,@demitido)";

            cmd.Parameters.AddWithValue("@nome", colaborador.Nome);
            cmd.Parameters.AddWithValue("@idFuncao",colaborador.Id);
            cmd.Parameters.AddWithValue("@cro", colaborador.Cro);
            cmd.Parameters.AddWithValue("@croEstado", colaborador.CroEstado);
            cmd.Parameters.AddWithValue("@dtAdmissao", colaborador.DataAdmissao);
            cmd.Parameters.AddWithValue("@dtDemissao", colaborador.DataDemissao);
            cmd.Parameters.AddWithValue("@idEndereco", colaborador.Endereco);
            cmd.Parameters.AddWithValue("@idClinica", colaborador.Clinica.Id );
            cmd.Parameters.AddWithValue("@ferias", colaborador.Ferias);
            cmd.Parameters.AddWithValue("@demitido", colaborador.Demitido);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    throw new Exception("Colaborador já cadastrada.");
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
