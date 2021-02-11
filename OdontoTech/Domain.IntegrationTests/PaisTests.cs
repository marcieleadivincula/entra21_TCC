using BusinessLogicalLayer;
using NUnit.Framework;
using System;

namespace Domain.IntegrationTests
{
    public class PaisTests
    {
        private PaisBLL bll;
        private string str;

        [SetUp]
        public void Setup()
        {
            bll = new PaisBLL();
            str = string.Empty;
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestarInsertPais()
        {
            Pais test = new Pais(0, "Coreia do Sul");                    

            str = bll.Insert(test);

            Assert.AreEqual(str, "País cadastrado com sucesso");
        }

        [Test]
        public void TestarInsertPaisDuplicado()
        {
            Pais test = new Pais(1, "Alemanha");

            str = bll.Insert(test);

            Assert.AreEqual(str, "País já cadastrado.");
        }

        [Test]
        public void TestarInsertPaisVazio()
        {
            Pais test = new Pais(0, "");

            str = bll.Insert(test);

            Assert.AreEqual(str, "O nome do país deve ser informado.\r\n");
        }

        

        [Test]
        public void TestarInsertPaisTamanhoExcedido()
        {
            Pais test = new Pais(0, "123123132131214567891011121314");

            str = bll.Insert(test);

            Assert.AreEqual(str, "O nome do país não pode conter mais que 20 caracteres.\r\n");
        }
        
        [Test]
        public void TestarAtualizarPais()
        {
            Pais test = new Pais(1, "Brazil");

            str = bll.Update(test);

            Assert.AreEqual(str, "País atualizado com êxito!");
        }

        [Test]
        public void TestarAtualizarPaisVazio()
        {
            Pais test = new Pais(1, "");
           

            str = bll.Update(test);

            Assert.AreEqual(str, "O nome do país deve ser informado.\r\n");
        }     

        [Test]
        public void TestarAtualizarPaisTamanhoExcedido()
        {
            Pais test = new Pais(1, "321546789546123654879");
            str = bll.Update(test);

            Assert.AreEqual(str, "O nome do país não pode conter mais que 20 caracteres.\r\n");
        }     

        [Test]
        public void TestarDeletarPais()
        {
            Pais test = new Pais(49, "");
            str = bll.Delete(test);

            Assert.AreEqual(str, "País deletado com êxito!");
        }     



    }
}
