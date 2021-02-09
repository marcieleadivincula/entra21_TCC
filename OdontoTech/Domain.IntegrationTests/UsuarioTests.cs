using BusinessLogicalLayer;
using NUnit.Framework;
using System;


namespace Domain.IntegrationTests
{
    public class UsuarioTests
    {
        private UsuarioBLL bll;
        private string str;
        private Colaborador colaborador;

        [SetUp]
        public void Setup()
        {
            bll = new UsuarioBLL();
            colaborador = new Colaborador();
            colaborador.Id = 1;
            str = string.Empty;
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestarInsertUsuario()
        {
            Usuario test = new Usuario(1, "Coca","123", colaborador);

            str = bll.Insert(test);

            Assert.AreEqual(str, "Usuario cadastrado com sucesso");
        }

        [Test]
        public void TestarInsertUsuarioLoginVazio()
        {
            Usuario test = new Usuario(1, "", "123", colaborador);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O Login deve ser informado.\r\n");
        }


        [Test]
        public void TestarInsertUsuarioLoginTamanhoExcedido()
        {
            Usuario test = new Usuario(1, "01234567890231546780123456789023154678012345678902315467801234567890231546780123456789023154678012345678902315467801234567890231546780123456789023154678012345678902315467801234567890231546780123456789023154678012345678902315467801234567890231546780123456789023154678", "123", colaborador);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O Login não pode conter mais que 60 caracteres.\r\n");
        }

         [Test]
        public void TestarInsertUsuarioSenhaVazio()
        {
            Usuario test = new Usuario(1, "Coca", "", colaborador);

            str = bll.Insert(test);

            Assert.AreEqual(str, "A Senha deve ser informada.\r\n");
        }

        [Test]
        public void TestarInsertUsuarioSenhaTamanhoExcedido()
        {
            Usuario test = new Usuario(1, "Coca", "012345678902315467801234567890231546780123456789023154678012345678902315467801234567890231546780123456789023154678012345678902315467801234567890231546780123456789023154678012345678902315467801234567890231546780123456789023154678012345678902315467801234567890231546780123456789023154678012345678902315467801234567890231546780123456789023154678012345678902315467801234567890231546780123456789023154678012345678902315467801234567890231546780123456789023154678012345678902315467801234567890231546780123456789023154678012345678902315467801234567890231546780123456789023154678012345678902315467801234567890231546780123456789023154678012345678902315467801234567890231546780123456789023154678012345678902315467801234567890231546780123456789023154678012345678902315467801234567890231546780123456789023154678", colaborador);

            str = bll.Insert(test);

            Assert.AreEqual(str, "A Senha Não pode conter mais que 250 caracteres.\r\n");
        }

        [Test]
        public void TestarAtualizarUsuario()
        {
            Usuario test = new Usuario(1, "Coca", "123", colaborador);

            str = bll.Update(test);

            Assert.AreEqual(str, "Usuario atualizado com êxito!");
        }

        [Test]
        public void TestarAtualizarUsuarioLoginVazio()
        {
            Usuario test = new Usuario(1, "", "123", colaborador);


            str = bll.Update(test);

            Assert.AreEqual(str, "O Login deve ser informado.\r\n");
        }


    }
}
