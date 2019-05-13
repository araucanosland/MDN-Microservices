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
    /// Clase Acceso de Datos AreasDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>02-04-2018 13:01:18</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class AreasDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="AreasEntity"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 13:01:18</created>
        /// <param name="areas">Referencia a una clase <see cref="AreasEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(AreasEntity areas)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@area_id", areas.area_id),
                new Parametro("@area_nombre", areas.area_nombre),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("empresas.spEmp_Areas_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="AreasEntity"/> de la Base de Datos dado un ID de AreasEntity
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 13:01:18</created>
        /// <param name="area_id">ID de AreasEntity.</param>
        /// <returns>Referencia a una clase <see cref="AreasEntity"/>.</returns>
        public static AreasEntity ObtenerPorID(int area_id)
        {
            Parametro parametro = new Parametro("@area_id", area_id);

            return DBHelper.InstanceCRM.ObtenerEntidad("empresas.spEmp_Areas_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="AreasEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 13:01:18</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("empresas.spEmp_Areas_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="AreasEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 13:01:18</created>
        /// <returns>Lista con todas las entidades <see cref="AreasEntity"/>.</returns>
        public static List<AreasEntity> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("empresas.spEmp_Areas_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static AreasEntity ConstructorEntidad(DataRow row)
        {
            return new AreasEntity
            {
                area_id = row["area_id"] != DBNull.Value ? Convert.ToInt32(row["area_id"]) : 0,
                area_nombre = row["area_nombre"] != DBNull.Value ? row["area_nombre"].ToString() : string.Empty,

            };
        }
        #endregion
    }
}
