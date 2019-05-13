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
    /// Clase Acceso de Datos RetencionDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>10-04-2018 18:06:53</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class RetencionDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="RetencionEntity"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>10-04-2018 18:06:53</created>
        /// <param name="retencion">Referencia a una clase <see cref="RetencionEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(RetencionEntity retencion)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@ret_id", retencion.ret_id),
                new Parametro("@empresa_id", retencion.empresa_id),
                new Parametro("@ret_estamento", retencion.ret_estamento),
                new Parametro("@ret_segmento", retencion.ret_segmento),
                new Parametro("@ret_dotacion", retencion.ret_dotacion),
                new Parametro("@ret_caja_destino", retencion.ret_caja_destino),
                new Parametro("@ejecutivo_rut", retencion.ejecutivo_rut),
                new Parametro("@oficina", retencion.oficina),
            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("empresas.spEmp_Retencion_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="RetencionEntity"/> de la Base de Datos dado un ID de RetencionEntity
        /// </summary>
        /// <author>@Charly</author>
        /// <created>10-04-2018 18:06:53</created>
        /// <param name="ret_id">ID de RetencionEntity.</param>
        /// <returns>Referencia a una clase <see cref="RetencionEntity"/>.</returns>
        public static RetencionEntity ObtenerPorID(int ret_id)
        {
            Parametro parametro = new Parametro("@ret_id", ret_id);

            return DBHelper.InstanceCRM.ObtenerEntidad("empresas.spEmp_Retencion_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="RetencionEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>10-04-2018 18:06:53</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("empresas.spEmp_Retencion_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="RetencionEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>10-04-2018 18:06:53</created>
        /// <returns>Lista con todas las entidades <see cref="RetencionEntity"/>.</returns>
        public static List<RetencionEntity> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("empresas.spEmp_Retencion_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static RetencionEntity ConstructorEntidad(DataRow row)
        {
            return new RetencionEntity
            {
                ret_id = row["ret_id"] != DBNull.Value ? Convert.ToInt32(row["ret_id"]) : 0,
                empresa_id = row["empresa_id"] != DBNull.Value ? Convert.ToInt32(row["empresa_id"]) : 0,
                ret_estamento = row["ret_estamento"] != DBNull.Value ? row["ret_estamento"].ToString() : string.Empty,
                ret_segmento = row["ret_segmento"] != DBNull.Value ? row["ret_segmento"].ToString() : string.Empty,
                ret_dotacion = row["ret_dotacion"] != DBNull.Value ? Convert.ToInt32(row["ret_dotacion"]) : 0,
                ret_caja_destino = row["ret_caja_destino"] != DBNull.Value ? row["ret_caja_destino"].ToString() : string.Empty,
                ejecutivo_rut = row["ejecutivo_rut"] != DBNull.Value ? row["ejecutivo_rut"].ToString() : string.Empty,
                oficina = row["oficina"] != DBNull.Value ? Convert.ToInt32(row["oficina"]) : 0,
            };
        }
        #endregion
    }
}
