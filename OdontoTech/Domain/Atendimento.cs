using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Atendimento
    {
        public int Id { get; set; }
        public Paciente Paciente { get; set; }
        public Colaborador Colaborador { get; set; }
        public List<Procedimento> Procedimentos = new List<Procedimento>();

        public Atendimento(int id, Paciente paciente, Colaborador colaborador, List<Procedimento> procedimentos)
        {
            this.Id = id;
            this.Paciente = paciente;
            this.Colaborador = colaborador;
            this.Procedimentos = procedimentos;
        }

        public Atendimento(int id, Paciente paciente, Colaborador colaborador)
        {
            this.Id = id;
            this.Paciente = paciente;
            this.Colaborador = colaborador;
        }
    }
}
