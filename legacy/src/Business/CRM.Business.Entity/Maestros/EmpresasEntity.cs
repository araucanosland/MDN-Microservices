using System;

//------------------------------------------------------------------------------
// <generado automáticamente>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </generado automáticamente>
//------------------------------------------------------------------------------

namespace CRM.Business.Entity.Maestros
{
    /// <summary>
    /// Clase Dominio EmpresasEntity
    /// </summary>
    /// <author>@Charly</author>
    /// <created>10-04-2018 11:54:32</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class EmpresasEntity
    {

        /// <summary>
        /// idFechaCorte
        /// </summary>
        public DateTime idFechaCorte { get; set; }

        /// <summary>
        /// RutEmpresa
        /// </summary>
        public string RutEmpresa { get; set; }

        /// <summary>
        /// DvEmpresa
        /// </summary>
        public string DvEmpresa { get; set; }

        /// <summary>
        /// NombreEmpresa
        /// </summary>
        public string NombreEmpresa { get; set; }

        /// <summary>
        /// NombreHolding
        /// </summary>
        public string NombreHolding { get; set; }

        /// <summary>
        /// TipoEmpresa
        /// </summary>
        public string TipoEmpresa { get; set; }


        /// <summary>
        /// RutCompuesto
        /// </summary>
        public string RutCompuesto {
            get
            {
                return RutEmpresa.ToString() + "-" + DvEmpresa;
            }
                
        }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="EmpresasEntity"/>.
        /// </summary>
        public EmpresasEntity()
        {
            idFechaCorte = new DateTime(1900, 1, 1);
            RutEmpresa = string.Empty;
            DvEmpresa = string.Empty;
            NombreEmpresa = string.Empty;
            NombreHolding = string.Empty;
            TipoEmpresa = string.Empty;

        }
    }
}
