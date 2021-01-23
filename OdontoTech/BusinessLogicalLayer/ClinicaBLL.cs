using DataAccessLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class ClinicaBLL
    {
        ClinicaDAL dal = new ClinicaDAL();

        public string Insert(Clinica clinica)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(clinica.Nome))
            {
                erros.AppendLine("O nome da clínica deve ser informado.");
            }

            if (clinica.Nome.Length > 60)
            {
                erros.AppendLine("O nome não pode conter mais que 60 caracteres.");
            }

            if (clinica.DataInauguracao == null) // rever a data
            {
                erros.AppendLine("A data de inauguração da clínica deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Inserir(clinica);
            return respostaDB;
        }

        public List<Clinica> GetAll()
        {
            return dal.SelecionaTodos();
        }

        public string Update(Clinica clinica)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(clinica.Nome))
            {
                erros.AppendLine("O nome da clínica deve ser informado.");
            }

            if (clinica.Nome.Length > 60)
            {
                erros.AppendLine("O nome não pode conter mais que 60 caracteres.");
            }

            if (clinica.DataInauguracao == null) // rever a data
            {
                erros.AppendLine("A data de inauguração da clínica deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Inserir(clinica);
            return respostaDB;
        }

        public string Delete(Clinica clinica)
        {
            string respostaDB = dal.Deletar(clinica);
            return respostaDB;
        }

    }
}
