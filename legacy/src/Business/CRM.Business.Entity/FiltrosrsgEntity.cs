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
    /// Clase Dominio FiltrosrsgEntity
    /// </summary>
    /// <author>@Charly</author>
    /// <created>31-08-2017 11:25:06</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class FiltrosrsgEntity
    {

        /// <summary>
        /// Periodo
        /// </summary>
        public int Periodo { get; set; }

        /// <summary>
        /// AfiliadoRut
        /// </summary>
        public string AfiliadoRut { get; set; }

        /// <summary>
        /// EmpresaRut
        /// </summary>
        public string EmpresaRut { get; set; }

        /// <summary>
        /// Filtros
        /// </summary>
        public string Filtros { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FiltrosrsgEntity"/>.
        /// </summary>
        public FiltrosrsgEntity()
        {
            Periodo = 0;
            AfiliadoRut = string.Empty;
            EmpresaRut = string.Empty;
            Filtros = string.Empty;

        }
    }
}
