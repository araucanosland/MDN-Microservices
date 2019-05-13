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
    /// Clase Dominio PreferenciaAfiliadoEntity
    /// </summary>
    /// <author>Charly</author>
    /// <created>29-05-2017 17:48:28</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class PreferenciaAfiliadoEntity
    {

        /// <summary>
        /// Afiliado_rut
        /// </summary>
        public int Afiliado_rut { get; set; }

        /// <summary>
        /// Fecha_accion
        /// </summary>
        public DateTime Fecha_accion { get; set; }

        /// <summary>
        /// Tipo_preferencia
        /// </summary>
        public string Tipo_preferencia { get; set; }

        /// <summary>
        /// Valor_preferencia
        /// </summary>
        public string Valor_preferencia { get; set; }

        /// <summary>
        /// Valida
        /// </summary>
        public bool Valida { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PreferenciaAfiliadoEntity"/>.
        /// </summary>
        public PreferenciaAfiliadoEntity()
        {
            Afiliado_rut = 0;
            Fecha_accion = new DateTime(1900, 1, 1);
            Tipo_preferencia = string.Empty;
            Valor_preferencia = string.Empty;
            Valida = false;

        }
    }
}
