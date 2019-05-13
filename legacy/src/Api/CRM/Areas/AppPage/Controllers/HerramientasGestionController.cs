using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM.Business.Data;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Areas.AppPage.Controllers
{
    public class HerramientasGestionController : Controller
    {
        // GET: AppPage/HerramientasGestion
        public IActionResult Index()
        {
            return View();
        }


        // GET: AppPage/HerramientasGestion/CalculadoraCredito
        public IActionResult CalculadoraCredito()
        {
            return View();
        }

        public IActionResult Falabella()
        {
            return View();
        }

        public IActionResult DetalleFalabella()
        {
            int codOficina = Convert.ToInt32(Request.Cookies["Oficina"]);
            ViewBag.ListaGestiones  = AfiliadoDataAccess.ListarGestionFalabella(codOficina);
            return View();
        }

        public IActionResult EncuestaEmpresa()
        {
            return View();
        }

        public IActionResult RolVerificador()
        {
            return View();
        }

    }
}