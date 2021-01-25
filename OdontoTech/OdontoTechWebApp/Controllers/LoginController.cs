using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdontoTechWebApp.Controllers
{
    public class LoginController : Controller
    {
        private UsuarioDAL usuarioDal = new UsuarioDAL();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EfetuarLogin(string login, string senha)
        {
            bool possuiCadastro = usuarioDal.EhFuncionarioCadastrado(login, senha);
            return View();
        }
        
    }
}