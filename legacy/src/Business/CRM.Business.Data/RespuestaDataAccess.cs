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
    /// Clase Acceso de Datos RespuestaDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>07-03-2018 10:59:06</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class RespuestaDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="RespuestaEntity"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>07-03-2018 10:59:06</created>
        /// <param name="respuesta">Referencia a una clase <see cref="RespuestaEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(RespuestaEntity respuesta)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@resp_id", respuesta.resp_id),
                new Parametro("@nuberespuesta_id", respuesta.nuberespuesta_id),
                new Parametro("@pregunta_id", respuesta.pregunta_id),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("fichas.spFicha_Respuesta_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="RespuestaEntity"/> de la Base de Datos dado un ID de RespuestaEntity
        /// </summary>
        /// <author>@Charly</author>
        /// <created>07-03-2018 10:59:06</created>
        /// <param name="resp_id">ID de RespuestaEntity.</param>
        /// <returns>Referencia a una clase <see cref="RespuestaEntity"/>.</returns>
        public static RespuestaEntity ObtenerPorID(int resp_id)
        {
            Parametro parametro = new Parametro("@resp_id", resp_id);

            return DBHelper.InstanceCRM.ObtenerEntidad("fichas.spFicha_Respuesta_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="RespuestaEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>07-03-2018 10:59:06</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("fichas.spFicha_Respuesta_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="RespuestaEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>07-03-2018 10:59:06</created>
        /// <returns>Lista con todas las entidades <see cref="RespuestaEntity"/>.</returns>
        public static List<RespuestaEntity> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("fichas.spFicha_Respuesta_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static RespuestaEntity ConstructorEntidad(DataRow row)
        {
            return new RespuestaEntity
            {
                resp_id = row["resp_id"] != DBNull.Value ? Convert.ToInt32(row["resp_id"]) : 0,
                nuberespuesta_id = row["nuberespuesta_id"] != DBNull.Value ? Convert.ToInt32(row["nuberespuesta_id"]) : 0,
                pregunta_id = row["pregunta_id"] != DBNull.Value ? Convert.ToInt32(row["pregunta_id"]) : 0,

            };
        }
        #endregion
    }
}
