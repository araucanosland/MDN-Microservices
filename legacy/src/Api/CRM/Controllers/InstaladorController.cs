using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Collections;
using System.Net.Http;
using System.Web.Http;
using CRM.Business.Entity;
using CRM.Business.Entity.Clases;
using CRM.Business.Data;
using Microsoft.AspNetCore.Mvc;
using CRM.Filters;

namespace CRM.Controllers
{
    [Route("api/instalador-actualizacion")]
    public class InstaladorController : ControllerBase
    {
        [AuthorizationRequired]
        [HttpGet]
        [Route("obtener-actualizacion")]
        public IEnumerable<InstaladorEntity> ObtenerDatosInstalacion(int instalacion)
        {
            string token = Request.Headers["Token"].ToString();
            return InstalacionDataAccess.ObInstalacion(instalacion);
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("update-intalador")]
        public ResultadoBase ActualizaEstadoIntalador()
        {
            try
            {
                string token = Request.Headers["Token"].ToString();
                InstalacionDataAccess.UpdateInstalacion(token);
                return new ResultadoBase() { Estado = "OK", Mensaje = "Exito" };
            }
            catch (Exception ex)
            {
                return new ResultadoBase() { Estado = "ERR", Mensaje = "Error", Objeto = ex };
            }

        }
    }
}
