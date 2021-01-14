using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Domain;

namespace Domain
{
    public class Bairro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Cidade cidade { get; set; }

        public Bairro(int id, string nome, Cidade cidade)
        {
            Id = id;
            Nome = nome;
            this.cidade = cidade;
        }

        /// <summary>
        /// contrutor dal.
        /// </summary>
        public Bairro()
        {

        }

    }
}
