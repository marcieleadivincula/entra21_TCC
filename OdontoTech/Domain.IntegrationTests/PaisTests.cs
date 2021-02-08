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

            Assert.AreEqual(str, "Pais cadastrado com sucesso");
        }

        [Test]
        public void TestarInsertPaisDuplicado()
        {
            Pais test = new Pais(1, "Alemanha");

            str = bll.Insert(test);

            Assert.AreEqual(str, "Pais já cadastrado.");
        }

        [Test]
        public void TestarInsertPaisVazio()
        {
            Pais test = new Pais(0, "");

            str = bll.Insert(test);

            Assert.AreEqual(str, "O nome deve ser informado.\r\n");
        }

        

        [Test]
        public void TestarInsertPaisTamanhoExcedido()
        {
            Pais test = new Pais(0, "123123132131214567891011121314");

            str = bll.Insert(test);

            Assert.AreEqual(str, "O nome não pode conter mais que 20 caracteres.\r\n");
        }
        
        [Test]
        public void TestarAtualizarPais()
        {
            Pais test = new Pais(1, "Brazil");

            str = bll.Update(test);

            Assert.AreEqual(str, "Pais atualizado com êxito!");
        }

        [Test]
        public void TestarAtualizarPaisVazio()
        {
            Pais test = new Pais(1, "");
           

            str = bll.Update(test);

            Assert.AreEqual(str, "O nome deve ser informado.\r\n");
        }     

        [Test]
        public void TestarAtualizarPaisTamanhoExcedido()
        {
            Pais test = new Pais(1, "321546789546123654879");
            Console.WriteLine(str);
            str = bll.Update(test);

            Assert.AreEqual(str, "O nome não pode conter mais que 20 caracteres.\r\n");
        }     

        [Test]
        public void TestarDeletarPais()
        {
            Pais test = new Pais(49, "");
            Console.WriteLine(str);
            str = bll.Delete(test);

            Assert.AreEqual(str, "Pais deletado com êxito!");
        }     



    }
}
