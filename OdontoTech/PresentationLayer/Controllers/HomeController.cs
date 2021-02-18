using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PresentationLayer.Models;
using System.Diagnostics;
using BusinessLogicalLayer;
using System;
using System.Collections.Generic;
using Domain;
using DataAccessLayer;
using System.Net.Mail;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        //public List<CalendarEvent> GoogleEvents = new List<CalendarEvent>();
        //// If modifying these scopes, delete your previously saved credentials
        //// at ~/.credentials/calendar-dotnet-quickstart.json
        //static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        //static string ApplicationName = "Google Calendar API .NET Quickstart";

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        //public void CalendarEvents()
        //{
        //    UserCredential credential;
        //    //string path = Server.MapPath("credentials.json");

        //    using (var stream =
        //        new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
        //    {
        //        // The file token.json stores the user's access and refresh tokens, and is created
        //        // automatically when the authorization flow completes for the first time.
        //        string credPath = "token.json";
        //        credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
        //            GoogleClientSecrets.Load(stream).Secrets,
        //            Scopes,
        //            "user",
        //            CancellationToken.None,
        //            new FileDataStore(credPath, true)).Result;
        //    }

        //    // Create Google Calendar API service.
        //    var service = new CalendarService(new BaseClientService.Initializer()
        //    {
        //        HttpClientInitializer = credential,
        //        ApplicationName = ApplicationName,
        //    });

        //    // Define parameters of request.
        //    EventsResource.ListRequest request = service.Events.List("primary");
        //    request.TimeMin = DateTime.Now;
        //    request.ShowDeleted = false;
        //    request.SingleEvents = true;
        //    request.MaxResults = 10;
        //    request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

        //    // List events.
        //    Events events = request.Execute();
        //    Console.WriteLine("Upcoming events:");
        //    if (events.Items != null && events.Items.Count > 0)
        //    {
        //        foreach (var eventItem in events.Items)
        //        {
        //            var calendarEvent = new CalendarEvent();
        //            calendarEvent.Summay = eventItem.Summary;
        //            calendarEvent.Organizer = eventItem.Organizer.Email;
        //            calendarEvent.Description = eventItem.Description;
        //            calendarEvent.StartTime = eventItem.Start.DateTime.ToString();
        //            calendarEvent.EndTime = eventItem.End.DateTime.ToString();

        //            GoogleEvents.Add(calendarEvent);
        //            //GoogleEvents.Add(eventItem.Summary);
        //        }
        //    }
        //}

        public IActionResult Index()
        {
            ViewBag.name = "";
            ViewBag.pass = "";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SignUp(string email, string passAgain, string pass, string btn, int Colaborador)
        {


            if (passAgain != pass)
            {
                ViewData["SEA"] = true;
                return View();
            }

            if (btn == "1")
            {
                if (Colaborador == 0)
                {
                    ViewData["result"] = "O colaborador deve ser selecionado.";
                    return View();
                }

                ColaboradorBLL bllcolab = new ColaboradorBLL();
                UsuarioBLL bll = new UsuarioBLL();
                Usuario usuario = new Usuario();
                usuario.Login = email;
                usuario.Senha = pass;

                usuario.Colaborador = bllcolab.GetById(Colaborador);

                TempData["result"] = bll.Insert(usuario);

                return RedirectToAction("Index", "Home");

            }
            else
            {

                return View();
            }
        }

        public IActionResult Colaborador(int idSelecionado,string saveBtn, string saveBtn2,string nomeColaborador, int funcao, string cro, string croEstado, int clinica,string dataDemissao,string dataAdmissao, string state, string city,string bairro,string logradouro, string cep, int numeroCasa,bool ferias,bool demitido)
        {
            ColaboradorBLL bll = new ColaboradorBLL();

                EnderecoBLL enderecoBLL = new EnderecoBLL();
                Colaborador a = new Colaborador();



            if ( state == null || city == null || logradouro == null || numeroCasa == 0 || cep == null)
            {
                ViewData["result"] = "Algum dado de Endereco não foi preenchido.";
                return View();
            }

            if (saveBtn2 == "Deletar")
            {

                a.Id = idSelecionado;

                ViewData["result"] = bll.Delete(a);

                return View();
            }

            if (idSelecionado != 0)
            {
                a.Endereco = enderecoBLL.EnderecoConstruido("Brasil",state,city,bairro,logradouro,numeroCasa,cep);
                ViewData["result"] = bll.Update(a);
                return View();
            }

            if (saveBtn == "Salvar")
            {
                a.Endereco = enderecoBLL.EnderecoConstruido("Brasil", state, city, bairro, logradouro, numeroCasa, cep);
                ViewData["result"] = bll.Insert(a);
                return View();

            }
            return View();
        }
        public IActionResult Atendimento(int idPaciente, int idColaborador, string saveBtn, int idSelecionado, string saveBtn2, DateTime dataInicial, DateTime dataFinal, int idTipoProcedimento, string status)
        {


            if (saveBtn2 == "Deletar")
            {
                AtendimentoBLL bll = new AtendimentoBLL();
                Atendimento a = new Atendimento();

                a.Id = idSelecionado;

                ViewData["result"] = bll.Delete(a);

                return View();
            }

            if (idSelecionado != 0)
            {
                AtendimentoBLL bll = new AtendimentoBLL();
                Atendimento a = new Atendimento();
                ProcedimentoBLL pbll = new ProcedimentoBLL();
                Procedimento procedimento = new Procedimento();                

                a.Paciente = new Paciente();
                a.Colaborador = new Colaborador();

                a.Id = idSelecionado;
                a.StatusAtendimento = status;
                a.DtInicioAtendimento = dataInicial;
                a.DtFinalAtendimento = dataFinal;
                a.Paciente.Id = idPaciente;
                a.Colaborador.Id = idColaborador;

                ViewData["result"] = bll.Update(a);
                return View();
            }

            if (saveBtn == "Salvar")
            {
                AtendimentoBLL bll = new AtendimentoBLL();
                Atendimento a = new Atendimento();


                a.Paciente = new Paciente();
                a.Colaborador = new Colaborador();
                a.StatusAtendimento = status;
                a.DtInicioAtendimento = dataInicial;
                a.DtFinalAtendimento = dataFinal;
                a.Paciente.Id = idPaciente;
                a.Colaborador.Id = idColaborador;

                ViewData["result"] = bll.Insert(a);
                return View();

            }
            return View();
        }



        public IActionResult Paciente(string firstName, string lastName, string cpf, string rg, DateTime dtNascimento, string pais, string estado, string cidade, string bairro, string logradouro, string cep, int numeroCasa, string contatos, string observacoes, int idPaciente, string funcao)
        {
            if (funcao != null)
            {
                PacienteBLL bll = new PacienteBLL();

                if (funcao == "Deletar")
                {
                    Paciente temp1 = new Paciente();
                    temp1.Id = idPaciente;
                    ViewData["result"] = bll.Delete(temp1);
                    return View();
                }

                if (pais == null || estado == null || cidade == null || logradouro == null)
                {
                    ViewData["result"] = "Algum dado de moradia não foi preenchido.";
                    return View();
                }

                EnderecoBLL bllmoradia = new EnderecoBLL();

                Paciente temp = new Paciente(idPaciente, firstName, lastName, rg, cpf, dtNascimento, observacoes, bllmoradia.EnderecoConstruido(pais, estado, cidade, bairro, logradouro, numeroCasa, cep));

                ViewData["result"] = "";

                if (funcao == "Atualizar")
                {
                    ViewData["result"] = bll.Update(temp);
                }

                else if (funcao == "Salvar")
                {
                    ViewData["result"] = bll.Insert(temp);
                }
            }
            return View();

        }

        public IActionResult Funcao(string saveBtn, string saveBtn2, int idSelecionado, string nomeFuncao, double salario, string comissao)
        {


            if (saveBtn2 == "Deletar")
            {
                FuncaoBLL bll = new FuncaoBLL();
                Funcao funcao = new Funcao();

                funcao.Id = idSelecionado;

                ViewData["result"] = bll.Delete(funcao);

                return View();
            }

            if (idSelecionado != 0)
            {
                FuncaoBLL bll = new FuncaoBLL();
                Funcao funcao = new Funcao(idSelecionado, nomeFuncao, salario, Convert.ToDouble(comissao));

                ViewData["result"] = bll.Update(funcao);
                return View();
            }

            if (saveBtn == "Salvar")
            {
                FuncaoBLL bll = new FuncaoBLL();
                Funcao funcao = new Funcao(idSelecionado, nomeFuncao, salario, Convert.ToDouble(comissao));

                ViewData["result"] = bll.Insert(funcao);
                return View();

            }
            return View();
        }

        public IActionResult Clinica(string saveBtn2, DateTime inauguracao, string saveBtn, string nomeClinica, string state, string city, string bairro, string logradouro, string cep, int numeroCasa, int idSelecionado)
        {

            if (saveBtn2 == "Deletar")
            {
                ClinicaBLL bll = new ClinicaBLL();
                Clinica clinica = new Clinica();
                Endereco endereco = new Endereco();

                clinica.Id = idSelecionado;

                ViewData["result"] = bll.Delete(clinica);

                return View();
            }

            if (idSelecionado != 0)
            {
                ClinicaBLL bll = new ClinicaBLL();
                Estoque estoque = new Estoque();
                EnderecoBLL enderecoBLL = new EnderecoBLL();
                estoque.Id = 2;

                Clinica clinica = new Clinica(idSelecionado, nomeClinica, inauguracao, enderecoBLL.EnderecoConstruido("Brasil", state, city, bairro, logradouro, numeroCasa, cep), estoque);

                ViewData["result"] = bll.Update(clinica);
                return View();
            }

            if (saveBtn == "Salvar")
            {
                ClinicaBLL bll = new ClinicaBLL();
                Estoque estoque = new Estoque();
                EnderecoBLL enderecoBLL = new EnderecoBLL();
                estoque.Id = 2;

                Clinica clinica = new Clinica(idSelecionado, nomeClinica, inauguracao, enderecoBLL.EnderecoConstruido("Brasil", state, city, bairro, logradouro, numeroCasa, cep), estoque);

                ViewData["result"] = bll.Insert(clinica);
                return View();

            }
            return View();
        }

        public IActionResult Contato()
        {
            return View();
        }

        public IActionResult FoneTipo()
        {
            return View();
        }

        public IActionResult Estoque(int IDproduto, int qtdProduto, DateTime dataentrada, DateTime datasaida, string saveBtn, string saveBtn2, int idSelecionado)
        {
            EstoqueBLL bll = new EstoqueBLL();
            Estoque estoque = new Estoque();

            estoque.Produto = new Produto();

            if (saveBtn2 == "Deletar")
            {

                estoque.Id = idSelecionado;

                ViewData["result"] = bll.Delete(estoque);

                return View();
            }
            if (idSelecionado != 0)
            {

                estoque.Id = idSelecionado;
                estoque.Produto.Id = IDproduto;
                estoque.DataEntrada = dataentrada;
                estoque.DataSaida = datasaida;
                estoque.QtdProduto = qtdProduto;

                ViewData["result"] = bll.Update(estoque);
                return View();
            }


            if (saveBtn == "Salvar")
            {

                estoque.Produto.Id = IDproduto;
                estoque.DataEntrada = dataentrada;
                estoque.DataSaida = datasaida;
                estoque.QtdProduto = qtdProduto;

                ViewData["result"] = bll.Insert(estoque);
                return View();

            }

            return View();
        }

        public IActionResult Endereco()
        {
            return View();
        }

        public IActionResult Logradouro()
        {
            return View();
        }

        public IActionResult Bairro()
        {
            return View();
        }

        public IActionResult Cidade()
        {
            return View();
        }

        public IActionResult Estado()
        {
            return View();
        }

        public IActionResult Pais()
        {
            PaisBLL paisBll = new PaisBLL();

            ViewBag.Id = paisBll.GetAll();
            ViewBag.Nome = paisBll.GetAll();

            return View();
        }

        public IActionResult Pagamento(double valor, int idSelecionado, DateTime data, int IdPaciente, string saveBtn, string saveBtn2, int idTipoPagamento)
        {

            PagamentoBLL bll = new PagamentoBLL();
            Pagamento pagamento = new Pagamento();


            if (saveBtn2 == "Deletar")
            {

                pagamento.Id = idSelecionado;
                ViewData["result"] = bll.Delete(pagamento);

                return View();
            }
            if (idSelecionado != 0)
            {
                pagamento.TipoPagamento = new TipoPagamento();
                pagamento.Paciente = new Paciente();
                pagamento.Id = idSelecionado;
                pagamento.TipoPagamento.Id = idTipoPagamento;
                pagamento.ValorPagamento = valor;
                pagamento.DataPagamento = data;
                pagamento.Paciente.Id = IdPaciente;

                ViewData["result"] = bll.Update(pagamento);
                return View();
            }


            if (saveBtn == "Salvar")
            {

                pagamento.TipoPagamento = new TipoPagamento();
                pagamento.Paciente = new Paciente();
                pagamento.TipoPagamento.Id = idTipoPagamento;
                pagamento.ValorPagamento = valor;
                pagamento.DataPagamento = data;
                pagamento.Paciente.Id = IdPaciente;

                ViewData["result"] = bll.Insert(pagamento);
                return View();

            }

            return View();
        }

        public IActionResult Produto(string nomeProduto, double precoProduto, int tipoembalaid, DateTime dtcompra, int idSelecionado, string saveBtn2, string saveBtn)
        {
            ProdutoBLL bll = new ProdutoBLL();
            var produto = new Produto();


            if (saveBtn2 == "Deletar")
            {
                produto.Id = idSelecionado;

                ViewData["result"] = bll.Delete(produto);
                return View();
            }
            if (idSelecionado != 0)
            {
                produto.Id = idSelecionado;
                produto.Nome = nomeProduto;
                produto.DataCompra = dtcompra;
                produto.TipoEmbalagem = new TipoEmbalagem();
                produto.TipoEmbalagem.Id = tipoembalaid;
                produto.Preco = precoProduto;

                ViewData["result"] = bll.Update(produto);
                return View();
            }


            if (saveBtn == "Salvar")
            {
                produto.Nome = nomeProduto;
                produto.DataCompra = dtcompra;
                produto.TipoEmbalagem = new TipoEmbalagem();
                produto.TipoEmbalagem.Id = tipoembalaid;
                produto.Preco = precoProduto;

                ViewData["result"] = bll.Insert(produto);
                return View();

            }

            return View();
        }

        public IActionResult Procedimento(string nomeProcedimento, string dsProcedimento, int idTipoProcedimento, int idSelecionado, string saveBtn, string saveBtn2)
        {
            ProcedimentoBLL bll = new ProcedimentoBLL();
            Procedimento procedimento = new Procedimento();
            procedimento.TipoProcedimento = new TipoProcedimento();

            if (saveBtn2 == "Deletar")
            {
                procedimento.Id = idSelecionado;
                ViewData["result"] = bll.Delete(procedimento);
                return View();
            }
            if (idSelecionado != 0)
            {
                procedimento.Id = idSelecionado;
                procedimento.Nome = nomeProcedimento;
                procedimento.DescricaoProcedimento = dsProcedimento;
                procedimento.TipoProcedimento.Id = idTipoProcedimento;

                ViewData["result"] = bll.Update(procedimento);
                return View();
            }


            if (saveBtn == "Salvar")
            {

                procedimento.Nome = nomeProcedimento;
                procedimento.DescricaoProcedimento = dsProcedimento;
                procedimento.TipoProcedimento.Id = idTipoProcedimento;

                ViewData["result"] = bll.Insert(procedimento);
                return View();

            }
            return View();
        }

        public IActionResult TipoEmbalagem(string descricao, int idSelecionado, string saveBtn, string saveBtn2)
        {
            TipoEmbalagemBLL bll = new TipoEmbalagemBLL();
            TipoEmbalagem procedimento = new TipoEmbalagem();

            if (saveBtn2 == "Deletar")
            {
                procedimento.Id = idSelecionado;
                ViewData["result"] = bll.Delete(procedimento);
                return View();
            }
            if (idSelecionado != 0)
            {
                procedimento.Id = idSelecionado;
                procedimento.Descricao = descricao;


                ViewData["result"] = bll.Update(procedimento);
                return View();
            }


            if (saveBtn == "Salvar")
            {

                procedimento.Descricao = descricao;

                ViewData["result"] = bll.Insert(procedimento);
                return View();

            }
            return View();

        }

        public IActionResult TipoPagamento(string saveBtn, string saveBtn2, int idSelecionado, string nometipoPagamento, int parcelas)
        {


            if (saveBtn2 == "Deletar")
            {
                TipoPagamentoBLL bll = new TipoPagamentoBLL();
                TipoPagamento tipoPagamento = new TipoPagamento();

                tipoPagamento.Id = idSelecionado;

                ViewData["result"] = bll.Delete(tipoPagamento);

                return View();
            }

            if (idSelecionado != 0)
            {
                TipoPagamentoBLL bll = new TipoPagamentoBLL();
                TipoPagamento tipoPagamento = new TipoPagamento(idSelecionado, nometipoPagamento, parcelas);

                ViewData["result"] = bll.Update(tipoPagamento);
                return View();
            }

            if (saveBtn == "Salvar")
            {
                TipoPagamentoBLL bll = new TipoPagamentoBLL();
                TipoPagamento tipoPagamento = new TipoPagamento(idSelecionado, nometipoPagamento, parcelas);


                ViewData["result"] = bll.Insert(tipoPagamento);
                return View();

            }
            return View();
        }

        public IActionResult TipoProcedimento(string nomeTipoProcedimento, double valorProcedimento, string saveBtn, string saveBtn2, int idSelecionado)
        {
            TipoProcedimentoBLL bll = new TipoProcedimentoBLL();
            TipoProcedimento procedimento = new TipoProcedimento();

            if (saveBtn2 == "Deletar")
            {
                procedimento.Id = idSelecionado;
                ViewData["result"] = bll.Delete(procedimento);
                return View();
            }
            if (idSelecionado != 0)
            {
                procedimento.Nome = nomeTipoProcedimento;
                procedimento.Valor = valorProcedimento;
                procedimento.Id = idSelecionado;


                ViewData["result"] = bll.Update(procedimento);
                return View();
            }


            if (saveBtn == "Salvar")
            {

                procedimento.Nome = nomeTipoProcedimento;
                procedimento.Valor = valorProcedimento;


                ViewData["result"] = bll.Insert(procedimento);
                return View();

            }
            return View();
        }

        public IActionResult Dashboard()
        {
            //CalendarEvents();
            //ViewBag.EventList = GoogleEvents;

            return View();
        }


        public IActionResult AlterarSenha(string Email, string senha1, string senha2)
        {

            if (senha1 != senha2)
            {
                ViewBag.Email = Email;
                ViewData["SenhasErradas"] = true;
                return View();
            }
            if (senha1 == null && senha2 == null)
            {
                ViewBag.Email = Email;
                return View();
            }
            if (senha1 == senha2)
            {


                UsuarioBLL bll = new UsuarioBLL();
                Usuario user = new Usuario();

                user = bll.GetByEmail(Email);

                user.Senha = senha1;

                bll.Update(user);

                TempData["Mensagem"] = "Senha Alterada com Sucesso !";

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult RecuperarSenha()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RecuperarSenhaAprovar(string Email, string codigo)
        {
            CodsegurancaBLL bll = new CodsegurancaBLL();
            UsuarioBLL usuariobll = new UsuarioBLL();

            if (codigo == null)
            {
                Usuario temp = new Usuario();
                temp = usuariobll.GetByEmail(Email);
                if (temp.Login == null || temp.Login == "")
                {
                    TempData.Add("Verificacaoemail", "O email informado não é cadastrado em nosso sistema.");
                    return RedirectToAction("RecuperarSenha", "Home");
                }
                ViewBag.Email = Email;
                bll.EnviaEMAIL(Email);
                return View();
            }
            if (bll.VerificaCodigo(codigo, Email))
            {
                bll.DeletaByEmail(Email);
                TempData.Add("Email", Email);
                return RedirectToAction("AlterarSenha", "Home");
            }
            else
            {
                ViewBag.Email = Email;
                ViewData["msgcodigo"] = true;
                return View();
            }
        }

        [HttpPost]
        public IActionResult VerificadorLogin(string email, string pass)
        {
            UsuarioDAL dal = new UsuarioDAL();

            if (dal.VerificaLogin(email, pass))
            {
                return View();
            }
            else
            {
                TempData.Add("Mensagem", "Senha ou Email invalido, verifique seus dados.");

                return RedirectToAction("Index", "Home");
            }
        }

        //[HttpPost]
        //public IActionResult VerificarLogin(string login, string password)
        //{
        //    UsuarioDAL dal = new UsuarioDAL();

        //    if (dal.Autenticar(login, password))
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        TempData.Add("Mensagem", "Login falhou, verifique seus dados.");

        //        return RedirectToAction("Index", "Home");
        //    }
        //}

        public IActionResult Finances()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
