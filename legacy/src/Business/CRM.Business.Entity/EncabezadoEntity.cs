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
    /// Clase Dominio EncabezadoEntity
    /// </summary>
    /// <author>@Charly</author>
    /// <created>07-03-2018 10:53:36</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class EncabezadoEntity
    {

        /// <summary>
        /// enc_id
        /// </summary>
        public int enc_id { get; set; }

        /// <summary>
        /// cuestionario_id
        /// </summary>
        public int cuestionario_id { get; set; }

        /// <summary>
        /// rut_empresa
        /// </summary>
        public string rut_empresa { get; set; }

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
        /// cantidad_empleados
        /// </summary>
        public int cantidad_empleados { get; set; }

        /// <summary>
        /// cod_sucursal
        /// </summary>
        public int cod_sucursal { get; set; }

        /// <summary>
        /// rut_ejecutivo
        /// </summary>
        public string rut_ejecutivo { get; set; }

        /// <summary>
        /// nombre_empresa
        /// </summary>
        public string nombre_empresa { get; set; }

        /// <summary>
        /// fecha_entrevista
        /// </summary>
        public DateTime fecha_entrevista { get; set; }


        /// <summary>
        /// fecha_actualizacion
        /// </summary>
        public DateTime fecha_actualizacion { get; set; }


        /// <summary>
        /// nombre_sucursal_empresa
        /// </summary>
        public string nombre_sucursal_empresa { get; set; }

        
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="EncabezadoEntity"/>.
        /// </summary>
        public EncabezadoEntity()
        {
            enc_id = 0;
            cuestionario_id = 0;
            rut_empresa = string.Empty;
            estamento = string.Empty;
            nombre_funcionario = string.Empty;
            cargo_funcionario = string.Empty;
            cantidad_empleados = 0;
            cod_sucursal = 0;
            rut_ejecutivo = string.Empty;
            nombre_empresa = string.Empty;
            fecha_entrevista = new DateTime(1900, 1, 1);
            fecha_actualizacion = new DateTime(1900, 1, 1);
            nombre_sucursal_empresa = string.Empty;
        }
    }
}
