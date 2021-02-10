using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Pais
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Pais(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        /// <summary>
        /// Pais DAL
        /// </summary>
        public Pais()
        {

        }

        public override string ToString()
        {
            return $"{Id} - {Nome}";
        }

        public Pais(int id)
        {
            Id = id;
        }

    }
}
