using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Paciente
    {
        public Paciente(int idPaciente, string nome, string sobrenome, string rg, string cpf, string dtNascimento, string obs, int idEndereco)
        {
            this.idPaciente = idPaciente;
            Nome = nome;
            Sobrenome = sobrenome;
            Rg = rg;
            Cpf = cpf;
            this.dtNascimento = dtNascimento;
            this.obs = obs;
            this.idEndereco = idEndereco;
        }

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
