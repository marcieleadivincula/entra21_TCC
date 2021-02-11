using DataAccessLayer;
using Domain;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicalLayer
{
    public class ClinicaBLL
    {
        ClinicaDAL dal = new ClinicaDAL();

        //Incluir um registro
        public string Insert(Clinica clinica)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(clinica.Nome))
            {
                erros.AppendLine("O nome da clínica deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(clinica.Nome))
            {
                if (clinica.Nome.Length > 60)
                {
                    erros.AppendLine("O nome não pode conter mais que 60 caracteres.");
                }
            }

            if (clinica.DataInauguracao == null || clinica.DataInauguracao.Equals("")) // rever a data
            {
                erros.AppendLine("A data de inauguração da clínica deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Insert(clinica);
            return respostaDB;
        }

        // Obter todos os registros
        public List<Clinica> GetAll()
        {
            return dal.GetAll();
        }

        //Atualizar um registro existente
        public string Update(Clinica clinica)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(clinica.Nome))
            {
                erros.AppendLine("O nome da clínica deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(clinica.Nome))
            {
                if (clinica.Nome.Length > 60)
                {
                    erros.AppendLine("O nome não pode conter mais que 60 caracteres.");
                }
            }

            if (clinica.DataInauguracao == null || clinica.DataInauguracao.Equals("")) // rever a data
            {
                erros.AppendLine("A data de inauguração da clínica deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Update(clinica);
            return respostaDB;
        }

        //Excluir um registro
        public string Delete(Clinica clinica)
        {
            StringBuilder erros = new StringBuilder();

            if (clinica.Id == 0)
            {
                erros.AppendLine("O ID deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Delete(clinica);
            return respostaDB;
        }

        //Obter um registro
        public Clinica GetById(Clinica clinica)
        {
            StringBuilder erros = new StringBuilder();

            if (clinica.Id == 0 || clinica.Id < 0)
            {
                erros.AppendLine("O ID da clinica deve ser informado.");
            }

            return dal.GetById(clinica.Id);
        }

        //Obter último registro
        public Clinica GetLastRegister()
        {
            return dal.GetLastRegister();
        }

        //Obter registros de determinado endereço
        public List<Clinica> getByEndereco(Endereco endereco)
        {
            return dal.GetByEndereco(endereco);
        }
    }
}
