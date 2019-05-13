using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Business.Entity;
using System.Data;
using CDK.Data;
using CDK.Integration;



namespace CRM.Business.Data
{
    public static class DotacionDataAccess
    {
        public static DotacionEntity ObtenerByToken(string Token)
        {
            Parametro p = new Parametro("@Token", Token);
            return DBHelper.InstanceCRM.ObtenerEntidad("spMotor_ObtenerEjecutivoByToken", p, ConstructorEntidad);
        }

        public static DotacionEntity ObtenerByRut(string RutEjecutivo)
        {
            Parametro p = new Parametro("@RutEjecutivo", RutEjecutivo);
            return DBHelper.InstanceCRM.ObtenerEntidad("spMotor_ObtenerEjecutivoByRut", p, ConstructorEntidad);
        }

        public static List<DotacionEntity> MultiLoginByRut(string RutEjecutivo)
        {
            Parametro p = new Parametro("@RutEjecutivo", RutEjecutivo);
            return DBHelper.InstanceCRM.ObtenerColeccion("spMotor_ObtenerMultiByRut", p, ConstructorEntidad);
        }

        public static List<DotacionEntity> ListarMiOficina(string Token)
        {
            Parametro p = new Parametro("@Token", Token);
            return DBHelper.InstanceCRM.ObtenerColeccion("spMotor_ObtenerEjecutivosOficinaByToken", p, ConstructorEntidad);
        }

        public static List<DotacionEntity> ListarMiOficinaHistorica(string Token, int Periodo)
        {
            Parametros prms = new Parametros()
            {
                new Parametro("@Token", Token),
                new Parametro("@Periodo", Periodo),
            };
                
            return DBHelper.InstanceCRM.ObtenerColeccion("spMotor_ObtenerEjecutivosOficinaByTokenHistorica", prms, ConstructorEntidad);
        }


        public static List<DotacionEntity> ListarMiOficinaProyeccion(string Token, int Periodo)
        {
            Parametros prms = new Parametros()
            {
                new Parametro("@Token", Token),
                new Parametro("@Periodo", Periodo),
            };

            return DBHelper.InstanceCRM.ObtenerColeccion("spMotor_ObtenerEjecutivosOficinaByTokenProyeccion", prms, ConstructorEntidad);
        }

        public static List<DotacionEntity> ListarMiOficinaProyeccionAdmin(int Periodo,int CodSucursal)
        {
            Parametros prms = new Parametros()
            {
                new Parametro("@Periodo", Periodo),
                new Parametro("@CodSucursal", CodSucursal)
            };

            return DBHelper.InstanceCRM.ObtenerColeccion("spMotor_ObtenerEjecutivosOficinaByTokenProyeccionAdmin", prms, ConstructorEntidad);
        }



        public static void MarcaAsignable(int Periodo, int oficina, List<string> ejecutivos)
        {

            Parametros prms_reset = new Parametros()
            {
                new Parametro("@Periodo", Periodo),
                new Parametro("@Oficina", oficina),
            };


            DBHelper.InstanceCRM.EjecutarProcedimiento("spMotor_ResetMarcaAsignable", prms_reset);
            
            ejecutivos.ForEach(ejec => {

                Parametros prms = new Parametros()
                {
                    new Parametro("@Periodo", Periodo),
                    new Parametro("@EjecRut", ejec),
                };

                DBHelper.InstanceCRM.EjecutarProcedimiento("spMotor_MarcaAsignable", prms);
            });
        }


        public static int PeriodoAbiertoAsignable(int periodo)
        {
            Parametro p = new Parametro("@Periodo", periodo);
            return DBHelper.InstanceCRM.ObtenerEscalar<int>("spMotor_PeriodoDotacionAbierto", p);
        }

        public static int InsertEjecutivoDotacion(DotacionEntity dotacion)
        {
            
            Parametros prm = new Parametros
            {
                new Parametro("@Rut",dotacion.Rut),
                new Parametro("@Nombres",dotacion.Nombres),
                new Parametro("@IdSucursal",dotacion.IdSucursal),
                new Parametro("@Cargo",dotacion.Cargo),
                new Parametro("@EsAsignable",dotacion.EsAsignable),
                new Parametro("@TipoContrato",dotacion.TipoContrato),
                new Parametro("@FechaIngreso",dotacion.FechaIngreso),
                new Parametro("@FechaFinaliza",dotacion.FechaFinalizacion),
                new Parametro("@Email",dotacion.Email),
                new Parametro("@Sexo",dotacion.Sexo),
            };


            return DBHelper.InstanceCRM.EjecutarProcedimiento("spMotor_Dotacion_Guardar", prm);
        }

        public static List<CargoEntity> ListaCargos()
        {
            return DBHelper.InstanceCRM.ObtenerColeccionFromSql("Select Distinct Cargo From dbo.TabMotor_Dotacion Where Cod_sucursal not in(0,99,999,555) Order By Cargo", Cargos);
        }

        private static CargoEntity Cargos(DataRow row)
        {
            return new CargoEntity
            {
                Nombre = row["Cargo"] != DBNull.Value ? row["Cargo"].ToString() : string.Empty
            };
        }

        public static List<DotacionEntity> ListarEntidades(int periodo)
        {
            Parametro p = new Parametro("@periodo", periodo);
            return DBHelper.InstanceCRM.ObtenerColeccion("dbo.spMotor_Dotacion_ListarByPeriodo", p, ConstructorEntidad);
        }

        public static int MarcarReemplazoRequerido(string rut, bool forzar = false)
        {
            Parametros p = new Parametros
            {
                new Parametro("@EjecutivoRut", rut),
                new Parametro("@Forzar", forzar)
            };
             

            return DBHelper.InstanceCRM.EjecutarProcedimiento("dbo.spMotor_Dotacion_ProcesaReemplazoRequerido", p);
        }
        
        private static DotacionEntity ConstructorEntidad(DataRow row)
        {
            return new DotacionEntity
            {
                Rut = row["Rut"] != DBNull.Value ? row["Rut"].ToString() : string.Empty,
                Nombres = row["Nombre"] != DBNull.Value ? row["Nombre"].ToString() : string.Empty,
                IdSucursal = row["Cod_Sucursal"] != DBNull.Value ? Convert.ToInt32(row["Cod_Sucursal"]) : 0,
                Sucursal = row["Sucursal"] != DBNull.Value ? row["Sucursal"].ToString() : string.Empty,
                Cargo = row["Cargo"] != DBNull.Value ? row["Cargo"].ToString() : string.Empty,
                EsAsignable = row["EsAsignable"] != DBNull.Value ? Convert.ToInt32(row["EsAsignable"]) : 0,
                
            };
        }

    }
}
