using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Areas.AppPage.Controllers
{
    [PermisosAppFilter]
    public class LicenciasController : Controller
    {
        // GET: AppPage/Licencias
        public IActionResult Index()
        {
            return View();
        }


        // GET: AppPage/Licencias/Ingreso
        public IActionResult Ingreso()
        {
            return View();
        }
    }
}