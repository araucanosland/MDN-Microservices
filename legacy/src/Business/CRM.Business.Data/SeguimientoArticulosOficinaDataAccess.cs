using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CRM.Business.Entity;
using CDK.Integration;
using CDK.Data;


namespace CRM.Business.Data
{
    public class SeguimientoArticulosOficinaDataAccess
    {

        /// <summary>
        /// Guarda la entidad de dominio <see cref="ContactoafiliadoEntity"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>04-05-2017 18:31:36</created>
        /// <param name="contactoafiliado">Referencia a una clase <see cref="ContactoafiliadoEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int GuardarSeguimientoCamaras(string Token, string Estado, string Comentarios = "")
        {
            Parametros param = new Parametros
            {
                new Parametro("@NombreArticulo", "Camaras"),
                new Parametro("@token", Token),
                new Parametro("@Estado", Estado),
                new Parametro("@Comentarios", Comentarios)
            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("dbo.spMotor_SeguimientoAtriculo_Guardar", param);
        }


        public static SeguimientoArticulosOficinaEntity ObtenerPorOficina(string token)
        {
            Parametro param = new Parametro("@Token", token);
            return DBHelper.InstanceCRM.ObtenerEntidad("dbo.spMotor_SeguimientoAtriculo_Obtener",param, ConstructorEntidad);

        }


        #region constructor
        private static SeguimientoArticulosOficinaEntity ConstructorEntidad(DataRow row)
        {
            return new SeguimientoArticulosOficinaEntity
            {
                IdSeguimiento = row["IdSeguimiento"] != DBNull.Value ? Convert.ToInt32(row["IdSeguimiento"]) : 0,
                FechaRegistro = row["FechaRegistro"] != DBNull.Value ? Convert.ToDateTime(row["FechaRegistro"]) : new DateTime(1900, 1, 1),
                Oficina = row["Oficina"] != DBNull.Value ? Convert.ToInt32(row["Oficina"]) : 0,
                Nombre = row["Nombre"] != DBNull.Value ? row["Nombre"].ToString() : string.Empty,
                Comentarios = row["Comentarios"] != DBNull.Value ? row["Comentarios"].ToString() : string.Empty,
                EstadoArticulo = row["EstadoArticulo"] != DBNull.Value ? row["EstadoArticulo"].ToString() : string.Empty,
            };
        }
        #endregion

    }
}
