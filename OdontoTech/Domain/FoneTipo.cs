using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class FoneTipo
    {
        public int Id { get; set; }
        public string Tipo { get; set; }

        public FoneTipo(int id, string tipo)
        {
            Id = id;
            Tipo = tipo;
        }

        public FoneTipo()
        {

        }

        public override string ToString()
        {
            return $"{Id} - {Tipo}";
        }

        public FoneTipo(int id)
        {
            Id = id;
        }
    }
}
