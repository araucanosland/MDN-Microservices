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
    /// Clase Acceso de Datos NotificacionAsignacionDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>16-05-2017 16:47:26</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class NotificacionAsignacionDataAccess
    {
        #region metodos base
        
        /// <summary>
        /// Recupera una entidad <see cref="NotificacionAsignacionEntity"/> de la Base de Datos dado un ID de NotificacionAsignacionEntity
        /// </summary>
        /// <author>@Charly</author>
        /// <created>16-05-2017 16:47:26</created>
        /// <param name="AfiliadoRut">ID de NotificacionAsignacionEntity.</param>
        /// <returns>Referencia a una clase <see cref="NotificacionAsignacionEntity"/>.</returns>
        public static NotificacionAsignacionEntity ObtenerNTF(string AfiliadoRut, string Tipo)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@AfiliadoRut", AfiliadoRut),
                new Parametro("@Tipo", Tipo),
            };

            return DBHelper.InstanceCRM.ObtenerEntidad("spMotor_NotificacionAsignacion_ObtenerPorID", parametros, ConstructorEntidad);
        }
        
        /// <summary>
        /// Recupera todas las entidades <see cref="NotificacionAsignacionEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>16-05-2017 16:47:26</created>
        /// <returns>Lista con todas las entidades <see cref="NotificacionAsignacionEntity"/>.</returns>
        public static List<NotificacionAsignacionEntity> ObtenerSetNTF(string AfiliadoRut)
        {
            Parametro parametro = new Parametro("@AfiliadoRut", AfiliadoRut);
            return DBHelper.InstanceCRM.ObtenerColeccion("spMotor_NotificacionAsignacion_Listar", parametro , ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static NotificacionAsignacionEntity ConstructorEntidad(DataRow row)
        {
            return new NotificacionAsignacionEntity
            {
                AfiliadoRut = row["AfiliadoRut"] != DBNull.Value ? row["AfiliadoRut"].ToString() : string.Empty,
                Tipo = row["Tipo"] != DBNull.Value ? row["Tipo"].ToString() : string.Empty,
                Valor = row["Valor"] != DBNull.Value ? row["Valor"].ToString() : string.Empty,
                Cantidad = row["Cantidad"] != DBNull.Value ? Convert.ToInt32(row["Cantidad"]) : 0,
            };
        }
        #endregion
    }
}
