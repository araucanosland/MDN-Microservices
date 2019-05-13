using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Business.Entity;
using CRM.Business.Entity.Clases;
using System.Data;
using CDK.Data;
using CDK.Integration;


namespace CRM.Business.Data
{
    public static class BaseCampagnaDataAccess
    {
        public static BaseCampagnaEntity Obtener(int Periodo, int Rut, string TokenEjecutivo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@Periodo", Periodo),
                new Parametro("@RutAfiliado",Rut),
                new Parametro("@TokenEjecutivo",TokenEjecutivo),
            };

            return DBHelper.InstanceCRM.ObtenerEntidad("spMotor_ObtenerBaseCampagna", pram, ConstructorEntidad);
        }
        
        public static List<BaseCampagnaEntity> ListarByEjecutivo(int Periodo, string TokenEjecutivo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@Periodo", Periodo),
                new Parametro("@TokenEjecutivo",TokenEjecutivo),
            };

            return DBHelper.InstanceCRM.ObtenerColeccion("spMotor_ListarBaseCampagnaByEjecutivo", pram, ConstructorEntidad);
        }
        public static BaseCampagnaEntity ObtenerAfiliado (string Rut)
        {
            Parametros para = new Parametros
            {
                new Parametro("@Rut",Rut)
            };
            return DBHelper.InstanceCRM.ObtenerEntidad("spMotor_Asignacion_ObtenerAfi", para, ConsAfiliado);
        }


        private static BaseCampagnaEntity ConstructorEntidad(DataRow row)
        {
            return new BaseCampagnaEntity
            {
                Periodo = row["periodo"] != DBNull.Value ? Convert.ToInt32(row["periodo"]) : 0,
                Rut = row["afi_rut"] != DBNull.Value ? Convert.ToInt32(row["afi_rut"]) : 0,
                Dv = row["afi_dv"] != DBNull.Value ? row["afi_dv"].ToString() : string.Empty,
                Apellidos = row["afi_apellidos"] != DBNull.Value ? row["afi_apellidos"].ToString() : string.Empty,
                Nombres = row["afi_nombres"] != DBNull.Value ? row["afi_nombres"].ToString() : string.Empty,
                Edad = row["afi_edad"] != DBNull.Value ? Convert.ToInt32(row["afi_edad"]) : 0,
                EmpresaRut = row["afi_empresa_rut"] != DBNull.Value ? Convert.ToInt32(row["afi_empresa_rut"]) : 0,
                EmpresaDv = row["afi_empresa_dv"] != DBNull.Value ? row["afi_empresa_dv"].ToString() : string.Empty,
                EmpresaNombre = row["afi_empresa_nombre"] != DBNull.Value ? row["afi_empresa_nombre"].ToString() : string.Empty,
                FechaNacimiento = row["afi_fecha_nacimiento"] != DBNull.Value ? Convert.ToDateTime(row["afi_fecha_nacimiento"]) : DateTime.MinValue,
                Uid = row["bcam_uid"] != DBNull.Value ? Convert.ToInt32(row["bcam_uid"]) : 0,
                Segmento = row["afi_segmento"] != DBNull.Value ? row["afi_segmento"].ToString() : string.Empty,
                PreAprobado = row["afi_preaprobado"] != DBNull.Value ? Convert.ToDecimal(row["afi_preaprobado"]) : 0,
                Renta = row["afi_renta"] != DBNull.Value ? Convert.ToDecimal(row["afi_renta"]) : 0,
                Sexo = row["afi_sexo"] != DBNull.Value ? row["afi_sexo"].ToString() : string.Empty,   
                IdTipoCampagna = row["tipo_campagna_id"] != DBNull.Value ? Convert.ToInt32(row["tipo_campagna_id"]) : 0,
                RutEjecutivo = row["ejec_rut"] != DBNull.Value ? row["ejec_rut"].ToString() : string.Empty,
            };
        }

        private static BaseCampagnaEntity ConsAfiliado(DataRow row)
        {
            return new BaseCampagnaEntity
            {
                Periodo = row["periodo"] != DBNull.Value ? Convert.ToInt32(row["periodo"]) : 0,
                Rut = row["Afiliado_Rut"] != DBNull.Value ? Convert.ToInt32(row["Afiliado_Rut"]) : 0,
                Dv = row["Afiliado_Dv"] != DBNull.Value ? row["Afiliado_Dv"].ToString() : string.Empty,
                Apellidos = row["Apellido"] != DBNull.Value ? row["Apellido"].ToString() : string.Empty,
                Nombres = row["Nombre"] != DBNull.Value ? row["Nombre"].ToString() : string.Empty,
                EmpresaRut = row["Empresa_Rut"] != DBNull.Value ? Convert.ToInt32(row["Empresa_Rut"]) : 0,
                EmpresaDv = row["Empresa_Dv"] != DBNull.Value ? row["Empresa_Dv"].ToString() : string.Empty,
                EmpresaNombre = row["Empresa"] != DBNull.Value ? row["Empresa"].ToString() : string.Empty,
                Segmento = row["Segmento"] != DBNull.Value ? row["Segmento"].ToString() : string.Empty,
                PreAprobado = row["PreAprobadoFinal"] != DBNull.Value ? Convert.ToDecimal(row["PreAprobadoFinal"]) : 0,
                Renta = row["MontoRenta"] != DBNull.Value ? Convert.ToDecimal(row["MontoRenta"]) : 0,
            };
        }

    }
}
