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
    /// Clase Acceso de Datos AgendaDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>15-03-2018 10:06:04</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class AgendaDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="AgendaEntity"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>15-03-2018 10:06:04</created>
        /// <param name="agenda">Referencia a una clase <see cref="AgendaEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(AgendaEntity agenda)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@age_id", agenda.age_id),
                new Parametro("@encabezado_id", agenda.encabezado_id),
                new Parametro("@fecha", agenda.fecha),
                new Parametro("@estamento", agenda.estamento),
                new Parametro("@nombre_funcionario", agenda.nombre_funcionario),
                new Parametro("@cargo_funcionario", agenda.cargo_funcionario),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("fichas.spFicha_Agenda_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="AgendaEntity"/> de la Base de Datos dado un ID de AgendaEntity
        /// </summary>
        /// <author>@Charly</author>
        /// <created>15-03-2018 10:06:04</created>
        /// <param name="age_id">ID de AgendaEntity.</param>
        /// <returns>Referencia a una clase <see cref="AgendaEntity"/>.</returns>
        public static AgendaEntity ObtenerPorID(int age_id)
        {
            Parametro parametro = new Parametro("@age_id", age_id);

            return DBHelper.InstanceCRM.ObtenerEntidad("fichas.spFicha_Agenda_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="AgendaEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>15-03-2018 10:06:04</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("fichas.spFicha_Agenda_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="AgendaEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>15-03-2018 10:06:04</created>
        /// <returns>Lista con todas las entidades <see cref="AgendaEntity"/>.</returns>
        public static List<AgendaEntity> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("fichas.spFicha_Agenda_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static AgendaEntity ConstructorEntidad(DataRow row)
        {
            return new AgendaEntity
            {
                age_id = row["age_id"] != DBNull.Value ? Convert.ToInt32(row["age_id"]) : 0,
                encabezado_id = row["encabezado_id"] != DBNull.Value ? Convert.ToInt32(row["encabezado_id"]) : 0,
                fecha = row["fecha"] != DBNull.Value ? Convert.ToDateTime(row["fecha"]) : new DateTime(1900, 1, 1),
                estamento = row["estamento"] != DBNull.Value ? row["estamento"].ToString() : string.Empty,
                nombre_funcionario = row["nombre_funcionario"] != DBNull.Value ? row["nombre_funcionario"].ToString() : string.Empty,
                cargo_funcionario = row["cargo_funcionario"] != DBNull.Value ? row["cargo_funcionario"].ToString() : string.Empty,

            };
        }
        #endregion
    }
}
