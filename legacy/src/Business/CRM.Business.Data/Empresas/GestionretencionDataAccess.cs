using System;
using System.Collections.Generic;
using System.Data;
using CRM.Business.Entity.Empresas;
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

namespace CRM.Business.Data.Empresas
{
    /// <summary>
    /// Clase Acceso de Datos GestionretencionDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>10-04-2018 18:04:35</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class GestionretencionDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="GestionretencionEntity"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>10-04-2018 18:04:35</created>
        /// <param name="gestionretencion">Referencia a una clase <see cref="GestionretencionEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(GestionretencionEntity gestionretencion)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@gstr_id", gestionretencion.gstr_id),
                new Parametro("@gstr_fecha", gestionretencion.gstr_fecha),
                new Parametro("@gstr_etapa", gestionretencion.gstr_etapa),
                new Parametro("@gstr_observaciones", gestionretencion.gstr_observaciones),
                new Parametro("@gstr_fecha_accion", gestionretencion.gstr_fecha_accion),
                new Parametro("@retencion_id", gestionretencion.retencion_id),
                new Parametro("@ejecutivo_rut", gestionretencion.ejecutivo_rut),
                new Parametro("@oficina", gestionretencion.oficina),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("empresas.spEmp_Gestionretencion_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="GestionretencionEntity"/> de la Base de Datos dado un ID de GestionretencionEntity
        /// </summary>
        /// <author>@Charly</author>
        /// <created>10-04-2018 18:04:35</created>
        /// <param name="gstr_id">ID de GestionretencionEntity.</param>
        /// <returns>Referencia a una clase <see cref="GestionretencionEntity"/>.</returns>
        public static GestionretencionEntity ObtenerPorID(int gstr_id)
        {
            Parametro parametro = new Parametro("@gstr_id", gstr_id);

            return DBHelper.InstanceCRM.ObtenerEntidad("empresas.spEmp_Gestionretencion_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="GestionretencionEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>10-04-2018 18:04:35</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("empresas.spEmp_Gestionretencion_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="GestionretencionEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>10-04-2018 18:04:35</created>
        /// <returns>Lista con todas las entidades <see cref="GestionretencionEntity"/>.</returns>
        public static List<GestionretencionEntity> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("empresas.spEmp_Gestionretencion_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static GestionretencionEntity ConstructorEntidad(DataRow row)
        {
            return new GestionretencionEntity
            {
                gstr_id = row["gstr_id"] != DBNull.Value ? Convert.ToInt32(row["gstr_id"]) : 0,
                gstr_fecha = row["gstr_fecha"] != DBNull.Value ? Convert.ToDateTime(row["gstr_fecha"]) : new DateTime(1900, 1, 1),
                gstr_etapa = row["gstr_etapa"] != DBNull.Value ? row["gstr_etapa"].ToString() : string.Empty,
                gstr_observaciones = row["gstr_observaciones"] != DBNull.Value ? row["gstr_observaciones"].ToString() : string.Empty,
                gstr_fecha_accion = row["gstr_fecha_accion"] != DBNull.Value ? Convert.ToDateTime(row["gstr_fecha_accion"]) : new DateTime(1900, 1, 1),
                retencion_id = row["retencion_id"] != DBNull.Value ? Convert.ToInt32(row["retencion_id"]) : 0,
                ejecutivo_rut = row["ejecutivo_rut"] != DBNull.Value ? row["ejecutivo_rut"].ToString() : string.Empty,
                oficina = row["oficina"] != DBNull.Value ? Convert.ToInt32(row["oficina"]) : 0,

            };
        }
        #endregion
    }
}
