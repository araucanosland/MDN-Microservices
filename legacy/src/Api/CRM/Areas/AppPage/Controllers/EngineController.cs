using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Areas.AppPage.Controllers
{
    public class EngineController : Controller
    {
        // GET: AppPage/Engine
        public IActionResult Index()
        {
            return View();
        }

        // GET: AppPage/Engine
        public IActionResult ListaPAC()
        {
            return View();
        }


        // GET: AppPage/Engine/Detalle
        public IActionResult Detalle()
        {
            return View();
        }
    }
}