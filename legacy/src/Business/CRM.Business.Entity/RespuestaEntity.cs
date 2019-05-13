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
    /// Clase Dominio RespuestaEntity
    /// </summary>
    /// <author>@Charly</author>
    /// <created>07-03-2018 10:58:37</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class RespuestaEntity
    {

        /// <summary>
        /// resp_id
        /// </summary>
        public int resp_id { get; set; }

        /// <summary>
        /// nuberespuesta_id
        /// </summary>
        public int nuberespuesta_id { get; set; }

        /// <summary>
        /// pregunta_id
        /// </summary>
        public int pregunta_id { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RespuestaEntity"/>.
        /// </summary>
        public RespuestaEntity()
        {
            resp_id = 0;
            nuberespuesta_id = 0;
            pregunta_id = 0;

        }
    }
}
