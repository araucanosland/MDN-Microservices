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
    /// Clase Acceso de Datos PreferenciaAfiliadoDataAccess
    /// </summary>
    /// <author>Charly</author>
    /// <created>29-05-2017 17:49:01</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class PreferenciaAfiliadoDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="PreferenciaAfiliadoEntity"/> en la Base de Datos
        /// </summary>
        /// <author>Charly</author>
        /// <created>29-05-2017 17:49:01</created>
        /// <param name="preferenciaAfiliado">Referencia a una clase <see cref="PreferenciaAfiliadoEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(PreferenciaAfiliadoEntity preferenciaAfiliado)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@Afiliado_rut", preferenciaAfiliado.Afiliado_rut),
                new Parametro("@Fecha_accion", preferenciaAfiliado.Fecha_accion),
                new Parametro("@Tipo_preferencia", preferenciaAfiliado.Tipo_preferencia),
                new Parametro("@Valor_preferencia", preferenciaAfiliado.Valor_preferencia),
                new Parametro("@Valida", preferenciaAfiliado.Valida),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("spMotor_PreferenciaAfiliado_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="PreferenciaAfiliadoEntity"/> de la Base de Datos dado un ID de PreferenciaAfiliadoEntity
        /// </summary>
        /// <author>Charly</author>
        /// <created>29-05-2017 17:49:01</created>
        /// <param name="Afiliado_rut">ID de PreferenciaAfiliadoEntity.</param>
        /// <returns>Referencia a una clase <see cref="PreferenciaAfiliadoEntity"/>.</returns>
        public static PreferenciaAfiliadoEntity ObtenerPorID(int Afiliado_rut, string Tipo_preferencia)
        {
            Parametros parametros = new Parametros
            {
                    new Parametro("@Afiliado_rut", Afiliado_rut),
                    new Parametro("@Tipo_preferencia", Tipo_preferencia),
            };

            return DBHelper.InstanceCRM.ObtenerEntidad("spMotor_PreferenciaAfiliado_ObtenerPorID", parametros, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="PreferenciaAfiliadoEntity"/> de la Base de Datos
        /// </summary>
        /// <author>Charly</author>
        /// <created>29-05-2017 17:49:01</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("spMotor_PreferenciaAfiliado_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="PreferenciaAfiliadoEntity"/> de la Base de Datos
        /// </summary>
        /// <author>Charly</author>
        /// <created>29-05-2017 17:49:01</created>
        /// <returns>Lista con todas las entidades <see cref="PreferenciaAfiliadoEntity"/>.</returns>
        public static List<PreferenciaAfiliadoEntity> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("spMotor_PreferenciaAfiliado_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static PreferenciaAfiliadoEntity ConstructorEntidad(DataRow row)
        {
            return new PreferenciaAfiliadoEntity
            {
                Afiliado_rut = row["Afiliado_rut"] != DBNull.Value ? Convert.ToInt32(row["Afiliado_rut"]) : 0,
                Fecha_accion = row["Fecha_accion"] != DBNull.Value ? Convert.ToDateTime(row["Fecha_accion"]) : new DateTime(1900, 1, 1),
                Tipo_preferencia = row["Tipo_preferencia"] != DBNull.Value ? row["Tipo_preferencia"].ToString() : string.Empty,
                Valor_preferencia = row["Valor_preferencia"] != DBNull.Value ? row["Valor_preferencia"].ToString() : string.Empty,
                Valida = row["Valida"] != DBNull.Value && Convert.ToBoolean(row["Valida"]),

            };
        }
        #endregion
    }
}
