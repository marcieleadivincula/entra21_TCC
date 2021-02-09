using BusinessLogicalLayer;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Domain.IntegrationTests
{
    public class ProcedimentoTests
    {

        private ProcedimentoBLL bll;
        private string str;
        private TipoProcedimento tipoProcedimento;
        private List<Atendimento> atendimentos;

        [SetUp]
        public void Setup()
        {
            bll = new ProcedimentoBLL();
            tipoProcedimento = new TipoProcedimento();
            tipoProcedimento.Id = 1;
            atendimentos = new List<Atendimento>();

            str = string.Empty;
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestarInsertLogradouro()
        {
            Procedimento test = new Procedimento(1, "Arrancamento de penas", tipoProcedimento, "blabla", atendimentos);

            str = bll.Insert(test);

            Assert.AreEqual(str, "Procedimento cadastrado com sucesso");
        }

        [Test]
        public void TestarInsertDescricaoVazio()
        {
            Procedimento test = new Procedimento(1, "Arrancamento de penas", tipoProcedimento, "", atendimentos);

            str = bll.Insert(test);

            Assert.AreEqual(str, "Uma descrição deve ser informada.\r\n");
        }

         [Test]
        public void TestarInsertDescricaoTamanhoExcedido()
        {
            Procedimento test = new Procedimento(1, "Arrancamento de penas", tipoProcedimento, "013245678901324567890132456789013245678901324567890132456789013245678901324567890132456789", atendimentos);

            str = bll.Insert(test);

            Assert.AreEqual(str, "A descrição do procedimento não pode conter mais que 60 caracteres.\r\n");
        }

        [Test]
        public void TestarAtualizarProcedimento()
        {
            Procedimento test = new Procedimento(1, "Arrancamento de penas", tipoProcedimento, "blabla", atendimentos);

            str = bll.Update(test);

            Assert.AreEqual(str, "Procedimento atualizado com êxito!");
        }

        [Test]
        public void TestarAtualizarProcedimentoVazio()
        {
            Procedimento test = new Procedimento(1, "Arrancamento de penas", tipoProcedimento, "blabla", atendimentos);


            str = bll.Update(test);

            Assert.AreEqual(str, "Procedimento atualizado com êxito!");
        }

        [Test]
        public void TestarAtualizarDescricaoVazio()
        {
            Procedimento test = new Procedimento(1, "Arrancamento de penas", tipoProcedimento, "", atendimentos);

            str = bll.Update(test);

            Assert.AreEqual(str, "Uma descrição deve ser informada.\r\n");
        }

        [Test]
        public void TestarAtualizarDescricaoTamanhoExcedido()
        {
            Procedimento test = new Procedimento(1, "Arrancamento de penas", tipoProcedimento, "013245678901324567890132456789013245678901324567890132456789013245678901324567890132456789", atendimentos);

            str = bll.Update(test);

            Assert.AreEqual(str, "A descrição do procedimento não pode conter mais que 60 caracteres.\r\n");
        }

        [Test]
        public void TestarDeletarProcedimento()
        {
            Procedimento test2 = new Procedimento(150, "Arrancamento de penas", tipoProcedimento, "blabla", atendimentos);

            str = bll.Insert(test2);

            Procedimento test = new Procedimento(150, "Arrancamento de penas", tipoProcedimento, "blabla", atendimentos);
            str = bll.Delete(test);
            Assert.AreEqual(str, "Procedimento deletado com êxito!");
        }

    }
}
