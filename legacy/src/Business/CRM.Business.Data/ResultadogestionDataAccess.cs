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
    /// Clase Acceso de Datos ResultadogestionDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>02-04-2018 13:10:17</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class ResultadogestionDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="ResultadogestionEntity"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 13:10:17</created>
        /// <param name="resultadogestion">Referencia a una clase <see cref="ResultadogestionEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(ResultadogestionEntity resultadogestion)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@resg_id", resultadogestion.resg_id),
                new Parametro("@resg_tipo", resultadogestion.resg_tipo),
                new Parametro("@resg_comentarios", resultadogestion.resg_comentarios),
                new Parametro("@resg_fecha", resultadogestion.resg_fecha),
                new Parametro("@fidelizacion_id", resultadogestion.fidelizacion_id),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("empresas.spEmp_Resultadogestion_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="ResultadogestionEntity"/> de la Base de Datos dado un ID de ResultadogestionEntity
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 13:10:17</created>
        /// <param name="resg_id">ID de ResultadogestionEntity.</param>
        /// <returns>Referencia a una clase <see cref="ResultadogestionEntity"/>.</returns>
        public static ResultadogestionEntity ObtenerPorID(int resg_id)
        {
            Parametro parametro = new Parametro("@resg_id", resg_id);

            return DBHelper.InstanceCRM.ObtenerEntidad("empresas.spEmp_Resultadogestion_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="ResultadogestionEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 13:10:17</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("empresas.spEmp_Resultadogestion_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="ResultadogestionEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 13:10:17</created>
        /// <returns>Lista con todas las entidades <see cref="ResultadogestionEntity"/>.</returns>
        public static List<ResultadogestionEntity> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("empresas.spEmp_Resultadogestion_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        /// <summary>
        /// Recupera todas las entidades <see cref="ResultadogestionEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 13:10:17</created>
        /// <returns>Lista con todas las entidades <see cref="ResultadogestionEntity"/>.</returns>
        public static void EliminarByFidelizacion(int idFidelizacion)
        {
            DBHelper.InstanceCRM.EjecutarProcedimiento("empresas.spEmp_Resultadogestion_Eliminar", new Parametro("@IdFidelizacion",idFidelizacion));
        }

        #endregion

        #region constructor
        private static ResultadogestionEntity ConstructorEntidad(DataRow row)
        {
            return new ResultadogestionEntity
            {
                resg_id = row["resg_id"] != DBNull.Value ? Convert.ToInt32(row["resg_id"]) : 0,
                resg_tipo = row["resg_tipo"] != DBNull.Value ? row["resg_tipo"].ToString() : string.Empty,
                resg_comentarios = row["resg_comentarios"] != DBNull.Value ? row["resg_comentarios"].ToString() : string.Empty,
                resg_fecha = row["resg_fecha"] != DBNull.Value ? Convert.ToDateTime(row["resg_fecha"]) : new DateTime(1900, 1, 1),
                fidelizacion_id = row["fidelizacion_id"] != DBNull.Value ? Convert.ToInt32(row["fidelizacion_id"]) : 0,

            };
        }
        #endregion
    }
}
