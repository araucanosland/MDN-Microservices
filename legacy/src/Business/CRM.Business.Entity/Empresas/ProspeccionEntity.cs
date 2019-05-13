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
    /// Clase Dominio ProspeccionEntity
    /// </summary>
    /// <author>@Charly</author>
    /// <created>12-04-2018 14:17:01</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class ProspeccionEntity
    {

        /// <summary>
        /// pros_id
        /// </summary>
        public int pros_id { get; set; }

        /// <summary>
        /// empresa_id
        /// </summary>
        public int empresa_id { get; set; }

        /// <summary>
        /// pros_dotacion
        /// </summary>
        public int pros_dotacion { get; set; }

        /// <summary>
        /// pros_caja_origen
        /// </summary>
        public string pros_caja_origen { get; set; }

        /// <summary>
        /// ejecutivo_rut
        /// </summary>
        public string ejecutivo_rut { get; set; }

        /// <summary>
        /// oficina
        /// </summary>
        public int oficina { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ProspeccionEntity"/>.
        /// </summary>
        public ProspeccionEntity()
        {
            pros_id = 0;
            empresa_id = 0;
            pros_dotacion = 0;
            pros_caja_origen = string.Empty;
            ejecutivo_rut = string.Empty;
            oficina = 0;

        }
    }
}
