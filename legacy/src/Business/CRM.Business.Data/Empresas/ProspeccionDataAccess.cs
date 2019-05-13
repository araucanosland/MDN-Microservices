using System;
using System.Collections.Generic;
using System.Data;
using CRM.Business.Entity.Empresas;
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

namespace CRM.Business.Data.Empresas
{
    /// <summary>
    /// Clase Acceso de Datos ProspeccionDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>12-04-2018 14:17:26</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class ProspeccionDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="ProspeccionEntity"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>12-04-2018 14:17:26</created>
        /// <param name="prospeccion">Referencia a una clase <see cref="ProspeccionEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(ProspeccionEntity prospeccion)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@pros_id", prospeccion.pros_id),
                new Parametro("@empresa_id", prospeccion.empresa_id),
                new Parametro("@pros_dotacion", prospeccion.pros_dotacion),
                new Parametro("@pros_caja_origen", prospeccion.pros_caja_origen),
                new Parametro("@ejecutivo_rut", prospeccion.ejecutivo_rut),
                new Parametro("@oficina", prospeccion.oficina),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("empresas.spEmp_Prospeccion_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="ProspeccionEntity"/> de la Base de Datos dado un ID de ProspeccionEntity
        /// </summary>
        /// <author>@Charly</author>
        /// <created>12-04-2018 14:17:26</created>
        /// <param name="pros_id">ID de ProspeccionEntity.</param>
        /// <returns>Referencia a una clase <see cref="ProspeccionEntity"/>.</returns>
        public static ProspeccionEntity ObtenerPorID(int pros_id)
        {
            Parametro parametro = new Parametro("@pros_id", pros_id);

            return DBHelper.InstanceCRM.ObtenerEntidad("empresas.spEmp_Prospeccion_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="ProspeccionEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>12-04-2018 14:17:26</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("empresas.spEmp_Prospeccion_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="ProspeccionEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>12-04-2018 14:17:26</created>
        /// <returns>Lista con todas las entidades <see cref="ProspeccionEntity"/>.</returns>
        public static List<ProspeccionEntity> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("empresas.spEmp_Prospeccion_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static ProspeccionEntity ConstructorEntidad(DataRow row)
        {
            return new ProspeccionEntity
            {
                pros_id = row["pros_id"] != DBNull.Value ? Convert.ToInt32(row["pros_id"]) : 0,
                empresa_id = row["empresa_id"] != DBNull.Value ? Convert.ToInt32(row["empresa_id"]) : 0,
                pros_dotacion = row["pros_dotacion"] != DBNull.Value ? Convert.ToInt32(row["pros_dotacion"]) : 0,
                pros_caja_origen = row["pros_caja_origen"] != DBNull.Value ? row["pros_caja_origen"].ToString() : string.Empty,
                ejecutivo_rut = row["ejecutivo_rut"] != DBNull.Value ? row["ejecutivo_rut"].ToString() : string.Empty,
                oficina = row["oficina"] != DBNull.Value ? Convert.ToInt32(row["oficina"]) : 0,

            };
        }
        #endregion
    }
}
