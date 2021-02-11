using System;
using BusinessLogicalLayer;
using NUnit.Framework;

namespace Domain.IntegrationTests
{
    public class EnderecoTests
    {

        private EnderecoBLL bll;
        private string str;
        private Logradouro logradouro;


        [SetUp]
        public void Setup()
        {
            bll = new EnderecoBLL();
            logradouro = new Logradouro();
            logradouro.Id = 1;


            str = string.Empty;
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestarInsertEndereco()
        {

            Endereco test = new Endereco(1, logradouro, 123,"123");

            str = bll.Insert(test);

            Assert.AreEqual(str, "Endereço cadastrado com sucesso");
        }

        [Test]
        public void TestarInsertEnderecoVazio()
        {
            Endereco test = new Endereco(1, logradouro, 0, "123");

            str = bll.Insert(test);

            Assert.AreEqual(str, "O número do endereço deve ser informado.\r\n");
        }

        [Test]
        public void TestarInsertEnderecoCepTamanhoExcedido()
        {
            Endereco test = new Endereco(1, logradouro, 123, "");

            str = bll.Insert(test);

            Assert.AreEqual(str, "O Cep deve ser informado.\r\n");
        }

        [Test]
        public void TestarAtualizarEndereco()
        {
            Endereco test = new Endereco(1, logradouro, 123, "123");

            str = bll.Update(test);

            Assert.AreEqual(str, "Endereço atualizado com êxito!");
        }

        [Test]
        public void TestarAtualizarEnderecoVazio()
        {
            Endereco test = new Endereco(1, logradouro, 0, "123");


            str = bll.Update(test);

            Assert.AreEqual(str, "O número do endereço deve ser informado.\r\n");
        }

        [Test]
        public void TestarAtualizarEnderecoCepTamanhoExcedido()
        {
            Endereco test = new Endereco(1, logradouro, 123, "012345678910");
            str = bll.Update(test);
            Assert.AreEqual(str, "O CEP não pode conter mais que 10 caracteres.\r\n");
        }

    }
}
