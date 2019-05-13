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
    // <summary>
    /// Clase Acceso de Datos PermisodetalleDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>12-09-2017 15:54:35</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class PermisodetalleDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="Permisodetalle"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>12-09-2017 15:54:35</created>
        /// <param name="permisodetalle">Referencia a una clase <see cref="Permisodetalle"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(PermisoDetalle permisodetalle)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@CodPerDetalle", permisodetalle.CodPerDetalle),
                new Parametro("@CodPermiso", permisodetalle.CodPermiso),
                new Parametro("@Controlador", permisodetalle.Controlador),
                new Parametro("@Accion", permisodetalle.Accion),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("security.sp_Permisodetalle_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="Permisodetalle"/> de la Base de Datos dado un ID de Permisodetalle
        /// </summary>
        /// <author>@Charly</author>
        /// <created>12-09-2017 15:54:35</created>
        /// <param name="CodPerDetalle">ID de Permisodetalle.</param>
        /// <returns>Referencia a una clase <see cref="Permisodetalle"/>.</returns>
        public static PermisoDetalle ObtenerPorID(int CodPerDetalle)
        {
            Parametro parametro = new Parametro("@CodPerDetalle", CodPerDetalle);

            return DBHelper.InstanceCRM.ObtenerEntidad("security.sp_Permisodetalle_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="Permisodetalle"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>12-09-2017 15:54:35</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("security.sp_Permisodetalle_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="Permisodetalle"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>12-09-2017 15:54:35</created>
        /// <returns>Lista con todas las entidades <see cref="Permisodetalle"/>.</returns>
        public static List<PermisoDetalle> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("security.sp_Permisodetalle_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        /// <summary>
        /// Recupera una entidad <see cref="Permisodetalle"/> de la Base de Datos dado un ID de Permisodetalle
        /// </summary>
        /// <author>@Charly</author>
        /// <created>12-09-2017 15:54:35</created>
        /// <param name="CodPerDetalle">ID de Permisodetalle.</param>
        /// <returns>Referencia a una clase <see cref="Permisodetalle"/>.</returns>
        public static bool VerificarPermiso(string Token, string Controlador, string Accion)
        {
            Parametros parametros = new Parametros() {
                new Parametro("@Token", Token),
                new Parametro("@Controlador", Controlador),
                new Parametro("@Accion", Accion),
            };
            PermisoDetalle pdt = DBHelper.InstanceCRM.ObtenerEntidad("security.sp_Sca_VerificarPermiso", parametros, ConstructorEntidad);
            bool retorno = false;

            if(pdt.Controlador.Equals(Controlador) && pdt.Accion.Equals(Accion))
            {
                retorno = true;
            }

            return retorno;
        }

        #endregion

        #region constructor
        private static PermisoDetalle ConstructorEntidad(DataRow row)
        {
            return new PermisoDetalle
            {
                CodPerDetalle = row["CodPerDetalle"] != DBNull.Value ? Convert.ToInt32(row["CodPerDetalle"]) : 0,
                CodPermiso = row["CodPermiso"] != DBNull.Value ? Convert.ToInt32(row["CodPermiso"]) : 0,
                Controlador = row["Controlador"] != DBNull.Value ? row["Controlador"].ToString() : string.Empty,
                Accion = row["Accion"] != DBNull.Value ? row["Accion"].ToString() : string.Empty,

            };
        }
        #endregion
    }
}
