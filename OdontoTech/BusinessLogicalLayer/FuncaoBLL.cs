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

        //Incluir um registro
        public string Insert(Funcao funcao)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(funcao.Nome))
            {
                erros.AppendLine("O nome da função deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(funcao.Nome))
            {
                if (funcao.Nome.Length > 100)
                {
                    erros.AppendLine("O nome da função não pode conter mais que 100 caracteres.");
                }
            }

            if (funcao.Salario < 0 || funcao.Salario == 0) //rever
            {
                erros.AppendLine("O salário deve ser informado.");
            }

            if (funcao.Comissao < 0) //rever tmb. 
            {
                erros.AppendLine("A comissão deve ser informada.");
            }

            if (funcao.Comissao > 0.6) //rever tmb. 
            {
                erros.AppendLine("A comissão não pode ser maior que 60%.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Insert(funcao);
            return respostaDB;
        }

        //Obter todos os registros
        public List<Funcao> GetAll()
        {
            return dal.GetAll();
        }

        //Atualizar um registro existente
        public string Update(Funcao funcao)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(funcao.Nome))
            {
                erros.AppendLine("O nome da função deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(funcao.Nome))
            {
                if (funcao.Nome.Length > 100)
                {
                    erros.AppendLine("O nome da função não pode conter mais que 100 caracteres.");
                }
            }

            if (funcao.Salario < 0 || funcao.Salario == 0) //rever
            {
                erros.AppendLine("O salário deve ser informado.");
            }

            if (funcao.Comissao < 0) //rever tmb. 
            {
                erros.AppendLine("A comissão deve ser informada.");
            }

            if (funcao.Comissao > 0.6) //rever tmb. 
            {
                erros.AppendLine("A comissão não pode ser maior que 60%.");
            }
            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Update(funcao);
            return respostaDB;
        }

        //Excluir um registro
        public string Delete(Funcao funcao)
        {
            string respostaDB = dal.Delete(funcao);
            return respostaDB;
        }

        //Obter um registro
        public Funcao GetById(Funcao funcao)
        {
            StringBuilder erros = new StringBuilder();

            if (funcao.Id == 0 || funcao.Id < 0)
            {
                erros.AppendLine("O ID da função deve ser informado.");
            }

            return dal.GetById(funcao.Id);
        }

        //Obter último registro
        public Funcao GetLastRegister()
        {
            return dal.GetLastRegister();
        }
    }
}
