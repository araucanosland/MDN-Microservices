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
    /// Clase Dominio DesarrolloEntity
    /// </summary>
    /// <author>@Charly</author>
    /// <created>07-03-2018 10:30:09</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class DesarrolloEntity
    {

        /// <summary>
        /// desa_id
        /// </summary>
        public long desa_id { get; set; }

        /// <summary>
        /// encabezado_id
        /// </summary>
        public int encabezado_id { get; set; }

        /// <summary>
        /// respuesta_id
        /// </summary>
        public int respuesta_id { get; set; }

        /// <summary>
        /// texto
        /// </summary>
        public string texto { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="DesarrolloEntity"/>.
        /// </summary>
        public DesarrolloEntity()
        {
            desa_id = 0;
            encabezado_id = 0;
            respuesta_id = 0;
            texto = string.Empty;

        }
    }
}
