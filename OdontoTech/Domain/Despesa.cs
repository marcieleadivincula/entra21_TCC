using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Despesa
    {
        public Despesa(int idDespesa, DateTime data, double valor, string descricao, string colaborador)
        {
            this.idDespesa = idDespesa;
            Data = data;
            Valor = valor;
            Descricao = descricao;
            Colaborador = colaborador;
        }

        public Despesa()
        {
        }

        public int idDespesa { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
        public string Colaborador { get; set; }
    }
}
