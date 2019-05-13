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
    /// Clase Acceso de Datos ContactoafiliadoDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>04-05-2017 18:31:36</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class ContactoafiliadoDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="ContactoafiliadoEntity"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>04-05-2017 18:31:36</created>
        /// <param name="contactoafiliado">Referencia a una clase <see cref="ContactoafiliadoEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(ContactoafiliadoEntity contactoafiliado)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@Afiliado_rut", contactoafiliado.Afiliado_rut),
                new Parametro("@Fecha_accion", contactoafiliado.Fecha_accion),
                new Parametro("@Tipo_contacto", contactoafiliado.Tipo_contacto),
                new Parametro("@Valor_contacto", contactoafiliado.Valor_contacto),
                new Parametro("@Valido", contactoafiliado.Valido),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("spMotor_Contactoafiliado_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="ContactoafiliadoEntity"/> de la Base de Datos dado un ID de ContactoafiliadoEntity
        /// </summary>
        /// <author>@Charly</author>
        /// <created>04-05-2017 18:31:36</created>
        /// <param name="Afiliado_rut">ID de ContactoafiliadoEntity.</param>
        /// <returns>Referencia a una clase <see cref="ContactoafiliadoEntity"/>.</returns>
        public static List<ContactoafiliadoEntity> ObtenerPorRutAfiliadoYTipo(int Afiliado_rut, string Tipo)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@Afiliado_rut", Afiliado_rut),
                new Parametro("@Tipo", Tipo),
            }; 

            return DBHelper.InstanceCRM.ObtenerColeccion("spMotor_Contactoafiliado_Obtener", parametros, ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        /// <summary>
        /// Recupera una entidad <see cref="ContactoafiliadoEntity"/> de la Base de Datos dado un ID de ContactoafiliadoEntity
        /// </summary>
        /// <author>@Charly</author>
        /// <created>04-05-2017 18:31:36</created>
        /// <param name="Afiliado_rut">ID de ContactoafiliadoEntity.</param>
        /// <returns>Referencia a una clase <see cref="ContactoafiliadoEntity"/>.</returns>
        public static ContactoafiliadoEntity Obtener(int Afiliado_rut, string valor)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@Afiliado_rut", Afiliado_rut),
                new Parametro("@Valor", valor),
            };

            return DBHelper.InstanceCRM.ObtenerEntidad("spMotor_Contactoafiliado_ObtenerUnico", parametros, ConstructorEntidad);
        }


        #endregion

        #region constructor
        private static ContactoafiliadoEntity ConstructorEntidad(DataRow row)
        {
            return new ContactoafiliadoEntity
            {
                Afiliado_rut = row["Afiliado_rut"] != DBNull.Value ? Convert.ToInt32(row["Afiliado_rut"]) : 0,
                Fecha_accion = row["Fecha_accion"] != DBNull.Value ? Convert.ToDateTime(row["Fecha_accion"]) : new DateTime(1900, 1, 1),
                Tipo_contacto = row["Tipo_contacto"] != DBNull.Value ? row["Tipo_contacto"].ToString() : string.Empty,
                Valor_contacto = row["Valor_contacto"] != DBNull.Value ? row["Valor_contacto"].ToString() : string.Empty,
                Valido = row["Valido"] != DBNull.Value ? Convert.ToInt16(row["Valido"]) : (short)0,
                Fecha_contacto = row["Fecha_contacto"] != DBNull.Value ? Convert.ToDateTime(row["Fecha_contacto"]) : new DateTime(1900, 1, 1),
            };
        }
        #endregion
    }
}
