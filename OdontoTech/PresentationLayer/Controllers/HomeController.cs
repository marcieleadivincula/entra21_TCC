using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
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

        [HttpPost]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Colaborador()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Atendimento()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Paciente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Funcao()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Clinica()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contato()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FoneTipo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Estoque()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Endereco()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logradouro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Bairro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cidade()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Estado()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Pais()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Pagamento()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Produto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Procedimento()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TipoEmbalagem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TipoPagamento()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TipoProcedimento()
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
