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
    /// Clase Acceso de Datos RepresentanteempresaDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>02-04-2018 13:09:10</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class RepresentanteempresaDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="RepresentanteempresaEntity"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 13:09:10</created>
        /// <param name="representanteempresa">Referencia a una clase <see cref="RepresentanteempresaEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(RepresentanteempresaEntity representanteempresa)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@rep_id", representanteempresa.rep_id),
                new Parametro("@rep_nombre", representanteempresa.rep_nombre),
                new Parametro("@rep_cargo", representanteempresa.rep_cargo),
                new Parametro("@emp_id", representanteempresa.emp_id),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("empresas.spEmp_Representanteempresa_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="RepresentanteempresaEntity"/> de la Base de Datos dado un ID de RepresentanteempresaEntity
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 13:09:10</created>
        /// <param name="rep_id">ID de RepresentanteempresaEntity.</param>
        /// <returns>Referencia a una clase <see cref="RepresentanteempresaEntity"/>.</returns>
        public static RepresentanteempresaEntity ObtenerPorID(int rep_id)
        {
            Parametro parametro = new Parametro("@rep_id", rep_id);

            return DBHelper.InstanceCRM.ObtenerEntidad("empresas.spEmp_Representanteempresa_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="RepresentanteempresaEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 13:09:10</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("empresas.spEmp_Representanteempresa_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="RepresentanteempresaEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 13:09:10</created>
        /// <returns>Lista con todas las entidades <see cref="RepresentanteempresaEntity"/>.</returns>
        public static List<RepresentanteempresaEntity> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("empresas.spEmp_Representanteempresa_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static RepresentanteempresaEntity ConstructorEntidad(DataRow row)
        {
            return new RepresentanteempresaEntity
            {
                rep_id = row["rep_id"] != DBNull.Value ? Convert.ToInt32(row["rep_id"]) : 0,
                rep_nombre = row["rep_nombre"] != DBNull.Value ? row["rep_nombre"].ToString() : string.Empty,
                rep_cargo = row["rep_cargo"] != DBNull.Value ? row["rep_cargo"].ToString() : string.Empty,
                emp_id = row["emp_id"] != DBNull.Value ? Convert.ToInt32(row["emp_id"]) : 0,

            };
        }
        #endregion
    }
}
