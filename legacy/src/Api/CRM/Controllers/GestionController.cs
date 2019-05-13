using System;
using System.Collections.Generic;
using System.Linq;
using CRM.Business.Entity;
using CRM.Business.Entity.Clases;
using CRM.Business.Entity.Contracts;
using CRM.Business.Data;
using CRM.Filters;
using System.Net.Http.Headers;
using CRM.Business.Entity.Log;
using CRM.Business.Data.Log;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/Gestion")]
    [ApiController]
    public class GestionController : ControllerBase
    {
        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-seguimientos")]
        public IEnumerable<BaseCampagna> ListaSeguimientos(int tipoCampagna, int periodo)
        {
            string token = Request.Headers["Token"].ToString();
            List<BaseCampagna> ret = new List<BaseCampagna>();
            List<AsignacionEntity> CampagnasEjec = new List<AsignacionEntity>();
            if (tipoCampagna == 5)
            {
                CampagnasEjec = AsignacionDataAccess.ListarByOficina(periodo, token).Where(x => (x.TipoAsignacion == 5 || x.TipoAsignacion == 1) && x.TipoDerivacion == "CALL").ToList();
                CampagnasEjec.AddRange(AsignacionDataAccess.ListarByOficina(periodo, token).Where(d => (d.TipoAsignacion == 1 || d.TipoAsignacion == 5) && d.TipoDerivacion == "WEB"));
            }
            else if (tipoCampagna == 1)
            {
                CampagnasEjec = AsignacionDataAccess.ListarByEjecutivo(periodo, token).Where(x => x.TipoAsignacion == tipoCampagna && (x.TipoDerivacion == string.Empty || x.TipoDerivacion == "ESPONTANEA")).ToList();
                CampagnasEjec.AddRange(AsignacionDataAccess.ListarByOficina(periodo, token).Where(x => x.TipoAsignacion == 5 && x.TipoDerivacion == "ESPONTANEA"));
            }
            else
            {
                CampagnasEjec = AsignacionDataAccess.ListarByEjecutivo(periodo, token).Where(x => x.TipoAsignacion == tipoCampagna).ToList();
            }



            foreach (var item in CampagnasEjec)
            {
                List<PadreGestion> glst = new List<PadreGestion>();
                List<GestionEntity> xx = GestionDataAccess.ListarGestion(item.id_Asign).OrderByDescending(d => d.FechaAccion).ToList();

                xx.ForEach(x =>
                {

                    if (tipoCampagna == 1 || tipoCampagna == 5)
                    {
                        Gestion g = new Gestion()
                        {
                            GestionBase = x,
                            EstadoGestion = EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == EstadosyTiposDataAccess.ListarEstadosGestion().Where(d => d.eges_id == x.IdEstado).FirstOrDefault().ejes_id_padre).FirstOrDefault(),
                            SubEstadoGestion = EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == x.IdEstado).FirstOrDefault(),
                            Gestor = new Ejecutivo() { EjecutivoData = DotacionDataAccess.ObtenerByRut(x.RutEjecutivo) }
                        };
                        glst.Add(g);
                    }
                    if (tipoCampagna == 2)
                    {
                        GestionRecuperacion g = new GestionRecuperacion()
                        {
                            GestionBase = x,
                            CausaBasalGestion = EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == Convert.ToInt32((x.IdEstado.ToString().Length == 9) ? x.IdEstado.ToString().Substring(0, 1) : x.IdEstado.ToString().Substring(0, 2))).FirstOrDefault(),
                            ConsecuenciaGestion = EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == Convert.ToInt32((x.IdEstado.ToString().Length == 9) ? x.IdEstado.ToString().Substring(1, 4) : x.IdEstado.ToString().Substring(2, 4))).FirstOrDefault(),
                            EstadoGestion = EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == Convert.ToInt32((x.IdEstado.ToString().Length == 9) ? x.IdEstado.ToString().Substring(5, 4) : x.IdEstado.ToString().Substring(6, 4))).FirstOrDefault(),
                            Gestor = new Ejecutivo() { EjecutivoData = DotacionDataAccess.ObtenerByRut(x.RutEjecutivo) }
                        };
                        glst.Add(g);
                    }
                    if (tipoCampagna == 3)
                    {
                        GestionNormalizacionTMC g = new GestionNormalizacionTMC()
                        {
                            GestionBase = x,
                            EstadoGestion = EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == EstadosyTiposDataAccess.ListarEstadosGestion().Where(d => d.eges_id == x.IdEstado).FirstOrDefault().ejes_id_padre).FirstOrDefault(),
                            SubEstadoGestion = EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == x.IdEstado).FirstOrDefault(),
                            Gestor = new Ejecutivo() { EjecutivoData = DotacionDataAccess.ObtenerByRut(x.RutEjecutivo) }
                        };
                        glst.Add(g);
                    }


                    if (tipoCampagna == 4)
                    {
                        GestionNormalizacionSC g = new GestionNormalizacionSC()
                        {
                            GestionBase = x,
                            EstadoGestion = EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == EstadosyTiposDataAccess.ListarEstadosGestion().Where(d => d.eges_id == x.IdEstado).FirstOrDefault().ejes_id_padre).FirstOrDefault(),
                            SubEstadoGestion = EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == x.IdEstado).FirstOrDefault(),
                            Gestor = new Ejecutivo() { EjecutivoData = DotacionDataAccess.ObtenerByRut(x.RutEjecutivo) }
                        };
                        glst.Add(g);
                    }


                });

                BaseCampagna bas = new BaseCampagna
                {
                    Seguimiento = item,
                    HistorialGestion = glst,
                    Notificaciones = NotificacionAsignacionDataAccess.ObtenerSetNTF(item.Afiliado_Rut.ToString()),
                    Celulares = ContactoafiliadoDataAccess.ObtenerPorRutAfiliadoYTipo(Convert.ToInt32(item.Afiliado_Rut), "CELULAR"),
                    Telefonos = ContactoafiliadoDataAccess.ObtenerPorRutAfiliadoYTipo(Convert.ToInt32(item.Afiliado_Rut), "TELEFONO"),
                    Correos = ContactoafiliadoDataAccess.ObtenerPorRutAfiliadoYTipo(Convert.ToInt32(item.Afiliado_Rut), "EMAIL"),
                    OficinaPreferencia = PreferenciaAfiliadoDataAccess.ObtenerPorID(Convert.ToInt32(item.Afiliado_Rut), "OFICINA"),
                    HorarioPreferencia = PreferenciaAfiliadoDataAccess.ObtenerPorID(Convert.ToInt32(item.Afiliado_Rut), "HORARIO"),
                    FiltrosRSG = FiltrosrsgDataAccess.ObtenerEntidad(periodo, item.Afiliado_Rut.ToString(), item.Empresa_Rut.ToString()).Filtros,
                    NombreOficina = SucursalDataAccess.ObtenerSucursal(item.Oficina).Nombre,
                };
                ret.Add(bas);
            }
            return ret;
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("v2/lista-seguimientos")]
        public IEnumerable<ContenedorCampaniaList> ListaSeguimientosv2(int tipoCampagna, int periodo)
        {
            string token = Request.Headers["Token"].ToString();
            List<ContenedorCampaniaList> res = new List<ContenedorCampaniaList>();

            if (tipoCampagna == 5)
            {
                res = AsignacionDataAccess.ListarByOficina2(periodo, token, "CALL").Where(x => x.Seguimiento.TipoAsignacion == 5 || x.Seguimiento.TipoAsignacion == 1).ToList();
                res.AddRange(AsignacionDataAccess.ListarByOficina2(periodo, token, "WEB").Where(d => d.Seguimiento.TipoAsignacion == 1 || d.Seguimiento.TipoAsignacion == 5));
            }
            else if (tipoCampagna == 1)
            {
                res = AsignacionDataAccess.ListarByEjecutivo2(periodo, token).Where(x => x.Seguimiento.TipoAsignacion == tipoCampagna).ToList();
                res.AddRange(AsignacionDataAccess.ListarByEjecutivo2(periodo, token, "ESPONTANEA").Where(x => x.Seguimiento.TipoAsignacion == tipoCampagna));
                res.AddRange(AsignacionDataAccess.ListarByOficina2(periodo, token, "ESPONTANEA").Where(x => x.Seguimiento.TipoAsignacion == 5));
            }
            else
            {
                res = AsignacionDataAccess.ListarByEjecutivo2(periodo, token).Where(x => x.Seguimiento.TipoAsignacion == tipoCampagna).ToList();
            }

            return res;
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("v3/lista-seguimientos")]
        public BootstrapTableResult<ContenedorCampaniaList> ListaSeguimientosv3(int tipoCampagna, int periodo, string estado = "-1", string marca = "", string subestado = "-1", string causaBasal = "-1", string consecuencia = "-1", string prioridad = "", string segmento = "", string tipo = "", string busEmpresa = "", string rut = "", int limit = 30, int offset = 0, string sort = "asc", string order = "", string vencimiento = "")
        {
            string token = Request.Headers["Token"].ToString();
            List<ContenedorCampaniaList> res = new List<ContenedorCampaniaList>();
            BootstrapTableResult<ContenedorCampaniaList> xd = new BootstrapTableResult<ContenedorCampaniaList>();


            sort = sort.Substring(sort.IndexOf(".") + 1);
            sort = sort.IndexOf(".") >= 0 ? sort.Substring(sort.IndexOf(".") + 1) : sort;

            if (tipoCampagna == 1 || tipoCampagna == 5)
            {
                int estado_dos = estado == null ? 0 : Convert.ToInt32(estado);
                int subestado_dos = subestado == null ? 0 : Convert.ToInt32(subestado);
                res = AsignacionDataAccess.ListarPaginado(periodo, tipoCampagna, token, estado_dos, marca, subestado_dos, prioridad, segmento, tipo, busEmpresa, rut, offset, limit, sort, order, vencimiento);
            }
            else if (tipoCampagna == 2)
            {
                int estado_dos = estado == null ? 0 : Convert.ToInt32(estado);
                int causa_dos = causaBasal == null ? 0 : Convert.ToInt32(causaBasal);
                int consecuencia_dos = consecuencia == null ? 0 : Convert.ToInt32(consecuencia);

                res = AsignacionDataAccess.ListarPaginado(periodo, tipoCampagna, token, estado_dos, causa_dos, consecuencia_dos, prioridad, rut, offset, limit, sort, order, vencimiento);
            }
            else if (tipoCampagna == 4)
            {
                int estado_dos = estado == null ? 0 : Convert.ToInt32(estado);
                int subestado_dos = subestado == null ? 0 : Convert.ToInt32(subestado);

                res = AsignacionDataAccess.ListarPaginado(periodo, tipoCampagna, token, estado_dos, subestado_dos, rut, offset, limit, sort, order, vencimiento);
            }

            //return res;
            xd.rows = res;
            xd.total = res.Count > 0 ? res[0].TotalRegistros : 0;

            return xd;

        }


        [AuthorizationRequired]
        [HttpGet]
        [Route("detalle-contacto")]
        public ContactoBase DataContacto(string rut)
        {
            string token = Request.Headers["Token"].ToString();
            int rutIn = Convert.ToInt32(rut);

            return new ContactoBase
            {
                Notificaciones = NotificacionAsignacionDataAccess.ObtenerSetNTF(rut),
                Celulares = ContactoafiliadoDataAccess.ObtenerPorRutAfiliadoYTipo(rutIn, "CELULAR"),
                Telefonos = ContactoafiliadoDataAccess.ObtenerPorRutAfiliadoYTipo(rutIn, "TELEFONO"),
                Correos = ContactoafiliadoDataAccess.ObtenerPorRutAfiliadoYTipo(rutIn, "EMAIL"),
                OficinaPreferencia = PreferenciaAfiliadoDataAccess.ObtenerPorID(rutIn, "OFICINA"),
                HorarioPreferencia = PreferenciaAfiliadoDataAccess.ObtenerPorID(rutIn, "HORARIO"),
            };

        }



        [AuthorizationRequired]
        [HttpGet]
        [Route("obtener-seguimiento")]
        public ResultadoBase ObtenerByAfiliado(int periodo, string afiRut, int tipoCampagna)
        {

            ResultadoBase a = new ResultadoBase();
            try
            {
                //string rut_enviar = afiRut.Substring(0, afiRut.IndexOf("-"));
                BaseCampagna x = new BaseCampagna();
                List<AsignacionEntity> ordCmp = AsignacionDataAccess.ObtenerByAfiRut(periodo, afiRut);

                if (tipoCampagna == 1)
                {
                    ordCmp = ordCmp.Where(y => y.TipoAsignacion == 1 || y.TipoAsignacion == 5).ToList();
                }
                else
                {
                    ordCmp = ordCmp.Where(y => y.TipoAsignacion == tipoCampagna).ToList();
                }



                foreach (var item in ordCmp)
                {
                    List<PadreGestion> glst = new List<PadreGestion>();
                    var xx = GestionDataAccess.ListarGestion(item.id_Asign).OrderByDescending(d => d.FechaAccion).ToList();

                    xx.ForEach(n =>
                    {

                        if (tipoCampagna == 1 || tipoCampagna == 5)
                        {
                            Gestion g = new Gestion()
                            {
                                GestionBase = n,
                                EstadoGestion = EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == EstadosyTiposDataAccess.ListarEstadosGestion().Where(d => d.eges_id == n.IdEstado).FirstOrDefault().ejes_id_padre).FirstOrDefault(),
                                SubEstadoGestion = EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == n.IdEstado).FirstOrDefault(),
                                Gestor = new Ejecutivo() { EjecutivoData = DotacionDataAccess.ObtenerByRut(n.RutEjecutivo) }
                            };
                            glst.Add(g);
                        }
                        if (tipoCampagna == 2)
                        {
                            GestionRecuperacion g = new GestionRecuperacion()
                            {
                                GestionBase = n,
                                CausaBasalGestion = EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == Convert.ToInt32((n.IdEstado.ToString().Length == 9) ? n.IdEstado.ToString().Substring(0, 1) : n.IdEstado.ToString().Substring(0, 2))).FirstOrDefault(),
                                ConsecuenciaGestion = EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == Convert.ToInt32((n.IdEstado.ToString().Length == 9) ? n.IdEstado.ToString().Substring(1, 4) : n.IdEstado.ToString().Substring(2, 4))).FirstOrDefault(),
                                EstadoGestion = EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == Convert.ToInt32((n.IdEstado.ToString().Length == 9) ? n.IdEstado.ToString().Substring(5, 4) : n.IdEstado.ToString().Substring(6, 4))).FirstOrDefault(),
                                Gestor = new Ejecutivo() { EjecutivoData = DotacionDataAccess.ObtenerByRut(n.RutEjecutivo) }
                            };
                            glst.Add(g);
                        }
                        if (tipoCampagna == 3)
                        {
                            GestionNormalizacionTMC g = new GestionNormalizacionTMC()
                            {
                                GestionBase = n,
                                EstadoGestion = EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == EstadosyTiposDataAccess.ListarEstadosGestion().Where(d => d.eges_id == n.IdEstado).FirstOrDefault().ejes_id_padre).FirstOrDefault(),
                                SubEstadoGestion = EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == n.IdEstado).FirstOrDefault(),
                                Gestor = new Ejecutivo() { EjecutivoData = DotacionDataAccess.ObtenerByRut(n.RutEjecutivo) }
                            };
                            glst.Add(g);
                        }

                        if (tipoCampagna == 4)
                        {
                            GestionNormalizacionSC g = new GestionNormalizacionSC()
                            {
                                GestionBase = n,
                                EstadoGestion = EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == EstadosyTiposDataAccess.ListarEstadosGestion().Where(d => d.eges_id == n.IdEstado).FirstOrDefault().ejes_id_padre).FirstOrDefault(),
                                SubEstadoGestion = EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == n.IdEstado).FirstOrDefault(),
                                Gestor = new Ejecutivo() { EjecutivoData = DotacionDataAccess.ObtenerByRut(n.RutEjecutivo) }
                            };
                            glst.Add(g);
                        }

                    });

                    x.Seguimiento = item;
                    x.HistorialGestion = glst;
                    x.Notificaciones = NotificacionAsignacionDataAccess.ObtenerSetNTF(item.Afiliado_Rut.ToString());
                    x.Celulares = ContactoafiliadoDataAccess.ObtenerPorRutAfiliadoYTipo(Convert.ToInt32(item.Afiliado_Rut), "CELULAR");
                    x.Telefonos = ContactoafiliadoDataAccess.ObtenerPorRutAfiliadoYTipo(Convert.ToInt32(item.Afiliado_Rut), "TELEFONO");
                    x.Correos = ContactoafiliadoDataAccess.ObtenerPorRutAfiliadoYTipo(Convert.ToInt32(item.Afiliado_Rut), "EMAIL");
                    x.OficinaPreferencia = PreferenciaAfiliadoDataAccess.ObtenerPorID(Convert.ToInt32(item.Afiliado_Rut), "OFICINA");
                    x.HorarioPreferencia = PreferenciaAfiliadoDataAccess.ObtenerPorID(Convert.ToInt32(item.Afiliado_Rut), "HORARIO");
                    x.FiltrosRSG = FiltrosrsgDataAccess.ObtenerEntidad(periodo, item.Afiliado_Rut.ToString(), item.Empresa_Rut.ToString()).Filtros;
                    x.NombreOficina = SucursalDataAccess.ObtenerSucursal(item.Oficina).Nombre;
                }


                if (x.Seguimiento == null)
                {
                    a.Estado = "ERROR";
                    a.Mensaje = "No se encuentra afiliado para el periodo*";
                    a.Objeto = ordCmp;
                }
                else
                {
                    a.Estado = "OK";
                    a.Mensaje = "Afiliado encontrado para el periodo";
                    a.Objeto = x;
                }



            }
            catch (Exception ex)
            {
                a.Estado = "ERROR";
                a.Mensaje = "No se encuentra afiliado para el periodo";
                a.Objeto = ex;
            }

            return a;

        }



        [AuthorizationRequired]
        [HttpGet]
        [Route("obtener-seguimiento-rec")]
        public ResultadoBase ObtenerByAfiliado2(int periodo, string afiRut, int tipoCampagna)
        {

            ResultadoBase a = new ResultadoBase();
            try
            {
                //string rut_enviar = afiRut.Substring(0, afiRut.IndexOf("-"));
                BaseCampagna x = new BaseCampagna();
                AsignacionEntity item = AsignacionDataAccess.ObtenerByAfiRutTipo(periodo, afiRut, tipoCampagna);


                if (item == null)
                {
                    a.Estado = "ERROR";
                    a.Mensaje = "No se encuentra afiliado para el periodo*";
                }
                else
                {

                    List<PadreGestion> glst = new List<PadreGestion>();
                    var xx = GestionDataAccess.ListarGestion(item.id_Asign).OrderByDescending(d => d.FechaAccion).ToList();

                    xx.ForEach(n =>
                    {


                        if (tipoCampagna == 2)
                        {
                            GestionRecuperacion g = new GestionRecuperacion()
                            {
                                GestionBase = n,
                                CausaBasalGestion = EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == Convert.ToInt32((n.IdEstado.ToString().Length == 9) ? n.IdEstado.ToString().Substring(0, 1) : n.IdEstado.ToString().Substring(0, 2))).FirstOrDefault(),
                                ConsecuenciaGestion = EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == Convert.ToInt32((n.IdEstado.ToString().Length == 9) ? n.IdEstado.ToString().Substring(1, 4) : n.IdEstado.ToString().Substring(2, 4))).FirstOrDefault(),
                                EstadoGestion = EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == Convert.ToInt32((n.IdEstado.ToString().Length == 9) ? n.IdEstado.ToString().Substring(5, 4) : n.IdEstado.ToString().Substring(6, 4))).FirstOrDefault(),
                                Gestor = new Ejecutivo() { EjecutivoData = DotacionDataAccess.ObtenerByRut(n.RutEjecutivo) }
                            };
                            glst.Add(g);
                        }


                    });

                    x.Seguimiento = item;
                    x.HistorialGestion = glst;
                    x.Notificaciones = NotificacionAsignacionDataAccess.ObtenerSetNTF(item.Afiliado_Rut.ToString());
                    x.Celulares = ContactoafiliadoDataAccess.ObtenerPorRutAfiliadoYTipo(Convert.ToInt32(item.Afiliado_Rut), "CELULAR");
                    x.Telefonos = ContactoafiliadoDataAccess.ObtenerPorRutAfiliadoYTipo(Convert.ToInt32(item.Afiliado_Rut), "TELEFONO");
                    x.Correos = ContactoafiliadoDataAccess.ObtenerPorRutAfiliadoYTipo(Convert.ToInt32(item.Afiliado_Rut), "EMAIL");
                    x.OficinaPreferencia = PreferenciaAfiliadoDataAccess.ObtenerPorID(Convert.ToInt32(item.Afiliado_Rut), "OFICINA");
                    x.HorarioPreferencia = PreferenciaAfiliadoDataAccess.ObtenerPorID(Convert.ToInt32(item.Afiliado_Rut), "HORARIO");
                    x.FiltrosRSG = FiltrosrsgDataAccess.ObtenerEntidad(periodo, item.Afiliado_Rut.ToString(), item.Empresa_Rut.ToString()).Filtros;
                    x.NombreOficina = SucursalDataAccess.ObtenerSucursal(item.Oficina).Nombre;



                    a.Estado = "OK";
                    a.Mensaje = "Afiliado encontrado para el periodo";
                    a.Objeto = x;
                }



            }
            catch (Exception ex)
            {
                a.Estado = "ERROR";
                a.Mensaje = "No se encuentra afiliado para el periodo";
            }

            return a;

        }



        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-estados-gestion")]
        public IEnumerable<EstadogestionEntity> ListaEstadosGestion(int tipoCampagna, int padre)
        {
            //tipoCampagna = tipoCampagna == 5 ? 1 : tipoCampagna;
            List<EstadogestionEntity> ret = new List<EstadogestionEntity>();
            List<EstadogestionEntity> dataList = EstadosyTiposDataAccess.ListarEstadosGestion();
            if (tipoCampagna == 5)
            {
                ret = dataList.Where(x => x.ejes_id_padre == padre && (x.ejes_tipo_campagna == 5 || x.ejes_tipo_campagna == 1)).ToList();
            }
            else
            {
                ret = dataList.Where(x => x.ejes_id_padre == padre && x.ejes_tipo_campagna == tipoCampagna).ToList();
            }

            return ret;
        }


        [AuthorizationRequired]
        [HttpPost]
        [Route("guardar-gestion")]
        public ResultadoBase GuardarGestion(WebGestion entrada)
        {
            ResultadoBase res = new ResultadoBase();

            try
            {
                if (entrada.ges_subestado.Equals("0"))
                {
                    throw new Exception("[ERR-00001] Error al guardar por favor comuniquese con Soporte");
                }


                string token = Request.Headers["Token"].ToString();
                DotacionEntity ejecutivo = DotacionDataAccess.ObtenerByToken(token);
                GestionEntity oGuardar = new GestionEntity
                {
                    IdBaseCampagna = entrada.ges_id_asignacion,
                    FechaAccion = DateTime.Now,
                    FechaCompromete = entrada.ges_prox_gestion != null ? Convert.ToDateTime(entrada.ges_prox_gestion) : Convert.ToDateTime("1/1/1753 12:00:00"),
                    IdEstado = entrada.ges_subestado,
                    Descripcion = entrada.ges_comentarios,
                    RutEjecutivo = ejecutivo.Rut,
                    IdOficina = ejecutivo.IdSucursal.ToString()

                };

                int id = GestionDataAccess.Guardar(oGuardar);

                ///////
                List<GestionGenerica> glst = new List<GestionGenerica>();
                var xx = GestionDataAccess.ListarGestion(entrada.ges_id_asignacion).OrderByDescending(d => d.FechaAccion).ToList();

                xx.ForEach(x =>
                {
                    GestionGenerica g = new GestionGenerica()
                    {
                        GestionBase = x,
                        EstadoGestion = EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == EstadosyTiposDataAccess.ListarEstadosGestion().Where(d => d.eges_id == x.IdEstado).FirstOrDefault().ejes_id_padre).FirstOrDefault(),
                        SubEstadoGestion = EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == x.IdEstado).FirstOrDefault(),
                        Gestor = new Ejecutivo() { EjecutivoData = DotacionDataAccess.ObtenerByRut(x.RutEjecutivo) }
                    };
                    glst.Add(g);

                });

                res.Objeto = glst;
                res.Estado = "OK";
                res.Mensaje = "Datos Guardados Correctamente";

            }
            catch (Exception ex)
            {
                res.Estado = "ERROR";
                res.Mensaje = ex.Message;
                res.Objeto = ex;
            }

            return res;
        }


        [AuthorizationRequired]
        [HttpPost]
        [Route("guardar-gestion-normalizacion")]
        public ResultadoBase GuardarGestionNormalizacion(WebGestionNormalizacion entrada)
        {
            ResultadoBase res = new ResultadoBase();

            try
            {

                string Estatus = entrada.ges_causa_basal_normalizacion.ToString() + entrada.ges_consecuencia_normalizacion.ToString() + entrada.ges_estado_normalizacion.ToString();
                if (Estatus.Length < 9)
                {
                    throw new Exception("Error al registrar la Gestión");
                }

                string token = Request.Headers["Token"].ToString();
                DotacionEntity ejecutivo = DotacionDataAccess.ObtenerByToken(token);
                GestionEntity oGuardar = new GestionEntity
                {
                    IdBaseCampagna = entrada.ges_id_asignacion_normalizacion,
                    FechaAccion = DateTime.Now,
                    FechaCompromete = entrada.ges_prox_gestion_normalizacion != null ? Convert.ToDateTime(entrada.ges_prox_gestion_normalizacion) : Convert.ToDateTime("1/1/1753 12:00:00"),
                    IdEstado = Convert.ToInt32(Estatus),
                    Descripcion = entrada.ges_comentarios_normalizacion,
                    RutEjecutivo = ejecutivo.Rut,
                    IdOficina = ejecutivo.IdSucursal.ToString()

                };

                int id = GestionDataAccess.Guardar(oGuardar);
                List<PadreGestion> glst = new List<PadreGestion>();
                var xx = GestionDataAccess.ListarGestion(entrada.ges_id_asignacion_normalizacion); //.OrderByDescending(d => d.FechaAccion).ToList();

                xx.ForEach(x =>
                {
                    GestionGenerica g = new GestionGenerica()
                    {
                        GestionBase = x,
                        CausaBasalGestion = EstadosyTiposDataAccess.ObtenerEstadosGestionById(entrada.ges_causa_basal_normalizacion),//EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == entrada.ges_causa_basal_normalizacion).FirstOrDefault(),
                        ConsecuenciaGestion = EstadosyTiposDataAccess.ObtenerEstadosGestionById(entrada.ges_consecuencia_normalizacion),//EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == entrada.ges_consecuencia_normalizacion).FirstOrDefault(),
                        EstadoGestion = EstadosyTiposDataAccess.ObtenerEstadosGestionById(entrada.ges_estado_normalizacion),//EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == entrada.ges_estado_normalizacion).FirstOrDefault(),
                        Gestor = new Ejecutivo() { EjecutivoData = DotacionDataAccess.ObtenerByRut(x.RutEjecutivo) }
                    };
                    glst.Add(g);

                });

                res.Objeto = glst;
                res.Estado = "OK";
                res.Mensaje = "Datos Guardados Correctamente";

            }
            catch (Exception ex)
            {
                res.Estado = "ERROR";
                res.Mensaje = ex.Message;
                res.Objeto = ex;
            }

            return res;
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("guardar-gestion-normalizacionTMC")]
        public ResultadoBase GuardarGestionTMC(WebGestionNormalizacionTMC entrada)
        {
            ResultadoBase res = new ResultadoBase();

            try
            {


                if (entrada.ges_subestadoTMC.Equals("0"))
                {
                    throw new Exception("[ERR-00001] Error al guardar por favor comuniquese con Soporte");
                }


                string token = Request.Headers["Token"].ToString();
                DotacionEntity ejecutivo = DotacionDataAccess.ObtenerByToken(token);
                GestionEntity oGuardar = new GestionEntity
                {
                    IdBaseCampagna = entrada.ges_id_asignacionTMC,
                    FechaAccion = DateTime.Now,
                    FechaCompromete = entrada.ges_prox_gestionTMC != null ? Convert.ToDateTime(entrada.ges_prox_gestionTMC) : Convert.ToDateTime("1/1/1753 12:00:00"),
                    IdEstado = entrada.ges_subestadoTMC,
                    Descripcion = entrada.ges_comentariosTMC,
                    RutEjecutivo = ejecutivo.Rut,
                    IdOficina = ejecutivo.IdSucursal.ToString()

                };

                int id = GestionDataAccess.Guardar(oGuardar);

                ///////
                List<PadreGestion> glst = new List<PadreGestion>();
                var xx = GestionDataAccess.ListarGestion(entrada.ges_id_asignacionTMC).OrderByDescending(d => d.FechaAccion).ToList();

                xx.ForEach(x =>
                {
                    Gestion g = new Gestion()
                    {
                        GestionBase = x,
                        EstadoGestion = EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == EstadosyTiposDataAccess.ListarEstadosGestion().Where(d => d.eges_id == x.IdEstado).FirstOrDefault().ejes_id_padre).FirstOrDefault(),
                        SubEstadoGestion = EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == x.IdEstado).FirstOrDefault(),
                        Gestor = new Ejecutivo() { EjecutivoData = DotacionDataAccess.ObtenerByRut(x.RutEjecutivo) }
                    };
                    glst.Add(g);

                });

                res.Objeto = glst;
                res.Estado = "OK";
                res.Mensaje = "Datos Guardados Correctamente";

            }
            catch (Exception ex)
            {
                res.Estado = "ERROR";
                res.Mensaje = ex.Message;
            }

            return res;
        }


        [AuthorizationRequired]
        [HttpPost]
        [Route("guardar-gestion-normalizacionSC")]
        public ResultadoBase GuardarGestionSC(WebGestionNormalizacionSC entrada)
        {
            ResultadoBase res = new ResultadoBase();

            try
            {


                if (entrada.ges_subestadoSC.Equals(0))
                {
                    throw new Exception("[ERR-00001] Error al guardar por favor comuniquese con Soporte");
                }


                string token = Request.Headers["Token"].ToString();
                DotacionEntity ejecutivo = DotacionDataAccess.ObtenerByToken(token);
                GestionEntity oGuardar = new GestionEntity
                {
                    IdBaseCampagna = entrada.ges_id_asignacionSC,
                    FechaAccion = DateTime.Now,
                    FechaCompromete = entrada.ges_prox_gestionSC != null ? Convert.ToDateTime(entrada.ges_prox_gestionSC) : Convert.ToDateTime("1/1/1753 12:00:00"),
                    IdEstado = entrada.ges_subestadoSC,
                    Descripcion = entrada.ges_comentariosSC,
                    RutEjecutivo = ejecutivo.Rut,
                    IdOficina = ejecutivo.IdSucursal.ToString()

                };

                int id = GestionDataAccess.Guardar(oGuardar);

                ///////
                List<PadreGestion> glst = new List<PadreGestion>();
                var xx = GestionDataAccess.ListarGestion(entrada.ges_id_asignacionSC).OrderByDescending(d => d.FechaAccion).ToList();

                xx.ForEach(x =>
                {
                    Gestion g = new Gestion()
                    {
                        GestionBase = x,
                        EstadoGestion = EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == EstadosyTiposDataAccess.ListarEstadosGestion().Where(d => d.eges_id == x.IdEstado).FirstOrDefault().ejes_id_padre).FirstOrDefault(),
                        SubEstadoGestion = EstadosyTiposDataAccess.ListarEstadosGestion().Where(c => c.eges_id == x.IdEstado).FirstOrDefault(),
                        Gestor = new Ejecutivo() { EjecutivoData = DotacionDataAccess.ObtenerByRut(x.RutEjecutivo) }
                    };
                    glst.Add(g);

                });

                res.Objeto = glst;
                res.Estado = "OK";
                res.Mensaje = "Datos Guardados Correctamente";

            }
            catch (Exception ex)
            {
                res.Estado = "ERROR";
                res.Mensaje = ex.Message;
            }

            return res;
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("guardar-nuevo-contacto")]
        public ResultadoBase GuardarNuevoContacto(WebDatoContacto x)
        {
            ResultadoBase res = new ResultadoBase();

            try
            {
                ContactoafiliadoEntity entidad = new ContactoafiliadoEntity
                {
                    Afiliado_rut = x.afiliado_Rut,
                    Fecha_accion = DateTime.Now,
                    Valor_contacto = x.valor_contacto,
                    Valido = Convert.ToInt16(x.valido)
                };


                switch (x.tipo)
                {
                    case "telefonos":
                        entidad.Tipo_contacto = "TELEFONO";
                        break;

                    case "celulares":
                        entidad.Tipo_contacto = "CELULAR";
                        break;

                    case "correos":
                        entidad.Tipo_contacto = "EMAIL";
                        break;
                }

                ContactoafiliadoDataAccess.Guardar(entidad);
                res.Objeto = entidad;

                res.Estado = "OK";
                res.Mensaje = "Datos Guardados Correctamente";

            }
            catch (Exception ex)
            {
                res.Estado = "ERROR";
                res.Mensaje = ex.Message;
            }

            return res;
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("guardar-preferencia-afiliado")]
        public ResultadoBase GuardarPreferencia(WebPreferenciaAfiliado x)
        {
            ResultadoBase res = new ResultadoBase();

            try
            {
                PreferenciaAfiliadoEntity entidad = new PreferenciaAfiliadoEntity
                {
                    Afiliado_rut = x.afiliado_Rut,
                    Fecha_accion = DateTime.Now,
                    Valor_preferencia = x.valor_preferencia,
                    Valida = x.valido,
                    Tipo_preferencia = x.tipo_preferencia
                };
                PreferenciaAfiliadoDataAccess.Guardar(entidad);
                res.Objeto = entidad;

                res.Estado = "OK";
                res.Mensaje = "Datos Guardados Correctamente";

            }
            catch (Exception ex)
            {
                res.Estado = "ERROR";
                res.Mensaje = ex.Message;
            }

            return res;
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("listar-oficinas")]
        public List<SucursalEntity> listarOffices()
        {
            return SucursalDataAccess.ListarSucursales();
        }
        [AuthorizationRequired]
        [HttpGet]
        [Route("listar-periodos")]
        public List<PeriodoEntity> listarPeriodos(int tipoAsignacion)
        {
            return PeriodoDataAccess.ListarPeriodosGestion(tipoAsignacion);
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("listar-periodosDotacion")]
        public List<PeriodoEntity> listarPeriodosDotacion(int tipoAsignacion)
        {
            return PeriodoDataAccess.ListarPeriodosDotacion(tipoAsignacion);
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("procesar-reasignacion")]
        public ResultadoBase procesarReasignacion(WebReasignacionBase entrada)
        {
            //System.Threading.Thread.Sleep(5000);
            try
            {
                AsignacionDataAccess.Reasignar(entrada);
                return new ResultadoBase()
                {
                    Estado = "OK",
                    Mensaje = "Pruebas ok",
                    Objeto = entrada
                };
            }
            catch (Exception ex)
            {
                return new ResultadoBase()
                {
                    Estado = "ERROR",
                    Mensaje = ex.Message,
                    Objeto = ex
                };
            }
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("listar-mi-oficina")]
        public List<Ejecutivo> listarEjecutivosDeMiOficina(int tipoCampania)
        {
            List<Ejecutivo> salida = new List<Ejecutivo>();
            string token = Request.Headers["Token"].ToString();
            List<DotacionEntity> ejecs = DotacionDataAccess.ListarMiOficina(token);

            if (tipoCampania > 0)
            {
                ejecs.ForEach(ej =>
                {
                    salida.Add(new Ejecutivo { EjecutivoData = ej, CantidadAsignaciones = AsignacionDataAccess.CantidadAsignacionesByRut(ej.Rut, tipoCampania, ej.IdSucursal) });
                });
            }
            else
            {
                ejecs.ForEach(ej =>
                {
                    salida.Add(new Ejecutivo { EjecutivoData = ej, CantidadAsignaciones = 0 });
                });
            }

            return salida;
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("listar-mi-oficina-historica")]
        public List<Ejecutivo> listarEjecutivosDeMiOficinaHistorico(int tipoCampania, int periodo)
        {
            List<Ejecutivo> salida = new List<Ejecutivo>();
            string token = Request.Headers["Token"].ToString();
            List<DotacionEntity> ejecs = DotacionDataAccess.ListarMiOficinaHistorica(token, periodo);

            if (tipoCampania > 0)
            {
                ejecs.ForEach(ej =>
                {
                    salida.Add(new Ejecutivo { EjecutivoData = ej, CantidadAsignaciones = AsignacionDataAccess.CantidadAsignacionesByRut(ej.Rut, tipoCampania, ej.IdSucursal) });
                });
            }
            else
            {
                ejecs.ForEach(ej =>
                {
                    salida.Add(new Ejecutivo { EjecutivoData = ej, CantidadAsignaciones = 0 });
                });
            }

            return salida;
        }
        
        [AuthorizationRequired]
        [HttpGet]
        [Route("listar-empresa-licencia")]
        public IEnumerable<EmpresaLicenciaEntity> ListarEmpresaLicencia()
        {
            return LicenciaDataAccess.ListarEmpresaLicencia();
        }
        [AuthorizationRequired]
        [HttpPost]
        [Route("guardar-recepcion-licencia")]
        public ResultadoBase GuardarRecepcionLicencia(WebLicenciaRecepcion entrada)
        {
            ResultadoBase res = new ResultadoBase();
            string token = Request.Headers["Token"].ToString();
            try
            {
                LicenciaEntity oGuardar = new LicenciaEntity
                {
                    EmpresaRut = entrada.wRutEmpresa,
                    FechaRecepcion = Convert.ToDateTime(entrada.wFechaRecepcion),
                    LMRecibida = entrada.wLMRecibida,
                    LMDigitada = entrada.wLMDigitada,
                    LMNoDigitada = entrada.wLMNoDigitada,
                    LMNoRecepcionada = entrada.wLMNoRecepcion,
                    Token = token,
                    CodOficina = entrada.wCodOficina,
                    LMRecepcionada = entrada.wLMRecepcionada
                };

                int id = LicenciaDataAccess.Guardar(oGuardar);

                res.Estado = "OK";
                res.Mensaje = "Datos Almacenados";
                res.Objeto = id;

            }
            catch (Exception ex)
            {
                res.Estado = "ER";
                res.Mensaje = ex.Message;
                res.Objeto = ex;
            }

            return res;
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("guardar-recepcion-licencia-envio-compin")]
        public ResultadoBase GuardarEnvioLicenciaCompin(WebLicenciaEnvio entrada)
        {
            ResultadoBase res = new ResultadoBase();
            string token = Request.Headers["Token"].ToString();
            try
            {
                LicenciaCompinEntity oGuardarCompin = new LicenciaCompinEntity
                {
                    FechaEnvio = Convert.ToDateTime(entrada.wFechaEnvio),
                    Token = token,
                    CodOficina = entrada.wCodOficina,
                    LMEnviado = entrada.wLMEnviada


                };

                int id = LicenciaDataAccess.GuardarEnvioCompin(oGuardarCompin);
                res.Estado = "OK";
                res.Mensaje = "Datos Almacenados";
                res.Objeto = id;
            }
            catch (Exception ex)
            {
                res.Estado = "ER";
                res.Mensaje = ex.Message;
                res.Objeto = ex;
            }
            return res;
        }


        [AuthorizationRequired]
        [HttpGet]
        [Route("obtener-recepcion-licencia")]
        public ResultadoBase ObtieneLicencia(string RutEmpresa, string Fecha)
        {
            try
            {
                return new ResultadoBase { Estado = "OK", Mensaje = "Datos obtenidos correctamente", Objeto = LicenciaDataAccess.ObtenerRecepcionLicencia(RutEmpresa, Convert.ToDateTime(Fecha)) };
            }
            catch (Exception ex)
            {
                return new ResultadoBase { Estado = "ER", Mensaje = "Error al obtener datos", Objeto = ex };
            }
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("obtener-recepcion-licencia-compin")]
        public ResultadoBase ObtieneLicenciaCompin(string Fecha)
        {
            try
            {
                return new ResultadoBase { Estado = "OK", Mensaje = "Datos obtenidos correctamente", Objeto = LicenciaDataAccess.ObtenerEnvioCompin(Convert.ToDateTime(Fecha)) };

            }
            catch (Exception ex)
            {
                return new ResultadoBase { Estado = "ER", Mensaje = "Error al obtener datos", Objeto = ex };
            }
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("logear-calculadora")]
        public ResultadoBase LogearCalculadora(Business.Entity.Log.LogcalculadoraEntity entrada)
        {
            string token = Request.Headers["Token"].ToString();
            int _uid = Security.Data.TokenDataAccess.Obtener(token).FirstOrDefault().UserId;
            string _rut = Security.Data.UsuarioDataAccess.UsuarioData(_uid).RutUsuario;
            int codOficina = Convert.ToInt32(Request.Cookies["Oficina"]);
            entrada.fecha_accion = DateTime.Now;
            entrada.ejecutivo = _rut;
            entrada.oficina = codOficina;

            Business.Data.Log.LogcalculadoraDataAccess.Guardar(entrada);
            return new ResultadoBase()
            {
                Mensaje = "OK",
                Objeto = entrada
            };
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("guarda-rol-verificador")]
        public IActionResult RolVerificador(WebRolVerificadorHelper entrada)
        {
            string token = Request.Headers["Token"].ToString();
            int _uid = Security.Data.TokenDataAccess.Obtener(token).FirstOrDefault().UserId;
            string _rut = Security.Data.UsuarioDataAccess.UsuarioData(_uid).RutUsuario;
            int codOficina = Convert.ToInt32(Request.Cookies["Oficina"]);



            LogRolVerificadorEntity entidad = new LogRolVerificadorEntity
            {
                //Id = entrada.Id,
                RutAfiliado = entrada.RutAfiliado,
                Anexo = Convert.ToInt32(entrada.Anexo),
                RutEmpresa = entrada.RutEmpresa,
                NombreEmpresa = entrada.NombreEmpresa,
                Cotiza = determinarEstado(entrada.Cotiza),
                Grado = determinarEstado(entrada.Grado),
                SeguroCesantia = determinarEstado(entrada.SeguroCesantia),
                ProEmpleo = determinarEstado(entrada.ProEmpleo),
                LeyEspecifica = determinarEstado(entrada.LeyEspecifica),
                LeyEspecifica2 = determinarEstado(entrada.LeyEspecifica2),
                RutEjecutivo = _rut,
                CodSucursal = codOficina,
                Resultado1 = entrada.Resultado1
            };
            var res = LogcalculadoraDataAccess.GuardarRolVerificador(entidad);


            return Ok(res);


            //return Business.Data.Log.LogcalculadoraDataAccess.GuardarRolVerificador(entrada);
            //return new ResultadoBase()
            //{
            //    Mensaje = "OK",
            //    Objeto = entrada
            //};
        }


        [AuthorizationRequired]
        [HttpPost]
        [Route("guarda-rol-verificador-calculo")]
        public IActionResult RolVerificadorCalculo(WebRolVerificadorHelper entrada)
        {
            LogRolVerificadorEntity entidad = new LogRolVerificadorEntity
            {
                Id = entrada.Id,
                TotalHaberes = Convert.ToInt32(entrada.TotalHaberes.Replace(".", "")),
                BonosExtras = Convert.ToInt32(entrada.BonosExtras.Replace(".", "")),
                //DescuentoLegalMes1 = Convert.ToInt32(entrada.DescuentoLegalMes1),
                //DescuentoLegalMes2 = Convert.ToInt32(entrada.DescuentoLegalMes2),
                //DescuentoLegalMes3 = Convert.ToInt32(entrada.DescuentoLegalMes3),
                Promedio = Convert.ToInt32(entrada.Promedio.Replace(".","")),
                RentaDepurada = Convert.ToInt32(entrada.RentaDepurada.Replace(".", "")),
                RentaDepuradaCMR = Convert.ToInt32(entrada.RentaDepuradaCMR.Replace(".", "")),
                TotalDescuento = Convert.ToInt32(entrada.TotalDescuento.Replace(".", "")),
                OtrosDescuentos = Convert.ToInt32(entrada.OtrosDescuentos.Replace(".", "")),
                ValorCuotaCredito = Convert.ToInt32(entrada.ValorCuotaCredito.Replace(".", "")),
                ValorCuotaCreditoComp = Convert.ToInt32(entrada.ValorCuotaCreditoComp.Replace(".", "")),
                Resultado2 = entrada.Resultado2
            };
            var res = LogcalculadoraDataAccess.GuardarRolVerificador(entidad);


            return Ok(res);


            //return Business.Data.Log.LogcalculadoraDataAccess.GuardarRolVerificador(entrada);
            //return new ResultadoBase()
            //{
            //    Mensaje = "OK",
            //    Objeto = entrada
            //};
        }



        private bool? determinarEstado(string input)
        {
            if (input == null)
            {
                return null;
            }
            else
            {
                return bool.Parse(input);
            }
        }


        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-rechazos-rsg")]
        public IEnumerable<AsignacionRechazos> ObtenerRechRSG(int Periodo, int RutEmpresa, int RutAfiliado)
        {
            return AsignacionDataAccess.obtenerRechazos(Periodo, RutEmpresa, RutAfiliado);
        }
        [AuthorizationRequired]
        [HttpGet]
        [Route("obtener-afi")]
        public BaseCampagnaEntity ObtenerAfiliado(string RutAfi)
        {
            return BaseCampagnaDataAccess.ObtenerAfiliado(RutAfi);
        }

        //[AuthorizationRequired]
        [HttpGet]
        [Route("existe-empresas-15-porciento")]
        public dynamic ObtenerEmpresas15(string rut_empresa)
        {
            try
            {
                string rut = rut_empresa.Replace("_", "").Replace(".", "");
                rut = rut.Substring(0, rut.IndexOf("-"));
                int existe = Business.Data.Log.LogcalculadoraDataAccess.ObtenerEmpresas15porc(rut);
                dynamic d = new { valid = (existe == 1), data = rut };
                return d;
            }
            catch (Exception ex)
            {
                dynamic d = new { valid = false, data = ex };
                return d;
            }
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-empresas")]
        public IEnumerable<DatosEmpresaEntity> ListaEmpresa()
        {
            string token = Request.Headers["Token"].ToString();
            return AsignacionDataAccess.ListaEmpresaEje(token);
        }


        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-empresa-rol")]
        public EmpresaRolVerificadorEntity ObtenerEmpresaRol(int IdAnexo)
        {
            return LogcalculadoraDataAccess.ObtieneEmpresaRol(IdAnexo);
        }


    }



}
