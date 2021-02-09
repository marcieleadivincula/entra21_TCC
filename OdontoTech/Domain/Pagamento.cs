using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Pagamento
    {
        public int Id { get; set; }
        public DateTime DataPagamento { get; set; } 
        public TipoPagamento TipoPagamento { get; set; }

        public Pagamento(int id, DateTime dataPagamento, TipoPagamento tipoPagamento)
        {
            Id = id;
            DataPagamento = dataPagamento;
            TipoPagamento = tipoPagamento;
        }

        /// <summary>
        /// construtor DAL.
        /// </summary>
        public Pagamento()
        {

        }

    }
}
