using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity
{
    public class GestionEntity
    {
        public int IdBaseCampagna { get; set; }
        public DateTime FechaAccion { get; set; }
        public DateTime FechaCompromete { get; set; }
        public int IdEstado { get; set; }
        public string Descripcion{ get; set; }
        public string RutEjecutivo { get; set; }
        public string IdOficina { get; set; }
    }

    
}
