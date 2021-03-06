﻿using BusinessLogicalLayer;
using DataAccessLayer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IntegrationTests
{
    public class ClinicaTests
    {

        private ClinicaBLL bll;
        private string str;
        private Endereco endereco;
        private DateTime dataInauguracao;
        private Estoque estoque;


        [SetUp]
        public void Setup()
        {
            bll = new ClinicaBLL();
            endereco = new Endereco();
            estoque = new Estoque();
            dataInauguracao = DateTime.Now;
            endereco.Id = 1;
            estoque.Id = 1;
            str = string.Empty;
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestarInsertClinica()
        {
            Clinica test = new Clinica(1, "Santo Sorriso", dataInauguracao, endereco, estoque);

            str = bll.Insert(test);

            Assert.AreEqual(str, "Clínica cadastrada com sucesso!");
        }       

        [Test]
        public void TestarInsertClinicaVazio()
        {
            Clinica test = new Clinica(1, "", dataInauguracao, endereco, estoque);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O nome da clínica deve ser informado.\r\n");
        }

        [Test]
        public void TestarInsertClinicaTamanhoExcedido()
        {
            Clinica test = new Clinica(1, "101234567891012345678910123456789101234567891012345678956789101234567895678910123456789", dataInauguracao, endereco, estoque);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O nome não pode conter mais que 60 caracteres.\r\n");
        }

        [Test]
        public void TestarAtualizarClinica()
        {
            Clinica test = new Clinica(1, "Badenfurt", dataInauguracao, endereco, estoque);

            str = bll.Update(test);

            Assert.AreEqual(str, "Clínica atualizada com êxito!");
        }

        [Test]
        public void TestarAtualizarClinicaVazio()
        {
            Clinica test = new Clinica(1, "", dataInauguracao, endereco, estoque);


            str = bll.Update(test);

            Assert.AreEqual(str, "O nome da clínica deve ser informado.\r\n");
        }

        [Test]
        public void TestarAtualizarClinicaTamanhoExcedido()
        {
            Clinica test = new Clinica(1, "101234567891012345678910123456789101234567891012345678989101234567898910123456789", dataInauguracao, endereco, estoque);
            str = bll.Update(test);

            Assert.AreEqual(str, "O nome não pode conter mais que 60 caracteres.\r\n");
        }

        [Test]
        public void TestarDeletarClinica()
        {
            Clinica test = new Clinica(150, "", dataInauguracao, endereco, estoque);
            str = bll.Delete(test);

            Assert.AreEqual(str, "Clínica deletada com êxito!");
        }

    }
}
