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
    public static class DotacionAgenteDataAccess
    {
        public static List<DotacionAgenteEntity> ListarDotacionAgente(string token)
        {
            Parametro prm = new Parametro("@Token", token);
            return DBHelper.InstanceCRM.ObtenerColeccion("spMotor_EjecutivosOficinaDotacion", prm, EntidadDotacionAgente);
        }

        private static DotacionAgenteEntity EntidadDotacionAgente(DataRow row)
        {
            return new DotacionAgenteEntity
            {
                Rut = row["Rut"] != DBNull.Value ? row["Rut"].ToString() : string.Empty,
                Nombre = row["Nombre"] != DBNull.Value ? row["Nombre"].ToString() : string.Empty,
                Cargo = row["Cargo"] != DBNull.Value ? row["Cargo"].ToString() : string.Empty,
                NombreReemplazo = row["NombreReemplazo"] != DBNull.Value ? row["NombreReemplazo"].ToString() : string.Empty,
                RutReemplazo = row["RutReemplazo"] != DBNull.Value ? row["RutReemplazo"].ToString() : string.Empty,
                TitularAusente = row["TitularAusente"] != DBNull.Value ? Convert.ToInt32(row["TitularAusente"]) : 0,
            };
        }


        public static DatosEjecutivoEntity ListarDataEjecutivo(string rut)
        {
            Parametro prm = new Parametro("@Rut", rut);
            return DBHelper.InstanceCRM.ObtenerEntidad("spMotor_ObtieneDatosEjecutivo", prm, EntidadDatosEjecutivo);
        }

        private static DatosEjecutivoEntity EntidadDatosEjecutivo(DataRow row)
        {
            return new DatosEjecutivoEntity
            {
                Rut = row["Rut"] != DBNull.Value ? row["Rut"].ToString() : string.Empty,
                Nombre = row["Nombre"] != DBNull.Value ? row["Nombre"].ToString() : string.Empty,
                Cargo = row["Cargo"] != DBNull.Value ? row["Cargo"].ToString() : string.Empty,
                TipoContrato = row["TipoContrato"] != DBNull.Value ? row["TipoContrato"].ToString() : string.Empty,
                FechaIngreso = row["FechaIngreso"] != DBNull.Value ? Convert.ToDateTime(row["FechaIngreso"]) : DateTime.MinValue,
                FechaFinal = row["FechaFinalizacion"] != DBNull.Value ? Convert.ToDateTime(row["FechaFinalizacion"]) : DateTime.MinValue,
                Correo = row["Correo"] != DBNull.Value ? row["Correo"].ToString() : string.Empty,
                Sexo = row["Sexo"] != DBNull.Value ? row["Sexo"].ToString() : string.Empty,
            };
        }

        public static int ActualizaDataEjecutivo(DatosActualizaEjecutivoEntity Ejec)
        {
            Parametros prm = new Parametros
            {
                new Parametro("@Rut",Ejec.Rut),
                new Parametro("@Cargo",Ejec.Cargo),
                new Parametro("@TipoContrato",Ejec.TipoContrato),
                new Parametro("@FechaInicio",Ejec.FechaInicio),
                new Parametro("@FechaFinaliza",Ejec.FechaFinaliza),
                new Parametro("@Sexo",Ejec.Sexo),
            };

            return DBHelper.InstanceCRM.EjecutarProcedimiento("spMotor_ActualizaEjecutivo", prm);
        }
    }
}
