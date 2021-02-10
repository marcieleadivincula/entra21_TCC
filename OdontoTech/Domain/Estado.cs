using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Estado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Pais Pais { get; set; }

        public Estado(int id, string nome, Pais pais)
        {
            Id = id;
            Nome = nome;
            Pais = pais;
        }
        /// <summary>
        /// construtor para DAL.
        /// </summary>
        public Estado()
        {

        }
        public Estado(int id)
        {
            Id = id;
        }
    }
}
