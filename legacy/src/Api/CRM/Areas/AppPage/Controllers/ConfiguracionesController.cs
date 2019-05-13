using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Areas.AppPage.Controllers
{
    //[PermisosAppFilter]
    public class ConfiguracionesController : Controller
    {
        // GET: AppPage/Configuraciones
        public IActionResult Index()
        {
            return View();
        }

        // GET: AppPage/Configuraciones/Dotacion
        
        public IActionResult Dotacion()
        {
            return View();
        }

        // GET: AppPage/Configuraciones/DotacionMes
        public IActionResult DotacionMes()
        {
            return View();
        }


        // GET: AppPage/Configuraciones/DotacionMes
    

        // GET: AppPage/Configuraciones/Reasignacion
        public IActionResult Reasignacion()
        {
            return View();
        }


        // GET: AppPage/Configuraciones/Noticias
        public IActionResult Noticias()
        {
            return View();
        }


        // GET: AppPage/Configuraciones/Articulos
        public IActionResult Articulos()
        {
            return View();
        }

        // GET: AppPage/Configuraciones/SucursalAdmin
        public IActionResult SucursalAdmin()
        {
            return View();
        }
        public IActionResult DotacionMesAdmin(int CodOficina)
        {
            return View();
        }
    }
}