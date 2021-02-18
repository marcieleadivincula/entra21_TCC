using BusinessLogicalLayer;
using NUnit.Framework;
using System;

namespace Domain.IntegrationTests
{
    public class TipoPagamentoTests
    {

        private TipoPagamentoBLL bll;
        private string str;
        private DateTime data;

        [SetUp]
        public void Setup()
        {
            bll = new TipoPagamentoBLL();
            str = string.Empty;
            data = DateTime.Now;
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestarInsertTipoPagamento()
        {
            TipoPagamento test = new TipoPagamento(0, "Test", 1);

            str = bll.Insert(test);

            Assert.AreEqual(str, "Tipo de pagamento cadastrado com sucesso!");
        }

        [Test]
        public void TestarInsertTipoPagamentoVazio()
        {
            TipoPagamento test = new TipoPagamento(0, "", 1);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O tipo de pagamento deve ser informada.\r\n");
        }

        [Test]
        public void TestarInsertTipoPagamentoValorNegativo()
        {
            TipoPagamento test = new TipoPagamento(0, "Test", -1);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O número de parcelas não pode ser menor ou igual a zero.\r\n");
        }

        [Test]
        public void TestarInsertTipoPagamentoValorZero()
        {
            TipoPagamento test = new TipoPagamento(0, "Test", 0);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O número de parcelas não pode ser menor ou igual a zero.\r\n");
        }



        [Test]
        public void TestarInsertTipoPagamentoTamanhoExcedido()
        {
            TipoPagamento test = new TipoPagamento(0, "012345678012345678012345678012345678012345678012345678012345678012345678012345678012345678", 1);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O tipo de pagamento não pode conter mais que 60 caracteres.\r\n");
        }

        [Test]
        public void TestarAtualizarTipoPagamento()
        {
            TipoPagamento test = new TipoPagamento(0, "Test", 1);

            str = bll.Update(test);

            Assert.AreEqual(str, "Tipo de pagamento atualizado com êxito!");
        }

        [Test]
        public void TestarAtualizarTipoPagamentoVazio()
        {
            TipoPagamento test = new TipoPagamento(0, "", 1);


            str = bll.Update(test);

            Assert.AreEqual(str, "O tipo de pagamento deve ser informada.\r\n");
        }

        [Test]
        public void TestarAtualizarTipoPagamentoTamanhoExcedido()
        {
            TipoPagamento test = new TipoPagamento(0, "012345678012345678012345678012345678012345678012345678012345678012345678012345678012345678", 1);

            str = bll.Update(test);

            Assert.AreEqual(str, "O tipo de pagamento não pode conter mais que 60 caracteres.\r\n");
        }

        [Test]
        public void TestarDeletarTipoPagamento()
        {
            TipoPagamento test1 = new TipoPagamento(150, "Test", 1);

            str = bll.Insert(test1);

            TipoPagamento test = new TipoPagamento(150, "Test", 1);
            str = bll.Delete(test);

            Assert.AreEqual(str, "Tipo de pagamento deletado com êxito!");
        }




    }
}
