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
    /// Clase Acceso de Datos FeriadosDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>28-08-2017 13:14:37</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class FeriadosDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="Feriados"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>28-08-2017 13:14:37</created>
        /// <param name="feriados">Referencia a una clase <see cref="Feriados"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static DateTime Guardar(Feriados feriados)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@Fecha", feriados.Fecha),
                new Parametro("@Descripcion", feriados.Descripcion),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<DateTime>("sp_Feriados_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="Feriados"/> de la Base de Datos dado un ID de Feriados
        /// </summary>
        /// <author>@Charly</author>
        /// <created>28-08-2017 13:14:37</created>
        /// <param name="Fecha">ID de Feriados.</param>
        /// <returns>Referencia a una clase <see cref="Feriados"/>.</returns>
        public static Feriados ObtenerPorID(DateTime Fecha)
        {
            Parametro parametro = new Parametro("@Fecha", Fecha);

            return DBHelper.InstanceCRM.ObtenerEntidad("sp_Feriados_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="Feriados"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>28-08-2017 13:14:37</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("sp_Feriados_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="Feriados"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>28-08-2017 13:14:37</created>
        /// <returns>Lista con todas las entidades <see cref="Feriados"/>.</returns>
        public static List<Feriados> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("sp_Feriados_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static Feriados ConstructorEntidad(DataRow row)
        {
            return new Feriados
            {
                Fecha = row["Fecha"] != DBNull.Value ? Convert.ToDateTime(row["Fecha"]) : new DateTime(1900, 1, 1),
                Descripcion = row["Descripcion"] != DBNull.Value ? row["Descripcion"].ToString() : string.Empty,

            };
        }
        #endregion
    }
}
