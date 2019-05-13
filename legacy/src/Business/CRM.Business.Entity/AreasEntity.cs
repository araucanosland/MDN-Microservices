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
    /// Clase Dominio AreasEntity
    /// </summary>
    /// <author>@Charly</author>
    /// <created>02-04-2018 13:00:45</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class AreasEntity
    {

        /// <summary>
        /// area_id
        /// </summary>
        public int area_id { get; set; }

        /// <summary>
        /// area_nombre
        /// </summary>
        public string area_nombre { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AreasEntity"/>.
        /// </summary>
        public AreasEntity()
        {
            area_id = 0;
            area_nombre = string.Empty;

        }
    }
}
