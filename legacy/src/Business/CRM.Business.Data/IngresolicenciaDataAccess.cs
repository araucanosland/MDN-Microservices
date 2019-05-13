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
    /// Clase Acceso de Datos IngresolicenciaDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>28-09-2017 16:35:13</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class IngresolicenciaDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="Ingresolicencia"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>28-09-2017 16:35:13</created>
        /// <param name="ingresolicencia">Referencia a una clase <see cref="Ingresolicencia"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static long Guardar(Ingresolicencia ingresolicencia, string Token)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@CodIngreso", ingresolicencia.CodIngreso),
                new Parametro("@RutAfiliado", ingresolicencia.RutAfiliado),
                new Parametro("@NombreAfiliado", ingresolicencia.NombreAfiliado),
                new Parametro("@SinDatosEnSistema", ingresolicencia.SinDatosEnSistema),
                new Parametro("@FormatoLM",ingresolicencia.FormatoLM),
                new Parametro("@FolioLicencia", ingresolicencia.FolioLicencia),
                new Parametro("@Oficina", ingresolicencia.Oficina),
                new Parametro("@Token", Token),
                new Parametro("@CodEstado", ingresolicencia.CodEstado),
                new Parametro("@FechaIngreso", ingresolicencia.FechaIngreso),
                new Parametro("@OficinaDerivacion", ingresolicencia.OficinaDerivacion)
                //

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<long>("licencias.sp_Lic_Ingresolicencia_Guardar", parametros);
        }
        public static long GuardaDerivacion(Ingresolicencia derivacion, string token)
        {
            Parametros parametros = new Parametros
            {

                new Parametro("@Token",token),
                new Parametro("@RutAfiliado",derivacion.RutAfiliado),
                new Parametro("@FolioLicencia",derivacion.FolioLicencia)
            };

            return DBHelper.InstanceCRM.ObtenerEscalar<long>("licencias.sp_Lic_Ingresolicencia_ActualizarDerivacion", parametros);
        }


        /// <summary>
        /// Guarda la entidad de dominio <see cref="Ingresolicencia"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>28-09-2017 16:35:13</created>
        /// <param name="ingresolicencia">Referencia a una clase <see cref="Ingresolicencia"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static long Eliminar(int CodIngreso, string Token)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@Token", Token),
                new Parametro("@CodIngreso", CodIngreso)
            };

            return DBHelper.InstanceCRM.ObtenerEscalar<long>("licencias.sp_Lic_Ingresolicencia_Eliminar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="Ingresolicencia"/> de la Base de Datos dado un ID de Ingresolicencia
        /// </summary>
        /// <author>@Charly</author>
        /// <created>28-09-2017 16:35:13</created>
        /// <param name="CodIngreso">ID de Ingresolicencia.</param>
        /// <returns>Referencia a una clase <see cref="Ingresolicencia"/>.</returns>
        public static Ingresolicencia ObtenerPorID(long CodIngreso)
        {
            Parametro parametro = new Parametro("@CodIngreso", CodIngreso);

            return DBHelper.InstanceCRM.ObtenerEntidad("licencias.sp_Lic_Ingresolicencia_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="Ingresolicencia"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>28-09-2017 16:35:13</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("licencias.sp_Lic_Ingresolicencia_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="Ingresolicencia"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>28-09-2017 16:35:13</created>
        /// <returns>Lista con todas las entidades <see cref="Ingresolicencia"/>.</returns>
        public static List<Ingresolicencia> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("licencias.sp_Lic_Ingresolicencia_Listar", ConstructorEntidad);
        }


        /// <summary>
        /// Recupera todas las entidades <see cref="Ingresolicencia"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>28-09-2017 16:35:13</created>
        /// <returns>Lista con todas las entidades <see cref="Ingresolicencia"/>.</returns>
        public static List<Ingresolicencia> ObtenerEntidadesByOficina(int CodOficina, DateTime Dia)
        {
            Parametros parametros = new Parametros()
            {
                new Parametro("@CodOficina", CodOficina),
                new Parametro("@Dia", Dia),
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("licencias.sp_Lic_Ingresolicencia_ListarByOficina", parametros, ConstructorEntidad);
        }

        public static Ingresolicencia ObtenerEncabezado(int CodOficina, DateTime Dia)
        {
            Parametros parametros = new Parametros()
            {
                new Parametro("@CodOficina", CodOficina),
                new Parametro("@Dia", Dia),
            };
            return DBHelper.InstanceCRM.ObtenerEntidad("licencias.sp_Lic_Ingresolicencia_ListarResumenEncabezado", parametros, EntidadEncabezado);
        }



        /// <summary>
        /// Recupera todas las entidades <see cref="Ingresolicencia"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>28-09-2017 16:35:13</created>
        /// <returns>Lista con todas las entidades <see cref="Ingresolicencia"/>.</returns>
        public static DataTable ObtenerEntidadesByOficinaXLS(int CodOficina, DateTime Dia)
        {
            Parametros parametros = new Parametros()
            {
                new Parametro("@CodOficina", CodOficina),
                new Parametro("@Dia", Dia),
            };
            return DBHelper.InstanceCRM.ObtenerDataTable("licencias.sp_Lic_Ingresolicencia_OficinaXLS", parametros);
        }

        public static DataTable ObtenerEntidadesByOficinaPdf(int CodOficina, DateTime Dia)
        {
            Parametros parametros = new Parametros()
            {
                new Parametro("@CodOficina", CodOficina),
                new Parametro("@Dia", Dia),
            };
            return DBHelper.InstanceCRM.ObtenerDataTable("licencias.sp_Lic_Ingresolicencia_OficinaPDF", parametros);
        }


        public static DataTable ObtenerEntidadesByOficinaPdf_Mixta(int CodOficina, DateTime Dia)
        {
            Parametros parametros = new Parametros()
            {
                new Parametro("@CodOficina", CodOficina),
                new Parametro("@Dia", Dia),
            };
            return DBHelper.InstanceCRM.ObtenerDataTable("licencias.sp_Lic_Ingresolicencia_Oficina_MixtaPDF", parametros);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static Ingresolicencia ConstructorEntidad(DataRow row)
        {
            return new Ingresolicencia
            {
                CodIngreso = row["CodIngreso"] != DBNull.Value ? Convert.ToInt64(row["CodIngreso"]) : 0,
                RutAfiliado = row["RutAfiliado"] != DBNull.Value ? row["RutAfiliado"].ToString() : string.Empty,
                NombreAfiliado = row["NombreAfiliado"] != DBNull.Value ? row["NombreAfiliado"].ToString() : string.Empty,
                FolioLicencia = row["FolioLicencia"] != DBNull.Value ? row["FolioLicencia"].ToString() : string.Empty,
                Oficina = row["Oficina"] != DBNull.Value ? Convert.ToInt32(row["Oficina"]) : 0,
                RutEjecutivo = row["RutEjecutivo"] != DBNull.Value ? row["RutEjecutivo"].ToString() : string.Empty,
                CodEstado = row["CodEstado"] != DBNull.Value ? Convert.ToInt32(row["CodEstado"]) : 0,
                FechaIngreso = row["FechaIngreso"] != DBNull.Value ? Convert.ToDateTime(row["FechaIngreso"]) : new DateTime(1900, 1, 1),
                FormatoLM = row["FormatoLM"] != DBNull.Value ? row["FormatoLM"].ToString() : string.Empty,
                FlagLM = row["FlagLM"] != DBNull.Value ? row["FlagLM"].ToString() : string.Empty,
                OficinaDerivacion= row["OficinaDerivada"] != DBNull.Value ? Convert.ToInt32(row["OficinaDerivada"]) : 0,

            };
        }
        private static Ingresolicencia EntidadEncabezado(DataRow row)
        {
            return new Ingresolicencia
            {
                //Lm_Total = row["FolioMotor"] != DBNull.Value ? Convert.ToInt32(row["FolioMotor"]) : 0,
                Lm_Verde = row["1"] != DBNull.Value ? Convert.ToInt32(row["1"]) : 0,
                Lm_Amarillo = row["2"] != DBNull.Value ? Convert.ToInt32(row["2"]) : 0,
                Lm_Rojo = row["3"] != DBNull.Value ? Convert.ToInt32(row["3"]) : 0,
                Lm_Naranjo= row["4"] != DBNull.Value ? Convert.ToInt32(row["4"]) : 0,
                Lm_Actualizacion = row["Actualizacion"] != DBNull.Value ? row["Actualizacion"].ToString() : string.Empty

            };
        }
        #endregion
    }
}
