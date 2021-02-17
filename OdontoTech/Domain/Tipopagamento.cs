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
        public int Parcelas { get; set; }
        public TipoPagamento(int id, string tipo, int parcelas)
        {
            Id = id;
            Tipo = tipo;
            Parcelas = parcelas;
        }

        /// <summary>
        /// construtor DAL
        /// </summary>
        public TipoPagamento()
        {

        }
        public TipoPagamento(int id)
        {
            Id = id;
        }

        
    }
}
