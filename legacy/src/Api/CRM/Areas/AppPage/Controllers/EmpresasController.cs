using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Areas.AppPage.Controllers
{
   
    public class EmpresasController : Controller
    {
        // GET: AppPage/Empresas
        
        public IActionResult Index()
        {
            return View();
        }

        // GET: AppPage/Empresas/Nuevo
        public IActionResult Nuevo(string t)
        {
            switch (t)
            {
                case "F":
                    return View("Nuevo/Fidelizacion");
                    
                case "R":
                    return View("Nuevo/Retencion");
                    
                case "P":
                    return View("Nuevo/Prospeccion");
                    
                default:
                    return View();
            }
        }


        // GET: AppPage/Empresas/Nuevo
        public IActionResult Editar(string t, int id)
        {
            ViewBag.id = id;
            switch (t)
            {
                case "F":
                    return View("Nuevo/Fidelizacion");

                case "R":
                    return View("Nuevo/Retencion");

                case "P":
                    return View("Nuevo/Prospeccion");

                default:
                    return View();
            }
        }


        public IActionResult CarteraEmpresas()
        {
            return View();
        }


        public IActionResult Maqueta()
        {
            return View();
        }
        
    }
}