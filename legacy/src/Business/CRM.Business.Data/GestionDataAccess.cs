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
    public static class GestionDataAccess
    {
        

        public static int Guardar(GestionEntity gestion)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@ges_bcam_uid", gestion.IdBaseCampagna),
                new Parametro("@ges_fecha_accion", gestion.FechaAccion),
                new Parametro("@ges_fecha_compromete", gestion.FechaCompromete),
                new Parametro("@ges_descripcion_gst", gestion.Descripcion),
                new Parametro("@ges_estado_gst", gestion.IdEstado),
                new Parametro("@ges_ejecutivo_rut", gestion.RutEjecutivo),
                new Parametro("@ges_oficina", gestion.IdOficina),
            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("spMotor_Gestion_Guardar", parametros);
        }


        public static List<GestionEntity> ListarGestion(int idAsignacion)
        {
            Parametro prm = new Parametro("@IdAsignacion", idAsignacion);
            return DBHelper.InstanceCRM.ObtenerColeccion("spMotor_Listar_GestionByAsignacion", prm,EntidadGestion);
        }


        public static List<GestionEntity> ListarGestion(string AfiliadoRut)
        {
            Parametro prm = new Parametro("@AfiliadoRut", AfiliadoRut);
            return DBHelper.InstanceCRM.ObtenerColeccion("spMotor_Listar_GestionByAfiliado", prm, EntidadGestion);
        }


        private static GestionEntity EntidadGestion(DataRow row)
        {
            return new GestionEntity
            {
                IdBaseCampagna = row["ges_bcam_uid"] != DBNull.Value ? Convert.ToInt32(row["ges_bcam_uid"]) : 0,
                FechaAccion = row["ges_fecha_accion"] != DBNull.Value ? Convert.ToDateTime(row["ges_fecha_accion"]) : DateTime.MinValue,
                FechaCompromete = row["ges_fecha_compromete"] != DBNull.Value ? Convert.ToDateTime(row["ges_fecha_compromete"]) : DateTime.MinValue,
                Descripcion = row["ges_descripcion_gst"] != DBNull.Value ? row["ges_descripcion_gst"].ToString() : string.Empty,
                IdEstado = row["ges_estado_gst"] != DBNull.Value ? Convert.ToInt32(row["ges_estado_gst"]) : 0,
                RutEjecutivo = row["ges_ejecutivo_rut"] != DBNull.Value ? row["ges_ejecutivo_rut"].ToString() : string.Empty,
                IdOficina = row["ges_oficina"] != DBNull.Value ? row["ges_oficina"].ToString() : string.Empty,
            };
        }



    }
}
