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
    /// Clase Dominio GestionprospeccionEntity
    /// </summary>
    /// <author>@Charly</author>
    /// <created>12-04-2018 14:18:08</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class GestionprospeccionEntity
    {

        /// <summary>
        /// gstp_id
        /// </summary>
        public int gstp_id { get; set; }

        /// <summary>
        /// gstp_fecha
        /// </summary>
        public DateTime gstp_fecha { get; set; }

        /// <summary>
        /// gstp_etapa
        /// </summary>
        public string gstp_etapa { get; set; }

        /// <summary>
        /// gstp_observaciones
        /// </summary>
        public string gstp_observaciones { get; set; }

        /// <summary>
        /// gstp_fecha_accion
        /// </summary>
        public DateTime gstp_fecha_accion { get; set; }

        /// <summary>
        /// prospecto_id
        /// </summary>
        public int prospecto_id { get; set; }

        /// <summary>
        /// ejecutivo_rut
        /// </summary>
        public string ejecutivo_rut { get; set; }

        /// <summary>
        /// oficina
        /// </summary>
        public int oficina { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GestionprospeccionEntity"/>.
        /// </summary>
        public GestionprospeccionEntity()
        {
            gstp_id = 0;
            gstp_fecha = new DateTime(1900, 1, 1);
            gstp_etapa = string.Empty;
            gstp_observaciones = string.Empty;
            gstp_fecha_accion = new DateTime(1900, 1, 1);
            prospecto_id = 0;
            ejecutivo_rut = string.Empty;
            oficina = 0;

        }
    }
}
