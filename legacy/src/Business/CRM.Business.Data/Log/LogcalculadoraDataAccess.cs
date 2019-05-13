using System;
using System.Collections.Generic;
using System.Data;
using CRM.Business.Entity.Log;
using CDK.Integration;
using CDK.Data;

//------------------------------------------------------------------------------
// <generado automáticamente>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </generado automáticamente>
//------------------------------------------------------------------------------

namespace CRM.Business.Data.Log
{
    /// <summary>
    /// Clase Acceso de Datos LogcalculadoraDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>19-04-2018 12:56:12</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class LogcalculadoraDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="LogcalculadoraEntity"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>19-04-2018 12:56:12</created>
        /// <param name="logcalculadora">Referencia a una clase <see cref="LogcalculadoraEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(LogcalculadoraEntity logcalculadora)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@lgc_id", logcalculadora.lgc_id),
                new Parametro("@fecha_accion", logcalculadora.fecha_accion),
                new Parametro("@ejecutivo", logcalculadora.ejecutivo),
                new Parametro("@oficina", logcalculadora.oficina),
                new Parametro("@rut_afiliado", logcalculadora.rut_afiliado),
                new Parametro("@renta_depurada_crm", logcalculadora.renta_depurada_crm),
                new Parametro("@descuento_legal", logcalculadora.descuento_legal),
                new Parametro("@procentaje_descuento", logcalculadora.procentaje_descuento),
                new Parametro("@total_descuentos_liquidacion", logcalculadora.total_descuentos_liquidacion),
                new Parametro("@descuentos_legales_primer_mes", logcalculadora.descuentos_legales_primer_mes),
                new Parametro("@descuentos_legales_segundo_mes", logcalculadora.descuentos_legales_segundo_mes),
                new Parametro("@descuentos_legales_tercer_mes", logcalculadora.descuentos_legales_tercer_mes),
                new Parametro("@descuentos_legales_promedio", logcalculadora.descuentos_legales_promedio),
                new Parametro("@tiene_descuentos_planilla", logcalculadora.tiene_descuentos_planilla),
                new Parametro("@descuentos_creditos_planilla", logcalculadora.descuentos_creditos_planilla),
                new Parametro("@cuota_maxima_descontar_caja", logcalculadora.cuota_maxima_descontar_caja),
                new Parametro("@rut_empresa", logcalculadora.rut_empresa),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("dbo.spLog_Logcalculadora_Guardar", parametros);
        }



        public static LogRolVerificadorEntity GuardarRolVerificador(LogRolVerificadorEntity logcalculadora)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@Id", logcalculadora.Id),
                new Parametro("@RutEjecutivo", logcalculadora.RutEjecutivo),
                new Parametro("@CodSucursal", logcalculadora.CodSucursal),
                new Parametro("@RutAfiliado", logcalculadora.RutAfiliado),
                new Parametro("@Anexo", logcalculadora.Anexo),
                new Parametro("@RutEmpresa", logcalculadora.RutEmpresa),
                new Parametro("@NombreEmpresa", logcalculadora.NombreEmpresa),
                new Parametro("@Cotiza", logcalculadora.Cotiza),
                new Parametro("@Grado", logcalculadora.Grado),
                new Parametro("@SeguroCesantia", logcalculadora.SeguroCesantia),
                new Parametro("@ProEmpleo", logcalculadora.ProEmpleo),
                new Parametro("@LeyEspecifica", logcalculadora.LeyEspecifica),
                new Parametro("@LeyEspecifica2", logcalculadora.LeyEspecifica2),

                new Parametro("@TotalHaberes", logcalculadora.TotalHaberes),
                new Parametro("@BonosExtras", logcalculadora.BonosExtras),
                new Parametro("@DescuentoLegalMes1", logcalculadora.DescuentoLegalMes1),
                new Parametro("@DescuentoLegalMes2", logcalculadora.DescuentoLegalMes2),
                new Parametro("@DescuentoLegalMes3", logcalculadora.DescuentoLegalMes3),
                new Parametro("@Promedio", logcalculadora.Promedio),
                new Parametro("@RentaDepurada", logcalculadora.RentaDepurada),
                new Parametro("@RentaDepuradaCMR", logcalculadora.RentaDepuradaCMR),
                new Parametro("@TotalDescuento", logcalculadora.TotalDescuento),
                new Parametro("@OtrosDescuentos", logcalculadora.OtrosDescuentos),
                new Parametro("@ValorCuotaCredito", logcalculadora.ValorCuotaCredito),
                new Parametro("@ValorCuotaCreditoComp", logcalculadora.ValorCuotaCreditoComp),
                new Parametro("@Resultado1", logcalculadora.Resultado1),
                new Parametro("@Resultado2", logcalculadora.Resultado2),

            };

            return DBHelper.InstanceCRM.ObtenerEntidad("dbo.spLog_LogRolVerificador_Guardar", parametros, EntidadRolVerficador);
          
        }


        private static LogRolVerificadorEntity EntidadRolVerficador(DataRow row)
        {
            return new LogRolVerificadorEntity
            {
                Id = row["Id"] != DBNull.Value ? row["Id"].ToString() : string.Empty,

            };
        }



        /// <summary>
        /// Recupera una entidad <see cref="LogcalculadoraEntity"/> de la Base de Datos dado un ID de LogcalculadoraEntity
        /// </summary>
        /// <author>@Charly</author>
        /// <created>19-04-2018 12:56:12</created>
        /// <param name="lgc_id">ID de LogcalculadoraEntity.</param>
        /// <returns>Referencia a una clase <see cref="LogcalculadoraEntity"/>.</returns>
        public static LogcalculadoraEntity ObtenerPorID(int lgc_id)
        {
            Parametro parametro = new Parametro("@lgc_id", lgc_id);

            return DBHelper.InstanceCRM.ObtenerEntidad("dbo.spLog_Logcalculadora_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="LogcalculadoraEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>19-04-2018 12:56:12</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("dbo.spLog_Logcalculadora_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="LogcalculadoraEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>19-04-2018 12:56:12</created>
        /// <returns>Lista con todas las entidades <see cref="LogcalculadoraEntity"/>.</returns>
        public static List<LogcalculadoraEntity> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("dbo.spLog_Logcalculadora_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales



        /// <summary>
        /// Recupera todas las entidades <see cref="LogcalculadoraEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>19-04-2018 12:56:12</created>
        /// <returns>Lista con todas las entidades <see cref="LogcalculadoraEntity"/>.</returns>
        public static int ObtenerEmpresas15porc(string rut_empresa)
        {
            return DBHelper.InstanceCRM.ObtenerEntidad("dbo.spMotor_EmpresasPublicas15porc", new Parametro("@emp_rut", rut_empresa), RenderExiste);
        }
        #endregion

        #region constructor
        private static int RenderExiste(DataRow row)
        {
            int retorno = row["Existe"] != DBNull.Value ? Convert.ToInt32(row["Existe"]) : 0;
            return retorno;
        }


        private static LogcalculadoraEntity ConstructorEntidad(DataRow row)
        {
            return new LogcalculadoraEntity
            {
                lgc_id = row["lgc_id"] != DBNull.Value ? Convert.ToInt32(row["lgc_id"]) : 0,
                fecha_accion = row["fecha_accion"] != DBNull.Value ? Convert.ToDateTime(row["fecha_accion"]) : new DateTime(1900, 1, 1),
                ejecutivo = row["ejecutivo"] != DBNull.Value ? row["ejecutivo"].ToString() : string.Empty,
                oficina = row["oficina"] != DBNull.Value ? Convert.ToInt32(row["oficina"]) : 0,
                rut_afiliado = row["rut_afiliado"] != DBNull.Value ? row["rut_afiliado"].ToString() : string.Empty,
                renta_depurada_crm = row["renta_depurada_crm"] != DBNull.Value ? Convert.ToInt64(row["renta_depurada_crm"]) : 0,
                descuento_legal = row["descuento_legal"] != DBNull.Value ? Convert.ToInt64(row["descuento_legal"]) : 0,
                procentaje_descuento = row["procentaje_descuento"] != DBNull.Value ? Convert.ToInt64(row["procentaje_descuento"]) : 0,
                total_descuentos_liquidacion = row["total_descuentos_liquidacion"] != DBNull.Value ? Convert.ToInt64(row["total_descuentos_liquidacion"]) : 0,
                descuentos_legales_primer_mes = row["descuentos_legales_primer_mes"] != DBNull.Value ? Convert.ToInt64(row["descuentos_legales_primer_mes"]) : 0,
                descuentos_legales_segundo_mes = row["descuentos_legales_segundo_mes"] != DBNull.Value ? Convert.ToInt64(row["descuentos_legales_segundo_mes"]) : 0,
                descuentos_legales_tercer_mes = row["descuentos_legales_tercer_mes"] != DBNull.Value ? Convert.ToInt64(row["descuentos_legales_tercer_mes"]) : 0,
                descuentos_legales_promedio = row["descuentos_legales_promedio"] != DBNull.Value ? Convert.ToInt64(row["descuentos_legales_promedio"]) : 0,
                tiene_descuentos_planilla = row["tiene_descuentos_planilla"] != DBNull.Value ? row["tiene_descuentos_planilla"].ToString() : string.Empty,
                descuentos_creditos_planilla = row["descuentos_creditos_planilla"] != DBNull.Value ? Convert.ToInt64(row["descuentos_creditos_planilla"]) : 0,
                cuota_maxima_descontar_caja = row["cuota_maxima_descontar_caja"] != DBNull.Value ? Convert.ToInt64(row["cuota_maxima_descontar_caja"]) : 0,
                rut_empresa = row["rut_empresa"] != DBNull.Value ? row["rut_empresa"].ToString() : string.Empty,

            };
        }



        public static EmpresaRolVerificadorEntity ObtieneEmpresaRol(int IdAnexo)
        {
            Parametro parametro = new Parametro("@IdAnexo", IdAnexo);

            return DBHelper.InstanceCRM.ObtenerEntidad("dbo.spMotor_Lista_Rol_Empresa", parametro, EntidadRolEmpresas);
        }

        private static EmpresaRolVerificadorEntity EntidadRolEmpresas(DataRow row)
        {
            return new EmpresaRolVerificadorEntity
            {
                IdAnexo = row["IdAnexo"] != DBNull.Value ? Convert.ToInt32(row["IdAnexo"]) : 0,
                RutEmpresa = row["RutEmpresa"] != DBNull.Value ? row["RutEmpresa"].ToString() : string.Empty,
                NombreEmpresa = row["NombreEmpresa"] != DBNull.Value ? row["NombreEmpresa"].ToString() : string.Empty,
            };
        }


        #endregion
    }
}
