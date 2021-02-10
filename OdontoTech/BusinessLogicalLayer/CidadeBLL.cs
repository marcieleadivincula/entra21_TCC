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

        //Incluir um registro
        public string Insert(Cidade cidade)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(cidade.Nome))
            {
                erros.AppendLine("O nome da cidade deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(cidade.Nome))
            {
                if (cidade.Nome.Length > 50)
                {
                    erros.AppendLine("O nome da cidade não pode conter mais que 50 caracteres.");
                }
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Insert(cidade);
            return respostaDB;
        }

        // Obter todos os registros
        public List<Cidade> GetAll()
        {
            return dal.GetAll();
        }

        //Atualizar um registro existente
        public string Update(Cidade cidade)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(cidade.Nome))
            {
                erros.AppendLine("O nome deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(cidade.Nome))
            {
                if (cidade.Nome.Length > 50)
                {
                    erros.AppendLine("O nome da cidade não pode conter mais que 50 caracteres.");
                }
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Update(cidade);
            return respostaDB;
        }

        //Excluir um registro
        public string Delete(Cidade cidade)
        {
            StringBuilder erros = new StringBuilder();

            if (cidade.Id == 0)
            {
                erros.AppendLine("O ID deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Delete(cidade);
            return respostaDB;
        }

        //Obter um registro
        public Cidade GetById(Cidade cidade)
        {
            StringBuilder erros = new StringBuilder();

            if (cidade.Id < 0 || cidade.Id == 0)
            {
                erros.AppendLine("O ID da cidade deve ser informado.");
            }

            return dal.GetById(cidade.Id);
        }

        //Obter último registro
        public Cidade GetLastRegister()
        {
            return dal.GetLastRegister();
        }

        //Obter lista de cidades de determinado estado
        public List<Cidade> GetByEstado(Estado estado)
        {
            return dal.GetByEstado(estado);
        }
    }
}
