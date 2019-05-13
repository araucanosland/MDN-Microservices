using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity
{
    public class EmpresaEntity__
    {
        public int idFicha { get; set; }
        public int Periodo { get; set; }
        public string PeriodoTri { get; set; }
        public int EmpresaRut { get; set; }
        public string EmpresaDV { get; set; }
        public string EmpresaNombre { get; set; }
        public int EjecRut { get; set; }
        public string EjecDV { get; set; }
        public string EmpresaTipo { get; set; }
        public string Empresa_Clasificacion { get; set; }
        public int EmpresaEjecutivo { get; set; }
        public string EmpresaEjecutivoDV { get; set; }
        public int codSucursal { get; set; }
        public string EmpresaSucursal { get; set; }
        public string EmpresaHolding { get; set; }
        public string EmpresaEstadoFicha { get; set; }


        public int CantidadFichas { get; set; }
        //nuevo

        public int CodOficina { get; set; }
        public string Estamento { get; set; }
        public string FuncionarioEmple { get; set; }
        public string FuncionarioCargo { get; set; }
        public int NumeroEmpleados { get; set; }
        public string FuncionarioCaja { get; set; }

        public string pregunta_1 { get; set; }
        public string pregunta_obs { get; set; }
        public int pregunta2_radio { get; set; }
        public string pregunta2_combo { get; set; }
        public string pregunta2_obs2 { get; set; }
        public int pregunta2_radio_1 { get; set; }
        public string pregunta2_obs3 { get; set; }
        public string pregunta2_obs4 { get; set; }
        public string pregunta2_obs5 { get; set; }
        public int pregunta3_radio { get; set; }
        public string pregunta3_obs { get; set; }
        public int pregunta4_radio { get; set; }
        public int pregunta4_radio_2 { get; set; }
        public string pregunta4_obs_1 { get; set; }
        public string pregunta4_obs_2 { get; set; }
        public int pregunta5_radio { get; set; }
        public string pregunta5_obs { get; set; }
        public string pregunta5_obs_1 { get; set; }
        public int pregunta6_radio { get; set; }
        public string pregunta6_obs_1 { get; set; }
        public string pregunta6_obs_2 { get; set; }
        public int pregunta7_radio { get; set; }
        public string pregunta7_obs_1 { get; set; }
        public string pregunta8_combo { get; set; }
        public string pregunta8_obs_1 { get; set; }
        public int pregunta9_radio { get; set; }
        public int pregunta9_radio_1 { get; set; }
        public string pregunta9_obs_1 { get; set; }
        public int pregunta10_radio { get; set; }
        public int pregunta10_radio_1 { get; set; }
        public string pregunta10_obs { get; set; }

        public string pregunta11_combo { get; set; }
        public string pregunta11_obs_1 { get; set; }
        public DateTime FechaReunionVisita { get; set; }
        public string EstamentoVisita { get; set; }
        public string Funcionario_EmpleadoVisita { get; set; }
        public string CargoFuncionarioVisita { get; set; }
        public string Estado { get; set; }
        public string Holding { get; set; }
        public int isHolding { get; set; }
        public string Anexo { get; set; }
        public string Num_Contacto { get; set; }
        public string Email { get; set; }
        public string NombreSucursal { get; set; }
        public string DireccionSucursal { get; set; }


    }
    public class FichaEmpresaEntity
    {

        public DateTime FechaIngreso { get; set; }
        public string EmpresaRut { get; set; }
        public string EmpresaNombre { get; set; }
        public string Token { get; set; }
        public string CodOficina { get; set; }
        public string Estamento { get; set; }
        public string FuncionarioEmple { get; set; }
        public string FuncionarioCargo { get; set; }
        public int NumeroEmpleados { get; set; }
        public string FuncionarioCaja { get; set; }

        #region pregunta_1
        public string pregunta_1 { get; set; }
        public string pregunta_obs { get; set; }
        #endregion
        #region pregunta_2
        public int? pregunta2_radio { get; set; }
        public string pregunta2_combo { get; set; }
        public string pregunta2_obs2 { get; set; }
        public int? pregunta2_radio_1 { get; set; }
        public string pregunta2_obs3 { get; set; }
        public string pregunta2_obs4 { get; set; }
        public string pregunta2_obs5 { get; set; }
        #endregion
        #region pregunta_3
        public int? pregunta3_radio { get; set; }
        public string pregunta3_obs { get; set; }
        #endregion
        #region pregunta_4
        public int? pregunta4_radio { get; set; }
        public int? pregunta4_radio_2 { get; set; }
        public string pregunta4_obs_1 { get; set; }
        public string pregunta4_obs_2 { get; set; }
        #endregion
        #region pregunta_5
        public int? pregunta5_radio { get; set; }
        public string pregunta5_obs { get; set; }
        public string pregunta5_obs_1 { get; set; }

        #endregion
        #region pregunta_6
        public int? pregunta6_radio { get; set; }
        public string pregunta6_obs_1 { get; set; }
        public string pregunta6_obs_2 { get; set; }

        #endregion
        #region pregunta_7
        public int? pregunta7_radio { get; set; }
        public string pregunta7_obs_1 { get; set; }
        #endregion
        #region pregunta_8
        public string pregunta8_combo { get; set; }
        public string pregunta8_obs_1 { get; set; }
        #endregion
        #region pregunta_9
        public int? pregunta9_radio { get; set; }
        public int? pregunta9_radio_1 { get; set; }
        public string pregunta9_obs_1 { get; set; }
        #endregion
        #region pregunta_10
        public int? pregunta10_radio { get; set; }
        public int? pregunta10_radio_1 { get; set; }
        public string pregunta10_obs { get; set; }

        #endregion
        #region pregunta_11
        public string pregunta11_combo { get; set; }
        public string pregunta11_obs_1 { get; set; }
        #endregion

        public DateTime FechaReunionVisita { get; set; }
        public string EstamentoVisita { get; set; }
        public string Funcionario_EmpleadoVisita { get; set; }
        public string CargoFuncionarioVisita { get; set; }
        public string Estado { get; set; }
        public string Anexo { get; set; }

        public int Id { get; set; }
        public string Num_Contacto { get; set; }
        public string Email { get; set; }
        public string NombreSucursal { get; set; }
        public string DireccionSucursal { get; set; }
    }
    public class DetalleEmpresaEntity
    {
        public int idEmpresaDetalle { get; set; }
        public string RutEmpDetalle { get; set; }
        public string NombreEmpDetalle { get; set; }
        public string OficinaEmpDetalle { get; set; }
        public string EstamentoEmpDetalle { get; set; }
        public string EstadoEmpDetalle { get; set; }
        public string NombreEjecEmpDetalle { get; set; }
        public string RutEjecEmpDetalle { get; set; }
        public string TrimentreEmpDetalle { get; set; }
        public string CargoEjecEmpresa { get; set; }
        public int Cantidad { get; set; }
        public int isHolding { get; set; }
        public int codSucursal { get; set; }
        

        public string FechaIngreso { get; set; }
        public string FechaModificacion { get; set; }
        public string NombreSucursal { get; set; }
        public string DireccionSucursal { get; set; }
    }
    public class EmpresaAsignacion
    {
        public int EmpresaRut { get; set; }
        public int CodOficina { get; set; }
        public int CodOficinaAnterior { get; set; }
        public string Observacion { get; set;}
        public string Token { get; set; }
    }
}
