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
    /// Clase Dominio RetencionEntity
    /// </summary>
    /// <author>@Charly</author>
    /// <created>10-04-2018 18:05:44</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class RetencionEntity
    {

        /// <summary>
        /// ret_id
        /// </summary>
        public int ret_id { get; set; }

        /// <summary>
        /// empresa_id
        /// </summary>
        public int empresa_id { get; set; }

        /// <summary>
        /// ret_estamento
        /// </summary>
        public string ret_estamento { get; set; }

        /// <summary>
        /// ret_segmento
        /// </summary>
        public string ret_segmento { get; set; }

        /// <summary>
        /// ret_dotacion
        /// </summary>
        public int ret_dotacion { get; set; }

        /// <summary>
        /// ret_caja_destino
        /// </summary>
        public string ret_caja_destino { get; set; }


        // <summary>
        /// ejecutivo_rut
        /// </summary>
        public string ejecutivo_rut { get; set; }

        /// <summary>
        /// oficina
        /// </summary>
        public int oficina { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RetencionEntity"/>.
        /// </summary>
        public RetencionEntity()
        {
            ret_id = 0;
            empresa_id = 0;
            ret_estamento = string.Empty;
            ret_segmento = string.Empty;
            ret_dotacion = 0;
            ret_caja_destino = string.Empty;
            ejecutivo_rut = string.Empty;
            oficina = 0;
        }
    }
}
