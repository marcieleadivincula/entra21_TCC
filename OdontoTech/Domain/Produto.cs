using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Produto
    {
        public Produto(int idProduto, string nomeProduto, int idTipoEmbalagem, double precoProduto, DateTime dtCompra)
        {
            this.idProduto = idProduto;
            this.nomeProduto = nomeProduto;
            this.idTipoEmbalagem = idTipoEmbalagem;
            this.precoProduto = precoProduto;
            this.dtCompra = dtCompra;
        }

        public int idProduto { get; set; }
        public string nomeProduto { get; set; }
        public int idTipoEmbalagem { get; set; }
        public double precoProduto { get; set; }
        public DateTime dtCompra { get; set; }
    }
}
