﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PresentationLayer.Models;
using System.Diagnostics;
using BusinessLogicalLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public List<CalendarEvent> GoogleEvents = new List<CalendarEvent>();
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/calendar-dotnet-quickstart.json
        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "Google Calendar API .NET Quickstart";

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        public void CalendarEvents()
        {
            UserCredential credential;
            //string path = Server.MapPath("credentials.json");

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            // Create Google Calendar API service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Events events = request.Execute();
            Console.WriteLine("Upcoming events:");
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    var calendarEvent = new CalendarEvent();
                    calendarEvent.Summay = eventItem.Summary;
                    calendarEvent.Organizer = eventItem.Organizer.Email;
                    calendarEvent.Description = eventItem.Description;
                    calendarEvent.StartTime = eventItem.Start.DateTime.ToString();
                    calendarEvent.EndTime = eventItem.End.DateTime.ToString();

                    GoogleEvents.Add(calendarEvent);
                    //GoogleEvents.Add(eventItem.Summary);
                }
            }
        }

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

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult Colaborador()
        {
            return View();
        }

        public IActionResult Atendimento()
        {
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

        public IActionResult Funcao()
        {
            return View();
        }

        public IActionResult Clinica()
        {
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

        public IActionResult Estoque(string produto, int qtdProduto, DateTime dtEntrada, DateTime dtSaida, string funcao, int idEstoque)
        {
            ProdutoBLL pbll = new ProdutoBLL();

            ViewData["produtos"] = pbll.GetAll();


            EstoqueBLL bll = new EstoqueBLL();
            if (funcao == "Deletar")
            {

                Domain.Estoque a = new Domain.Estoque();
                a.Id = idEstoque;

                ViewData["result"] = bll.Delete(a);
                return View();
            }
            if (funcao == "Atualizar")
            {

                if (!pbll.VerificaProduto(produto))
                {
                    ViewData["result"] = "Este produto não existe em nosso estoque.";
                    return View();
                }
                else
                {
                    Produto prdt = new Produto();

                    prdt.Id = pbll.GetIdPorNome(produto);

                    Estoque est = new Estoque(idEstoque,prdt,qtdProduto,dtEntrada,dtSaida);
                    ViewData["result"] = bll.Update(est);
                    return View();
                }


            }
            else if (funcao == "Salvar")
            {


                if (!pbll.VerificaProduto(produto))
                {
                    ViewData["result"] = "Este produto não existe em nosso estoque.";
                    return View();
                }
                else
                {
                    Produto prdt = new Produto();

                    prdt.Id = pbll.GetIdPorNome(produto);

                    Estoque est = new Estoque(idEstoque, prdt, qtdProduto, dtEntrada, dtSaida);
                    ViewData["result"] = bll.Insert(est);
                    return View();
                }
 
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

        public IActionResult Pagamento()
        {
            return View();
        }

        public IActionResult Produto(string produto, string embalagem, DateTime dtCompra, double preco, int idProduto, string funcao)
        {

            ProdutoBLL bll = new ProdutoBLL();

            if (funcao == "Deletar")
            {
                Produto x = new Produto();

                x.Id = idProduto;
                ViewData["result"] = bll.Delete(x);
                return View();
            }

            TipoEmbalagemBLL embalagembll = new TipoEmbalagemBLL();

            Produto temp = new Produto(idProduto, produto, embalagembll.ValidaTipoEmbalagem(embalagem), preco, dtCompra);

            ViewData["result"] = "";
            if (funcao == "Atualizar")
            {
                ViewData["result"] = bll.Update(temp);
            }
            else if (funcao == "Salvar")
            {
                ViewData["result"] = bll.Insert(temp);
            }


            return View();
        }

        public IActionResult Procedimento()
        {
            return View();
        }

        public IActionResult TipoEmbalagem()
        {
            return View();
        }

        public IActionResult TipoPagamento()
        {
            return View();
        }

        public IActionResult TipoProcedimento()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            CalendarEvents();
            ViewBag.EventList = GoogleEvents;

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
