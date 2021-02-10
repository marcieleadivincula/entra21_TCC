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

            if (contato.Fone.Length > 20)
            {
                erros.AppendLine("O telefone não pode conter mais que 20 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(contato.Email))
            {
                erros.AppendLine("O email deve ser informada.");
            }

            if (contato.Email.Length > 50)
            {
                erros.AppendLine("O email não pode conter mais que 50 caracteres.");
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

            if (contato.Fone.Length > 20)
            {
                erros.AppendLine("O telefone não pode conter mais que 20 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(contato.Email))
            {
                erros.AppendLine("O email deve ser informada.");
            }

            if (contato.Email.Length > 50)
            {
                erros.AppendLine("O email não pode conter mais que 50 caracteres.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Update(contato);
            return respostaDB;
        }

        public string Delete(Contato contato)
        {
            string respostaDB = dal.Delete(contato);
            return respostaDB;
        }
    }
}
