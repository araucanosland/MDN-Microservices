using System;
using System.Collections.Generic;
using System.Data;
using CRM.Security.Entity;
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

namespace CRM.Security.Data
{
    /// <summary>
    /// Clase Acceso de Datos AsignapermisoDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>14-09-2017 11:17:41</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class AsignapermisoDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="Asignapermiso"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>14-09-2017 11:17:41</created>
        /// <param name="asignapermiso">Referencia a una clase <see cref="Asignapermiso"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(Asignapermiso asignapermiso)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@CodPermiso", asignapermiso.CodPermiso),
                new Parametro("@Grupo", asignapermiso.Grupo),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("security.sp_Sca_Asignapermiso_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="Asignapermiso"/> de la Base de Datos dado un ID de Asignapermiso
        /// </summary>
        /// <author>@Charly</author>
        /// <created>14-09-2017 11:17:41</created>
        /// <param name="CodPermiso">ID de Asignapermiso.</param>
        /// <returns>Referencia a una clase <see cref="Asignapermiso"/>.</returns>
        public static Asignapermiso ObtenerPorID(int CodPermiso)
        {
            Parametro parametro = new Parametro("@CodPermiso", CodPermiso);

            return DBHelper.InstanceCRM.ObtenerEntidad("security.sp_Sca_Asignapermiso_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="Asignapermiso"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>14-09-2017 11:17:41</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("security.sp_Sca_Asignapermiso_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="Asignapermiso"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>14-09-2017 11:17:41</created>
        /// <returns>Lista con todas las entidades <see cref="Asignapermiso"/>.</returns>
        public static List<Asignapermiso> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("security.sp_Sca_Asignapermiso_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static Asignapermiso ConstructorEntidad(DataRow row)
        {
            return new Asignapermiso
            {
                CodPermiso = row["CodPermiso"] != DBNull.Value ? Convert.ToInt32(row["CodPermiso"]) : 0,
                Grupo = row["Grupo"] != DBNull.Value ? row["Grupo"].ToString() : string.Empty,

            };
        }
        #endregion
    }
}
