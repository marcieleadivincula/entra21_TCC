using DataAccessLayer;
using Domain;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicalLayer
{
    public class PaisBLL
    {
        PaisDAL dal = new PaisDAL();

        //Incluir um registro
        public string Insert(Pais pais)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(pais.Nome))
            {
                erros.AppendLine("O nome do país deve ser informado.");
            }

            if (pais.Nome.Length > 20)
            {
                erros.AppendLine("O nome do país não pode conter mais que 20 caracteres.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Inserir(pais);
            return respostaDB;
        }

        // Obter todos os registros
        public List<Pais> GetAll()
        {
            return dal.SelecionaTodos();
        }

        //Atualizar um registro existente
        public string Update(Pais pais)
        {
            StringBuilder erros = new StringBuilder();

            if (pais.Nome.Length > 20)
            {
                erros.AppendLine("O nome do país não pode conter mais que 20 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(pais.Nome))
            {
                erros.AppendLine("O nome do país deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Atualizar(pais);
            return respostaDB;
        }

        //Excluir um registro
        public string Delete(Pais pais)
        {
            string respostaDB = dal.Deletar(pais);
            return respostaDB;
        }

        //Obter um registro
        public Pais GetById(Pais pais)
        {
            StringBuilder erros = new StringBuilder();

            if (pais.Id < 0 || pais.Id == 0)
            {
                erros.AppendLine("O ID do país deve ser informado.");
            }

            return dal.GetById(pais.Id);
        }

        //Obter último registro
        public Pais GetLastRegister()
        {
            return dal.GetLastRegister();
        }
    }
}
