using DataAccessLayer;
using Domain;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicalLayer
{
    public class TipoEmbalagemBLL
    {
        TipoEmbalagemDAL dal = new TipoEmbalagemDAL();

        //Incluir um registro
        public string Insert(TipoEmbalagem tipoEmbalagem)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(tipoEmbalagem.Descricao))
            {
                erros.AppendLine("A descrição do tipo de embalagem deve ser informada.");
            }

            if (!string.IsNullOrWhiteSpace(tipoEmbalagem.Descricao))
            {
                if (tipoEmbalagem.Descricao.Length > 60)
                {
                    erros.AppendLine("A descrição do tipo de embalagem não pode conter mais que 60 caracteres.");
                }
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Insert(tipoEmbalagem);
            return respostaDB;
        }

        //Obter todos os registros
        public List<TipoEmbalagem> GetAll()
        {
            return dal.GetAll();
        }

        //Atualizar um registro existente
        public string Update(TipoEmbalagem tipoEmbalagem)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(tipoEmbalagem.Descricao))
            {
                erros.AppendLine("A descrição do tipo de embalagem deve ser informada.");
            }

            if (!string.IsNullOrWhiteSpace(tipoEmbalagem.Descricao))
            {
                if (tipoEmbalagem.Descricao.Length > 60)
                {
                    erros.AppendLine("A descrição do tipo de embalagem não pode conter mais que 60 caracteres.");
                }
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Update(tipoEmbalagem);
            return respostaDB;
        }

        //Excluir um registro
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

            string respostaDB = dal.Delete(tipoEmbalagem);
            return respostaDB;
        }

        //Obter um registro
        public TipoEmbalagem GetById(TipoEmbalagem tipoEmbalagem)
        {
            StringBuilder erros = new StringBuilder();

            if (tipoEmbalagem.Id == 0 || tipoEmbalagem.Id < 0)
            {
                erros.AppendLine("O ID do tipo de embalagem deve ser informado.");
            }

            return dal.GetById(tipoEmbalagem.Id);
        }

        //Obter último registro
        public TipoEmbalagem GetLastRegister()
        {
            return dal.GetLastRegister();
        }

        public TipoEmbalagem ValidaTipoEmbalagem(string embalagem)
        {
            TipoEmbalagem tipoEmbalagem = new TipoEmbalagem(0, embalagem);
            TipoEmbalagemDAL tipoEmbalagemDAL = new TipoEmbalagemDAL();

            bool x = true;


                List<TipoEmbalagem> lista = tipoEmbalagemDAL.GetAll();
                foreach (var item in lista)
                {
                    if (item.Descricao == tipoEmbalagem.Descricao)
                    {
                        x = false;
                        tipoEmbalagem.Id = item.Id;
                        break;
                    }
                }

            if (x)
            {
                tipoEmbalagem.Descricao = embalagem;
                tipoEmbalagemDAL.Insert(tipoEmbalagem);
                tipoEmbalagem = tipoEmbalagemDAL.GetLastRegister();
            }
            return tipoEmbalagem;
        }
    }
}
