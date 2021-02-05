using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OdontoTech.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using DataAccessLayer;
using BusinessLogicalLayer;

namespace OdontoTech.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
                TempData.Add("Mensagem", "Login falhou, verifique seus dados.");

                return RedirectToAction("Index","Home");
            }

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
