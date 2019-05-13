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
    /// Clase Acceso de Datos AusenciaDataAccess
    /// </summary>
    /// <author>Carlos Pradenas</author>
    /// <created>27-06-2017 23:59:04</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class AusenciaDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="AusenciaEntity"/> en la Base de Datos
        /// </summary>
        /// <author>Carlos Pradenas</author>
        /// <created>27-06-2017 23:59:04</created>
        /// <param name="ausencia">Referencia a una clase <see cref="AusenciaEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(AusenciaEntity ausencia)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@aus_id", ausencia.aus_id),
                new Parametro("@ejec_rut", ausencia.ejec_rut),
                new Parametro("@aus_fecha_inicio", ausencia.aus_fecha_inicio),
                new Parametro("@aus_fecha_fin", ausencia.aus_fecha_fin),
                new Parametro("@tipo_ausencia_id", ausencia.tipo_ausencia_id),
                new Parametro("@aus_cantidad_dias", ausencia.aus_cantidad_dias),
                new Parametro("@aus_comentarios", ausencia.aus_comentarios),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("spMotor_Ausencia_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="AusenciaEntity"/> de la Base de Datos dado un ID de AusenciaEntity
        /// </summary>
        /// <author>Carlos Pradenas</author>
        /// <created>27-06-2017 23:59:04</created>
        /// <param name="aus_id">ID de AusenciaEntity.</param>
        /// <returns>Referencia a una clase <see cref="AusenciaEntity"/>.</returns>
        public static AusenciaEntity ObtenerPorID(int aus_id)
        {
            Parametro parametro = new Parametro("@aus_id", aus_id);

            return DBHelper.InstanceCRM.ObtenerEntidad("spMotor_Ausencia_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="AusenciaEntity"/> de la Base de Datos
        /// </summary>
        /// <author>Carlos Pradenas</author>
        /// <created>27-06-2017 23:59:04</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("spMotor_Ausencia_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="AusenciaEntity"/> de la Base de Datos
        /// </summary>
        /// <author>Carlos Pradenas</author>
        /// <created>27-06-2017 23:59:04</created>
        /// <returns>Lista con todas las entidades <see cref="AusenciaEntity"/>.</returns>
        public static List<AusenciaEntity> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("spMotor_Ausencia_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales

        /// <summary>
        /// Recupera todas las entidades <see cref="AusenciaEntity"/> de la Base de Datos
        /// </summary>
        /// <author>Carlos Pradenas</author>
        /// <created>27-06-2017 23:59:04</created>
        /// <returns>Lista con todas las entidades <see cref="AusenciaEntity"/>.</returns>
        public static List<AusenciaEntity> ObtenerMensual(int periodo, string rutEjecutivo)
        {
            Parametros par = new Parametros
            {
                new Parametro("@Periodo", periodo),
                new Parametro("@RutEjec", rutEjecutivo),
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("spMotor_Ausencia_ListarMes", par, ConstructorEntidad);
        }


        public static bool RegistraReemplazo(string EjecutivoRut)
        {
            Parametro p = new Parametro("@RutE", EjecutivoRut);
            string query = @"select count(*) existe from dbo.TabMotor_MarcaReemplazo where EjecutivoRut = @RutE";

            return DBHelper.InstanceCRM.ObtenerEscalarFromSql<bool>(query, p);
        }
        #endregion

        #region constructor
        private static AusenciaEntity ConstructorEntidad(DataRow row)
        {
            return new AusenciaEntity
            {
                aus_id = row["aus_id"] != DBNull.Value ? Convert.ToInt32(row["aus_id"]) : 0,
                ejec_rut = row["ejec_rut"] != DBNull.Value ? row["ejec_rut"].ToString() : string.Empty,
                aus_fecha_inicio = row["aus_fecha_inicio"] != DBNull.Value ? Convert.ToDateTime(row["aus_fecha_inicio"]) : new DateTime(1900, 1, 1),
                aus_fecha_fin = row["aus_fecha_fin"] != DBNull.Value ? Convert.ToDateTime(row["aus_fecha_fin"]) : new DateTime(1900, 1, 1),
                tipo_ausencia_id = row["tipo_ausencia_id"] != DBNull.Value ? Convert.ToInt32(row["tipo_ausencia_id"]) : 0,
                aus_cantidad_dias = row["aus_cantidad_dias"] != DBNull.Value ? Convert.ToInt32(row["aus_cantidad_dias"]) : 0,
                aus_comentarios = row["aus_comentarios"] != DBNull.Value ? row["aus_comentarios"].ToString() : string.Empty,
                aus_marca_ausencia = row["aus_marca_ausencia"] != DBNull.Value ? Convert.ToBoolean(row["aus_marca_ausencia"]) : false,

            };
        }
        #endregion
    }
}
