using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Areas.AppPage.Controllers
{
    public class InformesController : Controller
    {
        // GET: AppPage/Informes
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DetalleEjecutivoTracking(int RutEjecutivo)
        {
            return View();
        }

        public IActionResult Comisiones()
        {
            return View();
        }

        public IActionResult DetalleEjecutivoNormalizacion(int RutEjecutivo)
        {
            return View();
        }

        public IActionResult TrackingPais()
        {
            return View();
        }
        public IActionResult TrackingZonal (int Periodo, int CodZona)
        {
            return View();
        }

        public IActionResult TrackingZonalNormalizacion(int Periodo, int CodZona)
        {
            return View();
        }

        public IActionResult SeguimientoGP()
        {
            return View();
        }
        public IActionResult Tracking(int CodOficina,int Periodo)
        {
            return View();
        }
        public IActionResult TrackingNormalizacion (int CodOficina,int Periodo)
        {
            return View();
        }

    }
}