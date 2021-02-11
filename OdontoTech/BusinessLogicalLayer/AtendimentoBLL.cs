﻿using DataAccessLayer;
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

        //Incluir um registro
        public string Insert(Atendimento atendimento)
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

            string respostaDB = dal.Insert(atendimento);
            return respostaDB;
        }

        //Excluir um registro
        public string Delete(Atendimento atendimento)
        {
            StringBuilder erros = new StringBuilder();

            if (atendimento.Id == 0)
            {
                erros.AppendLine("O ID deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Delete(atendimento);
            return respostaDB;
        }

        //Atualizar um registro existente
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

            string respostaDB = dal.Update(atendimento);
            return respostaDB;
        }

        //Obter todos os registros
        public List<Atendimento> GetAll()
        {
            return dal.GetAll();
        }

        //Obter um registro
        public Atendimento GetById(Atendimento atendimento)
        {
            StringBuilder erros = new StringBuilder();

            if (atendimento.Id < 0)
            {
                erros.AppendLine("O ID do atendimento deve ser informado.");
            }

            return dal.GetById(atendimento.Id);
        }

        //Obter último registro
        public Atendimento GetLastRegister()
        {
            return dal.GetLastRegister();
        }

        //Obter lista de procedimentos do atendimento
        public List<Procedimento> GetProcedimentos(int idAtendimento)
        {
            return dal.GetProcedimentos(idAtendimento);
        }
    }
}
