using System;
using System.Collections.Generic;
using System.Data;
using CRM.Business.Entity;
using CDK.Data;
using CDK.Integration;

namespace CRM.Business.Data
{
    public class InformesDataAccess
    {
        public static List<TrackingEntity> ListarTrackingBySucursal(string TokenEjecutivo, int Periodo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@TokenEjecutivo",TokenEjecutivo),
                new Parametro("@Periodo", Periodo),
            };
            return DBHelper.InstanceReportes.ObtenerColeccion("negocios.SPReporte_TrackingAgenteSucursal", pram, ConstructorEntidad);
        }
        private static TrackingEntity ConstructorEntidad(DataRow row)
        {
            return new TrackingEntity
            {
                CodOficina = row["codOficina"] != DBNull.Value ? Convert.ToInt32(row["codOficina"]) : 0,
                Oficina = row["Oficina"] != DBNull.Value ? row["Oficina"].ToString() : string.Empty,
                EjecutivoCargo = row["EjecAsign_Cargo"] != DBNull.Value ? row["EjecAsign_Cargo"].ToString() : string.Empty,
                EjecAsign_Rut = row["EjecAsign_Rut"] != DBNull.Value ? Convert.ToInt32(row["EjecAsign_Rut"]) : 0,
                EjecutivoNombre = row["EjecAsign_Nombre"] != DBNull.Value ? row["EjecAsign_Nombre"].ToString() : string.Empty,
                SumaAsignados = row["ASignados"] != DBNull.Value ? Convert.ToInt32(row["ASignados"]) : 0,
                SumaGestionados = row["Gestionados"] != DBNull.Value ? Convert.ToInt32(row["Gestionados"]) : 0,
                SumaPorcentajeGestionado = row["GestionadosPorc"] != DBNull.Value ? Convert.ToSingle(row["GestionadosPorc"]) : 0,
                SumaContactados = row["Contactados"] != DBNull.Value ? Convert.ToInt32(row["Contactados"]) : 0,
                SumaPorcentajeContactados = row["ContactadosPorc"] != DBNull.Value ? Convert.ToInt32(row["ContactadosPorc"]) : 0,
                SumaPresentados = row["Presentados"] != DBNull.Value ? Convert.ToInt32(row["Presentados"]) : 0,
                SumaPorcentajePresentados = row["PresentadosPorc"] != DBNull.Value ? Convert.ToInt32(row["PresentadosPorc"]) : 0,
                SumaAprobados = row["Aprobados"] != DBNull.Value ? Convert.ToInt32(row["Aprobados"]) : 0,
                SumaPorcentajeAprobados = row["AprobadosPorc"] != DBNull.Value ? Convert.ToInt32(row["AprobadosPorc"]) : 0,
                SumaCursados = row["Cursados"] != DBNull.Value ? Convert.ToInt32(row["Cursados"]) : 0,
                SumaPorcentajeCursados = row["CursadosPorc"] != DBNull.Value ? Convert.ToInt32(row["CursadosPorc"]) : 0,
                MontoPromedio = row["MontoNetoProm"] != DBNull.Value ? Convert.ToInt32(row["MontoNetoProm"]) : 0,
                SumaInteresados = row["Interesados"] != DBNull.Value ? Convert.ToInt32(row["Interesados"]) : 0,
                SumaPorcentajeInteresados = row["InteresadosPorc"] != DBNull.Value ? Convert.ToSingle(row["InteresadosPorc"]) : 0,
            };
        }

        //tracking pergil zonal
        public static List<TrackingEntity> ListarTrackingBySucursalPerfZonal(int CodOficina, int Periodo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@CodOficina",CodOficina),
                new Parametro("@Periodo", Periodo),
            };
            return DBHelper.InstanceReportes.ObtenerColeccion("negocios.SPReporte_TrackingAgenteSucursal_PerfZonal", pram, EntidadPerfZonal);
        }
        private static TrackingEntity EntidadPerfZonal(DataRow row)
        {
            return new TrackingEntity
            {
                CodOficina = row["codOficina"] != DBNull.Value ? Convert.ToInt32(row["codOficina"]) : 0,
                Oficina = row["Oficina"] != DBNull.Value ? row["Oficina"].ToString() : string.Empty,
                EjecutivoCargo = row["EjecAsign_Cargo"] != DBNull.Value ? row["EjecAsign_Cargo"].ToString() : string.Empty,
                EjecAsign_Rut = row["EjecAsign_Rut"] != DBNull.Value ? Convert.ToInt32(row["EjecAsign_Rut"]) : 0,
                EjecutivoNombre = row["EjecAsign_Nombre"] != DBNull.Value ? row["EjecAsign_Nombre"].ToString() : string.Empty,
                SumaAsignados = row["ASignados"] != DBNull.Value ? Convert.ToInt32(row["ASignados"]) : 0,
                SumaGestionados = row["Gestionados"] != DBNull.Value ? Convert.ToInt32(row["Gestionados"]) : 0,
                SumaPorcentajeGestionado = row["GestionadosPorc"] != DBNull.Value ? Convert.ToSingle(row["GestionadosPorc"]) : 0,
                SumaContactados = row["Contactados"] != DBNull.Value ? Convert.ToInt32(row["Contactados"]) : 0,
                SumaPorcentajeContactados = row["ContactadosPorc"] != DBNull.Value ? Convert.ToInt32(row["ContactadosPorc"]) : 0,
                SumaPresentados = row["Presentados"] != DBNull.Value ? Convert.ToInt32(row["Presentados"]) : 0,
                SumaPorcentajePresentados = row["PresentadosPorc"] != DBNull.Value ? Convert.ToInt32(row["PresentadosPorc"]) : 0,
                SumaAprobados = row["Aprobados"] != DBNull.Value ? Convert.ToInt32(row["Aprobados"]) : 0,
                SumaPorcentajeAprobados = row["AprobadosPorc"] != DBNull.Value ? Convert.ToInt32(row["AprobadosPorc"]) : 0,
                SumaCursados = row["Cursados"] != DBNull.Value ? Convert.ToInt32(row["Cursados"]) : 0,
                SumaPorcentajeCursados = row["CursadosPorc"] != DBNull.Value ? Convert.ToInt32(row["CursadosPorc"]) : 0,
                MontoPromedio = row["MontoNetoProm"] != DBNull.Value ? Convert.ToInt32(row["MontoNetoProm"]) : 0,
                SumaInteresados = row["Interesados"] != DBNull.Value ? Convert.ToInt32(row["Interesados"]) : 0,
                SumaPorcentajeInteresados = row["InteresadosPorc"] != DBNull.Value ? Convert.ToSingle(row["InteresadosPorc"]) : 0,
            };
        }


        //fin perfil zonal




        public static List<TrackingEntity> ListarTrackingNormalizacionBySucursal(string TokenEjecutivo, int Periodo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@TokenEjecutivo",TokenEjecutivo),
                new Parametro("@Periodo", Periodo),
            };
            return DBHelper.InstanceReportes.ObtenerColeccion("negocios.SPReporte_TrackingNormalizacionAgenteSucursal", pram, ConstructorEntidadTrackingNormalizacion);
        }
        private static TrackingEntity ConstructorEntidadTrackingNormalizacion(DataRow row)
        {
            return new TrackingEntity
            {
                CodOficina = row["codOficina"] != DBNull.Value ? Convert.ToInt32(row["codOficina"]) : 0,
                Oficina = row["Oficina"] != DBNull.Value ? row["Oficina"].ToString() : string.Empty,
                EjecutivoCargo = row["EjecAsign_Cargo"] != DBNull.Value ? row["EjecAsign_Cargo"].ToString() : string.Empty,
                EjecAsign_Rut = row["EjecAsign_Rut"] != DBNull.Value ? Convert.ToInt32(row["EjecAsign_Rut"]) : 0,
                EjecutivoNombre = row["EjecAsign_Nombre"] != DBNull.Value ? row["EjecAsign_Nombre"].ToString() : string.Empty,
                SumaAsignados = row["ASignados"] != DBNull.Value ? Convert.ToInt32(row["ASignados"]) : 0,
                SumaGestionados = row["Gestionados"] != DBNull.Value ? Convert.ToInt32(row["Gestionados"]) : 0,
                SumaPorcentajeGestionado = row["GestionadosPorc"] != DBNull.Value ? Convert.ToSingle(row["GestionadosPorc"]) : 0,
                SumaContactados = row["Contactados"] != DBNull.Value ? Convert.ToInt32(row["Contactados"]) : 0,
                SumaPorcentajeContactados = row["ContactadosPorc"] != DBNull.Value ? Convert.ToInt32(row["ContactadosPorc"]) : 0,
                SumaPresentados = row["Presentados"] != DBNull.Value ? Convert.ToInt32(row["Presentados"]) : 0,
                SumaPorcentajePresentados = row["PresentadosPorc"] != DBNull.Value ? Convert.ToInt32(row["PresentadosPorc"]) : 0,
                SumaAprobados = row["Aprobados"] != DBNull.Value ? Convert.ToInt32(row["Aprobados"]) : 0,
                SumaPorcentajeAprobados = row["AprobadosPorc"] != DBNull.Value ? Convert.ToInt32(row["AprobadosPorc"]) : 0,
                SumaCursados = row["Cursados"] != DBNull.Value ? Convert.ToInt32(row["Cursados"]) : 0,
                SumaPorcentajeCursados = row["CursadosPorc"] != DBNull.Value ? Convert.ToInt32(row["CursadosPorc"]) : 0,
                MontoPromedio = row["MontoBrutoProm"] != DBNull.Value ? Convert.ToInt32(row["MontoBrutoProm"]) : 0,
                SumaInteresados = row["Interesados"] != DBNull.Value ? Convert.ToInt32(row["Interesados"]) : 0,
                SumaPorcentajeInteresados = row["InteresadosPorc"] != DBNull.Value ? Convert.ToSingle(row["InteresadosPorc"]) : 0,
            };
        }

        public static TrackingWidgetsSucursal ListTrackNormPerfZonal(int CodOficina, int Periodo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@CodOficina",CodOficina),
                new Parametro("@Periodo", Periodo),
            };
            return DBHelper.InstanceReportes.ObtenerEntidad("negocios.SPReporte_WidgetsSucursal_Normalizacion_PerfZonal", pram, EntNormPerfZonal);
        }
        private static TrackingWidgetsSucursal EntNormPerfZonal(DataRow row)
        {
            return new TrackingWidgetsSucursal
            {
                Periodo = row["Periodo"] != DBNull.Value ? Convert.ToInt32(row["Periodo"]) : 0,
                Actualizacion = row["Actualizacion"] != DBNull.Value ? row["Actualizacion"].ToString() : string.Empty,
                diaHabilActual = row["DiaHabil_Actual"] != DBNull.Value ? row["DiaHabil_Actual"].ToString() : string.Empty,
                CodOficina = row["codOficina"] != DBNull.Value ? Convert.ToInt32(row["codOficina"]) : 0,
                Oficina = row["Oficina"] != DBNull.Value ? row["Oficina"].ToString() : string.Empty,
                SumaAsignadosWid = row["SumaAsignados"] != DBNull.Value ? Convert.ToInt32(row["SumaAsignados"]) : 0,
                SumaGestionadosWid = row["SumaGestionados"] != DBNull.Value ? Convert.ToInt32(row["SumaGestionados"]) : 0,
                SumaPorcentajeGestionadoWid = row["SumaPorcentajeGestionados"] != DBNull.Value ? Convert.ToSingle(row["SumaPorcentajeGestionados"]) : 0,
                SumaContactadosWid = row["SumaContactados"] != DBNull.Value ? Convert.ToInt32(row["SumaContactados"]) : 0,
                SumaPorcentajeContactadosWid = row["SumaPorcentajeContactados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeContactados"]) : 0,
                SumaPresentadosWid = row["SumaPresentados"] != DBNull.Value ? Convert.ToInt32(row["SumaPresentados"]) : 0,
                SumaPorcentajePresentadosWid = row["SumaPorcentajePresentados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajePresentados"]) : 0,
                SumaAprobadosWid = row["SumaAprobados"] != DBNull.Value ? Convert.ToInt32(row["SumaAprobados"]) : 0,
                SumaPorcentajeAprobadosWid = row["SumaPorcentajeAprobados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeAprobados"]) : 0,
                SumaCursadosWid = row["SumaCursados"] != DBNull.Value ? Convert.ToInt32(row["SumaCursados"]) : 0,
                SumaPorcentajeCursadosWid = row["SumaPorcentajeCursados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeCursados"]) : 0,
                MontoBrutoSumWid = row["MontoBrutoSum"] != DBNull.Value ? Convert.ToInt32(row["MontoBrutoSum"]) : 0,
                MontoBrutoPromWid = row["MontoBrutoProm"] != DBNull.Value ? Convert.ToInt32(row["MontoBrutoProm"]) : 0,
                MontoNetoSumWid = row["MontoNetoSum"] != DBNull.Value ? Convert.ToInt32(row["MontoNetoSum"]) : 0,
                MontoNetoPromWid = row["MontoNetoProm"] != DBNull.Value ? Convert.ToInt32(row["MontoNetoProm"]) : 0,
                TotalECWid = row["TotalEc"] != DBNull.Value ? Convert.ToInt32(row["TotalEc"]) : 0,

            };
        }
        public static TrackingWidgetsSucursal ListarTotales(string TokenEjecutivo, int Periodo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@Periodo", Periodo),
                new Parametro("@TokenEjecutivo",TokenEjecutivo),
            };
            return DBHelper.InstanceReportes.ObtenerEntidad("negocios.SPReporte_WidgetsSucursal", pram, ConstructorTotal);
        }
        private static TrackingWidgetsSucursal ConstructorTotal(DataRow row)
        {
            return new TrackingWidgetsSucursal
            {
                Periodo = row["Periodo"] != DBNull.Value ? Convert.ToInt32(row["Periodo"]) : 0,
                Actualizacion = row["Actualizacion"] != DBNull.Value ? row["Actualizacion"].ToString() : string.Empty,
                diaHabilActual = row["DiaHabil_Actual"] != DBNull.Value ? row["DiaHabil_Actual"].ToString() : string.Empty,
                CodOficina = row["codOficina"] != DBNull.Value ? Convert.ToInt32(row["codOficina"]) : 0,
                Oficina = row["Oficina"] != DBNull.Value ? row["Oficina"].ToString() : string.Empty,
                SumaAsignadosWid = row["SumaAsignados"] != DBNull.Value ? Convert.ToInt32(row["SumaAsignados"]) : 0,
                SumaGestionadosWid = row["SumaGestionados"] != DBNull.Value ? Convert.ToInt32(row["SumaGestionados"]) : 0,
                SumaPorcentajeGestionadoWid = row["SumaPorcentajeGestionados"] != DBNull.Value ? Convert.ToSingle(row["SumaPorcentajeGestionados"]) : 0,
                SumaContactadosWid = row["SumaContactados"] != DBNull.Value ? Convert.ToInt32(row["SumaContactados"]) : 0,
                SumaPorcentajeContactadosWid = row["SumaPorcentajeContactados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeContactados"]) : 0,
                SumaPresentadosWid = row["SumaPresentados"] != DBNull.Value ? Convert.ToInt32(row["SumaPresentados"]) : 0,
                SumaPorcentajePresentadosWid = row["SumaPorcentajePresentados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajePresentados"]) : 0,
                SumaAprobadosWid = row["SumaAprobados"] != DBNull.Value ? Convert.ToInt32(row["SumaAprobados"]) : 0,
                SumaPorcentajeAprobadosWid = row["SumaPorcentajeAprobados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeAprobados"]) : 0,
                SumaCursadosWid = row["SumaCursados"] != DBNull.Value ? Convert.ToInt32(row["SumaCursados"]) : 0,
                SumaPorcentajeCursadosWid = row["SumaPorcentajeCursados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeCursados"]) : 0,
                MontoBrutoSumWid = row["MontoBrutoSum"] != DBNull.Value ? Convert.ToInt32(row["MontoBrutoSum"]) : 0,
                MontoBrutoPromWid = row["MontoBrutoProm"] != DBNull.Value ? Convert.ToInt32(row["MontoBrutoProm"]) : 0,
                MontoNetoSumWid = row["MontoNetoSum"] != DBNull.Value ? Convert.ToInt32(row["MontoNetoSum"]) : 0,
                MontoNetoPromWid = row["MontoNetoProm"] != DBNull.Value ? Convert.ToInt32(row["MontoNetoProm"]) : 0,
                TotalECWid = row["TotalEc"] != DBNull.Value ? Convert.ToInt32(row["TotalEc"]) : 0,

            };
        }
        //perfil zonal
        public static TrackingWidgetsSucursal ListarTotalesPerfZonal(int CodOficina, int Periodo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@CodOficina", CodOficina),
                new Parametro("@Periodo",Periodo),
            };
            return DBHelper.InstanceReportes.ObtenerEntidad("negocios.SPReporte_WidgetsSucursal_PerfZonal", pram, ConsTotalPerfZonal);
        }
        private static TrackingWidgetsSucursal ConsTotalPerfZonal(DataRow row)
        {
            return new TrackingWidgetsSucursal
            {
                Periodo = row["Periodo"] != DBNull.Value ? Convert.ToInt32(row["Periodo"]) : 0,
                Actualizacion = row["Actualizacion"] != DBNull.Value ? row["Actualizacion"].ToString() : string.Empty,
                diaHabilActual = row["DiaHabil_Actual"] != DBNull.Value ? row["DiaHabil_Actual"].ToString() : string.Empty,
                CodOficina = row["codOficina"] != DBNull.Value ? Convert.ToInt32(row["codOficina"]) : 0,
                Oficina = row["Oficina"] != DBNull.Value ? row["Oficina"].ToString() : string.Empty,
                SumaAsignadosWid = row["SumaAsignados"] != DBNull.Value ? Convert.ToInt32(row["SumaAsignados"]) : 0,
                SumaGestionadosWid = row["SumaGestionados"] != DBNull.Value ? Convert.ToInt32(row["SumaGestionados"]) : 0,
                SumaPorcentajeGestionadoWid = row["SumaPorcentajeGestionados"] != DBNull.Value ? Convert.ToSingle(row["SumaPorcentajeGestionados"]) : 0,
                SumaContactadosWid = row["SumaContactados"] != DBNull.Value ? Convert.ToInt32(row["SumaContactados"]) : 0,
                SumaPorcentajeContactadosWid = row["SumaPorcentajeContactados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeContactados"]) : 0,
                SumaPresentadosWid = row["SumaPresentados"] != DBNull.Value ? Convert.ToInt32(row["SumaPresentados"]) : 0,
                SumaPorcentajePresentadosWid = row["SumaPorcentajePresentados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajePresentados"]) : 0,
                SumaAprobadosWid = row["SumaAprobados"] != DBNull.Value ? Convert.ToInt32(row["SumaAprobados"]) : 0,
                SumaPorcentajeAprobadosWid = row["SumaPorcentajeAprobados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeAprobados"]) : 0,
                SumaCursadosWid = row["SumaCursados"] != DBNull.Value ? Convert.ToInt32(row["SumaCursados"]) : 0,
                SumaPorcentajeCursadosWid = row["SumaPorcentajeCursados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeCursados"]) : 0,
                MontoBrutoSumWid = row["MontoBrutoSum"] != DBNull.Value ? Convert.ToInt32(row["MontoBrutoSum"]) : 0,
                MontoBrutoPromWid = row["MontoBrutoProm"] != DBNull.Value ? Convert.ToInt32(row["MontoBrutoProm"]) : 0,
                MontoNetoSumWid = row["MontoNetoSum"] != DBNull.Value ? Convert.ToInt32(row["MontoNetoSum"]) : 0,
                MontoNetoPromWid = row["MontoNetoProm"] != DBNull.Value ? Convert.ToInt32(row["MontoNetoProm"]) : 0,
                TotalECWid = row["TotalEc"] != DBNull.Value ? Convert.ToInt32(row["TotalEc"]) : 0,
                SumaInteresadosWid = row["Interesados"] != DBNull.Value ? Convert.ToInt32(row["Interesados"]) : 0,
                SumaPorcentajeInteresadosWid = row["SumaPorcentajeInteresados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeInteresados"]) : 0,

            };
        }


        // perfil zonal



        public static TrackingWidgetsPais ListarTotalesPais(int Periodo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@Periodo", Periodo)
            };
            return DBHelper.InstanceReportes.ObtenerEntidad("negocios.SPReporte_WidgetsPais", pram, ConstructorTotalPais);
        }
        private static TrackingWidgetsPais ConstructorTotalPais(DataRow row)
        {
            return new TrackingWidgetsPais
            {
                Pais = row["Pais"] != DBNull.Value ? row["Pais"].ToString() : string.Empty,
                Periodo = row["Periodo"] != DBNull.Value ? Convert.ToInt32(row["Periodo"]) : 0,
                FechaActualizacion = row["Actualizacion"] != DBNull.Value ? row["Actualizacion"].ToString() : string.Empty,
                DiaHabil = row["DiaHabil_Actual"] != DBNull.Value ? row["DiaHabil_Actual"].ToString() : string.Empty,
                SumAsignado = row["SumaAsignados"] != DBNull.Value ? Convert.ToInt32(row["SumaAsignados"]) : 0,
                SumGestionado = row["SumaGestionados"] != DBNull.Value ? Convert.ToInt32(row["SumaGestionados"]) : 0,
                PorcentajeGestionado = row["SumaPorcentajeGestionados"] != DBNull.Value ? Convert.ToSingle(row["SumaPorcentajeGestionados"]) : 0,
                SumContactado = row["SumaContactados"] != DBNull.Value ? Convert.ToInt32(row["SumaContactados"]) : 0,
                PorcentajeContactado = row["SumaPorcentajeContactados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeContactados"]) : 0,
                SumPresentado = row["SumaPresentados"] != DBNull.Value ? Convert.ToInt32(row["SumaPresentados"]) : 0,
                PorcentajePresentado = row["SumaPorcentajePresentados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajePresentados"]) : 0,
                SumAprobado = row["SumaAprobados"] != DBNull.Value ? Convert.ToInt32(row["SumaAprobados"]) : 0,
                PorcentajeAprobado = row["SumaPorcentajeAprobados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeAprobados"]) : 0,
                SumCursado = row["SumaCursados"] != DBNull.Value ? Convert.ToInt32(row["SumaCursados"]) : 0,
                PorcentajeCursado = row["SumaPorcentajeCursados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeCursados"]) : 0,
                SumBruto = row["MontoBrutoSum"] != DBNull.Value ? Convert.ToInt64(row["MontoBrutoSum"]) : 0,
                PromBruto = row["MontoBrutoProm"] != DBNull.Value ? Convert.ToInt64(row["MontoBrutoProm"]) : 0,
                SumNeto = row["MontoNetoSum"] != DBNull.Value ? Convert.ToInt64(row["MontoNetoSum"]) : 0,
                PromNeto = row["MontoNetoProm"] != DBNull.Value ? Convert.ToInt64(row["MontoNetoProm"]) : 0,
                TotalEC = row["SumTotalEc"] != DBNull.Value ? Convert.ToInt64(row["SumTotalEc"]) : 0,
                SumInteresado = row["InteresadosSum"] != DBNull.Value ? Convert.ToInt32(row["InteresadosSum"]) : 0,
                SumRechazado = row["RechazadosSum"] != DBNull.Value ? Convert.ToInt32(row["RechazadosSum"]) : 0,
                PorcentajeInteresado = row["SumaPorcentajeInteresados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeInteresados"]) : 0,

            };
        }
        //total pais normalizacion
        public static TrackingWidgetsPaisNormalizacion ListarTotalesPaisNormalizacion(int Periodo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@Periodo", Periodo)
            };
            return DBHelper.InstanceReportes.ObtenerEntidad("negocios.SPReporte_WidgetsPaisNormalizacion", pram, ConstructorTotalPaisNormalizacion);
        }
        private static TrackingWidgetsPaisNormalizacion ConstructorTotalPaisNormalizacion(DataRow row)
        {
            return new TrackingWidgetsPaisNormalizacion
            {
                Pais = row["Pais"] != DBNull.Value ? row["Pais"].ToString() : string.Empty,
                Periodo = row["Periodo"] != DBNull.Value ? Convert.ToInt32(row["Periodo"]) : 0,
                FechaActualizacion = row["Actualizacion"] != DBNull.Value ? row["Actualizacion"].ToString() : string.Empty,
                DiaHabil = row["DiaHabil_Actual"] != DBNull.Value ? row["DiaHabil_Actual"].ToString() : string.Empty,
                SumAsignado = row["SumaAsignados"] != DBNull.Value ? Convert.ToInt32(row["SumaAsignados"]) : 0,
                SumGestionado = row["SumaGestionados"] != DBNull.Value ? Convert.ToInt32(row["SumaGestionados"]) : 0,
                PorcentajeGestionado = row["SumaPorcentajeGestionados"] != DBNull.Value ? Convert.ToSingle(row["SumaPorcentajeGestionados"]) : 0,
                SumContactado = row["SumaContactados"] != DBNull.Value ? Convert.ToInt32(row["SumaContactados"]) : 0,
                PorcentajeContactado = row["SumaPorcentajeContactados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeContactados"]) : 0,
                SumPresentado = row["SumaPresentados"] != DBNull.Value ? Convert.ToInt32(row["SumaPresentados"]) : 0,
                PorcentajePresentado = row["SumaPorcentajePresentados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajePresentados"]) : 0,
                SumAprobado = row["SumaAprobados"] != DBNull.Value ? Convert.ToInt32(row["SumaAprobados"]) : 0,
                PorcentajeAprobado = row["SumaPorcentajeAprobados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeAprobados"]) : 0,
                SumCursado = row["SumaCursados"] != DBNull.Value ? Convert.ToInt32(row["SumaCursados"]) : 0,
                PorcentajeCursado = row["SumaPorcentajeCursados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeCursados"]) : 0,
                SumBruto = row["MontoBrutoSum"] != DBNull.Value ? Convert.ToInt64(row["MontoBrutoSum"]) : 0,
                PromBruto = row["MontoBrutoProm"] != DBNull.Value ? Convert.ToInt64(row["MontoBrutoProm"]) : 0,
                SumNeto = row["MontoNetoSum"] != DBNull.Value ? Convert.ToInt64(row["MontoNetoSum"]) : 0,
                PromNeto = row["MontoNetoProm"] != DBNull.Value ? Convert.ToInt64(row["MontoNetoProm"]) : 0,
                TotalEC = row["SumTotalEc"] != DBNull.Value ? Convert.ToInt64(row["SumTotalEc"]) : 0,
                SumInteresado = row["InteresadosSum"] != DBNull.Value ? Convert.ToInt32(row["InteresadosSum"]) : 0,
                //   SumRechazado = row["RechazadosSum"] != DBNull.Value ? Convert.ToInt32(row["RechazadosSum"]) : 0,
                PorcentajeInteresado = row["SumaPorcentajeInteresados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeInteresados"]) : 0,

            };
        }
        //end normalizacion
        public static List<TrackingWidgetsZonal> ListarTotalesZonal(int Periodo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@Periodo", Periodo)
            };
            return DBHelper.InstanceReportes.ObtenerColeccion("negocios.SPReporte_WidgetsZonal", pram, ConstructorTotalZonal);
        }
        private static TrackingWidgetsZonal ConstructorTotalZonal(DataRow row)
        {
            return new TrackingWidgetsZonal
            {
                Zona = row["Zona"] != DBNull.Value ? row["Zona"].ToString() : string.Empty,
                CodZona = row["CodZona"] != DBNull.Value ? Convert.ToInt32(row["CodZona"]) : 0,
                Periodo = row["Periodo"] != DBNull.Value ? Convert.ToInt32(row["Periodo"]) : 0,
                FechaActualizacion = row["Actualizacion"] != DBNull.Value ? row["Actualizacion"].ToString() : string.Empty,
                DiaHabil = row["DiaHabil_Actual"] != DBNull.Value ? row["DiaHabil_Actual"].ToString() : string.Empty,
                SumAsignado = row["SumaAsignados"] != DBNull.Value ? Convert.ToInt32(row["SumaAsignados"]) : 0,
                SumGestionado = row["SumaGestionados"] != DBNull.Value ? Convert.ToInt32(row["SumaGestionados"]) : 0,
                PorcentajeGestionado = row["SumaPorcentajeGestionados"] != DBNull.Value ? Convert.ToSingle(row["SumaPorcentajeGestionados"]) : 0,
                SumContactado = row["SumaContactados"] != DBNull.Value ? Convert.ToInt32(row["SumaContactados"]) : 0,
                PorcentajeContactado = row["SumaPorcentajeContactados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeContactados"]) : 0,
                SumPresentado = row["SumaPresentados"] != DBNull.Value ? Convert.ToInt32(row["SumaPresentados"]) : 0,
                PorcentajePresentado = row["SumaPorcentajePresentados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajePresentados"]) : 0,
                SumAprobado = row["SumaAprobados"] != DBNull.Value ? Convert.ToInt32(row["SumaAprobados"]) : 0,
                PorcentajeAprobado = row["SumaPorcentajeAprobados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeAprobados"]) : 0,
                SumCursado = row["SumaCursados"] != DBNull.Value ? Convert.ToInt32(row["SumaCursados"]) : 0,
                PorcentajeCursado = row["SumaPorcentajeCursados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeCursados"]) : 0,
                SumBruto = row["MontoBrutoSum"] != DBNull.Value ? Convert.ToInt64(row["MontoBrutoSum"]) : 0,
                PromBruto = row["MontoBrutoProm"] != DBNull.Value ? Convert.ToInt64(row["MontoBrutoProm"]) : 0,
                SumNeto = row["MontoNetoSum"] != DBNull.Value ? Convert.ToInt64(row["MontoNetoSum"]) : 0,
                PromNeto = row["MontoNetoProm"] != DBNull.Value ? Convert.ToInt64(row["MontoNetoProm"]) : 0,
                TotalEC = row["SumTotalEc"] != DBNull.Value ? Convert.ToInt64(row["SumTotalEc"]) : 0,
                SumInteresado = row["InteresadosSum"] != DBNull.Value ? Convert.ToInt32(row["InteresadosSum"]) : 0,
                SumRechazado = row["RechazadosSum"] != DBNull.Value ? Convert.ToInt32(row["RechazadosSum"]) : 0,
                PorcentajeInteresado = row["SumaPorcentajeInteresados"] != DBNull.Value ? Convert.ToSingle(row["SumaPorcentajeInteresados"]) : 0,

            };
        }
        //normalizacion
        public static List<TrackingWidgetsZonalNormalizacion> ListarTotalesZonalNormalizaicon(int Periodo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@Periodo", Periodo)
            };
            return DBHelper.InstanceReportes.ObtenerColeccion("negocios.SPReporte_WidgetsZonalNormalizacion", pram, ConstructorTotalZonalNormalizacion);
        }
        private static TrackingWidgetsZonalNormalizacion ConstructorTotalZonalNormalizacion(DataRow row)
        {
            return new TrackingWidgetsZonalNormalizacion
            {
                Zona = row["Zona"] != DBNull.Value ? row["Zona"].ToString() : string.Empty,
                CodZona = row["CodZona"] != DBNull.Value ? Convert.ToInt32(row["CodZona"]) : 0,
                Periodo = row["Periodo"] != DBNull.Value ? Convert.ToInt32(row["Periodo"]) : 0,
                FechaActualizacion = row["Actualizacion"] != DBNull.Value ? row["Actualizacion"].ToString() : string.Empty,
                DiaHabil = row["DiaHabil_Actual"] != DBNull.Value ? row["DiaHabil_Actual"].ToString() : string.Empty,
                SumAsignado = row["SumaAsignados"] != DBNull.Value ? Convert.ToInt32(row["SumaAsignados"]) : 0,
                SumGestionado = row["SumaGestionados"] != DBNull.Value ? Convert.ToInt32(row["SumaGestionados"]) : 0,
                PorcentajeGestionado = row["SumaPorcentajeGestionados"] != DBNull.Value ? Convert.ToSingle(row["SumaPorcentajeGestionados"]) : 0,
                SumContactado = row["SumaContactados"] != DBNull.Value ? Convert.ToInt32(row["SumaContactados"]) : 0,
                PorcentajeContactado = row["SumaPorcentajeContactados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeContactados"]) : 0,
                SumPresentado = row["SumaPresentados"] != DBNull.Value ? Convert.ToInt32(row["SumaPresentados"]) : 0,
                PorcentajePresentado = row["SumaPorcentajePresentados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajePresentados"]) : 0,
                SumAprobado = row["SumaAprobados"] != DBNull.Value ? Convert.ToInt32(row["SumaAprobados"]) : 0,
                PorcentajeAprobado = row["SumaPorcentajeAprobados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeAprobados"]) : 0,
                SumCursado = row["SumaCursados"] != DBNull.Value ? Convert.ToInt32(row["SumaCursados"]) : 0,
                PorcentajeCursado = row["SumaPorcentajeCursados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeCursados"]) : 0,
                SumBruto = row["MontoBrutoSum"] != DBNull.Value ? Convert.ToInt64(row["MontoBrutoSum"]) : 0,
                PromBruto = row["MontoBrutoProm"] != DBNull.Value ? Convert.ToInt64(row["MontoBrutoProm"]) : 0,
                SumNeto = row["MontoNetoSum"] != DBNull.Value ? Convert.ToInt64(row["MontoNetoSum"]) : 0,
                PromNeto = row["MontoNetoProm"] != DBNull.Value ? Convert.ToInt64(row["MontoNetoProm"]) : 0,
                TotalEC = row["SumTotalEc"] != DBNull.Value ? Convert.ToInt64(row["SumTotalEc"]) : 0,
                SumInteresado = row["InteresadosSum"] != DBNull.Value ? Convert.ToInt32(row["InteresadosSum"]) : 0,
                // SumRechazado = row["RechazadosSum"] != DBNull.Value ? Convert.ToInt32(row["RechazadosSum"]) : 0,
                PorcentajeInteresado = row["SumaPorcentajeInteresados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeInteresados"]) : 0,

            };
        }
        //end normalizacion
        public static TrackingSucursalZonal ListarTotalesZona(int Periodo, int zona)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@Periodo", Periodo),
                new Parametro("@CodZona",zona)
            };
            return DBHelper.InstanceReportes.ObtenerEntidad("negocios.SPReporte_WidgetsSucursalZonal", pram, ConstructorTotalZona);
        }
        private static TrackingSucursalZonal ConstructorTotalZona(DataRow row)
        {
            return new TrackingSucursalZonal
            {
                //Pais = row["Pais"] != DBNull.Value ? row["Pais"].ToString() : string.Empty,
                Periodo = row["Periodo"] != DBNull.Value ? Convert.ToInt32(row["Periodo"]) : 0,
                FechaActualizacion = row["Actualizacion"] != DBNull.Value ? row["Actualizacion"].ToString() : string.Empty,
                DiaHabil = row["DiaHabil_Actual"] != DBNull.Value ? row["DiaHabil_Actual"].ToString() : string.Empty,
                Zona = row["Zona"] != DBNull.Value ? row["Zona"].ToString() : string.Empty,
                SumAsignado = row["SumaAsignados"] != DBNull.Value ? Convert.ToInt64(row["SumaAsignados"]) : 0,
                SumGestionado = row["SumaGestionados"] != DBNull.Value ? Convert.ToInt64(row["SumaGestionados"]) : 0,
                PorcentajeGestionado = row["SumaPorcentajeGestionados"] != DBNull.Value ? Convert.ToSingle(row["SumaPorcentajeGestionados"]) : 0,
                SumContactado = row["SumaContactados"] != DBNull.Value ? Convert.ToInt64(row["SumaContactados"]) : 0,
                PorcentajeContactado = row["SumaPorcentajeContactados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeContactados"]) : 0,
                SumPresentado = row["SumaPresentados"] != DBNull.Value ? Convert.ToInt64(row["SumaPresentados"]) : 0,
                PorcentajePresentado = row["SumaPorcentajePresentados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajePresentados"]) : 0,
                SumAprobado = row["SumaAprobados"] != DBNull.Value ? Convert.ToInt64(row["SumaAprobados"]) : 0,
                PorcentajeAprobado = row["SumaPorcentajeAprobados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeAprobados"]) : 0,
                SumCursado = row["SumaCursados"] != DBNull.Value ? Convert.ToInt64(row["SumaCursados"]) : 0,
                PorcentajeCursado = row["SumaPorcentajeCursados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeCursados"]) : 0,
                SumBruto = row["MontoBrutoSum"] != DBNull.Value ? Convert.ToInt64(row["MontoBrutoSum"]) : 0,
                PromBruto = row["MontoBrutoProm"] != DBNull.Value ? Convert.ToInt64(row["MontoBrutoProm"]) : 0,
                SumNeto = row["MontoNetoSum"] != DBNull.Value ? Convert.ToInt64(row["MontoNetoSum"]) : 0,
                PromNeto = row["MontoNetoProm"] != DBNull.Value ? Convert.ToInt64(row["MontoNetoProm"]) : 0,
                TotalEC = row["SumTotalEc"] != DBNull.Value ? Convert.ToInt64(row["SumTotalEc"]) : 0,
                SumInteresado = row["InteresadosSum"] != DBNull.Value ? Convert.ToInt64(row["InteresadosSum"]) : 0,
                SumRechazado = row["RechazadosSum"] != DBNull.Value ? Convert.ToInt64(row["RechazadosSum"]) : 0,
                PorcentajeInteresado = row["SumaPorcentajeInteresados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeInteresados"]) : 0,

            };
        }
        //normalizacion
        public static TrackingSucursalZonalNormalizacion ListarTotalesZonaNormalizaicon(int Periodo, int zona)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@Periodo", Periodo),
                new Parametro("@CodZona",zona)
            };
            return DBHelper.InstanceReportes.ObtenerEntidad("negocios.SPReporte_WidgetsSucursalZonalNormalizacion", pram, ConstructorTotalZonaNormalizacion);
        }
        private static TrackingSucursalZonalNormalizacion ConstructorTotalZonaNormalizacion(DataRow row)
        {
            return new TrackingSucursalZonalNormalizacion
            {
                //Pais = row["Pais"] != DBNull.Value ? row["Pais"].ToString() : string.Empty,
                Periodo = row["Periodo"] != DBNull.Value ? Convert.ToInt32(row["Periodo"]) : 0,
                FechaActualizacion = row["Actualizacion"] != DBNull.Value ? row["Actualizacion"].ToString() : string.Empty,
                DiaHabil = row["DiaHabil_Actual"] != DBNull.Value ? row["DiaHabil_Actual"].ToString() : string.Empty,
                Zona = row["Zona"] != DBNull.Value ? row["Zona"].ToString() : string.Empty,
                SumAsignado = row["SumaAsignados"] != DBNull.Value ? Convert.ToInt32(row["SumaAsignados"]) : 0,
                SumGestionado = row["SumaGestionados"] != DBNull.Value ? Convert.ToInt32(row["SumaGestionados"]) : 0,
                PorcentajeGestionado = row["SumaPorcentajeGestionados"] != DBNull.Value ? Convert.ToSingle(row["SumaPorcentajeGestionados"]) : 0,
                SumContactado = row["SumaContactados"] != DBNull.Value ? Convert.ToInt32(row["SumaContactados"]) : 0,
                PorcentajeContactado = row["SumaPorcentajeContactados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeContactados"]) : 0,
                SumPresentado = row["SumaPresentados"] != DBNull.Value ? Convert.ToInt32(row["SumaPresentados"]) : 0,
                PorcentajePresentado = row["SumaPorcentajePresentados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajePresentados"]) : 0,
                SumAprobado = row["SumaAprobados"] != DBNull.Value ? Convert.ToInt32(row["SumaAprobados"]) : 0,
                PorcentajeAprobado = row["SumaPorcentajeAprobados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeAprobados"]) : 0,
                SumCursado = row["SumaCursados"] != DBNull.Value ? Convert.ToInt32(row["SumaCursados"]) : 0,
                PorcentajeCursado = row["SumaPorcentajeCursados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeCursados"]) : 0,
                SumBruto = row["MontoBrutoSum"] != DBNull.Value ? Convert.ToInt32(row["MontoBrutoSum"]) : 0,
                PromBruto = row["MontoBrutoProm"] != DBNull.Value ? Convert.ToInt32(row["MontoBrutoProm"]) : 0,
                SumNeto = row["MontoNetoSum"] != DBNull.Value ? Convert.ToInt32(row["MontoNetoSum"]) : 0,
                PromNeto = row["MontoNetoProm"] != DBNull.Value ? Convert.ToInt32(row["MontoNetoProm"]) : 0,
                TotalEC = row["SumTotalEc"] != DBNull.Value ? Convert.ToInt32(row["SumTotalEc"]) : 0,
                SumInteresado = row["InteresadosSum"] != DBNull.Value ? Convert.ToInt32(row["InteresadosSum"]) : 0,
                // SumRechazado = row["RechazadosSum"] != DBNull.Value ? Convert.ToInt32(row["RechazadosSum"]) : 0,
                PorcentajeInteresado = row["SumaPorcentajeInteresados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeInteresados"]) : 0,

            };
        }
        //end normalizacion
        public static TrackingWidgetsSucursal ListarTotalesNormalizacion(string TokenEjecutivo, int Periodo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@Periodo", Periodo),
                new Parametro("@TokenEjecutivo",TokenEjecutivo),
            };
            return DBHelper.InstanceReportes.ObtenerEntidad("negocios.SPReporte_WidgetsSucursal_Normalizacion", pram, ConstructorTotalNormalizacion);
        }
        private static TrackingWidgetsSucursal ConstructorTotalNormalizacion(DataRow row)
        {
            return new TrackingWidgetsSucursal
            {
                Periodo = row["Periodo"] != DBNull.Value ? Convert.ToInt32(row["Periodo"]) : 0,
                Actualizacion = row["Actualizacion"] != DBNull.Value ? row["Actualizacion"].ToString() : string.Empty,
                diaHabilActual = row["DiaHabil_Actual"] != DBNull.Value ? row["DiaHabil_Actual"].ToString() : string.Empty,
                CodOficina = row["codOficina"] != DBNull.Value ? Convert.ToInt32(row["codOficina"]) : 0,
                Oficina = row["Oficina"] != DBNull.Value ? row["Oficina"].ToString() : string.Empty,
                SumaAsignadosWid = row["SumaAsignados"] != DBNull.Value ? Convert.ToInt32(row["SumaAsignados"]) : 0,
                SumaGestionadosWid = row["SumaGestionados"] != DBNull.Value ? Convert.ToInt32(row["SumaGestionados"]) : 0,
                SumaPorcentajeGestionadoWid = row["SumaPorcentajeGestionados"] != DBNull.Value ? Convert.ToSingle(row["SumaPorcentajeGestionados"]) : 0,
                SumaContactadosWid = row["SumaContactados"] != DBNull.Value ? Convert.ToInt32(row["SumaContactados"]) : 0,
                SumaPorcentajeContactadosWid = row["SumaPorcentajeContactados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeContactados"]) : 0,
                SumaPresentadosWid = row["SumaPresentados"] != DBNull.Value ? Convert.ToInt32(row["SumaPresentados"]) : 0,
                SumaPorcentajePresentadosWid = row["SumaPorcentajePresentados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajePresentados"]) : 0,
                SumaAprobadosWid = row["SumaAprobados"] != DBNull.Value ? Convert.ToInt32(row["SumaAprobados"]) : 0,
                SumaPorcentajeAprobadosWid = row["SumaPorcentajeAprobados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeAprobados"]) : 0,
                SumaCursadosWid = row["SumaCursados"] != DBNull.Value ? Convert.ToInt32(row["SumaCursados"]) : 0,
                SumaPorcentajeCursadosWid = row["SumaPorcentajeCursados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeCursados"]) : 0,
                MontoBrutoSumWid = row["MontoBrutoSum"] != DBNull.Value ? Convert.ToInt32(row["MontoBrutoSum"]) : 0,
                MontoBrutoPromWid = row["MontoBrutoProm"] != DBNull.Value ? Convert.ToInt32(row["MontoBrutoProm"]) : 0,
                MontoNetoSumWid = row["MontoNetoSum"] != DBNull.Value ? Convert.ToInt32(row["MontoNetoSum"]) : 0,
                MontoNetoPromWid = row["MontoNetoProm"] != DBNull.Value ? Convert.ToInt32(row["MontoNetoProm"]) : 0,
                TotalECWid = row["TotalEc"] != DBNull.Value ? Convert.ToInt32(row["TotalEc"]) : 0,

            };
        }





        public static TrackingWidgetsEjecutivo ListarTotalesEjecutivoWid(int RutEjecutivo, int Periodo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@RutEjecutivo", RutEjecutivo),
                new Parametro("@Periodo",Periodo),
            };
            return DBHelper.InstanceReportes.ObtenerEntidad("negocios.SPReporte_WidgetsEjecutivo", pram, ConstructorTotalEjecutivo);
        }



        public static TrackingWidgetsEjecutivo ListarTotalesEjecutivoWid(string Token, int Periodo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@Token", Token),
                new Parametro("@Periodo",Periodo),
            };
            return DBHelper.InstanceReportes.ObtenerEntidad("negocios.SPReporte_EquacionEjecutivo", pram, ConstructorTotalEjecutivo);
        }



        public static TrackingWidgetsEjecutivoNormalizacion ListarTotalesEjecutivoWidNormalizacion(int RutEjecutivo, int Periodo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@RutEjecutivo", RutEjecutivo),
                new Parametro("@Periodo",Periodo),
            };
            return DBHelper.InstanceReportes.ObtenerEntidad("negocios.SPReporte_WidgetsEjecutivo_Normalizacion", pram, ConstructorTotalEjecutivoNormalizacion);
        }
        private static TrackingWidgetsEjecutivo ConstructorTotalEjecutivo(DataRow row)
        {
            return new TrackingWidgetsEjecutivo
            {
                Periodo = row["Periodo"] != DBNull.Value ? Convert.ToInt32(row["Periodo"]) : 0,
                Actualizacion = row["Actualizacion"] != DBNull.Value ? row["Actualizacion"].ToString() : string.Empty,
                nombreEjecutivo = row["EjecAsign_Nombre"] != DBNull.Value ? row["EjecAsign_Nombre"].ToString() : string.Empty,
                CodOficina = row["codOficina"] != DBNull.Value ? Convert.ToInt32(row["codOficina"]) : 0,
                Oficina = row["Oficina"] != DBNull.Value ? row["Oficina"].ToString() : string.Empty,
                SumaAsignadosWidEjec = row["ASignados"] != DBNull.Value ? Convert.ToInt32(row["ASignados"]) : 0,
                SumaGestionadosWidEjec = row["Gestionados"] != DBNull.Value ? Convert.ToInt32(row["Gestionados"]) : 0,
                SumaPorcentajeGestionadoWidEjec = row["GestionadosPorc"] != DBNull.Value ? Convert.ToSingle(row["GestionadosPorc"]) : 0,
                SumaContactadosWidEjec = row["Contactados"] != DBNull.Value ? Convert.ToInt32(row["Contactados"]) : 0,
                SumaPorcentajeContactadosWidEjec = row["ContactadosPorc"] != DBNull.Value ? Convert.ToInt32(row["ContactadosPorc"]) : 0,
                SumaPresentadosWidEjec = row["Presentados"] != DBNull.Value ? Convert.ToInt32(row["Presentados"]) : 0,
                SumaPorcentajePresentadosWidEjec = row["PresentadosPorc"] != DBNull.Value ? Convert.ToInt32(row["PresentadosPorc"]) : 0,
                SumaAprobadosWidEjec = row["Aprobados"] != DBNull.Value ? Convert.ToInt32(row["Aprobados"]) : 0,
                SumaPorcentajeAprobadosWidEjec = row["AprobadosPorc"] != DBNull.Value ? Convert.ToInt32(row["AprobadosPorc"]) : 0,
                SumaCursadosWidEjec = row["Cursados"] != DBNull.Value ? Convert.ToInt32(row["Cursados"]) : 0,
                SumaPorcentajeCursadosWidEjec = row["CursadosPorc"] != DBNull.Value ? Convert.ToInt32(row["CursadosPorc"]) : 0,
                MontoBrutoSumWidEjec = row["MontoBrutoSum"] != DBNull.Value ? Convert.ToInt32(row["MontoBrutoSum"]) : 0,
                MontoBrutoPromWidEjec = row["MontoBrutoProm"] != DBNull.Value ? Convert.ToInt32(row["MontoBrutoProm"]) : 0,
                MontoNetoSumWidEjec = row["MontoNetoSum"] != DBNull.Value ? Convert.ToInt32(row["MontoNetoSum"]) : 0,
                MontoNetoPromWidEjec = row["MontoNetoProm"] != DBNull.Value ? Convert.ToInt32(row["MontoNetoProm"]) : 0,
                TotalECWidEjec = row["TotalEc"] != DBNull.Value ? Convert.ToInt32(row["TotalEc"]) : 0,

            };
        }
        private static TrackingWidgetsEjecutivoNormalizacion ConstructorTotalEjecutivoNormalizacion(DataRow row)
        {
            return new TrackingWidgetsEjecutivoNormalizacion
            {
                Periodo = row["Periodo"] != DBNull.Value ? Convert.ToInt32(row["Periodo"]) : 0,
                Actualizacion = row["Actualizacion"] != DBNull.Value ? row["Actualizacion"].ToString() : string.Empty,
                nombreEjecutivo = row["EjecAsign_Nombre"] != DBNull.Value ? row["EjecAsign_Nombre"].ToString() : string.Empty,
                CodOficina = row["codOficina"] != DBNull.Value ? Convert.ToInt32(row["codOficina"]) : 0,
                Oficina = row["Oficina"] != DBNull.Value ? row["Oficina"].ToString() : string.Empty,
                SumaAsignadosWidEjec = row["ASignados"] != DBNull.Value ? Convert.ToInt32(row["ASignados"]) : 0,
                SumaGestionadosWidEjec = row["Gestionados"] != DBNull.Value ? Convert.ToInt32(row["Gestionados"]) : 0,
                SumaPorcentajeGestionadoWidEjec = row["GestionadosPorc"] != DBNull.Value ? Convert.ToSingle(row["GestionadosPorc"]) : 0,
                SumaContactadosWidEjec = row["Contactados"] != DBNull.Value ? Convert.ToInt32(row["Contactados"]) : 0,
                SumaPorcentajeContactadosWidEjec = row["ContactadosPorc"] != DBNull.Value ? Convert.ToInt32(row["ContactadosPorc"]) : 0,
                SumaPresentadosWidEjec = row["Presentados"] != DBNull.Value ? Convert.ToInt32(row["Presentados"]) : 0,
                SumaPorcentajePresentadosWidEjec = row["PresentadosPorc"] != DBNull.Value ? Convert.ToInt32(row["PresentadosPorc"]) : 0,
                SumaAprobadosWidEjec = row["Aprobados"] != DBNull.Value ? Convert.ToInt32(row["Aprobados"]) : 0,
                SumaPorcentajeAprobadosWidEjec = row["AprobadosPorc"] != DBNull.Value ? Convert.ToInt32(row["AprobadosPorc"]) : 0,
                SumaCursadosWidEjec = row["Cursados"] != DBNull.Value ? Convert.ToInt32(row["Cursados"]) : 0,
                SumaPorcentajeCursadosWidEjec = row["CursadosPorc"] != DBNull.Value ? Convert.ToInt32(row["CursadosPorc"]) : 0,
                MontoBrutoSumWidEjec = row["MontoBrutoSum"] != DBNull.Value ? Convert.ToInt32(row["MontoBrutoSum"]) : 0,
                MontoBrutoPromWidEjec = row["MontoBrutoProm"] != DBNull.Value ? Convert.ToInt32(row["MontoBrutoProm"]) : 0,
                MontoNetoSumWidEjec = row["MontoNetoSum"] != DBNull.Value ? Convert.ToInt32(row["MontoNetoSum"]) : 0,
                MontoNetoPromWidEjec = row["MontoNetoProm"] != DBNull.Value ? Convert.ToInt32(row["MontoNetoProm"]) : 0,
                TotalECWidEjec = row["TotalEc"] != DBNull.Value ? Convert.ToInt32(row["TotalEc"]) : 0,

            };
        }
        public static List<TrackingDetalleEjecutivo> Obtener(int RutEjecutivo, int Periodo)
        {
            //Parametro p = new Parametro("@EjecutivoRut", RutEjecutivo);
            Parametros pram = new Parametros
            {
                new Parametro("@Periodo", Periodo),
                new Parametro("@EjecutivoRut", RutEjecutivo)
            };
            return DBHelper.InstanceReportes.ObtenerColeccion("negocios.SPReporte_ObtenerTrackingDetalleEjecutivo", pram, ConstructorEntidadDetalleEjecutivo);
        }
        public static List<TrackingDetalleEjecutivoNormalizacion> ObtenerEjecutivoNormalizacion(int RutEjecutivo, int Periodo)
        {
            //Parametro p = new Parametro("@EjecutivoRut", RutEjecutivo);
            Parametros pram = new Parametros
            {
                new Parametro("@Periodo", Periodo),
                new Parametro("@EjecutivoRut", RutEjecutivo)
            };
            return DBHelper.InstanceReportes.ObtenerColeccion("negocios.SPReporte_ObtenerTrackingDetalleEjecutivoNormalizacion", pram, ConstructorEntidadDetalleEjecutivoNormalizacion);
        }
        private static TrackingDetalleEjecutivoNormalizacion ConstructorEntidadDetalleEjecutivoNormalizacion(DataRow row)
        {
            return new TrackingDetalleEjecutivoNormalizacion
            {

                AfiliadoRut = row["AfiliadoRut"] != DBNull.Value ? Convert.ToInt32(row["AfiliadoRut"]) : 0,
                AfiliadoDv = row["AfiliadoDv"] != DBNull.Value ? row["AfiliadoDv"].ToString() : string.Empty,
                AfiliadoNombre = row["AfiliadoNombre"] != DBNull.Value ? row["AfiliadoNombre"].ToString() : string.Empty,
                AfiliadoApellido = row["AfiliadoApellido"] != DBNull.Value ? row["AfiliadoApellido"].ToString() : string.Empty,
                AfiliadoSegmento = row["AfiliadoSegmento"] != DBNull.Value ? row["AfiliadoSegmento"].ToString() : string.Empty,
                EmpresaRut = row["EmpresaRut"] != DBNull.Value ? row["EmpresaRut"].ToString() : string.Empty,
                EmpresaDv = row["EmpresaDv"] != DBNull.Value ? row["EmpresaDv"].ToString() : string.Empty,
                EmpresaNombre = row["EmpresaNombre"] != DBNull.Value ? row["EmpresaNombre"].ToString() : string.Empty,
                Holding = row["Holding"] != DBNull.Value ? row["Holding"].ToString() : string.Empty,
                FechaNacimiento = row["FechaNacimiento"] != DBNull.Value ? row["FechaNacimiento"].ToString() : string.Empty,
                Edad = row["Edad"] != DBNull.Value ? Convert.ToInt32(row["Edad"]) : 0,
                Renta = row["Renta"] != DBNull.Value ? Convert.ToInt32(row["Renta"]) : 0,
                VecesRenta = row["VecesRenta"] != DBNull.Value ? Convert.ToInt32(row["VecesRenta"]) : 0,
                PreAprobado = row["PreAprobado"] != DBNull.Value ? Convert.ToInt32(row["PreAprobado"]) : 0,
                Prioridad = row["Prioridad"] != DBNull.Value ? Convert.ToInt32(row["Prioridad"]) : 0,
                EjecAsign_RutDv = row["EjecAsign_RutDv"] != DBNull.Value ? row["EjecAsign_RutDv"].ToString() : string.Empty,
                EjecAsign_Rut = row["EjecAsign_Rut"] != DBNull.Value ? Convert.ToInt32(row["EjecAsign_Rut"]) : 0,
                EjecAsign_Dv = row["EjecAsign_Dv"] != DBNull.Value ? row["EjecAsign_Dv"].ToString() : string.Empty,
                EjecAsign_Nombre = row["EjecAsign_Nombre"] != DBNull.Value ? row["EjecAsign_Nombre"].ToString() : string.Empty,
                EjecAsign_Cargo = row["EjecAsign_Cargo"] != DBNull.Value ? row["EjecAsign_Cargo"].ToString() : string.Empty,
                codOficina = row["codOficina"] != DBNull.Value ? Convert.ToInt32(row["codOficina"]) : 0,
                Oficina = row["Oficina"] != DBNull.Value ? row["Oficina"].ToString() : string.Empty,
                codZona = row["codZona"] != DBNull.Value ? Convert.ToInt32(row["codZona"]) : 0,
                Zona = row["Zona"] != DBNull.Value ? row["Zona"].ToString() : string.Empty,
                codRegion = row["codRegion"] != DBNull.Value ? Convert.ToInt32(row["codRegion"]) : 0,
                Region = row["Region"] != DBNull.Value ? row["Region"].ToString() : string.Empty,
                VentaMontoNetoReal = row["VentaMontoBruto"] != DBNull.Value ? Convert.ToInt32(row["VentaMontoBruto"]) : 0,
                Interesados = row["Interesados"] != DBNull.Value ? Convert.ToInt32(row["Interesados"]) : 0,
                Asignados = row["Asignados"] != DBNull.Value ? Convert.ToInt32(row["Asignados"]) : 0,
                Gestionados = row["Gestionados"] != DBNull.Value ? Convert.ToInt32(row["Gestionados"]) : 0,
                Contactados = row["Contactados"] != DBNull.Value ? Convert.ToInt32(row["Contactados"]) : 0,
                Presentados = row["Presentados"] != DBNull.Value ? Convert.ToInt32(row["Presentados"]) : 0,
                Aprobados = row["Aprobados"] != DBNull.Value ? Convert.ToInt32(row["Aprobados"]) : 0,
                Cursados = row["Cursados"] != DBNull.Value ? Convert.ToInt32(row["Cursados"]) : 0,

            };
        }
        private static TrackingDetalleEjecutivo ConstructorEntidadDetalleEjecutivo(DataRow row)
        {
            return new TrackingDetalleEjecutivo
            {

                AfiliadoRut = row["AfiliadoRut"] != DBNull.Value ? Convert.ToInt32(row["AfiliadoRut"]) : 0,
                AfiliadoDv = row["AfiliadoDv"] != DBNull.Value ? row["AfiliadoDv"].ToString() : string.Empty,
                AfiliadoNombre = row["AfiliadoNombre"] != DBNull.Value ? row["AfiliadoNombre"].ToString() : string.Empty,
                AfiliadoApellido = row["AfiliadoApellido"] != DBNull.Value ? row["AfiliadoApellido"].ToString() : string.Empty,
                AfiliadoSegmento = row["AfiliadoSegmento"] != DBNull.Value ? row["AfiliadoSegmento"].ToString() : string.Empty,
                EmpresaRut = row["EmpresaRut"] != DBNull.Value ? row["EmpresaRut"].ToString() : string.Empty,
                EmpresaDv = row["EmpresaDv"] != DBNull.Value ? row["EmpresaDv"].ToString() : string.Empty,
                EmpresaNombre = row["EmpresaNombre"] != DBNull.Value ? row["EmpresaNombre"].ToString() : string.Empty,
                Holding = row["Holding"] != DBNull.Value ? row["Holding"].ToString() : string.Empty,
                FechaNacimiento = row["FechaNacimiento"] != DBNull.Value ? row["FechaNacimiento"].ToString() : string.Empty,
                Edad = row["Edad"] != DBNull.Value ? Convert.ToInt32(row["Edad"]) : 0,
                Renta = row["Renta"] != DBNull.Value ? Convert.ToInt32(row["Renta"]) : 0,
                VecesRenta = row["VecesRenta"] != DBNull.Value ? Convert.ToInt32(row["VecesRenta"]) : 0,
                PreAprobado = row["PreAprobado"] != DBNull.Value ? Convert.ToInt32(row["PreAprobado"]) : 0,
                Prioridad = row["Prioridad"] != DBNull.Value ? Convert.ToInt32(row["Prioridad"]) : 0,
                EjecAsign_RutDv = row["EjecAsign_RutDv"] != DBNull.Value ? row["EjecAsign_RutDv"].ToString() : string.Empty,
                EjecAsign_Rut = row["EjecAsign_Rut"] != DBNull.Value ? Convert.ToInt32(row["EjecAsign_Rut"]) : 0,
                EjecAsign_Dv = row["EjecAsign_Dv"] != DBNull.Value ? row["EjecAsign_Dv"].ToString() : string.Empty,
                EjecAsign_Nombre = row["EjecAsign_Nombre"] != DBNull.Value ? row["EjecAsign_Nombre"].ToString() : string.Empty,
                EjecAsign_Cargo = row["EjecAsign_Cargo"] != DBNull.Value ? row["EjecAsign_Cargo"].ToString() : string.Empty,
                codOficina = row["codOficina"] != DBNull.Value ? Convert.ToInt32(row["codOficina"]) : 0,
                Oficina = row["Oficina"] != DBNull.Value ? row["Oficina"].ToString() : string.Empty,
                codZona = row["codZona"] != DBNull.Value ? Convert.ToInt32(row["codZona"]) : 0,
                Zona = row["Zona"] != DBNull.Value ? row["Zona"].ToString() : string.Empty,
                codRegion = row["codRegion"] != DBNull.Value ? Convert.ToInt32(row["codRegion"]) : 0,
                Region = row["Region"] != DBNull.Value ? row["Region"].ToString() : string.Empty,
                VentaMontoNetoReal = row["VentaMontoNetoReal"] != DBNull.Value ? Convert.ToInt32(row["VentaMontoNetoReal"]) : 0,
                Interesados = row["Interesados"] != DBNull.Value ? Convert.ToInt32(row["Interesados"]) : 0,
                Asignados = row["Asignados"] != DBNull.Value ? Convert.ToInt32(row["Asignados"]) : 0,
                Gestionados = row["Gestionados"] != DBNull.Value ? Convert.ToInt32(row["Gestionados"]) : 0,
                Contactados = row["Contactados"] != DBNull.Value ? Convert.ToInt32(row["Contactados"]) : 0,
                Presentados = row["Presentados"] != DBNull.Value ? Convert.ToInt32(row["Presentados"]) : 0,
                Aprobados = row["Aprobados"] != DBNull.Value ? Convert.ToInt32(row["Aprobados"]) : 0,
                Cursados = row["Cursados"] != DBNull.Value ? Convert.ToInt32(row["Cursados"]) : 0,

            };
        }
        public static List<TrackingComboCargo> ObtenerCombo(string TokenEjecutivo, int Periodo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@Periodo", Periodo),
                new Parametro("@TokenEjecutivo",TokenEjecutivo),
            };
            return DBHelper.InstanceReportes.ObtenerColeccion("negocios.SPReporte_CargaComboCargos", pram, ContructorCombo);

        }
        private static TrackingComboCargo ContructorCombo(DataRow row)
        {
            return new TrackingComboCargo
            {
                // Periodo= row["Periodo"] != DBNull.Value ? Convert.ToInt32(row["Periodo"]) : 0,
                EjecutivoCargo = row["EjecAsign_Cargo"] != DBNull.Value ? row["EjecAsign_Cargo"].ToString() : string.Empty,
            };
        }
        public static List<TrackingComboCargo> ObtenerComboPerfZonal(int CodOficina, int Periodo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@CodOficina",CodOficina),
                new Parametro("@Periodo", Periodo)

            };
            return DBHelper.InstanceReportes.ObtenerColeccion("negocios.SPReporte_CargaComboCargosPerfZonal", pram, ContructorComboPerfZonal);

        }
        public static List<TrackingComboCargo> ObtenerComboPerfZonalNormalizacion(int CodOficina, int Periodo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@CodOficina",CodOficina),
                new Parametro("@Periodo", Periodo)

            };
            return DBHelper.InstanceReportes.ObtenerColeccion("negocios.SPReporte_CargaComboCargosPerfZonalNormalizacion", pram, ContructorComboPerfZonal);

        }
        private static TrackingComboCargo ContructorComboPerfZonal(DataRow row)
        {
            return new TrackingComboCargo
            {
                // Periodo= row["Periodo"] != DBNull.Value ? Convert.ToInt32(row["Periodo"]) : 0,
                EjecutivoCargo = row["EjecAsign_Cargo"] != DBNull.Value ? row["EjecAsign_Cargo"].ToString() : string.Empty,
            };
        }
        public static List<TrackingComboCargoNormalizacion> ObtenerComboNormalizacion(string TokenEjecutivo, int Periodo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@Periodo", Periodo),
                new Parametro("@TokenEjecutivo",TokenEjecutivo),
            };
            return DBHelper.InstanceReportes.ObtenerColeccion("negocios.SPReporte_CargaComboCargosNormalizacion", pram, ContructorComboNormalizacion);

        }
        private static TrackingComboCargoNormalizacion ContructorComboNormalizacion(DataRow row)
        {
            return new TrackingComboCargoNormalizacion
            {
                // Periodo= row["Periodo"] != DBNull.Value ? Convert.ToInt32(row["Periodo"]) : 0,
                EjecutivoCargo = row["EjecAsign_Cargo"] != DBNull.Value ? row["EjecAsign_Cargo"].ToString() : string.Empty,
            };
        }
        public static List<TrackingSucursalZonal> ListarSucursalZonal(int Periodo, int CodZona)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@Periodo", Periodo),
                new Parametro("@CodZona",CodZona),
            };
            return DBHelper.InstanceReportes.ObtenerColeccion("negocios.SPReporte_TrackingPreAprobadosSucursalZonal", pram, ContructorSucursalZonal);
        }
        private static TrackingSucursalZonal ContructorSucursalZonal(DataRow row)
        {
            return new TrackingSucursalZonal
            {
                Periodo = row["Periodo"] != DBNull.Value ? Convert.ToInt32(row["Periodo"]) : 0,
                FechaActualizacion = row["Actualizacion"] != DBNull.Value ? row["Actualizacion"].ToString() : string.Empty,
                DiaHabil = row["DiaHabil_Actual"] != DBNull.Value ? row["DiaHabil_Actual"].ToString() : string.Empty,
                CodZona = row["CodZona"] != DBNull.Value ? Convert.ToInt32(row["CodZona"]) : 0,
                Zona = row["Zona"] != DBNull.Value ? row["Zona"].ToString() : string.Empty,
                CodOficina = row["codOficina"] != DBNull.Value ? Convert.ToInt32(row["codOficina"]) : 0,
                Oficina = row["Oficina"] != DBNull.Value ? row["Oficina"].ToString() : string.Empty,
                SumAsignado = row["SumaAsignados"] != DBNull.Value ? Convert.ToInt32(row["SumaAsignados"]) : 0,
                SumGestionado = row["SumaGestionados"] != DBNull.Value ? Convert.ToInt32(row["SumaGestionados"]) : 0,
                PorcentajeGestionado = row["SumaPorcentajeGestionados"] != DBNull.Value ? Convert.ToSingle(row["SumaPorcentajeGestionados"]) : 0,
                SumContactado = row["SumaContactados"] != DBNull.Value ? Convert.ToInt32(row["SumaContactados"]) : 0,
                PorcentajeContactado = row["SumaPorcentajeContactados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeContactados"]) : 0,
                SumPresentado = row["SumaPresentados"] != DBNull.Value ? Convert.ToInt32(row["SumaPresentados"]) : 0,
                PorcentajePresentado = row["SumaPorcentajePresentados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajePresentados"]) : 0,
                SumAprobado = row["SumaAprobados"] != DBNull.Value ? Convert.ToInt32(row["SumaAprobados"]) : 0,
                PorcentajeAprobado = row["SumaPorcentajeAprobados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeAprobados"]) : 0,
                SumCursado = row["SumaCursados"] != DBNull.Value ? Convert.ToInt32(row["SumaCursados"]) : 0,
                PorcentajeCursado = row["SumaPorcentajeCursados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeCursados"]) : 0,
                SumBruto = row["MontoBrutoSum"] != DBNull.Value ? Convert.ToInt32(row["MontoBrutoSum"]) : 0,
                PromBruto = row["MontoBrutoProm"] != DBNull.Value ? Convert.ToInt32(row["MontoBrutoProm"]) : 0,
                SumNeto = row["MontoNetoSum"] != DBNull.Value ? Convert.ToInt32(row["MontoNetoSum"]) : 0,
                PromNeto = row["MontoNetoProm"] != DBNull.Value ? Convert.ToInt32(row["MontoNetoProm"]) : 0,
                TotalEC = row["TotalEc"] != DBNull.Value ? Convert.ToInt32(row["TotalEc"]) : 0,
                SumInteresado = row["Interesados"] != DBNull.Value ? Convert.ToInt32(row["Interesados"]) : 0,
                SumRechazado = row["Rechazados"] != DBNull.Value ? Convert.ToInt32(row["Rechazados"]) : 0,
                PorcentajeInteresado = row["SumaPorcentajeInteresados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeInteresados"]) : 0,

            };
        }
        public static List<TrackingSucursalZonalNormalizacion> ListarSucursalZonalNormalizacion(int Periodo, int CodZona)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@Periodo", Periodo),
                new Parametro("@CodZona",CodZona),
            };
            return DBHelper.InstanceReportes.ObtenerColeccion("negocios.SPReporte_TrackingNormalizacionSucursalZonal", pram, ContructorSucursalZonalNormalizacion);
        }
        private static TrackingSucursalZonalNormalizacion ContructorSucursalZonalNormalizacion(DataRow row)
        {
            return new TrackingSucursalZonalNormalizacion
            {
                Periodo = row["Periodo"] != DBNull.Value ? Convert.ToInt32(row["Periodo"]) : 0,
                FechaActualizacion = row["Actualizacion"] != DBNull.Value ? row["Actualizacion"].ToString() : string.Empty,
                DiaHabil = row["DiaHabil_Actual"] != DBNull.Value ? row["DiaHabil_Actual"].ToString() : string.Empty,
                CodZona = row["CodZona"] != DBNull.Value ? Convert.ToInt32(row["CodZona"]) : 0,
                Zona = row["Zona"] != DBNull.Value ? row["Zona"].ToString() : string.Empty,
                CodOficina = row["codOficina"] != DBNull.Value ? Convert.ToInt32(row["codOficina"]) : 0,
                Oficina = row["Oficina"] != DBNull.Value ? row["Oficina"].ToString() : string.Empty,
                SumAsignado = row["SumaAsignados"] != DBNull.Value ? Convert.ToInt32(row["SumaAsignados"]) : 0,
                SumGestionado = row["SumaGestionados"] != DBNull.Value ? Convert.ToInt32(row["SumaGestionados"]) : 0,
                PorcentajeGestionado = row["SumaPorcentajeGestionados"] != DBNull.Value ? Convert.ToSingle(row["SumaPorcentajeGestionados"]) : 0,
                SumContactado = row["SumaContactados"] != DBNull.Value ? Convert.ToInt32(row["SumaContactados"]) : 0,
                PorcentajeContactado = row["SumaPorcentajeContactados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeContactados"]) : 0,
                SumPresentado = row["SumaPresentados"] != DBNull.Value ? Convert.ToInt32(row["SumaPresentados"]) : 0,
                PorcentajePresentado = row["SumaPorcentajePresentados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajePresentados"]) : 0,
                SumAprobado = row["SumaAprobados"] != DBNull.Value ? Convert.ToInt32(row["SumaAprobados"]) : 0,
                PorcentajeAprobado = row["SumaPorcentajeAprobados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeAprobados"]) : 0,
                SumCursado = row["SumaCursados"] != DBNull.Value ? Convert.ToInt32(row["SumaCursados"]) : 0,
                PorcentajeCursado = row["SumaPorcentajeCursados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeCursados"]) : 0,
                SumBruto = row["MontoBrutoSum"] != DBNull.Value ? Convert.ToInt32(row["MontoBrutoSum"]) : 0,
                PromBruto = row["MontoBrutoProm"] != DBNull.Value ? Convert.ToInt32(row["MontoBrutoProm"]) : 0,
                SumNeto = row["MontoNetoSum"] != DBNull.Value ? Convert.ToInt32(row["MontoNetoSum"]) : 0,
                PromNeto = row["MontoNetoProm"] != DBNull.Value ? Convert.ToInt32(row["MontoNetoProm"]) : 0,
                TotalEC = row["TotalEc"] != DBNull.Value ? Convert.ToInt32(row["TotalEc"]) : 0,
                SumInteresado = row["InteresadosSum"] != DBNull.Value ? Convert.ToInt32(row["InteresadosSum"]) : 0,
                //SumRechazado = row["Rechazados"] != DBNull.Value ? Convert.ToInt32(row["Rechazados"]) : 0,
                PorcentajeInteresado = row["SumaPorcentajeInteresados"] != DBNull.Value ? Convert.ToInt32(row["SumaPorcentajeInteresados"]) : 0,

            };
        }



        public static List<TrackingEntity> ListarTrackNormBySucursalPerfZonal(int CodOficina, int Periodo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@CodOficina",CodOficina),
                new Parametro("@Periodo", Periodo),
            };
            return DBHelper.InstanceReportes.ObtenerColeccion("Negocios.SPReporte_TrackNormAgenteSucursal_PerfZonal", pram, EntidadNormalizacionByPerfZonal);
        }
        private static TrackingEntity EntidadNormalizacionByPerfZonal(DataRow row)
        {
            return new TrackingEntity
            {
                CodOficina = row["codOficina"] != DBNull.Value ? Convert.ToInt32(row["codOficina"]) : 0,
                Oficina = row["Oficina"] != DBNull.Value ? row["Oficina"].ToString() : string.Empty,
                EjecutivoCargo = row["EjecAsign_Cargo"] != DBNull.Value ? row["EjecAsign_Cargo"].ToString() : string.Empty,
                EjecAsign_Rut = row["EjecAsign_Rut"] != DBNull.Value ? Convert.ToInt32(row["EjecAsign_Rut"]) : 0,
                EjecutivoNombre = row["EjecAsign_Nombre"] != DBNull.Value ? row["EjecAsign_Nombre"].ToString() : string.Empty,
                SumaAsignados = row["ASignados"] != DBNull.Value ? Convert.ToInt32(row["ASignados"]) : 0,
                SumaGestionados = row["Gestionados"] != DBNull.Value ? Convert.ToInt32(row["Gestionados"]) : 0,
                SumaPorcentajeGestionado = row["GestionadosPorc"] != DBNull.Value ? Convert.ToSingle(row["GestionadosPorc"]) : 0,
                SumaContactados = row["Contactados"] != DBNull.Value ? Convert.ToInt32(row["Contactados"]) : 0,
                SumaPorcentajeContactados = row["ContactadosPorc"] != DBNull.Value ? Convert.ToInt32(row["ContactadosPorc"]) : 0,
                SumaPresentados = row["Presentados"] != DBNull.Value ? Convert.ToInt32(row["Presentados"]) : 0,
                SumaPorcentajePresentados = row["PresentadosPorc"] != DBNull.Value ? Convert.ToInt32(row["PresentadosPorc"]) : 0,
                SumaAprobados = row["Aprobados"] != DBNull.Value ? Convert.ToInt32(row["Aprobados"]) : 0,
                SumaPorcentajeAprobados = row["AprobadosPorc"] != DBNull.Value ? Convert.ToInt32(row["AprobadosPorc"]) : 0,
                SumaCursados = row["Cursados"] != DBNull.Value ? Convert.ToInt32(row["Cursados"]) : 0,
                SumaPorcentajeCursados = row["CursadosPorc"] != DBNull.Value ? Convert.ToInt32(row["CursadosPorc"]) : 0,
                MontoPromedio = row["MontoBrutoProm"] != DBNull.Value ? Convert.ToInt32(row["MontoBrutoProm"]) : 0,
                SumaInteresados = row["Interesados"] != DBNull.Value ? Convert.ToInt32(row["Interesados"]) : 0,
                SumaPorcentajeInteresados = row["InteresadosPorc"] != DBNull.Value ? Convert.ToSingle(row["InteresadosPorc"]) : 0,
            };
        }

        // Sergio

        public static TrackingEjecutivoGestion ObtenerTotalesEjecutivoGestion(string Token)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@Token", Token)
            };
            return DBHelper.InstanceReportes.ObtenerEntidad("negocios.SPReporte_WidgetsEjecutivo_Gestiones", pram, EjecutivoGestion);
        }

        private static TrackingEjecutivoGestion EjecutivoGestion(DataRow row)
        {
            return new TrackingEjecutivoGestion
            {
                Asignados = row["Asignados"] != DBNull.Value ? Convert.ToInt32(row["Asignados"]) : 0,
                Gestionados = row["Gestionados"] != DBNull.Value ? Convert.ToInt32(row["Gestionados"]) : 0,
                Contactados = row["Contactados"] != DBNull.Value ? Convert.ToInt32(row["Contactados"]) : 0,
                Interesados = row["Interesados"] != DBNull.Value ? Convert.ToInt32(row["Interesados"]) : 0,
                Cursados = row["Cursados"] != DBNull.Value ? Convert.ToInt32(row["Cursados"]) : 0,
            };
        }

        public static TrackinVencimientosGestiones ObtenerVencidosGestiones(string Token)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@Token", Token)
            };
            return DBHelper.InstanceReportes.ObtenerEntidad("negocios.SPReporte_WidgetsEjec_GestionesDetalle", pram, EjecutivoVencimientoGestion);
        }

        private static TrackinVencimientosGestiones EjecutivoVencimientoGestion(DataRow row)
        {
            return new TrackinVencimientosGestiones
            {
                //Vencidos = row["Vencimiento"] != DBNull.Value ? row["Vencimiento"].ToString() : string.Empty,
                Vencidos = row["Vencido"] != DBNull.Value ? Convert.ToInt32(row["Vencido"]) : 0,
                VenceHoy = row["VenceHoy"] != DBNull.Value ? Convert.ToInt32(row["VenceHoy"]) : 0,
                VenceProx = row["VenceProx"] != DBNull.Value ? Convert.ToInt32(row["VenceProx"]) : 0,
            };
        }


        public static TrackEjecutivoGestionNormalizacion ObtenerGestionNormalizacion(string Token)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@Token", Token)
            };
            return DBHelper.InstanceReportes.ObtenerEntidad("negocios.SPReporte_WidgetsEjecutivo_Gestiones_Normalizacion", pram, EjecutivoNormalizacion);
        }

        private static TrackEjecutivoGestionNormalizacion EjecutivoNormalizacion(DataRow row)
        {
            return new TrackEjecutivoGestionNormalizacion
            {
                AsignadosNorm = row["Asignados"] != DBNull.Value ? Convert.ToInt32(row["Asignados"]) : 0,
                GestionadosNorm = row["Gestionados"] != DBNull.Value ? Convert.ToInt32(row["Gestionados"]) : 0,
                ContactadosNorm = row["Contactados"] != DBNull.Value ? Convert.ToInt32(row["Contactados"]) : 0,
                InteresadosNorm = row["Cursados"] != DBNull.Value ? Convert.ToInt32(row["Cursados"]) : 0,
                CursadosNorm = row["Interesados"] != DBNull.Value ? Convert.ToInt32(row["Interesados"]) : 0,
                SumaPorcentajeCurNorm = row["CursadosPorc"] != DBNull.Value ? Convert.ToInt32(row["CursadosPorc"]) : 0,

            };
        }


        public static TrackVencimientosGesNormalizacion ObtenerVencidosGesNormalizacion(string Token)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@Token", Token)
            };
            return DBHelper.InstanceReportes.ObtenerEntidad("negocios.SPReporte_WidgetsEjec_GestionesDetalle_Normalizacion", pram, EjecutivoVencNormalizacion);
        }

        private static TrackVencimientosGesNormalizacion EjecutivoVencNormalizacion(DataRow row)
        {
            return new TrackVencimientosGesNormalizacion
            {
                //Vencidos = row["Vencimiento"] != DBNull.Value ? row["Vencimiento"].ToString() : string.Empty,
                VencidosNorm = row["Vencido"] != DBNull.Value ? Convert.ToInt32(row["Vencido"]) : 0,
                VenceHoyNorm = row["VenceHoy"] != DBNull.Value ? Convert.ToInt32(row["VenceHoy"]) : 0,
                VenceProxNorm = row["VenceProx"] != DBNull.Value ? Convert.ToInt32(row["VenceProx"]) : 0,
            };
        }














    }
}
