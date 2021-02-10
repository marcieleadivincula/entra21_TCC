using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Logradouro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Bairro Bairro { get; set; }

        public Logradouro(int id, string nome, Bairro bairro)
        {
            Id = id;
            Nome = nome;
            Bairro = bairro;
        }
       
        /// <summary>
        /// CostrutorDAL.
        /// </summary>
        public Logradouro()
        {

        }

        public Logradouro(int id)
        {
            Id = id;
        }
    }
}
