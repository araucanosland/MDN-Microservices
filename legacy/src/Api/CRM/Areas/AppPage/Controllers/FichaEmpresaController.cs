using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Areas.AppPage.Controllers
{
    public class FichaEmpresaController : Controller
    {
        // GET: AppPage/FichaEmpresa
        public IActionResult Index()
        {
            return View();
        }

        // GET: AppPage/FichaEmpresa
        public IActionResult Listado()
        {
            return View();
        }

        public IActionResult OtrasEmpresas()
        {
            return View();
        }

        public IActionResult OtrasPublicas()
        {
            return View();
        }

        public IActionResult LeyDesmunicipalizacion()
        {
            return View();
        }

    }
}                         