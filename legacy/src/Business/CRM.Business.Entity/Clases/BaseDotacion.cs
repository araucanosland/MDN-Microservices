using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CRM.Business.Entity.Clases
{
    public class BaseDotacion
    {
        public List<EjecutivosDotacion> Ejecutivos { get; set; }
        public List<DateTime> Feriados { get; set; }
        public List<TipoausenciaEntity> TiposAusencia { get; set; }
        public List<CargoEntity> Cargos { get; set; }
        public List<ResumenAusencias> ResumenAusencias { get; set; }
        public SucursalEntity Oficina { get; set; }

    }

    public class EjecutivosDotacion
    {
        public DotacionEntity Ejecutivo { get; set; }
        public List<AusenciaEntity> PeriodoAusencia { get; set; }
        public bool RegistraAusencia { get; set; }
    }
    
     
}
