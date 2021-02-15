using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AtendimentoProcedimentos
    {
        public AtendimentoProcedimentos(int id, Procedimento procedimento, Atendimento atendimento, int qtdProcedimento)
        {
            Id = id;
            Procedimento = procedimento;
            Atendimento = atendimento;
            QtdProcedimento = qtdProcedimento;
        }

        public int Id { get; set; }
        public Procedimento Procedimento { get; set; }
        public Atendimento Atendimento { get; set; }
        public int QtdProcedimento { get; set; }

        public AtendimentoProcedimentos()
        {

        }

        public AtendimentoProcedimentos(int id)
        {
            Id = id;
        }
    }
}
