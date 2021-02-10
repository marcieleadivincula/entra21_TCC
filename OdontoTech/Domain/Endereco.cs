using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Endereco
    {
        public int Id { get; set; }
        public Logradouro Logradouro { get; set; }
        public int NumeroCasa { get; set; }
        public string Cep { get; set; }

        public Endereco(int id, Logradouro logradouro, int numeroCasa, string cep)
        {
            Id = id;
            Logradouro = logradouro;
            NumeroCasa = numeroCasa;
            Cep = cep;
        }

        /// <summary>
        /// Construtor para DAL
        /// </summary>
        public Endereco()
        {

        }

        public Endereco(int id)
        {
            Id = id;
        }

    }
}
