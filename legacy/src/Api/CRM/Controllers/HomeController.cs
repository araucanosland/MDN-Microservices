using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRM.Models;
using RestSharp;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace CRM.Controllers
{
    public class HomeController : Controller
    {

        private readonly IConfiguration _config;
        public HomeController(IConfiguration configuration)
        {
            _config = configuration;
            
        }

        public ActionResult Index()
        {
            if (Request.Headers["User-Agent"].ToString().ToUpper().Contains("IE"))
            {
                return View();
            }
            else
            {
                return Redirect(_config.GetValue<string>("BaseURL") + "/Home/Acceso");
            }
        }

        public ActionResult Acceso(string RE)
        {
            if (!Request.Headers["User-Agent"].ToString().ToUpper().Contains("IE"))
            {
                if (RE != null)
                {
                    string baseUrl = _config.GetValue<string>("ServidorApi");
                    var client = new RestClient(baseUrl + "/api");
                    var request = new RestRequest("Auth/authenticate", Method.GET);
                    request.AddQueryParameter("re", RE);
                    IRestResponse response = client.Execute(request);

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        LoginResponse respuesta = SimpleJson.DeserializeObject<LoginResponse>(response.Content);


                        Response.Cookies.Append("Token", response.Headers.Where(x => x.Name == "Token").FirstOrDefault().Value.ToString());
                        Response.Cookies.Append("Rut", RE);
                        Response.Cookies.Append("Usuario", respuesta.Usuario);
                        Response.Cookies.Append("Cargo", respuesta.Cargo);
                        
                        if (respuesta.Cargo.Equals("Administrador Sistema") || respuesta.Cargo.Equals("Usuario Avanzado") || respuesta.Cargo.Contains("Zonal"))
                        {
                            Response.Cookies.Append("X-Support-Token", response.Headers.Where(x => x.Name == "Token").FirstOrDefault().Value.ToString());
                        }

                        Response.Cookies.Append("Noticia", respuesta.Noticia);
                        Response.Cookies.Append("respuesta.Oficina", respuesta.Noticia);
                       

                        int install = Convert.ToInt32(respuesta.Instalar);
                        int multi = Convert.ToInt32(respuesta.Multi);

                        if (install > 0)
                        {
                            return Redirect(_config.GetValue<string>("BaseURL") + "/Home/Instalador?i=" + install.ToString());
                        }
                        else
                        {
                            if (multi > 1)
                            {
                                ViewBag.Modo = "MULTISELECT";
                                ViewBag.Logins = Business.Data.DotacionDataAccess.MultiLoginByRut(RE);
                                return View("Acceso");
                            }
                            else
                            {
                                return Redirect(_config.GetValue<string>("BaseURL") + response.Headers.Where(x => x.Name == "Location").FirstOrDefault().Value.ToString());
                            }
                        }
                    }
                    else
                    {
                        return Redirect(_config.GetValue<string>("BaseURL") + "/Home/SinAcceso");
                    }


                }
                else
                {
                    string urlEnvio = _config.GetValue<string>("UrlAutorizacion") + "?code=" + _config.GetValue<string>("SiteCode");
                    return Redirect(urlEnvio);

                }
            }
            else
            {
                return Redirect(_config.GetValue<string>("BaseURL") + "/Home/");
            }

        }

        

        public ActionResult Instalador()
        {
            return View();
        }

        public ActionResult RecuperarPassword()
        {
            return View();
        }

        public ActionResult SinAcceso()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

