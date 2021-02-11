using DataAccessLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class TipoProcedimentoBLL
    {
        TipoProcedimentoDAL dal = new TipoProcedimentoDAL();

        //Incluir um registro
        public string Insert(TipoProcedimento tipoProcedimento)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(tipoProcedimento.Nome))
            {
                erros.AppendLine("O nome do tipo de procedimento deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(tipoProcedimento.Nome))
            {
                if (tipoProcedimento.Nome.Length > 60)
                {
                    erros.AppendLine("O nome do tipo de procedimento não pode conter mais que 60 caracteres.");
                }
            }

            if (tipoProcedimento.Valor < 0 || tipoProcedimento.Valor == 0) //rever
            {
                erros.AppendLine("O valor do procedimento deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Insert(tipoProcedimento);
            return respostaDB;
        }

        //Obter todos os registros
        public List<TipoProcedimento> GetAll()
        {
            return dal.GetAll();
        }

        //Atualizar um registro existente
        public string Update(TipoProcedimento tipoProcedimento)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(tipoProcedimento.Nome))
            {
                erros.AppendLine("O nome do tipo de procedimento deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(tipoProcedimento.Nome))
            {
                if (tipoProcedimento.Nome.Length > 60)
                {
                    erros.AppendLine("O nome do tipo de procedimento não pode conter mais que 60 caracteres.");
                }
            }

            if (tipoProcedimento.Valor < 0 || tipoProcedimento.Valor == 0) //rever
            {
                erros.AppendLine("O valor do procedimento deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Update(tipoProcedimento);
            return respostaDB;
        }

        //Excluir um registro
        public string Delete(TipoProcedimento tipoProcedimento)
        {
            StringBuilder erros = new StringBuilder();

            if (tipoProcedimento.Id == 0)
            {
                erros.AppendLine("O ID deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Delete(tipoProcedimento);
            return respostaDB;
        }

        //Obter um registro
        public TipoProcedimento GetById(TipoProcedimento tipoProcedimento)
        {
            StringBuilder erros = new StringBuilder();

            if (tipoProcedimento.Id == 0 || tipoProcedimento.Id < 0)
            {
                erros.AppendLine("O ID do tipo de procedimento deve ser informado.");
            }

            return dal.GetById(tipoProcedimento.Id);
        }

        //Obter último registro
        public TipoProcedimento GetLastRegister()
        {
            return dal.GetLastRegister();
        }
    }
}
