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
    /// Clase Dominio NuberespuestasEntity
    /// </summary>
    /// <author>@Charly</author>
    /// <created>07-03-2018 10:56:31</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class NuberespuestasEntity
    {

        /// <summary>
        /// nresp_id
        /// </summary>
        public int nresp_id { get; set; }

        /// <summary>
        /// despriccion
        /// </summary>
        public string despriccion { get; set; }

        /// <summary>
        /// valor
        /// </summary>
        public string valor { get; set; }

        /// <summary>
        /// tag
        /// </summary>
        public string tag { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="NuberespuestasEntity"/>.
        /// </summary>
        public NuberespuestasEntity()
        {
            nresp_id = 0;
            despriccion = string.Empty;
            valor = string.Empty;
            tag = string.Empty;

        }
    }
}
