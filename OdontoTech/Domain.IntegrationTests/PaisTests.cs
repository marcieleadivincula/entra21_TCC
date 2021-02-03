using BusinessLogicalLayer;
using DataAccessLayer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IntegrationTests
{
    public class PaisTests
    {
        private PaisDAL dal;
        private PaisBLL bll;

        [SetUp]
        public void Setup()
        {
            dal = new PaisDAL();
            bll = new PaisBLL();
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestarInsertPais()
        {
            List<Pais> paises = new List<Pais>();
            Pais test = new Pais(0, "Coreia do Norte");
            Pais test2 = new Pais();
            string str = string.Empty;            

            str = bll.Insert(test);

            Console.WriteLine($"O texto ficou ->  {str}");

            Assert.AreEqual(str, "Pais cadastrado com sucesso");
        }

        [Test]
        public void TestarInsertPaisVazio()
        {
            List<Pais> paises = new List<Pais>();
            Pais test = new Pais(0, "");

            string str = bll.Insert(test);

            Console.WriteLine($"O texto ficou ->  {str}");

            Assert.AreEqual(str, "O nome deve ser informado.");
        }

        [Test]
        public void TestarInsertPaisTamanhoExcedido()
        {
            List<Pais> paises = new List<Pais>();
            Pais test = new Pais(0, "");

            string str = bll.Insert(test);

            Console.WriteLine($"O texto ficou ->  {str}");

            Assert.AreEqual(str, "O nome deve ser informado.");
        }
    }
}
