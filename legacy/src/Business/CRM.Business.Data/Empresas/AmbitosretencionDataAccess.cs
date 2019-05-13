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
    /// Clase Acceso de Datos AmbitosretencionDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>10-04-2018 18:02:37</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class AmbitosretencionDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="AmbitosretencionEntity"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>10-04-2018 18:02:37</created>
        /// <param name="ambitosretencion">Referencia a una clase <see cref="AmbitosretencionEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(AmbitosretencionEntity ambitosretencion)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@aret_id", ambitosretencion.aret_id),
                new Parametro("@ambito_id", ambitosretencion.ambito_id),
                new Parametro("@retencion_id", ambitosretencion.retencion_id),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("empresas.spEmp_Ambitosretencion_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="AmbitosretencionEntity"/> de la Base de Datos dado un ID de AmbitosretencionEntity
        /// </summary>
        /// <author>@Charly</author>
        /// <created>10-04-2018 18:02:37</created>
        /// <param name="aret_id">ID de AmbitosretencionEntity.</param>
        /// <returns>Referencia a una clase <see cref="AmbitosretencionEntity"/>.</returns>
        public static AmbitosretencionEntity ObtenerPorID(int aret_id)
        {
            Parametro parametro = new Parametro("@aret_id", aret_id);

            return DBHelper.InstanceCRM.ObtenerEntidad("empresas.spEmp_Ambitosretencion_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="AmbitosretencionEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>10-04-2018 18:02:37</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("empresas.spEmp_Ambitosretencion_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="AmbitosretencionEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>10-04-2018 18:02:37</created>
        /// <returns>Lista con todas las entidades <see cref="AmbitosretencionEntity"/>.</returns>
        public static List<AmbitosretencionEntity> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("empresas.spEmp_Ambitosretencion_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        /// <summary>
        /// Recupera todas las entidades <see cref="AmbitosfidelizacionEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 13:00:07</created>
        /// <returns>Lista con todas las entidades <see cref="AmbitosfidelizacionEntity"/>.</returns>
        public static void EliminarByRetencion(int idRetencion)
        {
            DBHelper.InstanceCRM.EjecutarProcedimiento("empresas.spEmp_Ambitosretencion_Eliminar", new Parametro("@IdRetencion", idRetencion));
        }

        #endregion

        #region constructor
        private static AmbitosretencionEntity ConstructorEntidad(DataRow row)
        {
            return new AmbitosretencionEntity
            {
                aret_id = row["aret_id"] != DBNull.Value ? Convert.ToInt32(row["aret_id"]) : 0,
                ambito_id = row["ambito_id"] != DBNull.Value ? Convert.ToInt32(row["ambito_id"]) : 0,
                retencion_id = row["retencion_id"] != DBNull.Value ? Convert.ToInt32(row["retencion_id"]) : 0,

            };
        }
        #endregion
    }
}
