using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Pagamento
    {
        public Pagamento(int idPagamento, DateTime dtPagamento, int idTipoPagamento)
        {
            this.idPagamento = idPagamento;
            this.dtPagamento = dtPagamento;
            this.idTipoPagamento = idTipoPagamento;
        }

        public int idPagamento { get; set; }
        public DateTime dtPagamento { get; set; }
        public int idTipoPagamento { get; set; }
    }
}
