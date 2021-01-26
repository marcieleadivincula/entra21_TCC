using DataAccessLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class ProcedimentoBLL
    {
        ProcedimentoDAL dal = new ProcedimentoDAL();

        public string Insert(Procedimento procedimento)
        {
            StringBuilder erros = new StringBuilder();

            if (procedimento.Id == 0 || procedimento.Id < 0)
            {
                erros.AppendLine("O ID do procedimento deve ser informado.");
            }

            if (string.IsNullOrWhiteSpace(procedimento.DescricaoProcedimento))
            {
                erros.AppendLine("Uma descrição deve ser informada.");
            }

            if (procedimento.DescricaoProcedimento.Length > 60)
            {
                erros.AppendLine("A descrição do procedimento não pode conter mais que 60 caracteres.");
            }

            if (procedimento.TipoProcedimento.Id == 0 || procedimento.TipoProcedimento.Id < 0)
            {
                erros.AppendLine("O ID do tipo de procedimento deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Inserir(procedimento);
            return respostaDB;
        }

        public List<Procedimento> GetAll()
        {
            return dal.SelecionaTodos();
        }

        public string Update(Procedimento procedimento)
        {
            StringBuilder erros = new StringBuilder();

            if (procedimento.Id == 0 || procedimento.Id < 0)
            {
                erros.AppendLine("O ID do procedimento deve ser informado.");
            }

            if (procedimento.DescricaoProcedimento.Length > 60)
            {
                erros.AppendLine("A descrição do procedimento não pode conter mais que 60 caracteres.");
            }

            if (procedimento.TipoProcedimento.Id == 0 || procedimento.TipoProcedimento.Id < 0)
            {
                erros.AppendLine("O ID do tipo de procedimento deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Inserir(procedimento);
            return respostaDB;
        }

        public string Delete(Procedimento procedimento)
        {
            string respostaDB = dal.Deletar(procedimento);
            return respostaDB;
        }
    }
}
