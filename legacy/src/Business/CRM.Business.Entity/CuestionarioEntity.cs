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
    /// Clase Dominio CuestionarioEntity
    /// </summary>
    /// <author>@Charly</author>
    /// <created>06-03-2018 18:00:08</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class CuestionarioEntity
    {

        /// <summary>
        /// cuest_id
        /// </summary>
        public int cuest_id { get; set; }

        /// <summary>
        /// descripcion
        /// </summary>
        public string descripcion { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CuestionarioEntity"/>.
        /// </summary>
        public CuestionarioEntity()
        {
            cuest_id = 0;
            descripcion = string.Empty;

        }
    }
}
