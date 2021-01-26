using DataAccessLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class CidadeBLL
    {
        CidadeDAL dal = new CidadeDAL();

        public string Insert(Cidade cidade)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(cidade.Nome))
            {
                erros.AppendLine("O nome deve ser informado.");
            }

            if (cidade.Nome.Length > 50)
            {
                erros.AppendLine("O nome não pode conter mais que 50 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(Convert.ToString(cidade.Estado.Id)))
            {
                erros.AppendLine("A ID do Estado deve ser informado.");
            }

            if (string.IsNullOrWhiteSpace(Convert.ToString(cidade.Id)))
            {
                erros.AppendLine("A ID da cidade deve ser informada.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Inserir(cidade);
            return respostaDB;
        }

        public List<Cidade> GetAll()
        {
            return dal.SelecionaTodos();
        }

        public string Update(Cidade cidade)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(cidade.Nome))
            {
                erros.AppendLine("O nome deve ser informado.");
            }

            if (cidade.Nome.Length > 50)
            {
                erros.AppendLine("O nome não pode conter mais que 50 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(Convert.ToString(cidade.Estado.Id)))
            {
                erros.AppendLine("A ID do Estado deve ser informado.");
            }

            if (string.IsNullOrWhiteSpace(Convert.ToString(cidade.Id)))
            {
                erros.AppendLine("A ID da cidade deve ser informada.");
            }
            string respostaDB = dal.Atualizar(cidade);
            return respostaDB;
        }

        public string Delete(Cidade cidade)
        {
            string respostaDB = dal.Deletar(cidade);
            return respostaDB;
        }
    }
}
