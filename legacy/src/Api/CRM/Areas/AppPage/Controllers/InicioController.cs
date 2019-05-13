using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace CRM.Areas.AppPage.Controllers
{
    [Area("AppPage")]
    public class InicioController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult SinPermiso()
        {
            return View();
        }
    }
}