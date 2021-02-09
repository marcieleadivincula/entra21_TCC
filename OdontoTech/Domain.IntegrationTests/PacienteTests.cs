using BusinessLogicalLayer;
using NUnit.Framework;
using System;

namespace Domain.IntegrationTests
{
    public class PacienteTests
    {

        private PacienteBLL bll;
        private string str;
        private Endereco endereco;
        private DateTime data;

        [SetUp]
        public void Setup()
        {
            bll = new PacienteBLL();
            endereco = new Endereco();
            data = DateTime.Now;
            endereco.Id = 1;

            str = string.Empty;
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestarInsertPaciente()
        {
            Paciente test = new Paciente(1, "Ana", "Julia", "132", "123", data, "blabla", endereco);

            str = bll.Insert(test);

            Assert.AreEqual(str, "Paciente cadastrado com sucesso");
        }

        [Test]
        public void TestarInsertPacienteNomeVazio()
        {
            Paciente test = new Paciente(1, "", "Julia", "132", "123", data, "blabla", endereco);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O nome deve ser informado.\r\n");
        }

        [Test]
        public void TestarInsertPacienteSobrenomeVazio()
        {
            Paciente test = new Paciente(1, "Ana", "", "132", "123", data, "blabla", endereco);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O sobrenome deve ser informado.\r\n");
        }

         [Test]
        public void TestarInsertPacienteRGVazio()
        {
            Paciente test = new Paciente(1, "Ana", "Julia", "", "123", data, "blabla", endereco);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O rg deve ser informado.\r\n");
        }

        [Test]
        public void TestarInsertPacienteRGTamanhoExcedido()
        {
            Paciente test = new Paciente(1, "Ana", "Julia", "01234567890123456789012345678", "123", data, "blabla", endereco);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O rg não pode conter mais que 20 caracteres.\r\n");
        }

        [Test]
        public void TestarInsertPacienteCPFVazio()
        {
            Paciente test = new Paciente(1, "Ana", "Julia", "132", "", data, "blabla", endereco);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O cpf deve ser informado.\r\n");
        }

        [Test]
        public void TestarInsertPacienteCPFTamanhoExcedido()
        {
            Paciente test = new Paciente(1, "Ana", "Julia", "123", "01234567890123456789012345678", data, "blabla", endereco);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O cpf não pode conter mais que 14 caracteres.\r\n");
        }

        [Test]
        public void TestarInsertPacienteNomeTamanhoExcedido()
        {
            Paciente test = new Paciente(1, "01234567890123456789012345678901234567890123456789012345678901234567890123456789", "Julia", "132", "123", data, "blabla", endereco);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O nome não pode conter mais que 60 caracteres.\r\n");
        }

         [Test]
        public void TestarInsertPacienteSobrenomeTamanhoExcedido()
        {
            Paciente test = new Paciente(1, "Ana", "01234567890123456789012345678901234567890123456789012345678901234567890123456789", "132", "123", data, "blabla", endereco);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O sobrenome não pode conter mais que 60 caracteres.\r\n");
        }

        [Test]
        public void TestarInsertPacienteObservacaoVazio()
        {
            Paciente test = new Paciente(1, "Ana", "123", "132", "123", data, "", endereco);

            str = bll.Insert(test);

            Assert.AreEqual(str, "Uma observação deve ser informada.\r\n");
        }

        [Test]
        public void TestarInsertPacienteObservacaoTamanhoExcedido()
        {
            Paciente test = new Paciente(1, "Ana", "123", "132", "123", data, "0123456789456123012345678945612301234567894561230123456789456123012345678945612301234567894561230123456789456123012345678945612301234234567894561230123456789456123012345678945612301234567894561230123456789456123012345678945612323456789456123012345678945612301234567894561230123456789456123012345678945612301234567894561235678945612301234567894561230123456789456123012345678945612301234567894561230123456789456123", endereco);

            str = bll.Insert(test);

            Assert.AreEqual(str, "A observação não pode conter mais que 250 caracteres.\r\n");
        }

        [Test]
        public void TestarAtualizarPaciente()
        {
            Paciente test = new Paciente(1, "Ana", "Julia", "132", "123", data, "blabla", endereco);

            str = bll.Update(test);

            Assert.AreEqual(str, "Paciente atualizado com êxito!");
        }

        [Test]
        public void TestarAtualizarPacienteNomeVazio()
        {
            Paciente test = new Paciente(1, "", "Julia", "132", "123", data, "blabla", endereco);


            str = bll.Update(test);

            Assert.AreEqual(str, "O nome deve ser informado.\r\n");
        }

        [Test]
        public void TestarAtualizarPacienteSobrenomeVazio()
        {
            Paciente test = new Paciente(1, "Ana", "", "132", "123", data, "blabla", endereco);


            str = bll.Update(test);

            Assert.AreEqual(str, "O sobrenome deve ser informado.\r\n");
        }
        
        [Test]
        public void TestarAtualizarPacienteRGVazio()
        {
            Paciente test = new Paciente(1, "Ana", "Julia", "", "123", data, "blabla", endereco);


            str = bll.Update(test);

            Assert.AreEqual(str, "O rg deve ser informado.\r\n");
        }

        [Test]
        public void TestarAtualizarPacienteRGTamanhoExcedido()
        {
            Paciente test = new Paciente(1, "Ana", "Julia", "01234567890123456789012345678", "123", data, "blabla", endereco);


            str = bll.Update(test);

            Assert.AreEqual(str, "O rg não pode conter mais que 20 caracteres.\r\n");
        }

        [Test]
        public void TestarAtualizarPacienteCPFTamanhoExcedido()
        {
            Paciente test = new Paciente(1, "Ana", "Julia", "132", "123456789456132456789123", data, "blabla", endereco);
            str = bll.Update(test);

            Assert.AreEqual(str, "O cpf não pode conter mais que 14 caracteres.\r\n");
        }

        [Test]
        public void TestarAtualizarPacienteCPFVazio()
        {
            Paciente test = new Paciente(1, "Ana", "Julia", "132", "", data, "blabla", endereco);
            str = bll.Update(test);

            Assert.AreEqual(str, "O cpf deve ser informado.\r\n");
        }

        [Test]
        public void TestarAtualizarPacienteObservacaoVazio()
        {
            Paciente test = new Paciente(1, "Ana", "123", "132", "123", data, "", endereco);

            str = bll.Update(test);

            Assert.AreEqual(str, "Uma observação deve ser informada.\r\n");
        }

        [Test]
        public void TestarDeletarPaciente()
        {
            Paciente test2 = new Paciente(150, "Ana", "Julia", "132", "123", data, "blabla", endereco);

            str = bll.Insert(test2);

            Paciente test = new Paciente(150, "Ana", "Julia", "132", "123", data, "blabla", endereco);
            str = bll.Delete(test);
            Assert.AreEqual(str, "Paciente deletado com êxito!");
        }

    }
}
