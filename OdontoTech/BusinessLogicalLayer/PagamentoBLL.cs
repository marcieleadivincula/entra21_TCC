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

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Inserir(pagamento);
            return respostaDB;
        }

        public string Delete(Pagamento pagamento)
        {
            string respostaDB = dal.Deletar(pagamento);
            return respostaDB;
        }

    }
}
