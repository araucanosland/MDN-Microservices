using System;
using System.Collections.Generic;
using CRM.Business.Data;
using CRM.Business.Entity.Afiliados;
using CRM.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/Afiliados")]
    [ApiController]
    public class AfiliadosController : ControllerBase
    {
        [HttpGet("obtener-info-afiliado")]
        public Business.Entity.Afiliados.AfiliadosEntity ObtenerInfoAfiliado(int RutAfiliado)
        {
            return AfiliadoDataAccess.ObtenerDatosAfi(RutAfiliado);
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-campanias-afiliado")]
        public IEnumerable<Business.Entity.Afiliados.AfiliadoCampanas> ListarCampaniasAfiliado(int RutAfiliado)
        {
            return AfiliadoDataAccess.ListaCampaniasAfi(RutAfiliado);
        }
        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-alerta-afiliado")]
        public IEnumerable<Business.Entity.Afiliados.AlertasAfiliados> ListarAlertasAfiliado(int RutAfiliado)
        {
            return AfiliadoDataAccess.ListarAlertasAfiliado(RutAfiliado);
        }
        // [AuthorizationRequired]
        [HttpGet]
        [Route("lista-rut-empresa")]
        public IEnumerable<Business.Entity.Afiliados.AfiliadoEmpresaEntity> ListarRutEmpresa(int RutAfiliado)
        {
            return AfiliadoDataAccess.ListaRutEmpresa(RutAfiliado);
        }
        [HttpGet]
        [Route("obtener-info-empresa")]
        public Business.Entity.Afiliados.EmpresaAfiliadoEntity ObtenerInfoEmpresa(int RutEmpresa, int RutAfiliado)
        {
            return AfiliadoDataAccess.ObtenerDatosEmpresa(RutEmpresa, RutAfiliado);
        }
        [HttpGet]
        [Route("obtener-hist-tipo-campana")]
        public IEnumerable<Business.Entity.Afiliados.AfiliadoCampanas> ObtenerHistorialCamapana(int RutAfiliado, int TipoAsignacion)
        {
            return AfiliadoDataAccess.ObtenerHistorialCampana(RutAfiliado, TipoAsignacion);
        }
        [HttpGet]
        [Route("obtener-cumpleanos")]
        public Business.Entity.Afiliados.AfiliadoDatosCumpleanios ObtenerCumpleanos(int RutAfiliado)
        {
            return AfiliadoDataAccess.ObtenerCumpleanos(RutAfiliado);
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("guarda-no-molestar")]
        public Business.Entity.Afiliados.NoMolestarAfiliado noMolestar(string RutAfiliado, string motivo)
        {
            string token = Request.Headers["Token"].ToString();
            return AfiliadoDataAccess.AfilidoNoMolestar(RutAfiliado, motivo, token);
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("guarda-comentario-afiliado")]
        public Business.Entity.Afiliados.ObservacionAfiliado guardaComentario(string RutAfiliado, string Observacion)
        {
            string token = Request.Headers["Token"].ToString();
            return AfiliadoDataAccess.AfiliadoComentario(RutAfiliado, Observacion, token);
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("quita-marcaNoMolestar-afiliado")]
        public Business.Entity.Afiliados.NoMolestarAfiliado SacaMarcaNM(string RutAfiliado)
        {
            string token = Request.Headers["Token"].ToString();
            return AfiliadoDataAccess.sacaMarcaNoMolestar(RutAfiliado, token);
        }

        [HttpGet]
        [Route("obtener-proyeccion")]
        public IEnumerable<Business.Entity.Afiliados.AfiliadoProyeccion> ObtenerProyeccion(string RutAfiliado)
        {
            return AfiliadoDataAccess.ObtieneProyeccionAfiliado(RutAfiliado);
        }

        [HttpGet]
        [Route("filtro-proyeccion")]
        public IEnumerable<Business.Entity.Afiliados.AfiliadoProyeccion> FiltroProyeccion(string RutAfiliado, int Estado)
        {
            return AfiliadoDataAccess.FiltroProyeccionAfiliado(RutAfiliado, Estado);
        }

        [HttpGet]
        [Route("afiliado-falabella/{RutAfiliado}")]
        public IActionResult afiliadoFalabella(string RutAfiliado)
        {
            var el = AfiliadoDataAccess.BuscarAfiliadoFalabella(RutAfiliado);
            if (!string.IsNullOrEmpty(el.RutAfiliado))
            {
                return Ok(el);
            }
            else
            {
                return BadRequest();
            }

        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("afiliado-falabella/{RutAfiliado}/add-gestion")]
        public IActionResult gestionAfiliadoFalabella([FromBody] GestionAfiliadoFalabella entrada, [FromRoute] string RutAfiliado)
        {
            /*Valido La solicitud*/
            if (RutAfiliado != entrada.RutAfiliado)
            {
                return BadRequest("Datos Inconsistentes");
            }

            string token = Request.Headers["Token"].ToString();
            entrada.TicketGestion = Guid.NewGuid();

            AfiliadoDataAccess.GuardarGestionFalabella(entrada, token);

            return Ok();
        }



        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-enfermedades-encuesta")]
        public IEnumerable<Business.Entity.Afiliados.EnfermedadesEncuestaEntity> ListarEnfermedades()
        {
            return AfiliadoDataAccess.ObtenerEnfermedades();
        }



        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-medicamentos-encuesta")]
        public IEnumerable<Business.Entity.Afiliados.MedicamantosEncuestaEntity> ListarMedicamentos()
        {
            return AfiliadoDataAccess.ObtenerMedicamentos();
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("guarda-encueasta-enfermedades")]
        public IActionResult GuardaEncuestas(EncuestaEntity entrada)
        {
            EncuestaEntity entidad = new EncuestaEntity
            {
                Adquiere_CanastaGes = entrada.Adquiere_CanastaGes,
                Adquiere_Consultorio = entrada.Adquiere_Consultorio,
                Adquiere_Farmacia = entrada.Adquiere_Farmacia,

                Edad = entrada.Edad,
                Enfermedad_1 = entrada.Enfermedad_1,
                Enfermedad_2 = entrada.Enfermedad_2,
                Enfermedad_3 = entrada.Enfermedad_3,
                Enfermedad_4 = entrada.Enfermedad_4,
                Enfermedad_5 = entrada.Enfermedad_5,
                Enfermedad_6 = entrada.Enfermedad_6,
                Enfermedad_7 = entrada.Enfermedad_7,
                Enfermedad_8 = entrada.Enfermedad_8,
                Enfermedad_9 = entrada.Enfermedad_9,
                Enfermedad_10 = entrada.Enfermedad_10,
                Enfermedad_11 = entrada.Enfermedad_11,
                Medicamentos_1 = entrada.Medicamentos_1,
                Medicamentos_2 = entrada.Medicamentos_2,
                Medicamentos_3 = entrada.Medicamentos_3,
                Medicamentos_4 = entrada.Medicamentos_4,
                Medicamentos_5 = entrada.Medicamentos_5,
                Medicamentos_6 = entrada.Medicamentos_6,
                Medicamentos_7 = entrada.Medicamentos_7,
                Medicamentos_8 = entrada.Medicamentos_8,
                Medicamentos_9 = entrada.Medicamentos_9,
                Medicamentos_10 = entrada.Medicamentos_10,
                Medicamentos_11 = entrada.Medicamentos_11,
                Medicamentos_12 = entrada.Medicamentos_12,
                Medicamentos_13 = entrada.Medicamentos_13,
                Medicamentos_14 = entrada.Medicamentos_14,
                Medicamentos_15 = entrada.Medicamentos_15,
                NombreFarmacia = entrada.NombreFarmacia,
                Nombre_Afiliado = entrada.Nombre_Afiliado,
                Prevision = entrada.Prevision,
                Rut_Afiliado = entrada.Rut_Afiliado,
                Rut_Ejecutivo = entrada.Rut_Ejecutivo,
                Sexo = entrada.Sexo,
                Actividad = entrada.Actividad,
                Sucursal = entrada.Sucursal,
                Tiene_Enfermedad = entrada.Tiene_Enfermedad,
                Flag_Encuesta = entrada.Flag_Encuesta

            };
            AfiliadoDataAccess.GuardarEncuestaEnfermedades(entidad);
            return Ok("OK");
        }


        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-estado-encuesta")]
        public IEnumerable<Business.Entity.Afiliados.EncuestaEntity> ListaEstadoEncuesta(string RutAfiliado)
        {
            return AfiliadoDataAccess.ObtenerEstadoEncuesta(RutAfiliado);
        }
    }
}
