using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity.Afiliados
{
    public class AfiliadosEntity
    {
        public int Periodo { get; set; }
        public string RutAfiliado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Nacionalidad { get; set; }
        public string Sexo { get; set; }
        public string FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string EstadoCivil { get; set; }
        public string RolSegmentoAfiliado { get; set; }
        public string InicioValidezRol { get; set; }
        public string FinValidezRol { get; set; }
        public string RegimenPrevisional { get; set; }
        public string RegimenSalud { get; set; }
        public string CargoAfiliado { get; set; }
        public string TipoContrato { get; set; }
        public int PeriodoUltimaRenta { get; set; }
        public int RentaUltimaInformada { get; set; }
        public string RegionAfiliado { get; set; }
        public string ComunaAfiliado { get; set; }
        public string Cel { get; set; }
        public string Fono { get; set; }
        public string Mail { get; set; }
        public int Vigente { get; set; }
        public int Fallecido { get; set; }
        public int FlagNoMolestar { get; set; }
        public string MotivoNM { get; set; }


    }
    public class AfiliadoEmpresaEntity
    {
        public int RutEmpresa { get; set; }
        public string RutEmpresaDv { get; set; }
        public string NombreEmpresa { get; set; }

    }

    public class EmpresaAfiliadoEntity
    {
        public int RutEmpresa { get; set; }
        public string RutEmpresaDv { get; set; }
        public string NombreEmpresa { get; set; }
        public string PeriodoUltimaRenta { get; set; }
        public int RentaUltimaInformada { get; set; }
        public string RolSegmentoAfiliado { get; set; }

    }
    public class AfiliadoCampanas
    {
        public string Periodo { get; set; }
        public int RutAfiliado { get; set; }
        public string RutDvAfiliado { get; set; }
        public string Campania { get; set; }
        public int Oferta { get; set; }
        public string Prioridad { get; set; }
        public int id_Asginacion { get; set; }
        public string Tipo { get; set; }
        public int TipoAsignacion { get; set; }
        public string Estado { get; set; }
        public string SubEstado { get; set; }
        public DateTime FechaCompromete { get; set; }
        public DateTime FechaAccion { get; set; }
        public string Nombres { get; set; }
        public string Descripcion { get; set; }
        public string EsTerminal { get; set; }

    }
    public class AfiliadoDatosCumpleanios
    {
        public string Estado { get; set; }
        public string FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public int RutAfiliado { get; set; }
    }

    public class AlertasAfiliados
    {
        public int AfiliadoRut { get; set; }
        public string Tipo { get; set; }
        public string Valor { get; set; }
        public string TipoValor { get; set; }
    }

    public class NoMolestarAfiliado
    {
        public string RutAfiliado { get; set; }
        public string Motivo { get; set; }
        public DateTime Fecha_incio { get; set; }
        public string RutEjecutivoIni { get; set; }
        public int CodOficinaIni { get; set; }
        public DateTime Fecha_fin { get; set; }
        public string RutEjecutivoFin { get; set; }
        public int CodOficinaFin { get; set; }
        public int FlagEstado { get; set; }
    }

    public class ObservacionAfiliado
    {
        public string RutAfiliado { get; set; }
        public DateTime Fecha_obs { get; set; }
        public string Observacion { get; set; }
        public string RutEjecutivo { get; set; }
        public int CodOficina { get; set; }

    }

    public class AfiliadoProyeccion
    {
        public string RutAfiliado { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public string SubEstado { get; set; }
        public string Afiliado { get; set; }
        public string Ejecutivo { get; set; }
        public string Sucursal { get; set; }
        public int PreAprobadoFinal { get; set; }
        public string Periodo { get; set; }
        public int EstadoGestion { get; set; }

    }

    public class GestionAfiliadoFalabella
    {
        public Guid TicketGestion { get; set; }
        public string RutAfiliado { get; set; }
        public string TipoGestion { get; set; }
        public string Observacion { get; set; }
        public string MontoRef { get; set; }
        public string Beneficios { get; set; }
        public string Ejecutivo { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public GestionAfiliadoFalabella()
        {
            TicketGestion = Guid.Empty;
            RutAfiliado = string.Empty;
            TipoGestion = string.Empty;
            Observacion = string.Empty;
            MontoRef = string.Empty;
            Beneficios = string.Empty;
            Ejecutivo = string.Empty;
            Telefono = string.Empty;
            Correo = string.Empty;
        }
    }


    public class MedicamantosEncuestaEntity
    {
        public int Id { get; set; }
        public string Medicamento { get; set; }
        public string Categoria { get; set; }
    }

    public class EnfermedadesEncuestaEntity
    {
        public int Id { get; set; }
        public string Patologia { get; set; }
        public string Categoria { get; set; }
    }

    public class EncuestaEntity
    {
        public string Rut_Afiliado { get; set; }
        public string Nombre_Afiliado { get; set; }
        public string Rut_Ejecutivo { get; set; }
        public int Sucursal { get; set; }
        public string Tiene_Enfermedad { get; set; }
        public string Enfermedad_1 { get; set; }
        public string Enfermedad_2 { get; set; }
        public string Enfermedad_3 { get; set; }
        public string Enfermedad_4 { get; set; }
        public string Enfermedad_5 { get; set; }
        public string Enfermedad_6 { get; set; }
        public string Enfermedad_7 { get; set; }
        public string Enfermedad_8 { get; set; }
        public string Enfermedad_9 { get; set; }
        public string Enfermedad_10 { get; set; }
        public string Enfermedad_11 { get; set; }
        public string Medicamentos_1 { get; set; }
        public string Medicamentos_2 { get; set; }
        public string Medicamentos_3 { get; set; }
        public string Medicamentos_4 { get; set; }
        public string Medicamentos_5 { get; set; }
        public string Medicamentos_6 { get; set; }
        public string Medicamentos_7 { get; set; }
        public string Medicamentos_8 { get; set; }
        public string Medicamentos_9 { get; set; }
        public string Medicamentos_10 { get; set; }
        public string Medicamentos_11 { get; set; }
        public string Medicamentos_12 { get; set; }
        public string Medicamentos_13 { get; set; }
        public string Medicamentos_14 { get; set; }
        public string Medicamentos_15 { get; set; }
        public string Medicamentos_16 { get; set; }
        public string Adquiere_CanastaGes { get; set; }
        public string Adquiere_Consultorio { get; set; }
        public string Adquiere_Farmacia { get; set; }
        public string NombreFarmacia { get; set; }
        public string Actividad { get; set; }
        public string Sexo { get; set; }
        public string Edad { get; set; }
        public string Prevision { get; set; }
        // public string Region { get; set; }
        public int Flag_Encuesta { get; set; }


        public EncuestaEntity()
        {
            Rut_Afiliado = string.Empty;
            Nombre_Afiliado = string.Empty;
            Rut_Ejecutivo = string.Empty;
            Sucursal = 0;
            Tiene_Enfermedad = "";
            Enfermedad_1 = "";
            Enfermedad_2 = "";
            Enfermedad_3 = "";
            Enfermedad_4 = "";
            Enfermedad_5 = "";
            Enfermedad_6 = "";
            Enfermedad_7 = "";
            Enfermedad_8 = "";
            Enfermedad_9 = "";
            Enfermedad_10 ="";
            Enfermedad_11 = "";
            Medicamentos_1 = "";
            Medicamentos_2 = "";
            Medicamentos_3 = "";
            Medicamentos_4 = "";
            Medicamentos_5 = "";
            Medicamentos_6 = "";
            Medicamentos_7 = "";
            Medicamentos_8 = "";
            Medicamentos_9 = "";
            Medicamentos_10 = "";
            Medicamentos_11 = "";
            Medicamentos_12 = "";
            Medicamentos_13 = "";
            Medicamentos_14 = "";
            Medicamentos_15 = "";
            Medicamentos_16 = "";
            Adquiere_CanastaGes = "";
            Adquiere_Consultorio = "";
            Adquiere_Farmacia = "";
            NombreFarmacia = "";
            Actividad = "";
            Sexo = "";
            Edad = "";
            Prevision = "";
            // public string Region { get; set; }
            Flag_Encuesta = 0;
        }
    }


}
