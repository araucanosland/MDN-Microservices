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
    /// Clase Acceso de Datos EncabezadoDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>07-03-2018 10:53:58</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class EncabezadoDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="EncabezadoEntity"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>07-03-2018 10:53:58</created>
        /// <param name="encabezado">Referencia a una clase <see cref="EncabezadoEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(EncabezadoEntity encabezado)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@enc_id", encabezado.enc_id),
                new Parametro("@cuestionario_id", encabezado.cuestionario_id),
                new Parametro("@rut_empresa", encabezado.rut_empresa),
                new Parametro("@estamento", encabezado.estamento),
                new Parametro("@nombre_funcionario", encabezado.nombre_funcionario),
                new Parametro("@cargo_funcionario", encabezado.cargo_funcionario),
                new Parametro("@cantidad_empleados", encabezado.cantidad_empleados),
                new Parametro("@cod_sucursal", encabezado.cod_sucursal),
                new Parametro("@rut_ejecutivo", encabezado.rut_ejecutivo),
                new Parametro("@fecha_entrevista", encabezado.fecha_entrevista),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("fichas.spFicha_Encabezado_Guardar", parametros);
        }


        /// <summary>
        /// Guarda la entidad de dominio <see cref="EncabezadoEntity"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>07-03-2018 10:53:58</created>
        /// <param name="encabezado">Referencia a una clase <see cref="EncabezadoEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int GuardarNombre(EncabezadoEntity encabezado)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@enc_id", encabezado.enc_id),
                new Parametro("@nombre_empresa", encabezado.nombre_empresa),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("fichas.spFicha_Encabezado_GuardarNombre", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="EncabezadoEntity"/> de la Base de Datos dado un ID de EncabezadoEntity
        /// </summary>
        /// <author>@Charly</author>
        /// <created>07-03-2018 10:53:58</created>
        /// <param name="enc_id">ID de EncabezadoEntity.</param>
        /// <returns>Referencia a una clase <see cref="EncabezadoEntity"/>.</returns>
        public static EncabezadoEntity ObtenerPorID(int enc_id)
        {
            Parametro parametro = new Parametro("@enc_id", enc_id);

            return DBHelper.InstanceCRM.ObtenerEntidad("fichas.spFicha_Encabezado_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="EncabezadoEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>07-03-2018 10:53:58</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("fichas.spFicha_Encabezado_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="EncabezadoEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>07-03-2018 10:53:58</created>
        /// <returns>Lista con todas las entidades <see cref="EncabezadoEntity"/>.</returns>
        public static List<EncabezadoEntity> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("fichas.spFicha_Encabezado_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static EncabezadoEntity ConstructorEntidad(DataRow row)
        {
            return new EncabezadoEntity
            {
                enc_id = row["enc_id"] != DBNull.Value ? Convert.ToInt32(row["enc_id"]) : 0,
                cuestionario_id = row["cuestionario_id"] != DBNull.Value ? Convert.ToInt32(row["cuestionario_id"]) : 0,
                rut_empresa = row["rut_empresa"] != DBNull.Value ? row["rut_empresa"].ToString() : string.Empty,
                estamento = row["estamento"] != DBNull.Value ? row["estamento"].ToString() : string.Empty,
                nombre_funcionario = row["nombre_funcionario"] != DBNull.Value ? row["nombre_funcionario"].ToString() : string.Empty,
                cargo_funcionario = row["cargo_funcionario"] != DBNull.Value ? row["cargo_funcionario"].ToString() : string.Empty,
                cantidad_empleados = row["cantidad_empleados"] != DBNull.Value ? Convert.ToInt32(row["cantidad_empleados"]) : 0,
                cod_sucursal = row["cod_sucursal"] != DBNull.Value ? Convert.ToInt32(row["cod_sucursal"]) : 0,
                rut_ejecutivo = row["rut_ejecutivo"] != DBNull.Value ? row["rut_ejecutivo"].ToString() : string.Empty,
                nombre_empresa = row["nombre_empresa"] != DBNull.Value ? row["nombre_empresa"].ToString() : string.Empty,
                fecha_entrevista = row["fecha_entrevista"] != DBNull.Value ? Convert.ToDateTime(row["fecha_entrevista"]) : DateTime.MinValue,
                fecha_actualizacion = row["fecha_actualizacion"] != DBNull.Value ? Convert.ToDateTime(row["fecha_actualizacion"]) : DateTime.MinValue,
                nombre_sucursal_empresa = row["nombre_sucursal_empresa"] != DBNull.Value ? row["nombre_sucursal_empresa"].ToString() : string.Empty,
            };
        }
        #endregion
    }
}
