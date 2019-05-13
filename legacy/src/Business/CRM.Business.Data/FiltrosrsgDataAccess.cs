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
    /// Clase Acceso de Datos FiltrosrsgDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>31-08-2017 11:33:54</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class FiltrosrsgDataAccess
    {
        #region metodos base
        

        /// <summary>
        /// Recupera una entidad <see cref="FiltrosrsgEntity"/> de la Base de Datos dado un ID de FiltrosrsgEntity
        /// </summary>
        /// <author>@Charly</author>
        /// <created>31-08-2017 11:33:54</created>
        /// <param name="Periodo">ID de FiltrosrsgEntity.</param>
        /// <returns>Referencia a una clase <see cref="FiltrosrsgEntity"/>.</returns>
        public static FiltrosrsgEntity ObtenerEntidad(int Periodo, string RutAfiliado, string RutEmpresa)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@Periodo", Periodo),
                new Parametro("@RutAfiliado", RutAfiliado),
                new Parametro("@RutEmpresa", RutEmpresa)
            };

            return DBHelper.InstanceCRM.ObtenerEntidad("spMotor_Filtrosrsg_Obtener", parametros, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="FiltrosrsgEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>31-08-2017 11:33:54</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("spMotor_Filtrosrsg_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="FiltrosrsgEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>31-08-2017 11:33:54</created>
        /// <returns>Lista con todas las entidades <see cref="FiltrosrsgEntity"/>.</returns>
        public static List<FiltrosrsgEntity> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("spMotor_Filtrosrsg_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static FiltrosrsgEntity ConstructorEntidad(DataRow row)
        {
            return new FiltrosrsgEntity
            {
                Periodo = row["Periodo"] != DBNull.Value ? Convert.ToInt32(row["Periodo"]) : 0,
                AfiliadoRut = row["AfiliadoRut"] != DBNull.Value ? row["AfiliadoRut"].ToString() : string.Empty,
                EmpresaRut = row["EmpresaRut"] != DBNull.Value ? row["EmpresaRut"].ToString() : string.Empty,
                Filtros = row["Filtros"] != DBNull.Value ? row["Filtros"].ToString() : string.Empty,

            };
        }
        #endregion
    }
}
