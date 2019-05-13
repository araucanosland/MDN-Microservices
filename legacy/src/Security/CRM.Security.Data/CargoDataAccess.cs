using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CDK.Data;
using CDK.Integration;
using CRM.Security.Entity;


namespace CRM.Security.Data
{
    public static class CargoDataAccess
    {
        
        public static string obtener(string token)
        {
            return DBHelper.InstanceSecurity.ObtenerEscalar<string>("security.spSca_ObtenerCargo", new Parametro("@token", token));
        }
        

        private static string ConstructorEntidad(DataRow row)
        {
            return row["Cargo"] != DBNull.Value ? row["Cargo"].ToString() : string.Empty;
        }
    }
}
