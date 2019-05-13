using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity
{
    public class BaseCampagnaEntity
    {
        public int Periodo { get; set; }
        public int Uid { get; set; }
        public int IdTipoCampagna { get; set; }
        public string RutEjecutivo { get; set; }
        public int Rut { get; set; }
        public string Dv { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int EmpresaRut { get; set; }
        public string EmpresaDv { get; set; }
        public string EmpresaNombre { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public decimal Renta { get; set; }
        public decimal PreAprobado { get; set; }
        public string Segmento { get; set; }
        
    }

    
}
