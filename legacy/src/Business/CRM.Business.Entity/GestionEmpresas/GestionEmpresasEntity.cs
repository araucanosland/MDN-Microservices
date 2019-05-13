using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity
{
    public class GestionEmpresasEntity
    {

        public string RutEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public string Segmento { get; set; }
        public int IdSucursalEmpresa { get; set; }
        public string SucursalEmpresa { get; set; }
        public int CodOficina { get; set; }
        public int NTrabajador { get; set; }
        public int Holding { get; set; }
        public string Comentarios { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string EjecutivoIngreso { get; set; }
        public string NombreHolding { get; set; }
        public string FechaAntiguedad { get; set; }
        public string Anexo { get; set; }
        public int NumTrabajadores { get; set; }

    }
    public class CarteraEmpresasEntity
    {
        public int Id { get; set; }
        public string RutEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public string Segmento { get; set; }
        public int IdSucursalEmpresa { get; set; }
        public string SucursalEmpresa { get; set; }
        public int CodOficina { get; set; }
        public int NTrabajador { get; set; }
        public int Holding { get; set; }
        public string Comentarios { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string EjecutivoIngreso { get; set; }
        public string NombreHolding { get; set; }
        public string Tipo { get; set; }
        public int IdEmpresa { get; set; }

        public int CountAnexo { get; set; }
        public int CountEmp { get; set; }
    }

    public class AsigandosEjecutivoEmpresaEntity
    {
        public int Id_Asign { get; set; }
        public int Afiliado_Rut { get; set; }
        public string Afiliado_Dv { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int Monto_preaprobado { get; set; }
        public int Contacto { get; set; }
        public int PreAprobadoFinal { get; set; }
        public int CredVigente { get; set; }
        public int TipoAsignacion { get; set; }
        public string TipoCampania { get; set; }
        public int Prioridad { get; set; }
    }

    public class ComunasEmpresaEntity
    {
        public string NombreComuna { get; set; }
        public int IdComuna { get; set; }
    }

    public class EjecutivosAsignadosEntity
    {
        public string RutEjecutivoAsignado { get; set; }
    }

    public class ContadorAnexoEntity
    {
        public int TotalAnexos { get; set; }
    }

    public class AnexoEmpresaEntity
    {
        public int IdEmpresaAnexo { get; set; }
        public string RutEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public string Anexo { get; set; }
        public int NumTrabajadores { get; set; }
        public int IdComuna { get; set; }
        public string NombreComuna { get; set; }
        public string Direccion { get; set; }
        public int TotalAsignados { get; set; }
        public int EsMatriz { get; set; }
        
    }

    public class AsignacionAnexoEmpresa
    {
        public string Tipo { get; set; }
        public int Id { get; set; }
        public string EjecAsignado { get; set; }
    }


    public class EjecutivosOficina
    {
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }
    }

    public class EntrevistaEntity
    {
        public int IdEntrevista { get; set; }
        public string RutEmpresa { get; set; }
        public string FechaEntrevista { get; set; }
        public string NombreContacto { get; set; }
        public string Estamento { get; set; }
        public string Cargo { get; set; }
        public string TelefonoContacto { get; set; }
        public string CorreoContacto { get; set; }
        public string Comentarios { get; set; }
        public string Tipo { get; set; }
        public string RutEjeIngreso { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string NombreEjecutivo { get; set; }
        public int IdAnexo { get; set; }
    }


    public class DetalleEntrevistaEntity
    {
        public int IdDetalleEntrevista { get; set; }
        public int IdEntrevista { get; set; }
        public string Tema { get; set; }
        public string SubTema { get; set; }
        public string Semaforo { get; set; }
        public int Alerta { get; set; }
        public string FechaResolucion { get; set; }
        public string Comentarios { get; set; }
        public string RutEjeIngreso { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string NombreEjecutivo { get; set; }
        public int Compromiso { get; set; }
        public int FlagActualizacion { get; set; }
        public int IdDetalleOrigen { get; set; }
    }
    public class IdEntrevistaEntity
    {
        public int IdEntrevista { get; set; }
    }

    public class GestionMantencionEntity
    {
        public int IdGesMantencion { get; set; }
        public int IdCabGesMantencion { get; set; }
        public string RutEmpresa { get; set; }
        public string Tema { get; set; }
        public string SubTema { get; set; }
        public string RutAfiliado { get; set; }
        public string Comentarios { get; set; }
        public string RutEjeIngreso { get; set; }
        public string NombreEjecutivo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int Alerta { get; set; }
        public int FlagActualizacion { get; set; }
        public int IdDetalleOrigen { get; set; }
    }

    public class TipologiaGestionEntity
    {
        public int IdTema { get; set; }
        public string GlosaGestion { get; set; }
    }

    public class TipologiaSubGestionEntity
    {
        public int IdSubTema { get; set; }
        public string GlosaSubTema { get; set; }
    }

    public class AfiliadoOficinaEntity
    {
        public string RutAfiliado { get; set; }
        public string NombreAfiliado { get; set; }
    }

    public class CabGestionMantencionEntity
    {
        public int IdCabGesMantencion { get; set; }
        public string RutEmpresa { get; set; }
        public string Tipo { get; set; }
        public string Comentarios { get; set; }
        public string RutEjeIngreso { get; set; }
        public string FechaIngreso { get; set; }
        public string NombreEjecutivo { get; set; }
        public int Oficna { get; set; }
        public int Anexo { get; set; }
    }


    public class AgendaEmpresaEntity
    {
        public int IdAgenda { get; set; }
        public int IdRegistro { get; set; }
        public string RutEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public string RutEjecutivo { get; set; }
        public string Glosa { get; set; }
        public DateTime FechaInico { get; set; }
        public DateTime FechaFin { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string Frecuencia { get; set; }
        public string Dias { get; set; }
        public int DiasSucede { get; set; }
        public string TipoVisita { get; set; }
        public int CodOficina { get; set; }
        public int IdAnexo { get; set; }
        public int NCitas { get; set; }

    }

    public class RegionEmpresaEntity
    {
        public int Region_codigo { get; set; }
        public string Region_nombre { get; set; }
    }

    public class ComunaEmpresaEntity
    {
        public int Comuna_codigo { get; set; }
        public string Comuna_nombre { get; set; }
    }
}
