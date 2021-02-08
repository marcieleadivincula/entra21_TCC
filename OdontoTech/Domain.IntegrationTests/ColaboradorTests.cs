using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicalLayer;
using NUnit.Framework;


namespace Domain.IntegrationTests
{
    public class ColaboradorTests
    {
        private ColaboradorBLL bll;
        private string str;
        private Endereco endereco;
        private Clinica clinica;
        private Funcao funcao;

        private bool ferias;
        private bool demitido;
        private DateTime dataAdmissao;
        private DateTime dataDemissao;



        [SetUp]
        public void Setup()
        {
            bll = new ColaboradorBLL();
            endereco = new Endereco();
            clinica = new Clinica();
            funcao = new Funcao();
            dataAdmissao = DateTime.Now;
            dataDemissao = DateTime.Now;
            ferias = false;
            demitido = false;
            clinica.Id = 1;
            endereco.Id = 1;
            funcao.Id = 1;


            str = string.Empty;
        }

        [TearDown]
        public void TearDown()
        {

        }
        
        [Test]
        public void TestarInsertColaborador()
        {

            Colaborador test = new Colaborador(1, "Alan Domingo", "12000", "SC", dataAdmissao, dataDemissao, endereco, funcao, clinica, ferias, demitido);

            str = bll.Insert(test);

            Assert.AreEqual(str, "Colaborador cadastrado com sucesso");
        }

        [Test]
        public void TestarInsertColaboradorVazio()
        {
            Colaborador test = new Colaborador(1, "", "12", "12", dataAdmissao, dataDemissao, endereco, funcao, clinica, ferias, demitido);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O nome deve ser informado.\r\n");
        }

        [Test]
        public void TestarInsertColaboradorTamanhoExcedido()
        {
            Colaborador test = new Colaborador(1, "01234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789", "12", "12", dataAdmissao, dataDemissao, endereco, funcao, clinica, ferias, demitido);

            str = bll.Insert(test);

            Assert.AreEqual(str, "O nome não pode conter mais que 100 caracteres.\r\n");
        }

        [Test]
        public void TestarAtualizarColaborador()
        {
            Colaborador test = new Colaborador(1, "Alan Domingo", "12", "12", dataAdmissao, dataDemissao, endereco, funcao, clinica, ferias, demitido);

            str = bll.Update(test);

            Assert.AreEqual(str, "Colaborador atualizado com êxito!");
        }

        [Test]
        public void TestarAtualizarColaboradorVazio()
        {
            Colaborador test = new Colaborador(1, "", "12", "12", dataAdmissao, dataDemissao, endereco, funcao, clinica, ferias, demitido);


            str = bll.Update(test);

            Assert.AreEqual(str, "O nome deve ser informado.\r\n");
        }

        [Test]
        public void TestarAtualizarColaboradorTamanhoExcedido()
        {
            Colaborador test = new Colaborador(1, "01234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789", "12", "12", dataAdmissao, dataDemissao, endereco, funcao, clinica, ferias, demitido);
            Console.WriteLine(str);
            str = bll.Update(test);

            Assert.AreEqual(str, "O nome não pode conter mais que 100 caracteres.\r\n");
        }

        [Test]
        public void TestarDeletarColaborador()
        {
            Colaborador test = new Colaborador(150, "Alan Domingo", "12", "12", dataAdmissao, dataDemissao, endereco, funcao, clinica, ferias, demitido);
            Console.WriteLine(str);
            str = bll.Delete(test);

            Assert.AreEqual(str, "Colaborador deletada com êxito!");
        }

    }
}
