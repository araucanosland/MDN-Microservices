using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity.Clases
{
    public class CarteraEmpresa
    {
        public string RutEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public int TipoEjectEmpresa { get; set; }
        public string RutEjecutivo { get; set; }
        public string NombreEjecutivo { get; set; }
    }

    public class CarteraEmpresaRut
    {
        public string RutEmpresas { get; set; }
        public string NombreEmpresas { get; set; }
    }
}
