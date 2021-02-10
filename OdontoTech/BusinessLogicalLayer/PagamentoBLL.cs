using DataAccessLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class PagamentoBLL
    {
        PagamentoDAL dal = new PagamentoDAL();

        public string Insert(Pagamento pagamento)
        {
            StringBuilder erros = new StringBuilder();

            if (pagamento.Id == 0 || pagamento.Id < 0)
            {
                erros.AppendLine("O ID do pagamento deve ser informado.");
            }

            if (pagamento.TipoPagamento.Id == 0 || pagamento.TipoPagamento.Id < 0)
            {
                erros.AppendLine("O nome do pagamento deve ser informado.");
            }

            
            if (pagamento.DataPagamento == null) 
            {
                erros.AppendLine("A data do pagamento deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Inserir(pagamento);
            return respostaDB;
        }

        public List<Pagamento> GetAll()
        {
            return dal.SelecionaTodos();
        }

        public string Update(Pagamento pagamento)
        {
            StringBuilder erros = new StringBuilder();
            if (pagamento.Id == 0 || pagamento.Id < 0)
            {
                erros.AppendLine("O ID do pagamento deve ser informado.");
            }

            if (pagamento.TipoPagamento.Id == 0 || pagamento.TipoPagamento.Id < 0)
            {
                erros.AppendLine("O nome do pagamento deve ser informado.");
            }


            if (pagamento.DataPagamento == null) // rever a data
            {
                erros.AppendLine("A data do pagamento deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Atualizar(pagamento);
            return respostaDB;
        }

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

            string respostaDB = dal.Deletar(pagamento);
            return respostaDB;
        }

    }
}
