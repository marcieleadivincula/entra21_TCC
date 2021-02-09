using DataAccessLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class LogradouroBLL
    {
        LogradouroDAL dal = new LogradouroDAL();

        public string Insert(Logradouro logradouro)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(logradouro.Nome))
            {
                erros.AppendLine("O nome deve ser informado.");
            }

            if (logradouro.Nome.Length > 50)
            {
                erros.AppendLine("O nome não pode conter mais que 50 caracteres.");
            }

            if (logradouro.Bairro.Id == 0 || logradouro.Bairro.Id < 0)
            {
                erros.AppendLine("O ID do logradouro deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Inserir(logradouro);
            return respostaDB;
        }

        public List<Logradouro> GetAll()
        {
            return dal.SelecionaTodos();
        }

        public string Update(Logradouro logradouro)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(logradouro.Nome))
            {
                erros.AppendLine("O nome deve ser informado.");
            }

            if (logradouro.Nome.Length > 50)
            {
                erros.AppendLine("O nome não pode conter mais que 50 caracteres.");
            }

            if (logradouro.Bairro.Id == 0 || logradouro.Bairro.Id < 0)
            {
                erros.AppendLine("O ID do logradouro deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Atualizar(logradouro);
            return respostaDB;
        }

        public string Delete(Logradouro logradouro)
        {
            string respostaDB = dal.Deletar(logradouro);
            return respostaDB;
        }
    }
}
