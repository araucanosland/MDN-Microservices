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
    /// Clase Acceso de Datos SucursalDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>16-05-2017 16:47:26</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class SucursalDataAccess
    {
        #region metodos base

        /// <summary>
        /// Recupera una entidad <see cref="NotificacionAsignacionEntity"/> de la Base de Datos dado un ID de NotificacionAsignacionEntity
        /// </summary>
        /// <author>@Charly</author>
        /// <created>16-05-2017 16:47:26</created>
        /// <param name="AfiliadoRut">ID de NotificacionAsignacionEntity.</param>
        /// <returns>Referencia a una clase <see cref="NotificacionAsignacionEntity"/>.</returns>
        public static SucursalEntity ObtenerSucursal(int Codigo)
        {
            return ListarSucursales().Find(x => x.Id == Codigo);
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="NotificacionAsignacionEntity"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>16-05-2017 16:47:26</created>
        
        public static List<SucursalEntity> ListarSucursales()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("spMotor_Sucursales_Listar", ConstructorEntidad);
        }

        public static List<SucursalAdminEntity>ListarSucursalAdmin()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("spMotor_ListaSucursalDotAdmin",EntidadAdmin);
        }

        #endregion

        #region metodos adicionales
        #endregion

        #region constructor
        private static SucursalEntity ConstructorEntidad(DataRow row)
        {
            return new SucursalEntity
            {
                Id = row["Cod_Oficina"] != DBNull.Value ? Convert.ToInt32(row["Cod_Oficina"]) : 0,
                Nombre = row["Oficina"] != DBNull.Value ? row["Oficina"].ToString() : string.Empty,
            };
        }
        private static SucursalAdminEntity EntidadAdmin(DataRow row)
        {
            return new SucursalAdminEntity
            {
                CodOficina              = row["Cod_Sucursal"] != DBNull.Value ? Convert.ToInt32(row["Cod_Sucursal"]) : 0,
                Sucursal                = row["Sucursal"] != DBNull.Value ? row["Sucursal"].ToString() : string.Empty,
                NumeroActivo            =row["NumeroActivo"] !=DBNull.Value? Convert.ToInt32(row["NumeroActivo"]):0,
                PorcentajeActivo        =row["PorcentajeActivo"] !=DBNull.Value? Convert.ToInt32(row["PorcentajeActivo"]):0,
                nroLicencia             =row["NroLicencia"]!=DBNull.Value? Convert.ToInt32(row["NroLicencia"]):0,
                porcentajeLicencia      =row["PorcentajeLicencia"]!=DBNull.Value? Convert.ToInt32(row["PorcentajeLicencia"]):0,
                nroPermiso              =row["NroPermiso"]!=DBNull.Value? Convert.ToInt32(row["NroPermiso"]):0,
                porcentajePermiso       =row["PorcentajePermiso"]!=DBNull.Value? Convert.ToInt32(row["PorcentajePermiso"]):0,
                nroVacaciones           =row["NroVacaciones"]!=DBNull.Value? Convert.ToInt32(row["NroVacaciones"]):0,
                porcentajeVacaciones    =row["PorcentajeVacaciones"]!=DBNull.Value? Convert.ToInt32(row["PorcentajeVacaciones"]):0,
                nroCapacitacion         =row["NroCapacitacion"]!=DBNull.Value? Convert.ToInt32(row["NroCapacitacion"]):0,
                porcentajeCapaciontacion=row["PorcentajeCapacitacion"]!=DBNull.Value? Convert.ToInt32(row["PorcentajeCapacitacion"]):0, 
                nroComision             =row["NroComision"]!=DBNull.Value? Convert.ToInt32(row["NroComision"]):0, 
                porcentajeComision      =row["PorcentajeComision"]!=DBNull.Value? Convert.ToInt32(row["PorcentajeComision"]):0,
                nroDesvinculacion       =row["NroDesvinculacion"]!=DBNull.Value? Convert.ToInt32(row["NroDesvinculacion"]):0, 
                porcentajeDesvinculacion=row["PorcentajeDesvinculacion"]!=DBNull.Value? Convert.ToInt32(row["PorcentajeDesvinculacion"]):0, 
                nroTotal                =row["NroTotal"]!=DBNull.Value? Convert.ToInt32(row["NroTotal"]):0, 
                porcentajeTotal         =row["PorcentajeTotal"]!=DBNull.Value? Convert.ToInt32(row["PorcentajeTotal"]):0
            };
        }
        
        #endregion
    }
}
