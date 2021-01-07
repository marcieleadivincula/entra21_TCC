using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TipoPagamento
    {
        public int Id { get; set; }
        public string Tipo { get; set; }

        public TipoPagamento(int id, string tipoPagamento)
        {
            Id = id;
            Tipo = tipoPagamento;
        }
    }
}
