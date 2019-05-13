using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CDK.Data;
using CDK.Integration;
using CRM.Security.Entity;


namespace CRM.Security.Data
{
    /// <summary>
    /// Clase Acceso de Datos PermisosDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>12-09-2017 15:59:19</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class PermisosDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="Permisos"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>12-09-2017 15:59:19</created>
        /// <param name="permisos">Referencia a una clase <see cref="Permisos"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(Permisos permisos)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@CodPermiso", permisos.CodPermiso),
                new Parametro("@CodRecurso", permisos.CodRecurso),
                new Parametro("@CodRol", permisos.CodRol),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("sp_Sca_Permisos_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="Permisos"/> de la Base de Datos dado un ID de Permisos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>12-09-2017 15:59:19</created>
        /// <param name="CodPermiso">ID de Permisos.</param>
        /// <returns>Referencia a una clase <see cref="Permisos"/>.</returns>
        public static Permisos ObtenerPorID(int CodPermiso)
        {
            Parametro parametro = new Parametro("@CodPermiso", CodPermiso);

            return DBHelper.InstanceCRM.ObtenerEntidad("security.sp_Sca_Permisos_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="Permisos"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>12-09-2017 15:59:19</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("security.sp_Sca_Permisos_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="Permisos"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>12-09-2017 15:59:19</created>
        /// <returns>Lista con todas las entidades <see cref="Permisos"/>.</returns>
        public static List<Permisos> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("security.sp_Sca_Permisos_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static Permisos ConstructorEntidad(DataRow row)
        {
            return new Permisos
            {
                CodPermiso = row["CodPermiso"] != DBNull.Value ? Convert.ToInt32(row["CodPermiso"]) : 0,
                CodRecurso = row["CodRecurso"] != DBNull.Value ? Convert.ToInt32(row["CodRecurso"]) : 0,
                CodRol = row["CodRol"] != DBNull.Value ? Convert.ToInt32(row["CodRol"]) : 0,

            };
        }
        #endregion
    }
}
