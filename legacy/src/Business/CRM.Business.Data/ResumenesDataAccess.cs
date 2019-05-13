using System;
using System.Collections.Generic;
using System.Data;
using CRM.Business.Entity;
using CRM.Business.Entity.Clases;
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
    /// Clase Acceso de Datos AusenciaDataAccess
    /// </summary>
    /// <author>Carlos Pradenas</author>
    /// <created>27-06-2017 23:59:04</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class ResumenesDataAccess
    {
        #region metodos base

        /// <summary>
        /// Recupera todas las entidades <see cref="AusenciaEntity"/> de la Base de Datos
        /// </summary>
        /// <author>Carlos Pradenas</author>
        /// <created>27-06-2017 23:59:04</created>
        /// <returns>Lista con todas las entidades <see cref="AusenciaEntity"/>.</returns>
        public static List<ResumenAusencias> ObtenerEntidades(string Token, int Periodo)
        {
            Parametros prm = new Parametros
            {
                new Parametro("@TOKEN",Token),
                new Parametro("@PERIODO",Periodo),
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("spMotor_ListarResumenesAusencias", prm, ConstructorEntidad);
        }
        public static List<ResumenAusencias> ObtenerEntidadesAdmin(int Periodo,int codSucursal)
        {
            Parametros prm = new Parametros
            {
                
                new Parametro("@PERIODO",Periodo),
                new Parametro("@CODSUCURSAL",codSucursal)
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("spMotor_ListarResumenesAusenciasAdmin", prm, ConstructorEntidad);
        }
        #endregion



        #region constructor
        private static ResumenAusencias ConstructorEntidad(DataRow row)
        {
            return new ResumenAusencias
            {
                ClaseAusencia = row["ClaseAusencia"] != DBNull.Value ? row["ClaseAusencia"].ToString() : string.Empty,
                Numero = row["Numero"] != DBNull.Value ? Convert.ToInt32(row["Numero"]) : 0,
                Porcentaje = row["Porcentaje"] != DBNull.Value ? Convert.ToInt32(row["Porcentaje"]) : 0,
            };
        }
        #endregion
    }
}

