using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity
{
    public class FFVVBaseEntity
    {
        public int periodo { get; set; }
        public int rutEjecutivo { get; set; }
        public string dvAfiliado { get; set; }
        public string rutAfiliado { get; set; }
        public string nombreAfiliado { get; set; }
        public string apellidoAfiliado { get; set; }
        public int montoBruto { get; set; }
        public int montoNetoReal { get; set; }
        public string tipoCliente { get; set; }
        public string tipoCamapana { get; set; }

    }

    public class DetalleFFVVBase
    {
        public int periodo { get; set; }
        public int rutEjecutivo { get; set; }
        public string nombreEjecutivo { get; set; }
        public int nOpCHSinCredito { get; set; } // n° operacions cliente historicamente sin credito
        public int montoCHSinCredito { get; set; } //monto cliente historicamente sin credito
        public int nOpCSinCredVigente { get; set; } // n° Operaciones Cliente sin Credito Vigente
        public int montoCSinCredVigente { get; set; }//monto cliente sin crtedito vigente
        public int nOpCCreditoVigente { get; set; }//n° cliente con credito vigente
        public int montoCCreditoVigente { get; set; }//monto cliente con credito vigente
        public int TotalOperaciones { get; set; }
        public int TotalMonto { get; set; }
    }

    public class IncentivoFFVV
    {
        public int desde { get; set; }
        public string hasta { get; set; }
        public int MayorMM25 { get; set; }
        public int M25_35MM { get; set; }
        public int M35_50MM { get; set; }
        public int M50_70MM { get; set; }
        public int M70 { get; set; }
    }
    public class ComisionesColocacionesFFVV
    {
        public int desdeCo { get; set; }
        public string hastaCo { get; set; }
        public string PorcCliHistoSinCredito { get; set; }
        public string PorcCliSinCreditoVigente { get; set; }
        public string PorcCliConCreditoVigente { get; set; }
    }

    public class PagoComisionesHistorico
    {
        public int periodo { get; set; }
        public int rutEjecutivo { get; set; }
        public string nombreEjecutivo { get; set; }
        public int opHistorico { get; set; }
        public int mtoHistorico { get; set; }
        public int opSinCredito { get; set; }
        public int mtoSinCredito { get; set; }
        public int opConCredito { get; set; }
        public int mtoConCredito { get; set; }
        public int totalOpValido { get; set; }
        public int totalMtoValido { get; set; }
        public int nOperacion { get; set; }
        public int mtoNOperacion { get; set; }
        public int totalOperacion { get; set; }


    }

    public class PagoComision
    {
        public int periodo { get; set; }
        public int rutEjecutivo { get; set; }
        public int totalOperacion { get; set; }
        public int mtoNeto { get; set; }
        public int incentivoNOperacion { get; set; }
        public int cliHistorico { get; set; }
        public int cliSinCredito { get; set; }
        public int cliConCredito { get; set; }
        public int nSegurosVendidos { get; set; }
        public int incentivoNSeguros { get; set; }
        public int totalComision { get; set; }

    }
}
