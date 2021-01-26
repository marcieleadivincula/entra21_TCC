using DataAccessLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class PacienteBLL
    {
        PacienteDAL dal = new PacienteDAL();

        public string Insert(Paciente paciente)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(paciente.Nome))
            {
                erros.AppendLine("O nome deve ser informado.");
            }

            if (paciente.Nome.Length > 60)
            {
                erros.AppendLine("O nome não pode conter mais que 60 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(paciente.Sobrenome))
            {
                erros.AppendLine("O sobrenome deve ser informado.");
            }

            if (paciente.Sobrenome.Length > 60)
            {
                erros.AppendLine("O nome não pode conter mais que 60 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(paciente.Rg))
            {
                erros.AppendLine("O rg deve ser informado.");
            }

            if (paciente.Rg.Length > 20)
            {
                erros.AppendLine("O rg não pode conter mais que 20 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(paciente.Cpf))
            {
                erros.AppendLine("O cpf deve ser informado.");
            }

            if (paciente.Cpf.Length > 14)
            {
                erros.AppendLine("O cpf não pode conter mais que 14 caracteres.");
            }

            // - VER OQUE PODE SER COLOCADO AQUI!!!
            //if (string.IsNullOrWhiteSpace(paciente.DataNascimento))
            //{
            //    erros.AppendLine("A data de nacimento deve ser informada.");
            //}

            //if (paciente.DataNascimento)
            //{
            //    erros.AppendLine(" ");
            //}
            // - VER OQUE PODE SER COLOCADO AQUI!!!

            if (string.IsNullOrWhiteSpace(paciente.Observacao))
            {
                erros.AppendLine("Uma observação deve ser informada.");
            }

            if (paciente.Observacao.Length > 250)
            {
                erros.AppendLine("A observação não pode conter mais que 250 caracteres.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Inserir(paciente);
            return respostaDB;
        }

        public List<Paciente> GetAll()
        {
            return dal.SelecionaTodos();
        }

        public string Update(Paciente paciente)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(paciente.Nome))
            {
                erros.AppendLine("O nome deve ser informado.");
            }

            if (paciente.Nome.Length > 60)
            {
                erros.AppendLine("O nome não pode conter mais que 60 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(paciente.Sobrenome))
            {
                erros.AppendLine("O sobrenome deve ser informado.");
            }

            if (paciente.Sobrenome.Length > 60)
            {
                erros.AppendLine("O nome não pode conter mais que 60 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(paciente.Rg))
            {
                erros.AppendLine("O rg deve ser informado.");
            }

            if (paciente.Rg.Length > 20)
            {
                erros.AppendLine("O rg não pode conter mais que 20 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(paciente.Cpf))
            {
                erros.AppendLine("O cpf deve ser informado.");
            }

            if (paciente.Cpf.Length > 14)
            {
                erros.AppendLine("O cpf não pode conter mais que 14 caracteres.");
            }

            // - VER OQUE PODE SER COLOCADO AQUI!!!
            //if (string.IsNullOrWhiteSpace(paciente.DataNascimento))
            //{
            //    erros.AppendLine("A data de nacimento deve ser informada.");
            //}

            //if (paciente.DataNascimento)
            //{
            //    erros.AppendLine(" ");
            //}
            // - VER OQUE PODE SER COLOCADO AQUI!!!

            if (string.IsNullOrWhiteSpace(paciente.Observacao))
            {
                erros.AppendLine("Uma observação deve ser informada.");
            }

            if (paciente.Observacao.Length > 250)
            {
                erros.AppendLine("A observação não pode conter mais que 250 caracteres.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Inserir(paciente);
            return respostaDB;
        }

        public string Delete(Paciente paciente)
        {
            string respostaDB = dal.Deletar(paciente);
            return respostaDB;
        }
    }
}
