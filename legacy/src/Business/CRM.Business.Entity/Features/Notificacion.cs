using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity.Features
{
    public class Notificacion
    {
        public string MensajePrincipal { get; set; }
        public bool EsNueva { get; set; }
        public string MensajeOpcional { get; set; }
    }
}
