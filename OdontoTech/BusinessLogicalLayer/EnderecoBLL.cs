using DataAccessLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class EnderecoBLL
    {
        EnderecoDAL dal = new EnderecoDAL();

        //Incluir um registro
        public string Insert(Endereco endereco)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(endereco.Cep))
            {
                erros.AppendLine("O Cep deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(endereco.Cep))
            {
                if (endereco.Cep.Length > 10)
                {
                    erros.AppendLine("O CEP não pode conter mais que 10 caracteres.");
                }
            }

            if (endereco.NumeroCasa == 0 || endereco.NumeroCasa < 0)
            {
                erros.AppendLine("O número do endereço deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Insert(endereco);
            return respostaDB;
        }

        //Obter todos os registros
        public List<Endereco> GetAll()
        {
            return dal.GetAll();
        }

        //Atualizar um registro existente
        public string Update(Endereco endereco)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(endereco.Cep))
            {
                erros.AppendLine("O Cep deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(endereco.Cep))
            {
                if (endereco.Cep.Length > 10)
                {
                    erros.AppendLine("O CEP não pode conter mais que 10 caracteres.");
                }
            }

            if (endereco.NumeroCasa == 0 || endereco.NumeroCasa < 0)
            {
                erros.AppendLine("O número do endereço deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Update(endereco);
            return respostaDB;
        }

        //Excluir um registro
        public string Delete(Endereco endereco)
        {
            StringBuilder erros = new StringBuilder();

            if (endereco.Id == 0)
            {
                erros.AppendLine("O ID deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Delete(endereco);
            return respostaDB;
        }

        //Obter um registro
        public Endereco GetById(Endereco endereco)
        {
            StringBuilder erros = new StringBuilder();

            if (endereco.Id == 0 || endereco.Id < 0)
            {
                erros.AppendLine("O ID do endereco deve ser informado.");
            }

            return dal.GetById(endereco.Id);
        }

        //Obter último registro
        public Endereco getLastRegister()
        {
            return dal.GetLastRegister();
        }

        //Obter registros de determinado logradouro
        public List<Endereco> GetByLogradouro(Logradouro logradouro)
        {
            return dal.GetByLogradouro(logradouro);
        }
    }
}
