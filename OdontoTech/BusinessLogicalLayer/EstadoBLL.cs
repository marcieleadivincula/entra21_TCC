using DataAccessLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class EstadoBLL
    {
        EstadoDAL dal = new EstadoDAL();

        //Incluir um registro
        public string Insert(Estado estado)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(estado.Nome))
            {
                erros.AppendLine("O nome do estado deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(estado.Nome))
            {
                if (estado.Nome.Length > 20)
                {
                    erros.AppendLine("O nome do estado não pode conter mais que 20 caracteres.");
                }
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Insert(estado);
            return respostaDB;
        }

        // Obter todos os registros
        public List<Estado> GetAll()
        {
            return dal.GetAll();
        }

        //Atualizar um registro existente
        public string Update(Estado estado)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(estado.Nome))
            {
                erros.AppendLine("O nome do estado deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(estado.Nome))
            {
                if (estado.Nome.Length > 20)
                {
                    erros.AppendLine("O nome do estado não pode conter mais que 20 caracteres.");
                }
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Update(estado);
            return respostaDB;
        }

        //Excluir um registro
        public string Delete(Estado estado)
        {
            StringBuilder erros = new StringBuilder();

            if (estado.Id == 0)
            {
                erros.AppendLine("O ID deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Delete(estado);
            return respostaDB;
        }

        //Obter um registro
        public Estado GetById(Estado estado)
        {
            StringBuilder erros = new StringBuilder();

            if (estado.Id < 0 || estado.Id == 0)
            {
                erros.AppendLine("O ID do estado deve ser informado.");
            }

            return dal.GetById(estado.Id);
        }

        //Obter último registro
        public Estado GetLastRegister()
        {
            return dal.GetLastRegister();
        }

        //Obter registros de determinado estado
        public List<Estado> GetByPais(Pais pais)
        {
            return dal.GetByPais(pais);
        }

        //Obter registros por nome do pais de determinado estado
        public List<Estado> GetByNamePais(Pais pais)
        {
            return dal.GetByNamePais(pais);
        }
    }
}
