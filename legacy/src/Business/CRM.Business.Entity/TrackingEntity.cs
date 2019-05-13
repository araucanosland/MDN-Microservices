using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity
{
    public class TrackingEntity
    {
        public int Periodo { get; set; }
        public int EjecAsign_Rut { get; set; }
        public int CodOficina { get; set; }
        public string Oficina { get; set; }
        public string EjecutivoCargo { get; set; }
        public string EjecutivoNombre { get; set; }
        public int SumaAsignados { get; set; }
        public int SumaGestionados { get; set; }
        public float SumaPorcentajeGestionado { get; set; }
        public int SumaContactados { get; set; }
        public float SumaPorcentajeContactados { get; set; }
        public int SumaPresentados { get; set; }
        public float SumaPorcentajePresentados { get; set; }
        public int SumaAprobados { get; set; }
        public float SumaPorcentajeAprobados { get; set; }
        public int SumaCursados { get; set; }
        public float SumaPorcentajeCursados { get; set; }
        public int MontoPromedio { get; set; }
        public int SumaInteresados { get; set; }
        public float SumaPorcentajeInteresados { get; set; }
    }
    public class TrackingWidgetsSucursal
    {
        public int Periodo { get; set; }
        public string Actualizacion { get; set; }
        public string diaHabilActual { get; set; }
        public int CodOficina { get; set; }
        public string Oficina { get; set; }
        public int SumaAsignadosWid { get; set; }
        public int SumaGestionadosWid { get; set; }
        public float SumaPorcentajeGestionadoWid { get; set; }
        public int SumaContactadosWid { get; set; }
        public float SumaPorcentajeContactadosWid { get; set; }
        public int SumaPresentadosWid { get; set; }
        public float SumaPorcentajePresentadosWid { get; set; }
        public int SumaAprobadosWid { get; set; }
        public float SumaPorcentajeAprobadosWid { get; set; }
        public int SumaCursadosWid { get; set; }
        public float SumaPorcentajeCursadosWid { get; set; }
        public int MontoBrutoSumWid { get; set; }
        public int MontoBrutoPromWid { get; set; }
        public int MontoNetoSumWid { get; set; }
        public int MontoNetoPromWid { get; set; }
        public int TotalECWid { get; set; }
        public int SumaInteresadosWid { get; set; }
        public float SumaPorcentajeInteresadosWid { get; set; }
    }
    public class TrackingDetalleEjecutivo
    {

        public string Periodo { get; set; }
        public int AfiliadoRut { get; set; }
        public string AfiliadoDv { get; set; }
        public string AfiliadoNombre { get; set; }
        public string AfiliadoApellido { get; set; }
        public string AfiliadoSegmento { get; set; }
        public string EmpresaRut { get; set; }
        public string EmpresaDv { get; set; }
        public string EmpresaNombre { get; set; }
        public string Holding { get; set; }
        public string FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public int Renta { get; set; }
        public int VecesRenta { get; set; }
        public int PreAprobado { get; set; }
        public int Prioridad { get; set; }
        public string EjecAsign_RutDv { get; set; }
        public int EjecAsign_Rut { get; set; }
        public string EjecAsign_Dv { get; set; }
        public string EjecAsign_Nombre { get; set; }
        public string EjecAsign_Cargo { get; set; }
        public int codOficina { get; set; }
        public string Oficina { get; set; }
        public int codZona { get; set; }
        public string Zona { get; set; }
        public int codRegion { get; set; }
        public string Region { get; set; }
        public string GestionFechaAccion { get; set; }
        public string GestionFechaCompromete { get; set; }
        public int GestionEstadoid { get; set; }
        public string GestionEstadoDescrip { get; set; }
        public int GestionSubEstadoid { get; set; }
        public string GestionSubEstadoDescrip { get; set; }
        public string GestionEstadoTerminal { get; set; }
        public string GestionObs { get; set; }
        public string GestionEjec { get; set; }
        public int GestionOficina { get; set; }
        public string PresentFechaCrea { get; set; }
        public string PresentHoraCrea { get; set; }
        public string PresentFechaEstado { get; set; }
        public string PresentHoraEstado { get; set; }
        public int PresentIdEstado { get; set; }
        public string PresentEstado { get; set; }
        public string PresentEjec { get; set; }
        public string VentaFolioCredito { get; set; }
        public string VentaProducto { get; set; }
        public string VentaFechaColocacion { get; set; }
        public int VentaPlazo { get; set; }
        public float VentaTasaInteres { get; set; }
        public int VentaMontoBruto { get; set; }
        public int VentaMontoNetoReal { get; set; }
        public string VentaRutEmpleadoCotizacion { get; set; }
        public int VentaCodOficinaCurse { get; set; }
        public int VentaOficinaCurse { get; set; }
        public int VentaCodOficinaPago { get; set; }
        public string VentaOficinaPago { get; set; }
        public int Asignados { get; set; }
        public int Gestionados { get; set; }
        public int Contactados { get; set; }
        public int Presentados { get; set; }
        public int Aprobados { get; set; }
        public int Cursados { get; set; }
        public int Interesados { get; set; }

    }
    public class TrackingDetalleEjecutivoNormalizacion
    {

        public string Periodo { get; set; }
        public int AfiliadoRut { get; set; }
        public string AfiliadoDv { get; set; }
        public string AfiliadoNombre { get; set; }
        public string AfiliadoApellido { get; set; }
        public string AfiliadoSegmento { get; set; }
        public string EmpresaRut { get; set; }
        public string EmpresaDv { get; set; }
        public string EmpresaNombre { get; set; }
        public string Holding { get; set; }
        public string FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public int Renta { get; set; }
        public int VecesRenta { get; set; }
        public int PreAprobado { get; set; }
        public int Prioridad { get; set; }
        public string EjecAsign_RutDv { get; set; }
        public int EjecAsign_Rut { get; set; }
        public string EjecAsign_Dv { get; set; }
        public string EjecAsign_Nombre { get; set; }
        public string EjecAsign_Cargo { get; set; }
        public int codOficina { get; set; }
        public string Oficina { get; set; }
        public int codZona { get; set; }
        public string Zona { get; set; }
        public int codRegion { get; set; }
        public string Region { get; set; }
        public string GestionFechaAccion { get; set; }
        public string GestionFechaCompromete { get; set; }
        public int GestionEstadoid { get; set; }
        public string GestionEstadoDescrip { get; set; }
        public int GestionSubEstadoid { get; set; }
        public string GestionSubEstadoDescrip { get; set; }
        public string GestionEstadoTerminal { get; set; }
        public string GestionObs { get; set; }
        public string GestionEjec { get; set; }
        public int GestionOficina { get; set; }
        public string PresentFechaCrea { get; set; }
        public string PresentHoraCrea { get; set; }
        public string PresentFechaEstado { get; set; }
        public string PresentHoraEstado { get; set; }
        public int PresentIdEstado { get; set; }
        public string PresentEstado { get; set; }
        public string PresentEjec { get; set; }
        public string VentaFolioCredito { get; set; }
        public string VentaProducto { get; set; }
        public string VentaFechaColocacion { get; set; }
        public int VentaPlazo { get; set; }
        public float VentaTasaInteres { get; set; }
        public int VentaMontoBruto { get; set; }
        public int VentaMontoNetoReal { get; set; }
        public string VentaRutEmpleadoCotizacion { get; set; }
        public int VentaCodOficinaCurse { get; set; }
        public int VentaOficinaCurse { get; set; }
        public int VentaCodOficinaPago { get; set; }
        public string VentaOficinaPago { get; set; }
        public int Asignados { get; set; }
        public int Gestionados { get; set; }
        public int Contactados { get; set; }
        public int Presentados { get; set; }
        public int Aprobados { get; set; }
        public int Cursados { get; set; }
        public int Interesados { get; set; }

    }
    public class TrackingWidgetsEjecutivo
    {
        public int Periodo { get; set; }
        public string Actualizacion { get; set; }
        public string diaHabilActual { get; set; }
        public string nombreEjecutivo { get; set; }
        public int CodOficina { get; set; }
        public string Oficina { get; set; }
        public int SumaAsignadosWidEjec { get; set; }
        public int SumaGestionadosWidEjec { get; set; }
        public float SumaPorcentajeGestionadoWidEjec { get; set; }
        public int SumaContactadosWidEjec { get; set; }
        public float SumaPorcentajeContactadosWidEjec { get; set; }
        public int SumaPresentadosWidEjec { get; set; }
        public float SumaPorcentajePresentadosWidEjec { get; set; }
        public int SumaAprobadosWidEjec { get; set; }
        public float SumaPorcentajeAprobadosWidEjec { get; set; }
        public int SumaCursadosWidEjec { get; set; }
        public float SumaPorcentajeCursadosWidEjec { get; set; }
        public int MontoBrutoSumWidEjec { get; set; }
        public int MontoBrutoPromWidEjec { get; set; }
        public int MontoNetoSumWidEjec { get; set; }
        public int MontoNetoPromWidEjec { get; set; }
        public int TotalECWidEjec { get; set; }
    }
    public class TrackingWidgetsEjecutivoNormalizacion
    {
        public int Periodo { get; set; }
        public string Actualizacion { get; set; }
        public string diaHabilActual { get; set; }
        public string nombreEjecutivo { get; set; }
        public int CodOficina { get; set; }
        public string Oficina { get; set; }
        public int SumaAsignadosWidEjec { get; set; }
        public int SumaGestionadosWidEjec { get; set; }
        public float SumaPorcentajeGestionadoWidEjec { get; set; }
        public int SumaContactadosWidEjec { get; set; }
        public float SumaPorcentajeContactadosWidEjec { get; set; }
        public int SumaPresentadosWidEjec { get; set; }
        public float SumaPorcentajePresentadosWidEjec { get; set; }
        public int SumaAprobadosWidEjec { get; set; }
        public float SumaPorcentajeAprobadosWidEjec { get; set; }
        public int SumaCursadosWidEjec { get; set; }
        public float SumaPorcentajeCursadosWidEjec { get; set; }
        public int MontoBrutoSumWidEjec { get; set; }
        public int MontoBrutoPromWidEjec { get; set; }
        public int MontoNetoSumWidEjec { get; set; }
        public int MontoNetoPromWidEjec { get; set; }
        public int TotalECWidEjec { get; set; }
    }
    public class TrackingComboCargo
    {
        public int Periodo { get; set; }
        public string EjecutivoCargo { get; set; }
    }
    public class TrackingComboCargoNormalizacion
    {
        public int Periodo { get; set; }
        public string EjecutivoCargo { get; set; }
    }

    public class TrackingWidgetsPais
    {
        public string Pais { get; set; }
        public string FechaActualizacion { get; set; }
        public int Periodo { get; set; }
        public string DiaHabil { get; set; }
        public int rateGestion { get; set; }
        public int SumAsignado { get; set; }
        public int SumGestionado { get; set; }
        public float PorcentajeGestionado { get; set; }
        public int SumContactado { get; set; }
        public float PorcentajeContactado { get; set; }
        public int SumPresentado { get; set; }
        public float PorcentajePresentado { get; set; }
        public int SumAprobado { get; set; }
        public float PorcentajeAprobado { get; set; }
        public int SumCursado { get; set; }
        public float PorcentajeCursado { get; set; }
        public Int64 SumBruto { get; set; }
        public Int64 PromBruto { get; set; }
        public Int64 SumNeto { get; set; }
        public Int64 PromNeto { get; set; }
        public Int64 TotalEC { get; set; }
        public int SumInteresado { get; set; }
        public int SumRechazado { get; set; }
        public float PorcentajeInteresado { get; set; }
    }
    public class TrackingWidgetsZonal
    {

        public int Periodo { get; set; }
        public string FechaActualizacion { get; set; }
        public string DiaHabil { get; set; }
        public int rateGestion { get; set; }
        public int CodZona { get; set; }
        public string Zona { get; set; }
        public int SumAsignado { get; set; }
        public int SumGestionado { get; set; }
        public float PorcentajeGestionado { get; set; }
        public int SumContactado { get; set; }
        public float PorcentajeContactado { get; set; }
        public int SumPresentado { get; set; }
        public float PorcentajePresentado { get; set; }
        public int SumAprobado { get; set; }
        public float PorcentajeAprobado { get; set; }
        public int SumCursado { get; set; }
        public float PorcentajeCursado { get; set; }
        public Int64 SumBruto { get; set; }
        public Int64 PromBruto { get; set; }
        public Int64 SumNeto { get; set; }
        public Int64 PromNeto { get; set; }
        public Int64 TotalEC { get; set; }
        public int SumInteresado { get; set; }
        public int SumRechazado { get; set; }
        public float PorcentajeInteresado { get; set; }
    }

    public class TrackingSucursalZonal
    {
        public int Periodo { get; set; }
        public string FechaActualizacion { get; set; }
        public string DiaHabil { get; set; }
        public int rateGestion { get; set; }
        public int CodZona { get; set; }
        public string Zona { get; set; }
        public int CodOficina { get; set; }
        public string Oficina { get; set; }
        public Int64 SumAsignado { get; set; }
        public Int64 SumGestionado { get; set; }
        public float PorcentajeGestionado { get; set; }
        public Int64 SumContactado { get; set; }
        public float PorcentajeContactado { get; set; }
        public Int64 SumPresentado { get; set; }
        public float PorcentajePresentado { get; set; }
        public Int64 SumAprobado { get; set; }
        public float PorcentajeAprobado { get; set; }
        public Int64 SumCursado { get; set; }
        public float PorcentajeCursado { get; set; }
        public Int64 SumBruto { get; set; }
        public Int64 PromBruto { get; set; }
        public Int64 SumNeto { get; set; }
        public Int64 PromNeto { get; set; }
        public Int64 TotalEC { get; set; }
        public Int64 SumInteresado { get; set; }
        public Int64 SumRechazado { get; set; }
        public float PorcentajeInteresado { get; set; }
    }


    //NORMALIZACION
    public class TrackingWidgetsPaisNormalizacion
    {
        public string Pais { get; set; }
        public string FechaActualizacion { get; set; }
        public int Periodo { get; set; }
        public string DiaHabil { get; set; }
        public int rateGestion { get; set; }
        public int SumAsignado { get; set; }
        public int SumGestionado { get; set; }
        public float PorcentajeGestionado { get; set; }
        public int SumContactado { get; set; }
        public float PorcentajeContactado { get; set; }
        public int SumPresentado { get; set; }
        public float PorcentajePresentado { get; set; }
        public int SumAprobado { get; set; }
        public float PorcentajeAprobado { get; set; }
        public int SumCursado { get; set; }
        public float PorcentajeCursado { get; set; }
        public Int64 SumBruto { get; set; }
        public Int64 PromBruto { get; set; }
        public Int64 SumNeto { get; set; }
        public Int64 PromNeto { get; set; }
        public Int64 TotalEC { get; set; }
        public int SumInteresado { get; set; }
        public int SumRechazado { get; set; }
        public float PorcentajeInteresado { get; set; }
    }
    public class TrackingWidgetsZonalNormalizacion
    {

        public int Periodo { get; set; }
        public string FechaActualizacion { get; set; }
        public string DiaHabil { get; set; }
        public int rateGestion { get; set; }
        public int CodZona { get; set; }
        public string Zona { get; set; }
        public int SumAsignado { get; set; }
        public int SumGestionado { get; set; }
        public float PorcentajeGestionado { get; set; }
        public int SumContactado { get; set; }
        public float PorcentajeContactado { get; set; }
        public int SumPresentado { get; set; }
        public float PorcentajePresentado { get; set; }
        public int SumAprobado { get; set; }
        public float PorcentajeAprobado { get; set; }
        public int SumCursado { get; set; }
        public float PorcentajeCursado { get; set; }
        public Int64 SumBruto { get; set; }
        public Int64 PromBruto { get; set; }
        public Int64 SumNeto { get; set; }
        public Int64 PromNeto { get; set; }
        public Int64 TotalEC { get; set; }
        public int SumInteresado { get; set; }
        public int SumRechazado { get; set; }
        public float PorcentajeInteresado { get; set; }
    }
    public class TrackingSucursalZonalNormalizacion
    {
        public int Periodo { get; set; }
        public string FechaActualizacion { get; set; }
        public string DiaHabil { get; set; }
        public int rateGestion { get; set; }
        public int CodZona { get; set; }
        public string Zona { get; set; }
        public int CodOficina { get; set; }
        public string Oficina { get; set; }
        public int SumAsignado { get; set; }
        public int SumGestionado { get; set; }
        public float PorcentajeGestionado { get; set; }
        public int SumContactado { get; set; }
        public float PorcentajeContactado { get; set; }
        public int SumPresentado { get; set; }
        public float PorcentajePresentado { get; set; }
        public int SumAprobado { get; set; }
        public float PorcentajeAprobado { get; set; }
        public int SumCursado { get; set; }
        public float PorcentajeCursado { get; set; }
        public int SumBruto { get; set; }
        public int PromBruto { get; set; }
        public int SumNeto { get; set; }
        public int PromNeto { get; set; }
        public int TotalEC { get; set; }
        public int SumInteresado { get; set; }
        public int SumRechazado { get; set; }
        public float PorcentajeInteresado { get; set; }
    }

    public class TrackingEjecutivoGestion
    {
        public string Campana { get; set; }
        public int Asignados { get; set; }
        public int Gestionados { get; set; }
        public int Contactados { get; set; }
        public int Interesados { get; set; }
        public int Cursados { get; set; }
    }

    public class TrackinVencimientosGestiones
    {
        public int Vencidos { get; set; }
        public int VenceHoy { get; set; }
        public int VenceProx { get; set; }
    }


    public class TrackEjecutivoGestionNormalizacion
    {
        public int AsignadosNorm { get; set; }
        public int GestionadosNorm { get; set; }
        public int ContactadosNorm { get; set; }
        public int InteresadosNorm { get; set; }
        public int CursadosNorm { get; set; }
        public float SumaPorcentajeCurNorm { get; set; }
    }

    public class TrackVencimientosGesNormalizacion
    {
        public int VencidosNorm { get; set; }
        public int VenceHoyNorm { get; set; }
        public int VenceProxNorm { get; set; }
    }





}
