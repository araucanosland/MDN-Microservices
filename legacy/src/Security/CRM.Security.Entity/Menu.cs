using System;

//------------------------------------------------------------------------------
// <generado automáticamente>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </generado automáticamente>
//------------------------------------------------------------------------------

namespace CRM.Security.Entity
{
    /// <summary>
    /// Clase Dominio Menu
    /// </summary>
    /// <author>@Charly</author>
    /// <created>14-09-2017 11:30:00</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class Menu
    {

        /// <summary>
        /// CodMenu
        /// </summary>
        public int CodMenu { get; set; }

        /// <summary>
        /// CodRecurso
        /// </summary>
        public int CodRecurso { get; set; }

        /// <summary>
        /// CodMenuPadre
        /// </summary>
        public int CodMenuPadre { get; set; }

        /// <summary>
        /// Enlace
        /// </summary>
        public string Enlace { get; set; }

        /// <summary>
        /// Icono
        /// </summary>
        public string Icono { get; set; }


        /// <summary>
        /// Orden
        /// </summary>
        public int Orden { get; set; }


        /// <summary>
        /// CodCategoria
        /// </summary>
        public int CodCategoria { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Menu"/>.
        /// </summary>
        public Menu()
        {
            CodMenu = 0;
            CodRecurso = 0;
            CodMenuPadre = 0;
            Enlace = string.Empty;
            Icono = string.Empty;
            Orden = 0;
            CodCategoria = 0;

        }
    }
}
