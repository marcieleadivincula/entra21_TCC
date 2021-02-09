using BusinessLogicalLayer;
using NUnit.Framework;
using System;

namespace Domain.IntegrationTests
{
    public class PagamentoTests
    {
        private PagamentoBLL bll;
        private string str;
        private TipoPagamento tipoPagamento;
        private DateTime dataPagamento;

        [SetUp]
        public void Setup()
        {
            bll = new PagamentoBLL();
            tipoPagamento = new TipoPagamento();
            dataPagamento = DateTime.Now;

            tipoPagamento.Id = 1;

            str = string.Empty;
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestarInsertPagamento()
        {
            Pagamento test = new Pagamento(1, dataPagamento,tipoPagamento);

            str = bll.Insert(test);

            Assert.AreEqual(str, "Pagamento cadastrado com sucesso !");
        }       

        [Test]
        public void TestarAtualizarPagamento()
        {
            Pagamento test = new Pagamento(1, dataPagamento, tipoPagamento);

            str = bll.Update(test);

            Assert.AreEqual(str, "Pagamento atualizado com êxito!");
        }

        [Test]
        public void TestarAtualizarPagamentoVazio()
        {
            Pagamento test = new Pagamento(1, dataPagamento, tipoPagamento);


            str = bll.Update(test);

            Assert.AreEqual(str, "Pagamento atualizado com êxito!");
        }

        [Test]
        public void TestarDeletarPagamento()
        {
            Pagamento test2 = new Pagamento(1, dataPagamento, tipoPagamento);

            str = bll.Insert(test2);

            Pagamento test = new Pagamento(1, dataPagamento, tipoPagamento);
            str = bll.Delete(test);
            Assert.AreEqual(str, "Pagamento deletado com êxito!");
        }
    }
}
