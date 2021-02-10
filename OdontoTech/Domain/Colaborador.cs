using System;

namespace Domain
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cro { get; set; }
        public string CroEstado { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime DataDemissao { get; set; }
        public Endereco Endereco { get; set; }
        public Funcao Funcao { get; set; }
        public Clinica Clinica { get; set; }
        public bool Ferias { get; set; }
        public bool Demitido { get; set; }

        public Colaborador(int id, string nome, string cro, string croEstado, DateTime dataAdmissao, DateTime dataDemissao, Endereco endereco, Funcao funcao, Clinica clinica, bool ferias, bool demitido)
        {
            Id = id;
            Nome = nome;
            Cro = cro;
            CroEstado = croEstado;
            DataAdmissao = dataAdmissao;
            DataDemissao = dataDemissao;
            Endereco = endereco;
            Funcao = funcao;
            Clinica = clinica;
            Ferias = ferias;
            Demitido = demitido;
        }

        public Colaborador(int id, string nome, string cro, string croEstado, DateTime dataAdmissao, Endereco endereco, Funcao funcao, Clinica clinica, bool ferias, bool demitido)
        {
            Id = id;
            Nome = nome;
            Cro = cro;
            CroEstado = croEstado;
            DataAdmissao = dataAdmissao;
            Endereco = endereco;
            Funcao = funcao;
            Clinica = clinica;
            Ferias = ferias;
            Demitido = demitido;
        }

        /// <summary>
        /// construtor Dal.
        /// </summary>
        public Colaborador()
        {

        }

        public Colaborador(int id)
        {
            Id = id;
        }
    }
}
