using Microsoft.AspNetCore.Mvc;
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



        public IActionResult Paciente(string firstName, string lastName, string cpf, string rg, DateTime dtNascimento, string pais,string estado, string cidade, string bairro, string logradouro,string cep,int numeroCasa, string contatos ,string observacoes, int idPaciente, string funcao)
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

                LogradouroDAL logradouroDAL = new LogradouroDAL();
                PaisDAL paisDAL = new PaisDAL();
                EstadoDAL estadoDAL = new EstadoDAL();
                BairroDAL bairroDAL = new BairroDAL();
                CidadeDAL cidadeDAL = new CidadeDAL();

                Pais paiss = new Pais(0,pais);

               string a =  paisDAL.Insert(paiss);
                if (a.Contains("já"))
                {
                    List<Pais> lista = new List<Pais>();
                    lista = paisDAL.GetAll();

                    foreach (var item in lista)
                    {
                        if (item.Nome == pais)
                        {
                            paiss.Id = item.Id;
                            break;
                        }
                    }
                    
                }
                else
                {
                  paiss = paisDAL.GetLastRegister();

                }

                Estado estadoo = new Estado(0,estado,paiss);

    

                string b = estadoDAL.Insert(estadoo);
                if (b.Contains("já"))
                {
                    List<Estado> lista = new List<Estado>();
                    lista = estadoDAL.GetAll();

                    foreach (var item in lista)
                    {
                        if (item.Nome == estado)
                        {
                            estadoo.Id = item.Id;
                            break;
                        }
                    }

                }
                else
                {
    
                    estadoo = estadoDAL.GetLastRegister();

                }


                Cidade cidadee = new Cidade(0,cidade,estadoo);

                string c = cidadeDAL.Insert(cidadee);
                if (c.Contains("já"))
                {
                    List<Cidade> lista = new List<Cidade>();
                    lista = cidadeDAL.GetAll();

                    foreach (var item in lista)
                    {
                        if (item.Nome == cidade)
                        {
                            estadoo.Id = item.Id;
                            break;
                        }
                    }

                }
                else
                {

                    cidadee = cidadeDAL.GetLastRegister();
       

                }

                Bairro bairoo = new Bairro(0,bairro,cidadee);

                string d = bairroDAL.Insert(bairoo);
                if (d.Contains("já"))
                {
                    List<Bairro> lista = new List<Bairro>();
                    lista = bairroDAL.GetAll();

                    foreach (var item in lista)
                    {
                        if (item.Nome == cidade)
                        {
                            estadoo.Id = item.Id;
                            break;
                        }
                    }

                }
                else
                {

                bairoo = bairroDAL.GetLastRegister();


                }


                Logradouro logradouroo = new Logradouro(0,logradouro,bairoo);

                string e = logradouroDAL.Insert(logradouroo);
                if (d.Contains("já"))
                {
                    List<Logradouro> lista = new List<Logradouro>();
                    lista = logradouroDAL.GetAll();

                    foreach (var item in lista)
                    {
                        if (item.Nome == logradouro)
                        {
                            logradouroo.Id = item.Id;
                            break;
                        }
                    }

                }
                else
                {

                logradouroo = logradouroDAL.GetLastRegister();

                }

                Endereco endereco1 = new Endereco(0, logradouroo, numeroCasa, cep);

                EnderecoDAL endereco = new EnderecoDAL();
                endereco.Insert(endereco1);

                endereco1 = endereco.GetLastRegister();


                Paciente temp = new Paciente(idPaciente, firstName, lastName, rg, cpf, dtNascimento, observacoes, endereco1); 

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

        public IActionResult Produto(string produto, int embalagem, DateTime dtCompra,double preco, int idProduto, string funcao)
        
        {

            ProdutoBLL bll = new ProdutoBLL();

            ViewBag.produto = produto;
            ViewBag.embalagem = embalagem;
            ViewBag.dtCompra = dtCompra;
            ViewBag.preco = preco;
            ViewBag.idProduto = idProduto;
            ViewData["btn"] = funcao;


            TipoEmbalagem tipoEmbalagem = new TipoEmbalagem(embalagem,"");

            Produto temp = new Produto(idProduto,produto,tipoEmbalagem,preco,dtCompra);


            //if (Convert.ToString(ViewBag.btn) == "Atualizar" )
            //{
            //    bll.Update(temp);
            //}
            //else if (Convert.ToString(ViewBag.btn) == "Deletar")
            //{
            //    bll.Delete(temp);
            //}
            //else if (Convert.ToString(ViewBag.btn) == "Salvar")
            //{
            //    bll.Insert(temp);
            //}

            ViewData["result"] = "";
            if (funcao == "Atualizar")
            {
                ViewData["result"] = bll.Update(temp);
            }
            else if (funcao == "Deletar")
            {
                ViewData["result"] = bll.Delete(temp);
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

        public IActionResult AlterarSenha()
        {
            return View();
        }

        public IActionResult RecuperarSenha()
        {
            return View();
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
