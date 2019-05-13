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
    /// Clase Dominio Fidelizacion
    /// </summary>
    /// <author>@Charly</author>
    /// <created>04-01-2018 14:49:57</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class Fidelizacion
    {

        /// <summary>
        /// CodFide
        /// </summary>
        public long CodFide { get; set; }

        /// <summary>
        /// RutEmpresa
        /// </summary>
        public string RutEmpresa { get; set; }

        /// <summary>
        /// NombreEmpresa
        /// </summary>
        public string NombreEmpresa { get; set; }

        /// <summary>
        /// HoldingEmpresa
        /// </summary>
        public string HoldingEmpresa { get; set; }

        /// <summary>
        /// Area
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// AmbitoAccion
        /// </summary>
        public string AmbitoAccion { get; set; }

        /// <summary>
        /// Estamento
        /// </summary>
        public string Estamento { get; set; }

        /// <summary>
        /// Actividad
        /// </summary>
        public string Actividad { get; set; }

        /// <summary>
        /// Cobertura
        /// </summary>
        public string Cobertura { get; set; }

        /// <summary>
        /// NombreRepresentanteEmpresa
        /// </summary>
        public string NombreRepresentanteEmpresa { get; set; }

        /// <summary>
        /// Cargo
        /// </summary>
        public string Cargo { get; set; }

        /// <summary>
        /// FechaIngreso
        /// </summary>
        public DateTime FechaIngreso { get; set; }

        /// <summary>
        /// FechaCreacion
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// RutEjecutivo
        /// </summary>
        public string RutEjecutivo { get; set; }

        /// <summary>
        /// Oficina
        /// </summary>
        public int Oficina { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Fidelizacion"/>.
        /// </summary>
        public Fidelizacion()
        {
            CodFide = 0;
            RutEmpresa = string.Empty;
            NombreEmpresa = string.Empty;
            HoldingEmpresa = string.Empty;
            Area = string.Empty;
            AmbitoAccion = string.Empty;
            Estamento = string.Empty;
            Actividad = string.Empty;
            Cobertura = string.Empty;
            NombreRepresentanteEmpresa = string.Empty;
            Cargo = string.Empty;
            FechaIngreso = new DateTime(1900, 1, 1);
            FechaCreacion = new DateTime(1900, 1, 1);
            RutEjecutivo = string.Empty;
            Oficina = 0;

        }
    }
}