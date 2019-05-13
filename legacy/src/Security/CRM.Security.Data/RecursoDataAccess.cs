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
    /// Clase Acceso de Datos RecursoDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>12-09-2017 18:08:09</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class RecursoDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="Recurso"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>12-09-2017 18:08:09</created>
        /// <param name="recurso">Referencia a una clase <see cref="Recurso"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(Recurso recurso)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@CodRecurso", recurso.CodRecurso),
                new Parametro("@Nombre", recurso.Nombre),
                new Parametro("@Descripcion", recurso.Descripcion),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("security.sp_Recurso_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="Recurso"/> de la Base de Datos dado un ID de Recurso
        /// </summary>
        /// <author>@Charly</author>
        /// <created>12-09-2017 18:08:09</created>
        /// <param name="CodRecurso">ID de Recurso.</param>
        /// <returns>Referencia a una clase <see cref="Recurso"/>.</returns>
        public static Recurso ObtenerPorID(int CodRecurso)
        {
            Parametro parametro = new Parametro("@CodRecurso", CodRecurso);

            return DBHelper.InstanceCRM.ObtenerEntidad("security.sp_Recurso_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="Recurso"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>12-09-2017 18:08:09</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("security.sp_Recurso_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="Recurso"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>12-09-2017 18:08:09</created>
        /// <returns>Lista con todas las entidades <see cref="Recurso"/>.</returns>
        public static List<Recurso> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("security.sp_Recurso_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static Recurso ConstructorEntidad(DataRow row)
        {
            return new Recurso
            {
                CodRecurso = row["CodRecurso"] != DBNull.Value ? Convert.ToInt32(row["CodRecurso"]) : 0,
                Nombre = row["Nombre"] != DBNull.Value ? row["Nombre"].ToString() : string.Empty,
                Descripcion = row["Descripcion"] != DBNull.Value ? row["Descripcion"].ToString() : string.Empty,

            };
        }
        #endregion
    }
}
