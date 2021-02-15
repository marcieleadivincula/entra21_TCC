using DataAccessLayer;
using Domain;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicalLayer
{
    public class AtendimentoProcedimentosBLL
    {
        AtendimentoProcedimentosDAL dal = new AtendimentoProcedimentosDAL();

        //Incluir um registro
        public string Insert(AtendimentoProcedimentos atendimentoProcedimentos)
        {
            StringBuilder erros = new StringBuilder();

            if (atendimentoProcedimentos.Procedimento.Id == 0 || atendimentoProcedimentos.Procedimento.Id < 0)
            {
                erros.AppendLine("O ID do procedimento deve ser informado.");
            }

            if (atendimentoProcedimentos.Atendimento.Id == 0 || atendimentoProcedimentos.Atendimento.Id < 0)
            {
                erros.AppendLine("O ID do atendimento deve ser informado.");
            }

            if (atendimentoProcedimentos.QtdProcedimento == 0 || atendimentoProcedimentos.QtdProcedimento < 0)
            {
                erros.AppendLine("A quantidade de procedimentos deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Insert(atendimentoProcedimentos);
            return respostaDB;
        }

        //Excluir um registro
        public string Delete(AtendimentoProcedimentos atendimentoProcedimentos)
        {
            StringBuilder erros = new StringBuilder();

            if (atendimentoProcedimentos.Id == 0)
            {
                erros.AppendLine("O ID deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Delete(atendimentoProcedimentos);
            return respostaDB;
        }

        //Atualizar um registro existente
        public string Update(AtendimentoProcedimentos atendimentoProcedimentos)
        {
            StringBuilder erros = new StringBuilder();


            if (atendimentoProcedimentos.Procedimento.Id == 0 || atendimentoProcedimentos.Procedimento.Id < 0)
            {
                erros.AppendLine("O ID do procedimento deve ser informado.");
            }

            if (atendimentoProcedimentos.Atendimento.Id == 0 || atendimentoProcedimentos.Atendimento.Id < 0)
            {
                erros.AppendLine("O ID do atendimento deve ser informado.");
            }

            if (atendimentoProcedimentos.QtdProcedimento == 0 || atendimentoProcedimentos.QtdProcedimento < 0)
            {
                erros.AppendLine("A quantidade de procedimentos deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Update(atendimentoProcedimentos);
            return respostaDB;
        }

        //Obter todos os registros
        public List<AtendimentoProcedimentos> GetAll()
        {
            return dal.GetAll();
        }

        //Obter um registro
        public AtendimentoProcedimentos GetById(AtendimentoProcedimentos atendimentoProcedimentos)
        {
            StringBuilder erros = new StringBuilder();

            if (atendimentoProcedimentos.Id < 0)
            {
                erros.AppendLine("O ID deve ser informado.");
            }

            return dal.GetById(atendimentoProcedimentos.Id);
        }

        //Obter último registro
        public AtendimentoProcedimentos GetLastRegister()
        {
            return dal.GetLastRegister();
        }
    }
}
