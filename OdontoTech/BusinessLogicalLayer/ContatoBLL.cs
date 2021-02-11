using DataAccessLayer;
using Domain;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicalLayer
{
    public class ContatoBLL
    {
        ContatoDAL dal = new ContatoDAL();

        //Incluir um registro
        public string Insert(Contato contato)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(contato.Fone))
            {
                erros.AppendLine("O telefone deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(contato.Fone))
            {
                if (contato.Fone.Length > 20)
                {
                    erros.AppendLine("O telefone não pode conter mais que 20 caracteres.");
                }
            }

            if (string.IsNullOrWhiteSpace(contato.Email))
            {
                erros.AppendLine("O email deve ser informada.");
            }

            if (!string.IsNullOrWhiteSpace(contato.Email))
            {
                if (contato.Email.Length > 50)
                {
                    erros.AppendLine("O email não pode conter mais que 50 caracteres.");
                }
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Insert(contato);
            return respostaDB;
        }

        //Obter todos os registros
        public List<Contato> GetAll()
        {
            return dal.GetAll();
        }

        //Atualizar um registro existente
        public string Update(Contato contato)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(contato.Fone))
            {
                erros.AppendLine("O telefone deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(contato.Fone))
            {
                if (contato.Fone.Length > 20)
                {
                    erros.AppendLine("O telefone não pode conter mais que 20 caracteres.");
                }
            }

            if (string.IsNullOrWhiteSpace(contato.Email))
            {
                erros.AppendLine("O email deve ser informada.");
            }

            if (!string.IsNullOrWhiteSpace(contato.Email))
            {
                if (contato.Email.Length > 50)
                {
                    erros.AppendLine("O email não pode conter mais que 50 caracteres.");
                }
            }


            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Update(contato);
            return respostaDB;
        }

        //Excluir um registro
        public string Delete(Contato contato)
        {
            StringBuilder erros = new StringBuilder();

            if (contato.Id == 0)
            {
                erros.AppendLine("O ID deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Delete(contato);
            return respostaDB;
        }

        //Obter um registro
        public Contato GetById(Contato contato)
        {
            StringBuilder erros = new StringBuilder();

            if (contato.Id == 0 || contato.Id < 0)
            {
                erros.AppendLine("O ID do contato deve ser informado.");
            }

            return dal.GetById(contato.Id);
        }

        //Obter último registro
        public Contato GetLastRegister()
        {
            return dal.GetLastRegister();
        }

        //Obtem os contatos do colaborador
        public List<Contato> GetByColaborador(Colaborador colaborador)
        {
            return dal.GetByColaborador(colaborador);
        }

        //Obtem os contatos do paciente
        public List<Contato> GetByPaciente(Paciente paciente)
        {
            return dal.GetByPaciente(paciente);
        }
    }
}
