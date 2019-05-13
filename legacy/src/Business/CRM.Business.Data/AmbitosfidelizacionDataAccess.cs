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
    /// Clase Acceso de Datos AmbitosfidelizacionDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>02-04-2018 13:00:07</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class AmbitosfidelizacionDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="AmbitosfidelizacionEntity"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 13:00:07</created>
        /// <param name="ambitosfidelizacion">Referencia a una clase <see cref="AmbitosfidelizacionEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(AmbitosfidelizacionEntity ambitosfidelizacion)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@afid_id", ambitosfidelizacion.afid_id),
                new Parametro("@ambito_id", ambitosfidelizacion.ambito_id),
                new Parametro("@fidelizacion_id", ambitosfidelizacion.fidelizacion_id),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("empresas.spEmp_Ambitosfidelizacion_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="AmbitosfidelizacionEntity"/> de la Base de Datos dado un ID de AmbitosfidelizacionEntity
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 13:00:07</created>
        /// <param name="afid_id">ID de AmbitosfidelizacionEntity.</param>
        /// <returns>Referencia a una clase <see cref="AmbitosfidelizacionEntity"/>.</returns>
        public static AmbitosfidelizacionEntity ObtenerPorID(int afid_id)
        {
            Parametro parametro = new Parametro("@afid_id", afid_id);

            return DBHelper.InstanceCRM.ObtenerEntidad("empresas.spEmp_Ambitosfidelizacion_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="AmbitosfidelizacionEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 13:00:07</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("empresas.spEmp_Ambitosfidelizacion_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="AmbitosfidelizacionEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 13:00:07</created>
        /// <returns>Lista con todas las entidades <see cref="AmbitosfidelizacionEntity"/>.</returns>
        public static List<AmbitosfidelizacionEntity> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("empresas.spEmp_Ambitosfidelizacion_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        /// <summary>
        /// Recupera todas las entidades <see cref="AmbitosfidelizacionEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>02-04-2018 13:00:07</created>
        /// <returns>Lista con todas las entidades <see cref="AmbitosfidelizacionEntity"/>.</returns>
        public static void EliminarByFidelizacion(int idFidelizacion)
        {
            DBHelper.InstanceCRM.EjecutarProcedimiento("empresas.spEmp_Ambitosfidelizacion_Eliminar", new Parametro("@IdFidelizacion", idFidelizacion));
        }


        #endregion

        #region constructor
        private static AmbitosfidelizacionEntity ConstructorEntidad(DataRow row)
        {
            return new AmbitosfidelizacionEntity
            {
                afid_id = row["afid_id"] != DBNull.Value ? Convert.ToInt32(row["afid_id"]) : 0,
                ambito_id = row["ambito_id"] != DBNull.Value ? Convert.ToInt32(row["ambito_id"]) : 0,
                fidelizacion_id = row["fidelizacion_id"] != DBNull.Value ? Convert.ToInt32(row["fidelizacion_id"]) : 0,

            };
        }
        #endregion
    }
}
