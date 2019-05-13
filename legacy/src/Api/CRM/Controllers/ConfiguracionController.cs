using System;
using System.Collections.Generic;
using System.Linq;
using CRM.Business.Data;
using CRM.Business.Entity;
using CRM.Business.Entity.Clases;
using CRM.Filters;
using CRM.Providers;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/Config")]
    [ApiController]
    public class ConfiguracionController : ControllerBase
    {

        [AuthorizationRequired]
        [HttpGet]
        [Route("noticia-inicio")]
        public NoticiaEntity NoticiaInicio(int idNoticia)
        {
            return NoticiaDataAccess.ObtenerPorID(idNoticia);
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("noticia-leida")]
        public ResultadoBase NoticiaLeida()
        {
            //NoticiaDataAccess.ObtenerPorID(idNoticia);
            string token = Request.Headers["Token"].ToString();
            NoticiaDataAccess.NoticiaLeida(token);
            return new ResultadoBase() { Estado = "OK", Mensaje = "OK", Objeto = null };

        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("guarda-dotacion")]
        public ResultadoBase GuardaDotacion(WebDotacionData formData)
        {
            try
            {
                DotacionDataAccess.MarcaAsignable(formData.periodo, formData.oficina, formData.ejecutivos);
                return new ResultadoBase() { Estado = "OK", Mensaje = "OK", Objeto = formData };
            }
            catch (Exception exz)
            {
                return new ResultadoBase() { Estado = "ERR", Mensaje = exz.Message, Objeto = exz };
            }
        }


        [AuthorizationRequired]
        [HttpGet]
        [Route("reemplazo-requerido")]
        public ResultadoBase ReemplazoRequerido(string rutEjecutivo, bool forzar = false)
        {
            try
            {
                string token = Request.Headers["Token"].ToString();
                DotacionDataAccess.MarcarReemplazoRequerido(rutEjecutivo, forzar);
                return new ResultadoBase() { Estado = "OK", Mensaje = "OK", Objeto = token };
            }
            catch (Exception exz)
            {
                return new ResultadoBase() { Estado = "ERR", Mensaje = exz.Message, Objeto = exz };
            }
        }


        [AuthorizationRequired]
        [HttpGet]
        [Route("proceso-dotacion-abierto")]
        public ResultadoBase ProcesoDotacionAbierto(int periodo)
        {
            try
            {
                int salida = DotacionDataAccess.PeriodoAbiertoAsignable(periodo);
                return new ResultadoBase() { Estado = "OK", Mensaje = "OK", Objeto = salida };
            }
            catch (Exception exz)
            {
                return new ResultadoBase() { Estado = "ERR", Mensaje = exz.Message, Objeto = exz };
            }
        }


        [AuthorizationRequired]
        [HttpGet]
        [Route("dotacion-data")]
        public BaseDotacion DatosDocitacion(int periodo, int codOficina)
        {
            string token = Request.Headers["Token"].ToString();
            List<EjecutivosDotacion> LstEjecutivos = new List<EjecutivosDotacion>();
            List<DateTime> FechasFeriado = new List<DateTime>();

            FeriadosDataAccess.ObtenerEntidades().ForEach(x =>
            {
                FechasFeriado.Add(x.Fecha);
            });

            List<TipoausenciaEntity> lstTiposAusen = TipoausenciaDataAccess.ObtenerEntidades();



            DotacionDataAccess.ListarMiOficinaProyeccion(token, periodo).ForEach(ejecutivs =>
            {
                LstEjecutivos.Add(new EjecutivosDotacion {
                    Ejecutivo = ejecutivs,
                    PeriodoAusencia = AusenciaDataAccess.ObtenerMensual(periodo, ejecutivs.Rut),
                    RegistraAusencia = AusenciaDataAccess.RegistraReemplazo(ejecutivs.Rut)
                });
            });


            return new BaseDotacion
            {
                Feriados = FechasFeriado,
                Ejecutivos = LstEjecutivos,
                TiposAusencia = lstTiposAusen,
                Cargos = DotacionDataAccess.ListaCargos(),
                ResumenAusencias = ResumenesDataAccess.ObtenerEntidades(token, periodo),
                Oficina = SucursalDataAccess.ObtenerSucursal(codOficina),
            };

        }
        [AuthorizationRequired]
        [HttpGet]
        [Route("dotacion-data-admin")]
        public BaseDotacion DatosDocitacionAdmin(int periodo, int codOficina)
        {
            string token = Request.Headers["Token"].ToString();
            List<EjecutivosDotacion> LstEjecutivos = new List<EjecutivosDotacion>();
            List<DateTime> FechasFeriado = new List<DateTime>();

            FeriadosDataAccess.ObtenerEntidades().ForEach(x =>
            {
                FechasFeriado.Add(x.Fecha);
            });

            List<TipoausenciaEntity> lstTiposAusen = TipoausenciaDataAccess.ObtenerEntidades();



            DotacionDataAccess.ListarMiOficinaProyeccionAdmin(periodo, codOficina).ForEach(ejecutivs =>
            {
                LstEjecutivos.Add(new EjecutivosDotacion { Ejecutivo = ejecutivs, PeriodoAusencia = AusenciaDataAccess.ObtenerMensual(periodo, ejecutivs.Rut) });
            });


            return new BaseDotacion
            {
                Feriados = FechasFeriado,
                Ejecutivos = LstEjecutivos,
                TiposAusencia = lstTiposAusen,
                Cargos = DotacionDataAccess.ListaCargos(),
                ResumenAusencias = ResumenesDataAccess.ObtenerEntidadesAdmin(periodo, codOficina),
                Oficina = SucursalDataAccess.ObtenerSucursal(codOficina),
            };

        }


        [AuthorizationRequired]
        [HttpPost]
        [Route("guardar-ausencia-dotacion")]
        public ResultadoBase GuardarAusencia(WebAusenciaDot entrada)
        {

            try
            {
                AusenciaEntity ausen = new AusenciaEntity()
                {
                    aus_id = entrada.IdAusencia,
                    ejec_rut = entrada.RutEjecutivo,
                    aus_fecha_inicio = Convert.ToDateTime(entrada.FechaInicio),
                    aus_fecha_fin = !string.IsNullOrEmpty(entrada.FechaFin) ? Convert.ToDateTime(entrada.FechaFin) : Convert.ToDateTime(entrada.FechaInicio),
                    tipo_ausencia_id = entrada.CodigoMotivo,
                    aus_cantidad_dias = entrada.CantidadDias,
                    aus_comentarios = entrada.Comentarios
                };

                AusenciaDataAccess.Guardar(ausen);
                return new ResultadoBase() { Estado = "OK", Mensaje = "Ausencia registrada exitosamente", Objeto = entrada };
            }
            catch (Exception ex)
            {
                return new ResultadoBase() { Estado = "ER", Mensaje = "Ha ocurrido un error al registrar Ausencia", Objeto = ex };
            }
        }


        [AuthorizationRequired]
        [HttpPost]
        [Route("guardar-dotacion-ejecutivo")]
        public ResultadoBase GuardarEjecutivoDotacion(WebDotacionEntrada entrada)
        {
            try
            {
                DotacionEntity d = new DotacionEntity
                {
                    Rut = entrada.Rut,
                    Cargo = entrada.Cargo,
                    IdSucursal = entrada.Oficina,
                    EsAsignable = 1,
                    Nombres = entrada.Nombre,
                    FechaIngreso = Convert.ToDateTime(entrada.FechaIngreso),
                    FechaFinalizacion = entrada.TipoContrato == "P" ? Convert.ToDateTime(entrada.FechaFinal) : DateTime.MaxValue,
                    TipoContrato = entrada.TipoContrato,
                    Email = entrada.Email,
                    Sexo = entrada.Sexo
                    
                };

                DotacionDataAccess.InsertEjecutivoDotacion(d);
                return new ResultadoBase() { Estado = "OK", Mensaje = "Ejecutivo registrado exitosamente", Objeto = d };
            }
            catch (Exception ex)
            {
                return new ResultadoBase() { Estado = "ER", Mensaje = "Ha ocurrido un error al registrar Ejecutivo", Objeto = ex };
            }
        }


        [AuthorizationRequired]
        [HttpGet]
        [Route("marca-dotacion-hoy")]
        public ResultadoBase MarcaDotacionDiaria()
        {
            try
            {
                string token = Request.Headers["Token"].ToString();
                int x = ConfirmDotacionDataAccess.Guardar(token);
                return new ResultadoBase() { Estado = "OK", Mensaje = "Dotación confirmada con éxito", Objeto = x };
            }
            catch (Exception ex)
            {
                return new ResultadoBase() { Estado = "ER", Mensaje = "Ha ocurrido un error", Objeto = ex };
            }
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("marca-camaras-hoy")]
        public ResultadoBase MarcaCamarasDiaria(SeguimientoArticulosOficinaWeb entrada)
        {
            try
            {
                string token = Request.Headers["Token"].ToString();
                SeguimientoArticulosOficinaEntity haydat = SeguimientoArticulosOficinaDataAccess.ObtenerPorOficina(token);

                if (haydat.IdSeguimiento > 0)
                {
                    return new ResultadoBase() { Estado = "WARN", Mensaje = "Ya esta marcado hoy", Objeto = null };
                }
                else
                {
                    int x = SeguimientoArticulosOficinaDataAccess.GuardarSeguimientoCamaras(token, entrada.EstadoArticulo, entrada.Comentarios);
                    return new ResultadoBase() { Estado = "OK", Mensaje = "Guardado con éxito", Objeto = x };
                }
            }
            catch (Exception ex)
            {
                return new ResultadoBase() { Estado = "ER", Mensaje = "Ha ocurrido un error", Objeto = ex };
            }
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("marcadas-camaras-hoy")]
        public SeguimientoArticulosOficinaEntity MarcadasCamarasDiaria()
        {
            string token = Request.Headers["Token"].ToString();
            return SeguimientoArticulosOficinaDataAccess.ObtenerPorOficina(token);
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-sucursales")]
        public IEnumerable<SucursalAdminEntity> ListaSucursalAdmin()
        {
            return SucursalDataAccess.ListarSucursalAdmin();
        }


        [AuthorizationRequired]
        [HttpGet]
        [Route("dotacion-oficina")]
        public IEnumerable<DotacionAgenteEntity> DatosDotacionOficina()
        {
            string token = Request.Headers["Token"].ToString();
            return DotacionAgenteDataAccess.ListarDotacionAgente(token); 
        }


        [AuthorizationRequired]
        [HttpGet]
        [Route("obtiene-datos-ejecutivos")]
        public DatosEjecutivoEntity ObtieneDataEjecutivo(string rut)
        {
            return DotacionAgenteDataAccess.ListarDataEjecutivo(rut);
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("actualiza-dotacion-ejecutivo")]
        public ResultadoBase ActualizaEjecutivoDotacion(WebActualizaDotacionEntrada entrada)
        {
            try
            {
                DatosActualizaEjecutivoEntity d = new DatosActualizaEjecutivoEntity
                {
                    Rut = entrada.Rut,
                    Cargo = entrada.Cargo,
                    TipoContrato = entrada.TipoContrato,
                    FechaInicio = Convert.ToDateTime(entrada.FechaInicio),
                    FechaFinaliza = entrada.TipoContrato == "P" ? Convert.ToDateTime(entrada.FechaFinal) : DateTime.MaxValue,
                    Sexo = entrada.Sexo
                };

                DotacionAgenteDataAccess.ActualizaDataEjecutivo(d);
                return new ResultadoBase() { Estado = "OK", Mensaje = "Ejecutivo actualizado exitosamente", Objeto = d };
            }
            catch (Exception ex)
            {
                return new ResultadoBase() { Estado = "ER", Mensaje = "Ha ocurrido un error al actualizar Ejecutivo", Objeto = ex };
            }
        }


    }
}
