using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Areas.AppPage.Controllers
{
    public class DatosAfiliadosController : Controller
    {
        // GET: AppPage/DatosAfiliados
        public IActionResult Index(string RutBuscar)
        {
            return View();
        }
    }
}