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
    /// Clase Dominio NoticiaEntity
    /// </summary>
    /// <author>Charly</author>
    /// <created>12-06-2017 10:14:41</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class NoticiaEntity
    {

        /// <summary>
        /// noti_id
        /// </summary>
        public int noti_id { get; set; }

        /// <summary>
        /// noti_titulo
        /// </summary>
        public string noti_titulo { get; set; }

        /// <summary>
        /// noti_cuerpo
        /// </summary>
        public string noti_cuerpo { get; set; }

        /// <summary>
        /// noti_cerrable
        /// </summary>
        public int noti_cerrable { get; set; }

        /// <summary>
        /// noti_fecha
        /// </summary>
        public DateTime noti_fecha { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="NoticiaEntity"/>.
        /// </summary>
        public NoticiaEntity()
        {
            noti_id = 0;
            noti_titulo = string.Empty;
            noti_cuerpo = string.Empty;
            noti_cerrable = 0;
            noti_fecha = new DateTime(1900, 1, 1);

        }
    }
}
