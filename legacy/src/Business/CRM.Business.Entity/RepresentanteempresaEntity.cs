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
    /// Clase Dominio RepresentanteempresaEntity
    /// </summary>
    /// <author>@Charly</author>
    /// <created>02-04-2018 13:08:32</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class RepresentanteempresaEntity
    {

        /// <summary>
        /// rep_id
        /// </summary>
        public int rep_id { get; set; }

        /// <summary>
        /// rep_nombre
        /// </summary>
        public string rep_nombre { get; set; }

        /// <summary>
        /// rep_cargo
        /// </summary>
        public string rep_cargo { get; set; }

        /// <summary>
        /// emp_id
        /// </summary>
        public int emp_id { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RepresentanteempresaEntity"/>.
        /// </summary>
        public RepresentanteempresaEntity()
        {
            rep_id = 0;
            rep_nombre = string.Empty;
            rep_cargo = string.Empty;
            emp_id = 0;

        }
    }
}
