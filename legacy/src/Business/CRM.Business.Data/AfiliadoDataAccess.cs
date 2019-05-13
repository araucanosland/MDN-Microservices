using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Business.Entity;
using System.Data;
using CDK.Data;
using CDK.Integration;
using CRM.Business.Entity.Afiliados;

namespace CRM.Business.Data
{
    public class AfiliadoDataAccess
    {
        public static Entity.Afiliados.AfiliadosEntity ObtenerDatosAfi(int RutAfiliado)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@RutAfiliado", RutAfiliado)
            };
            return DBHelper.InstanceCRM.ObtenerEntidad("mae.spMotor_BuscarAfiliadoScan", pram, ConstAfiliado);
        }

        //Lista combo
        public static List<Entity.Afiliados.AfiliadoEmpresaEntity> ListaRutEmpresa(int RutAfiliado)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@RutAfiliado", RutAfiliado)
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("mae.spMotor_BuscarAfiliadoScan_ListaEmpresa", pram, ConstAfiliadoEmpresa);
        }
        public static Entity.Afiliados.EmpresaAfiliadoEntity ObtenerDatosEmpresa(int RutEmpresa, int RutAfiliado)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@RutEmpresa", RutEmpresa),
                new Parametro("@RutAfiliado", RutAfiliado)
            };
            return DBHelper.InstanceCRM.ObtenerEntidad("mae.spMotor_BuscarAfiliadoScan_ObtenerEmpresa", pram, EmpresaAfiliado);
        }
        public static Entity.Afiliados.AfiliadoDatosCumpleanios ObtenerCumpleanos(int RutAfiliado)
        {
            Parametros param = new Parametros
            {
                new Parametro("@RutAfiliado",RutAfiliado)
            };
            return DBHelper.InstanceCRM.ObtenerEntidad("scafi.spMotor_MostrarCumpleanos", param, DatosContacto);
        }


        public static List<Entity.Afiliados.AfiliadoCampanas> ListaCampaniasAfi(int RutAfiliado)
        {
            Parametros pram = new Parametros
            {
                  new Parametro("@RutAfiliado", RutAfiliado)
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("mae.spMotor_BuscarAfiliadoScanCampanas", pram, CampaniaAfiConst);
        }
        public static List<Entity.Afiliados.AlertasAfiliados> ListarAlertasAfiliado(int RutAfiliado)
        {
            Parametros pram = new Parametros
            {
                  new Parametro("@RutAfiliado", RutAfiliado)
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("alertafi.spMotor_ListarAlertas", pram, Alertas);
        }

        public static List<Entity.Afiliados.AfiliadoCampanas> ObtenerHistorialCampana(int RutAfiliado, int TipoAsignacion)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@RutAfiliado", RutAfiliado),
                new Parametro("@TipoAsignacion", TipoAsignacion)
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("mae.spMotor_BuscarAfiliadoScanCampanasHist", pram, CampaniaAfiConst_Hitorial);
        }

        private static Entity.Afiliados.AfiliadoEmpresaEntity ConstAfiliadoEmpresa(DataRow row)
        {

            return new Entity.Afiliados.AfiliadoEmpresaEntity
            {
                RutEmpresa = row["rutempresa"] != DBNull.Value ? Convert.ToInt32(row["rutempresa"]) : 0,
                RutEmpresaDv = row["RutEmpresaDv"] != DBNull.Value ? row["RutEmpresaDv"].ToString() : string.Empty,
                NombreEmpresa = row["nombreempresa"] != DBNull.Value ? row["nombreempresa"].ToString() : string.Empty,

            };
        }
        private static Entity.Afiliados.AfiliadoDatosCumpleanios DatosContacto(DataRow row)
        {

            return new Entity.Afiliados.AfiliadoDatosCumpleanios
            {
                Estado = row["Estado"] != DBNull.Value ? row["Estado"].ToString() : string.Empty,
                FechaNacimiento = row["FechaNacimiento"] != DBNull.Value ? row["FechaNacimiento"].ToString() : string.Empty,
                Edad = row["Edad"] != DBNull.Value ? Convert.ToInt32(row["Edad"]) : 0,
                RutAfiliado = row["RutAfiliado"] != DBNull.Value ? Convert.ToInt32(row["RutAfiliado"]) : 0,

            };
        }

        private static Entity.Afiliados.AlertasAfiliados Alertas(DataRow row)
        {

            return new Entity.Afiliados.AlertasAfiliados
            {
                AfiliadoRut = row["RutAfiliado"] != DBNull.Value ? Convert.ToInt32(row["RutAfiliado"]) : 0,
                Tipo = row["Tipo"] != DBNull.Value ? row["Tipo"].ToString() : string.Empty,
                Valor = row["valor"] != DBNull.Value ? row["valor"].ToString() : string.Empty,
                TipoValor = row["TipoAlerta"] != DBNull.Value ? row["TipoAlerta"].ToString() : string.Empty,
            };
        }


        private static Entity.Afiliados.EmpresaAfiliadoEntity EmpresaAfiliado(DataRow row)
        {

            return new Entity.Afiliados.EmpresaAfiliadoEntity
            {
                RutEmpresa = row["rutempresa"] != DBNull.Value ? Convert.ToInt32(row["rutempresa"]) : 0,
                RutEmpresaDv = row["RutEmpresaDv"] != DBNull.Value ? row["RutEmpresaDv"].ToString() : string.Empty,
                NombreEmpresa = row["nombreempresa"] != DBNull.Value ? row["nombreempresa"].ToString() : string.Empty,
                PeriodoUltimaRenta = row["PeriodoUltimaRenta"] != DBNull.Value ? row["PeriodoUltimaRenta"].ToString() : string.Empty,
                RentaUltimaInformada = row["RentaUltimaInformada"] != DBNull.Value ? Convert.ToInt32(row["RentaUltimaInformada"]) : 0,
                RolSegmentoAfiliado = row["RolSegmentoAfiliado"] != DBNull.Value ? row["RolSegmentoAfiliado"].ToString() : string.Empty,


            };
        }
        private static Entity.Afiliados.AfiliadosEntity ConstAfiliado(DataRow row)
        {

            return new Entity.Afiliados.AfiliadosEntity
            {
                Periodo = row["Periodo"] != DBNull.Value ? Convert.ToInt32(row["Periodo"]) : 0,
                RutAfiliado = row["RutAfiliado"] != DBNull.Value ? row["RutAfiliado"].ToString() : string.Empty,
                Nombres = row["Nombres"] != DBNull.Value ? row["Nombres"].ToString() : string.Empty,
                Apellidos = row["Apellidos"] != DBNull.Value ? row["Apellidos"].ToString() : string.Empty,
                Nacionalidad = row["Nacionalidad"] != DBNull.Value ? row["Nacionalidad"].ToString() : string.Empty,
                Sexo = row["Sexo"] != DBNull.Value ? row["Sexo"].ToString() : string.Empty,
                FechaNacimiento = row["FechaNacimiento"] != DBNull.Value ? row["FechaNacimiento"].ToString() : string.Empty,
                Edad = row["Edad"] != DBNull.Value ? Convert.ToInt32(row["Edad"]) : 0,
                EstadoCivil = row["EstadoCivil"] != DBNull.Value ? row["EstadoCivil"].ToString() : string.Empty,
                RolSegmentoAfiliado = row["RolSegmentoAfiliado"] != DBNull.Value ? row["RolSegmentoAfiliado"].ToString() : string.Empty,
                InicioValidezRol = row["InicioValidezRol"] != DBNull.Value ? row["InicioValidezRol"].ToString() : string.Empty,
                FinValidezRol = row["FinValidezRol"] != DBNull.Value ? (row["FinValidezRol"]).ToString() : string.Empty,
                RegimenPrevisional = row["RegimenPrevisional"] != DBNull.Value ? row["RegimenPrevisional"].ToString() : string.Empty,
                RegimenSalud = row["RegimenSalud"] != DBNull.Value ? row["RegimenSalud"].ToString() : string.Empty,
                CargoAfiliado = row["CargoAfiliado"] != DBNull.Value ? row["CargoAfiliado"].ToString() : string.Empty,
                TipoContrato = row["TipoContrato"] != DBNull.Value ? row["TipoContrato"].ToString() : string.Empty,
                PeriodoUltimaRenta = row["PeriodoUltimaRenta"] != DBNull.Value ? Convert.ToInt32(row["PeriodoUltimaRenta"]) : 0,
                RentaUltimaInformada = row["RentaUltimaInformada"] != DBNull.Value ? Convert.ToInt32(row["RentaUltimaInformada"]) : 0,
                RegionAfiliado = row["RegionAfiliado"] != DBNull.Value ? row["RegionAfiliado"].ToString() : string.Empty,
                ComunaAfiliado = row["ComunaAfiliado"] != DBNull.Value ? row["ComunaAfiliado"].ToString() : string.Empty,
                Cel = row["Cel"] != DBNull.Value ? row["Cel"].ToString() : string.Empty,
                Fono = row["Fono"] != DBNull.Value ? row["Fono"].ToString() : string.Empty,
                Mail = row["Mail"] != DBNull.Value ? row["Mail"].ToString() : string.Empty,
                Vigente = row["Vigente"] != DBNull.Value ? Convert.ToInt32(row["Vigente"]) : 0,
                Fallecido = row["Fallecido"] != DBNull.Value ? Convert.ToInt32(row["Fallecido"]) : 0,
                FlagNoMolestar = row["FlagNoMolestar"] != DBNull.Value ? Convert.ToInt32(row["FlagNoMolestar"]) : 0,
                MotivoNM = row["MotivoNM"] != DBNull.Value ? row["MotivoNM"].ToString() : string.Empty,
            };
        }
        private static Entity.Afiliados.AfiliadoCampanas CampaniaAfiConst(DataRow row)
        {

            return new Entity.Afiliados.AfiliadoCampanas
            {
                Periodo = row["Periodo"] != DBNull.Value ? row["Periodo"].ToString() : string.Empty,
                RutAfiliado = row["Afiliado_Rut"] != DBNull.Value ? Convert.ToInt32(row["Afiliado_Rut"]) : 0,
                RutDvAfiliado = row["Afiliado_Dv"] != DBNull.Value ? row["Afiliado_Dv"].ToString() : string.Empty,
                Campania = row["Campania"] != DBNull.Value ? row["Campania"].ToString() : string.Empty,
                Oferta = row["Oferta"] != DBNull.Value ? Convert.ToInt32(row["Oferta"]) : 0,
                Prioridad = row["Prioridad"] != DBNull.Value ? row["Prioridad"].ToString() : string.Empty,
                id_Asginacion = row["id_Asign"] != DBNull.Value ? Convert.ToInt32(row["id_Asign"]) : 0,
                TipoAsignacion = row["TipoAsignacion"] != DBNull.Value ? Convert.ToInt32(row["TipoAsignacion"]) : 0,
                Estado = row["EstadoGestion"] != DBNull.Value ? row["EstadoGestion"].ToString() : string.Empty,
                SubEstado = row["SubEstadoGestion"] != DBNull.Value ? row["SubEstadoGestion"].ToString() : string.Empty,
                FechaCompromete = row["FComprometeGestion"] != DBNull.Value ? Convert.ToDateTime(row["FComprometeGestion"]) : DateTime.MinValue,

            };
        }
        private static Entity.Afiliados.AfiliadoCampanas CampaniaAfiConst_Hitorial(DataRow row)
        {

            return new Entity.Afiliados.AfiliadoCampanas
            {
                Periodo = row["Periodo"] != DBNull.Value ? row["Periodo"].ToString() : string.Empty,
                RutAfiliado = row["Afiliado_Rut"] != DBNull.Value ? Convert.ToInt32(row["Afiliado_Rut"]) : 0,
                RutDvAfiliado = row["Afiliado_Dv"] != DBNull.Value ? row["Afiliado_Dv"].ToString() : string.Empty,
                Campania = row["Campania"] != DBNull.Value ? row["Campania"].ToString() : string.Empty,
                Oferta = row["Oferta"] != DBNull.Value ? Convert.ToInt32(row["Oferta"]) : 0,
                Prioridad = row["Prioridad"] != DBNull.Value ? row["Prioridad"].ToString() : string.Empty,
                id_Asginacion = row["id_Asign"] != DBNull.Value ? Convert.ToInt32(row["id_Asign"]) : 0,
                TipoAsignacion = row["TipoAsignacion"] != DBNull.Value ? Convert.ToInt32(row["TipoAsignacion"]) : 0,
                Estado = row["EstadoGestion"] != DBNull.Value ? row["EstadoGestion"].ToString() : string.Empty,
                SubEstado = row["SubEstadoGestion"] != DBNull.Value ? row["SubEstadoGestion"].ToString() : string.Empty,
                FechaCompromete = row["FComprometeGestion"] != DBNull.Value ? Convert.ToDateTime(row["FComprometeGestion"]) : DateTime.MinValue,
                FechaAccion = row["FechaAccion"] != DBNull.Value ? Convert.ToDateTime(row["FechaAccion"]) : DateTime.MinValue,
                Descripcion = row["Descripcion"] != DBNull.Value ? row["Descripcion"].ToString() : string.Empty,
                Nombres = row["Nombre"] != DBNull.Value ? row["Nombre"].ToString() : string.Empty,
                EsTerminal = row["EstadoTerminal"] != DBNull.Value ? row["EstadoTerminal"].ToString() : string.Empty,
            };
        }

        public static Entity.Afiliados.NoMolestarAfiliado AfilidoNoMolestar(string RutAfiliado, string motivo, string token)
        {
            Parametros param = new Parametros
            {
                new Parametro("@RutAfiliado",RutAfiliado),
                new Parametro("@Motivo",motivo),
                new Parametro("@TokenEjecutivo",token),
            };
            return DBHelper.InstanceCRM.ObtenerEntidad("dbo.SpMotor_Guarda_NoMolestar", param, Afiliado_NoMolestar);
        }


        private static Entity.Afiliados.NoMolestarAfiliado Afiliado_NoMolestar(DataRow row)
        {
            return new Entity.Afiliados.NoMolestarAfiliado
            {
                RutAfiliado = row["RutAfiliado"] != DBNull.Value ? row["RutAfiliado"].ToString() : string.Empty,
                Motivo = row["Motivo"] != DBNull.Value ? row["Motivo"].ToString() : string.Empty,
            };
        }

        public static Entity.Afiliados.ObservacionAfiliado AfiliadoComentario(string RutAfiliado, string Observacion, string token)
        {
            Parametros param = new Parametros
            {
                new Parametro("@RutAfiliado",RutAfiliado),
                new Parametro("@Observacion",Observacion),
                new Parametro("@TokenEjecutivo",token),
            };
            return DBHelper.InstanceCRM.ObtenerEntidad("dbo.SpMotor_Guarda_AfiliadoComentario", param, Afiliado_Comentario);
        }

        private static Entity.Afiliados.ObservacionAfiliado Afiliado_Comentario(DataRow row)
        {
            return new Entity.Afiliados.ObservacionAfiliado
            {
                RutAfiliado = row["RutAfiliado"] != DBNull.Value ? row["RutAfiliado"].ToString() : string.Empty,
                Observacion = row["Comentario"] != DBNull.Value ? row["Comentario"].ToString() : string.Empty,
            };
        }

        public static Entity.Afiliados.NoMolestarAfiliado sacaMarcaNoMolestar(string RutAfiliado, string token)
        {
            Parametros param = new Parametros
            {
                new Parametro("@RutAfiliado",RutAfiliado),
                new Parametro("@TokenEjecutivo",token),
            };
            return DBHelper.InstanceCRM.ObtenerEntidad("dbo.SpMotor_Saca_Marca_NoMolestar", param, sacaMarca_NoMolestar);
        }

        private static Entity.Afiliados.NoMolestarAfiliado sacaMarca_NoMolestar(DataRow row)
        {
            return new Entity.Afiliados.NoMolestarAfiliado
            {
                RutAfiliado = row["RutAfiliado"] != DBNull.Value ? row["RutAfiliado"].ToString() : string.Empty,
            };
        }


        public static List<Entity.Afiliados.AfiliadoProyeccion> ObtieneProyeccionAfiliado(string RutAfiliado)
        {
            Parametros param = new Parametros
            {
                new Parametro("@RutAfiliado",RutAfiliado),
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("dbo.SpMotor_Lista_Gestion_lineaTiempo", param, ProyecAfiliado);
        }


        public static List<Entity.Afiliados.AfiliadoProyeccion> FiltroProyeccionAfiliado(string RutAfiliado, int Estado)
        {
            Parametros param = new Parametros
            {
                new Parametro("@RutAfiliado",RutAfiliado),
                new Parametro("@Estado",Estado),
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("dbo.SpMotor_Filtro_Gestion_lineaTiempo", param, ProyecAfiliado);
        }

        private static Entity.Afiliados.AfiliadoProyeccion ProyecAfiliado(DataRow row)
        {
            return new Entity.Afiliados.AfiliadoProyeccion
            {
                RutAfiliado = row["RutAfiliado"] != DBNull.Value ? row["RutAfiliado"].ToString() : string.Empty,
                Fecha = row["Fecha"] != DBNull.Value ? Convert.ToDateTime(row["Fecha"]) : DateTime.MinValue,
                Estado = row["Estado"] != DBNull.Value ? row["Estado"].ToString() : string.Empty,
                SubEstado = row["SubEstado"] != DBNull.Value ? row["SubEstado"].ToString() : string.Empty,
                Afiliado = row["Afiliado"] != DBNull.Value ? row["Afiliado"].ToString() : string.Empty,
                Ejecutivo = row["Ejecutivo"] != DBNull.Value ? row["Ejecutivo"].ToString() : string.Empty,
                Sucursal = row["Sucursal"] != DBNull.Value ? row["Sucursal"].ToString() : string.Empty,
                PreAprobadoFinal = row["PreAprobadoFinal"] != DBNull.Value ? Convert.ToInt32(row["PreAprobadoFinal"]) : 0,
                Periodo = row["Periodo"] != DBNull.Value ? row["Periodo"].ToString() : string.Empty,
                EstadoGestion = row["EstadoGestion"] != DBNull.Value ? Convert.ToInt32(row["EstadoGestion"]) : 0,
            };
        }
        //


        public static Entity.Afiliados.AfiliadosEntity BuscarAfiliadoFalabella(string RutAfiliado)
        {
            Parametros param = new Parametros
            {
                new Parametro("@RutAfiliado",RutAfiliado)
            };
            return DBHelper.InstanceCRM.ObtenerEntidad("proceso.sp_AfiliadosFalabella", param, rsFalabella);
        }

        public static void GuardarGestionFalabella(GestionAfiliadoFalabella entrada, string token)
        {
            Parametros param = new Parametros
            {
                new Parametro("@Ticket",entrada.TicketGestion.ToString()),
                new Parametro("@RutAfiliado",entrada.RutAfiliado),
                new Parametro("@Beneficios",entrada.Beneficios),
                new Parametro("@Correo",entrada.Correo),
                new Parametro("@MontoRef",entrada.MontoRef),
                new Parametro("@Observacion",entrada.Observacion),
                new Parametro("@Telefono",entrada.Telefono),
                new Parametro("@TipoGestion",entrada.TipoGestion),
                new Parametro("@Token",token)
            };
            DBHelper.InstanceCRM.EjecutarProcedimiento("proceso.sp_GuardaGestionFalabella", param);
        }


        public static List<GestionAfiliadoFalabella> ListarGestionFalabella(int oficina)
        {
            Parametro p = new Parametro("@Oficina", oficina);
            return DBHelper.InstanceCRM.ObtenerColeccion("proceso.sp_ListaGestionFalabella", p, rsFalabellaGestion);
        }



        private static GestionAfiliadoFalabella rsFalabellaGestion(DataRow row)
        {
            return new GestionAfiliadoFalabella
            {
                RutAfiliado = row["RutAfiliado"] != DBNull.Value ? row["RutAfiliado"].ToString() : string.Empty,
                Beneficios = row["Beneficios"] != DBNull.Value ? row["Beneficios"].ToString() : string.Empty,
                Correo = row["Correo"] != DBNull.Value ? row["Correo"].ToString() : string.Empty,
                TipoGestion = row["TipoGestion"] != DBNull.Value ? row["TipoGestion"].ToString() : string.Empty,
                Telefono = row["Telefono"] != DBNull.Value ? row["Telefono"].ToString() : string.Empty,
                Ejecutivo = row["Ejecutivo"] != DBNull.Value ? row["Ejecutivo"].ToString() : string.Empty,
                MontoRef = row["MontoRef"] != DBNull.Value ? row["MontoRef"].ToString() : string.Empty,
                Observacion = row["Observacion"] != DBNull.Value ? row["Observacion"].ToString() : string.Empty,
                TicketGestion = row["TicketGestion"] != DBNull.Value ? Guid.Parse(row["TicketGestion"].ToString()) : Guid.Empty
            };
        }

        private static Entity.Afiliados.AfiliadosEntity rsFalabella(DataRow row)
        {
            return new Entity.Afiliados.AfiliadosEntity
            {
                RutAfiliado = row["RutAfiliado"] != DBNull.Value ? row["RutAfiliado"].ToString() : string.Empty,
                Nombres = row["Nombres"] != DBNull.Value ? row["Nombres"].ToString() : string.Empty
            };
        }


        public static List<Entity.Afiliados.EnfermedadesEncuestaEntity> ObtenerEnfermedades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("mae.spMotorCartera_ObtenerEnfermedades", ConEnfermedades);
        }

        private static Entity.Afiliados.EnfermedadesEncuestaEntity ConEnfermedades(DataRow row)
        {

            return new Entity.Afiliados.EnfermedadesEncuestaEntity
            {
                Id = row["Id"] != DBNull.Value ? Convert.ToInt32(row["Id"]) : 0,
                Patologia = row["Patologia"] != DBNull.Value ? row["Patologia"].ToString() : string.Empty,
                Categoria = row["Categoria"] != DBNull.Value ? row["Categoria"].ToString() : string.Empty,

            };
        }

        public static List<Entity.Afiliados.MedicamantosEncuestaEntity> ObtenerMedicamentos()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("mae.spMotorCartera_ObtenerMedicamentos", ConMedicamentos);
        }

        private static Entity.Afiliados.MedicamantosEncuestaEntity ConMedicamentos(DataRow row)
        {

            return new Entity.Afiliados.MedicamantosEncuestaEntity
            {
                Id = row["Id"] != DBNull.Value ? Convert.ToInt32(row["Id"]) : 0,
                Medicamento = row["Medicamento"] != DBNull.Value ? row["Medicamento"].ToString() : string.Empty,
                Categoria = row["Categoria"] != DBNull.Value ? row["Categoria"].ToString() : string.Empty,

            };
        }

        public static void  GuardarEncuestaEnfermedades(EncuestaEntity entrada)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@Adquiere_CanastaGes ", entrada.Adquiere_CanastaGes),
                new Parametro("@Adquiere_Consultorio ", entrada.Adquiere_Consultorio),
                new Parametro("@Adquiere_Farmacia ", entrada.Adquiere_Farmacia),
                new Parametro("@Edad ", entrada.Edad),
                new Parametro("@Enfermedad_1 ", entrada.Enfermedad_1),
                new Parametro("@Enfermedad_2 ", entrada.Enfermedad_2),
                new Parametro("@Enfermedad_3 ", entrada.Enfermedad_3),
                new Parametro("@Enfermedad_4 ", entrada.Enfermedad_4),
                new Parametro("@Enfermedad_5 ", entrada.Enfermedad_5),
                new Parametro("@Enfermedad_6 ", entrada.Enfermedad_6),
                new Parametro("@Enfermedad_7 ", entrada.Enfermedad_7),
                new Parametro("@Enfermedad_8 ", entrada.Enfermedad_8),
                new Parametro("@Enfermedad_9 ", entrada.Enfermedad_9),
                new Parametro("@Enfermedad_10 ", entrada.Enfermedad_10),
                new Parametro("@Enfermedad_11 ", entrada.Enfermedad_11),
                new Parametro("@Medicamentos_1 ", entrada.Medicamentos_1),
                new Parametro("@Medicamentos_2 ", entrada.Medicamentos_2),
                new Parametro("@Medicamentos_3 ", entrada.Medicamentos_3),
                new Parametro("@Medicamentos_4 ", entrada.Medicamentos_4),
                new Parametro("@Medicamentos_5 ", entrada.Medicamentos_5),
                new Parametro("@Medicamentos_6 ", entrada.Medicamentos_6),
                new Parametro("@Medicamentos_7 ", entrada.Medicamentos_7),
                new Parametro("@Medicamentos_8 ", entrada.Medicamentos_8),
                new Parametro("@Medicamentos_9 ", entrada.Medicamentos_9),
                new Parametro("@Medicamentos_10 ", entrada.Medicamentos_10),
                new Parametro("@Medicamentos_11 ", entrada.Medicamentos_11),
                new Parametro("@Medicamentos_12 ", entrada.Medicamentos_12),
                new Parametro("@Medicamentos_13 ", entrada.Medicamentos_13),
                new Parametro("@Medicamentos_14 ", entrada.Medicamentos_14),
                new Parametro("@Medicamentos_15 ", entrada.Medicamentos_15),
                new Parametro("@Medicamentos_16 ", entrada.Medicamentos_16),
                new Parametro("@NombreFarmacia ", entrada.NombreFarmacia),
                new Parametro("@Actividad ", entrada.Actividad),
                new Parametro("@Nombre_Afiliado ", entrada.Nombre_Afiliado),
                new Parametro("@Prevision ", entrada.Prevision),
                new Parametro("@Rut_Afiliado ", entrada.Rut_Afiliado),
                new Parametro("@Rut_Ejecutivo ", entrada.Rut_Ejecutivo),
                new Parametro("@Sexo ", entrada.Sexo),
                new Parametro("@Sucursal ", entrada.Sucursal),
                new Parametro("@Tiene_Enfermedad ", entrada.Tiene_Enfermedad),
                new Parametro("@Flag_Encuesta ", entrada.Flag_Encuesta),
            };
            DBHelper.InstanceCRM.EjecutarProcedimiento("dbo.sp_Encuesta_01_InsertEncuesta", parametros);

        }

        public static List<Entity.Afiliados.EncuestaEntity> ObtenerEstadoEncuesta(string RutAfiliado)
        {
            Parametro p = new Parametro("@RUT_AFILIADO", RutAfiliado);
            return DBHelper.InstanceCRM.ObtenerColeccion("mae.spMotor_ConsultaEncuestaEnfermedades", p, EstadoEncuesta);
        }

        private static Entity.Afiliados.EncuestaEntity EstadoEncuesta(DataRow row)
        {

            return new Entity.Afiliados.EncuestaEntity
            {
                Flag_Encuesta = row["Flag_Encuesta"] != DBNull.Value ? Convert.ToInt32(row["Flag_Encuesta"]) : 0,
            };
        }
    }

}
