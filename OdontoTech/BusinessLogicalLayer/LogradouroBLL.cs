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

        //Incluir um registro
        public string Insert(Logradouro logradouro)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(logradouro.Nome))
            {
                erros.AppendLine("O nome do logradouro deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(logradouro.Nome))
            {
                if (logradouro.Nome.Length > 50)
                {
                    erros.AppendLine("O nome do logradouro não pode conter mais que 50 caracteres.");
                }
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Insert(logradouro);
            return respostaDB;
        }

        // Obter todos os registros
        public List<Logradouro> GetAll()
        {
            return dal.GetAll();
        }

        //Atualizar um registro existente
        public string Update(Logradouro logradouro)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(logradouro.Nome))
            {
                erros.AppendLine("O nome do logradouro deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(logradouro.Nome))
            {
                if (logradouro.Nome.Length > 50)
                {
                    erros.AppendLine("O nome do logradouro não pode conter mais que 50 caracteres.");
                }
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Update(logradouro);
            return respostaDB;
        }

        //Excluir um registro
        public string Delete(Logradouro logradouro)
        {
            StringBuilder erros = new StringBuilder();

            if (logradouro.Id == 0)
            {
                erros.AppendLine("O ID deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Delete(logradouro);
            return respostaDB;
        }

        //Obter um registro
        public Logradouro GetById(Logradouro logradouro)
        {
            StringBuilder erros = new StringBuilder();

            if (logradouro.Id == 0 || logradouro.Id < 0)
            {
                erros.AppendLine("O ID do logradouro deve ser informado.");
            }

            return dal.GetByID(logradouro.Id);
        }
        //Obter último registro
        public Logradouro GetLastRegister()
        {
            return dal.GetLastRegister();
        }

        //Obter registros de determinado bairro
        public List<Logradouro> GetByBairro(Bairro bairro)
        {
            return dal.GetByBairro(bairro);
        }
    }
}
