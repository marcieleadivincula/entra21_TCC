using DataAccessLayer;
using Domain;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicalLayer
{
    public class EstoqueBLL
    {
        EstoqueDAL dal = new EstoqueDAL();

        //Incluir um registro
        public string Insert(Estoque estoque)
        {
            StringBuilder erros = new StringBuilder();

            if (estoque.QtdProduto <= 0)
            {
                erros.AppendLine("A quantidade do produto deve ser informada.");
            }

            if (estoque.DataEntrada == null || estoque.DataEntrada.Equals(""))
            {
                erros.AppendLine("A data de entrada deve ser informada.");
            }

            if (estoque.DataSaida == null || estoque.DataSaida.Equals(""))
            {
                erros.AppendLine("A data de saída deve ser informada.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Insert(estoque);
            return respostaDB;
        }

        //Obter todos os registros
        public List<Estoque> GetAll()
        {
            return dal.GetAll();
        }

        //Atualizar um registro existente
        public string Update(Estoque estoque)
        {
            StringBuilder erros = new StringBuilder();

            if (estoque.QtdProduto <= 0)
            {
                erros.AppendLine("A quantidade do produto deve ser informada.");
            }

            if (estoque.DataEntrada == null || estoque.DataEntrada.Equals(""))
            {
                erros.AppendLine("A data de entrada deve ser informada.");
            }

            if (estoque.DataSaida == null || estoque.DataSaida.Equals(""))
            {
                erros.AppendLine("A data de saída deve ser informada.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Update(estoque);
            return respostaDB;
        }

        //Excluir um registro
        public string Delete(Estoque estoque)
        {
            StringBuilder erros = new StringBuilder();

            if (estoque.Id == 0)
            {
                erros.AppendLine("O ID deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Delete(estoque);
            return respostaDB;
        }

        //Obter um registro
        public Estoque GetById(Estoque estoque)
        {
            StringBuilder erros = new StringBuilder();

            if (estoque.Id == 0 || estoque.Id < 0)
            {
                erros.AppendLine("O ID do estoque deve ser informado.");
            }

            return dal.GetById(estoque.Id);
        }

        //Obter último registro
        public Estoque GetLastRegister()
        {
            return dal.GetLastRegister();
        }

        //Obtem os produtos do Estoque
        public List<Estoque> GetByProduto(Produto produto)
        {
            return dal.GetByProduto(produto);
        }
    }
}
