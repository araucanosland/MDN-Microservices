using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity.Contactibilidad
{
    public class ContactabilidadEntity
    {
        public int RutAfiliado { get; set; }
        public int iTipoDato { get; set; }
        public string TipoDato { get; set; }
        public int iClasifdato { get; set; }
        public string ClasifDato { get; set; }
        public string ValorDato { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string OrigenCreacion { get; set; }
        public DateTime FechaIntento { get; set; }
        public string ResultIntento { get; set; }
        public string OrigenIntento { get; set; }
        public DateTime FechaContacto { get; set; }
        public string OrigenContacto { get; set; }
        public DateTime FechaBaja { get; set; }
        public string OrigenBaja { get; set; }
        public string MotivoBaja { get; set; }
        public string RutEjecGestion { get; set; }
        public int Oficina { get; set; }
        public int IndiceContactabilidad { get; set; }
        public int Ocultar { get; set; }
        public string Token { get; set; }

        public int PorcIndice { get; set; }
        public string Descripcion { get; set; }


        public ContactabilidadEntity()
        {
            RutAfiliado = 0;
            iTipoDato = 0;
            TipoDato = string.Empty;
            iClasifdato = 0;
            ClasifDato = string.Empty;
            ValorDato = string.Empty;
            FechaCreacion = new DateTime(1900, 1, 1);
            OrigenCreacion = string.Empty;
            FechaIntento = new DateTime(1900, 1, 1);
            ResultIntento = string.Empty;
            OrigenIntento = string.Empty;
            FechaContacto = new DateTime(1900, 1, 1);
            OrigenIntento = string.Empty;
            FechaBaja = new DateTime(1900, 1, 1);
            OrigenBaja = string.Empty;
            MotivoBaja = string.Empty;
            RutEjecGestion = string.Empty;
            Oficina = 0;
            IndiceContactabilidad = 0;
            Ocultar = 0;
            PorcIndice = 0;
            Descripcion = string.Empty;
        }
    }

    public class IndiceContactabilidad
    {
        public int IdEstado { get; set; }
        public string Descripcion { get; set; }
    }
}





