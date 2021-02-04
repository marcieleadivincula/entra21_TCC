using BusinessLogicalLayer;
using DataAccessLayer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IntegrationTests
{
    public class BairroTests
    {
        private BairroBLL bll;
        private string str;
        private Cidade cidade;

        [SetUp]
        public void Setup()
        {
            bll = new BairroBLL();
            cidade = new Cidade();
            cidade.Id = 1;
            str = string.Empty;
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestarInsertBairro()
        {
            Bairro test = new Bairro(1, "Água Verde", cidade);

            str = bll.Insert(test);

            Assert.AreEqual(str, "Bairro cadastrado com sucesso");
        }
        
        [Test]
        public void TestarInsertBairroVazio()
        {
            Bairro test = new Bairro(1, "", cidade);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O nome deve ser informado.\r\n");
        }

        [Test]
        public void TestarInsertBairroTamanhoExcedido()
        {
            Bairro test = new Bairro(1, "1012345678910123456789101234567891012345678910123456789", cidade);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O nome não pode conter mais que 50 caracteres.\r\n");
        }

        [Test]
        public void TestarAtualizarBairro()
        {
            Bairro test = new Bairro(1, "Badenfurt", cidade);

            str = bll.Update(test);

            Assert.AreEqual(str, "Bairro atualizado com êxito!");
        }

        [Test]
        public void TestarAtualizarBairroVazio()
        {
            Bairro test = new Bairro(1, "", cidade);


            str = bll.Update(test);

            Assert.AreEqual(str, "O nome deve ser informado.\r\n");
        }

        [Test]
        public void TestarAtualizarBairroTamanhoExcedido()
        {
            Bairro test = new Bairro(1, "1012345678910123456789101234567891012345678910123456789", cidade);
            Console.WriteLine(str);
            str = bll.Update(test);

            Assert.AreEqual(str, "O nome não pode conter mais que 50 caracteres.\r\n");
        }

        [Test]
        public void TestarDeletarBairro()
        {
            Bairro test = new Bairro(150, "", cidade);
            Console.WriteLine(str);
            str = bll.Delete(test);

            Assert.AreEqual(str, "Bairro deletado com êxito!");
        }

        
    }
}
