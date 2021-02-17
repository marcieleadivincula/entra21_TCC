using DataAccessLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogicalLayer
{
    public class DispesaBLL
    {
        DispesaDAL dal = new DispesaDAL();

        public string Insert(Dispesa dispesa)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(dispesa.Descricao))
            {
                erros.AppendLine("A descrição da dispesa deve ser informada.");
            }


            if (dispesa.Data == null)
            {
                erros.AppendLine("A data da dispesa deve ser informada.");
            }

            if (dispesa.Valor == 0)
            {
                erros.AppendLine("A descrição do procedimento deve ser informada.");
            }

            if (!string.IsNullOrWhiteSpace(dispesa.Descricao))
            {
                if (dispesa.Descricao.Length > 45)
                {
                    erros.AppendLine("A descrição da dispesa não pode conter mais que 45 caracteres.");
                }
            }
            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Insert(dispesa);
            return respostaDB;
        }
        public string Delete(Dispesa dispesa)
        {
            StringBuilder erros = new StringBuilder();

            if (dispesa.idMovimentacaofinanceira == 0)
            {
                erros.AppendLine("O ID deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Delete(dispesa);
            return respostaDB;
        }

        public List<Dispesa> GetAll()
        {
            return dal.GetAll();
        }
    }
}