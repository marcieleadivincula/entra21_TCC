using System.Collections.Generic;
using System;

namespace Domain
{
    public class Atendimento
    {
        public int Id { get; set; }
        public Paciente Paciente { get; set; }
        public Colaborador Colaborador { get; set; }
        public DateTime DtAtendimento { get; set; }
        public string Status { get; set; }
        public List<Procedimento> Procedimentos = new List<Procedimento>();

   
        public Atendimento(int id, Paciente paciente, Colaborador colaborador, DateTime dtAtendimento, string status, List<Procedimento> procedimentos)
        {
            Id = id;
            Paciente = paciente;
            Colaborador = colaborador;
            DtAtendimento = dtAtendimento;
            Status = status;
            Procedimentos = procedimentos;
        }

        public Atendimento(int id, Paciente paciente, Colaborador colaborador)
        {
            Id = id;
            Paciente = paciente;
            Colaborador = colaborador;
        }

        /// <summary>
        /// construtor para desenvolvimento DAL
        /// </summary>
        public Atendimento()
        {

        }

        public Atendimento(int id)
        {
            Id = id;
        }

    }
}
