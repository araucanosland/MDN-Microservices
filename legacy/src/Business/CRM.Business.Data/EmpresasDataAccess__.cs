using System;
using System.Collections.Generic;
using System.Data;
using CRM.Business.Entity;
using CDK.Data;
using CDK.Integration;

namespace CRM.Business.Data
{
    public class EmpresasDataAccess__
    {
        
        

        private static EmpresaEntity__ ContructorEntidad(DataRow row)
        {
            return new EmpresaEntity__
            {
                EmpresaRut = row["RutEmpresa"] != DBNull.Value ? Convert.ToInt32(row["RutEmpresa"]) : 0,
                EmpresaDV = row["DvEmpresa"] != DBNull.Value ? row["DvEmpresa"].ToString() : string.Empty,
                EmpresaNombre = row["NombreEmpresa"] != DBNull.Value ? row["NombreEmpresa"].ToString() : string.Empty,
                Holding = row["NombreHolding"] != DBNull.Value ? row["NombreHolding"].ToString() : string.Empty,
            };
        }
    }
}
