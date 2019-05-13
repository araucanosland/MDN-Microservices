using System;
using System.Collections.Generic;
using CRM.Business.Entity;
using CRM.Business.Data;
using CRM.Business.Data.Mail;
using CRM.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/Contrasena")]
    [ApiController]
    public class ContrasenaController : ControllerBase
    {
        [HttpGet]
        [Route("restablece-contrasena")]
        public EstadoMailEntity RestableceContrasena(string rutEjecutivo)
        {
            return DbMailDataAccess.EnviaMail(rutEjecutivo);
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("consulta-estado-pass")]
        public ContrasenaEntity EstadoContrasena()
        {
            string token = Request.Headers["Token"].ToString();
            return DbMailDataAccess.EstadoContrasena(token);
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("actualiza-contrasena")]
        public int ActualizaContrasena(string passs)
        {
            string token = Request.Headers["Token"].ToString();
            return DbMailDataAccess.ActualizaContrasena(token, passs);
        }
    }
}
