using DataAccessLayer;
using Domain;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicalLayer
{
    public class PacienteBLL
    {
        PacienteDAL dal = new PacienteDAL();

        //Incluir um registro
        public string Insert(Paciente paciente)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(paciente.Nome))
            {
                erros.AppendLine("O nome deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(paciente.Nome))
            {

                if (paciente.Nome.Length > 60)
                {
                    erros.AppendLine("O nome não pode conter mais que 60 caracteres.");
                }
            }


            if (string.IsNullOrWhiteSpace(paciente.Sobrenome))
            {
                erros.AppendLine("O sobrenome deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(paciente.Sobrenome))
            {
                if (paciente.Sobrenome.Length > 60)
                {
                    erros.AppendLine("O sobrenome não pode conter mais que 60 caracteres.");
                }
            } 

            if (string.IsNullOrWhiteSpace(paciente.Rg))
            {
                erros.AppendLine("O rg deve ser informado.");
            }
            if (!string.IsNullOrWhiteSpace(paciente.Rg))
            {
                if (paciente.Rg.Length > 20)
                {
                    erros.AppendLine("O rg não pode conter mais que 20 caracteres.");
                }
            }
            if (string.IsNullOrWhiteSpace(paciente.Cpf))
            {
                erros.AppendLine("O cpf deve ser informado.");

            }
            if (!string.IsNullOrWhiteSpace(paciente.Cpf))
            {
                if (paciente.Cpf.Length > 14)
                {
                    erros.AppendLine("O cpf não pode conter mais que 14 caracteres.");
                }

            }
        

            
            if (paciente.DataNascimento == null)
            {
                erros.AppendLine("A data de nacimento deve ser informada.");
            }     

            if (string.IsNullOrWhiteSpace(paciente.Observacao))
            {
                erros.AppendLine("Uma observação deve ser informada.");
            }
            if (!string.IsNullOrWhiteSpace(paciente.Observacao))
            {
                if (paciente.Observacao.Length > 250)
                {
                    erros.AppendLine("A observação não pode conter mais que 250 caracteres.");
                }

            }
            

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Insert(paciente);
            return respostaDB;
        }

        //Obter todos os registros
        public List<Paciente> GetAll()
        {
            return dal.GetAll();
        }

        //Atualizar um registro existente
        public string Update(Paciente paciente)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(paciente.Nome))
            {
                erros.AppendLine("O nome deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(paciente.Nome))
            {

                if (paciente.Nome.Length > 60)
                {
                    erros.AppendLine("O nome não pode conter mais que 60 caracteres.");
                }
            }


            if (string.IsNullOrWhiteSpace(paciente.Sobrenome))
            {
                erros.AppendLine("O sobrenome deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(paciente.Sobrenome))
            {
                if (paciente.Sobrenome.Length > 60)
                {
                    erros.AppendLine("O sobrenome não pode conter mais que 60 caracteres.");
                }
            }

            if (string.IsNullOrWhiteSpace(paciente.Rg))
            {
                erros.AppendLine("O rg deve ser informado.");
            }
            if (!string.IsNullOrWhiteSpace(paciente.Rg))
            {
                if (paciente.Rg.Length > 20)
                {
                    erros.AppendLine("O rg não pode conter mais que 20 caracteres.");
                }
            }
            if (string.IsNullOrWhiteSpace(paciente.Cpf))
            {
                erros.AppendLine("O cpf deve ser informado.");

            }
            if (!string.IsNullOrWhiteSpace(paciente.Cpf))
            {
                if (paciente.Cpf.Length > 14)
                {
                    erros.AppendLine("O cpf não pode conter mais que 14 caracteres.");
                }

            }



            if (paciente.DataNascimento == null)
            {
                erros.AppendLine("A data de nacimento deve ser informada.");
            }

            if (string.IsNullOrWhiteSpace(paciente.Observacao))
            {
                erros.AppendLine("Uma observação deve ser informada.");
            }
            if (!string.IsNullOrWhiteSpace(paciente.Observacao))
            {
                if (paciente.Observacao.Length > 250)
                {
                    erros.AppendLine("A observação não pode conter mais que 250 caracteres.");
                }

            }
            if (paciente.Id == 0)
            {
                return "O ID do paciente deve ser informado.";
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Update(paciente);
            return respostaDB;
        }

        //Excluir um registro
        public string Delete(Paciente paciente)
        {
            StringBuilder erros = new StringBuilder();

            if (paciente.Id == 0)
            {
                erros.AppendLine("O ID deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Delete(paciente);
            return respostaDB;
        }

        //Obter um registro
        public Paciente GetById(Paciente paciente)
        {
            StringBuilder erros = new StringBuilder();

            if (paciente.Id == 0 || paciente.Id < 0)
            {
                erros.AppendLine("O ID do paciente deve ser informado.");
            }

            return dal.GetById(paciente.Id);
        }

        //Obter último registro
        public Paciente GetLastRegister()
        {
            return dal.GetLastRegister();
        }
    }
}
