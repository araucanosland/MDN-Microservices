using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity
{
   public class LicenciaEntity
    {
        public string EmpresaRut { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public int LMRecibida { get; set; }
        public int LMDigitada { get; set; }
        public int LMNoDigitada { get; set; }
        public int LMNoRecepcionada { get; set; }
        public int LMRecepcionada { get; set; }
        public string Token { get; set; }
        public int CodOficina { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
    public class EmpresaLicenciaEntity
    {
        public int Periodo { get; set; }
        public int EmpresaRut { get; set; }
        public string EmpresaDv { get; set; }
        public string EmpresaRutDv { get; set; }
        public string EmpresaNombre { get; set; } 
    }
    public class LicenciaCompinEntity
    {
        public DateTime FechaEnvio { get; set; }
        public int LMEnviado { get; set; }
        public string Token { get; set; }
        public int CodOficina { get; set; }
        public DateTime FechaActualizacion { get; set; }

    }
    public class LicenciaDerivacionEntity
    {
        public int sucursalOrigen { get; set; }
        public int sucursalDerivacion { get; set; }
        public string RutEjecutivo { get; set; }

    }
    public class OficinaDerivacionEntity
    {
        public int codOficina { get; set; }
        public string DescOficina { get; set; }
        public int codOficinaCompin { get; set; }
        public string OficinaCompin { get; set; }
    }
   
    
}
