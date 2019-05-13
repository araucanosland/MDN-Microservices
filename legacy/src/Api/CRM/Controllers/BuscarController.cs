using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Collections;
using CRM.Business.Entity;
using CRM.Business.Data;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/busqueda-dotacion")]
    [ApiController]
    public class BuscarController : ControllerBase
    {
        [HttpGet]
        [Route("listar-ejecutivos")]
        public IEnumerable<DotacionEntity> obtenerDotacion()
        {
            DateTime hoy = DateTime.Now;
            int periodo = Convert.ToInt32(hoy.Year.ToString() + hoy.Month.ToString().PadLeft(2,'0'));
            return DotacionDataAccess.ListarEntidades(periodo);
        }
    }
}
