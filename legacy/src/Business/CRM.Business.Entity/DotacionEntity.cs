using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity
{
    public class DotacionEntity
    {
        public int Periodo { get; set; }
        public string Rut { get; set; }
        public int IdSucursal { get; set; }
        public int IdTipoEjecutivo { get; set; }
        public string Nombres { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public int EsAsignable { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public string TipoContrato { get; set; }
        public string Sucursal { get; set; }
        public string Sexo { get; set; }
    }


}
