using System;
using System.Collections.Generic;
using System.Data;
using CRM.Business.Entity;
using CDK.Integration;
using CDK.Data;
namespace CRM.Business.Data
{
    public class IngresoCarteraEmpresaDataAccess
    {
        public static long Guardar(IngresoCarteraEmpresa ingresocartera, string Token)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@IdEmpresaIngreso", ingresocartera.CodIngresoEmpresa),
                new Parametro("@Token", Token),
                new Parametro("@EmpresaRut", ingresocartera.RutEmpresa),
                new Parametro("@EmpresaNombre", ingresocartera.NombreEmpresa),
                new Parametro("@EmpresaTipoEjecutivo",ingresocartera.TipoEjectEmpresa),
                new Parametro("@EmpresaRutEjecutivo", ingresocartera.RutEjecutivo),
                new Parametro("@EmpresaNombreEjecutivo", ingresocartera.NombreEjecutivo)

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<long>("carteras.spMotorCarteraIngreso_Guardar", parametros);
        }
        public static IngresoCarteraEmpresa ObtenerPorID(int CodIngreso)
        {
            Parametro parametro = new Parametro("@CodIngreso", CodIngreso);

            return DBHelper.InstanceCRM.ObtenerEntidad("carteras.spMotorCarteraIngreso_ObtenerPorID", parametro, ConstructorEntidad);
        }
        public static int Eliminar(int CodIngreso)
        {
            Parametros parametros = new Parametros
            {
                
                new Parametro("@CodIngreso", CodIngreso)
            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("carteras.spMotorCarteraIngreso_Eliminar", parametros);
        }
        private static IngresoCarteraEmpresa ConstructorEntidad(DataRow row)
        {
            return new IngresoCarteraEmpresa
            {

                CodIngresoEmpresa = row["IdEmpresaIngreso"] != DBNull.Value ? Convert.ToInt32(row["IdEmpresaIngreso"]) : 0,
                RutEmpresa = row["EmpresaRut"] != DBNull.Value ? row["EmpresaRut"].ToString() : string.Empty,
                NombreEmpresa =row["EmpresaNombre"] != DBNull.Value ? row["EmpresaNombre"].ToString() : string.Empty,
                TipoEjectEmpresa = row["EmpresaTipoEjecutivo"] != DBNull.Value ? Convert.ToInt32(row["EmpresaTipoEjecutivo"]) : 0,
                RutEjecutivo = row["EmpresaRutEjecutivo"] != DBNull.Value ? row["EmpresaRutEjecutivo"].ToString() : string.Empty,
                NombreEjecutivo= row["EmpresaNombreEjecutivo"] != DBNull.Value ? row["EmpresaNombreEjecutivo"].ToString() : string.Empty,
            };
    }

}
    

    /// <summary>
    /// admin
    /// </summary>
    public class IngresoCarteraEmpresaAdminDataAccess
    {
        public static long Guardar(IngresoCarteraEmpresaAdmin ingresocartera, string Token)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@IdEmpresaIngreso", ingresocartera.CodIngresoEmpresa),
                new Parametro("@Token", Token),
                new Parametro("@EmpresaRut", ingresocartera.RutEmpresa),
                new Parametro("@EmpresaNombre", ingresocartera.NombreEmpresa),
                new Parametro("@NTrabajador", ingresocartera.nTrabajador),
                new Parametro("@EsHolding", ingresocartera.esHolding),
                new Parametro("@Comentarios", ingresocartera.Comentarios),


            };

            return DBHelper.InstanceCRM.ObtenerEscalar<long>("carteras.spMotorCarteraAdminIngreso_Guardar", parametros);
        }

        public static long GuardarAsignacion(string rut,long id)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@IdEmpresaIngreso", id ),
                new Parametro("@rutEjecutivo", rut),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<long>("carteras.spMotorCarteraAdminIngresoEjecutivo_Guardar", parametros);
        }

        public static IngresoCarteraEmpresaAdmin ObtenerPorID(int CodIngreso)
        {
            Parametro parametro = new Parametro("@CodIngreso", CodIngreso);

            return DBHelper.InstanceCRM.ObtenerEntidad("carteras.spMotorCarteraIngresoAdmin_ObtenerPorID", parametro, ConstructorEntidad);
        }
        public static int Eliminar(int CodIngreso)
        {
            Parametros parametros = new Parametros
            {

                new Parametro("@CodIngreso", CodIngreso)
            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("carteras.spMotorCarteraIngresoAdmin_Eliminar", parametros);
        }
        public static int Actualizar(int CodIngreso)
        {
            Parametros parametros = new Parametros
            {

                new Parametro("@CodIngreso", CodIngreso)
            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("carteras.spMotorCarteraAdminIngreso_UpdateAcepta", parametros);
        }
        private static IngresoCarteraEmpresaAdmin ConstructorEntidad(DataRow row)
        {
            return new IngresoCarteraEmpresaAdmin
            {

                CodIngresoEmpresa = row["IdEmpresaIngreso"] != DBNull.Value ? Convert.ToInt32(row["IdEmpresaIngreso"]) : 0,
                RutEmpresa = row["EmpresaRut"] != DBNull.Value ? row["EmpresaRut"].ToString() : string.Empty,
                NombreEmpresa = row["EmpresaNombre"] != DBNull.Value ? row["EmpresaNombre"].ToString() : string.Empty,
            };
        }
    }
}
