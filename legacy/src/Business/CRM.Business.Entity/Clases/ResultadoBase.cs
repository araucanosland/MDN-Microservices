using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity.Clases
{
    public class ResultadoBase
    {
        public string Estado { get; set; }
        public string Mensaje { get; set; }
        public dynamic Objeto { get; set; }
    }
}
