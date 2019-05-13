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
    /// Clase Dominio GestionretencionEntity
    /// </summary>
    /// <author>@Charly</author>
    /// <created>10-04-2018 18:03:59</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class GestionretencionEntity
    {

        /// <summary>
        /// gstr_id
        /// </summary>
        public int gstr_id { get; set; }

        /// <summary>
        /// gstr_fecha
        /// </summary>
        public DateTime gstr_fecha { get; set; }

        /// <summary>
        /// gstr_etapa
        /// </summary>
        public string gstr_etapa { get; set; }

        /// <summary>
        /// gstr_observaciones
        /// </summary>
        public string gstr_observaciones { get; set; }

        /// <summary>
        /// gstr_fecha_accion
        /// </summary>
        public DateTime gstr_fecha_accion { get; set; }

        /// <summary>
        /// retencion_id
        /// </summary>
        public int retencion_id { get; set; }

        /// <summary>
        /// ejecutivo_rut
        /// </summary>
        public string ejecutivo_rut { get; set; }

        /// <summary>
        /// oficina
        /// </summary>
        public int oficina { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GestionretencionEntity"/>.
        /// </summary>
        public GestionretencionEntity()
        {
            gstr_id = 0;
            gstr_fecha = new DateTime(1900, 1, 1);
            gstr_etapa = string.Empty;
            gstr_observaciones = string.Empty;
            gstr_fecha_accion = new DateTime(1900, 1, 1);
            retencion_id = 0;
            ejecutivo_rut = string.Empty;
            oficina = 0;

        }
    }
}
