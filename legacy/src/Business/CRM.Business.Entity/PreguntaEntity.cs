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
    /// Clase Dominio PreguntaEntity
    /// </summary>
    /// <author>@Charly</author>
    /// <created>07-03-2018 10:57:19</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class PreguntaEntity
    {

        /// <summary>
        /// preg_id
        /// </summary>
        public int preg_id { get; set; }

        /// <summary>
        /// cuestionario_id
        /// </summary>
        public int cuestionario_id { get; set; }

        /// <summary>
        /// titulo
        /// </summary>
        public string titulo { get; set; }

        /// <summary>
        /// item
        /// </summary>
        public string item { get; set; }

        /// <summary>
        /// pregunta_relacionada
        /// </summary>
        public int pregunta_relacionada { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PreguntaEntity"/>.
        /// </summary>
        public PreguntaEntity()
        {
            preg_id = 0;
            cuestionario_id = 0;
            titulo = string.Empty;
            item = string.Empty;
            pregunta_relacionada = 0;

        }
    }
}
