using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity.Clases
{
    public class WebGestion
    {
        public int ges_estado { get; set; }
        public int ges_subestado { get; set; }
        public string ges_prox_gestion { get; set; }
        public string ges_comentarios { get; set; }
        public int ges_id_asignacion { get; set; }

    }


    public class WebGestionNormalizacion
    {
        public int ges_causa_basal_normalizacion { get; set; }
        public int ges_consecuencia_normalizacion { get; set; }
        public int ges_estado_normalizacion { get; set; }
        public string ges_prox_gestion_normalizacion { get; set; }
        public string ges_comentarios_normalizacion { get; set; }
        public int ges_id_asignacion_normalizacion { get; set; }

    }
    public class WebGestionNormalizacionTMC
    {
        public int ges_estadoTMC { get; set; }
        public int ges_subestadoTMC { get; set; }
        public string ges_prox_gestionTMC { get; set; }
        public string ges_comentariosTMC { get; set; }
        public int ges_id_asignacionTMC { get; set; }
    }

    public class WebGestionNormalizacionSC
    {
        public int ges_estadoSC { get; set; }
        public int ges_subestadoSC { get; set; }
        public string ges_prox_gestionSC { get; set; }
        public string ges_comentariosSC { get; set; }
        public int ges_id_asignacionSC { get; set; }
    }

    public class WebDatoContacto
    {
        public int afiliado_Rut { get; set; }
        public string tipo { get; set; }
        public string valor_contacto { get; set; }
        public int valido { get; set; }
    }


    public class WebPreferenciaAfiliado
    {
        public int afiliado_Rut { get; set; }
        public string tipo_preferencia { get; set; }
        public string valor_preferencia { get; set; }
        public bool valido { get; set; }
    }



    public class WebReasignacionBase
    {
        public WebProcesoReasignacion ProcesoReasignacion { get; set; }
        public WebAuxLogReasignacion AuxLog { get; set; }
    }

    public class WebProcesoReasignacion
    {
        public string RutEjecutivoOrigen { get; set; }
        public string RutEjecutivoDestino { get; set; }
        public int CodOficina { get; set; }
        public string TipoCampania { get; set; }
        public int CantidadAsignaciones { get; set; }
    }

    public class WebAuxLogReasignacion
    {
        public int OrigenAntes { get; set; }
        public int OrigenDespues { get; set; }
        public int DestinoAntes { get; set; }
        public int DestinoDespues { get; set; }
        public string TokenAgente { get; set; }
    }

    public class WebDotacionData
    {
        public int periodo { get; set; }
        public int oficina { get; set; }
        public List<string> ejecutivos { get; set; }
    }

    public class WebAusenciaDot
    {
        public int IdAusencia { get; set; }
        public string RutEjecutivo { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public int CodigoMotivo { get; set; }
        public int CantidadDias { get; set; }
        public string Comentarios { get; set; }
    }

    public class WebDotacionEntrada
    {
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public int Oficina { get; set; }
        public string TipoContrato { get; set; }
        public string FechaIngreso { get; set; }
        public string FechaFinal { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
    }

    public class WebFichaEmpresa
    {
        public string rutEmpresaIngreso { get; set; }
        public string nombreEmpresaIngreso { get; set; }
        public string sslEstamentoIngreso { get; set; }
        public string FuncionarioIngreso { get; set; }
        public string CargoIngreso { get; set; }
        public int NEmpleadosIngreso { get; set; }
        public string pub { get; set; }
        public string sslOPtion1 { get; set; }
        public string textObs1 { get; set; }
        public int? respuesta1 { get; set; }
        public string sslOption2 { get; set; }
        public string textObs2 { get; set; }
        public int? respuesta2 { get; set; }
        public string textObs2_1 { get; set; }
        public string textObs2_2 { get; set; }
        public string textObs2_3 { get; set; }
        public int? respuesta3 { get; set; }
        public string textObs3 { get; set; }
        public int? respuesta4 { get; set; }
        public int? respuesta4_1 { get; set; }
        public string textObs4 { get; set; }
        public string textObs4_1 { get; set; }
        public int? respuesta5 { get; set; }
        public string textObs5 { get; set; }
        public string textObs5_1 { get; set; }
        public int? respuesta6 { get; set; }
        public string textObs6 { get; set; }
        public string textObs6_1 { get; set; }
        public int? respuesta7 { get; set; }
        public string textObs7 { get; set; }
        public string sslOption8 { get; set; }
        public string textObs8 { get; set; }
        public int? respuesta9 { get; set; }
        public int? respuesta9_1 { get; set; }
        public string textObs9 { get; set; }
        public int? respuesta10 { get; set; }
        public int? respuesta10_1 { get; set; }
        public string textObs10 { get; set; }
        public string sslOption11 { get; set; }
        public string textObs11 { get; set; }
        public DateTime fechaVisita { get; set; }
        public string Cod_sucursal { get; set; }
        //public string sslEstamentoVisita { get; set; }
        //public string funcionarioVisita { get; set; }
        //public string CargoVisita { get; set; }
        public string ncontacto { get; set; }
        public string MailIngreso { get; set; }
        public string NombreSucursal { get; set; }
        public string DireccionSucursal { get; set; }
        public string Estado { get; set; }
        public string Anexo { get; set; }
        public int idFicha { get; set; }
    }

    public class WebAsignacionEmpresa
    {
        public int wsslOficina { get; set; }
        public int wsslOficinaAnterior { get; set; }
        public string wtext_observacion { get; set; }
        public int wencRut { get; set; }
    }

    public class WebActualizaDotacionEntrada
    {
        public string Rut { get; set; }
        public string Cargo { get; set; }
        public string TipoContrato { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Sexo { get; set; }
    }
}
