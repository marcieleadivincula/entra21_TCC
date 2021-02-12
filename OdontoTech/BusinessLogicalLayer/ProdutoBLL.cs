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

        //Incluir um registro
        public string Insert(Produto produto)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(produto.Nome))
            {
                erros.AppendLine("O nome do produto deve ser informado.");
            }          

            if (!string.IsNullOrWhiteSpace(produto.Nome))
            {
                if (produto.Nome.Length > 60)
                {
                    erros.AppendLine("O nome não pode conter mais que 60 caracteres.");
                }
            }

            if (produto.Preco == 0 || produto.Preco < 0)
            {
                erros.AppendLine("O preço do produto deve ser informado.");
            }

            if (produto.DataCompra == null || produto.DataCompra.Equals(""))
            {
                erros.AppendLine("A data de compra do produto deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Insert(produto);
            return respostaDB;
        }

        //Obter todos os registros
        public List<Produto> GetAll()
        {
            return dal.GetAll();
        }

        //Atualizar um registro existente
        public string Update(Produto produto)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(produto.Nome))
            {
                erros.AppendLine("O nome do produto deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(produto.Nome))
            {
                if (produto.Nome.Length > 60)
                {
                    erros.AppendLine("O nome não pode conter mais que 60 caracteres.");
                }
            }

            if (produto.Preco == 0 || produto.Preco < 0)
            {
                erros.AppendLine("O preço do produto deve ser informado.");
            }

            if (produto.DataCompra == null || produto.DataCompra.Equals("")) 
            {
                erros.AppendLine("A data de compra do produto deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Update(produto);
            return respostaDB;
        }

        //Excluir um registro
        public string Delete(Produto produto)
        {
            StringBuilder erros = new StringBuilder();

            if (produto.Id == 0)
            {
                erros.AppendLine("O ID deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Delete(produto);
            return respostaDB;
        }
        
        //Obter um registro
        public Produto GetById(Produto produto)
        {
            StringBuilder erros = new StringBuilder();

            if (produto.Id == 0 || produto.Id < 0)
            {
                erros.AppendLine("O ID do produto deve ser informado.");
            }

            return dal.GetById(produto.Id);
        }

        //Obter último registro
        public Produto GetLastRegister()
        {
            return dal.GetLastRegister();
        }

        //Obtem lista de embalagens por tipo
        public List<Produto> GetByTipoEmbalagem(TipoEmbalagem tipoEmbalagem)
        {
            return dal.GetByTipoEmbalagem(tipoEmbalagem);
        }

        public bool VerificaProduto(string NomeProduto)
        {
            ProdutoBLL pdall = new ProdutoBLL();

            List<Produto> lpdt = pdall.GetAll();

            foreach (var item in lpdt)
            {
                if (item.Nome == NomeProduto)
                {
                    return true;
                }
            }

            return false;
        }

        public int GetIdPorNome(string nome)
        {
            ProdutoDAL pdall = new ProdutoDAL();
            return pdall.PegaIDporNome(nome);
        }
    }
}
