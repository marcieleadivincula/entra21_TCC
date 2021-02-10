using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; } 
        public string Observacao { get; set; }
        public Endereco Endereco { get; set; }

        public Paciente(int id, string nome, string sobrenome, string rg, string cpf, DateTime dataNascimento, string observacao, Endereco endereco)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Rg = rg;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Observacao = observacao;
            Endereco = endereco;
        }
        public Paciente()
        {
           
        }

        public Paciente(int id)
        {
            Id = id;
        }
    }
}
