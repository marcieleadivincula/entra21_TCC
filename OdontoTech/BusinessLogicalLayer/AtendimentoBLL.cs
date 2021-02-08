using DataAccessLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class AtendimentoBLL
    {
        AtendimentoDAL dal = new AtendimentoDAL();

        public string Insert(Atendimento atendimento)
        {
            StringBuilder erros = new StringBuilder();

            if (atendimento.Id == 0 || atendimento.Id < 0)
            {
                erros.AppendLine("O ID de atendimento deve ser informado.");
            }
            if (atendimento.Paciente.Id == 0 || atendimento.Paciente.Id < 0 )
            {
                erros.AppendLine("O ID de Paciente deve ser informado.");
            }
            if (atendimento.Colaborador.Id == 0 || atendimento.Colaborador.Id < 0)
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


            if (atendimento.Id == 0 || atendimento.Id < 0)
            {
                erros.AppendLine("O ID de atendimento deve ser informado.");
            }
            if (atendimento.Paciente.Id == 0 || atendimento.Paciente.Id < 0)
            {
                erros.AppendLine("O ID de Paciente deve ser informado.");
            }
            if (atendimento.Colaborador.Id == 0 || atendimento.Colaborador.Id < 0)
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

        public List<Atendimento> GetAll()
        {
            return dal.SelecionaTodos();
        }

        //Obter um registro
        public Atendimento GetAtendimentoById(Atendimento atendimento)
        {
            StringBuilder erros = new StringBuilder();

            if (atendimento.Id < 0)
            {
                erros.AppendLine("O ID do atendimento deve ser informado.");
            }

            return dal.GetAtendimentoById(atendimento.Id);
        }

        //Obter último registro
        //public Atendimento getLastRegister()
        //{
        //return dal.getLastRegister();

        //}
    }
}
