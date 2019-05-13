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
    /// Clase Dominio EmpresaEntity
    /// </summary>
    /// <author>@Charly</author>
    /// <created>02-04-2018 13:02:00</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class EmpresaEntity
    {

        /// <summary>
        /// emp_id
        /// </summary>
        public int emp_id { get; set; }

        /// <summary>
        /// emp_rut
        /// </summary>
        public string emp_rut { get; set; }

        /// <summary>
        /// emp_nombre
        /// </summary>
        public string emp_nombre { get; set; }

        /// <summary>
        /// emp_holding
        /// </summary>
        public string emp_holding { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="EmpresaEntity"/>.
        /// </summary>
        public EmpresaEntity()
        {
            emp_id = 0;
            emp_rut = string.Empty;
            emp_nombre = string.Empty;
            emp_holding = string.Empty;

        }
    }
}
