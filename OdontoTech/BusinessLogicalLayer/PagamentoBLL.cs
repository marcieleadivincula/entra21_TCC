using DataAccessLayer;
using Domain;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicalLayer
{
    public class PagamentoBLL
    {
        PagamentoDAL dal = new PagamentoDAL();

        //Incluir um registro
        public string Insert(Pagamento pagamento)
        {
            StringBuilder erros = new StringBuilder();

            if (pagamento.DataPagamento == null || pagamento.DataPagamento.Equals("")) 
            {
                erros.AppendLine("A data do pagamento deve ser informado.");
            }

            if (pagamento.ValorPagamento <= 0)
            {
                erros.AppendLine("A valor do pagamento deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Insert(pagamento);
            return respostaDB;
        }

        //Obter todos os registros
        public List<Pagamento> GetAll()
        {
            return dal.GetAll();
        }

        //Atualizar um registro existente
        public string Update(Pagamento pagamento)
        {
            StringBuilder erros = new StringBuilder();

            if (pagamento.DataPagamento == null || pagamento.DataPagamento.Equals("")) // rever a data
            {
                erros.AppendLine("A data do pagamento deve ser informado.");
            }

            if (pagamento.ValorPagamento <= 0)
            {
                erros.AppendLine("A valor do pagamento deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Update(pagamento);
            return respostaDB;
        }

        //Excluir um registro
        public string Delete(Pagamento pagamento)
        {
            StringBuilder erros = new StringBuilder();

            if (pagamento.Id == 0)
            {
                erros.AppendLine("O ID deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Delete(pagamento);
            return respostaDB;
        }

        //Obter um registro
        public Pagamento GetById(Pagamento pagamento)
        {
            StringBuilder erros = new StringBuilder();

            if (pagamento.Id == 0 || pagamento.Id < 0)
            {
                erros.AppendLine("O ID do pagamento deve ser informado.");
            }

            return dal.GetById(pagamento.Id);
        }

        //Obter último registro
        public Pagamento GetLastRegister()
        {
            return dal.GetLastRegister();
        }

        //Obtem lista de pagamentos por tipo
        public List<Pagamento> GetByTipoPagamento(TipoPagamento tipoPagamento)
        {
            return dal.GetByTipoPagamento(tipoPagamento);
        }
    }
}
