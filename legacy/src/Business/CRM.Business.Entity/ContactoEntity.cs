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
    /// Clase Dominio ContactoEntity
    /// </summary>
    /// <author>@Charly</author>
    /// <created>06-03-2018 17:56:31</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class ContactoEntity
    {

        /// <summary>
        /// cnt_id
        /// </summary>
        public int cnt_id { get; set; }

        /// <summary>
        /// pregunta_id
        /// </summary>
        public int encabezado_id { get; set; }

        /// <summary>
        /// nombre
        /// </summary>
        public string nombre { get; set; }

        /// <summary>
        /// telefono
        /// </summary>
        public int telefono { get; set; }

        /// <summary>
        /// email
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// direccion
        /// </summary>
        public string direccion { get; set; }

        /// <summary>
        /// compromisos
        /// </summary>
        public string compromisos { get; set; }

        /// <summary>
        /// Tipo
        /// </summary>
        public string tipo { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ContactoEntity"/>.
        /// </summary>
        public ContactoEntity()
        {
            cnt_id = 0;
            encabezado_id = 0;
            nombre = string.Empty;
            telefono = 0;
            email = string.Empty;
            direccion = string.Empty;
            compromisos = string.Empty;
            tipo = string.Empty;

        }
    }
}
