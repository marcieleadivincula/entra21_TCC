using DataAccessLayer;
using Domain;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicalLayer
{
    public class ClinicaBLL
    {
        ClinicaDAL dal = new ClinicaDAL();

        public string Insert(Clinica clinica)
        {
            StringBuilder erros = new StringBuilder();

            if (clinica.Id == 0 || clinica.Id < 0)
            {
                erros.AppendLine("O ID da clínica deve ser informado.");
            }

            if (string.IsNullOrWhiteSpace(clinica.Nome))
            {
                erros.AppendLine("O nome da clínica deve ser informado.");
            }

            if (clinica.Nome.Length > 60)
            {
                erros.AppendLine("O nome não pode conter mais que 60 caracteres.");
            }

            if (clinica.Endereco.Id == 0 || clinica.Id < 0)
            {
                erros.AppendLine("O ID do endereço deve ser informado.");
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

            if (clinica.Id == 0 || clinica.Id < 0)
            {
                erros.AppendLine("O ID da clínica deve ser informado.");
            }

            if (string.IsNullOrWhiteSpace(clinica.Nome))
            {
                erros.AppendLine("O nome da clínica deve ser informado.");
            }

            if (clinica.Nome.Length > 60)
            {
                erros.AppendLine("O nome não pode conter mais que 60 caracteres.");
            }

            if (clinica.Endereco.Id == 0 || clinica.Id < 0)
            {
                erros.AppendLine("O ID do endereço deve ser informado.");
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
