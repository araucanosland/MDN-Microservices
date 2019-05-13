using System;

//------------------------------------------------------------------------------
// <generado automáticamente>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </generado automáticamente>
//------------------------------------------------------------------------------

namespace CRM.Business.Entity.Empresas
{
    /// <summary>
    /// Clase Dominio AmbitosretencionEntity
    /// </summary>
    /// <author>@Charly</author>
    /// <created>10-04-2018 18:00:15</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class AmbitosretencionEntity
    {

        /// <summary>
        /// aret_id
        /// </summary>
        public int aret_id { get; set; }

        /// <summary>
        /// ambito_id
        /// </summary>
        public int ambito_id { get; set; }

        /// <summary>
        /// retencion_id
        /// </summary>
        public int retencion_id { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AmbitosretencionEntity"/>.
        /// </summary>
        public AmbitosretencionEntity()
        {
            aret_id = 0;
            ambito_id = 0;
            retencion_id = 0;

        }
    }
}
