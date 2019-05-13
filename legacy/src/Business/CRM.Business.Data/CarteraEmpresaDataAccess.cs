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
    public class CarteraEmpresaDataAccess
    {
        public static CarteraEmpresaEntity ObtenerDatoEmpresa(string RutEmpresa)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@Rut", RutEmpresa)
            };
            return DBHelper.InstanceCRM.ObtenerEntidad("carteras.spMotorCartera_ListaEmpresaRut", pram, ConsCarteraEmpresa);
        }

        public static List<CarteraEmpresaHolding> ObtenerEmpresaPorNombreRutOHolding(string busqueda)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@Entrada", busqueda)
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.spMotorCartera_ObtenerEmpresaPorNombreRutOHolding", pram, ConsCarteraEmpresaHolding);
        }

        public static List<EjecutivoCarteraEntity> ListarEjecutivoCargo(string TokenEjecutivo, int CodTipo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@TokenEjecutivo", TokenEjecutivo),
                new Parametro("@CodTipo",CodTipo)
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.sp_MotorCartera_ListaEjecutivoCargo", pram,ConstEjecutivoCargo);
        }
        public static List<EjecutivoCarteraEntity> ListarEjecutivoAdmin(string TokenEjecutivo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@TokenEjecutivo", TokenEjecutivo),
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.sp_MotorCartera_ListaEjecutivoAdmin", pram, ConstEjecutivoCargo);
        }


        public static List<CarteraEmpresaEntity> ListaEmpresaEjecutivo(string TokenEjecutivo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@TokenEjecutivo", TokenEjecutivo)
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.spMotorCartera_ListaEmpresaEjecutivo", pram,ConsEmpresaEjecutivo);
        }
        public static List<CarteraEmpresaTotal> ListarEmpresaTotal(int limit, int offset, string search = "", string token = "")
        {
            var para = new Parametros
            {
                new Parametro("@offset",offset),
                new Parametro("@limit", limit),
                new Parametro("@search",search),
                new Parametro("@token",token)
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.spMotorCartera_ListaTotalEmpresa", para ,EmpresaTotal);
        }

        public static int CountEmpresaTotal(string search = "", string token="")
        {
            var para = new Parametros
            {
             
                new Parametro("@search",search),
                new Parametro("@token",token)
            };
            return DBHelper.InstanceCRM.ObtenerEntidad("carteras.spMotorCartera_CountTotalEmpresa", para,ConstructotrCount);
        }


        public static List<CarteraEmpresaAdmin> ListarEmpresaAdmin(string TokenEjecutivo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@TokenEjecutivo", TokenEjecutivo)
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.spMotorCartera_ListaEmpresaEjecutivoAdmin", pram, ListadoEmpresaAsignada);
        }


        #region  Constructores

        private static CarteraEmpresaEntity ConsCarteraEmpresa(DataRow row)
        {

            return new CarteraEmpresaEntity
            {
                RutEmpresa = row["RutEmpresa"] != DBNull.Value ? row["RutEmpresa"].ToString() : string.Empty,
                NombreEmpresa= row["NombreEmpresa"] != DBNull.Value ? row["NombreEmpresa"].ToString() : string.Empty
            };
        }

        private static CarteraEmpresaHolding ConsCarteraEmpresaHolding(DataRow row)
        {

            return new CarteraEmpresaHolding
            {
                RutEmpresa = row["RutEmpresa"] != DBNull.Value ? row["RutEmpresa"].ToString() : string.Empty,
                NombreEmpresa = row["NombreEmpresa"] != DBNull.Value ? row["NombreEmpresa"].ToString() : string.Empty,
                Holding = row["Holding"] != DBNull.Value ? row["Holding"].ToString() : string.Empty
            };
        }

        private static EjecutivoCarteraEntity ConstEjecutivoCargo(DataRow row)
        {
            return new EjecutivoCarteraEntity
            {
                EjecutivoRut =row["Rut"] != DBNull.Value ? row["Rut"].ToString() : string.Empty,
                EjecutivoNombre= row["Nombre"] != DBNull.Value ? row["Nombre"].ToString() : string.Empty,
                EjecutivoCargo = row["Nombre_TipoCargo"] != DBNull.Value ? row["Nombre_TipoCargo"].ToString() : string.Empty,
                EjecutivoSucursal = row["Sucursal"] != DBNull.Value ? row["Sucursal"].ToString():string.Empty

            };
        }
        private static CarteraEmpresaEntity ConsEmpresaEjecutivo(DataRow row)
        {
            return new CarteraEmpresaEntity
            {
                IdEmpresaIngreso = row["IdEmpresaIngreso"] != DBNull.Value ? Convert.ToInt32(row["IdEmpresaIngreso"]) : 0,
                RutEmpresa = row["EmpresaRut"] != DBNull.Value ? row["EmpresaRut"].ToString() : string.Empty,
                NombreEmpresa = row["EmpresaNombre"] != DBNull.Value ? row["EmpresaNombre"].ToString() : string.Empty,
                TipoEjectEmpresa=row["EmpresaTipoEjecutivo"] != DBNull.Value ? row["EmpresaTipoEjecutivo"].ToString() : string.Empty,
                RutEjecutivo = row["EmpresaRutEjecutivo"] != DBNull.Value ? row["EmpresaRutEjecutivo"].ToString() : string.Empty,
                NombreEjecutivo = row["EmpresaNombreEjecutivo"] != DBNull.Value ? row["EmpresaNombreEjecutivo"].ToString() : string.Empty,

            };
        }
        private static CarteraEmpresaTotal EmpresaTotal(DataRow row)
        {
            return new CarteraEmpresaTotal
            {
             
                RutEmpresa = row["RutEmpresa"] != DBNull.Value ? row["RutEmpresa"].ToString() : string.Empty,
                NombreEmpresa = row["EmpresaNombre"] != DBNull.Value ? row["EmpresaNombre"].ToString() : string.Empty,
               
            };
        }
        private static CarteraEmpresaAdmin ListadoEmpresaAsignada(DataRow row)
        {
            return new CarteraEmpresaAdmin
            {
                IdSucursalEmpresa= row["IdSucursalEmpresa"] != DBNull.Value ? Convert.ToInt32(row["IdSucursalEmpresa"]) : 0,
                SucursalEmpresa = row["SucursalEmpresa"] != DBNull.Value ? row["SucursalEmpresa"].ToString() : string.Empty,
                RutEmpresa = row["RutEmpresa"] != DBNull.Value ? row["RutEmpresa"].ToString() : string.Empty,
                NombreEmpresa = row["NombreEmpresa"] != DBNull.Value ? row["NombreEmpresa"].ToString() : string.Empty,
                codOficina = row["CodOficina"] != DBNull.Value ? Convert.ToInt32(row["CodOficina"]) : 0,
                NTrabajador = row["NTrabajador"] != DBNull.Value ? Convert.ToInt32(row["NTrabajador"]) : 0,
                Holding = row["Holding"] != DBNull.Value ? Convert.ToInt32(row["Holding"]) : 0,
                Comentarios = row["Comentarios"] != DBNull.Value ? row["Comentarios"].ToString() : string.Empty,
                FechaIngreso  = row["FechaIngreso"] != DBNull.Value ? Convert.ToDateTime(row["FechaIngreso"]) : new DateTime(1900, 1, 1),
                EjecutivoIngreso = row["EjecutivoIngreso"] != DBNull.Value ? row["EjecutivoIngreso"].ToString() : string.Empty,
            };
        }


        private static int ConstructotrCount(DataRow row)
        {
            return Convert.ToInt32(row["Total"]);
        } 
        #endregion

    }
}
