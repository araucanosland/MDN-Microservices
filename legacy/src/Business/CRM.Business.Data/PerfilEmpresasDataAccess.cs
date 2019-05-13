using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Business.Entity;
using System.Data;
using CDK.Data;
using CDK.Integration;

namespace CRM.Business.Data
{
    public static class PerfilEmpresasDataAccess
    {
        public static List<CarteraEmpresasEntity> ObtieneCarteraEmp(string token)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@Token", token),
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.spMotorCartera_ListaCarteraEjecutivo", pram, ListaCarteraEmpresa);
        }


        public static List<CarteraEmpresasEntity> ObtieneCarteraAgen(string token)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@Token", token),
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.spMotorCartera_ListaCarteraAgente", pram, ListaCarteraEmpresaAgente);
        }

        public static Entity.GestionEmpresasEntity ObtienePerfilEmp(string RutEmpresa)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@RUT_EMPRESA", RutEmpresa),
            };
            return DBHelper.InstanceCRM.ObtenerEntidad("carteras.spMotorCartera_ListaPerfilEjecutivo", pram, ObDatosEmpresa);
        }


        public static Entity.GestionEmpresasEntity ObtienePerfilEmpAnexo(int IdEmpresaA)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@ID_EMPRESA", IdEmpresaA),
            };
            return DBHelper.InstanceCRM.ObtenerEntidad("carteras.spMotorCartera_ListaPerfilEjecutivoAnexo", pram, ObDatosEmpresa);
        }


        public static List<AsigandosEjecutivoEmpresaEntity> ObtieneAsignacionEjeEmp(string token, string rutEmpresa)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@Token", token),
                new Parametro("@RUT_EMPRESA", rutEmpresa),
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.spMotorCartera_ListaPreAprobadoEmpresa", pram, AsigEjeEmpresa);
        }


        public static long GuardaGestion(int CodIngreso, string Token)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@Token", Token),
                new Parametro("@CodIngreso", CodIngreso)
            };

            return DBHelper.InstanceCRM.ObtenerEscalar<long>("licencias.sp_Lic_Ingresolicencia_Eliminar", parametros);
        }

        public static List<ComunasEmpresaEntity> ObtieneComunaEmp()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.spMotorCartera_ListaComunas", ListaComunaEmpresa);
        }

        public static List<EjecutivosAsignadosEntity> ObtieneEjeAsignados(int IdEmpresa)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@ID_EMPRESA", IdEmpresa),
            };

            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.spMotorCartera_Lista_EjecutivoAsigEmpresa", parametros, ListaEjecutivosAsigEmp);
        }

        public static List<AnexoEmpresaEntity> ObtieneAnexoEmp(string RutEmpresa, string token)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@RUT_EMPRESA", RutEmpresa),
                new Parametro("@Token", token),
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.spMotorCartera_Anexo", pram, ListaAnexoEmp);
        }

        public static Entity.AnexoEmpresaEntity ObtieneDatosAnexo(int IdEmpresa)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@IdEmpresaAnexo", IdEmpresa),
            };
            return DBHelper.InstanceCRM.ObtenerEntidad("carteras.spMotorCartera_Lista_datos_anexo", pram, ListaAnexoEmp);
        }


        public static int InsertaNuevoAnexo(string Token, string RutEmpresa, string NombreEmpresa, string Anexo, int NumTrabajadores, int IdComuna, string NombreComuna, string Direccion)
        {
            Parametros parametros = new Parametros
            {
                 new Parametro("@Token", Token),
                 new Parametro("@RutEmpresa", RutEmpresa),
                 new Parametro("@NombreEmpresa", NombreEmpresa),
                 new Parametro("@Anexo", Anexo),
                 new Parametro("@NumTrabajadores", NumTrabajadores),
                 new Parametro("@IdComuna", IdComuna),
                 new Parametro("@NombreComuna", NombreComuna),
                 new Parametro("@Direccion", Direccion),
            };
            return DBHelper.InstanceCRM.EjecutarProcedimiento("carteras.sp_MotorCartera_GuardaAnexo", parametros);
        }
        public static long GuardarAsignacionEmpAnexo(string tipo, string rut, long Id)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@Tipo", tipo ),
                new Parametro("@id", Id ),
                new Parametro("@RutEjecutivo", rut),

            };
            return DBHelper.InstanceCRM.ObtenerEscalar<long>("carteras.spMotorCartera_IngresoAsignacionEmpAnexo", parametros);
        }

        public static long EliminaAsignacionEmpAnexo(string tipo, string rut, long id)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@Tipo", tipo ),
                new Parametro("@id", id ),
                new Parametro("@RutEjecutivo", rut),

            };
            return DBHelper.InstanceCRM.ObtenerEscalar<long>("carteras.spMotorCartera_EliminaAsignacionEmpAnexo", parametros);
        }


        public static int ActualizaAnexo(int IdEmpresaAnexo, string Anexo, int NumTrabajadores, int IdComuna, string NombreComuna, string Direccion)
        {
            Parametros parametros = new Parametros
            {
                 new Parametro("@IdEmpresaAnexo", IdEmpresaAnexo),
                 new Parametro("@Anexo", Anexo),
                 new Parametro("@NumTrabajadores", NumTrabajadores),
                 new Parametro("@IdComuna", IdComuna),
                 new Parametro("@NombreComuna", NombreComuna),
                 new Parametro("@Direccion", Direccion),
            };
            return DBHelper.InstanceCRM.EjecutarProcedimiento("carteras.spMotorCartera_Actualiza_datos_anexo", parametros);
        }

        public static ContadorAnexoEntity ObtieneContadorAnexo(string RutEmpresa)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@RutEmpresa", RutEmpresa),
            };
            return DBHelper.InstanceCRM.ObtenerEntidad("carteras.spMotorCartera_Contador_Anexos", pram, ListaContAnexos);
        }


        public static int InsertaAfiliadoAnexo(int anexo, string rutAfiliado)
        {
            Parametros parametros = new Parametros
            {
                 new Parametro("@RUT_AFILIADO", rutAfiliado),
                 new Parametro("@ID_ANEXO", anexo),
            };
            return DBHelper.InstanceCRM.EjecutarProcedimiento("carteras.spMotorCartera_GuardaAfiliadosAnexos", parametros);
        }


        public static List<AsigandosEjecutivoEmpresaEntity> ObtienePreAprobasoAnex(int idAnexo, string rutEmpresa)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@ID_ANEXO", idAnexo),
                new Parametro("@RUT_EMPRESA", rutEmpresa),
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.spMotorCartera_ListaPreAprobadoAnexo", pram, AsigEjeEmpresa);
        }
        //static Entity.GestionEmpresasEntity
        //public static int InsertaNuevoCabEntrevista(string Token, string RutEmpresa, string FechaEntrevista, string NombreContacto, string Estamento, string Cargo, string Comentarios)
        public static EntrevistaEntity InsertaNuevoCabEntrevista(string Token, string RutEmpresa, string FechaEntrevista, string NombreContacto, string Estamento, string Cargo, string Comentarios, string TelefonoContacto, string CorreoContacto, int Anexo)
        {
            Parametros parametros = new Parametros
            {
                 new Parametro("@TOKEN", Token),
                 new Parametro("@RUT_EMPRESA", RutEmpresa),
                 new Parametro("@FECHA_ENTREVISTA", FechaEntrevista),
                 new Parametro("@CONTACTO", NombreContacto),
                 new Parametro("@ESTAMENTO", Estamento),
                 new Parametro("@CARGO", Cargo),
                 new Parametro("@TELEFONO", TelefonoContacto),
                 new Parametro("@CORREO", CorreoContacto),
                 new Parametro("@COMENTARIO", Comentarios),
                 new Parametro("@ANEXO", Anexo),
            };
            return DBHelper.InstanceCRM.ObtenerEntidad("carteras.spMotorCartera_Guarda_CabeceraEntrevista", parametros, ListaIdEntravista);
        }

        public static CabGestionMantencionEntity InsertaNuevoCabDetalleGestion(string Token, string RutEmpresa, string FechaIngreso, string Tipo, string Comentarios, int Anexo)
        {
            Parametros parametros = new Parametros
            {
                 new Parametro("@TOKEN", Token),
                 new Parametro("@RUT_EMPRESA", RutEmpresa),
                 new Parametro("@FECHA_INGRESO", FechaIngreso),
                 new Parametro("@TIPO", Tipo),
                 new Parametro("@COMENTARIO", Comentarios),
                 new Parametro("@ANEXO", Anexo),

            };
            return DBHelper.InstanceCRM.ObtenerEntidad("carteras.spMotorCartera_Guarda_Cabecera_ManGestion", parametros, ListaIdManGestion);
        }

        public static int InsertaDetalleEntrevista(string Token, int IdEntrevista, string Tema, string SubTema, string Semaforo, int Alerta, string FechaResolucion, string Comentarios, int Compromiso)
        {
            Parametros parametros = new Parametros
            {
                 new Parametro("@TOKEN", Token),
                 new Parametro("@ID_ENTREVISTA", IdEntrevista),
                 new Parametro("@TEMA", Tema),
                 new Parametro("@SUBTEMA", SubTema),
                 new Parametro("@SEMAFORO", Semaforo),
                 new Parametro("@ALERTA", Alerta),
                 new Parametro("@FECHA_RESOLUCION", FechaResolucion),
                 new Parametro("@COMENTARIOS", Comentarios),
                 new Parametro("@COMPROMISO", Compromiso),
            };
            return DBHelper.InstanceCRM.EjecutarProcedimiento("carteras.spMotorCartera_Guarda_DetalleEntrevista", parametros);
        }

        public static int ActualizaDetalleEntrevista(string Token, int IdDetalleEntrevista, int IdEntrevista, string Tema, string SubTema, string Semaforo, int Alerta, string FechaResolucion, string Comentarios, int Compromiso)
        {
            Parametros parametros = new Parametros
            {
                 new Parametro("@TOKEN", Token),
                 new Parametro("@ID_ENTREVISTA_DETALLE", IdDetalleEntrevista),
                 new Parametro("@ID_ENTREVISTA", IdEntrevista),
                 new Parametro("@TEMA", Tema),
                 new Parametro("@SUBTEMA", SubTema),
                 new Parametro("@SEMAFORO", Semaforo),
                 new Parametro("@ALERTA", Alerta),
                 new Parametro("@FECHA_RESOLUCION", FechaResolucion),
                 new Parametro("@COMENTARIOS", Comentarios),
                 new Parametro("@COMPROMISO", Compromiso),
            };
            return DBHelper.InstanceCRM.EjecutarProcedimiento("carteras.spMotorCartera_Actualiza_DetalleEntrevista", parametros);
        }

        public static Entity.DetalleEntrevistaEntity ObtieneDetalleEntr(int idDetalleEntrevista)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@ID_DETALLE_ENT", idDetalleEntrevista),
            };
            return DBHelper.InstanceCRM.ObtenerEntidad("carteras.spMotorCartera_Obtiene_Detalle_Ent", pram, ListaDetalleEntrevistaEmp);
        }


        private static EntrevistaEntity ListaIdEntravista(DataRow row)
        {
            return new EntrevistaEntity
            {
                IdEntrevista = row["IdEntrevista"] != DBNull.Value ? Convert.ToInt32(row["IdEntrevista"]) : 0,
            };
        }

        private static CabGestionMantencionEntity ListaIdManGestion(DataRow row)
        {
            return new CabGestionMantencionEntity
            {
                IdCabGesMantencion = row["IdCabGesMantencion"] != DBNull.Value ? Convert.ToInt32(row["IdCabGesMantencion"]) : 0,
            };
        }

        //SE CAMBIA POR NUEVO SP DE GRADO DETALLE GESTION MANTENCION
        //public static int InsertaGestionMantencion(string Token, string RutEmpresa, string Tema, string SubTema, string Tipo, string RutAfiliado, string Comentarios, int Alerta)
        //{
        //    Parametros parametros = new Parametros
        //    {
        //         new Parametro("@TOKEN", Token),
        //         new Parametro("@RUT_EMPRESA", RutEmpresa),
        //         new Parametro("@TEMA", Tema),
        //         new Parametro("@SUBTEMA", SubTema),
        //         new Parametro("@TIPO", Tipo),
        //         new Parametro("@RUT_AFILIADO", RutAfiliado),
        //         new Parametro("@COMENTARIOS", Comentarios),
        //         new Parametro("@ALERTA", Alerta),
        //    };
        //    return DBHelper.InstanceCRM.EjecutarProcedimiento("carteras.spMotorCartera_Guarda_GestionMantencion", parametros);
        //}

        public static int InsertaGestionMantencion(string Token, int IdCabGesMantencion, string RutEmpresa, string Tema, string SubTema, string RutAfiliado, string Comentarios, int Alerta)
        {
            Parametros parametros = new Parametros
            {
                 new Parametro("@TOKEN", Token),
                 new Parametro("@ID_CAB_GES_MANTENCION", IdCabGesMantencion),
                 new Parametro("@RUT_EMPRESA", RutEmpresa),
                 new Parametro("@TEMA", Tema),
                 new Parametro("@SUBTEMA", SubTema),
                 new Parametro("@RUT_AFILIADO", RutAfiliado),
                 new Parametro("@COMENTARIOS", Comentarios),
                 new Parametro("@ALERTA", Alerta),
            };
            return DBHelper.InstanceCRM.EjecutarProcedimiento("carteras.spMotorCartera_Guarda_Detalle_GestionMantencion", parametros);
        }

        public static int ModificaGestionMantencion(string Token, int IdGesMantencion, string RutEmpresa, string Tema, string SubTema, string RutAfiliado, string Comentarios)
        {
            Parametros parametros = new Parametros
            {
                 new Parametro("@TOKEN", Token),
                 new Parametro("@ID_GEST_MANTENCION", IdGesMantencion),
                 new Parametro("@RUT_EMPRESA", RutEmpresa),
                 new Parametro("@TEMA", Tema),
                 new Parametro("@SUBTEMA", SubTema),
                 new Parametro("@RUT_AFILIADO", RutAfiliado),
                 new Parametro("@COMENTARIOS", Comentarios),
            };
            return DBHelper.InstanceCRM.EjecutarProcedimiento("carteras.spMotorCartera_Actualiza_GestionMantencion", parametros);
        }


        public static int IngresaCitaAgenda(string Token, string RutEmpresa, string NombreEmpresa, string Glosa,
                                                            DateTime FechaInico, DateTime FechaFin, string HoraInicio, string HoraFin,
                                                            string Frecuencia, string Dias, string TipoVisita,
                                                            int IdAnexo, int DiasSucede)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@TOKEN", Token),
                new Parametro("@RUT_EMPRESA", RutEmpresa),
                new Parametro("@NOMBRE_EMPRESA", NombreEmpresa),
                new Parametro("@GLOSA", Glosa),
                new Parametro("@FECHA_INICO", FechaInico),
                new Parametro("@FECHA_FIN", FechaFin),
                new Parametro("@HORA_INICIO", HoraInicio),
                new Parametro("@HORA_FIN", HoraFin),
                new Parametro("@FRECUENCIA", Frecuencia),
                new Parametro("@DIAS", Dias),
                new Parametro("@TIPO_VISITA", TipoVisita),
                new Parametro("@ID_ANEXO", IdAnexo),
                new Parametro("@DIA_SUCEDE", DiasSucede),

            };
            return DBHelper.InstanceCRM.EjecutarProcedimiento("carteras.spMotorCartera_Guarda_Cita_Agenda_Empresa", parametros);
        }




        public static int IngresaCitaAgendaAgente(string Token, string RutEmpresa, string RutEjecutivo, string NombreEmpresa, string Glosa,
                                                            DateTime FechaInico, DateTime FechaFin, string HoraInicio, string HoraFin,
                                                            string Frecuencia, string Dias, string TipoVisita,
                                                            int IdAnexo, int DiasSucede)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@TOKEN", Token),
                new Parametro("@RUT_EMPRESA", RutEmpresa),
                new Parametro("@RUT_EJECUTIVO", RutEjecutivo),
                new Parametro("@NOMBRE_EMPRESA", NombreEmpresa),
                new Parametro("@GLOSA", Glosa),
                new Parametro("@FECHA_INICO", FechaInico),
                new Parametro("@FECHA_FIN", FechaFin),
                new Parametro("@HORA_INICIO", HoraInicio),
                new Parametro("@HORA_FIN", HoraFin),
                new Parametro("@FRECUENCIA", Frecuencia),
                new Parametro("@DIAS", Dias),
                new Parametro("@TIPO_VISITA", TipoVisita),
                new Parametro("@ID_ANEXO", IdAnexo),
                new Parametro("@DIA_SUCEDE", DiasSucede),

            };
            return DBHelper.InstanceCRM.EjecutarProcedimiento("carteras.spMotorCartera_Guarda_Cita_Agenda_Empresa_Agente", parametros);
        }



        public static int ActulizaCitaAgenda(string Token, int IdAgenda, string RutEmpresa, string Glosa,
                                                         DateTime FechaInico, DateTime FechaFin, string HoraInicio, string HoraFin, string TipoVisita)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@TOKEN", Token),
                new Parametro("@ID_AGENDA", IdAgenda),
               // new Parametro("@ID_REGISTRO", IdRegistro),
                new Parametro("@RUT_EMPRESA", RutEmpresa),
                new Parametro("@GLOSA", Glosa),
                new Parametro("@FECHA_INICO", FechaInico),
                new Parametro("@FECHA_FIN", FechaFin),
                new Parametro("@HORA_INICIO", HoraInicio),
                new Parametro("@HORA_FIN", HoraFin),
               // new Parametro("@FRECUENCIA", Frecuencia),
               // new Parametro("@DIAS", Dias),
                new Parametro("@TIPO_VISITA", TipoVisita),
               // new Parametro("@DIA_SUCEDE", DiasSucede),

            };
            return DBHelper.InstanceCRM.EjecutarProcedimiento("carteras.spMotorCartera_Actualiza_Cita_Agenda_Empresa", parametros);
        }

        public static int EliminaCitaAgenda(string Token, int IdAgenda, int IdRegistro, string RutEmpresa)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@TOKEN", Token),
                new Parametro("@ID_AGENDA", IdAgenda),
                new Parametro("@ID_REGISTRO", IdRegistro),
                new Parametro("@RUT_EMPRESA", RutEmpresa),
            };
            return DBHelper.InstanceCRM.EjecutarProcedimiento("carteras.spMotorCartera_Elimina_Cita_Agenda_Empresa", parametros);
        }


        public static int EliminaEmpAsignada(string Token, int IdEmpresa, string RutEmpresa)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@IdSucursalEmpresa", IdEmpresa),
                new Parametro("@RutEmpresa", RutEmpresa),
                new Parametro("@Token", Token),
            };
            return DBHelper.InstanceCRM.EjecutarProcedimiento("carteras.spMotorCartera_Elimina_Empresa", parametros);
        }

        public static int EliminaAnexoAsignada(string Token, string RutEmpresa, int IdAnexo)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@RutEmpresa", RutEmpresa),
                new Parametro("@IdEmpresaAnexo ", IdAnexo),
                new Parametro("@Token", Token),
            };
            return DBHelper.InstanceCRM.EjecutarProcedimiento("carteras.spMotorCartera_Elimina_Anexo", parametros);
        }


        private static CarteraEmpresasEntity ListaCarteraEmpresa(DataRow row)
        {
            return new CarteraEmpresasEntity
            {
                Id = row["ID"] != DBNull.Value ? Convert.ToInt32(row["ID"]) : 0,
                RutEmpresa = row["RutEmpresa"] != DBNull.Value ? row["RutEmpresa"].ToString() : string.Empty,
                NombreEmpresa = row["NombreEmpresa"] != DBNull.Value ? row["NombreEmpresa"].ToString() : string.Empty,
                Segmento = row["TipoEmpresa"] != DBNull.Value ? row["TipoEmpresa"].ToString() : string.Empty,
                IdSucursalEmpresa = row["IdSucursalEmpresa"] != DBNull.Value ? Convert.ToInt32(row["IdSucursalEmpresa"]) : 0,
                // SucursalEmpresa = row["SucursalEmpresa"] != DBNull.Value ? row["SucursalEmpresa"].ToString() : string.Empty,
                CodOficina = row["CodOficina"] != DBNull.Value ? Convert.ToInt32(row["CodOficina"]) : 0,
                NTrabajador = row["NTrabajador"] != DBNull.Value ? Convert.ToInt32(row["NTrabajador"]) : 0,
                Holding = row["Holding"] != DBNull.Value ? Convert.ToInt32(row["Holding"]) : 0,
                //Comentarios = row["Comentarios"] != DBNull.Value ? row["Comentarios"].ToString() : string.Empty,
                //FechaIngreso = row["FechaIngreso"] != DBNull.Value ? Convert.ToDateTime(row["FechaIngreso"]) : DateTime.MinValue,
                NombreHolding = row["NombreHolding"] != DBNull.Value ? row["NombreHolding"].ToString() : string.Empty,
                Tipo = row["Tipo"] != DBNull.Value ? row["Tipo"].ToString() : string.Empty,
                IdEmpresa = row["IdEmpresa"] != DBNull.Value ? Convert.ToInt32(row["IdEmpresa"]) : 0,
            };
        }



        public static List<EjecutivosOficina> ListarDotacionOficina(string token)
        {
            Parametro prm = new Parametro("@Token", token);
            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.spMotorCartera_ListaDotacionOficina", prm, EntidadDotacionOficina);
        }

        private static EjecutivosOficina EntidadDotacionOficina(DataRow row)
        {
            return new EjecutivosOficina
            {
                Rut = row["Rut"] != DBNull.Value ? row["Rut"].ToString() : string.Empty,
                Nombre = row["Nombre"] != DBNull.Value ? row["Nombre"].ToString() : string.Empty,
                Cargo = row["Cargo"] != DBNull.Value ? row["Cargo"].ToString() : string.Empty,
            };
        }

        public static List<EntrevistaEntity> ObtieneEntrevista(string Token, string RutEmpresa, int Anexo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@TOKEN", Token),
                new Parametro("@RUT_EMPRESA", RutEmpresa),
                new Parametro("@COD_ANEXO", Anexo),
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.spMotorCartera_Lista_Entrevista", pram, ListaEntrevistaEmp);
        }


        public static List<EntrevistaEntity> ObtieneVistaEntrevista(int IdEntrevista)
        {
            Parametro prm = new Parametro("@ID_ENTREVISTA", IdEntrevista);
            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.spMotorCartera_Lista_Entrevista_id", prm, ListaEntrevistaEmp);
        }

        public static List<DetalleEntrevistaEntity> ObtieneDetalleVistaEntrevista(int IdEntrevista)
        {
            Parametro prm = new Parametro("@ID_ENTREVISTA", IdEntrevista);
            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.spMotorCartera_Lista_Detalle_Entrevista", prm, ListaDetalleEntrevistaEmp);
        }

        public static List<TipologiaGestionEntity> ObtieneTipoGestion()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.spMotorCartera_Obtiene_TipologiaGestion", ListaTemaGestion);
        }

        public static List<TipologiaSubGestionEntity> ObtieneSubTemaoGestion(int IdTema)
        {
            Parametro prm = new Parametro("@ID_TEMA", IdTema);
            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.spMotorCartera_Obtiene_TipologiaSubGestion", prm, ListaSubTemaGestion);
        }


        //SE CAMBIA POR VISTA CEBECERA
        //public static List<GestionMantencionEntity> ObtenerMantencionGest(string RutEmpresa)
        //{
        //    Parametro prm = new Parametro("@RUT_EMPRESA", RutEmpresa);
        //    return DBHelper.InstanceCRM.ObtenerColeccion("carteras.spMotorCartera_Lista_MantencionGestion", prm, ListaMantGestion);
        //}

        public static List<CabGestionMantencionEntity> ObtenerMantencionGest(string Token, string RutEmpresa, int idAnexo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@TOKEN", Token),
                new Parametro("@RUT_EMPRESA", RutEmpresa),
                 new Parametro("@COD_ANEXO", idAnexo),
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.spMotorCartera_Lista_MantencionGestion_Cabecera", pram, ListaCabeceraMantGestion);
        }

        public static List<GestionMantencionEntity> ObtieneDetalleMantGestion(int IdCabGesMantencion)
        {
            Parametro prm = new Parametro("@ID_CAB_GES_MANTENCION", IdCabGesMantencion);
            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.spMotorCartera_Lista_Detalle_Mantencion_Gestion", prm, ListaMantGestionDetalle);
        }


        public static Entity.GestionMantencionEntity ObtieneDetalleMantUp(int IdGesMantencion)
        {
            Parametro prm = new Parametro("@ID_GES_MANTENCION", IdGesMantencion);
            return DBHelper.InstanceCRM.ObtenerEntidad("carteras.spMotorCartera_Lista_Detalle_Mantencion_Gestion_idGestion", prm, ListaMantGestionDetalle);

        }
        
        public static List<AfiliadoOficinaEntity> ObtieneAfiliadoSuc(string RutEmpresa)
        {
            Parametro prm = new Parametro("@RUT_EMPRESA", RutEmpresa);
            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.spMotorCartera_Lista_afiliados_empresa", prm, ListaAfiliadoSucursal);
        }

        public static List<GestionMantencionEntity> ObtenerMantencionGestHistorial(int IdGesMantencion)
        {
            Parametro prm = new Parametro("@ID_GEST_MANTENCION", IdGesMantencion);
            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.spMotorCartera_Lista_MantencionGestion_Historial", prm, ListaMantGestion);
        }

        public static CabGestionMantencionEntity ObtieneCabGestionMantenedor(int IdCabGesMantencion)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@ID_CAB_GES_MANTENCION", IdCabGesMantencion),
            };
            return DBHelper.InstanceCRM.ObtenerEntidad("carteras.spMotorCartera_Lista_Cabecera_Mantencion_Gest", pram, ListaCabeceraMantGestion);
        }


        public static List<DetalleEntrevistaEntity> ObtenerDetalleEntrevistaHistorial(int IdDetalleEntrevista)
        {
            Parametro prm = new Parametro("@ID_DETALLE_ENTREVISTA", IdDetalleEntrevista);
            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.spMotorCartera_Lista_DetalleEntrevista_Historial", prm, ListaDetalleEntrevistaEmp);
        }


        public static List<AgendaEmpresaEntity> ObtenerCitaCartera(string RutEmpresa, string RutEjecutivo, int IdAnexo, string Token)
        {
            Parametros prm = new Parametros
            {
                new Parametro("@RUT_EMPRESA", RutEmpresa),
                new Parametro("@RUT_EJECUTIVO", RutEjecutivo),
                new Parametro("@ID_ANEXO", IdAnexo),
                 new Parametro("@TOKEN", Token),
            };

            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.spMotorCartera_Lista_Cita_Agenda_Empresa_Cartera", prm, ListaCitaAgendaEmp);
        }


        public static List<AgendaEmpresaEntity> ObtenerCitaCarteraAnexo(string RutEmpresa, int IdAnexo)
        {
            Parametros prm = new Parametros
            {
                new Parametro("@RUT_EMPRESA", RutEmpresa),
                new Parametro("@ID_ANEXO", IdAnexo),
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.spMotorCartera_Lista_Cita_Agenda_Empresa_Cartera_Anexo", prm, ListaCitaAgendaEmp);
        }


        public static List<AgendaEmpresaEntity> ObtenerCitaCarteraEjecutivo(string RutEmpresa, string Token, int IdAnexo)
        {
            Parametros prm = new Parametros
            {
                new Parametro("@TOKEN", Token),
                new Parametro("@RUT_EMPRESA", RutEmpresa),
                new Parametro("@ID_ANEXO", IdAnexo),
            };

            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.spMotorCartera_Lista_Cita_Agenda_Empresa_Ejecutivo", prm, ListaCitaAgendaEmp);
        }


        private static CarteraEmpresasEntity ListaCarteraEmpresaAgente(DataRow row)
        {
            return new CarteraEmpresasEntity
            {
                Id = row["ID"] != DBNull.Value ? Convert.ToInt32(row["ID"]) : 0,
                RutEmpresa = row["RutEmpresa"] != DBNull.Value ? row["RutEmpresa"].ToString() : string.Empty,
                NombreEmpresa = row["NombreEmpresa"] != DBNull.Value ? row["NombreEmpresa"].ToString() : string.Empty,
                Segmento = row["TipoEmpresa"] != DBNull.Value ? row["TipoEmpresa"].ToString() : string.Empty,
                IdSucursalEmpresa = row["IdSucursalEmpresa"] != DBNull.Value ? Convert.ToInt32(row["IdSucursalEmpresa"]) : 0,
                CodOficina = row["CodOficina"] != DBNull.Value ? Convert.ToInt32(row["CodOficina"]) : 0,
                NTrabajador = row["NTrabajador"] != DBNull.Value ? Convert.ToInt32(row["NTrabajador"]) : 0,
                Holding = row["Holding"] != DBNull.Value ? Convert.ToInt32(row["Holding"]) : 0,
                NombreHolding = row["NombreHolding"] != DBNull.Value ? row["NombreHolding"].ToString() : string.Empty,
                Tipo = row["Tipo"] != DBNull.Value ? row["Tipo"].ToString() : string.Empty,
                // IdEmpresa = row["IdEmpresa"] != DBNull.Value ? Convert.ToInt32(row["IdEmpresa"]) : 0,
                CountAnexo = row["CountAnexo"] != DBNull.Value ? Convert.ToInt32(row["CountAnexo"]) : 0,
                CountEmp = row["CountEmp"] != DBNull.Value ? Convert.ToInt32(row["CountEmp"]) : 0,
            };
        }


        private static GestionEmpresasEntity ObDatosEmpresa(DataRow row)
        {
            return new GestionEmpresasEntity
            {
                RutEmpresa = row["RutEmpresa"] != DBNull.Value ? row["RutEmpresa"].ToString() : string.Empty,
                NombreEmpresa = row["NombreEmpresa"] != DBNull.Value ? row["NombreEmpresa"].ToString() : string.Empty,
                Segmento = row["TipoEmpresa"] != DBNull.Value ? row["TipoEmpresa"].ToString() : string.Empty,
                IdSucursalEmpresa = row["IdSucursalEmpresa"] != DBNull.Value ? Convert.ToInt32(row["IdSucursalEmpresa"]) : 0,
                //SucursalEmpresa = row["SucursalEmpresa"] != DBNull.Value ? row["SucursalEmpresa"].ToString() : string.Empty,
                CodOficina = row["CodOficina"] != DBNull.Value ? Convert.ToInt32(row["CodOficina"]) : 0,
                NTrabajador = row["NTrabajador"] != DBNull.Value ? Convert.ToInt32(row["NTrabajador"]) : 0,
                Holding = row["Holding"] != DBNull.Value ? Convert.ToInt32(row["Holding"]) : 0,
                //Comentarios = row["Comentarios"] != DBNull.Value ? row["Comentarios"].ToString() : string.Empty,
                //FechaIngreso = row["FechaIngreso"] != DBNull.Value ? Convert.ToDateTime(row["FechaIngreso"]) : DateTime.MinValue,
                NombreHolding = row["NombreHolding"] != DBNull.Value ? row["NombreHolding"].ToString() : string.Empty,
                FechaAntiguedad = row["FechaAntiguedad"] != DBNull.Value ? row["FechaAntiguedad"].ToString() : string.Empty,
                Anexo = row["Anexo"] != DBNull.Value ? row["Anexo"].ToString() : string.Empty,
                NumTrabajadores = row["NumTrabajadores"] != DBNull.Value ? Convert.ToInt32(row["NumTrabajadores"]) : 0,
            };
        }

        private static AsigandosEjecutivoEmpresaEntity AsigEjeEmpresa(DataRow row)
        {
            return new AsigandosEjecutivoEmpresaEntity
            {
                Id_Asign = row["id_Asign"] != DBNull.Value ? Convert.ToInt32(row["id_Asign"]) : 0,
                Afiliado_Rut = row["Afiliado_Rut"] != DBNull.Value ? Convert.ToInt32(row["Afiliado_Rut"]) : 0,
                Afiliado_Dv = row["Afiliado_Dv"] != DBNull.Value ? row["Afiliado_Dv"].ToString() : string.Empty,
                Nombre = row["Nombre"] != DBNull.Value ? row["Nombre"].ToString() : string.Empty,
                Apellido = row["Apellido"] != DBNull.Value ? row["Apellido"].ToString() : string.Empty,
                Email = row["Email"] != DBNull.Value ? row["Email"].ToString() : string.Empty,
                Monto_preaprobado = row["Monto_preaprobado"] != DBNull.Value ? Convert.ToInt32(row["Monto_preaprobado"]) : 0,
                Contacto = row["Contacto"] != DBNull.Value ? Convert.ToInt32(row["Contacto"]) : 0,
                PreAprobadoFinal = row["PreAprobadoFinal"] != DBNull.Value ? Convert.ToInt32(row["PreAprobadoFinal"]) : 0,
                CredVigente = row["CredVigente"] != DBNull.Value ? Convert.ToInt32(row["CredVigente"]) : 0,
                TipoAsignacion = row["TipoAsignacion"] != DBNull.Value ? Convert.ToInt32(row["TipoAsignacion"]) : 0,
                TipoCampania = row["TipoCampania"] != DBNull.Value ? row["TipoCampania"].ToString() : string.Empty,
                Prioridad = row["Prioridad"] != DBNull.Value ? Convert.ToInt32(row["Prioridad"]) : 0,
            };
        }

        private static ComunasEmpresaEntity ListaComunaEmpresa(DataRow row)
        {
            return new ComunasEmpresaEntity
            {
                IdComuna = row["COMUNA_CODIGO"] != DBNull.Value ? Convert.ToInt32(row["COMUNA_CODIGO"]) : 0,
                NombreComuna = row["COMUNA_NOMBRESIAGF"] != DBNull.Value ? row["COMUNA_NOMBRESIAGF"].ToString() : string.Empty,
            };
        }

        private static EjecutivosAsignadosEntity ListaEjecutivosAsigEmp(DataRow row)
        {
            return new EjecutivosAsignadosEntity
            {
                RutEjecutivoAsignado = row["RutEjectAsignado"] != DBNull.Value ? row["RutEjectAsignado"].ToString() : string.Empty,
            };
        }



        private static ContadorAnexoEntity ListaContAnexos(DataRow row)
        {
            return new ContadorAnexoEntity
            {
                TotalAnexos = row["TotalAnexos"] != DBNull.Value ? Convert.ToInt32(row["TotalAnexos"]) : 0,
            };
        }


        public static List<CarteraEmpresasEntity> ObtieneEmpEjecutivoAsignado(string RutEjecutivo)
        {
            Parametro prm = new Parametro("@RUT_EJECUTIVO", RutEjecutivo);
            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.spMotorCartera_Lista_Empresa_Ejecutivo", prm, ListaEmpresaEjecutivoAsig);
        }

        public static List<RegionEmpresaEntity> ObtieneRegionEmpresa()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.sp_MotorCartera_LitaRegion", ListaRegionEmp);
        }

        private static RegionEmpresaEntity ListaRegionEmp(DataRow row)
        {
            return new RegionEmpresaEntity
            {
                Region_codigo = row["REGION_CODIGOSIAGF"] != DBNull.Value ? Convert.ToInt32(row["REGION_CODIGOSIAGF"]) : 0,
                Region_nombre = row["REGION_NOMBRE"] != DBNull.Value ? row["REGION_NOMBRE"].ToString() : string.Empty,
            };
        }

        public static List<ComunaEmpresaEntity> ObtieneComunaEmpresa(int ComunaCodigo)
        {
            Parametro prm = new Parametro("@ID_REGION", ComunaCodigo);
            return DBHelper.InstanceCRM.ObtenerColeccion("carteras.sp_MotorCartera_LitaComunas", prm, ListaComunaEmp);
        }

        private static ComunaEmpresaEntity ListaComunaEmp(DataRow row)
        {
            return new ComunaEmpresaEntity
            {
                Comuna_codigo = row["COMUNA_CODIGO"] != DBNull.Value ? Convert.ToInt32(row["COMUNA_CODIGO"]) : 0,
                Comuna_nombre = row["COMUNA_NOMBRESIAGF"] != DBNull.Value ? row["COMUNA_NOMBRESIAGF"].ToString() : string.Empty,
            };
        }




        private static AnexoEmpresaEntity ListaAnexoEmp(DataRow row)
        {
            return new AnexoEmpresaEntity
            {
                IdEmpresaAnexo = row["IdEmpresaAnexo"] != DBNull.Value ? Convert.ToInt32(row["IdEmpresaAnexo"]) : 0,
                RutEmpresa = row["RutEmpresa"] != DBNull.Value ? row["RutEmpresa"].ToString() : string.Empty,
                NombreEmpresa = row["NombreEmpresa"] != DBNull.Value ? row["NombreEmpresa"].ToString() : string.Empty,
                Anexo = row["Anexo"] != DBNull.Value ? row["Anexo"].ToString() : string.Empty,
                NumTrabajadores = row["NumTrabajadores"] != DBNull.Value ? Convert.ToInt32(row["NumTrabajadores"]) : 0,
                Direccion = row["Direccion"] != DBNull.Value ? row["Direccion"].ToString() : string.Empty,
                IdComuna = row["IdComuna"] != DBNull.Value ? Convert.ToInt32(row["IdComuna"]) : 0,
                TotalAsignados = row["TotalAsignados"] != DBNull.Value ? Convert.ToInt32(row["TotalAsignados"]) : 0,
                EsMatriz = row["EsMatriz"] != DBNull.Value ? Convert.ToInt32(row["EsMatriz"]) : 0,

            };
        }

        private static EntrevistaEntity ListaEntrevistaEmp(DataRow row)
        {
            return new EntrevistaEntity
            {
                IdEntrevista = row["IdEntrevista"] != DBNull.Value ? Convert.ToInt32(row["IdEntrevista"]) : 0,
                RutEmpresa = row["RutEmpresa"] != DBNull.Value ? row["RutEmpresa"].ToString() : string.Empty,
                FechaEntrevista = row["FechaEntrevista"] != DBNull.Value ? row["FechaEntrevista"].ToString() : string.Empty,
                Tipo = row["Tipo"] != DBNull.Value ? row["Tipo"].ToString() : string.Empty,
                NombreContacto = row["NombreContacto"] != DBNull.Value ? row["NombreContacto"].ToString() : string.Empty,
                Cargo = row["Cargo"] != DBNull.Value ? row["Cargo"].ToString() : string.Empty,
                Estamento = row["Estamento"] != DBNull.Value ? row["Estamento"].ToString() : string.Empty,
                Comentarios = row["Comentarios"] != DBNull.Value ? row["Comentarios"].ToString() : string.Empty,
                RutEjeIngreso = row["RutEjeIngreso"] != DBNull.Value ? row["RutEjeIngreso"].ToString() : string.Empty,
                FechaIngreso = row["FechaIngreso"] != DBNull.Value ? Convert.ToDateTime(row["FechaIngreso"]) : DateTime.MinValue,
                NombreEjecutivo = row["NombreEjecutivo"] != DBNull.Value ? row["NombreEjecutivo"].ToString() : string.Empty,
            };
        }

        private static GestionMantencionEntity ListaMantGestion(DataRow row)
        {
            return new GestionMantencionEntity
            {
                IdGesMantencion = row["IdGesMantencion"] != DBNull.Value ? Convert.ToInt32(row["IdGesMantencion"]) : 0,
                RutEmpresa = row["RutEmpresa"] != DBNull.Value ? row["RutEmpresa"].ToString() : string.Empty,
                Tema = row["Tema"] != DBNull.Value ? row["Tema"].ToString() : string.Empty,
                SubTema = row["SubTema"] != DBNull.Value ? row["SubTema"].ToString() : string.Empty,
                //Tipo = row["Tipo"] != DBNull.Value ? row["Tipo"].ToString() : string.Empty,
                Comentarios = row["Comentarios"] != DBNull.Value ? row["Comentarios"].ToString() : string.Empty,
                RutEjeIngreso = row["RutEjeIngreso"] != DBNull.Value ? row["RutEjeIngreso"].ToString() : string.Empty,
                FechaIngreso = row["FechaIngreso"] != DBNull.Value ? Convert.ToDateTime(row["FechaIngreso"]) : DateTime.MinValue,
                NombreEjecutivo = row["NombreEjecutivo"] != DBNull.Value ? row["NombreEjecutivo"].ToString() : string.Empty,
                FlagActualizacion = row["FlagActualizacion"] != DBNull.Value ? Convert.ToInt32(row["FlagActualizacion"]) : 0,
                Alerta = row["Alerta"] != DBNull.Value ? Convert.ToInt32(row["Alerta"]) : 0,
            };
        }

        private static CabGestionMantencionEntity ListaCabeceraMantGestion(DataRow row)
        {
            return new CabGestionMantencionEntity
            {
                IdCabGesMantencion = row["IdCabGesMantencion"] != DBNull.Value ? Convert.ToInt32(row["IdCabGesMantencion"]) : 0,
                RutEmpresa = row["RutEmpresa"] != DBNull.Value ? row["RutEmpresa"].ToString() : string.Empty,
                Tipo = row["Tipo"] != DBNull.Value ? row["Tipo"].ToString() : string.Empty,
                Comentarios = row["Comentarios"] != DBNull.Value ? row["Comentarios"].ToString() : string.Empty,
                RutEjeIngreso = row["RutEjeIngreso"] != DBNull.Value ? row["RutEjeIngreso"].ToString() : string.Empty,
                FechaIngreso = row["FechaIngreso"] != DBNull.Value ? row["FechaIngreso"].ToString() : string.Empty,
                NombreEjecutivo = row["NombreEjecutivo"] != DBNull.Value ? row["NombreEjecutivo"].ToString() : string.Empty,
            };
        }



        private static GestionMantencionEntity ListaMantGestionDetalle(DataRow row)
        {
            return new GestionMantencionEntity
            {
                IdGesMantencion = row["IdGesMantencion"] != DBNull.Value ? Convert.ToInt32(row["IdGesMantencion"]) : 0,
                IdCabGesMantencion = row["IdCabGesMantencion"] != DBNull.Value ? Convert.ToInt32(row["IdCabGesMantencion"]) : 0,
                RutEmpresa = row["RutEmpresa"] != DBNull.Value ? row["RutEmpresa"].ToString() : string.Empty,
                Tema = row["Tema"] != DBNull.Value ? row["Tema"].ToString() : string.Empty,
                SubTema = row["SubTema"] != DBNull.Value ? row["SubTema"].ToString() : string.Empty,
                //Tipo = row["Tipo"] != DBNull.Value ? row["Tipo"].ToString() : string.Empty,
                Comentarios = row["Comentarios"] != DBNull.Value ? row["Comentarios"].ToString() : string.Empty,
                RutEjeIngreso = row["RutEjeIngreso"] != DBNull.Value ? row["RutEjeIngreso"].ToString() : string.Empty,
                FechaIngreso = row["FechaIngreso"] != DBNull.Value ? Convert.ToDateTime(row["FechaIngreso"]) : DateTime.MinValue,
                NombreEjecutivo = row["NombreEjecutivo"] != DBNull.Value ? row["NombreEjecutivo"].ToString() : string.Empty,
                RutAfiliado = row["RutAfiliado"] != DBNull.Value ? row["RutAfiliado"].ToString() : string.Empty,
                Alerta = row["Alerta"] != DBNull.Value ? Convert.ToInt32(row["Alerta"]) : 0,
                FlagActualizacion = row["FlagActualizacion"] != DBNull.Value ? Convert.ToInt32(row["FlagActualizacion"]) : 0,
            };
        }


        private static DetalleEntrevistaEntity ListaDetalleEntrevistaEmp(DataRow row)
        {
            return new DetalleEntrevistaEntity
            {
                IdDetalleEntrevista = row["IdDetalleEntrevista"] != DBNull.Value ? Convert.ToInt32(row["IdDetalleEntrevista"]) : 0,
                IdEntrevista = row["IdEntrevista"] != DBNull.Value ? Convert.ToInt32(row["IdEntrevista"]) : 0,
                Tema = row["Tema"] != DBNull.Value ? row["Tema"].ToString() : string.Empty,
                SubTema = row["SubTema"] != DBNull.Value ? row["SubTema"].ToString() : string.Empty,
                Semaforo = row["Semaforo"] != DBNull.Value ? row["Semaforo"].ToString() : string.Empty,
                Alerta = row["Alerta"] != DBNull.Value ? Convert.ToInt32(row["Alerta"]) : 0,
                FechaResolucion = row["FechaResolucion"] != DBNull.Value ? row["FechaResolucion"].ToString() : string.Empty,
                Comentarios = row["Comentarios"] != DBNull.Value ? row["Comentarios"].ToString() : string.Empty,
                RutEjeIngreso = row["RutEjeIngreso"] != DBNull.Value ? row["RutEjeIngreso"].ToString() : string.Empty,
                FechaIngreso = row["FechaIngreso"] != DBNull.Value ? Convert.ToDateTime(row["FechaIngreso"]) : DateTime.MinValue,
                NombreEjecutivo = row["NombreEjecutivo"] != DBNull.Value ? row["NombreEjecutivo"].ToString() : string.Empty,
                Compromiso = row["Compromiso"] != DBNull.Value ? Convert.ToInt32(row["Compromiso"]) : 0,
                FlagActualizacion = row["FlagActualizacion"] != DBNull.Value ? Convert.ToInt32(row["FlagActualizacion"]) : 0,
                IdDetalleOrigen = row["IdDetalleOrigen"] != DBNull.Value ? Convert.ToInt32(row["IdDetalleOrigen"]) : 0,
            };
        }

        private static AgendaEmpresaEntity ListaCitaAgendaEmp(DataRow row)
        {
            return new AgendaEmpresaEntity
            {
                IdAgenda = row["IdAgenda"] != DBNull.Value ? Convert.ToInt32(row["IdAgenda"]) : 0,
                IdRegistro = row["IdRegistro"] != DBNull.Value ? Convert.ToInt32(row["IdRegistro"]) : 0,
                RutEmpresa = row["RutEmpresa"] != DBNull.Value ? row["RutEmpresa"].ToString() : string.Empty,
                NombreEmpresa = row["NombreEmpresa"] != DBNull.Value ? row["NombreEmpresa"].ToString() : string.Empty,
                RutEjecutivo = row["RutEjecutivo"] != DBNull.Value ? row["RutEjecutivo"].ToString() : string.Empty,
                Glosa = row["Glosa"] != DBNull.Value ? row["Glosa"].ToString() : string.Empty,
                FechaInico = row["FechaInico"] != DBNull.Value ? Convert.ToDateTime(row["FechaInico"]) : DateTime.MinValue,
                FechaFin = row["FechaFin"] != DBNull.Value ? Convert.ToDateTime(row["FechaFin"]) : DateTime.MinValue,
                Frecuencia = row["Frecuencia"] != DBNull.Value ? row["Frecuencia"].ToString() : string.Empty,
                Dias = row["Dias"] != DBNull.Value ? row["Dias"].ToString() : string.Empty,
                DiasSucede = row["DiasSucede"] != DBNull.Value ? Convert.ToInt32(row["DiasSucede"]) : 0,
                TipoVisita = row["TipoVisita"] != DBNull.Value ? row["TipoVisita"].ToString() : string.Empty,
                IdAnexo = row["IdAnexo"] != DBNull.Value ? Convert.ToInt32(row["IdAnexo"]) : 0,
                HoraInicio = row["HoraInicio"] != DBNull.Value ? row["HoraInicio"].ToString() : string.Empty,
                HoraFin = row["HoraFin"] != DBNull.Value ? row["HoraFin"].ToString() : string.Empty,
                NCitas = row["NCitas"] != DBNull.Value ? Convert.ToInt32(row["NCitas"]) : 0,
            };
        }

        private static TipologiaGestionEntity ListaTemaGestion(DataRow row)
        {
            return new TipologiaGestionEntity
            {
                IdTema = row["IdTema"] != DBNull.Value ? Convert.ToInt32(row["IdTema"]) : 0,
                GlosaGestion = row["GlosaGestion"] != DBNull.Value ? row["GlosaGestion"].ToString() : string.Empty,
            };
        }

        private static AfiliadoOficinaEntity ListaAfiliadoSucursal(DataRow row)
        {
            return new AfiliadoOficinaEntity
            {
                RutAfiliado = row["RutAfiliado"] != DBNull.Value ? row["RutAfiliado"].ToString() : string.Empty,
                NombreAfiliado = row["NombreAfiliado"] != DBNull.Value ? row["NombreAfiliado"].ToString() : string.Empty,
            };
        }

        private static TipologiaSubGestionEntity ListaSubTemaGestion(DataRow row)
        {
            return new TipologiaSubGestionEntity
            {
                IdSubTema = row["IdSubTema"] != DBNull.Value ? Convert.ToInt32(row["IdSubTema"]) : 0,
                GlosaSubTema = row["GlosaSubTema"] != DBNull.Value ? row["GlosaSubTema"].ToString() : string.Empty,
            };
        }

        private static CarteraEmpresasEntity ListaEmpresaEjecutivoAsig(DataRow row)
        {
            return new CarteraEmpresasEntity
            {
                RutEmpresa = row["RutEmpresa"] != DBNull.Value ? row["RutEmpresa"].ToString() : string.Empty,
                NombreEmpresa = row["NombreEmpresa"] != DBNull.Value ? row["NombreEmpresa"].ToString() : string.Empty,
                IdEmpresa = row["IdEmpresa"] != DBNull.Value ? Convert.ToInt32(row["IdEmpresa"]) : 0,

            };
        }



    }
}

