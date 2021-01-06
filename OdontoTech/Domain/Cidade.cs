using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Estado Estado { get; set; }

        public Cidade(int id, string nome, Estado estado)
        {
            Id = id;
            Nome = nome;
            Estado = estado;
        }
    }
}
