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
    /// Clase Acceso de Datos CuestionarioDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>07-03-2018 10:28:27</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class CuestionarioDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="CuestionarioEntity"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>07-03-2018 10:28:27</created>
        /// <param name="cuestionario">Referencia a una clase <see cref="CuestionarioEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(CuestionarioEntity cuestionario)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@cuest_id", cuestionario.cuest_id),
                new Parametro("@descripcion", cuestionario.descripcion),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("fichas.spFicha_Cuestionario_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="CuestionarioEntity"/> de la Base de Datos dado un ID de CuestionarioEntity
        /// </summary>
        /// <author>@Charly</author>
        /// <created>07-03-2018 10:28:27</created>
        /// <param name="cuest_id">ID de CuestionarioEntity.</param>
        /// <returns>Referencia a una clase <see cref="CuestionarioEntity"/>.</returns>
        public static CuestionarioEntity ObtenerPorID(int cuest_id)
        {
            Parametro parametro = new Parametro("@cuest_id", cuest_id);

            return DBHelper.InstanceCRM.ObtenerEntidad("fichas.spFicha_Cuestionario_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="CuestionarioEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>07-03-2018 10:28:27</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("fichas.spFicha_Cuestionario_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="CuestionarioEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>07-03-2018 10:28:27</created>
        /// <returns>Lista con todas las entidades <see cref="CuestionarioEntity"/>.</returns>
        public static List<CuestionarioEntity> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("fichas.spFicha_Cuestionario_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static CuestionarioEntity ConstructorEntidad(DataRow row)
        {
            return new CuestionarioEntity
            {
                cuest_id = row["cuest_id"] != DBNull.Value ? Convert.ToInt32(row["cuest_id"]) : 0,
                descripcion = row["descripcion"] != DBNull.Value ? row["descripcion"].ToString() : string.Empty,

            };
        }
        #endregion
    }
}
