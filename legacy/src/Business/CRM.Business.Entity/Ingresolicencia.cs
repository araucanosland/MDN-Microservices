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
    /// Clase Dominio Ingresolicencia
    /// </summary>
    /// <author>@Charly</author>
    /// <created>28-09-2017 16:33:09</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class Ingresolicencia
    {

        /// <summary>
        /// CodIngreso
        /// </summary>
        public long CodIngreso { get; set; }

        /// <summary>
        /// RutAfiliado
        /// </summary>
        public string RutAfiliado { get; set; }

        /// <summary>
        /// NombreAfiliado 
        /// </summary>
        public string NombreAfiliado { get; set; }


        /// <summary>
        /// SinDatosEnSistema 
        /// </summary>
        public bool SinDatosEnSistema { get; set; }



        /// <summary>
        /// FolioLicencia
        /// </summary>
        public string FolioLicencia { get; set; }

        /// <summary>
        /// Oficina
        /// </summary>
        public int Oficina { get; set; }

        /// <summary>
        /// RutEjecutivo
        /// </summary>
        public string RutEjecutivo { get; set; }

        /// <summary>
        /// CodEstado
        /// </summary>
        public int CodEstado { get; set; }

        /// <summary>
        /// FechaIngreso
        /// </summary>
        public DateTime FechaIngreso { get; set; }


        /// <summary>
        /// CantidadDiasLM
        /// </summary>
        public int? CantidadDiasLM { get; set; }

        /// <summary>
        /// FechaInicioLM
        /// </summary>
        public DateTime? FechaInicioLM { get; set; }

        // <summary>
        /// FechaHastaLM
        /// </summary>
        public DateTime? FechaHastaLM { get; set; }

        /// <summary>
        /// TipoLM
        /// </summary>
        public int? TipoLM { get; set; }
        public string FormatoLM { get; set; }
        public string FlagLM { get; set; }
        public int Lm_Total { get; set; }
        public int Lm_Verde { get; set; }
        public int Lm_Amarillo { get; set; }
        public int Lm_Rojo { get; set; }
        public int Lm_Naranjo { get; set; }
        public string Lm_Actualizacion { get; set; }

        public bool Editable { get; set; }
        public int OficinaDerivacion { get; set; }
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Ingresolicencia"/>.
        /// </summary>
        public Ingresolicencia()
        {
            CodIngreso = 0;
            RutAfiliado = string.Empty;
            NombreAfiliado = string.Empty;
            FolioLicencia = string.Empty;
            Oficina = 0;
            RutEjecutivo = string.Empty;
            CodEstado = 0;
            FechaIngreso = new DateTime(1900, 1, 1);
            CantidadDiasLM = null;
            FechaInicioLM = null;
            FechaHastaLM = null;
            TipoLM = null;
            FormatoLM = string.Empty;
            Editable = true;

            FlagLM = string.Empty;
            OficinaDerivacion = 0;
        }
    }
}
