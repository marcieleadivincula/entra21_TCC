using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Domain
{
    public class Bairro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Cidade Cidade { get; set; }

        public Bairro(int id, string nome, Cidade cidade)
        {
            Id = id;
            Nome = nome;
            Cidade = cidade;
        }       

        /// <summary>
        /// construtor dal.
        /// </summary>
        public Bairro()
        {

        }

        public Bairro(int id)
        {
            Id = id;
        }
    }
}
