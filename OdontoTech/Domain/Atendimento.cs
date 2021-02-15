
using System;
using System.Collections.Generic;

namespace Domain
{
    public class Atendimento
    {
        public int Id { get; set; }
        public Paciente Paciente { get; set; }
        public Colaborador Colaborador { get; set; }
        public DateTime DtInicioAtendimento { get; set; }
        public DateTime DtFinalAtendimento { get; set; }
        public string StatusAtendimento { get; set; }
        public List<Procedimento> Procedimentos = new List<Procedimento>();

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
      
        public Atendimento(int id, Paciente paciente, Colaborador colaborador, DateTime dtInicioAtendimento, DateTime dtFinalAtendimento, string statusAtendimento, List<Procedimento> procedimentos)
        {
            Id = id;
            Paciente = paciente;
            Colaborador = colaborador;
            DtInicioAtendimento = dtInicioAtendimento;
            DtFinalAtendimento = dtFinalAtendimento;
            StatusAtendimento = statusAtendimento;
            Procedimentos = procedimentos;
        }
    }
}
