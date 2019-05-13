using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using CRM.Business.Data;
using CRM.Business.Data.ContactabilidadDataAccess;
using CRM.Business.Entity;
using CRM.Business.Entity.Contactibilidad;
using CRM.Business.Entity.Clases;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/stage/call-center")]
    [ApiController]
    public class CallCenterController : ControllerBase
    {
        [HttpGet]
        [Route("afiliado-search/{AfiliadoRut}")]
        public AsignacionCallBase AfiliadoServiceData(string AfiliadoRut)
        {
            int periodo = Convert.ToInt32(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2,'0'));
            var AsgDataBrut = AsignacionDataAccess.ListarByAfiRut(periodo, AfiliadoRut).Where(asg => asg.TipoAsignacion == 5 || asg.TipoAsignacion == 1).FirstOrDefault();
            //List<ContactoafiliadoEntity> telefonos = ContactoafiliadoDataAccess.ObtenerPorRutAfiliadoYTipo(Convert.ToInt32(AsgDataBrut.Afiliado_Rut), "TELEFONO");
            //telefonos.AddRange(ContactoafiliadoDataAccess.ObtenerPorRutAfiliadoYTipo(Convert.ToInt32(AsgDataBrut.Afiliado_Rut), "CELULAR"));
            var gestiones = GestionDataAccess.ListarGestion(AsgDataBrut.id_Asign).OrderByDescending(ord => ord.FechaAccion).ToList();

            List<ContactabilidadEntity> telefonos = ContactabilidadDataAccess.ListarContacto(Convert.ToInt32(AsgDataBrut.Afiliado_Rut)).Where(cnt => cnt.iTipoDato == 1 || cnt.iTipoDato == 2).ToList();


            return new AsignacionCallBase
            {
                Asignacion = AsgDataBrut.id_Asign,
                Afiliado = new AfiliadoCallBase
                {
                    Rut = AsgDataBrut.Afiliado_Rut + "-" + AsgDataBrut.Afiliado_Dv,
                    Nombres = AsgDataBrut.Nombre + " " + AsgDataBrut.Apellido,
                    Segmento = AsgDataBrut.Segmento,
                    ClaveRut = AsgDataBrut.Afiliado_Rut.ToString()
                },
                Empresa = new EmpresaCallBase
                {
                    Rut = AsgDataBrut.Empresa_Rut + "-" + AsgDataBrut.Empresa_Dv,
                    RazonSocial = AsgDataBrut.Empresa
                },
                OficinaAsinacion = SucursalDataAccess.ObtenerSucursal(AsgDataBrut.Oficina).Nombre,
                PreAprobado = AsgDataBrut.PreAprobadoFinal,
                Fonos = telefonos,
                Gestiones = gestiones
            };
        }

        [HttpGet]
        [Route("estados")]
        public IEnumerable<EstadoCallBase> EstadosServiceData()
        {
            List<EstadoCallBase> retorno = new List<EstadoCallBase>();
            
            List<EstadogestionEntity> dataList = EstadosyTiposDataAccess.ListarEstadosGestion();
            dataList.Where(x => x.ejes_id_padre == 0 && x.ejes_tipo_campagna == 5).ToList().ForEach(eg => {
                EstadoCallBase ecb = new EstadoCallBase
                {
                    EstadoId = eg.eges_id,
                    Nombre = eg.eges_nombre,
                    Hijos = ListarHijos(eg.eges_id)
                };
                retorno.Add(ecb);
            });
            
            return retorno;
        }

        private List<EstadoCallBase> ListarHijos(int idPadre)
        {
            List<EstadoCallBase> retorno = new List<EstadoCallBase>();
            List<EstadogestionEntity> dataList = EstadosyTiposDataAccess.ListarEstadosGestion();

            if (idPadre != 70)
            {
                dataList.Where(x => x.ejes_id_padre == idPadre && x.ejes_tipo_campagna == 5).ToList().ForEach(eg =>
                {
                    EstadoCallBase ecb = new EstadoCallBase
                    {
                        EstadoId = eg.eges_id,
                        Nombre = eg.eges_nombre
                    };
                    retorno.Add(ecb);
                });
            }
            else
            {
                SucursalDataAccess.ListarSucursales().Where(d=>d.Id!=0).ToList().ForEach(s => {
                    EstadoCallBase ecb = new EstadoCallBase
                    {
                        EstadoId = s.Id,
                        Nombre = s.Nombre
                    };
                    retorno.Add(ecb);
                });
            }

            return retorno;
        }

        [HttpGet]
        [Route("oficinas")]
        public IEnumerable<OficinaCallBase> OficinasServiceData()
        {
            List<OficinaCallBase> retorno = new List<OficinaCallBase>();

            SucursalDataAccess.ListarSucursales().Where(d => d.Id != 0).ToList().ForEach(s => {
                OficinaCallBase ecb = new OficinaCallBase
                {
                    Id = s.Id,
                    Nombre = s.Nombre
                };
                retorno.Add(ecb);
            });


            return retorno;
        }

        [HttpOptions, HttpPost]
        [Route("registrar-gestion")]
        public ResultadoBase GuardarGestionService(WebGestionCall entrada)
        {
            string prefijo_numero = "56";
            if (entrada == null)
            {
                return new ResultadoBase
                {
                    Estado = "ESPERA",
                    Mensaje = "RECONOCIENDO SERVER",
                    Objeto = entrada
                };
            }
            else
            {
                GestionEntity oSv = new GestionEntity();
                oSv.IdBaseCampagna = entrada.Asignacion;
                oSv.IdEstado = 701;
                oSv.IdOficina = "555";
                oSv.Descripcion = entrada.Comentarios;
                oSv.FechaAccion = DateTime.Now;
                oSv.FechaCompromete = entrada.FechaProxGestion != null && entrada.FechaProxGestion != "" ? Convert.ToDateTime(entrada.FechaProxGestion) : Convert.ToDateTime("1/1/1753 12:00:00");
                oSv.RutEjecutivo = entrada.RutEjecutivo;
                GestionDataAccess.Guardar(oSv);
                AsignacionDataAccess.AsignarOficina(entrada.Asignacion, entrada.Oficina);


                AsignacionEntity asg = AsignacionDataAccess.ObtenerPorID(entrada.Asignacion);
                PreferenciaAfiliadoEntity pa = new PreferenciaAfiliadoEntity()
                {
                    Afiliado_rut = (int)asg.Afiliado_Rut,
                    Fecha_accion = DateTime.Now,
                    Tipo_preferencia = "HORARIO",
                    Valida = true,
                    Valor_preferencia = entrada.HorarioPreferencia
                };

                PreferenciaAfiliadoDataAccess.Guardar(pa);

                if(entrada.FonoContact != "OTR")
                {
                    ContactabilidadDataAccess.ActualizarIndiceContacto(1, Convert.ToInt32(entrada.RutAfiliado), entrada.FonoContact.Replace("+", string.Empty), entrada.RutEjecutivo, 555);
                }
                else
                {
                    //si no se valida dispara exception
                    int validaFono = Convert.ToInt32(entrada.NuevoFono);

                    string datocontacto = prefijo_numero + entrada.NuevoFono;
                    var existe = ContactabilidadDataAccess.ListarContacto(Convert.ToInt32(entrada.RutAfiliado)).FirstOrDefault(contc => contc.ValorDato == datocontacto);

                    if(existe != null)
                    {
                        throw new Exception("El dato de contacto ya existe en la base de datos.");
                    }
                    else
                    {
                        ContactabilidadDataAccess.InsertaNuevoContacto(Convert.ToInt32(entrada.RutAfiliado), 1, "Celular", 1, "Personal", datocontacto);
                        ContactabilidadDataAccess.ActualizarIndiceContacto(1, Convert.ToInt32(entrada.RutAfiliado), datocontacto, entrada.RutEjecutivo, 555);
                    }

                    
                }
                    
                return new ResultadoBase
                {
                    Estado = "OK",
                    Mensaje = "Guardado con Exito",
                    Objeto = entrada
                };
                
            }
            
        }

    }
}
