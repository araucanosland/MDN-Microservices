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
    /// Clase Acceso de Datos PeriodoDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>16-05-2017 16:47:26</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class PeriodoDataAccess
    {
        #region metodos base


        /// <summary>
        /// Recupera todas las entidades <see cref="PeriodoEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>16-05-2017 16:47:26</created>
        /// <returns>Lista con todas las entidades <see cref="PeriodoEntity"/>.</returns>
        public static List<PeriodoEntity> ListarPeriodosGestion(int TipoAsignacion)
        {
            Parametro p = new Parametro("@TipoAsignacion", TipoAsignacion);
            return DBHelper.InstanceCRM.ObtenerColeccion("spMotor_ListaPeriodos", p, ConstructorEntidad);
        }
        public static List<PeriodoEntity> ListarPeriodosDotacion(int TipoAsignacion)
        {
            Parametro p = new Parametro("@TipoAsignacion", TipoAsignacion);
            return DBHelper.InstanceCRM.ObtenerColeccion("spMotor_ListaPeriodosDotacion", p, ConstructorEntidad);
        }
        

        /// <summary>
        /// Recupera todas las entidades <see cref="PeriodoEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>16-05-2017 16:47:26</created>
        /// <returns>Lista con todas las entidades <see cref="PeriodoEntity"/>.</returns>
        public static List<PeriodoEntity> ListarPeriodosTracking()
        {
            return DBHelper.InstanceReportes.ObtenerColeccion("negocios.spReporte_ListaPeriodos", ConstructorEntidad);
        }

        public static List<PeriodoEntity> ListarPeriodosFFVV()
        {
            return DBHelper.InstanceReportes.ObtenerColeccion("comisiones.spReporte_ListaPeriodosFFVV", ConstructorEntidad);
        }
        

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static PeriodoEntity ConstructorEntidad(DataRow row)
        {
            return new PeriodoEntity
            {
                Periodo = row["Periodo"] != DBNull.Value ? Convert.ToInt32(row["Periodo"]) : 0,
                PeriodoText = row["Periodo_Text"] != DBNull.Value ? row["Periodo_Text"].ToString() : string.Empty,
            };
        }
        #endregion
    }
}
