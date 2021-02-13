using DataAccessLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class ProcedimentoBLL
    {
        ProcedimentoDAL dal = new ProcedimentoDAL();

        //Incluir um registro
        public string Insert(Procedimento procedimento)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(procedimento.Nome))
            {
                erros.AppendLine("O nome do procedimento deve ser informada.");
            }

            

            if (string.IsNullOrWhiteSpace(procedimento.DescricaoProcedimento))
            {
                erros.AppendLine("A descrição do procedimento deve ser informada.");
            }   

            if (!string.IsNullOrWhiteSpace(procedimento.DescricaoProcedimento))
            {
                if (procedimento.DescricaoProcedimento.Length > 60)
                {
                    erros.AppendLine("A descrição do procedimento não pode conter mais que 60 caracteres.");
                }
            }
            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Insert(procedimento);
            return respostaDB;
        }

        //Obter todos os registros
        public List<Procedimento> GetAll()
        {
            return dal.GetAll();
        }

        //Atualizar um registro existente
        public string Update(Procedimento procedimento)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(procedimento.Nome))
            {
                erros.AppendLine("O nome do procedimento deve ser informada.");
            }            

            if (string.IsNullOrWhiteSpace(procedimento.DescricaoProcedimento))
            {
                erros.AppendLine("A descrição do procedimento deve ser informada.");
            }

            if (!string.IsNullOrWhiteSpace(procedimento.DescricaoProcedimento))
            {
                if (procedimento.DescricaoProcedimento.Length > 60)
                {
                    erros.AppendLine("A descrição do procedimento não pode conter mais que 60 caracteres.");
                }
            }
            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Update(procedimento);
            return respostaDB;
        }

        //Excluir um registro
        public string Delete(Procedimento procedimento)
        {
            StringBuilder erros = new StringBuilder();

            if (~procedimento.Id == 0)
            {
                erros.AppendLine("O ID deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Delete(procedimento);
            return respostaDB;
        }

        //Obter um registro
        public Procedimento GetById(Procedimento procedimento)
        {
            StringBuilder erros = new StringBuilder();

            if (procedimento.Id == 0 || procedimento.Id < 0)
            {
                erros.AppendLine("O ID do procedimento deve ser informado.");
            }

            return dal.GetById(procedimento.Id);
        }

        //Obter último registro
        public Procedimento GetLastRegister()
        {
            return dal.GetLastRegister();
        }

        //Obtem lista de atendimentos por procedimento
        public List<Atendimento> GetAtendimentos(int idProcedimento)
        {
            return dal.GetAtendimentos(idProcedimento);
        }

        public Procedimento GetProcedimentoIdTipo(int id)
        {
            return dal.GetProcedimentoIdTipo(id);
        }
    }
}
