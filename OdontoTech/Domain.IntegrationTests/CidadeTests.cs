using BusinessLogicalLayer;
using DataAccessLayer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IntegrationTests
{
    public class CidadeTests
    {
        private CidadeBLL bll;
        private string str;
        private Estado estado;

        [SetUp]
        public void Setup()
        {
            bll = new CidadeBLL();
            estado = new Estado();
            estado.Id = 1;
            str = string.Empty;
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestarInsertCidade()
        {
            Cidade test = new Cidade(1, "Abdon Batista", estado);

            str = bll.Insert(test);

            Assert.AreEqual(str, "Cidade cadastrada com sucesso");
        }

        //[Test]
        //public void TestarInsertCidadeDuplicado()
        //{
        //    Cidade test = new Cidade(1, "Blumenau", estado);

        //    str = bll.Insert(test);

        //    Assert.AreEqual(str, "Cidade já cadastrada.");
        //}

        [Test]
        public void TestarInsertCidadeVazio()
        {
            Cidade test = new Cidade(1, "", estado);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O nome deve ser informado.\r\n");
        }

        [Test]
        public void TestarInsertCidadeTamanhoExcedido()
        {
            Cidade test = new Cidade(1, "1012345678910123456789101234567891012345678910123456789", estado);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O nome não pode conter mais que 50 caracteres.\r\n");
        }

        [Test]
        public void TestarAtualizarCidade()
        {
            Cidade test = new Cidade(1, "Badenfurt", estado);

            str = bll.Update(test);

            Assert.AreEqual(str, "Cidade atualizada com êxito!");
        }

        [Test]
        public void TestarAtualizarCidadeVazio()
        {
            Cidade test = new Cidade(1, "", estado);


            str = bll.Update(test);

            Assert.AreEqual(str, "O nome deve ser informado.\r\n");
        }

        [Test]
        public void TestarAtualizarCidadeTamanhoExcedido()
        {
            Cidade test = new Cidade(1, "1012345678910123456789101234567891012345678910123456789", estado);
            Console.WriteLine(str);
            str = bll.Update(test);

            Assert.AreEqual(str, "O nome não pode conter mais que 50 caracteres.\r\n");
        }

        [Test]
        public void TestarDeletarCidade()
        {
            Cidade test = new Cidade(150, "", estado);
            Console.WriteLine(str);
            str = bll.Delete(test);

            Assert.AreEqual(str, "Cidade deletada com êxito!");
        }

    }
}
