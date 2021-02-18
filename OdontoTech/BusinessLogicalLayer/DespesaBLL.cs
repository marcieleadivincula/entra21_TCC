using DataAccessLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogicalLayer
{
    public class DespesaBLL
    {
        DespesaDAL dal = new DespesaDAL();

        public string Insert(Despesa despesa)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(despesa.Descricao))
            {
                erros.AppendLine("A descrição da despesa deve ser informada.");
            }


            if (despesa.Data == null)
            {
                erros.AppendLine("A data da despesa deve ser informada.");
            }

            if (despesa.Valor <= 0)
            {
                erros.AppendLine("O valor da despesa não pode ser negativo ou zero.");
            }

            if (!string.IsNullOrWhiteSpace(despesa.Descricao))
            {
                if (despesa.Descricao.Length > 45)
                {
                    erros.AppendLine("A descrição da despesa não pode conter mais que 45 caracteres.");
                }
            }
            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Insert(despesa);
            return respostaDB;
        }

        public string Update(Despesa despesa)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(despesa.Descricao))
            {
                erros.AppendLine("A descrição da despesa deve ser informada.");
            }


            if (despesa.Data == null)
            {
                erros.AppendLine("A data da despesa deve ser informada.");
            }

            if (despesa.Valor <= 0)
            {
                erros.AppendLine("O valor da despesa não pode ser negativo ou zero.");
            }

            if (!string.IsNullOrWhiteSpace(despesa.Descricao))
            {
                if (despesa.Descricao.Length > 45)
                {
                    erros.AppendLine("A descrição da despesa não pode conter mais que 45 caracteres.");
                }
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Update(despesa);
            return respostaDB;
        }
        public string Delete(Despesa despesa)
        {
            StringBuilder erros = new StringBuilder();

            if (despesa.idDespesa == 0)
            {
                erros.AppendLine("O ID deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Delete(despesa);
            return respostaDB;
        }

        public List<Despesa> GetAll()
        {
            return dal.GetAll();
        }
    }
}