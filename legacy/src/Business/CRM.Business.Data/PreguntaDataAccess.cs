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
    /// Clase Acceso de Datos PreguntaDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>07-03-2018 10:58:18</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class PreguntaDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="PreguntaEntity"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>07-03-2018 10:58:18</created>
        /// <param name="pregunta">Referencia a una clase <see cref="PreguntaEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(PreguntaEntity pregunta)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@preg_id", pregunta.preg_id),
                new Parametro("@cuestionario_id", pregunta.cuestionario_id),
                new Parametro("@titulo", pregunta.titulo),
                new Parametro("@item", pregunta.item),
                new Parametro("@pregunta_relacionada", pregunta.pregunta_relacionada),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("fichas.spFicha_Pregunta_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="PreguntaEntity"/> de la Base de Datos dado un ID de PreguntaEntity
        /// </summary>
        /// <author>@Charly</author>
        /// <created>07-03-2018 10:58:18</created>
        /// <param name="preg_id">ID de PreguntaEntity.</param>
        /// <returns>Referencia a una clase <see cref="PreguntaEntity"/>.</returns>
        public static PreguntaEntity ObtenerPorID(int preg_id)
        {
            Parametro parametro = new Parametro("@preg_id", preg_id);

            return DBHelper.InstanceCRM.ObtenerEntidad("fichas.spFicha_Pregunta_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="PreguntaEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>07-03-2018 10:58:18</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("fichas.spFicha_Pregunta_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="PreguntaEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>07-03-2018 10:58:18</created>
        /// <returns>Lista con todas las entidades <see cref="PreguntaEntity"/>.</returns>
        public static List<PreguntaEntity> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("fichas.spFicha_Pregunta_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static PreguntaEntity ConstructorEntidad(DataRow row)
        {
            return new PreguntaEntity
            {
                preg_id = row["preg_id"] != DBNull.Value ? Convert.ToInt32(row["preg_id"]) : 0,
                cuestionario_id = row["cuestionario_id"] != DBNull.Value ? Convert.ToInt32(row["cuestionario_id"]) : 0,
                titulo = row["titulo"] != DBNull.Value ? row["titulo"].ToString() : string.Empty,
                item = row["item"] != DBNull.Value ? row["item"].ToString() : string.Empty,
                pregunta_relacionada = row["pregunta_relacionada"] != DBNull.Value ? Convert.ToInt32(row["pregunta_relacionada"]) : 0,

            };
        }
        #endregion
    }
}
