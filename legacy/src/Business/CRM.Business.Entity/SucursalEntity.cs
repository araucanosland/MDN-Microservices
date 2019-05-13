using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity
{
    public class SucursalEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        
    }
    public class SucursalAdminEntity
    {
        public int CodOficina { get; set; }
        public string Sucursal { get; set; }
        public int NumeroActivo { get; set; }
        public int PorcentajeActivo { get; set; }
        public int nroLicencia { get; set; }
        public int porcentajeLicencia { get; set; }
        public int nroPermiso { get; set; }
        public int porcentajePermiso { get; set; }
        public int nroVacaciones { get; set; }
        public int porcentajeVacaciones { get; set; }
        public int nroCapacitacion { get; set; }
        public int porcentajeCapaciontacion { get; set; }
        public int nroComision              {get;set;}
        public int porcentajeComision { get;set;}
        public int nroDesvinculacion        {get;set;}
        public int porcentajeDesvinculacion { get;set;}
        public int nroTotal                 {get;set;}
        public int porcentajeTotal { get; set; }






    }

}
