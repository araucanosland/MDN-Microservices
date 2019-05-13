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
    /// Clase Acceso de Datos ContactoDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>06-03-2018 17:58:02</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class ContactoDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="ContactoEntity"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>06-03-2018 17:58:02</created>
        /// <param name="contacto">Referencia a una clase <see cref="ContactoEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(ContactoEntity contacto)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@cnt_id", contacto.cnt_id),
                new Parametro("@encabezado_id", contacto.encabezado_id),
                new Parametro("@nombre", contacto.nombre),
                new Parametro("@telefono", contacto.telefono),
                new Parametro("@email", contacto.email),
                new Parametro("@direccion", contacto.direccion),
                new Parametro("@compromisos", contacto.compromisos),
                new Parametro("@tipo", contacto.tipo),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("fichas.spFicha_Contacto_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="ContactoEntity"/> de la Base de Datos dado un ID de ContactoEntity
        /// </summary>
        /// <author>@Charly</author>
        /// <created>06-03-2018 17:58:02</created>
        /// <param name="cnt_id">ID de ContactoEntity.</param>
        /// <returns>Referencia a una clase <see cref="ContactoEntity"/>.</returns>
        public static ContactoEntity ObtenerPorID(int cnt_id)
        {
            Parametro parametro = new Parametro("@cnt_id", cnt_id);

            return DBHelper.InstanceCRM.ObtenerEntidad("fichas.spFicha_Contacto_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="ContactoEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>06-03-2018 17:58:02</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("fichas.spFicha_Contacto_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="ContactoEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>06-03-2018 17:58:02</created>
        /// <returns>Lista con todas las entidades <see cref="ContactoEntity"/>.</returns>
        public static List<ContactoEntity> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("fichas.spFicha_Contacto_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static ContactoEntity ConstructorEntidad(DataRow row)
        {
            return new ContactoEntity
            {
                cnt_id = row["cnt_id"] != DBNull.Value ? Convert.ToInt32(row["cnt_id"]) : 0,
                encabezado_id = row["encabezado_id"] != DBNull.Value ? Convert.ToInt32(row["encabezado_id"]) : 0,
                nombre = row["nombre"] != DBNull.Value ? row["nombre"].ToString() : string.Empty,
                telefono = row["telefono"] != DBNull.Value ? Convert.ToInt32(row["telefono"]) : 0,
                email = row["email"] != DBNull.Value ? row["email"].ToString() : string.Empty,
                direccion = row["direccion"] != DBNull.Value ? row["direccion"].ToString() : string.Empty,
                compromisos = row["compromisos"] != DBNull.Value ? row["compromisos"].ToString() : string.Empty,
                tipo = row["tipo"] != DBNull.Value ? row["tipo"].ToString() : string.Empty,
            };
        }
        #endregion
    }
}
