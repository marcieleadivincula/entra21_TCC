using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PresentationLayer.Models;
using System.Diagnostics;
using Domain;
using DataAccessLayer;
using BusinessLogicalLayer;
using System.Collections.Generic;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        EnderecoBLL enderecoBLL = new EnderecoBLL();
        LogradouroBLL logradouroBLL = new LogradouroBLL();
        BairroBLL bairroBLL = new BairroBLL();
        CidadeBLL cidadeBLL = new CidadeBLL();
        EstadoBLL estadoBLL = new EstadoBLL();
        PaisBLL paisBll = new PaisBLL();

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

        public IActionResult Paciente()
        {
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

        public IActionResult Estoque()
        {
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
            ViewBag.Id = paisBll.GetAll();
            ViewBag.Nome = paisBll.GetAll();

            return View();
        }

        public IActionResult Pagamento()
        {
            return View();
        }

        public IActionResult Produto()
        {
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

        public IActionResult AlterarSenha()
        {
            return View();
        }

        public IActionResult RecuperarSenha()
        {
            return View();
        }

        [HttpPost]
        public IActionResult VerificarLogin(string email, string pass)
        {
            UsuarioDAL dal = new UsuarioDAL();

            if (dal.VerificaLogin(email, pass))
            {
                return View();
            }
            else
            {
                TempData.Add("Mensagem", "Login falhou, verifique seus dados.");

                return RedirectToAction("Index", "Home");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
