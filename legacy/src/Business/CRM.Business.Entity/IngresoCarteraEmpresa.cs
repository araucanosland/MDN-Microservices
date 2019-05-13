using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity
{
    public class IngresoCarteraEmpresa
    {
        public int CodIngresoEmpresa { get; set; }
        public string RutEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public int TipoEjectEmpresa { get; set; }
        public string RutEjecutivo { get; set; }
        public string NombreEjecutivo { get; set; }
        public string PeriodoCarteraEmpresa { get; set; }
        public IngresoCarteraEmpresa()
        {
            CodIngresoEmpresa = 0;
            RutEmpresa = string.Empty;
            NombreEmpresa = string.Empty;
            TipoEjectEmpresa = 0;
            RutEjecutivo = string.Empty;
            NombreEjecutivo = string.Empty;
        }
    }

    public class IngresoCarteraEmpresaAdmin
    {
        public int CodIngresoEmpresa { get; set; }
        public string RutEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public int nTrabajador { get; set; }
        public IEnumerable<string> EjecAsignado { get; set; }
        public int esHolding { get; set; }
        public string Comentarios { get; set; }

        public IngresoCarteraEmpresaAdmin()
        {
            CodIngresoEmpresa = 0;
            RutEmpresa = string.Empty;
            NombreEmpresa = string.Empty;
            nTrabajador = 0;
            EjecAsignado = new List<string>();
            esHolding = 0;
            Comentarios = string.Empty;
        }


    }
    public class IngresoEjecutivoAsignacion
    {
        public int IdSucursal { get; set; }
        public string RutEjecutivo { get; set; }
    }
}
