using BusinessLogicalLayer;
using NUnit.Framework;
using System;

namespace Domain.IntegrationTests
{
    public class EstoqueTests
    {

        private EstoqueBLL bll;
        private string str;
        private Produto produto;
        private DateTime DataEntrada;
        private DateTime DataSaida;

        [SetUp]
        public void Setup()
        {
            bll = new EstoqueBLL();
            produto = new Produto();
            produto.Id = 1;
            DataEntrada = DateTime.Now;
            DataSaida = DateTime.Now;
            str = string.Empty;
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestarInsertEstoque()
        {
            Estoque test = new Estoque(1, produto, 1, DataEntrada, DataSaida);

            str = bll.Insert(test);

            Assert.AreEqual(str, "Estoque cadastrado com sucesso!");
        }

        [Test]
        public void TestarInsertEstoqueQuantidadeNaoInformada()
        {
            Estoque test = new Estoque(1, produto, -1, DataEntrada, DataSaida);

            str = bll.Insert(test);

            Assert.AreEqual(str, "A quantidade do produto deve ser informada.\r\n");
        }

        [Test]
        public void TestarAtualizarEstoque()
        {
            Estoque test = new Estoque(1, produto, 1, DataEntrada, DataSaida);

            str = bll.Update(test);

            Assert.AreEqual(str, "Estoque atualizado com êxito!");
        }

        [Test]
        public void TestarDeletarEstoque()
        {
            Estoque test2 = new Estoque(1000, produto, 1000, DataEntrada, DataSaida);

            str = bll.Insert(test2);

            Estoque test = new Estoque(1000, produto, 1000, DataEntrada, DataSaida);
            str = bll.Delete(test);

            Assert.AreEqual(str, "Estoque deletado com êxito!");
        }

    }
}
