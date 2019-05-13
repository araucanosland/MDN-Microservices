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
    /// Clase Dominio TipoausenciaEntity
    /// </summary>
    /// <author>Carlos Pradenas</author>
    /// <created>27-06-2017 23:53:10</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class TipoausenciaEntity
    {

        /// <summary>
        /// taus_id
        /// </summary>
        public int taus_id { get; set; }

        /// <summary>
        /// taus_nombre
        /// </summary>
        public string taus_nombre { get; set; }


        /// <summary>
        /// taus_clase_color
        /// </summary>
        public string taus_clase_color { get; set; }


        /// <summary>
        /// taus_es_rango_fechas
        /// </summary>
        public bool taus_es_rango_fechas { get; set; }


        /// <summary>
        /// taus_es_dias_corridos
        /// </summary>
        public bool taus_es_dias_corridos { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TipoausenciaEntity"/>.
        /// </summary>
        public TipoausenciaEntity()
        {
            taus_id = 0;
            taus_nombre = string.Empty;
            taus_clase_color = string.Empty;
            taus_es_rango_fechas = false;
            taus_es_dias_corridos = false;
        }
    }
}
