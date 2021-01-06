using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Paciente
    {
        public int idPaciente { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string dtNascimento { get; set; } // Data esta como string ! (TEMPORARIO)
        public string obs { get; set; }
        public int idEndereco { get; set; }

    }
}
