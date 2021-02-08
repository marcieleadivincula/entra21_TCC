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

        public string Insert(Endereco Endereco)
        {
            StringBuilder erros = new StringBuilder();

            if (Endereco.Id == 0  || Endereco.Id < 0)
            {
                erros.AppendLine("O ID de endereco deve ser informado.");
            }

            if (Endereco.Logradouro.Id == 0 || Endereco.Logradouro.Id < 0)
            {
                erros.AppendLine("O ID de Logradouro deve ser informado.");
            }

            if (Endereco.NumeroCasa == 0 || Endereco.NumeroCasa < 0)
            {
                erros.AppendLine("O Numero da casa do endereco deve ser informado.");
            }

            if (string.IsNullOrWhiteSpace(Endereco.Cep))
            {
                erros.AppendLine("O Cep deve ser informado.");
            }

            if (Endereco.Cep.Length > 10)
            {
                erros.AppendLine("O CEP não pode conter mais que 10 caracteres.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Inserir(Endereco);
            return respostaDB;
        }

        public List<Endereco> GetAll()
        {
            return dal.SelecionaTodos();
        }

        public string Update(Endereco Endereco)
        {
            StringBuilder erros = new StringBuilder();
            if (Endereco.Id == 0 || Endereco.Id < 0)
            {
                erros.AppendLine("O ID de endereco deve ser informado.");
            }

            if (Endereco.Logradouro.Id == 0 || Endereco.Logradouro.Id < 0)
            {
                erros.AppendLine("O ID de Logradouro deve ser informado.");
            }

            if (Endereco.NumeroCasa == 0 || Endereco.NumeroCasa < 0)
            {
                erros.AppendLine("O Numero da casa do endereco deve ser informado.");
            }

            if (string.IsNullOrWhiteSpace(Endereco.Cep))
            {
                erros.AppendLine("O Cep deve ser informado.");
            }

            if (Endereco.Cep.Length > 10)
            {
                erros.AppendLine("O CEP não pode conter mais que 10 caracteres.");
            }


            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Atualizar(Endereco);
            return respostaDB;
        }

        public string Delete(Endereco Endereco)
        {
            string respostaDB = dal.Deletar(Endereco);
            return respostaDB;
        }
    }
}
