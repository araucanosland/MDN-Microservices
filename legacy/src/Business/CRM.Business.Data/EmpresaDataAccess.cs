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
    /// Clase Acceso de Datos EmpresaDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>02-04-2018 13:04:57</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class EmpresaDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="EmpresaEntity"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 13:04:57</created>
        /// <param name="empresa">Referencia a una clase <see cref="EmpresaEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(EmpresaEntity empresa)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@emp_id", empresa.emp_id),
                new Parametro("@emp_rut", empresa.emp_rut),
                new Parametro("@emp_nombre", empresa.emp_nombre),
                new Parametro("@emp_holding", empresa.emp_holding),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("empresas.spEmp_Empresa_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="EmpresaEntity"/> de la Base de Datos dado un ID de EmpresaEntity
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 13:04:57</created>
        /// <param name="emp_id">ID de EmpresaEntity.</param>
        /// <returns>Referencia a una clase <see cref="EmpresaEntity"/>.</returns>
        public static EmpresaEntity ObtenerPorID(int emp_id)
        {
            Parametro parametro = new Parametro("@emp_id", emp_id);

            return DBHelper.InstanceCRM.ObtenerEntidad("empresas.spEmp_Empresa_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="EmpresaEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 13:04:57</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("empresas.spEmp_Empresa_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="EmpresaEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 13:04:57</created>
        /// <returns>Lista con todas las entidades <see cref="EmpresaEntity"/>.</returns>
        public static List<EmpresaEntity> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("empresas.spEmp_Empresa_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static EmpresaEntity ConstructorEntidad(DataRow row)
        {
            return new EmpresaEntity
            {
                emp_id = row["emp_id"] != DBNull.Value ? Convert.ToInt32(row["emp_id"]) : 0,
                emp_rut = row["emp_rut"] != DBNull.Value ? row["emp_rut"].ToString() : string.Empty,
                emp_nombre = row["emp_nombre"] != DBNull.Value ? row["emp_nombre"].ToString() : string.Empty,
                emp_holding = row["emp_holding"] != DBNull.Value ? row["emp_holding"].ToString() : string.Empty,

            };
        }
        #endregion
    }
}
