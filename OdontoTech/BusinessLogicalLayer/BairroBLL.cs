using DataAccessLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    class BairroBLL
    {
        BairroDAL dal = new BairroDAL();
        public string Insert(Bairro bairro)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(bairro.Nome))
            {
                erros.AppendLine("O nome deve ser informado.");
            }

            if (bairro.Nome.Length > 50)
            {
                erros.AppendLine("O nome não pode conter mais que 100 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(bairro.cidade.Nome))
            {
                erros.AppendLine("A cidade deve ser informada.");
            }
            if (bairro.cidade.Nome.Length > 50)
            {
                erros.AppendLine("O CRO não pode conter mais que 10 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(bairro.cidade.Estado.Nome))
            {
                erros.AppendLine("O estado da cidade deve ser informado.");
            }
           

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Inserir(bairro);
            return respostaDB;
        }
    }
}
