using BusinessLogicalLayer;
using NUnit.Framework;
using System;

namespace Domain.IntegrationTests
{
    public class DespesaTest
    {
        private DespesaBLL bll;
        private string str;
        private DateTime data;

        [SetUp]
        public void Setup()
        {
            bll = new DespesaBLL();
            str = string.Empty;
            data = DateTime.Now;
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestarInsertDespesa()
        {
            Despesa test = new Despesa(0, data, 150, "test");

            str = bll.Insert(test);

            Assert.AreEqual(str, "Despesa cadastrada com sucesso!");
        }

        [Test]
        public void TestarInsertDespesaVazio()
        {
            Despesa test = new Despesa(0, data, 150, "");

            str = bll.Insert(test);

            Assert.AreEqual(str, "A descrição da despesa deve ser informada.\r\n");
        }

        [Test]
        public void TestarInsertDespesaValorNegativo()
        {
            Despesa test = new Despesa(0, data, -150, "Test");

            str = bll.Insert(test);

            Assert.AreEqual(str, "O valor da despesa não pode ser negativo ou zero.\r\n");
        }

        [Test]
        public void TestarInsertDespesaValorZero()
        {
            Despesa test = new Despesa(0, data, 0, "Test");

            str = bll.Insert(test);

            Assert.AreEqual(str, "O valor da despesa não pode ser negativo ou zero.\r\n");
        }



        [Test]
        public void TestarInsertDespesaTamanhoExcedido()
        {
            Despesa test = new Despesa(0, data, 150, "012345687901234568790123456879012345687901234568790123456879");

            str = bll.Insert(test);

            Assert.AreEqual(str, "A descrição da despesa não pode conter mais que 45 caracteres.\r\n");
        }

        [Test]
        public void TestarAtualizarDespesa()
        {
            Despesa test = new Despesa(0, data, 150, "test");

            str = bll.Update(test);

            Assert.AreEqual(str, "Despesa atualizada com êxito!");
        }

        [Test]
        public void TestarAtualizarDespesaVazio()
        {
            Despesa test = new Despesa(0, data, 150, "");


            str = bll.Update(test);

            Assert.AreEqual(str, "A descrição da despesa deve ser informada.\r\n");
        }

        [Test]
        public void TestarAtualizarDespesaTamanhoExcedido()
        {
            Despesa test = new Despesa(0, data, 150, "012345687901234568790123456879012345687901234568790123456879");

            str = bll.Update(test);

            Assert.AreEqual(str, "A descrição da despesa não pode conter mais que 45 caracteres.\r\n");
        }

        [Test]
        public void TestarDeletarDespesa()
        {
            Despesa test = new Despesa(1, data, 150, "test");
            str = bll.Delete(test);

            Assert.AreEqual(str, "Despesa deletada com êxito!");
        }



    }


}
