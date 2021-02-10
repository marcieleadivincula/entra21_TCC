using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PresentationLayer.Models;
using System.Diagnostics;
using Domain;
using DataAccessLayer;
using BusinessLogicalLayer;
using System.Collections.Generic;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
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
