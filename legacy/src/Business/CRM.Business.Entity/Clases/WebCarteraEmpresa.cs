using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity.Clases
{
    public class WebCarteraEmpresa
    {
        public int webCodIngreso { get; set; }
        public string webRutEmpresa { get; set; }
        public string webNombreEmpresa { get; set; }
        public int webTipoEjecutivo { get; set; }
        public string webRutEjecutivo { get; set; }
        public string webNombreEjecutivo { get; set; }
    }
    public class WebCarteraEmpresaAdmin
    {
        public int webCodIngreso { get; set; }
        public string webRutEmpresa { get; set; }
        public string webNombreEmpresa { get; set; }
        public int webNTrabajador { get; set; }
    }
}
