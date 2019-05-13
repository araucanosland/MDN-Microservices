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
    /// Clase Dominio ResultadogestionEntity
    /// </summary>
    /// <author>@Charly</author>
    /// <created>02-04-2018 13:09:37</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class ResultadogestionEntity
    {

        /// <summary>
        /// resg_id
        /// </summary>
        public int resg_id { get; set; }

        /// <summary>
        /// resg_tipo
        /// </summary>
        public string resg_tipo { get; set; }

        /// <summary>
        /// resg_comentarios
        /// </summary>
        public string resg_comentarios { get; set; }

        /// <summary>
        /// resg_fecha
        /// </summary>
        public DateTime resg_fecha { get; set; }

        /// <summary>
        /// fidelizacion_id
        /// </summary>
        public int fidelizacion_id { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ResultadogestionEntity"/>.
        /// </summary>
        public ResultadogestionEntity()
        {
            resg_id = 0;
            resg_tipo = string.Empty;
            resg_comentarios = string.Empty;
            resg_fecha = new DateTime(1900, 1, 1);
            fidelizacion_id = 0;

        }
    }
}
