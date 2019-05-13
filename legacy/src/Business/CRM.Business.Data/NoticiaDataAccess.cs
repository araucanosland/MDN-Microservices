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
    /// Clase Acceso de Datos NoticiaDataAccess
    /// </summary>
    /// <author>Charly</author>
    /// <created>12-06-2017 10:15:26</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class NoticiaDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="NoticiaEntity"/> en la Base de Datos
        /// </summary>
        /// <author>Charly</author>
        /// <created>12-06-2017 10:15:26</created>
        /// <param name="noticia">Referencia a una clase <see cref="NoticiaEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(NoticiaEntity noticia)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@noti_id", noticia.noti_id),
                new Parametro("@noti_titulo", noticia.noti_titulo),
                new Parametro("@noti_cuerpo", noticia.noti_cuerpo),
                new Parametro("@noti_cerrable", noticia.noti_cerrable),
                
            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("spMotor_Noticia_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="NoticiaEntity"/> de la Base de Datos dado un ID de NoticiaEntity
        /// </summary>
        /// <author>Charly</author>
        /// <created>12-06-2017 10:15:26</created>
        /// <param name="noti_id">ID de NoticiaEntity.</param>
        /// <returns>Referencia a una clase <see cref="NoticiaEntity"/>.</returns>
        public static NoticiaEntity ObtenerPorID(int noti_id)
        {
            Parametro parametro = new Parametro("@noti_id", noti_id);

            return DBHelper.InstanceCRM.ObtenerEntidad("spMotor_Noticia_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="NoticiaEntity"/> de la Base de Datos
        /// </summary>
        /// <author>Charly</author>
        /// <created>12-06-2017 10:15:26</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("spMotor_Noticia_Listar");
        }


        /// <summary>
        /// Recupera todas las entidades <see cref="NoticiaEntity"/> de la Base de Datos
        /// </summary>
        /// <author>Charly</author>
        /// <created>12-06-2017 10:15:26</created>
        /// <returns>Lista con todas las entidades <see cref="NoticiaEntity"/>.</returns>
        public static List<NoticiaEntity> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("spMotor_Noticia_Listar", ConstructorEntidad);
        }


        #endregion

        #region metodos adicionales
        /// <summary>
        /// Recupera todas las entidades <see cref="NoticiaEntity"/> de la Base de Datos
        /// </summary>
        /// <author>Charly</author>
        /// <created>12-06-2017 10:15:26</created>
        /// <returns>Lista con todas las entidades <see cref="NoticiaEntity"/>.</returns>
        public static int NoticiaLeida(string token)
        {
            Parametro p = new Parametro("@token", token);
            return DBHelper.InstanceCRM.EjecutarProcedimiento("spMotor_Noticia_Leida", p);
        }


        #endregion

        #region constructor
        private static NoticiaEntity ConstructorEntidad(DataRow row)
        {
            return new NoticiaEntity
            {
                noti_id = row["noti_id"] != DBNull.Value ? Convert.ToInt32(row["noti_id"]) : 0,
                noti_titulo = row["noti_titulo"] != DBNull.Value ? row["noti_titulo"].ToString() : string.Empty,
                noti_cuerpo = row["noti_cuerpo"] != DBNull.Value ? row["noti_cuerpo"].ToString() : string.Empty,
                noti_cerrable = row["noti_cerrable"] != DBNull.Value ? Convert.ToInt32(row["noti_cerrable"]) : 0,
                noti_fecha = row["noti_fecha"] != DBNull.Value ? Convert.ToDateTime(row["noti_fecha"]) : new DateTime(1900, 1, 1),
                
            };
        }
        #endregion
    }
}
