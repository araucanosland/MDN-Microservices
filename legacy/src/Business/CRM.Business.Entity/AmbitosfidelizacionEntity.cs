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
    /// Clase Dominio AmbitosfidelizacionEntity
    /// </summary>
    /// <author>@Charly</author>
    /// <created>02-04-2018 12:59:44</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class AmbitosfidelizacionEntity
    {

        /// <summary>
        /// afid_id
        /// </summary>
        public int afid_id { get; set; }

        /// <summary>
        /// ambito_id
        /// </summary>
        public int ambito_id { get; set; }

        /// <summary>
        /// fidelizacion_id
        /// </summary>
        public int fidelizacion_id { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AmbitosfidelizacionEntity"/>.
        /// </summary>
        public AmbitosfidelizacionEntity()
        {
            afid_id = 0;
            ambito_id = 0;
            fidelizacion_id = 0;

        }
    }
}
