using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity.Clases
{
    public class WebGestionCall
    {
        public int Asignacion { get; set; }
        public int Estado { get; set; }
        public int SubEstado { get; set; }
        public string FechaProxGestion { get; set; }
        public string Comentarios { get; set; }
        public string RutEjecutivo { get; set; }
        public int Oficina { get; set; }
        public string FonoContact { get; set; }
        public string NuevoFono { get; set; }
        public string RutAfiliado { get; set; }
        public string HorarioPreferencia { get; set; }
    }
}
