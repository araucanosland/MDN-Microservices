using System;
using System.Collections.Generic;
using System.Linq;
using CRM.Business.Entity;
using CRM.Business.Entity.Clases;
using CRM.Business.Entity.Contracts;
using CRM.Business.Data;
using CRM.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Areas.AppPage.Controllers
{
    [Route("api/Contactos")]
    [ApiController]
    public class ContactabilidadController : ControllerBase
    {
        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-contactos-afi")]
        public IEnumerable<Business.Entity.Contactibilidad.ContactabilidadEntity> ListarContactoAfiliado(int RutAfiliado)
        {
            return Business.Data.ContactabilidadDataAccess.ContactabilidadDataAccess.ListarContacto(RutAfiliado);
        }


        [AuthorizationRequired]
        [HttpGet]
        [Route("actualiza-indice-contacto")]
        public int ActualizaIndice(int Indice, int RutAfi, string ValorDato, int Oficina)
        {
            string token = Request.Headers["Token"].ToString();
            return Business.Data.ContactabilidadDataAccess.ContactabilidadDataAccess.ActualizarIndiceContacto(Indice, RutAfi, ValorDato, token, Oficina);
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("ingresa-nuevo-contacto")]
        public int NuevoContacto(int RutAfiliado, int idTipoContac, string GlosaTipoContac, int IdClasifContac, string GlosaClasifContac, string DatosContac)
        {
            return Business.Data.ContactabilidadDataAccess.ContactabilidadDataAccess.InsertaNuevoContacto(RutAfiliado, idTipoContac, GlosaTipoContac, IdClasifContac, GlosaClasifContac, DatosContac);
        }
    }

    //[AuthorizationRequired]
    //[HttpGet]
    //[Route("lista-indice-contacto")]
    //public IEnumerable<Business.Entity.Contactibilidad.IndiceContactabilidad> ListarIndiceContacto()
    //{
    //    return Business.Data.ContactabilidadDataAccess.ContactabilidadDataAccess.ListarIndice();
    //}
}

