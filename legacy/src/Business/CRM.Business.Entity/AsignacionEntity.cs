using System;
//------------------------------------------------------------------------------
// <generado automáticamente>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </generado automáticamente>
//------------------------------------------------------------------------------

namespace CRM.Business.Entity
{
    /// <summary>
    /// Clase Dominio Asignacion
    /// </summary>
    /// <author>Carlos Pradenas</author>
    /// <created>11-04-2017 17:24:37</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class AsignacionEntity 
    {

        /// <summary>
        /// id_Asign
        /// </summary>
        public int id_Asign { get; set; }

        /// <summary>
        /// Periodo
        /// </summary>
        public string Periodo { get; set; }

        /// <summary>
        /// Afiliado_Rut
        /// </summary>
        public decimal Afiliado_Rut { get; set; }

        /// <summary>
        /// Afiliado_Dv
        /// </summary>
        public string Afiliado_Dv { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido
        /// </summary>
        public string Apellido { get; set; }

        /// <summary>
        /// Empresa_Rut
        /// </summary>
        public string Empresa_Rut { get; set; }

        /// <summary>
        /// Empresa_Dv
        /// </summary>
        public string Empresa_Dv { get; set; }

        /// <summary>
        /// Empresa
        /// </summary>
        public string Empresa { get; set; }

        /// <summary>
        /// ClaRiesgoEmpresa
        /// </summary>
        public string ClaRiesgoEmpresa { get; set; }

        /// <summary>
        /// Holding
        /// </summary>
        public string Holding { get; set; }

        /// <summary>
        /// Celular
        /// </summary>
        public string Celular { get; set; }

        /// <summary>
        /// Telefono1
        /// </summary>
        public string Telefono1 { get; set; }

        /// <summary>
        /// Telefono2
        /// </summary>
        public string Telefono2 { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// MontoPension
        /// </summary>
        public decimal MontoPension { get; set; }

        /// <summary>
        /// MontoRenta
        /// </summary>
        public int MontoRenta { get; set; }

        /// <summary>
        /// Monto_preaprobado
        /// </summary>
        public int Monto_preaprobado { get; set; }

        /// <summary>
        /// Antiguedad_en_Meses
        /// </summary>
        public int Antiguedad_en_Meses { get; set; }

        /// <summary>
        /// LicMedicaVigente
        /// </summary>
        public int LicMedicaVigente { get; set; }

        /// <summary>
        /// CreditosVigentes
        /// </summary>
        public int CreditosVigentes { get; set; }

        /// <summary>
        /// CredVig_Meses_Morosos
        /// </summary>
        public int CredVig_Meses_Morosos { get; set; }

        /// <summary>
        /// CredVig_MontoCuota
        /// </summary>
        public int CredVig_MontoCuota { get; set; }

        /// <summary>
        /// EsPensionado
        /// </summary>
        public int EsPensionado { get; set; }

        /// <summary>
        /// EsPrivado
        /// </summary>
        public int EsPrivado { get; set; }

        /// <summary>
        /// EsPublico
        /// </summary>
        public int EsPublico { get; set; }

        /// <summary>
        /// Contacto
        /// </summary>
        public int Contacto { get; set; }

        /// <summary>
        /// Segmento
        /// </summary>
        public string Segmento { get; set; }

        /// <summary>
        /// FechaNacimiento
        /// </summary>
        public DateTime FechaNacimiento { get; set; }

        /// <summary>
        /// Edad
        /// </summary>
        public int Edad { get; set; }

        /// <summary>
        /// PensionadoFFAA
        /// </summary>
        public int PensionadoFFAA { get; set; }

        /// <summary>
        /// EmpresaEsPensionado
        /// </summary>
        public int EmpresaEsPensionado { get; set; }

        /// <summary>
        /// EmpresaEsPublico
        /// </summary>
        public int EmpresaEsPublico { get; set; }

        /// <summary>
        /// EmpresaEsPrivado
        /// </summary>
        public int EmpresaEsPrivado { get; set; }

        /// <summary>
        /// RiesgoPerfil
        /// </summary>
        public string RiesgoPerfil { get; set; }

        /// <summary>
        /// RiesgoMaxVecesRenta
        /// </summary>
        public long RiesgoMaxVecesRenta { get; set; }

        /// <summary>
        /// RiesgoMaxPreAprobado
        /// </summary>
        public long RiesgoMaxPreAprobado { get; set; }

        /// <summary>
        /// PreAprobadoFinal
        /// </summary>
        public long PreAprobadoFinal { get; set; }

        /// <summary>
        /// CredVigente
        /// </summary>
        public int CredVigente { get; set; }

        /// <summary>
        /// Oficina
        /// </summary>
        public int Oficina { get; set; }

        /// <summary>
        /// Asignado
        /// </summary>
        public int Asignado { get; set; }

        /// <summary>
        /// Ejec_Asignacion
        /// </summary>
        public string Ejec_Asignacion { get; set; }

        /// <summary>
        /// TipoAsignacion
        /// </summary>
        public int TipoAsignacion { get; set; }

        /// <summary>
        /// Prioridad
        /// </summary>
        public int Prioridad { get; set; }

        /// <summary>
        /// TipoCampania
        /// </summary>
        public string TipoCampania { get; set; }

        /// <summary>
        /// Cuadrante
        /// </summary>
        public int Cuadrante { get; set; }


        /// <summary>
        /// OfertaTexto
        /// </summary>
        public string OfertaTexto { get; set; }


        /// <summary>
        /// OfertaTexto
        /// </summary>
        public string TipoDerivacion { get; set; }



        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AsignacionEntity"/>.
        /// </summary>
        public AsignacionEntity()
        {
            id_Asign = 0;
            Periodo = string.Empty;
            Afiliado_Rut = 0;
            Afiliado_Dv = string.Empty;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Empresa_Rut = string.Empty;
            Empresa_Dv = string.Empty;
            Empresa = string.Empty;
            ClaRiesgoEmpresa = string.Empty;
            Holding = string.Empty;
            Celular = string.Empty;
            Telefono1 = string.Empty;
            Telefono2 = string.Empty;
            Email = string.Empty;
            MontoPension = 0;
            MontoRenta = 0;
            Monto_preaprobado = 0;
            Antiguedad_en_Meses = 0;
            LicMedicaVigente = 0;
            CreditosVigentes = 0;
            CredVig_Meses_Morosos = 0;
            CredVig_MontoCuota = 0;
            EsPensionado = 0;
            EsPrivado = 0;
            EsPublico = 0;
            Contacto = 0;
            Segmento = string.Empty;
            FechaNacimiento = new DateTime(1900, 1, 1);
            Edad = 0;
            PensionadoFFAA = 0;
            EmpresaEsPensionado = 0;
            EmpresaEsPublico = 0;
            EmpresaEsPrivado = 0;
            RiesgoPerfil = string.Empty;
            RiesgoMaxVecesRenta = 0;
            RiesgoMaxPreAprobado = 0;
            PreAprobadoFinal = 0;
            CredVigente = 0;
            Oficina = 0;
            Asignado = 0;
            Ejec_Asignacion = string.Empty;
            TipoAsignacion = 0;
            Prioridad = 0;
            TipoCampania = string.Empty;
            Cuadrante = 0;
            OfertaTexto = string.Empty;
            TipoDerivacion = string.Empty;

        }
    }
}
