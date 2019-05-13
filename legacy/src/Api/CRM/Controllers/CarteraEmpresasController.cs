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

    [Route("api/CarteraEmpresas")]
    [ApiController]
    public class CarteraEmpresasController : ControllerBase
    {
        // GET: CarteraEmpresas
        [AuthorizationRequired] 
        [HttpGet]
        [Route("obtener-nombre")]
        public CarteraEmpresaEntity ObtEmpresaNombres(string RutEmpresa)
        {
            return CarteraEmpresaDataAccess.ObtenerDatoEmpresa(RutEmpresa);
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-ejecutivo-cargo")]
        public List<EjecutivoCarteraEntity> ListarEjecutivoCargo(int CodTipo)
        {
            string token = Request.Headers["Token"].ToString();
            return CarteraEmpresaDataAccess.ListarEjecutivoCargo(token, CodTipo);
        }
        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-ejecutivo-admin")]
        public List<EjecutivoCarteraEntity> ListarEjecutivoAdmin()
        {
            string token = Request.Headers["Token"].ToString();
            return CarteraEmpresaDataAccess.ListarEjecutivoAdmin(token);
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-empresa-ejecutivo")]
        public IEnumerable<CarteraEmpresaEntity> ListarEmpresaEjecutivo()
        {
            string token = Request.Headers["Token"].ToString();
            return CarteraEmpresaDataAccess.ListaEmpresaEjecutivo(token);
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-empresa-total")]
        public BootstrapTableResult<CarteraEmpresaTotal> ListarEmpresaEjecutivoTotal(int offset, int limit, string search = "")
        {
            string token = Request.Headers["Token"].ToString();
            var resultado = new BootstrapTableResult<CarteraEmpresaTotal>();
            resultado.rows = CarteraEmpresaDataAccess.ListarEmpresaTotal(limit, offset, search,token);
            resultado.total = CarteraEmpresaDataAccess.CountEmpresaTotal(search,token);
            
            return resultado;
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("guardar-cartera-empresa")]
        public ResultadoBase GuardarCartera(WebCarteraEmpresa entrada)
        {

            try
            {
                string token = Request.Headers["Token"].ToString();
                IngresoCarteraEmpresa ing = new IngresoCarteraEmpresa();

                ing.CodIngresoEmpresa = entrada.webCodIngreso;
                ing.RutEmpresa = entrada.webRutEmpresa.Replace(".", "");
                ing.NombreEmpresa = entrada.webNombreEmpresa;
                ing.TipoEjectEmpresa = entrada.webTipoEjecutivo;
                ing.RutEjecutivo = entrada.webRutEjecutivo.Replace(".", "");
                ing.NombreEjecutivo = entrada.webNombreEjecutivo;
                

                IngresoCarteraEmpresaDataAccess.Guardar(ing, token);
                return new ResultadoBase() { Estado = "OK", Mensaje = "Ingreso Correcto", Objeto = entrada };
            }
            catch (Exception ex)
            {
                return new ResultadoBase() { Estado = "ERR", Mensaje = "Error en el ingreso: " + ex.Message, Objeto = ex };
            }
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("cartera-data")]
        public IngresoCarteraEmpresa DatoCarteraEmpresa(int codIngreso)
        {
            string token = Request.Headers["Token"].ToString();
            return IngresoCarteraEmpresaDataAccess.ObtenerPorID(codIngreso);
            
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("eliminar-cartera-empresa")]
        public ResultadoBase EliminarCarteraEmpresa(int CodIngreso)
        {
            try
            {
                IngresoCarteraEmpresaDataAccess.Eliminar(CodIngreso);
                return new ResultadoBase() { Estado = "OK", Mensaje = "Registro Eliminado con éxito", Objeto = CodIngreso };
            }
            catch (Exception ex)
            {
                return new ResultadoBase() { Estado = "ERR", Mensaje = "Error al eliminar " + ex.Message, Objeto = ex };
            }
        }

        ///Admin
        [AuthorizationRequired]
        [HttpGet]
        [Route("listar-empresa-admin")]
        public IEnumerable<CarteraEmpresaAdmin> ListarEmpresaAdmin()
        {
            string token = Request.Headers["Token"].ToString();
            return CarteraEmpresaDataAccess.ListarEmpresaAdmin(token);
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("guardar-cartera-empresa-admin")]
        public ResultadoBase GuardarCarteraAdmin([FromBody] IngresoCarteraEmpresaAdmin entrada)
        {
            try
            {
                string token = Request.Headers["Token"].ToString();
                long id = IngresoCarteraEmpresaAdminDataAccess.Guardar(entrada, token);

                foreach (var item in entrada.EjecAsignado)
                {
                    IngresoCarteraEmpresaAdminDataAccess.GuardarAsignacion(item, id);
                } 
                return new ResultadoBase() { Estado = "OK", Mensaje = "Ingreso Correcto", Objeto = entrada };
            }
            catch (Exception ex)
            {
                return new ResultadoBase() { Estado = "ERR", Mensaje = "Error en el ingreso: " + ex.Message, Objeto = ex };
            }
        }

        [AuthorizationRequired]
        [HttpGet]
        [Route("eliminar-cartera-empresa-admin")]
        public ResultadoBase EliminarCarteraEmpresaAdmin(int CodIngreso)
        {
            try
            {
                IngresoCarteraEmpresaAdminDataAccess.Eliminar(CodIngreso);
                return new ResultadoBase() { Estado = "OK", Mensaje = "Registro Eliminado con éxito", Objeto = CodIngreso };
            }
            catch (Exception ex)
            {
                return new ResultadoBase() { Estado = "ERR", Mensaje = "Error al eliminar " + ex.Message, Objeto = ex };
            }
        }
        [AuthorizationRequired]
        [HttpGet]
        [Route("actualiza-validacion")]
        public ResultadoBase ActualizaValidacion(int CodIngreso)
        {
            try
            {
                IngresoCarteraEmpresaAdminDataAccess.Actualizar(CodIngreso);
                return new ResultadoBase() { Estado = "OK", Mensaje = "Registro Actualizado con éxito", Objeto = CodIngreso };
            }
            catch (Exception ex)
            {
                return new ResultadoBase() { Estado = "ERR", Mensaje = "Error al Actualizar " + ex.Message, Objeto = ex };
            }
        }


        [AuthorizationRequired]
        [HttpGet]
        [Route("cartera-data-admin")]
        public IngresoCarteraEmpresaAdmin DatoCarteraEmpresaAdmin(int codIngreso)
        {
            string token = Request.Headers["Token"].ToString();
            return IngresoCarteraEmpresaAdminDataAccess.ObtenerPorID(codIngreso);

        }


        /*Nuevos metodos para Empresas
         *
         */



        [AuthorizationRequired]
        [HttpGet]
        [Route("buscar-empresa")]
        public IActionResult BuscarEmpresa(string query)
        {
            string token = Request.Headers["Token"].ToString();

            return Ok(CarteraEmpresaDataAccess.ObtenerEmpresaPorNombreRutOHolding(query));
            
        }

    }
}