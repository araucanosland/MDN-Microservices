using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Security.Entity
{
    /// <summary>
    /// Clase Dominio Permisodetalle
    /// </summary>
    /// <author>@Charly</author>
    /// <created>12-09-2017 15:51:46</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class PermisoDetalle
    {

        /// <summary>
        /// CodPerDetalle
        /// </summary>
        public int CodPerDetalle { get; set; }

        /// <summary>
        /// CodPermiso
        /// </summary>
        public int CodPermiso { get; set; }

        /// <summary>
        /// Controlador
        /// </summary>
        public string Controlador { get; set; }

        /// <summary>
        /// Accion
        /// </summary>
        public string Accion { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Permisodetalle"/>.
        /// </summary>
        public PermisoDetalle()
        {
            CodPerDetalle = 0;
            CodPermiso = 0;
            Controlador = string.Empty;
            Accion = string.Empty;

        }
    }
}
