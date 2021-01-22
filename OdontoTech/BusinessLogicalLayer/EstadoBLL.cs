using DataAccessLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    class EstadoBLL
    {
        EstadoDAL dal = new EstadoDAL();

        public string Insert(Estado estado)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(estado.Nome))
            {
                erros.AppendLine("O nome deve ser informado.");
            }

            if (estado.Nome.Length > 20)
            {
                erros.AppendLine("O nome não pode conter mais que 20 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(Convert.ToString(estado.Pais.Id)))
            {
                erros.AppendLine("A ID do pais deve ser informado.");
            }

            if (string.IsNullOrWhiteSpace(Convert.ToString(estado.Id)))
            {
                erros.AppendLine("A ID do estado deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Inserir(estado);
            return respostaDB;
        }

        public List<Estado> GetAll()
        {
            return dal.SelecionaTodos();
        }

        public string Update(Estado estado)
        {
            StringBuilder erros = new StringBuilder();
            if (string.IsNullOrWhiteSpace(estado.Nome))
            {
                erros.AppendLine("O nome deve ser informado.");
            }

            if (estado.Nome.Length > 20)
            {
                erros.AppendLine("O nome não pode conter mais que 20 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(Convert.ToString(estado.Pais.Id)))
            {
                erros.AppendLine("A ID do pais deve ser informado.");
            }

            if (string.IsNullOrWhiteSpace(Convert.ToString(estado.Id)))
            {
                erros.AppendLine("A ID do estado deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Inserir(estado);
            return respostaDB;
        }

        public string Delete(Estado estado)
        {
            string respostaDB = dal.Deletar(estado);
            return respostaDB;
        }
    }
}
