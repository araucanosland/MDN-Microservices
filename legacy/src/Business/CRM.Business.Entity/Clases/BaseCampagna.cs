using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity.Clases
{
    public class BaseCampagna
    {
        public AsignacionEntity Seguimiento { get; set; }
        public TipoCampagnaEntity TipoCampagna { get; set; }
        public Ejecutivo Ejecutivo { get; set; }
        public List<PadreGestion> HistorialGestion { get; set; }
        public List<NotificacionAsignacionEntity> Notificaciones { get; set; }
        public List<ContactoafiliadoEntity> Telefonos { get; set; }
        public List<ContactoafiliadoEntity> Celulares { get; set; }
        public List<ContactoafiliadoEntity> Correos { get; set; }
        public PreferenciaAfiliadoEntity OficinaPreferencia { get; set; }
        public PreferenciaAfiliadoEntity HorarioPreferencia { get; set; }
        public string FiltrosRSG { get; set; }
        public string NombreOficina { get; set; }
    }


    public class ContenedorCampaniaList
    {
        public AsignacionEntity Seguimiento { get; set; }
        public List<NotificacionAsignacionEntity> Notificaciones { get; set; }
        public GestionGenerica UltimaGestion { get; set; }
        public int TotalRegistros { get; set; }
    }
    public class DatosEmpresaEntity
    {
        public string NonEmpresa { get; set; }

    }
}
