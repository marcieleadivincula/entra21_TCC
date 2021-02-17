using BusinessLogicalLayer;
using NUnit.Framework;
using System;


namespace Domain.IntegrationTests
{
    public class TipoEmbalagemTests
    {
        private TipoEmbalagemBLL bll;
        private string str;

        [SetUp]
        public void Setup()
        {
            bll = new TipoEmbalagemBLL();
            str = string.Empty;
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestarInsertTipoEmbalagem()
        {
            TipoEmbalagem test = new TipoEmbalagem(1, "blabla");

            str = bll.Insert(test);

            Assert.AreEqual(str, "Tipo de embalagem cadastrado com sucesso!");
        }

        [Test]
        public void TestarInsertTipoEmbalagemNomeVazio()
        {
            TipoEmbalagem test = new TipoEmbalagem(1, "");

            str = bll.Insert(test);

            Assert.AreEqual(str, "A descrição do tipo de embalagem deve ser informada.\r\n");
        }

        [Test]
        public void TestarInsertTipoEmbalagemNomeTamanhoExcedido()
        {
            TipoEmbalagem test = new TipoEmbalagem(1, "0123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789");

            str = bll.Insert(test);

            Assert.AreEqual(str, "A descrição do tipo de embalagem não pode conter mais que 60 caracteres.\r\n");
        }

        [Test]
        public void TestarAtualizarTipoEmbalagem()
        {
            TipoEmbalagem test = new TipoEmbalagem(1, "blabla");

            str = bll.Update(test);

            Assert.AreEqual(str, "Tipo de embalagem atualizado com êxito!");
        }

        [Test]
        public void TestarAtualizarTipoEmbalagemNomeVazio()
        {
            TipoEmbalagem test = new TipoEmbalagem(1, "");


            str = bll.Update(test);

            Assert.AreEqual(str, "A descrição do tipo de embalagem deve ser informada.\r\n");
        }


    }
}
