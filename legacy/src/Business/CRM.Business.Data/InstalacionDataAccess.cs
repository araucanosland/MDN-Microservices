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
    public static class InstalacionDataAccess
    {
        public static IEnumerable<InstaladorEntity> ObInstalacion(int idInstalacion)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@IdInstalacion", idInstalacion),
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("SPMotor_Instalacion", pram, InstaladorActualizaciones);
        }

        private static InstaladorEntity InstaladorActualizaciones(DataRow row)
        {
            return new InstaladorEntity
            {
                Id_ins = row["Id_instal"] != DBNull.Value ? Convert.ToInt32(row["Id_instal"]) : 0,
                Titulo = row["Titulo"] != DBNull.Value ? row["Titulo"].ToString() : string.Empty,
                Glosa = row["Glosa"] != DBNull.Value ? row["Glosa"].ToString() : string.Empty,
                Ruta = row["Ruta"] != DBNull.Value ? row["Ruta"].ToString() : string.Empty,
                Tiempo = row["Tiempo"] != DBNull.Value ? Convert.ToInt32(row["Tiempo"]) : 0,
            };
        }

        public static int UpdateInstalacion(string Token)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@Token", Token),
            };
            return DBHelper.InstanceCRM.ObtenerEscalar<int>("SPMotor_UpdateFlagInstalacion", parametros);
        }
    }
}
