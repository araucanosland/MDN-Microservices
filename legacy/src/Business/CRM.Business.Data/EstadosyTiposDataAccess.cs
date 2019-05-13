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
    public static class EstadosyTiposDataAccess
    {


        public static TipoCampagnaEntity OnbtenerTipoCampagnaByBaseCamp(int uid)
        {
            Parametro pram = new Parametro("@uid", uid);
            return DBHelper.InstanceCRM.ObtenerEntidad("spMotor_ObtenerBaseCampagna", pram, EntidadTipoCampagna);
        }

        public static List<EstadogestionEntity> ListarEstadosGestion()
        {
            
            return DBHelper.InstanceCRM.ObtenerColeccion("spMotor_Estadogestion_Listar", EntidadEstadoGestion);
        }

        public static EstadogestionEntity ObtenerEstadosGestionById(long id)
        {
            return DBHelper.InstanceCRM.ObtenerEntidad("spMotor_Estadogestion_ObtenerById", new Parametro("@Id", id),EntidadEstadoGestion);
        }


        private static TipoCampagnaEntity EntidadTipoCampagna(DataRow row)
        {
            return new TipoCampagnaEntity
            {
                Id = row["periodo"] != DBNull.Value ? Convert.ToInt32(row["periodo"]) : 0,
                Nombre = row["afi_dv"] != DBNull.Value ? row["afi_dv"].ToString() : string.Empty,
            };
        }
        
        private static EstadogestionEntity EntidadEstadoGestion(DataRow row)
        {
            return new EstadogestionEntity
            {
                eges_id = row["eges_id"] != DBNull.Value ? Convert.ToInt32(row["eges_id"]) : 0,
                eges_nombre = row["eges_nombre"] != DBNull.Value ? row["eges_nombre"].ToString() : string.Empty,
                ejes_id_padre = row["ejes_id_padre"] != DBNull.Value ? Convert.ToInt64(row["ejes_id_padre"]) : 0,
                ejes_terminal = row["ejes_terminal"] != DBNull.Value ? row["ejes_terminal"].ToString() : string.Empty,
                ejes_tipo_campagna = row["ejes_tipo_campagna"] != DBNull.Value ? Convert.ToInt32(row["ejes_tipo_campagna"]) : 0,
            };
        }

    }
}
