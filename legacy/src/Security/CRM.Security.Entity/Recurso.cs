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
    /// Clase Dominio Recurso
    /// </summary>
    /// <author>@Charly</author>
    /// <created>12-09-2017 18:07:47</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class Recurso
    {

        /// <summary>
        /// CodRecurso
        /// </summary>
        public int CodRecurso { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Recurso"/>.
        /// </summary>
        public Recurso()
        {
            CodRecurso = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;

        }
    }
}
