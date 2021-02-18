using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Despesa
    {
        public Despesa(int idDespesa, DateTime data, double valor, string descricao)
        {
            this.idDespesa = idDespesa;
            Data = data;
            Valor = valor;
            Descricao = descricao;
        }

        public Despesa()
        {
        }

        public int idDespesa { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
    }
}
