using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Clinica
    {
        public int Id { get; set; }
        public string nNome { get; set; }
        public DateTime DataInauguracao { get; set; } //verificar qual usar para apenas DATA
        public Endereco Endereco { get; set; }

        public Clinica(int id, string nNome, DateTime dataInauguracao, Endereco endereco)
        {
            Id = id;
            this.nNome = nNome;
            DataInauguracao = dataInauguracao;
            Endereco = endereco;
        }
    }
}
