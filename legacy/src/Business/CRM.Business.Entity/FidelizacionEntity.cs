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
    /// Clase Dominio FidelizacionEntity
    /// </summary>
    /// <author>@Charly</author>
    /// <created>02-04-2018 13:05:53</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class FidelizacionEntity
    {

        /// <summary>
        /// fide_id
        /// </summary>
        public int fide_id { get; set; }

        /// <summary>
        /// fide_estamento
        /// </summary>
        public string fide_estamento { get; set; }

        /// <summary>
        /// fide_actividad
        /// </summary>
        public string fide_actividad { get; set; }

        /// <summary>
        /// fide_cobertura
        /// </summary>
        public string fide_cobertura { get; set; }

        /// <summary>
        /// fide_fecha_calendario
        /// </summary>
        public DateTime fide_fecha_calendario { get; set; }

        /// <summary>
        /// fide_fecha_accion
        /// </summary>
        public DateTime fide_fecha_accion { get; set; }

        /// <summary>
        /// representante_id
        /// </summary>
        public int representante_id { get; set; }

        /// <summary>
        /// cod_oficina
        /// </summary>
        public int cod_oficina { get; set; }

        /// <summary>
        /// rut_ejecutivo
        /// </summary>
        public string rut_ejecutivo { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FidelizacionEntity"/>.
        /// </summary>
        public FidelizacionEntity()
        {
            fide_id = 0;
            fide_estamento = string.Empty;
            fide_actividad = string.Empty;
            fide_cobertura = string.Empty;
            fide_fecha_calendario = new DateTime(1900, 1, 1);
            fide_fecha_accion = new DateTime(1900, 1, 1);
            representante_id = 0;
            cod_oficina = 0;
            rut_ejecutivo = string.Empty;

        }
    }
}
