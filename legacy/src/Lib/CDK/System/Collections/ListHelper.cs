using System.Collections.Generic;
using System.Linq;

namespace CDK.System.Collections
{
    /// <summary>
    /// ListHelper
    /// </summary>
    public static class ListHelper
    {
        /// <summary>
        /// Ordena una Lista de objetos por nombre de Propiedad
        /// </summary>
        /// <typeparam name="T">Clase</typeparam>
        /// <param name="lista">Colección de objetos</param>
        /// <param name="propiedad">Nombre de la propiedad de la clase</param>
        /// <param name="descendente">Dejar en <c>true</c> para aplicar ordenamiento descendente</param>
        /// <returns></returns>
        public static IEnumerable<T> OrdenarPorNombrePropiedad<T>(IEnumerable<T> lista, string propiedad, bool descendente = false)
        {
            return descendente ? lista.OrderByDescending(element => TypeHelper.ObtenerValorPropiedad(element, propiedad)) : lista.OrderBy(element => TypeHelper.ObtenerValorPropiedad(element, propiedad));
        }
    }
}
