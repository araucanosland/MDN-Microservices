using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity
{


    public class EstadogestionEntity
    {

        /// <summary>
        /// eges_id
        /// </summary>
        public int eges_id { get; set; }

        /// <summary>
        /// eges_nombre
        /// </summary>
        public string eges_nombre { get; set; }

        /// <summary>
        /// ejes_id_padre
        /// </summary>
        public long ejes_id_padre { get; set; }

        /// <summary>
        /// ejes_terminal
        /// </summary>
        public string ejes_terminal { get; set; }

        /// <summary>
        /// ejes_tipo_campagna
        /// </summary>
        public int ejes_tipo_campagna { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="EstadogestionEntity"/>.
        /// </summary>
        public EstadogestionEntity()
        {
            eges_id = 0;
            eges_nombre = string.Empty;
            ejes_id_padre = 0;
            ejes_terminal = string.Empty;
            ejes_tipo_campagna = 0;

        }
    }

    public class TipoEjecutivoEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }


    public class TipoCampagnaEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
