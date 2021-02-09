using BusinessLogicalLayer;
using NUnit.Framework;

namespace Domain.IntegrationTests
{
    class TipoProcedimentoTests
    {

        private TipoProcedimentoBLL bll;
        private string str;

        [SetUp]
        public void Setup()
        {
            bll = new TipoProcedimentoBLL();
            str = string.Empty;
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestarInsertTipoProcedimento()
        {
            TipoProcedimento test = new TipoProcedimento(15, "Restauração Geral", 1500);

            str = bll.Insert(test);

            Assert.AreEqual(str, "Tipo procedimento cadastrado com sucesso");
        }

        [Test]
        public void TestarInsertTipoProcedimentoVazio()
        {
            TipoProcedimento test = new TipoProcedimento(1, "", 1500);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O nome deve ser informado.\r\n");
        }


        [Test]
        public void TestarInsertTipoProcedimentoTamanhoExcedido()
        {
            TipoProcedimento test = new TipoProcedimento(1, "021345678902134567890213456789021345678902134567890213456789021345678902134567890213456789", 1500);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O nome do tipo de procedimento não pode conter mais que 60 caracteres.\r\n");
        }

        [Test]
        public void TestarAtualizarTipoProcedimento()
        {
            TipoProcedimento test = new TipoProcedimento(1, "Restauração Básica", 1500);

            str = bll.Update(test);

            Assert.AreEqual(str, "Tipo de procedimento atualizado com êxito!");
        }

        [Test]
        public void TestarAtualizarTipoProcedimentoVazio()
        {
            TipoProcedimento test = new TipoProcedimento(1, "", 1500);


            str = bll.Update(test);

            Assert.AreEqual(str, "O nome deve ser informado.\r\n");
        }

        [Test]
        public void TestarAtualizarTipoProcedimentoTamanhoExcedido()
        {
            TipoProcedimento test = new TipoProcedimento(1, "021345678902134567890213456789021345678902134567890213456789021345678902134567890213456789", 1500);
            str = bll.Update(test);

            Assert.AreEqual(str, "O nome do tipo de procedimento não pode conter mais que 60 caracteres.\r\n");
        }

        [Test]
        public void TestarDeletarTipoProcedimento()
        {
            TipoProcedimento test2 = new TipoProcedimento(150, "Teste", 1500);

            str = bll.Insert(test2);

            TipoProcedimento test = new TipoProcedimento(150, "", 1500);

            str = bll.Delete(test);

            Assert.AreEqual(str, "Tipo Procedimento deletado com êxito!");
        }

    }
}
