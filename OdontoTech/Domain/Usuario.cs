using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public Colaborador Colaborador { get; set; }

        public Usuario(int id, string login, string senha)
        {
            Id = id;
            Login = login;
            Senha = senha;
        }

        public Usuario(int id, string login, string senha, Colaborador colaborador)
        {
            Id = id;
            Login = login;
            Senha = senha;
            Colaborador = colaborador;
        }

        /// <summary>
        /// Construtor DAL
        /// </summary>
        public Usuario()
        {

        }

        public Usuario(int id)
        {
            Id = id;
        }
    }
}
