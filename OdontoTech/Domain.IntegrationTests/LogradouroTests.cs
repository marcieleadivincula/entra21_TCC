using BusinessLogicalLayer;
using NUnit.Framework;
using System;

namespace Domain.IntegrationTests
{
    public class LogradouroTests
    {

        private LogradouroBLL bll;
        private string str;
        private Bairro bairro;

        [SetUp]
        public void Setup()
        {
            bll = new LogradouroBLL();
            bairro = new Bairro();

            bairro.Id = 1;

            str = string.Empty;
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestarInsertLogradouro()
        {
            Logradouro test = new Logradouro(1, "Getúlivo Vargas", bairro);

            str = bll.Insert(test);

            Assert.AreEqual(str, "Logradouro cadastrado com sucesso");
        }

        [Test]
        public void TestarInsertLogradouroVazio()
        {
            Logradouro test = new Logradouro(1, "", bairro);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O nome do logradouro deve ser informado.\r\n");
        }

        [Test]
        public void TestarInsertLogradouroTamanhoExcedido()
        {
            Logradouro test = new Logradouro(1, "1012345678910123456789101234567891012345678910123456789", bairro);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O nome do logradouro não pode conter mais que 50 caracteres.\r\n");
        }

        [Test]
        public void TestarAtualizarLogradouro()
        {
            Logradouro test = new Logradouro(1, "Rua Ana Julia", bairro);

            str = bll.Update(test);

            Assert.AreEqual(str, "Logradouro atualizado com êxito!");
        }

        [Test]
        public void TestarAtualizarLogradouroVazio()
        {
            Logradouro test = new Logradouro(1, "", bairro);


            str = bll.Update(test);

            Assert.AreEqual(str, "O nome do logradouro deve ser informado.\r\n");
        }

        [Test]
        public void TestarAtualizarLogradouroTamanhoExcedido()
        {
            Logradouro test = new Logradouro(1, "0123456789012345678901234567890123456789012345678901234567890123456789", bairro);
            str = bll.Update(test);

            Assert.AreEqual(str, "O nome do logradouro não pode conter mais que 50 caracteres.\r\n");
        }

    }
}
