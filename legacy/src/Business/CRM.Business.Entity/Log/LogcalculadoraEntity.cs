using System;

//------------------------------------------------------------------------------
// <generado automáticamente>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </generado automáticamente>
//------------------------------------------------------------------------------

namespace CRM.Business.Entity.Log
{
    /// <summary>
    /// Clase Dominio LogcalculadoraEntity
    /// </summary>
    /// <author>@Charly</author>
    /// <created>19-04-2018 12:55:02</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class LogcalculadoraEntity
    {

        /// <summary>
        /// lgc_id
        /// </summary>
        public int lgc_id { get; set; }

        /// <summary>
        /// fecha_accion
        /// </summary>
        public DateTime fecha_accion { get; set; }

        /// <summary>
        /// ejecutivo
        /// </summary>
        public string ejecutivo { get; set; }

        /// <summary>
        /// oficina
        /// </summary>
        public int oficina { get; set; }

        /// <summary>
        /// rut_afiliado
        /// </summary>
        public string rut_afiliado { get; set; }

        /// <summary>
        /// renta_depurada_crm
        /// </summary>
        public long renta_depurada_crm { get; set; }

        /// <summary>
        /// descuento_legal
        /// </summary>
        public long descuento_legal { get; set; }

        /// <summary>
        /// procentaje_descuento
        /// </summary>
        public long procentaje_descuento { get; set; }

        /// <summary>
        /// total_descuentos_liquidacion
        /// </summary>
        public long total_descuentos_liquidacion { get; set; }

        /// <summary>
        /// descuentos_legales_primer_mes
        /// </summary>
        public long descuentos_legales_primer_mes { get; set; }

        /// <summary>
        /// descuentos_legales_segundo_mes
        /// </summary>
        public long descuentos_legales_segundo_mes { get; set; }

        /// <summary>
        /// descuentos_legales_tercer_mes
        /// </summary>
        public long descuentos_legales_tercer_mes { get; set; }

        /// <summary>
        /// descuentos_legales_promedio
        /// </summary>
        public long descuentos_legales_promedio { get; set; }

        /// <summary>
        /// tiene_descuentos_planilla
        /// </summary>
        public string tiene_descuentos_planilla { get; set; }

        /// <summary>
        /// descuentos_creditos_planilla
        /// </summary>
        public long descuentos_creditos_planilla { get; set; }

        /// <summary>
        /// cuota_maxima_descontar_caja
        /// </summary>
        public long cuota_maxima_descontar_caja { get; set; }

        /// <summary>
        /// rut_empresa
        /// </summary>
        public string rut_empresa { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="LogcalculadoraEntity"/>.
        /// </summary>
        public LogcalculadoraEntity()
        {
            lgc_id = 0;
            fecha_accion = new DateTime(1900, 1, 1);
            ejecutivo = string.Empty;
            oficina = 0;
            rut_afiliado = string.Empty;
            renta_depurada_crm = 0;
            descuento_legal = 0;
            procentaje_descuento = 0;
            total_descuentos_liquidacion = 0;
            descuentos_legales_primer_mes = 0;
            descuentos_legales_segundo_mes = 0;
            descuentos_legales_tercer_mes = 0;
            descuentos_legales_promedio = 0;
            tiene_descuentos_planilla = string.Empty;
            descuentos_creditos_planilla = 0;
            cuota_maxima_descontar_caja = 0;
            rut_empresa = string.Empty;

        }
    }

    // <ROL VERIFICADOR>

    public class LogRolVerificadorEntity
    {
        public string Id { get; set; }
        public string RutEjecutivo { get; set; }
        public int CodSucursal { get; set; }
        public string RutAfiliado { get; set; }
        public int Anexo { get; set; }
        public string RutEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public bool? Cotiza { get; set; }
        public bool? Grado { get; set; }
        public bool? SeguroCesantia { get; set; }
        public bool? ProEmpleo { get; set; }
        public bool? LeyEspecifica { get; set; }
        public bool? LeyEspecifica2 { get; set; }

        public int? TotalHaberes { get; set; }
        public int? BonosExtras { get; set; }
        public int? DescuentoLegalMes1 { get; set; }
        public int? DescuentoLegalMes2 { get; set; }
        public int? DescuentoLegalMes3 { get; set; }
        public int? Promedio { get; set; }
        public int? RentaDepurada { get; set; }
        public int? RentaDepuradaCMR { get; set; }
        public int? TotalDescuento { get; set; }
        public int? OtrosDescuentos { get; set; }
        public int? ValorCuotaCredito { get; set; }
        public int? ValorCuotaCreditoComp { get; set; }
        public string Resultado1 { get; set; }
        public string Resultado2 { get; set; }

        public LogRolVerificadorEntity()
        {
            Id = string.Empty;
            RutEjecutivo = string.Empty;
            CodSucursal = 0;
            RutAfiliado = string.Empty;
            Anexo = 0;
            RutEmpresa = string.Empty;
            NombreEmpresa = string.Empty;
            Cotiza = null;
            Grado = null;
            SeguroCesantia = null;
            ProEmpleo = null;
            LeyEspecifica = null;
            LeyEspecifica2 = null;

            TotalHaberes = null;
            BonosExtras = null;
            DescuentoLegalMes1 = null;
            DescuentoLegalMes2 = null;
            DescuentoLegalMes3 = null;
            Promedio = null;
            RentaDepurada = null;
            RentaDepuradaCMR = null;
            TotalDescuento = null;
            OtrosDescuentos = null;
            ValorCuotaCredito = null;
            ValorCuotaCreditoComp = null;
            Resultado1 = null;
            Resultado2 = null;

        }
    }


    public class WebRolVerificadorHelper
    {
        public string Id { get; set; }
        public string RutEjecutivo { get; set; }
        public string CodSucursal { get; set; }
        public string RutAfiliado { get; set; }
        public string Anexo { get; set; }
        public string RutEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public string Cotiza { get; set; }
        public string Grado { get; set; }
        public string SeguroCesantia { get; set; }
        public string ProEmpleo { get; set; }
        public string LeyEspecifica { get; set; }
        public string LeyEspecifica2 { get; set; }


        public string TotalHaberes { get; set; }
        public string BonosExtras { get; set; }
        public string DescuentoLegalMes1 { get; set; }
        public string DescuentoLegalMes2 { get; set; }
        public string DescuentoLegalMes3 { get; set; }
        public string Promedio { get; set; }
        public string RentaDepurada { get; set; }
        public string RentaDepuradaCMR { get; set; }
        public string TotalDescuento { get; set; }
        public string OtrosDescuentos { get; set; }
        public string ValorCuotaCredito { get; set; }
        public string ValorCuotaCreditoComp { get; set; }
        public string Resultado1 { get; set; }
        public string Resultado2 { get; set; }
    }


    public class MuniRolVerificadorEntity
    {
        public int RutEmpresa { get; set; }
        public string DvEmpresa { get; set; }
        public string NombreEmpresa { get; set; }

    }

    public class EmpresaRolVerificadorEntity
    {
        public int IdAnexo { get; set; }
        public string RutEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
    }

}
