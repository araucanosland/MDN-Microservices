using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Security.Entity
{
    
        /// <summary>
        /// Clase Dominio Rol
        /// </summary>
        /// <author>@Charly</author>
        /// <created>12-09-2017 15:46:45</created>
        /// <remarks>
        /// Esta clase fué generada automáticamente por una herramienta.
        /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
        /// </remarks>
        public class Rol
        {

            /// <summary>
            /// CodRol
            /// </summary>
            public int CodRol { get; set; }

            /// <summary>
            /// Nombre
            /// </summary>
            public string Nombre { get; set; }


            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="Rol"/>.
            /// </summary>
            public Rol()
            {
                CodRol = 0;
                Nombre = string.Empty;

            }
        }

}
