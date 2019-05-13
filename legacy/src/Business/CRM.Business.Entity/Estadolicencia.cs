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
    /// Clase Dominio Estadolicencia
    /// </summary>
    /// <author>@Charly</author>
    /// <created>28-09-2017 16:23:13</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class Estadolicencia
    {

        /// <summary>
        /// CodEstado
        /// </summary>
        public int CodEstado { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Estadolicencia"/>.
        /// </summary>
        public Estadolicencia()
        {
            CodEstado = 0;
            Nombre = string.Empty;

        }
    }
}
