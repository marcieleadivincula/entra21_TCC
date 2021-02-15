using DataAccessLayer;
using Domain;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicalLayer
{
    public class BairroBLL
    {
        BairroDAL dal = new BairroDAL();

        //Incluir um registro
        public string Insert(Bairro bairro)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(bairro.Nome))
            {
                erros.AppendLine("O nome do bairro deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(bairro.Nome))
            {
                if (bairro.Nome.Length > 50)
                {
                    erros.AppendLine("O nome não pode conter mais que 50 caracteres.");
                }
            }

            if (bairro.Cidade.Id == 0 || bairro.Cidade.Id < 0)
            {
                erros.AppendLine("A cidade deve ser informada.");
            }

            if (bairro.Id == 0 || bairro.Id < 0)
            {
                erros.AppendLine("O bairro deve ser informada.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Insert(bairro);
            return respostaDB;
        }

        //Excluir um registro
        public string Delete(Bairro bairro)
        {
            StringBuilder erros = new StringBuilder();

            if (bairro.Id == 0)
            {
                erros.AppendLine("O ID deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Delete(bairro);
            return respostaDB;
        }

        //Atualizar um registro existente
        public string Update(Bairro bairro)
        {
            StringBuilder erros = new StringBuilder();


            if (string.IsNullOrWhiteSpace(bairro.Nome))
            {
                erros.AppendLine("O nome deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(bairro.Nome))
            {
                if (bairro.Nome.Length > 50)
                {
                    erros.AppendLine("O nome não pode conter mais que 50 caracteres.");
                }
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Update(bairro);
            return respostaDB;
        }

        //Obter todos os registros
        public List<Bairro> GetAll()
        {
            return dal.GetAll();
        }

        //Obter um registro
        public Bairro GetById(Bairro bairro)
        {
            StringBuilder erros = new StringBuilder();

            if (bairro.Id == 0 || bairro.Id < 0)
            {
                erros.AppendLine("O ID do bairro deve ser informado.");
            }

            return dal.GetById(bairro.Id);
        }

        //Obter último registro
        public Bairro GetLastRegister()
        {
            return dal.GetLastRegister();
        }

        //Obter todos os bairros por cidade
        public List<Bairro> GetByCidade(Cidade cidade)
        {
            return dal.GetByCidade(cidade);
        }
    }
}
