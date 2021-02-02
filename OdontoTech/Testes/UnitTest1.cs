using NUnit.Framework;
using System;
using System.Collections.Generic;
using DataAccessLayer;
using Domain;
using MySql.Data.MySqlClient;
using BusinessLogicalLayer;

namespace Testes
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestarInsertPais()
        {
            PaisDAL dal = new PaisDAL();
            PaisBLL bll = new PaisBLL();
            List<Pais> paises = new List<Pais>();
            Pais test = new Pais(0, "Coreia do Norte");
            Pais test2 = new Pais();

            test2 = dal.SelecionarUltimoID();
            string str = bll.Delete(test2); 

            str = bll.Insert(test);

            Console.WriteLine($"O texto ficou ->  {str}");

            Assert.AreEqual(str, "Pais cadastrado com sucesso");
        }

        [Test]
        public void TestarInsertPaisVazio()
        {
            PaisDAL dal = new PaisDAL();
            PaisBLL bll = new PaisBLL();
            List<Pais> paises = new List<Pais>();
            Pais test = new Pais(0, ""); 
            
            string str = bll.Insert(test);

            Console.WriteLine($"O texto ficou ->  {str}");

            Assert.AreEqual(str, "O nome deve ser informado.");
        } 
        
        [Test]
        public void TestarInsertPaisTamanhoExcedido()
        {
            PaisDAL dal = new PaisDAL();
            PaisBLL bll = new PaisBLL();
            List<Pais> paises = new List<Pais>();
            Pais test = new Pais(0, ""); 
            
            string str = bll.Insert(test);

            Console.WriteLine($"O texto ficou ->  {str}");

            Assert.AreEqual(str, "O nome deve ser informado.");
        }
    }
}