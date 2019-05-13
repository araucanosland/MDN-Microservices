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
    /// Clase Acceso de Datos TipoausenciaDataAccess
    /// </summary>
    /// <author>Carlos Pradenas</author>
    /// <created>27-06-2017 23:53:51</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class TipoausenciaDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="TipoausenciaEntity"/> en la Base de Datos
        /// </summary>
        /// <author>Carlos Pradenas</author>
        /// <created>27-06-2017 23:53:51</created>
        /// <param name="tipoausencia">Referencia a una clase <see cref="TipoausenciaEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(TipoausenciaEntity tipoausencia)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@taus_id", tipoausencia.taus_id),
                new Parametro("@taus_nombre", tipoausencia.taus_nombre),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("spMotor_Tipoausencia_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="TipoausenciaEntity"/> de la Base de Datos dado un ID de TipoausenciaEntity
        /// </summary>
        /// <author>Carlos Pradenas</author>
        /// <created>27-06-2017 23:53:51</created>
        /// <param name="taus_id">ID de TipoausenciaEntity.</param>
        /// <returns>Referencia a una clase <see cref="TipoausenciaEntity"/>.</returns>
        public static TipoausenciaEntity ObtenerPorID(int taus_id)
        {
            Parametro parametro = new Parametro("@taus_id", taus_id);

            return DBHelper.InstanceCRM.ObtenerEntidad("spMotor_Tipoausencia_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="TipoausenciaEntity"/> de la Base de Datos
        /// </summary>
        /// <author>Carlos Pradenas</author>
        /// <created>27-06-2017 23:53:51</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("spMotor_Tipoausencia_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="TipoausenciaEntity"/> de la Base de Datos
        /// </summary>
        /// <author>Carlos Pradenas</author>
        /// <created>27-06-2017 23:53:51</created>
        /// <returns>Lista con todas las entidades <see cref="TipoausenciaEntity"/>.</returns>
        public static List<TipoausenciaEntity> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("spMotor_Tipoausencia_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static TipoausenciaEntity ConstructorEntidad(DataRow row)
        {
            return new TipoausenciaEntity
            {
                taus_id = row["taus_id"] != DBNull.Value ? Convert.ToInt32(row["taus_id"]) : 0,
                taus_nombre = row["taus_nombre"] != DBNull.Value ? row["taus_nombre"].ToString() : string.Empty,
                taus_clase_color = row["taus_clase_color"] != DBNull.Value ? row["taus_clase_color"].ToString() : string.Empty,
                taus_es_rango_fechas = row["taus_es_rango_fechas"] != DBNull.Value ? Convert.ToBoolean(row["taus_es_rango_fechas"]) : false,
                taus_es_dias_corridos = row["taus_es_dias_corridos"] != DBNull.Value ? Convert.ToBoolean(row["taus_es_dias_corridos"]) : false,
            };
        }
        #endregion
    }
}
