using DataAccessLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class FuncaoBLL
    {
        FuncaoDAL dal = new FuncaoDAL();

        public string Insert(Funcao funcao)
        {
            StringBuilder erros = new StringBuilder();

            if (funcao.Id == 0 || funcao.Id < 0)
            {
                erros.AppendLine("O ID da função deve ser informado.");
            }

            if (string.IsNullOrWhiteSpace(funcao.Nome))
            {
                erros.AppendLine("Um nome deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(funcao.Nome))
            {
                if (funcao.Nome.Length > 100)
                {
                    erros.AppendLine("O nome da função não pode conter mais que 100 caracteres.");
                }
            }

            if (funcao.Salario < 0) //rever
            {
                erros.AppendLine("O salário não pode ser negativo.");
            }

            if (funcao.Comissao < 0) //rever tmb. 
            {
                erros.AppendLine("A comissão não pode ser negativa.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Inserir(funcao);
            return respostaDB;
        }

        public List<Funcao> GetAll()
        {
            return dal.SelecionaTodos();
        }

        public string Update(Funcao funcao)
        {
            StringBuilder erros = new StringBuilder();

            if (funcao.Id == 0 || funcao.Id < 0)
            {
                erros.AppendLine("O ID da função deve ser informado.");
            }

            if (string.IsNullOrWhiteSpace(funcao.Nome))
            {
                erros.AppendLine("Um nome deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(funcao.Nome))
            {
                if (funcao.Nome.Length > 100)
                {
                    erros.AppendLine("O nome da função não pode conter mais que 100 caracteres.");
                }
            }

            if (funcao.Salario < 0) //rever
            {
                erros.AppendLine("O salário não pode ser negativo.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Atualizar(funcao);
            return respostaDB;
        }

        public string Delete(Funcao funcao)
        {
            string respostaDB = dal.Deletar(funcao);
            return respostaDB;
        }



    }
}
