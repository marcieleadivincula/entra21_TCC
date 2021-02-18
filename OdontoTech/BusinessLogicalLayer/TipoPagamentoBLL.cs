using DataAccessLayer;
using Domain;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicalLayer
{
    public class TipoPagamentoBLL
    {
        TipoPagamentoDAL dal = new TipoPagamentoDAL();

        //Incluir um registro
        public string Insert(TipoPagamento tipoPagamento)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(tipoPagamento.Tipo))
            {
                erros.AppendLine("O tipo de pagamento deve ser informada.");
            }

            if (tipoPagamento.Tipo.Length > 60)
            {
                erros.AppendLine("O tipo de pagamento não pode conter mais que 60 caracteres.");
            }

            if (tipoPagamento.Parcelas <= 0)
            {
                erros.AppendLine("O número de parcelas não pode ser menor ou igual a zero.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Insert(tipoPagamento);
            return respostaDB;
        }

        //Obter todos os registros
        public List<TipoPagamento> GetAll()
        {
            return dal.GetAll();
        }

        //Atualizar um registro existente
        public string Update(TipoPagamento tipoPagamento)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(tipoPagamento.Tipo))
            {
                erros.AppendLine("O tipo de pagamento deve ser informada.");
            }

            if (tipoPagamento.Tipo.Length > 60)
            {
                erros.AppendLine("O tipo de pagamento não pode conter mais que 60 caracteres.");
            }

            if (tipoPagamento.Parcelas <= 0)
            {
                erros.AppendLine("O número de parcelas não pode ser menor ou igual a zero.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Update(tipoPagamento);
            return respostaDB;
        }

        //Excluir um registro
        public string Delete(TipoPagamento tipoPagamento)
        {
            string respostaDB = dal.Delete(tipoPagamento);
            return respostaDB;
        }

        //Obter um registro
        public TipoPagamento GetById(TipoPagamento tipoPagamento)
        {
            StringBuilder erros = new StringBuilder();

            if (tipoPagamento.Id == 0 || tipoPagamento.Id < 0)
            {
                erros.AppendLine("O ID do tipo de pagamento deve ser informado.");
            }

            return dal.GetById(tipoPagamento.Id);
        }

        //Obter último registro
        public TipoPagamento GetLastRegister()
        {
            return dal.GetLastRegister();
        }
    }
}
