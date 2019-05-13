using System;
using System.Collections.Generic;
using System.Linq;
using CRM.Business.Entity;
using CRM.Business.Entity.Clases;
using CRM.Business.Entity.Contracts;
using CRM.Business.Data;
using CRM.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class InformeFFVVController : ControllerBase
    {
        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-ffvv-resumen")]
        public IEnumerable<FFVVBaseEntity> ObtenerFFVVInforme(int Periodo)
        {
            string token = Request.Headers["Token"].ToString();
            return FFVVBaseDataAccess.ListarResumenFFVVEjecutivo(token, Periodo);
        }
    }
}