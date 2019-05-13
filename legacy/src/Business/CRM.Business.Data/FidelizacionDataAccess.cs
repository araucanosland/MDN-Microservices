using System;
using System.Collections.Generic;
using System.Data;
using CRM.Business.Entity;
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

namespace CRM.Business.Data
{
    /// <summary>
    /// Clase Acceso de Datos FidelizacionDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>02-04-2018 13:08:00</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class FidelizacionDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="FidelizacionEntity"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 13:08:00</created>
        /// <param name="fidelizacion">Referencia a una clase <see cref="FidelizacionEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(FidelizacionEntity fidelizacion)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@fide_id", fidelizacion.fide_id),
                new Parametro("@fide_estamento", fidelizacion.fide_estamento),
                new Parametro("@fide_actividad", fidelizacion.fide_actividad),
                new Parametro("@fide_cobertura", fidelizacion.fide_cobertura),
                new Parametro("@fide_fecha_calendario", fidelizacion.fide_fecha_calendario),
                new Parametro("@fide_fecha_accion", fidelizacion.fide_fecha_accion),
                new Parametro("@representante_id", fidelizacion.representante_id),
                new Parametro("@cod_oficina", fidelizacion.cod_oficina),
                new Parametro("@rut_ejecutivo", fidelizacion.rut_ejecutivo),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("empresas.spEmp_Fidelizacion_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="FidelizacionEntity"/> de la Base de Datos dado un ID de FidelizacionEntity
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 13:08:00</created>
        /// <param name="fide_id">ID de FidelizacionEntity.</param>
        /// <returns>Referencia a una clase <see cref="FidelizacionEntity"/>.</returns>
        public static FidelizacionEntity ObtenerPorID(int fide_id)
        {
            Parametro parametro = new Parametro("@fide_id", fide_id);

            return DBHelper.InstanceCRM.ObtenerEntidad("empresas.spEmp_Fidelizacion_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="FidelizacionEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 13:08:00</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("empresas.spEmp_Fidelizacion_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="FidelizacionEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 13:08:00</created>
        /// <returns>Lista con todas las entidades <see cref="FidelizacionEntity"/>.</returns>
        public static List<FidelizacionEntity> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("empresas.spEmp_Fidelizacion_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static FidelizacionEntity ConstructorEntidad(DataRow row)
        {
            return new FidelizacionEntity
            {
                fide_id = row["fide_id"] != DBNull.Value ? Convert.ToInt32(row["fide_id"]) : 0,
                fide_estamento = row["fide_estamento"] != DBNull.Value ? row["fide_estamento"].ToString() : string.Empty,
                fide_actividad = row["fide_actividad"] != DBNull.Value ? row["fide_actividad"].ToString() : string.Empty,
                fide_cobertura = row["fide_cobertura"] != DBNull.Value ? row["fide_cobertura"].ToString() : string.Empty,
                fide_fecha_calendario = row["fide_fecha_calendario"] != DBNull.Value ? Convert.ToDateTime(row["fide_fecha_calendario"]) : new DateTime(1900, 1, 1),
                fide_fecha_accion = row["fide_fecha_accion"] != DBNull.Value ? Convert.ToDateTime(row["fide_fecha_accion"]) : new DateTime(1900, 1, 1),
                representante_id = row["representante_id"] != DBNull.Value ? Convert.ToInt32(row["representante_id"]) : 0,
                cod_oficina = row["cod_oficina"] != DBNull.Value ? Convert.ToInt32(row["cod_oficina"]) : 0,
                rut_ejecutivo = row["rut_ejecutivo"] != DBNull.Value ? row["rut_ejecutivo"].ToString() : string.Empty,

            };
        }
        #endregion
    }
}
