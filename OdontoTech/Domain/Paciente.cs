namespace Domain
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string DataNascimento { get; set; } // Data esta como string ! (TEMPORARIO)
        public string Observacao { get; set; }
        public Endereco Endereco { get; set; }

        public Paciente(int id, string nome, string sobrenome, string rg, string cpf, string dataNascimento, string observacao, Endereco endereco)
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
    }
}
