using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Dispesa
    {
        public Dispesa(int idMovimentacaofinanceira, DateTime data, double valor, string descricao, string colaborador)
        {
            this.idMovimentacaofinanceira = idMovimentacaofinanceira;
            Data = data;
            Valor = valor;
            Descricao = descricao;
            Colaborador = colaborador;
        }

        public Dispesa()
        {
        }

        public int idMovimentacaofinanceira { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
        public string Colaborador { get; set; }
    }
}
