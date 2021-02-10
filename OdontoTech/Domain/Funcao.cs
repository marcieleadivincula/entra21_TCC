using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Funcao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Salario { get; set; }
        public double Comissao { get; set; }
        public Funcao(int id, string nome, double salario, double comissao)
        {
            Id = id;
            Nome = nome;
            Salario = salario;
            Comissao = comissao;
        }

        /// <summary>
        /// construtor DAL
        /// </summary>
        public Funcao()
        {

        }

        public Funcao(int id)
        {
            Id = id;
        }
    }
}
