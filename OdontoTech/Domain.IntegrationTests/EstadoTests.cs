using System;
using BusinessLogicalLayer;
using NUnit.Framework;

namespace Domain.IntegrationTests
{
    public class EstadoTests
    {

        private EstadoBLL bll;
        private string str;
        private Pais pais;


        [SetUp]
        public void Setup()
        {
            bll = new EstadoBLL();
            pais = new Pais();
            pais.Id = 1;
            str = string.Empty;
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestarInsertEstado()
        {

            Estado test = new Estado(1, "TEST", pais);

            str = bll.Insert(test);

            Assert.AreEqual(str, "Estado cadastrado com sucesso");
        }

        [Test]
        public void TestarInsertEstadoVazio()
        {
            Estado test = new Estado(1, "", pais);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O nome do estado deve ser informado.\r\n");
        }

        [Test]
        public void TestarAtualizarEstado()
        {
            Estado test = new Estado(1, "Amapá", pais);

            str = bll.Update(test);

            Assert.AreEqual(str, "Estado atualizado com êxito!");
        }

        [Test]
        public void TestarAtualizarEstadoVazio()
        {
            Estado test = new Estado(1, "", pais);


            str = bll.Update(test);

            Assert.AreEqual(str, "O nome do estado deve ser informado.\r\n");
        }



    }
}
