using DataAccessLayer;
using Domain;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicalLayer
{
    public class EstoqueBLL
    {
        EstoqueDAL dal = new EstoqueDAL();

        public string Insert(Estoque estoque)
        {
            StringBuilder erros = new StringBuilder();

            if (estoque.Id == 0 || estoque.Id < 0)
            {
                erros.AppendLine("O ID do estoque deve ser informado.");
            }

            if (estoque.QtdProduto <= 0)
            {
                erros.AppendLine("A quantidade de produto deve ser informada.");
            }

            if (estoque.DataEntrada == null)
            {
                erros.AppendLine("A data de entrada deve ser informada.");
            }

            if (estoque.DataSaida == null)
            {
                erros.AppendLine("A data de saida deve ser informada.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Inserir(estoque);
            return respostaDB;
        }

        public List<Estoque> GetAll()
        {
            return dal.SelecionaTodos();
        }

        public string Update(Estoque estoque)
        {
            StringBuilder erros = new StringBuilder();

            if (estoque.Id == 0 || estoque.Id < 0)
            {
                erros.AppendLine("O ID do estoque deve ser informado.");
            }

            if (estoque.QtdProduto <= 0)
            {
                erros.AppendLine("A quantidade de produto deve ser informada.");
            }

            if (estoque.DataEntrada == null)
            {
                erros.AppendLine("A data de entrada deve ser informada.");
            }

            if (estoque.DataSaida == null)
            {
                erros.AppendLine("A data de saida deve ser informada.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Atualizar(estoque);
            return respostaDB;
        }

        public string Delete(Estoque estoque)
        {
            string respostaDB = dal.Deletar(estoque);
            return respostaDB;
        }
    }
}
