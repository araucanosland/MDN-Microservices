using System;
using System.Collections.Generic;
using System.Linq;
using CRM.Business.Entity;
using CRM.Business.Entity.Clases;
using CRM.Business.Entity.Empresas;
using CRM.Business.Data;
using CRM.Business.Data.Empresas;
using CRM.Filters;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    //Motor de Empresas
    [Route("api/Empresas")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        #region Generales

        [HttpGet]
        [Route("data-empresa/{RutEmpresa}")]
        public Business.Entity.Maestros.EmpresasEntity DataEmpresa(string RutEmpresa)
        {
            return Business.Data.Maestros.EmpresasDataAccess.ObtenerByRut(RutEmpresa);
        }

        #endregion



        #region Fidelizacion

        //[AuthorizationRequired]
        [HttpGet]
        [Route("listar-fidelizacion")]
        public BootstrapTableResult<FidelizaContainer> ListadoFidelizacion(string sort= "Empresa.emp_rut", string order="asc", int limit = 30, int offset = 0, string search="")
        {
            int codOficina = Convert.ToInt32(Request.Cookies["Oficina"]);

            List<FidelizaContainer> salida = new List<FidelizaContainer>();
            BootstrapTableResult<FidelizaContainer> salida_final = new BootstrapTableResult<FidelizaContainer>();
            FidelizacionDataAccess.ObtenerEntidades().FindAll(x => x.cod_oficina == codOficina ).ForEach(fide =>
            {
                FidelizaContainer fc = new FidelizaContainer();
                fc.Fidelizacion = fide;
                fc.Representante = RepresentanteempresaDataAccess.ObtenerPorID(fide.representante_id);
                fc.Empresa = EmpresaDataAccess.ObtenerPorID(fc.Representante.emp_id);
                fc.ResultadoGestion = ResultadogestionDataAccess.ObtenerEntidades().FindAll(d => d.fidelizacion_id == fide.fide_id);
                List<AmbitosContainer<AmbitosfidelizacionEntity>> ambits = new List<AmbitosContainer<AmbitosfidelizacionEntity>>();
                AmbitosfidelizacionDataAccess.ObtenerEntidades().FindAll(d => d.fidelizacion_id == fc.Fidelizacion.fide_id).ForEach(amf => {
                    AmbitosContainer<AmbitosfidelizacionEntity> saf = new AmbitosContainer<AmbitosfidelizacionEntity>();
                    saf.AmbitoFinal = amf;
                    saf.AmbitoArea = AmbitosareaDataAccess.ObtenerPorID(amf.ambito_id);
                    saf.Area = AreasDataAccess.ObtenerPorID(saf.AmbitoArea.area_id);
                    ambits.Add(saf);
                });
                fc.Ambitos = ambits;
                salida.Add(fc);
            });

            if(!string.IsNullOrEmpty(search))
            {
                salida = salida.FindAll(s =>    s.Empresa.emp_nombre.ToLower().Contains(search.ToLower()) 
                                            ||  s.Empresa.emp_rut.ToLower().Contains(search.ToLower().Replace(".",""))
                                            ||  s.Empresa.emp_holding.ToLower().Contains(search.ToLower())
                                            ).ToList();
            }

            switch (order)
            {
                case "asc":
                    switch (sort)
                    {
                        case "Empresa.emp_rut":
                            salida = salida.OrderBy(o => o.Empresa.emp_rut).ToList();
                            break;
                        case "Empresa.emp_nombre":
                            salida = salida.OrderBy(o => o.Empresa.emp_nombre).ToList();
                            break;
                        case "Empresa.emp_holding":
                            salida = salida.OrderBy(o => o.Empresa.emp_holding).ToList();
                            break;
                        case "Representante.rep_nombre":
                            salida = salida.OrderBy(o => o.Fidelizacion.fide_estamento).ToList();
                            break;
                        case "Fidelizacion.fide_estamento":
                            salida = salida.OrderBy(o => o.Empresa.emp_nombre).ToList();
                            break;
                        case "Fidelizacion.fide_fecha_calendario":
                            salida = salida.OrderBy(o => o.Fidelizacion.fide_fecha_calendario).ToList();
                            break;
                    }
                    break;
                case "desc":
                    switch (sort)
                    {
                        case "Empresa.emp_rut":
                            salida = salida.OrderByDescending(o => o.Empresa.emp_rut).ToList();
                            break;
                        case "Empresa.emp_nombre":
                            salida = salida.OrderByDescending(o => o.Empresa.emp_nombre).ToList();
                            break;
                        case "Empresa.emp_holding":
                            salida = salida.OrderByDescending(o => o.Empresa.emp_holding).ToList();
                            break;
                        case "Representante.rep_nombre":
                            salida = salida.OrderByDescending(o => o.Fidelizacion.fide_estamento).ToList();
                            break;
                        case "Fidelizacion.fide_estamento":
                            salida = salida.OrderByDescending(o => o.Empresa.emp_nombre).ToList();
                            break;
                        case "Fidelizacion.fide_fecha_calendario":
                            salida = salida.OrderByDescending(o => o.Fidelizacion.fide_fecha_calendario).ToList();
                            break;
                    }
                    break;
            }

            salida_final.total = salida.Count;
            salida_final.rows = salida.Skip(offset).Take(limit).ToList();
            return salida_final;
        }


        //[AuthorizationRequired]
        [HttpGet]
        [Route("data-fidelizacion")]
        public FidelizaContainer DataFidelizacion(int id)
        {
            FidelizaContainer salida = new FidelizaContainer();
            salida.Fidelizacion = FidelizacionDataAccess.ObtenerPorID(id);
            salida.Representante = RepresentanteempresaDataAccess.ObtenerPorID(salida.Fidelizacion.representante_id);
            salida.Empresa = EmpresaDataAccess.ObtenerPorID(salida.Representante.emp_id);
            salida.ResultadoGestion = ResultadogestionDataAccess.ObtenerEntidades().FindAll(d=>d.fidelizacion_id == salida.Fidelizacion.fide_id);

            List<AmbitosContainer<AmbitosfidelizacionEntity>> ambits = new List<AmbitosContainer<AmbitosfidelizacionEntity>>();
            AmbitosfidelizacionDataAccess.ObtenerEntidades().FindAll(d => d.fidelizacion_id == salida.Fidelizacion.fide_id).ForEach(amf => {
                AmbitosContainer<AmbitosfidelizacionEntity> saf = new AmbitosContainer<AmbitosfidelizacionEntity>();
                saf.AmbitoFinal = amf;
                saf.AmbitoArea = AmbitosareaDataAccess.ObtenerPorID(amf.ambito_id);
                saf.Area = AreasDataAccess.ObtenerPorID(saf.AmbitoArea.area_id);
                ambits.Add(saf);
            });

            salida.Ambitos = ambits;
            
            return salida;
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("guardar-fidelizacion")]
        public ResultadoBase GuardarFidelizacion(Fideliza entrada)
        {
            try
            {
                string token = Request.Headers["Token"].ToString();
                int _uid = Security.Data.TokenDataAccess.Obtener(token).FirstOrDefault().UserId;
                string _rut = Security.Data.UsuarioDataAccess.UsuarioData(_uid).RutUsuario;
                int codOficina = Convert.ToInt32(Request.Cookies["Oficina"]);



                EmpresaEntity em = EmpresaDataAccess.ObtenerEntidades().Find(emp => emp.emp_rut == entrada.Rut.Replace(".", ""));
                if(em == null)
                {
                    em = new EmpresaEntity();
                    em.emp_rut = entrada.Rut.Replace(".", "");
                    em.emp_nombre = entrada.Nombre;
                    em.emp_holding = entrada.Holding;
                    em.emp_id = EmpresaDataAccess.Guardar(em);
                }

                

                RepresentanteempresaEntity rep = RepresentanteempresaDataAccess.ObtenerPorID(entrada.IdRepresentante);
                if (rep == null)
                {
                    rep = new RepresentanteempresaEntity();
                }

                rep.emp_id = em.emp_id;
                rep.rep_nombre = entrada.NombreRepresentante;
                rep.rep_cargo = entrada.CargoRepresentante;
                rep.rep_id = RepresentanteempresaDataAccess.Guardar(rep);

                FidelizacionEntity fd = FidelizacionDataAccess.ObtenerPorID(entrada.IdFidelizacion);
                if(fd == null)
                {
                    fd = new FidelizacionEntity();
                }

                fd.fide_actividad = entrada.Actividad;
                fd.fide_cobertura = entrada.Cobertura;
                fd.fide_estamento = entrada.Estamento;
                fd.fide_fecha_calendario = Convert.ToDateTime(entrada.FechaFidelizacion);
                fd.fide_fecha_accion = DateTime.Now;
                fd.representante_id = rep.rep_id;
                fd.cod_oficina = codOficina;
                fd.rut_ejecutivo = _rut;
                fd.fide_id = FidelizacionDataAccess.Guardar(fd);

                if(entrada.Ambitos.Count > 0)
                {
                    AmbitosfidelizacionDataAccess.EliminarByFidelizacion(fd.fide_id);
                    entrada.Ambitos.ForEach(amb =>
                    {
                        AmbitosfidelizacionEntity _amb = new AmbitosfidelizacionEntity();
                        _amb.ambito_id = Convert.ToInt32(amb.valor);
                        _amb.fidelizacion_id = fd.fide_id;
                        AmbitosfidelizacionDataAccess.Guardar(_amb);
                    });
                }
                
                if(entrada.ResultadosGestion.Count > 0)
                {
                    ResultadogestionDataAccess.EliminarByFidelizacion(fd.fide_id);
                    entrada.ResultadosGestion.ForEach(rges => {
                        ResultadogestionEntity _resg = new ResultadogestionEntity();
                        _resg.fidelizacion_id = fd.fide_id;
                        _resg.resg_comentarios = rges.contenido;
                        _resg.resg_fecha = Convert.ToDateTime(rges.fecha + " 00:00:00");
                        _resg.resg_tipo = rges.tipo;
                        ResultadogestionDataAccess.Guardar(_resg);
                    });
                }
                

                return new ResultadoBase() { Estado="OK", Mensaje="Fidelización Almacenada con Éxito", Objeto = entrada };
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Guardar Fidelización", ex);
            }
        }

        #endregion


        #region Retnecion
        //[AuthorizationRequired]
        [HttpGet]
        [Route("listar-retencion")]
        public BootstrapTableResult<RetieneContainer> ListadoRetencion(string sort = "Empresa.emp_rut", string order = "asc", int limit = 30, int offset = 0, string search = "")
        {
            int codOficina = Convert.ToInt32(Request.Cookies["Oficina"]);

            List<RetieneContainer> salida = new List<RetieneContainer>();
            BootstrapTableResult<RetieneContainer> salida_final = new BootstrapTableResult<RetieneContainer>();

            RetencionDataAccess.ObtenerEntidades().FindAll(x => x.oficina == codOficina).ForEach(ret => {
                RetieneContainer container = new RetieneContainer();
                container.Retencion = ret;
                container.Gestiones = GestionretencionDataAccess.ObtenerEntidades().FindAll(g => g.retencion_id == ret.ret_id);
                container.UltimaGestion = GestionretencionDataAccess.ObtenerEntidades().FindAll(g => g.retencion_id == ret.ret_id).OrderByDescending(d => d.gstr_fecha_accion).FirstOrDefault();
                container.Empresa = EmpresaDataAccess.ObtenerPorID(ret.empresa_id);
                List<AmbitosContainer<AmbitosretencionEntity>> ambits = new List<AmbitosContainer<AmbitosretencionEntity>>();
                AmbitosretencionDataAccess.ObtenerEntidades().FindAll(d => d.retencion_id == ret.ret_id).ForEach(amf => {
                    AmbitosContainer<AmbitosretencionEntity> saf = new AmbitosContainer<AmbitosretencionEntity>();
                    saf.AmbitoFinal = amf;
                    saf.AmbitoArea = AmbitosareaDataAccess.ObtenerPorID(amf.ambito_id);
                    saf.Area = AreasDataAccess.ObtenerPorID(saf.AmbitoArea.area_id);
                    ambits.Add(saf);
                });
                container.Ambitos = ambits;
                salida.Add(container);
            });

            if (!string.IsNullOrEmpty(search))
            {
                salida = salida.FindAll(s => s.Empresa.emp_nombre.ToLower().Contains(search.ToLower())
                                            || s.Empresa.emp_rut.ToLower().Contains(search.ToLower().Replace(".", ""))
                                            || s.Empresa.emp_holding.ToLower().Contains(search.ToLower())
                                            ).ToList();
            }

            switch (order)
            {
                case "asc":
                    switch (sort)
                    {
                        case "Empresa.emp_rut":
                            salida = salida.OrderBy(o => o.Empresa.emp_rut).ToList();
                            break;
                        case "Empresa.emp_nombre":
                            salida = salida.OrderBy(o => o.Empresa.emp_nombre).ToList();
                            break;
                        case "Empresa.emp_holding":
                            salida = salida.OrderBy(o => o.Empresa.emp_holding).ToList();
                            break;
                        case "Retencion.ret_estamento":
                            salida = salida.OrderBy(o => o.Retencion.ret_estamento).ToList();
                            break;
                        case "Retencion.ret_caja_destino":
                            salida = salida.OrderBy(o => o.Retencion.ret_caja_destino).ToList();
                            break;
                    }
                    break;
                case "desc":
                    switch (sort)
                    {
                        case "Empresa.emp_rut":
                            salida = salida.OrderByDescending(o => o.Empresa.emp_rut).ToList();
                            break;
                        case "Empresa.emp_nombre":
                            salida = salida.OrderByDescending(o => o.Empresa.emp_nombre).ToList();
                            break;
                        case "Empresa.emp_holding":
                            salida = salida.OrderByDescending(o => o.Empresa.emp_holding).ToList();
                            break;
                        case "Retencion.ret_estamento":
                            salida = salida.OrderByDescending(o => o.Retencion.ret_estamento).ToList();
                            break;
                        case "Retencion.ret_caja_destino":
                            salida = salida.OrderByDescending(o => o.Retencion.ret_caja_destino).ToList();
                            break;
                    }
                    break;
            }

            salida_final.total = salida.Count;
            salida_final.rows = salida.Skip(offset).Take(limit).ToList();
            return salida_final;
        }

        //[AuthorizationRequired]
        [HttpGet]
        [Route("data-retencion")]
        public RetieneContainer DataRetencion(int id)
        {
            RetieneContainer salida = new RetieneContainer();
            salida.Retencion = RetencionDataAccess.ObtenerPorID(id);
            salida.Empresa = EmpresaDataAccess.ObtenerPorID(salida.Retencion.empresa_id);
            salida.Gestiones = GestionretencionDataAccess.ObtenerEntidades().FindAll(g => g.retencion_id == id);
            salida.UltimaGestion = GestionretencionDataAccess.ObtenerEntidades().FindAll(g => g.retencion_id == id).OrderByDescending(d => d.gstr_fecha_accion).FirstOrDefault();
            List<AmbitosContainer<AmbitosretencionEntity>> ambits = new List<AmbitosContainer<AmbitosretencionEntity>>();
            AmbitosretencionDataAccess.ObtenerEntidades().FindAll(d => d.retencion_id == salida.Retencion.ret_id).ForEach(amf => {
                AmbitosContainer<AmbitosretencionEntity> saf = new AmbitosContainer<AmbitosretencionEntity>();
                saf.AmbitoFinal = amf;
                saf.AmbitoArea = AmbitosareaDataAccess.ObtenerPorID(amf.ambito_id);
                saf.Area = AreasDataAccess.ObtenerPorID(saf.AmbitoArea.area_id);
                ambits.Add(saf);
            });

            salida.Ambitos = ambits;

            return salida;
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("guardar-retencion")]
        public ResultadoBase GuardarRetencion(Retiene entrada)
        {
            try
            {
                string token = Request.Headers["Token"].ToString();
                int _uid = Security.Data.TokenDataAccess.Obtener(token).FirstOrDefault().UserId;
                string _rut = Security.Data.UsuarioDataAccess.UsuarioData(_uid).RutUsuario;
                int codOficina = Convert.ToInt32(Request.Cookies["Oficina"]);




                EmpresaEntity em = EmpresaDataAccess.ObtenerEntidades().Find(emp => emp.emp_rut == entrada.Rut.Replace(".", ""));
                if (em == null)
                {
                    em = new EmpresaEntity();
                    em.emp_rut = entrada.Rut.Replace(".", "");
                    em.emp_nombre = entrada.Nombre;
                    em.emp_holding = entrada.Holding;
                    em.emp_id = EmpresaDataAccess.Guardar(em);
                }


                RetencionEntity rt = RetencionDataAccess.ObtenerPorID(entrada.IdRetencion);
                if(rt.ret_id == 0)
                {
                    rt.empresa_id = em.emp_id;
                    rt.ret_caja_destino = entrada.CajaDestino;
                    rt.ret_dotacion = Convert.ToInt32(entrada.Dotacion);
                    rt.ret_estamento = entrada.Estamento;
                    rt.ret_segmento = entrada.Segmento;
                    rt.ejecutivo_rut = _rut;
                    rt.oficina = codOficina;
                    rt.ret_id = RetencionDataAccess.Guardar(rt);
                    
                    //Primera Gestion solo si es nuevo
                    GestionretencionEntity gst = new GestionretencionEntity();
                    gst.gstr_etapa = "Estudio Cajas";
                    gst.gstr_fecha = DateTime.Now;
                    gst.gstr_fecha_accion = DateTime.Now;
                    gst.gstr_observaciones = "SISTEMA Gestion Inicial";
                    gst.retencion_id = rt.ret_id;
                    gst.ejecutivo_rut = _rut;
                    gst.oficina = codOficina;
                    GestionretencionDataAccess.Guardar(gst);
                }
                

                if (entrada.Ambitos.Count > 0)
                {
                    AmbitosretencionDataAccess.EliminarByRetencion(rt.ret_id);
                    entrada.Ambitos.ForEach(amb =>
                    {
                        AmbitosretencionEntity _amb = new AmbitosretencionEntity();
                        _amb.ambito_id = Convert.ToInt32(amb.valor);
                        _amb.retencion_id = rt.ret_id;
                        AmbitosretencionDataAccess.Guardar(_amb);
                    });
                }

                



                return new ResultadoBase() { Estado = "OK", Mensaje = "Retención Almacenada con Éxito", Objeto = entrada };
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Guardar Retencion", ex);
            }
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("guardar-gestion-retencion")]
        public ResultadoBase GuardarGestionRetencion(GestionRetiene entrada)
        {
            try
            {
                string token = Request.Headers["Token"].ToString();
                int _uid = Security.Data.TokenDataAccess.Obtener(token).FirstOrDefault().UserId;
                string _rut = Security.Data.UsuarioDataAccess.UsuarioData(_uid).RutUsuario;
                int codOficina = Convert.ToInt32(Request.Cookies["Oficina"]);

                GestionretencionEntity gst = new GestionretencionEntity();
                gst.ejecutivo_rut = _rut;
                gst.oficina = codOficina;
                gst.retencion_id = entrada.IdRetencion;
                gst.gstr_etapa = entrada.Etapa;
                gst.gstr_fecha = Convert.ToDateTime(entrada.Fecha);
                gst.gstr_fecha_accion = DateTime.Now;
                gst.gstr_observaciones = entrada.Observaciones;

                GestionretencionDataAccess.Guardar(gst);

                return new ResultadoBase() { Estado = "OK", Mensaje = "Gestión Almacenada con Éxito", Objeto = entrada };
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Guardar Retencion", ex);
            }
        }
        #endregion


        #region Prospeccion
        //[AuthorizationRequired]
        [HttpGet]
        [Route("listar-prospeccion")]
        public BootstrapTableResult<ProspectoContainer> ListadoProspeccion(string sort = "Empresa.emp_rut", string order = "asc", int limit = 30, int offset = 0, string search = "")
        {

            int codOficina = Convert.ToInt32(Request.Cookies["Oficina"]);

            List<ProspectoContainer> salida = new List<ProspectoContainer>();
            BootstrapTableResult<ProspectoContainer> salida_final = new BootstrapTableResult<ProspectoContainer>();

            ProspeccionDataAccess.ObtenerEntidades().FindAll(x => x.oficina == codOficina).ForEach(pro => {
                ProspectoContainer container = new ProspectoContainer();
                container.Prospeccion = pro;
                container.Gestiones = GestionprospeccionDataAccess.ObtenerEntidades().FindAll(g => g.prospecto_id == pro.pros_id);
                container.UltimaGestion = container.Gestiones.OrderByDescending(d => d.gstp_fecha_accion).FirstOrDefault();
                container.Empresa = EmpresaDataAccess.ObtenerPorID(pro.empresa_id);
                salida.Add(container);
            });

            if (!string.IsNullOrEmpty(search))
            {
                salida = salida.FindAll(s => s.Empresa.emp_nombre.ToLower().Contains(search.ToLower())
                                            || s.Empresa.emp_rut.ToLower().Contains(search.ToLower().Replace(".", ""))
                                            || s.Empresa.emp_holding.ToLower().Contains(search.ToLower())
                                            ).ToList();
            }

            switch (order)
            {
                case "asc":
                    switch (sort)
                    {
                        case "Empresa.emp_rut":
                            salida = salida.OrderBy(o => o.Empresa.emp_rut).ToList();
                            break;
                        case "Empresa.emp_nombre":
                            salida = salida.OrderBy(o => o.Empresa.emp_nombre).ToList();
                            break;
                        case "Empresa.emp_holding":
                            salida = salida.OrderBy(o => o.Empresa.emp_holding).ToList();
                            break;
                        case "Prospeccion.pros_caja_origen":
                            salida = salida.OrderBy(o => o.Prospeccion.pros_caja_origen).ToList();
                            break;
                        case "UltimaGestion.gstp_fecha_accion":
                            salida = salida.OrderBy(o => o.UltimaGestion.gstp_fecha_accion).ToList();
                            break;
                    }
                    break;
                case "desc":
                    switch (sort)
                    {
                        case "Empresa.emp_rut":
                            salida = salida.OrderByDescending(o => o.Empresa.emp_rut).ToList();
                            break;
                        case "Empresa.emp_nombre":
                            salida = salida.OrderByDescending(o => o.Empresa.emp_nombre).ToList();
                            break;
                        case "Empresa.emp_holding":
                            salida = salida.OrderByDescending(o => o.Empresa.emp_holding).ToList();
                            break;
                        case "Prospeccion.pros_caja_origen":
                            salida = salida.OrderByDescending(o => o.Prospeccion.pros_caja_origen).ToList();
                            break;
                        case "UltimaGestion.gstp_fecha_accion":
                            salida = salida.OrderByDescending(o => o.UltimaGestion.gstp_fecha_accion).ToList();
                            break;
                    }
                    break;
            }

            salida_final.total = salida.Count;
            salida_final.rows = salida.Skip(offset).Take(limit).ToList();
            return salida_final;
        }

        //[AuthorizationRequired]
        [HttpGet]
        [Route("data-prospeccion")]
        public ProspectoContainer DataProspeccion(int id)
        {
            ProspectoContainer salida = new ProspectoContainer();
            salida.Prospeccion = ProspeccionDataAccess.ObtenerPorID(id);
            salida.Empresa = EmpresaDataAccess.ObtenerPorID(salida.Prospeccion.empresa_id);
            salida.Gestiones = GestionprospeccionDataAccess.ObtenerEntidades().FindAll(g => g.prospecto_id == id);
            salida.UltimaGestion = salida.Gestiones.OrderByDescending(d => d.gstp_fecha_accion).FirstOrDefault();
            
            return salida;
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("guardar-prospeccion")]
        public ResultadoBase GuardarRetencion(Prospecta entrada)
        {
            try
            {
                string token = Request.Headers["Token"].ToString();
                int _uid = Security.Data.TokenDataAccess.Obtener(token).FirstOrDefault().UserId;
                string _rut = Security.Data.UsuarioDataAccess.UsuarioData(_uid).RutUsuario;
                int codOficina = Convert.ToInt32(Request.Cookies["Oficina"]);



                EmpresaEntity em = EmpresaDataAccess.ObtenerEntidades().Find(emp => emp.emp_rut == entrada.Rut.Replace(".", ""));
                if (em == null)
                {
                    em = new EmpresaEntity();
                    em.emp_rut = entrada.Rut.Replace(".", "");
                    em.emp_nombre = entrada.Nombre;
                    em.emp_holding = entrada.Holding;
                    em.emp_id = EmpresaDataAccess.Guardar(em);
                }


                ProspeccionEntity pro = ProspeccionDataAccess.ObtenerPorID(entrada.IdProspeccion);
                if (pro.pros_id == 0)
                {
                    pro.empresa_id = em.emp_id;
                    pro.pros_caja_origen = entrada.CajaOrigen;
                    pro.pros_dotacion = Convert.ToInt32(entrada.Dotacion);
                    pro.ejecutivo_rut = _rut;
                    pro.oficina = codOficina;
                    pro.pros_id = ProspeccionDataAccess.Guardar(pro);

                    //Primera Gestion solo si es nuevo
                    GestionprospeccionEntity gst = new GestionprospeccionEntity();
                    gst.gstp_etapa = "Prospección";
                    gst.gstp_fecha = DateTime.Now;
                    gst.gstp_fecha_accion = DateTime.Now;
                    gst.gstp_observaciones = "SISTEMA Gestión Inicial";
                    gst.prospecto_id = pro.pros_id;
                    gst.ejecutivo_rut = _rut;
                    gst.oficina = codOficina;
                    GestionprospeccionDataAccess.Guardar(gst);
                }
                
                return new ResultadoBase() { Estado = "OK", Mensaje = "Prospección Almacenada con Éxito", Objeto = entrada };
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Guardar Retencion", ex);
            }
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("guardar-gestion-prospeccion")]
        public ResultadoBase GuardarGestionProspeccion(GestionProspecto entrada)
        {
            try
            {
                string token = Request.Headers["Token"].ToString();
                int _uid = Security.Data.TokenDataAccess.Obtener(token).FirstOrDefault().UserId;
                string _rut = Security.Data.UsuarioDataAccess.UsuarioData(_uid).RutUsuario;
                int codOficina = Convert.ToInt32(Request.Cookies["Oficina"]);

                GestionprospeccionEntity gst = new GestionprospeccionEntity();
                gst.ejecutivo_rut = _rut;
                gst.oficina = codOficina;
                gst.prospecto_id = entrada.IdProspeccion;
                gst.gstp_etapa = entrada.Etapa;
                gst.gstp_fecha = Convert.ToDateTime(entrada.Fecha);
                gst.gstp_fecha_accion = DateTime.Now;
                gst.gstp_observaciones = entrada.Observaciones;
                GestionprospeccionDataAccess.Guardar(gst);

                return new ResultadoBase() { Estado = "OK", Mensaje = "Gestión Almacenada con Éxito", Objeto = entrada };
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Guardar Retencion", ex);
            }
        }
        #endregion
    }

    public class BootstrapTableResult<T>
    {
        public int total { get; set; }
        public IEnumerable<T> rows { get; set; }
    }

    public class FidelizaContainer
    {
        public FidelizacionEntity Fidelizacion { get; set; }
        public RepresentanteempresaEntity Representante { get; set; }
        public EmpresaEntity Empresa { get; set; }
        public IEnumerable<AmbitosContainer<AmbitosfidelizacionEntity>> Ambitos { get; set; }
        public IEnumerable<ResultadogestionEntity> ResultadoGestion { get; set; } 
    }

    public class RetieneContainer
    {
        public RetencionEntity Retencion { get; set; }
        public EmpresaEntity Empresa { get; set; }
        public GestionretencionEntity UltimaGestion { get; set; }
        public IEnumerable<GestionretencionEntity> Gestiones { get; set; }
        public IEnumerable<AmbitosContainer<AmbitosretencionEntity>> Ambitos { get; set; }
    }

    public class ProspectoContainer
    {
        public ProspeccionEntity Prospeccion { get; set; }
        public EmpresaEntity Empresa { get; set; }
        public GestionprospeccionEntity UltimaGestion { get; set; }
        public IEnumerable<GestionprospeccionEntity> Gestiones { get; set; }
    }

    public class AmbitosContainer<T>
    {
        public T AmbitoFinal { get; set; }
        public AmbitosareaEntity AmbitoArea { get; set; }
        public AreasEntity Area { get; set; }
    }

    public class Fideliza
    {
        public int IdFidelizacion { get; set; }
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Holding { get; set; }
        public string Estamento { get; set; }
        public string Actividad { get; set; }
        public string Cobertura { get; set; }
        public int IdRepresentante { get; set; }
        public string NombreRepresentante { get; set; }
        public string CargoRepresentante { get; set; }
        public string FechaFidelizacion { get; set; }
        public List<ResultadoGestion> ResultadosGestion { get; set; }
        public List<Ambito> Ambitos { get; set; }

    }

    public class Retiene
    {
        public int IdRetencion { get; set; }
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Holding { get; set; }
        public string Estamento { get; set; }
        public string Segmento { get; set; }
        public string Dotacion { get; set; }
        public string CajaDestino { get; set; }
        public List<Ambito> Ambitos { get; set; }
    }

    public class Prospecta
    {
        public int IdProspeccion { get; set; }
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Holding { get; set; }
        public string Dotacion { get; set; }
        public string CajaOrigen { get; set; }
    }

    public class ResultadoGestion
    {
        public int id { get; set; }
        public string tipo { get; set; }
        public string fecha { get; set; }
        public string contenido { get; set; }
    }

    public class Ambito
    {
        public int id { get; set; }
        public string valor { get; set; }
    }

    public class GestionRetiene
    {
        public int IdRetencion { get; set; }
        public string Fecha { get; set; }
        public string Etapa { get; set; }
        public string Observaciones { get; set; }
    }

    public class GestionProspecto
    {
        public int IdProspeccion { get; set; }
        public string Fecha { get; set; }
        public string Etapa { get; set; }
        public string Observaciones { get; set; }
    }
}
