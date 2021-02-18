using DataAccessLayer;
using Domain;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicalLayer
{
    public class ColaboradorBLL
    {
        ColaboradorDAL dal = new ColaboradorDAL();

        public string Insert(Colaborador colaborador)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(colaborador.Nome))
            {
                erros.AppendLine("O nome deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(colaborador.Nome))
            {
                if (colaborador.Nome.Length > 100)
                {
                    erros.AppendLine("O nome não pode conter mais que 100 caracteres.");
                }
            }

            if (string.IsNullOrWhiteSpace(colaborador.Cro))
            {
                erros.AppendLine("O CRO deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(colaborador.Cro))
            {
                if (colaborador.Cro.Length > 10)
                {
                    erros.AppendLine("O CRO não pode conter mais que 10 caracteres.");
                }
            }

            if (string.IsNullOrWhiteSpace(colaborador.CroEstado))
            {
                erros.AppendLine("O estado do CRO deve ser informado.");
            }

            if (colaborador.DataAdmissao == null)
            {
                erros.AppendLine("A data de admissão deve ser informada.");
            }

            if (!string.IsNullOrWhiteSpace(colaborador.CroEstado))
            {
                if (colaborador.CroEstado.Length > 2)
                {
                    erros.AppendLine("O estado do CRO não pode conter mais que 2 caracteres.");
                }
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Inserir(colaborador);
            return respostaDB;
        }

        public List<Colaborador> GetAll()
        {
            return dal.SelecionaTodos();
        }

        public string Update(Colaborador colaborador)
        {
            StringBuilder erros = new StringBuilder();
            if (string.IsNullOrWhiteSpace(colaborador.Nome))
            {
                erros.AppendLine("O nome deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(colaborador.Nome))
            {
                if (colaborador.Nome.Length > 100)
                {
                    erros.AppendLine("O nome não pode conter mais que 100 caracteres.");
                }
            }

            if (string.IsNullOrWhiteSpace(colaborador.Cro))
            {
                erros.AppendLine("O CRO deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(colaborador.Cro))
            {
                if (colaborador.Cro.Length > 10)
                {
                    erros.AppendLine("O CRO não pode conter mais que 10 caracteres.");
                }
            }

            if (string.IsNullOrWhiteSpace(colaborador.CroEstado))
            {
                erros.AppendLine("O estado do CRO deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(colaborador.CroEstado))
            {
                if (colaborador.CroEstado.Length > 2)
                {
                    erros.AppendLine("O estado do CRO não pode conter mais que 2 caracteres.");
                }
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Atualizar(colaborador);
            return respostaDB;
        }

        public string Delete(Colaborador colaborador)
        {
            StringBuilder erros = new StringBuilder();

            if (colaborador.Id == 0)
            {
                erros.AppendLine("O ID deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Deletar(colaborador);
            return respostaDB;
        }
        public Colaborador GetById(int id)
        {
            return dal.GetByID(id);
        }
    }
}
