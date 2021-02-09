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

namespace PresentationLayer.Controllers
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
