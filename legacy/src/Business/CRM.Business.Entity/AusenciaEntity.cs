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
    /// Clase Dominio AusenciaEntity
    /// </summary>
    /// <author>Carlos Pradenas</author>
    /// <created>27-06-2017 23:58:23</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class AusenciaEntity
    {

        /// <summary>
        /// aus_id
        /// </summary>
        public int aus_id { get; set; }

        /// <summary>
        /// ejec_rut
        /// </summary>
        public string ejec_rut { get; set; }

        /// <summary>
        /// aus_fecha_inicio
        /// </summary>
        public DateTime aus_fecha_inicio { get; set; }

        /// <summary>
        /// aus_fecha_fin
        /// </summary>
        public DateTime aus_fecha_fin { get; set; }

        /// <summary>
        /// tipo_ausencia_id
        /// </summary>
        public int tipo_ausencia_id { get; set; }

        /// <summary>
        /// aus_cantidad_dias
        /// </summary>
        public int aus_cantidad_dias { get; set; }

        /// <summary>
        /// aus_comentarios
        /// </summary>
        public string aus_comentarios { get; set; }

        /// <summary>
        /// aus_marca_ausencia
        /// </summary>
        public bool aus_marca_ausencia { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AusenciaEntity"/>.
        /// </summary>
        public AusenciaEntity()
        {
            aus_id = 0;
            ejec_rut = string.Empty;
            aus_fecha_inicio = new DateTime(1900, 1, 1);
            aus_fecha_fin = new DateTime(1900, 1, 1);
            tipo_ausencia_id = 0;
            aus_cantidad_dias = 0;
            aus_comentarios = string.Empty;
            aus_marca_ausencia = false;
        }
    }
}
