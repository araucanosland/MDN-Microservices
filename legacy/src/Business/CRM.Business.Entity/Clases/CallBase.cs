using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity.Clases
{
    public class AsignacionCallBase
    {
        public int Asignacion { get; set; }
        public AfiliadoCallBase Afiliado { get; set; }
        public EmpresaCallBase Empresa { get; set; }
        public string OficinaAsinacion { get; set; }
        public long PreAprobado { get; set; }
        public List<Contactibilidad.ContactabilidadEntity> Fonos { get; set; }
        public List<GestionEntity> Gestiones { get; set; }

        public AsignacionCallBase()
        {
            Afiliado = new AfiliadoCallBase();
            Empresa = new EmpresaCallBase();
        }
    }

    public class AfiliadoCallBase
    {
        public string Nombres { get; set; }
        public string Rut { get; set; }
        public string Segmento { get; set; }
        public string ClaveRut { get; set; }
    }

    public class EmpresaCallBase
    {
        public string Rut { get; set; }
        public string RazonSocial { get; set; }
    }

    public class EstadoCallBase
    {
        public int EstadoId { get; set; }
        public string Nombre { get; set; }
        public List<EstadoCallBase> Hijos { get; set; }

        public EstadoCallBase()
        {
            Hijos = new List<EstadoCallBase>();
        }
    }


    public class OficinaCallBase
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        
    }
}
