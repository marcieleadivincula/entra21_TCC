using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class PacienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        //public IActionResult Create(PacienteViewModel viewModel)
        //{
        //    //AutoMapper
        //    //new PacienteBLL.Insert();

        //    return View();
        //}
    }
}
