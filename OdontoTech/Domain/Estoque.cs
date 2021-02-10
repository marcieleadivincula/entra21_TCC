using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Estoque
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public int QtdProduto { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }

        public Estoque(int id, Produto produto, int qtdProduto, DateTime dataEntrada, DateTime dataSaida)
        {
            Id = id;
            Produto = produto;
            QtdProduto = qtdProduto;
            DataEntrada = dataEntrada;
            DataSaida = dataSaida;
        }
        /// <summary>
        /// construtor DAL
        /// </summary>
        public Estoque()
        {

        }

        public Estoque(int id)
        {
            Id = id;
        }
    }
}
