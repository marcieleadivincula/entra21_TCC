using System;

namespace Domain
{
    public class Pagamento
    {
        public int Id { get; set; }
        public DateTime DataPagamento { get; set; } 
        public double ValorPagamento { get; set; } 
        public TipoPagamento TipoPagamento { get; set; }
        public Paciente Paciente { get; set; }

        /// <summary>
        /// construtor DAL.
        /// </summary>
        public Pagamento()
        {

        }

        public Pagamento(int id)
        {
            Id = id;
        }

        public Pagamento(int id, DateTime dataPagamento, double valorPagamento, TipoPagamento tipoPagamento, Paciente paciente)
        {
            Id = id;
            DataPagamento = dataPagamento;
            ValorPagamento = valorPagamento;
            TipoPagamento = tipoPagamento;
            Paciente = paciente;
        }
    }
}
