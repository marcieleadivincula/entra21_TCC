using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Contato
    {
        public int Id { get; set; }
        public string Fone { get; set; }
        public FoneTipo FoneTipo { get; set; }
        public string Email { get; set; }
        public Paciente Paciente { get; set; }
        public Colaborador Colaborador { get; set; }

        public Contato(int id, string fone, FoneTipo foneTipo, string email, Colaborador colaborador)
        {
            Id = id;
            Fone = fone;
            FoneTipo = foneTipo;
            Email = email;
            Colaborador = colaborador;
        }

        public Contato(int id, string fone, FoneTipo foneTipo, string email, Paciente paciente)
        {
            Id = id;
            Fone = fone;
            FoneTipo = foneTipo;
            Email = email;
            Paciente = paciente;
        }

        public Contato(int id)
        {
            Id = id;
        }

        public Contato()
        {

        }
    }
}
