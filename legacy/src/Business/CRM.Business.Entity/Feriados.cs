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
    /// Clase Dominio Feriados
    /// </summary>
    /// <author>@Charly</author>
    /// <created>28-08-2017 13:14:01</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class Feriados
    {

        /// <summary>
        /// Fecha
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Feriados"/>.
        /// </summary>
        public Feriados()
        {
            Fecha = new DateTime(1900, 1, 1);
            Descripcion = string.Empty;

        }
    }
}
