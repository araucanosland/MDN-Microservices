using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Security.Entity;
using System.Data;
using CDK.Data;
using CDK.Integration;

namespace CRM.Security.Data
{
    /// <summary>
    /// Clase Acceso de Datos RolDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>12-09-2017 15:49:32</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class RolDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="Rol"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>12-09-2017 15:49:32</created>
        /// <param name="rol">Referencia a una clase <see cref="Rol"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(Rol rol)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@CodRol", rol.CodRol),
                new Parametro("@Nombre", rol.Nombre),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("sp_Rol_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="Rol"/> de la Base de Datos dado un ID de Rol
        /// </summary>
        /// <author>@Charly</author>
        /// <created>12-09-2017 15:49:32</created>
        /// <param name="CodRol">ID de Rol.</param>
        /// <returns>Referencia a una clase <see cref="Rol"/>.</returns>
        public static Rol ObtenerPorID(int CodRol)
        {
            Parametro parametro = new Parametro("@CodRol", CodRol);

            return DBHelper.InstanceCRM.ObtenerEntidad("sp_Rol_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="Rol"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>12-09-2017 15:49:32</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("sp_Rol_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="Rol"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>12-09-2017 15:49:32</created>
        /// <returns>Lista con todas las entidades <see cref="Rol"/>.</returns>
        public static List<Rol> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("sp_Rol_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static Rol ConstructorEntidad(DataRow row)
        {
            return new Rol
            {
                CodRol = row["CodRol"] != DBNull.Value ? Convert.ToInt32(row["CodRol"]) : 0,
                Nombre = row["Nombre"] != DBNull.Value ? row["Nombre"].ToString() : string.Empty,

            };
        }
        #endregion
    }
}
