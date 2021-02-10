using DataAccessLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class TipoEmbalagemBLL
    {
        TipoEmbalagemDAL dal = new TipoEmbalagemDAL();

        public string Insert(TipoEmbalagem tipoEmbalagem)
        {
            StringBuilder erros = new StringBuilder();

            if (tipoEmbalagem.Id == 0 || tipoEmbalagem.Id < 0)
            {
                erros.AppendLine("O ID da embalagem deve ser informado.");
            }

            if (string.IsNullOrWhiteSpace(tipoEmbalagem.Descricao))
            {
                erros.AppendLine("Uma descrição deve ser informada.");
            }

            if (!string.IsNullOrWhiteSpace(tipoEmbalagem.Descricao))
            {
                if (tipoEmbalagem.Descricao.Length > 60)
                {
                    erros.AppendLine("A descrição não pode conter mais que 60 caracteres.");
                }
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Inserir(tipoEmbalagem);
            return respostaDB;
        }

        public List<TipoEmbalagem> GetAll()
        {
            return dal.SelecionaTodos();
        }

        public string Update(TipoEmbalagem tipoEmbalagem)
        {
            StringBuilder erros = new StringBuilder();

            if (tipoEmbalagem.Id == 0 || tipoEmbalagem.Id < 0)
            {
                erros.AppendLine("O ID da embalagem deve ser informado.");
            }

            if (string.IsNullOrWhiteSpace(tipoEmbalagem.Descricao))
            {
                erros.AppendLine("Uma descrição deve ser informada.");
            }

            if (!string.IsNullOrWhiteSpace(tipoEmbalagem.Descricao))
            {
                if (tipoEmbalagem.Descricao.Length > 60)
                {
                    erros.AppendLine("A descrição não pode conter mais que 60 caracteres.");
                }
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Inserir(tipoEmbalagem);
            return respostaDB;
        }

        public string Delete(TipoEmbalagem tipoEmbalagem)
        {
            StringBuilder erros = new StringBuilder();

            if (tipoEmbalagem.Id == 0)
            {
                erros.AppendLine("O ID deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Deletar(tipoEmbalagem);
            return respostaDB;
        }
    }
}
