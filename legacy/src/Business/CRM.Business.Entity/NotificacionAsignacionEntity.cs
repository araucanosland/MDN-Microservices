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
    /// Clase Dominio NotificacionAsignacionEntity
    /// </summary>
    /// <author>@Charly</author>
    /// <created>16-05-2017 16:40:39</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class NotificacionAsignacionEntity
    {

        /// <summary>
        /// AfiliadoRut
        /// </summary>
        public string AfiliadoRut { get; set; }

        /// <summary>
        /// Tipo
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        public string Valor { get; set; }


        /// <summary>
        /// Cantidad
        /// </summary>
        public int Cantidad { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="NotificacionAsignacionEntity"/>.
        /// </summary>
        public NotificacionAsignacionEntity()
        {
            AfiliadoRut = string.Empty;
            Tipo = string.Empty;
            Valor = string.Empty;
            Cantidad = 0;

        }
    }
}
