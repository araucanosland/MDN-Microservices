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
    /// Clase Dominio ContactoafiliadoEntity
    /// </summary>
    /// <author>@Charly</author>
    /// <created>04-05-2017 18:30:55</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class ContactoafiliadoEntity
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
        /// Tipo_contacto
        /// </summary>
        public string Tipo_contacto { get; set; }

        /// <summary>
        /// Valor_contacto
        /// </summary>
        public string Valor_contacto { get; set; }

        /// <summary>
        /// Valido
        /// </summary>
        public short Valido { get; set; }

        /// <summary>
        /// Fecha_contacto
        /// </summary>
        public DateTime Fecha_contacto { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ContactoafiliadoEntity"/>.
        /// </summary>
        public ContactoafiliadoEntity()
        {
            Afiliado_rut = 0;
            Fecha_accion = new DateTime(1900, 1, 1);
            Tipo_contacto = string.Empty;
            Valor_contacto = string.Empty;
            Valido = 0;
            Fecha_contacto = new DateTime(1900, 1, 1);
        }
    }
}
