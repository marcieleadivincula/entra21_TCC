using DataAccessLayer;
using Domain;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicalLayer
{
    public class AgendaBLL
    {
        AgendaDAL dal = new AgendaDAL();

        //Incluir um registro
        public string Insert(Agenda agenda)
        {
            StringBuilder erros = new StringBuilder();

            if (agenda.DtAgenda == null || agenda.DtAgenda.Equals(""))
            {
                erros.AppendLine("A data de agendamento deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Insert(agenda);
            return respostaDB;
        }

        //Excluir um registro
        public string Delete(Agenda agenda)
        {
            StringBuilder erros = new StringBuilder();

            if (agenda.Id == 0)
            {
                erros.AppendLine("O ID deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Delete(agenda);
            return respostaDB;
        }

        //Atualizar um registro existente
        public string Update(Agenda agenda)
        {
            StringBuilder erros = new StringBuilder();

            if (agenda.DtAgenda == null || agenda.DtAgenda.Equals(""))
            {
                erros.AppendLine("A data de agendamento deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Update(agenda);
            return respostaDB;
        }

        //Obter todos os registros
        public List<Agenda> GetAll()
        {
            return dal.GetAll();
        }

        //Obter um registro
        public Agenda GetById(Agenda agenda)
        {
            StringBuilder erros = new StringBuilder();

            if (agenda.Id == 0 || agenda.Id < 0)
            {
                erros.AppendLine("O ID deve ser informado.");
            }

            return dal.GetById(agenda.Id);
        }

        //Obter último registro
        public Agenda GetLastRegister()
        {
            return dal.GetLastRegister();
        }

        //Obter toda a agenda por paciente
        public List<Agenda> GetByPaciente(Paciente paciente)
        {
            return dal.GetByPaciente(paciente);
        }

        //Obter toda a agenda por colaborador
        public List<Agenda> GetByColaborador(Colaborador colaborador)
        {
            return dal.GetByColaborador(colaborador);
        }
    }
}
