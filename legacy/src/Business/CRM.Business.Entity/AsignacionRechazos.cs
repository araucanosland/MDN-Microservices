using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity
{
    public class AsignacionRechazos
    {
        public int Periodo { get; set; }
        public int AfiliadoRut { get; set; }
        public int EmpresaRut { get; set; }
        public string MotivoRechazo { get; set; }
    }
}
