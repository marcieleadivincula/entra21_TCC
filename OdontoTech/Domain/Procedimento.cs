using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Procedimento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoProcedimento TipoProcedimento { get; set; }
        public string DescricaoProcedimento { get; set; }

        public List<Atendimento> Atendimentos = new List<Atendimento>();

        public Procedimento(int id, string nome, TipoProcedimento tipoProcedimento, string descricaoProcedimento, List<Atendimento> atendimentos)
        {
            Id = id;
            Nome = nome;
            TipoProcedimento = tipoProcedimento;
            DescricaoProcedimento = descricaoProcedimento;
            Atendimentos = atendimentos;
        }

        /// <summary>
        /// construtor para DAL.
        /// </summary>
        public Procedimento()
        {

        }

        public Procedimento(int id)
        {
            Id = id;
        }

        public Procedimento(int id, string nome, TipoProcedimento tipoProcedimento, string descricaoProcedimento)
        {
            Id = id;
            Nome = nome;
            TipoProcedimento = tipoProcedimento;
            DescricaoProcedimento = descricaoProcedimento;
        }
    }
}
