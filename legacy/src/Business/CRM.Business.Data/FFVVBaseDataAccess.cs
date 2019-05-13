using System;
using System.Collections.Generic;
using System.Data;
using CRM.Business.Entity;
using CDK.Data;
using CDK.Integration;

namespace CRM.Business.Data
{
    public class FFVVBaseDataAccess
    {
        public static List<FFVVBaseEntity> ListarResumenFFVVEjecutivo(string TokenEjecutivo, int Periodo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@TokenEjecutivo",TokenEjecutivo),
                new Parametro("@Periodo", Periodo),
            };
            return DBHelper.InstanceReportes.ObtenerColeccion("negocios.SPReporte_Reporte_ResumenFFVV", pram, ConstructorEntidad);
        }
        private static FFVVBaseEntity ConstructorEntidad(DataRow row)
        {
            return new FFVVBaseEntity
            {
                periodo = row["MesVenta"] != DBNull.Value ? Convert.ToInt32(row["MesVenta"]) : 0,
                rutEjecutivo = row["RutEje"] != DBNull.Value ? Convert.ToInt32(row["RutEje"]) : 0,//row["RutEje"].ToString() : string.Empty,
                rutAfiliado = row["RutAfiliado"] != DBNull.Value ? row["RutAfiliado"].ToString() : string.Empty,
                dvAfiliado = row["DvAfiliado"] != DBNull.Value ? row["DvAfiliado"].ToString() : string.Empty,
                nombreAfiliado = row["NombreAfiliado"] != DBNull.Value ? row["NombreAfiliado"].ToString() : string.Empty,
                apellidoAfiliado = row["ApellidoAfiliado"] != DBNull.Value ? row["ApellidoAfiliado"].ToString() : string.Empty,
                montoBruto = row["MontoBruto"] != DBNull.Value ? Convert.ToInt32(row["MontoBruto"]) : 0,
                montoNetoReal = row["montoNetoReal"] != DBNull.Value ? Convert.ToInt32(row["montoNetoReal"]) : 0,
                tipoCliente = row["TipoCliente"] != DBNull.Value ? row["TipoCliente"].ToString() : string.Empty,
                //TipoClienteCampana
                tipoCamapana = row["TipoClienteCampana"] != DBNull.Value ? row["TipoClienteCampana"].ToString() : string.Empty,
            };
        }

        public static List<DetalleFFVVBase> ListarDetalleFFVVEjecutivo(string TokenEjecutivo, int Periodo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@TokenEjecutivo",TokenEjecutivo),
                new Parametro("@Periodo", Periodo),
            };
            return DBHelper.InstanceReportes.ObtenerColeccion("negocios.SPReporte_ReporteResumenFFVVDetalle", pram, ContructorDetalle);
        }

        private static DetalleFFVVBase ContructorDetalle(DataRow row)
        {
            return new DetalleFFVVBase
            {
                periodo = row["MesVenta"] != DBNull.Value ? Convert.ToInt32(row["MesVenta"]) : 0,
                rutEjecutivo = row["RutEjec"] != DBNull.Value ? Convert.ToInt32(row["RutEjec"]) : 0,
                nombreEjecutivo = row["NombreEje"] != DBNull.Value ? row["NombreEje"].ToString() : string.Empty,
                nOpCHSinCredito = row["OP_Historico"] != DBNull.Value ? Convert.ToInt32(row["OP_Historico"]) : 0,
                montoCHSinCredito = row["Mto_Historico"] != DBNull.Value ? Convert.ToInt32(row["Mto_Historico"]) : 0,
                nOpCSinCredVigente = row["OP_SinCredito"] != DBNull.Value ? Convert.ToInt32(row["OP_SinCredito"]) : 0,
                montoCSinCredVigente = row["Mto_SinCredito"] != DBNull.Value ? Convert.ToInt32(row["Mto_SinCredito"]) : 0,
                nOpCCreditoVigente = row["OP_ConCredito"] != DBNull.Value ? Convert.ToInt32(row["OP_ConCredito"]) : 0,
                montoCCreditoVigente = row["Mto_ConCredito"] != DBNull.Value ? Convert.ToInt32(row["Mto_ConCredito"]) : 0,
                TotalOperaciones = row["Total_OP"] != DBNull.Value ? Convert.ToInt32(row["Total_OP"]) : 0,
                TotalMonto = row["Total_Monto"] != DBNull.Value ? Convert.ToInt32(row["Total_Monto"]) : 0,

            };
        }
        public static List<PagoComisionesHistorico> ListarComisionHitorica(string TokenEjecutivo,int Periodo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@TokenEjecutivo",TokenEjecutivo),
                new Parametro("@Periodo", Periodo),
            };
            return DBHelper.InstanceReportes.ObtenerColeccion("negocios.SPReporte_PagoComisionHistorico", pram, ContructorHistoricoComision);
        }
        private static PagoComisionesHistorico ContructorHistoricoComision(DataRow row)
        {
            return new PagoComisionesHistorico
            {
                periodo = row["MesVenta"] != DBNull.Value ? Convert.ToInt32(row["MesVenta"]) : 0,
                rutEjecutivo = row["RutEjecutivo"] != DBNull.Value ? Convert.ToInt32(row["RutEjecutivo"]) : 0,
                nombreEjecutivo = row["NombreEjecutivo"] != DBNull.Value ? row["NombreEjecutivo"].ToString() : string.Empty,
                opHistorico = row["OpeHistoricos"] != DBNull.Value ? Convert.ToInt32(row["OpeHistoricos"]) : 0,
                mtoHistorico = row["MtoHistoricos"] != DBNull.Value ? Convert.ToInt32(row["MtoHistoricos"]) : 0,
                opSinCredito = row["OpeSinCredito"] != DBNull.Value ? Convert.ToInt32(row["OpeSinCredito"]) : 0,
                mtoSinCredito = row["MtoSinCredito"] != DBNull.Value ? Convert.ToInt32(row["MtoSinCredito"]) : 0,
                opConCredito = row["OpeConCredito"] != DBNull.Value ? Convert.ToInt32(row["OpeConCredito"]) : 0,
                mtoConCredito = row["MtoConCredito"] != DBNull.Value ? Convert.ToInt32(row["MtoConCredito"]) : 0,
                totalOpValido = row["TotalOpeValidas"] != DBNull.Value ? Convert.ToInt32(row["TotalOpeValidas"]) : 0,
                totalMtoValido = row["TotalMtoValido"] != DBNull.Value ? Convert.ToInt32(row["TotalMtoValido"]) : 0,
                nOperacion = row["N_Operacion"] != DBNull.Value ? Convert.ToInt32(row["N_Operacion"]) : 0,
                mtoNOperacion = row["MontoN_Operacion"] != DBNull.Value ? Convert.ToInt32(row["MontoN_Operacion"]) : 0,
                totalOperacion = row["TotalOperaciones"] != DBNull.Value ? Convert.ToInt32(row["TotalOperaciones"]) : 0,


            };
        }
        public static List<PagoComision> ListarPagoComision(string TokenEjecutivo, int Periodo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@TokenEjecutivo",TokenEjecutivo),
                new Parametro("@Periodo", Periodo),
            };
            return DBHelper.InstanceReportes.ObtenerColeccion("negocios.SPReportePagoComision", pram, ConstructorPagoComision);
        }
        private static PagoComision ConstructorPagoComision(DataRow row)
        {
            return new PagoComision
            {
                periodo = row["MesVenta"] != DBNull.Value ? Convert.ToInt32(row["MesVenta"]) : 0,
                //rutEjecutivo = row["RutEjecutivo"] != DBNull.Value ? Convert.ToInt32(row["RutEjecutivo"]) : 0,
                totalOperacion= row["TotalOperaciones"] != DBNull.Value ? Convert.ToInt32(row["TotalOperaciones"]) : 0,
                mtoNeto = row["Monto_Neto"] != DBNull.Value ? Convert.ToInt32(row["Monto_Neto"]) : 0,
                incentivoNOperacion = row["IncentivoN_Operacion"] != DBNull.Value ? Convert.ToInt32(row["IncentivoN_Operacion"]) : 0,
                cliHistorico = row["Cliente_Historico"] != DBNull.Value ? Convert.ToInt32(row["Cliente_Historico"]) : 0,
                cliSinCredito = row["Cliente_sin_credito"] != DBNull.Value ? Convert.ToInt32(row["Cliente_sin_credito"]) : 0,
                cliConCredito = row["Cliente_con_credito"] != DBNull.Value ? Convert.ToInt32(row["Cliente_con_credito"]) : 0,
                nSegurosVendidos = row["NSeguros_Vendidos"] != DBNull.Value ? Convert.ToInt32(row["NSeguros_Vendidos"]) : 0,
                incentivoNSeguros = row["Incentivo_N_Seguros"] != DBNull.Value ? Convert.ToInt32(row["Incentivo_N_Seguros"]) : 0,
                totalComision = row["TotalComision"] != DBNull.Value ? Convert.ToInt32(row["TotalComision"]) : 0,

            };
        }


        public static List<IncentivoFFVV> ListarIncentivoFFVV()
        {
            return DBHelper.InstanceReportes.ObtenerColeccion("negocios.SPReporte_ReporteFFVVIncentivo", ConstructorIncentivoFFVV);
        }
        private static IncentivoFFVV ConstructorIncentivoFFVV(DataRow row)
        {
            return new IncentivoFFVV
             {
                desde = row["Desde"] != DBNull.Value ? Convert.ToInt32(row["Desde"]) : 0,
                hasta = row["Hasta"] != DBNull.Value ? row["Hasta"].ToString() : string.Empty,
                MayorMM25 = row[">MM25"] != DBNull.Value ? Convert.ToInt32(row[">MM25"]) : 0,
                M25_35MM = row[">=25_<35"] != DBNull.Value ? Convert.ToInt32(row[">=25_<35"]) : 0,
                M35_50MM = row[">=35_<50"] != DBNull.Value ? Convert.ToInt32(row[">=35_<50"]) : 0,
                M50_70MM = row[">=50_<70"] != DBNull.Value ? Convert.ToInt32(row[">=50_<70"]) : 0,
                M70= row[">=70"] != DBNull.Value ? Convert.ToInt32(row[">=70"]) : 0,
            };

        }
        public static List<ComisionesColocacionesFFVV> ListarComisionesFFVV()
        {
            return DBHelper.InstanceReportes.ObtenerColeccion("negocios.SPReporte_ReporteFFVVComisiones", ConstructorComisiones);
        }
        private static ComisionesColocacionesFFVV ConstructorComisiones(DataRow row)
        {
            return new ComisionesColocacionesFFVV
            {
                desdeCo = row["DesdeCo"] != DBNull.Value ? Convert.ToInt32(row["DesdeCo"]) : 0,
                hastaCo =row["HastaCo"] != DBNull.Value ? row["HastaCo"].ToString() : string.Empty,
                PorcCliHistoSinCredito= row["PorcCliHistoSinCredito"] != DBNull.Value ? row["PorcCliHistoSinCredito"].ToString() : string.Empty,
                PorcCliSinCreditoVigente =row["PorcCliSinCreditoVigente"] != DBNull.Value ? row["PorcCliSinCreditoVigente"].ToString() : string.Empty,
                PorcCliConCreditoVigente = row["PorcCliConCreditoVigente"] != DBNull.Value ? row["PorcCliConCreditoVigente"].ToString() : string.Empty,
            };
        }



    }
}