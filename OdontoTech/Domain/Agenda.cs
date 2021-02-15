using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Agenda
    {
        public int Id { get; set; }
        public Paciente Paciente { get; set; }
        public Colaborador Colaborador { get; set; }
        public DateTime DtAgenda { get; set; }

        public Agenda()
        {

        }

        public Agenda(int id)
        {
            Id = id;
        }

        public Agenda(int id, Paciente paciente, Colaborador colaborador, DateTime dtAgenda)
        {
            Id = id;
            Paciente = paciente;
            Colaborador = colaborador;
            DtAgenda = dtAgenda;
        }
    }
}
