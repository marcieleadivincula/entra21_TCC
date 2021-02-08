using BusinessLogicalLayer;
using NUnit.Framework;

namespace Domain.IntegrationTests
{
    public class FuncaoTests
    {
        private FuncaoBLL bll;
        private string str;

        [SetUp]
        public void Setup()
        {
            bll = new FuncaoBLL();
            str = string.Empty;
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestarInsertFuncao()
        {
            Funcao test = new Funcao(1, "Barman",1500,1.5);

            str = bll.Insert(test);

            Assert.AreEqual(str, "Função cadastrada com sucesso");
        }

        [Test]
        public void TestarInsertFuncaoVazio()
        {
            Funcao test = new Funcao(1, "", 1500, 1.5);

            str = bll.Insert(test);

            Assert.AreEqual(str, "Um nome deve ser informado.\r\n");
        }


        [Test]
        public void TestarInsertFuncaoTamanhoExcedido()
        {
            Funcao test = new Funcao(1, "01234567890123456701234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567898901234567890123456789012345678901234567890123456789012345678901234567890123456789", 1500, 1.5);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O nome da função não pode conter mais que 100 caracteres.\r\n");
        }

        [Test]
        public void TestarAtualizarFuncao()
        {
            Funcao test = new Funcao(1, "Barman", 1500, 1.5);

            str = bll.Update(test);

            Assert.AreEqual(str, "Função atualizado com êxito!");
        }

        [Test]
        public void TestarAtualizarFuncaoVazio()
        {
            Funcao test = new Funcao(1, "", 1500, 1.5);


            str = bll.Update(test);

            Assert.AreEqual(str, "Um nome deve ser informado.\r\n");
        }

        [Test]
        public void TestarAtualizarFuncaoTamanhoExcedido()
        {
            Funcao test = new Funcao(1, "01234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789", 1500, 1.5);
            str = bll.Update(test);

            Assert.AreEqual(str, "O nome da função não pode conter mais que 100 caracteres.\r\n");
        }

        [Test]
        public void TestarDeletarFuncao()
        {
            Funcao test2 = new Funcao(15, "Barman", 1500, 1.5);

            str = bll.Insert(test2);

            Funcao test = new Funcao(15, "Barman", 1500, 1.5);
            str = bll.Delete(test);

            Assert.AreEqual(str, "Função deletada com êxito!");
        }

    }
}
