using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity.Clases
{
    public class BaseLicencia
    {
        public Ingresolicencia IngresoData { get; set; }
        public Estadolicencia EstadoData { get; set; }
        public string NombreEjecutivo { get; set; }
    }
}
