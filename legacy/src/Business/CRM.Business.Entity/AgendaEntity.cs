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
    /// Clase Dominio AgendaEntity
    /// </summary>
    /// <author>@Charly</author>
    /// <created>15-03-2018 10:05:12</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class AgendaEntity
    {

        /// <summary>
        /// age_id
        /// </summary>
        public int age_id { get; set; }

        /// <summary>
        /// encabezado_id
        /// </summary>
        public int encabezado_id { get; set; }

        /// <summary>
        /// fecha
        /// </summary>
        public DateTime fecha { get; set; }

        /// <summary>
        /// estamento
        /// </summary>
        public string estamento { get; set; }

        /// <summary>
        /// nombre_funcionario
        /// </summary>
        public string nombre_funcionario { get; set; }

        /// <summary>
        /// cargo_funcionario
        /// </summary>
        public string cargo_funcionario { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AgendaEntity"/>.
        /// </summary>
        public AgendaEntity()
        {
            age_id = 0;
            encabezado_id = 0;
            fecha = new DateTime(1900, 1, 1);
            estamento = string.Empty;
            nombre_funcionario = string.Empty;
            cargo_funcionario = string.Empty;

        }
    }
}
