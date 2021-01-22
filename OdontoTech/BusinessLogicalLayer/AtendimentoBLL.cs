using DataAccessLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    class AtendimentoBLL
    {
        AtendimentoDAL dal = new AtendimentoDAL();

        public string Insert(Atendimento atendimento)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(Convert.ToString(atendimento.Id)))
            {
                erros.AppendLine("O ID de atendimento deve ser informado.");
            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(atendimento.Paciente.Id)))
            {
                erros.AppendLine("O ID de Paciente deve ser informado.");
            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(atendimento.Colaborador.Id)))
            {
                erros.AppendLine("O ID de Colaborador deve ser informado.");
            }


            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Inserir(atendimento);
            return respostaDB;
        }

        public string Delete(Atendimento atendimento)
        {
            string respostaDB = dal.Deletar(atendimento);
            return respostaDB;
        }

        public string Update(Atendimento atendimento)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(Convert.ToString(atendimento.Id)))
            {
                erros.AppendLine("O ID de atendimento deve ser informado.");
            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(atendimento.Paciente.Id)))
            {
                erros.AppendLine("O ID de Paciente deve ser informado.");
            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(atendimento.Colaborador.Id)))
            {
                erros.AppendLine("O ID de Colaborador deve ser informado.");
            }


            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Atualizar(atendimento);
            return respostaDB;
        }

        public List<Bairro> GetAll()
        {
            return dal.SelecionaTodos();
        }
    }
}
