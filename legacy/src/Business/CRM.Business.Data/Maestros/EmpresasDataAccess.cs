using System;
using System.Collections.Generic;
using System.Data;
using CRM.Business.Entity.Maestros;
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

namespace CRM.Business.Data.Maestros
{
    /// <summary>
    /// Clase Acceso de Datos EmpresasDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>10-04-2018 11:56:11</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class EmpresasDataAccess
    {
        #region metodos base


        
        /// <summary>
        /// Recupera todas las entidades <see cref="EmpresasEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>10-04-2018 11:56:11</created>
        /// <returns>Lista con todas las entidades <see cref="EmpresasEntity"/>.</returns>
        public static EmpresasEntity ObtenerByRut(string RutEmpresa)
        {
            return DBHelper.InstanceCRM.ObtenerEntidad("mae.spMotor_ObtenerEmpresaByRut", new Parametro("@Rut",RutEmpresa),ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="EmpresasEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>10-04-2018 11:56:11</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("empresas.spEmp_Empresas_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="EmpresasEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>10-04-2018 11:56:11</created>
        /// <returns>Lista con todas las entidades <see cref="EmpresasEntity"/>.</returns>
        public static List<EmpresasEntity> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("empresas.spEmp_Empresas_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static EmpresasEntity ConstructorEntidad(DataRow row)
        {
            return new EmpresasEntity
            {
                idFechaCorte = row["idFechaCorte"] != DBNull.Value ? Convert.ToDateTime(row["idFechaCorte"]) : new DateTime(1900, 1, 1),
                RutEmpresa = row["RutEmpresa"] != DBNull.Value ? row["RutEmpresa"].ToString() : string.Empty,
                DvEmpresa = row["DvEmpresa"] != DBNull.Value ? row["DvEmpresa"].ToString() : string.Empty,
                NombreEmpresa = row["NombreEmpresa"] != DBNull.Value ? row["NombreEmpresa"].ToString() : string.Empty,
                NombreHolding = row["NombreHolding"] != DBNull.Value ? row["NombreHolding"].ToString() : string.Empty,
                TipoEmpresa = row["TipoEmpresa"] != DBNull.Value ? row["TipoEmpresa"].ToString() : string.Empty,

            };
        }
        #endregion
    }
}
