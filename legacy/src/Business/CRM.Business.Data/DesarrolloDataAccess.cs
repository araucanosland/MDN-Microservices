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
    /// Clase Acceso de Datos DesarrolloDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>07-03-2018 10:31:00</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class DesarrolloDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="DesarrolloEntity"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>07-03-2018 10:31:00</created>
        /// <param name="desarrollo">Referencia a una clase <see cref="DesarrolloEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static long Guardar(DesarrolloEntity desarrollo)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@desa_id", desarrollo.desa_id),
                new Parametro("@encabezado_id", desarrollo.encabezado_id),
                new Parametro("@respuesta_id", desarrollo.respuesta_id),
                new Parametro("@texto", desarrollo.texto),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<long>("fichas.spFicha_Desarrollo_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="DesarrolloEntity"/> de la Base de Datos dado un ID de DesarrolloEntity
        /// </summary>
        /// <author>@Charly</author>
        /// <created>07-03-2018 10:31:00</created>
        /// <param name="desa_id">ID de DesarrolloEntity.</param>
        /// <returns>Referencia a una clase <see cref="DesarrolloEntity"/>.</returns>
        public static DesarrolloEntity ObtenerPorID(long desa_id)
        {
            Parametro parametro = new Parametro("@desa_id", desa_id);

            return DBHelper.InstanceCRM.ObtenerEntidad("fichas.spFicha_Desarrollo_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="DesarrolloEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>07-03-2018 10:31:00</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("fichas.spFicha_Desarrollo_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="DesarrolloEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>07-03-2018 10:31:00</created>
        /// <returns>Lista con todas las entidades <see cref="DesarrolloEntity"/>.</returns>
        public static List<DesarrolloEntity> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("fichas.spFicha_Desarrollo_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static DesarrolloEntity ConstructorEntidad(DataRow row)
        {
            return new DesarrolloEntity
            {
                desa_id = row["desa_id"] != DBNull.Value ? Convert.ToInt64(row["desa_id"]) : 0,
                encabezado_id = row["encabezado_id"] != DBNull.Value ? Convert.ToInt32(row["encabezado_id"]) : 0,
                respuesta_id = row["respuesta_id"] != DBNull.Value ? Convert.ToInt32(row["respuesta_id"]) : 0,
                texto = row["texto"] != DBNull.Value ? row["texto"].ToString() : string.Empty,

            };
        }
        #endregion
    }
}
