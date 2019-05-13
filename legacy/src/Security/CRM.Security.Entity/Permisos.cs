using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Security.Entity
{
    /// <summary>
    /// Clase Dominio Permisos
    /// </summary>
    /// <author>@Charly</author>
    /// <created>12-09-2017 15:58:15</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class Permisos
    {

        /// <summary>
        /// CodPermiso
        /// </summary>
        public int CodPermiso { get; set; }

        /// <summary>
        /// CodRecurso
        /// </summary>
        public int CodRecurso { get; set; }


        /// <summary>
        /// CodRol
        /// </summary>
        public int CodRol { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Permisos"/>.
        /// </summary>
        public Permisos()
        {
            CodPermiso = 0;
            CodRecurso = 0;
            CodRol = 0;
        }
    }
}
