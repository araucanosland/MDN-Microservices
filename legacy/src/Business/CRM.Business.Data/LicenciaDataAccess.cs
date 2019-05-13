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
    public class LicenciaDataAccess
    {
        public static List<EmpresaLicenciaEntity> ListarEmpresaLicencia()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("spMotor_ObtenerEmpresaLicencia",  ConstructorEntidad);
        }

        public static LicenciaEntity ObtenerRecepcionLicencia(string empresaRut, DateTime fecha )
        {
            Parametros prms = new Parametros()
            {
                new Parametro("@Empresa_Rut",empresaRut),
                new Parametro("@Fecha_recepcion",fecha),
            };
            return DBHelper.InstanceCRM.ObtenerEntidad("spMotor_LicenciaRecepcion_Obtener", prms, ConstructorLicencia);
        }

        public static LicenciaCompinEntity ObtenerEnvioCompin(DateTime fecha)
        {
            Parametro prm = new Parametro("@Fecha_enviolicencia", fecha);
            return DBHelper.InstanceCRM.ObtenerEntidad("spMotor_LicenciaEnvioCompin_Obtener", prm, ConstructorLicenciaCompin);
        }

        public static int Guardar(LicenciaEntity licencia)
        {
            Parametros parametros = new Parametros
            {
                 new Parametro("@Empresa_Rut", licencia.EmpresaRut),
                 new Parametro("@Fecha_recepcion", licencia.FechaRecepcion),
                 new Parametro("@LM_Recibida", licencia.LMRecibida),
                 new Parametro("@LM_Digitada", licencia.LMDigitada),
                 new Parametro("@LM_NoDigitada", licencia.LMNoDigitada),
                 new Parametro("@LM_NoRecepcionada", licencia.LMNoRecepcionada),
                 new Parametro("@Token", licencia.Token),
                 new Parametro("@CodOficinaEhec", licencia.CodOficina),
                 new Parametro("@LM_Recepcionada", licencia.LMRecepcionada)

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("spMotor_LicenciaRecepcion_Guardar", parametros);
        }

        public static int GuardarEnvioCompin(LicenciaCompinEntity licenciaCom)
        {
            Parametros parametros = new Parametros
            {
                 new Parametro("@Fecha_enviolicencia", licenciaCom.FechaEnvio),
                 new Parametro("@Token", licenciaCom.Token),
                 new Parametro("@CodOficinaEjec", licenciaCom.CodOficina),
                 new Parametro("@num_LMEnvio", licenciaCom.LMEnviado)
            };
            return DBHelper.InstanceCRM.ObtenerEscalar<int>("spMotor_LicenciaEnvioCompin_Guardar", parametros);
        }
        public static List<OficinaDerivacionEntity>ListaOficinaDerivacion()
        {
            //return DBHelper.InstanceReportes.ObtenerColeccion("negocios.spReporte_ListaPeriodos", ConstructorEntidad);
            return DBHelper.InstanceCRM.ObtenerColeccion("licencias.sp_Lic_Ingresolicencia_ListaOficinaMaestra", ConstructorOfiDerivacion);
        }

        
        #region CONSTRUCTORES

        private static LicenciaCompinEntity ConstructorLicenciaCompin(DataRow row)
        {
            return new LicenciaCompinEntity
            {
                FechaEnvio = row["FechaEnvioLicencia"] != DBNull.Value ? Convert.ToDateTime(row["FechaEnvioLicencia"]) : DateTime.MinValue,
                LMEnviado = row["Num_LM_Envio"] != DBNull.Value ? Convert.ToInt32(row["Num_LM_Envio"]) : 0,
            };
        }

        private static LicenciaEntity ConstructorLicencia(DataRow row)
        {
            return new LicenciaEntity
            {
                EmpresaRut = row["RutEmpresa"] != DBNull.Value ? row["RutEmpresa"].ToString() : string.Empty,
                FechaRecepcion = row["FechaRecepcionLicencia"] != DBNull.Value ? Convert.ToDateTime(row["FechaRecepcionLicencia"]) : DateTime.MinValue,
                LMDigitada = row["Num_LMDigitada"] != DBNull.Value ? Convert.ToInt32(row["Num_LMDigitada"]) : 0,
                LMRecibida = row["Num_LMRecibida"] != DBNull.Value ? Convert.ToInt32(row["Num_LMRecibida"]) : 0,
                LMNoDigitada = row["Num_LMNoDigitada"] != DBNull.Value ? Convert.ToInt32(row["Num_LMNoDigitada"]) : 0,
                LMNoRecepcionada = row["Num_LMNoRecepcion"] != DBNull.Value ? Convert.ToInt32(row["Num_LMNoRecepcion"]) : 0,
                LMRecepcionada = row["Num_LMRecepcionada"] != DBNull.Value ? Convert.ToInt32(row["Num_LMRecepcionada"]) : 0,
            };
        }

        private static EmpresaLicenciaEntity ConstructorEntidad(DataRow row)
        {
            return new EmpresaLicenciaEntity
            {
                Periodo = row["Periodo"] != DBNull.Value ? Convert.ToInt32(row["Periodo"]) : 0,
                EmpresaRut = row["Empresa_Rut"] != DBNull.Value ? Convert.ToInt32(row["Empresa_Rut"]) : 0,
                EmpresaDv = row["Empresa_Dv"] != DBNull.Value ? row["Empresa_Dv"].ToString() : string.Empty,
                EmpresaRutDv = row["Rut_Dv"] != DBNull.Value ? row["Rut_Dv"].ToString() : string.Empty,
                EmpresaNombre = row["EmpresaNombre"] != DBNull.Value ? row["EmpresaNombre"].ToString() : string.Empty,
            };
        }
        private static OficinaDerivacionEntity ConstructorOfiDerivacion(DataRow row)
        {
            return new OficinaDerivacionEntity
            {
                codOficina= row["Cod_Oficina"] != DBNull.Value ? Convert.ToInt32(row["Cod_Oficina"]) : 0,
                DescOficina= row["Oficina"] != DBNull.Value ? row["Oficina"].ToString() : string.Empty,
                codOficinaCompin = row["CodOficinaCompin"] != DBNull.Value ? Convert.ToInt32(row["CodOficinaCompin"]) : 0,
                OficinaCompin = row["OficinaCompin"] != DBNull.Value ? row["OficinaCompin"].ToString() : string.Empty,

            };
        }


        #endregion

    }
}
