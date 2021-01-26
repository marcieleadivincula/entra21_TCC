using DataAccessLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class ProdutoBLL
    {
        ProdutoDAL dal = new ProdutoDAL();

        public string Insert(Produto produto)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(produto.Nome))
            {
                erros.AppendLine("O nome deve ser informado.");
            }

            if (produto.Nome.Length > 60)
            {
                erros.AppendLine("O nome não pode conter mais que 60 caracteres.");
            }

            if (produto.Preco == 0)
            {
                erros.AppendLine("O preço deve ser informado.");
            }

            // ADICIONAR O SISTEMA DA DATA!

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Inserir(produto);
            return respostaDB;
        }

        public List<Produto> GetAll()
        {
            return dal.SelecionaTodos();
        }

        public string Update(Produto produto)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(produto.Nome))
            {
                erros.AppendLine("O nome deve ser informado.");
            }

            if (produto.Nome.Length > 60)
            {
                erros.AppendLine("O nome não pode conter mais que 60 caracteres.");
            }

            if (produto.Preco == 0)
            {
                erros.AppendLine("O preço deve ser informado.");
            }

            // ADICIONAR O SISTEMA DA DATA!

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Inserir(produto);
            return respostaDB;
        }

        public string Delete(Produto produto)
        {
            string respostaDB = dal.Deletar(produto);
            return respostaDB;
        }
    }
}
