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
    /// Clase Acceso de Datos GestionprospeccionDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>12-04-2018 14:18:32</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class GestionprospeccionDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="GestionprospeccionEntity"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>12-04-2018 14:18:32</created>
        /// <param name="gestionprospeccion">Referencia a una clase <see cref="GestionprospeccionEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(GestionprospeccionEntity gestionprospeccion)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@gstp_id", gestionprospeccion.gstp_id),
                new Parametro("@gstp_fecha", gestionprospeccion.gstp_fecha),
                new Parametro("@gstp_etapa", gestionprospeccion.gstp_etapa),
                new Parametro("@gstp_observaciones", gestionprospeccion.gstp_observaciones),
                new Parametro("@gstp_fecha_accion", gestionprospeccion.gstp_fecha_accion),
                new Parametro("@prospecto_id", gestionprospeccion.prospecto_id),
                new Parametro("@ejecutivo_rut", gestionprospeccion.ejecutivo_rut),
                new Parametro("@oficina", gestionprospeccion.oficina),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("empresas.spEmp_Gestionprospeccion_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="GestionprospeccionEntity"/> de la Base de Datos dado un ID de GestionprospeccionEntity
        /// </summary>
        /// <author>@Charly</author>
        /// <created>12-04-2018 14:18:32</created>
        /// <param name="gstp_id">ID de GestionprospeccionEntity.</param>
        /// <returns>Referencia a una clase <see cref="GestionprospeccionEntity"/>.</returns>
        public static GestionprospeccionEntity ObtenerPorID(int gstp_id)
        {
            Parametro parametro = new Parametro("@gstp_id", gstp_id);

            return DBHelper.InstanceCRM.ObtenerEntidad("empresas.spEmp_Gestionprospeccion_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="GestionprospeccionEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>12-04-2018 14:18:32</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("empresas.spEmp_Gestionprospeccion_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="GestionprospeccionEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>12-04-2018 14:18:32</created>
        /// <returns>Lista con todas las entidades <see cref="GestionprospeccionEntity"/>.</returns>
        public static List<GestionprospeccionEntity> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("empresas.spEmp_Gestionprospeccion_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static GestionprospeccionEntity ConstructorEntidad(DataRow row)
        {
            return new GestionprospeccionEntity
            {
                gstp_id = row["gstp_id"] != DBNull.Value ? Convert.ToInt32(row["gstp_id"]) : 0,
                gstp_fecha = row["gstp_fecha"] != DBNull.Value ? Convert.ToDateTime(row["gstp_fecha"]) : new DateTime(1900, 1, 1),
                gstp_etapa = row["gstp_etapa"] != DBNull.Value ? row["gstp_etapa"].ToString() : string.Empty,
                gstp_observaciones = row["gstp_observaciones"] != DBNull.Value ? row["gstp_observaciones"].ToString() : string.Empty,
                gstp_fecha_accion = row["gstp_fecha_accion"] != DBNull.Value ? Convert.ToDateTime(row["gstp_fecha_accion"]): new DateTime(1900, 1, 1),
                prospecto_id = row["prospecto_id"] != DBNull.Value ? Convert.ToInt32(row["prospecto_id"]) : 0,
                ejecutivo_rut = row["ejecutivo_rut"] != DBNull.Value ? row["ejecutivo_rut"].ToString() : string.Empty,
                oficina = row["oficina"] != DBNull.Value ? Convert.ToInt32(row["oficina"]) : 0,

            };
        }
        #endregion
    }
}
