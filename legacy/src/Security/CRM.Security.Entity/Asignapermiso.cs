using System;

//------------------------------------------------------------------------------
// <generado automáticamente>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </generado automáticamente>
//------------------------------------------------------------------------------

namespace CRM.Security.Entity
{
    /// <summary>
    /// Clase Dominio Asignapermiso
    /// </summary>
    /// <author>@Charly</author>
    /// <created>14-09-2017 11:17:00</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class Asignapermiso
    {

        /// <summary>
        /// CodPermiso
        /// </summary>
        public int CodPermiso { get; set; }

        /// <summary>
        /// Grupo
        /// </summary>
        public string Grupo { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Asignapermiso"/>.
        /// </summary>
        public Asignapermiso()
        {
            CodPermiso = 0;
            Grupo = string.Empty;

        }
    }
}
