using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM.Filters;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Areas.AppPage.Controllers
{
    //[PermisosAppFilter]
    public class GestionController : Controller
    {

        public GestionController()
        {
            ViewBag.hash = Jasheo.CurrentDateHash;

        }

        


        // GET: AppPage/Negocios
        public IActionResult Index()
        {
            return View();
        }

        [Route("Oferta/{periodo}/{rut}/{tipo}")]
        public IActionResult Oferta([FromRoute] string rut, [FromRoute] int periodo, [FromRoute] int tipo)
        {
            ViewBag.rut = rut;
            ViewBag.periodo = periodo;
            ViewBag.tipo = tipo;

            return View();
        }


        public IActionResult Empresas()
        {
            
            return View();
        }
        public IActionResult EmpresasAdmin()
        {
            
            return View();
        }

        public IActionResult EmpresaDetalle(int Id)
        {
            
            return View();
        }

        
        public IActionResult Licencia()
        {
            
            return View();
        }
        public IActionResult DetalleGestionEmpresa(int RutEmpresa,string Periodo)
        {
            
            return View();
        }
        public IActionResult DetalleGestionEmpresasAdmin(int RutEmpresa, string Periodo)
        {
            
            return View();
        }

        public IActionResult AsignacionEmpresa(int RutEmpresa, string Periodo)
        {
            
            return View();
        }
    }

    public class Jasheo
    {

        public static string CurrentDateHash { get { return generaCurTime(); } }

        private static string generaCurTime()
        {
            string re = "";
            using (MD5 md5Hash = MD5.Create())
            {
                re = GetMd5Hash(md5Hash, DateTime.Now.ToString());
            };
            return re;
        }

        private static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}