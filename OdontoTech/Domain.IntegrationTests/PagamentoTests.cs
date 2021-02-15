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
        private double valorPagamento;
        private Paciente paciente;

        [SetUp]
        public void Setup()
        {
            bll = new PagamentoBLL();
            tipoPagamento = new TipoPagamento();
            dataPagamento = DateTime.Now;
            valorPagamento = 478.55;
            paciente = new Paciente();

            tipoPagamento.Id = 1;
            paciente.Id = 1;

            str = string.Empty;
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestarInsertPagamento()
        {
            Pagamento test = new Pagamento(1, dataPagamento, valorPagamento, tipoPagamento, paciente);

            str = bll.Insert(test);

            Assert.AreEqual(str, "Pagamento cadastrado com sucesso!");
        }       

        [Test]
        public void TestarAtualizarPagamento()
        {
            Pagamento test = new Pagamento(1, dataPagamento, valorPagamento, tipoPagamento, paciente);

            str = bll.Update(test);

            Assert.AreEqual(str, "Pagamento atualizado com êxito!");
        }

        [Test]
        public void TestarAtualizarPagamentoVazio()
        {
            Pagamento test = new Pagamento(1, dataPagamento, valorPagamento, tipoPagamento, paciente);


            str = bll.Update(test);

            Assert.AreEqual(str, "Pagamento atualizado com êxito!");
        }

        [Test]
        public void TestarDeletarPagamento()
        {
            Pagamento test2 = new Pagamento(1, dataPagamento, valorPagamento, tipoPagamento, paciente);

            str = bll.Insert(test2);

            Pagamento test = new Pagamento(1, dataPagamento, valorPagamento, tipoPagamento, paciente);
            str = bll.Delete(test);
            Assert.AreEqual(str, "Pagamento deletado com êxito!");
        }
    }
}
