using BusinessLogicalLayer;
using NUnit.Framework;
using System;

namespace Domain.IntegrationTests
{
    public class ProdutoTests
    {
        private ProdutoBLL bll;
        private string str;
        private TipoEmbalagem tipoEmbalagem;
        private DateTime data;

        [SetUp]
        public void Setup()
        {
            bll = new ProdutoBLL();
            tipoEmbalagem = new TipoEmbalagem();
            data = DateTime.Now;
            tipoEmbalagem.Id = 1;
            str = string.Empty;
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestarInsertProduto()
        {
            Produto test = new Produto(1, "Coca", tipoEmbalagem, 150, data);

            str = bll.Insert(test);

            Assert.AreEqual(str, "Produto cadastrado com sucesso");
        }

        [Test]
        public void TestarInsertProdutoNomeVazio()
        {
            Produto test = new Produto(1, "", tipoEmbalagem, 150, data);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O nome deve ser informado.\r\n");
        }

        [Test]
        public void TestarInsertProdutoNomeTamanhoExcedido()
        {
            Produto test = new Produto(1, "0123456789012345678901234567890123456789012345678901234567890123456789", tipoEmbalagem, 150, data);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O nome não pode conter mais que 60 caracteres.\r\n");
        }

        [Test]
        public void TestarAtualizarProduto()
        {
            Produto test = new Produto(1, "Coca", tipoEmbalagem, 150, data);

            str = bll.Update(test);

            Assert.AreEqual(str, "Produto atualizado com êxito!");
        }

        [Test]
        public void TestarAtualizarProdutoNomeVazio()
        {
            Produto test = new Produto(1, "", tipoEmbalagem, 150, data);


            str = bll.Update(test);

            Assert.AreEqual(str, "O nome deve ser informado.\r\n");
        }
        
    }
}
