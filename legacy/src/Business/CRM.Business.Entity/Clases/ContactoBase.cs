using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity.Clases
{
    public class ContactoBase
    {
        public List<NotificacionAsignacionEntity> Notificaciones { get; set; }
        public List<ContactoafiliadoEntity> Telefonos { get; set; }
        public List<ContactoafiliadoEntity> Celulares { get; set; }
        public List<ContactoafiliadoEntity> Correos { get; set; }
        public PreferenciaAfiliadoEntity OficinaPreferencia { get; set; }
        public PreferenciaAfiliadoEntity HorarioPreferencia { get; set; }
        public string FiltrosRSG { get; set; }
    }
}
