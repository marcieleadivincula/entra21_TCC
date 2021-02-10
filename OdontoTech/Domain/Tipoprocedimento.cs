using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TipoProcedimento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }

        public TipoProcedimento(int id, string nome, double valor)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
        }
        public TipoProcedimento()
        {

        }

        public TipoProcedimento(int id)
        {
            Id = id;
        }
    }
}
