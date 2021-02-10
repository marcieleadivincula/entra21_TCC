﻿using DataAccessLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class BairroBLL
    {
        BairroDAL dal = new BairroDAL();
        public string Insert(Bairro bairro)
        {
            StringBuilder erros = new StringBuilder();


            if (string.IsNullOrWhiteSpace(bairro.Nome))
            {
                erros.AppendLine("O nome deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(bairro.Nome))
            {
               if (bairro.Nome.Length > 50)
               {
                  erros.AppendLine("O nome não pode conter mais que 50 caracteres.");
               }
            }


            if (bairro.Cidade.Id == 0 || bairro.Cidade.Id < 0)
            {
                erros.AppendLine("A cidade deve ser informada.");
            }

            if (bairro.Id == 0 || bairro.Id < 0)
            {
                erros.AppendLine("O bairro deve ser informada.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Inserir(bairro);
            return respostaDB;
        }

        public string Delete(Bairro bairro)
        {
            StringBuilder erros = new StringBuilder();

            if (bairro.Id == 0)
            {
                erros.AppendLine("O ID deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Deletar(bairro);
            return respostaDB;
        }

        public string Update(Bairro bairro)
        {
            StringBuilder erros = new StringBuilder();


            if (string.IsNullOrWhiteSpace(bairro.Nome))
            {
                erros.AppendLine("O nome deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(bairro.Nome))
            {
                if (bairro.Nome.Length > 50)
                {
                    erros.AppendLine("O nome não pode conter mais que 50 caracteres.");
                }
            }

            if (bairro.Cidade.Id == 0 || bairro.Cidade.Id < 0)
            {
                erros.AppendLine("A cidade deve ser informada.");
            }

            if (bairro.Id == 0 || bairro.Id < 0)
            {
                erros.AppendLine("O bairro deve ser informada.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Atualizar(bairro);
            return respostaDB;
        }

        public List<Bairro> GetAll()
        {
            return dal.SelecionaTodos();
        }
    }
}
