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
    /// Clase Acceso de Datos NuberespuestasDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>07-03-2018 10:56:52</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class NuberespuestasDataAccess
    {
        #region metodos base

        /// <summary>
        /// Guarda la entidad de dominio <see cref="NuberespuestasEntity"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>07-03-2018 10:56:52</created>
        /// <param name="nuberespuestas">Referencia a una clase <see cref="NuberespuestasEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(NuberespuestasEntity nuberespuestas)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@nresp_id", nuberespuestas.nresp_id),
                new Parametro("@despriccion", nuberespuestas.despriccion),
                new Parametro("@valor", nuberespuestas.valor),
                new Parametro("@tag", nuberespuestas.tag),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("fichas.spFicha_Nuberespuestas_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="NuberespuestasEntity"/> de la Base de Datos dado un ID de NuberespuestasEntity
        /// </summary>
        /// <author>@Charly</author>
        /// <created>07-03-2018 10:56:52</created>
        /// <param name="nresp_id">ID de NuberespuestasEntity.</param>
        /// <returns>Referencia a una clase <see cref="NuberespuestasEntity"/>.</returns>
        public static NuberespuestasEntity ObtenerPorID(int nresp_id)
        {
            Parametro parametro = new Parametro("@nresp_id", nresp_id);

            return DBHelper.InstanceCRM.ObtenerEntidad("fichas.spFicha_Nuberespuestas_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="NuberespuestasEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>07-03-2018 10:56:52</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("fichas.spFicha_Nuberespuestas_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="NuberespuestasEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>07-03-2018 10:56:52</created>
        /// <returns>Lista con todas las entidades <see cref="NuberespuestasEntity"/>.</returns>
        public static List<NuberespuestasEntity> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("fichas.spFicha_Nuberespuestas_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static NuberespuestasEntity ConstructorEntidad(DataRow row)
        {
            return new NuberespuestasEntity
            {
                nresp_id = row["nresp_id"] != DBNull.Value ? Convert.ToInt32(row["nresp_id"]) : 0,
                despriccion = row["despriccion"] != DBNull.Value ? row["despriccion"].ToString() : string.Empty,
                valor = row["valor"] != DBNull.Value ? row["valor"].ToString() : string.Empty,
                tag = row["tag"] != DBNull.Value ? row["tag"].ToString() : string.Empty,

            };
        }
        #endregion
    }
}
