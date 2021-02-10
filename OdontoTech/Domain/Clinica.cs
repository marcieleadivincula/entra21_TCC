using System;

namespace Domain
{
    public class Clinica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInauguracao { get; set; } //verificar qual usar para apenas DATA
        public Endereco Endereco { get; set; }

        public Clinica(int id, string nome, DateTime dataInauguracao, Endereco endereco)
        {
            Id = id;
            Nome = nome;
            DataInauguracao = dataInauguracao;
            Endereco = endereco;
        }
        /// <summary>
        /// construtor DAL.
        /// </summary>
        public Clinica()
        {
            
        }

        public Clinica(int id)
        {
            Id = id;
        }
    }
}
