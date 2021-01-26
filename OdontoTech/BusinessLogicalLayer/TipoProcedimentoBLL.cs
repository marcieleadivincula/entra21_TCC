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

        public string Insert(TipoProcedimento tipoProcedimento)
        {
            StringBuilder erros = new StringBuilder();

            if (tipoProcedimento.Id == 0 || tipoProcedimento.Id < 0)
            {
                erros.AppendLine("O ID do tipo procedimento deve ser informado.");
            }

            if (tipoProcedimento.Nome.Length > 60)
            {
                erros.AppendLine("O nome do tipo de procedimento não pode conter mais que 60 caracteres.");
            }

            if (tipoProcedimento.Valor < 0) //rever
            {
                erros.AppendLine("O valor do procedimento não pode ser negativo.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Inserir(tipoProcedimento);
            return respostaDB;
        }

        public List<TipoProcedimento> GetAll()
        {
            return dal.SelecionaTodos();
        }

        public string Update(TipoProcedimento tipoProcedimento)
        {
            StringBuilder erros = new StringBuilder();

            if (tipoProcedimento.Id == 0 || tipoProcedimento.Id < 0)
            {
                erros.AppendLine("O ID do tipo procedimento deve ser informado.");
            }

            if (string.IsNullOrWhiteSpace(tipoProcedimento.Nome))
            {
                erros.AppendLine("Uma descrição deve ser informada.");
            }

            if (tipoProcedimento.Nome.Length > 60)
            {
                erros.AppendLine("O nome do tipo de procedimento não pode conter mais que 60 caracteres.");
            }


            if (tipoProcedimento.Valor < 0) //rever
            {
                erros.AppendLine("O valor do procedimento não pode ser negativo.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Inserir(tipoProcedimento);
            return respostaDB;
        }

        public string Delete(TipoProcedimento tipoProcedimento)
        {
            string respostaDB = dal.Deletar(tipoProcedimento);
            return respostaDB;
        }

    }
}
