using DataAccessLayer;
using Domain;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicalLayer
{
    public class PaisBLL
    {
        PaisDAL dal = new PaisDAL();

        public string Insert(Pais pais)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(pais.Nome))
            {
                erros.Append("O nome deve ser informado.");
            }

            if (pais.Nome.Length > 20)
            {
                erros.AppendLine("O nome não pode conter mais que 20 caracteres.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Inserir(pais);
            return respostaDB;
        }

        public List<Pais> GetAll()
        {
            return dal.SelecionaTodos();
        }

        public string Update(Pais pais)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(pais.Nome))
            {
                erros.AppendLine("O nome deve ser informado.");
            }

            if (pais.Nome.Length > 20)
            {
                erros.AppendLine("O nome não pode conter mais que 20 caracteres.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Inserir(pais);
            return respostaDB;
        }

        public string Delete(Pais pais)
        {
            string respostaDB = dal.Deletar(pais);
            return respostaDB;
        }
    }
}
