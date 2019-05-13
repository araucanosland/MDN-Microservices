using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Areas.AppPage.Controllers
{
    public class CarteraEmpresasController : Controller
    {
        // GET: AppPage/CarteraEmpresas
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Admin()
        {
            return View();
        }
    }
}