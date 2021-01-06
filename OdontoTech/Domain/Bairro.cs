using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Bairro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int idCidade { get; set; }

        public Bairro(int id, string nome, int idCidade)
        {
            Id = id;
            Nome = nome;
            this.idCidade = idCidade;
        }

    }
}
