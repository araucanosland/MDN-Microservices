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
using System.IO;
using System.Runtime.InteropServices;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRM.Filters;

namespace CRM.Controllers
{
    [Route("api/perfil-empresas")]
    [ApiController]
    public class PerfilEmpresasController : ControllerBase
    {
        //[AuthorizationRequired]
        [HttpGet]
        [Route("obtener-cartera-empresa")]
        public ICollection<CarteraEmpresasEntity> ObtenerCarteraEmpresa()
        {
            string token = Request.Headers["Token"].ToString();
            return PerfilEmpresasDataAccess.ObtieneCarteraEmp(token);
        }

        [HttpGet]
        [Route("obtener-cartera-agente")]
        public ICollection<CarteraEmpresasEntity> ObtenerCarteraAgente()
        {
            string token = Request.Headers["Token"].ToString();
            return PerfilEmpresasDataAccess.ObtieneCarteraAgen(token);
        }

        [HttpGet]
        [Route("lista-perfil-empresa")]
        public Business.Entity.GestionEmpresasEntity ListaPerfilEmpresa(string RutEmpresa)
        {
            return PerfilEmpresasDataAccess.ObtienePerfilEmp(RutEmpresa);
        }

        [HttpGet]
        [Route("lista-perfil-empresaAnexo")]
        public Business.Entity.GestionEmpresasEntity ListaPerfilEmpresaAnexo(int IdEmpresaA)
        {
            return PerfilEmpresasDataAccess.ObtienePerfilEmpAnexo(IdEmpresaA);
        }

        [HttpGet]
        [Route("lista-asignados-empresa")]
        public ICollection<AsigandosEjecutivoEmpresaEntity> ObtenerAsignadosEjeEmpresa(string RutEmpresa)
        {
            string token = Request.Headers["Token"].ToString();
            return PerfilEmpresasDataAccess.ObtieneAsignacionEjeEmp(token, RutEmpresa);
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("ingresa-nuevo-anexo")]
        public int NuevoAnexo(AnexoEmpresaEntity ingreso)
        {
            string token = Request.Headers["Token"].ToString();
            return Business.Data.PerfilEmpresasDataAccess.InsertaNuevoAnexo(token, ingreso.RutEmpresa, ingreso.NombreEmpresa, ingreso.Anexo, ingreso.NumTrabajadores, ingreso.IdComuna, ingreso.NombreComuna, ingreso.Direccion);
        }

        [HttpGet]
        [Route("lista-comunas-empresa")]
        public ICollection<ComunasEmpresaEntity> ObtenerComunasEmpresas()
        {
            return PerfilEmpresasDataAccess.ObtieneComunaEmp();
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("guardar-asignacion-empresa-anexo")]
        public ResultadoBase GuardarCarteraEmpAnexo(AsignacionAnexoEmpresa asignacionEmpresa)
        {
            try
            {
                PerfilEmpresasDataAccess.GuardarAsignacionEmpAnexo(asignacionEmpresa.Tipo, asignacionEmpresa.EjecAsignado, asignacionEmpresa.Id);
                return new ResultadoBase() { Estado = "OK", Mensaje = "Ingreso Correcto" };
            }
            catch (Exception ex)
            {
                return new ResultadoBase() { Estado = "ERR", Mensaje = "Error en el ingreso: " + ex.Message, Objeto = ex };
            }
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("elimina-asignacion-empresa-anexo")]
        public ResultadoBase EliminaCarteraEmpAnexo(AsignacionAnexoEmpresa asignacionEmpresa)
        {
            try
            {
                PerfilEmpresasDataAccess.EliminaAsignacionEmpAnexo(asignacionEmpresa.Tipo, asignacionEmpresa.EjecAsignado, asignacionEmpresa.Id);
                return new ResultadoBase() { Estado = "OK", Mensaje = "Se desasigno Correctamente" };
            }
            catch (Exception ex)
            {
                return new ResultadoBase() { Estado = "ERR", Mensaje = "Error al desasignar: " + ex.Message, Objeto = ex };
            }
        }


        [HttpGet]
        [Route("lista-ejecutivo-asignado")]
        public ICollection<EjecutivosAsignadosEntity> ObtenerEjesAsig(int IdEmpresa)
        {
            return PerfilEmpresasDataAccess.ObtieneEjeAsignados(IdEmpresa);
        }

        [HttpGet]
        [Route("lista-cartera-anexo")]
        public ICollection<AnexoEmpresaEntity> ObtenerAnexos(string RutEmpresa)
        {
            string token = Request.Headers["Token"].ToString();
            return PerfilEmpresasDataAccess.ObtieneAnexoEmp(RutEmpresa, token);
        }

        [HttpGet]
        [Route("lista-datos-anexo")]
        public Business.Entity.AnexoEmpresaEntity ListadatosAnexos(int IdEmpresa)
        {
            return PerfilEmpresasDataAccess.ObtieneDatosAnexo(IdEmpresa);
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("actualiza-nuevo-anexo")]
        public int ActualizaAnexoEmp(AnexoEmpresaEntity actualiza)
        {
            return Business.Data.PerfilEmpresasDataAccess.ActualizaAnexo(actualiza.IdEmpresaAnexo, actualiza.Anexo, actualiza.NumTrabajadores, actualiza.IdComuna, actualiza.NombreComuna, actualiza.Direccion);
        }

        [HttpGet]
        [Route("lista-contador-anexos")]
        public Business.Entity.ContadorAnexoEntity ContadorAnexos(string RutEmpresa)
        {
            return PerfilEmpresasDataAccess.ObtieneContadorAnexo(RutEmpresa);
        }

        //DEPRECATED
        [HttpPost]
        [Route("carga-afiliados-dropzone/{anexo}")]

        public async Task<IActionResult> SaveUploadedFile([FromRoute] string anexo = "")
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("lista-preaprobado-anexo")]
        public ICollection<AsigandosEjecutivoEmpresaEntity> ObtenerPreAprobadosAnexo(int idAnexo, string RutEmpresa)
        {
            return PerfilEmpresasDataAccess.ObtienePreAprobasoAnex(idAnexo, RutEmpresa);
        }

        [HttpGet]
        [Route("dotacion-oficina")]
        public IEnumerable<EjecutivosOficina> DatosDotacionOficina()
        {
            string token = Request.Headers["Token"].ToString();
            return PerfilEmpresasDataAccess.ListarDotacionOficina(token);
        }

        [HttpGet]
        [Route("lista-entrevista")]
        public ICollection<EntrevistaEntity> ObtenerEntrevistas(string RutEmpresa, int Anexo)
        {
            string token = Request.Headers["Token"].ToString();
            return PerfilEmpresasDataAccess.ObtieneEntrevista(token, RutEmpresa, Anexo);
        }

        //[AuthorizationRequired]
        //[HttpPost]
        //[Route("ingresa-cabecera-entrevista")]
        //public int NuevaCabeceraEntrevista(EntrevistaEntity cabecera)
        //{
        //    string token = Request.Headers["Token"].ToString();
        //    return Business.Data.PerfilEmpresasDataAccess.InsertaNuevoCabEntrevista(token, cabecera.RutEmpresa, cabecera.FechaEntrevista, cabecera.NombreContacto, cabecera.Estamento, cabecera.Cargo, cabecera.Comentarios);
        //}


        [AuthorizationRequired]
        [HttpPost]
        [Route("ingresa-cabecera-entrevista")]
        public Business.Entity.EntrevistaEntity NuevaCabeceraEntrevista(EntrevistaEntity cabecera)
        {
            string token = Request.Headers["Token"].ToString();
            return Business.Data.PerfilEmpresasDataAccess.InsertaNuevoCabEntrevista(token, cabecera.RutEmpresa, cabecera.FechaEntrevista, cabecera.NombreContacto, cabecera.Estamento, cabecera.Cargo, cabecera.Comentarios, cabecera.TelefonoContacto, cabecera.CorreoContacto, cabecera.IdAnexo);
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("ingresa-detalle-entrevista")]
        public int NuevaDetalleEntrevista(DetalleEntrevistaEntity detalleEntrevista)
        {
            string token = Request.Headers["Token"].ToString();
            return Business.Data.PerfilEmpresasDataAccess.InsertaDetalleEntrevista(token, detalleEntrevista.IdEntrevista, detalleEntrevista.Tema, detalleEntrevista.SubTema, detalleEntrevista.Semaforo, detalleEntrevista.Alerta, detalleEntrevista.FechaResolucion, detalleEntrevista.Comentarios, detalleEntrevista.Compromiso);
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-cabecera-vista")]
        public ICollection<EntrevistaEntity> VistaCabeceraEntrevista(int IdEntrevista)
        {
            return Business.Data.PerfilEmpresasDataAccess.ObtieneVistaEntrevista(IdEntrevista);
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-detalle-cabecera-vista")]
        public ICollection<DetalleEntrevistaEntity> VistaDetalleEntrevista(int IdEntrevista)
        {
            return Business.Data.PerfilEmpresasDataAccess.ObtieneDetalleVistaEntrevista(IdEntrevista);
        }


        [HttpGet]
        [Route("obtiene-detalle-entrev")]
        public Business.Entity.DetalleEntrevistaEntity ListaDetalleEnt(int idDetalleEntrevista)
        {
            return PerfilEmpresasDataAccess.ObtieneDetalleEntr(idDetalleEntrevista);
        }

        //SE CAMBIA POR NUEVO DETALLE DE GESTION 
        //[AuthorizationRequired]
        //[HttpPost]
        //[Route("ingresa-gestion-mantencion")]
        //public int NuevaGestionMantencion(GestionMantencionEntity GestionMant)
        //{
        //    string token = Request.Headers["Token"].ToString();
        //    return Business.Data.PerfilEmpresasDataAccess.InsertaGestionMantencion(token, GestionMant.RutEmpresa, GestionMant.Tema, GestionMant.SubTema, GestionMant.Tipo, GestionMant.RutAfiliado, GestionMant.Comentarios, GestionMant.Alerta);
        //}

        [AuthorizationRequired]
        [HttpPost]
        [Route("ingresa-gestion-mantencion")]
        public int NuevaGestionMantencion(GestionMantencionEntity GestionMant)
        {
            string token = Request.Headers["Token"].ToString();
            return Business.Data.PerfilEmpresasDataAccess.InsertaGestionMantencion(token, GestionMant.IdCabGesMantencion, GestionMant.RutEmpresa, GestionMant.Tema, GestionMant.SubTema, GestionMant.RutAfiliado, GestionMant.Comentarios, GestionMant.Alerta);
        }



        [AuthorizationRequired]
        [HttpPost]
        [Route("actualiza-detalle-entrevista")]
        public int ActualizaDetalleEntrevista(DetalleEntrevistaEntity detalleEntrevista)
        {
            string token = Request.Headers["Token"].ToString();
            return Business.Data.PerfilEmpresasDataAccess.ActualizaDetalleEntrevista(token, detalleEntrevista.IdDetalleEntrevista, detalleEntrevista.IdEntrevista, detalleEntrevista.Tema, detalleEntrevista.SubTema, detalleEntrevista.Semaforo, detalleEntrevista.Alerta, detalleEntrevista.FechaResolucion, detalleEntrevista.Comentarios, detalleEntrevista.Compromiso);
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-tipologia-gestion")]
        public ICollection<TipologiaGestionEntity> ObtieneTipologiaGestion()
        {
            return Business.Data.PerfilEmpresasDataAccess.ObtieneTipoGestion();
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-tipologia-Subgestion")]
        public ICollection<TipologiaSubGestionEntity> ObtieneTipologiaSubGestion(int IdTema)
        {
            return Business.Data.PerfilEmpresasDataAccess.ObtieneSubTemaoGestion(IdTema);
        }

        //SE CAMBIA POR VISTA CABECERA MANTENCION
        //[HttpGet]
        //[Route("lista-mantencion-gestion")]
        //public ICollection<GestionMantencionEntity> ObtenerMantencionGestion(string RutEmpresa)
        //{
        //    return PerfilEmpresasDataAccess.ObtenerMantencionGest(RutEmpresa);
        //}


        //SE CAMBIA POR VISTA CABECERA  detalle MANTENCION
        //[AuthorizationRequired]
        //[HttpGet]
        //[Route("lista-detalle-mantencion-gestion")]
        //public ICollection<GestionMantencionEntity> VistaDetalleGestion(int IdGesMantencion)
        //{
        //    return Business.Data.PerfilEmpresasDataAccess.ObtieneDetalleMantGestion(IdGesMantencion);
        //}



        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-afiliado-oficina")]
        public ICollection<AfiliadoOficinaEntity> ObtieneAfiliadoOficina(string RutEmpresa)
        {
            return Business.Data.PerfilEmpresasDataAccess.ObtieneAfiliadoSuc(RutEmpresa);
        }

        [HttpGet]
        [Route("lista-detalle-mantencion-gestion-update")]
        public Business.Entity.GestionMantencionEntity VistaDetalleGestionUpdate(int IdGesMantencion)
        {
            return PerfilEmpresasDataAccess.ObtieneDetalleMantUp(IdGesMantencion);
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("actualiza-detalle-mantencion-gestion")]
        public int ActualizaDetalleMantencionGestion(GestionMantencionEntity GestionMantUp)
        {
            string token = Request.Headers["Token"].ToString();
            return Business.Data.PerfilEmpresasDataAccess.ModificaGestionMantencion(token, GestionMantUp.IdGesMantencion, GestionMantUp.RutEmpresa, GestionMantUp.Tema, GestionMantUp.SubTema, GestionMantUp.RutAfiliado, GestionMantUp.Comentarios);
        }

        [HttpGet]
        [Route("lista-mantencion-gestion-historial")]
        public ICollection<GestionMantencionEntity> ObtenerMantencionGestionHistorial(int IdGesMantencion)
        {
            return PerfilEmpresasDataAccess.ObtenerMantencionGestHistorial(IdGesMantencion);
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("ingresa-cabecera-mant-gestion")]
        public Business.Entity.CabGestionMantencionEntity NuevaCabeceraGestionMan(CabGestionMantencionEntity cabecera)
        {
            string token = Request.Headers["Token"].ToString();
            return Business.Data.PerfilEmpresasDataAccess.InsertaNuevoCabDetalleGestion(token, cabecera.RutEmpresa, cabecera.FechaIngreso, cabecera.Tipo, cabecera.Comentarios, cabecera.Anexo);
        }


        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-cabecera-gestion-mant")]
        public Business.Entity.CabGestionMantencionEntity ObtieneCabeceraGestion(int IdCabGesMantencion)
        {
            return PerfilEmpresasDataAccess.ObtieneCabGestionMantenedor(IdCabGesMantencion);
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-mantencion-gestion")]
        public ICollection<CabGestionMantencionEntity> ObtenerMantencionGestion(string RutEmpresa, int idAnexo)
        {
            string token = Request.Headers["Token"].ToString();
            return PerfilEmpresasDataAccess.ObtenerMantencionGest(token, RutEmpresa, idAnexo);
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-detalle-mantencion-gestion")]
        public ICollection<GestionMantencionEntity> VistaDetalleGestion(int IdCabGesMantencion)
        {
            return Business.Data.PerfilEmpresasDataAccess.ObtieneDetalleMantGestion(IdCabGesMantencion);
        }

        [HttpGet]
        [Route("lista-detalle-entrevista-historial")]
        public ICollection<DetalleEntrevistaEntity> ObtenerDetalleEntreviHistorial(int IdDetalleEntrevista)
        {
            return PerfilEmpresasDataAccess.ObtenerDetalleEntrevistaHistorial(IdDetalleEntrevista);
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("ingresa-cita-agenda-empresa")]
        public int GuardaCitaAgendaEmp(AgendaEmpresaEntity AgendaCita)
        {
            string token = Request.Headers["Token"].ToString();
            return Business.Data.PerfilEmpresasDataAccess.IngresaCitaAgenda(token, AgendaCita.RutEmpresa, AgendaCita.NombreEmpresa, AgendaCita.Glosa,
                                                                                    AgendaCita.FechaInico, AgendaCita.FechaFin, AgendaCita.HoraInicio, AgendaCita.HoraFin,
                                                                                    AgendaCita.Frecuencia, AgendaCita.Dias, AgendaCita.TipoVisita,
                                                                                    AgendaCita.IdAnexo, AgendaCita.DiasSucede);
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("ingresa-cita-agenda-empresa-agente")]
        public int GuardaCitaAgendaEmpAgente(AgendaEmpresaEntity AgendaCita)
        {
            string token = Request.Headers["Token"].ToString();
            return Business.Data.PerfilEmpresasDataAccess.IngresaCitaAgendaAgente(token, AgendaCita.RutEmpresa, AgendaCita.RutEjecutivo, AgendaCita.NombreEmpresa, AgendaCita.Glosa,
                                                                                    AgendaCita.FechaInico, AgendaCita.FechaFin, AgendaCita.HoraInicio, AgendaCita.HoraFin,
                                                                                    AgendaCita.Frecuencia, AgendaCita.Dias, AgendaCita.TipoVisita,
                                                                                    AgendaCita.IdAnexo, AgendaCita.DiasSucede);
        }


        // [AuthorizationRequired]
        [HttpGet]
        [Route("lista-cita-agenda-cartera/{RutEmpresa}/{RutEjecutivo}/{IdAnexo}")]
        public IActionResult ListarMisEventosFC(string RutEmpresa, string RutEjecutivo, int IdAnexo)
        {
            string token = Request.Headers["Token"].ToString();
            var data = PerfilEmpresasDataAccess.ObtenerCitaCartera(RutEmpresa, RutEjecutivo, IdAnexo, token);
            var salida = new List<dynamic>();

            data.ForEach(cita =>
            {
                var clase = "warning";
                switch (cita.TipoVisita)
                {
                    case "Terreno":
                        clase = "primary";
                        break;
                    case "Telefono":
                        clase = "warning";
                        break;
                    case "Mail":
                        clase = "success";
                        break;
                }
                var evt = new
                {
                    title = cita.NombreEmpresa,
                    start = cita.FechaInico,
                    end = cita.FechaFin,
                    IdAgenda = cita.IdAgenda,
                    IdRegistro = cita.IdRegistro,
                    RutEmpresa = cita.RutEmpresa,
                    NombreEmpresa = cita.NombreEmpresa,
                    Frecuencia = cita.Frecuencia,
                    Dias = cita.Dias,
                    DiasSucede = cita.DiasSucede,
                    TipoVisita = cita.TipoVisita,
                    IdAnexo = cita.IdAnexo,
                    HoraInicio = cita.HoraInicio,
                    HoraFin =cita.HoraFin,
                    Ncitas = cita.NCitas,
                    Glosa = cita.Glosa,
                    className = clase
                };
                salida.Add(evt);
            });

            return Ok(salida);
        }

        [HttpGet]
        [Route("lista-cita-agenda-cartera-anexo/{RutEmpresa}/{RutEjecutivo}/{IdAnexo}")]
        public IActionResult ListarMisEventosFC(string RutEmpresa, int IdAnexo)
        {
            var data = PerfilEmpresasDataAccess.ObtenerCitaCarteraAnexo(RutEmpresa, IdAnexo);

            var salida = new List<dynamic>();

            data.ForEach(cita =>
            {
                var clase = "warning";
                switch (cita.TipoVisita)
                {
                    case "Terreno":
                        clase = "primary";
                        break;
                    case "Telefono":
                        clase = "warning";
                        break;
                    case "Mail":
                        clase = "success";
                        break;
                }
                var evt = new
                {
                    title = cita.NombreEmpresa,
                    start = cita.FechaInico,
                    end = cita.FechaFin,
                    IdAgenda = cita.IdAgenda,
                    IdRegistro = cita.IdRegistro,
                    RutEmpresa = cita.RutEmpresa,
                    NombreEmpresa = cita.NombreEmpresa,
                    Frecuencia = cita.Frecuencia,
                    Dias = cita.Dias,
                    DiasSucede = cita.DiasSucede,
                    TipoVisita = cita.TipoVisita,
                    IdAnexo = cita.IdAnexo,
                    HoraInicio = cita.HoraInicio,
                    HoraFin = cita.HoraFin,
                    Ncitas = cita.NCitas,
                    Glosa = cita.Glosa,
                    className = clase
                };

                salida.Add(evt);
            });

            return Ok(salida);
        }


        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-cita-agenda-cartera-ejecutivo/{RutEmpresa}/{IdAnexo}")]
        public IActionResult ListarMisEventosFCejecutivo(string RutEmpresa, int IdAnexo)
        {
            string token = Request.Headers["Token"].ToString();
            var data = PerfilEmpresasDataAccess.ObtenerCitaCarteraEjecutivo(RutEmpresa, token, IdAnexo);

            var salida = new List<dynamic>();

            data.ForEach(cita =>
            {
                var clase = "warning";
                switch (cita.TipoVisita)
                {
                    case "Terreno":
                        clase = "primary";
                        break;
                    case "Telefono":
                        clase = "warning";
                        break;
                    case "Mail":
                        clase = "success";
                        break;
                }
                var evt = new
                {
                    title = cita.NombreEmpresa,
                    start = cita.FechaInico,
                    end = cita.FechaFin,
                    IdAgenda = cita.IdAgenda,
                    IdRegistro = cita.IdRegistro,
                    RutEmpresa = cita.RutEmpresa,
                    NombreEmpresa = cita.NombreEmpresa,
                    Frecuencia = cita.Frecuencia,
                    Dias = cita.Dias,
                    DiasSucede = cita.DiasSucede,
                    TipoVisita = cita.TipoVisita,
                    IdAnexo = cita.IdAnexo,
                    HoraInicio = cita.HoraInicio,
                    HoraFin = cita.HoraFin,
                    Ncitas = cita.NCitas,
                    Glosa = cita.Glosa,
                    className = clase
                };

                salida.Add(evt);
            });

            return Ok(salida);
        }


        [AuthorizationRequired]
        [HttpPost]
        [Route("actualiza-cita-agenda-empresa")]
        public int ActualizaCitaAgendaEmp(AgendaEmpresaEntity AgendaCita)
        {
            string token = Request.Headers["Token"].ToString();
            return Business.Data.PerfilEmpresasDataAccess.ActulizaCitaAgenda(token, AgendaCita.IdAgenda, AgendaCita.RutEmpresa, AgendaCita.Glosa,
                                                                                    AgendaCita.FechaInico, AgendaCita.FechaFin, AgendaCita.HoraInicio, AgendaCita.HoraFin, AgendaCita.TipoVisita );
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("elimina-cita-agenda-empresa")]
        public int EliminaCitaAgendaEmp(AgendaEmpresaEntity AgendaCita)
        {
            string token = Request.Headers["Token"].ToString();
            return Business.Data.PerfilEmpresasDataAccess.EliminaCitaAgenda(token, AgendaCita.IdAgenda, AgendaCita.IdRegistro, AgendaCita.RutEmpresa);
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-empresa-ejecutivo")]
        public ICollection<CarteraEmpresasEntity> ObtieneEmpresaEjecutivo(string RutEjecutivo)
        {
            return Business.Data.PerfilEmpresasDataAccess.ObtieneEmpEjecutivoAsignado(RutEjecutivo);
        }


        [AuthorizationRequired]
        [HttpGet]
        [Route("elimina-empresa-asignada/{IdEmpresa}/{RutEmpresa}")]
        public int EliminaEmpresaAsignada([FromRoute] int IdEmpresa, [FromRoute] string RutEmpresa)
        {
            string token = Request.Headers["Token"].ToString();
            return Business.Data.PerfilEmpresasDataAccess.EliminaEmpAsignada(token, IdEmpresa, RutEmpresa);
        }


        [AuthorizationRequired]
        [HttpGet]
        [Route("elimina-anexo-asignada/{RutEmpresa}")]
        public int EliminaAnexoAsignada([FromRoute] string RutEmpresa, [FromRoute] int IdAnexo)
        {
            string token = Request.Headers["Token"].ToString();
            return Business.Data.PerfilEmpresasDataAccess.EliminaAnexoAsignada(token, RutEmpresa, IdAnexo);
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-region-empresa")]
        public ICollection<RegionEmpresaEntity> ObtieneRegionEmpresa()
        {
            return Business.Data.PerfilEmpresasDataAccess.ObtieneRegionEmpresa();
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-comuna-empresa")]
        public ICollection<ComunaEmpresaEntity> ObtieneComunaEmpresa(int ComunaCodigo)
        {
            return Business.Data.PerfilEmpresasDataAccess.ObtieneComunaEmpresa(ComunaCodigo);
        }
    }

}
