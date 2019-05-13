using System;
using System.Collections.Generic;
using System.Data;
using CRM.Business.Entity;
using CDK.Integration;
using CDK.Data;

namespace CRM.Business.Data
{
    public class ConfirmDotacionDataAccess
    {

        /// <summary>
        /// Guarda la entidad de dominio <see cref="ContactoafiliadoEntity"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>04-05-2017 18:31:36</created>
        /// <param name="contactoafiliado">Referencia a una clase <see cref="ContactoafiliadoEntity"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(string Token)
        {
            Parametro param = new Parametro("@Token", Token);
            return DBHelper.InstanceCRM.ObtenerEscalar<int>("dbo.spMotor_ConfDotacion_Guardar", param);
        }

        

        #region constructor
        private static ConfirmDotacion ConstructorEntidad(DataRow row)
        {
            return new ConfirmDotacion
            {
                EjecutivoRut = row["EjecutivoRut"] != DBNull.Value ? row["EjecutivoRut"].ToString() : string.Empty,
                Fecha = row["Fecha"] != DBNull.Value ? Convert.ToDateTime(row["Fecha"]) : new DateTime(1900, 1, 1),
            };
        }
        #endregion
    }
}
