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
    /// Clase Acceso de Datos AmbitosareaDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>02-04-2018 12:58:21</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class AmbitosareaDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="AmbitosareaEntity"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 12:58:21</created>
        /// <param name="ambitosarea">Referencia a una clase <see cref="AmbitosareaEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(AmbitosareaEntity ambitosarea)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@ambito_id", ambitosarea.ambito_id),
                new Parametro("@ambito_nombre", ambitosarea.ambito_nombre),
                new Parametro("@area_id", ambitosarea.area_id),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("empresas.spEmp_Ambitosarea_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="AmbitosareaEntity"/> de la Base de Datos dado un ID de AmbitosareaEntity
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 12:58:21</created>
        /// <param name="ambito_id">ID de AmbitosareaEntity.</param>
        /// <returns>Referencia a una clase <see cref="AmbitosareaEntity"/>.</returns>
        public static AmbitosareaEntity ObtenerPorID(int ambito_id)
        {
            Parametro parametro = new Parametro("@ambito_id", ambito_id);

            return DBHelper.InstanceCRM.ObtenerEntidad("empresas.spEmp_Ambitosarea_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="AmbitosareaEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 12:58:21</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("empresas.spEmp_Ambitosarea_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="AmbitosareaEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 12:58:21</created>
        /// <returns>Lista con todas las entidades <see cref="AmbitosareaEntity"/>.</returns>
        public static List<AmbitosareaEntity> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("empresas.spEmp_Ambitosarea_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static AmbitosareaEntity ConstructorEntidad(DataRow row)
        {
            return new AmbitosareaEntity
            {
                ambito_id = row["ambito_id"] != DBNull.Value ? Convert.ToInt32(row["ambito_id"]) : 0,
                ambito_nombre = row["ambito_nombre"] != DBNull.Value ? row["ambito_nombre"].ToString() : string.Empty,
                area_id = row["area_id"] != DBNull.Value ? Convert.ToInt32(row["area_id"]) : 0,

            };
        }
        #endregion
    }
}
