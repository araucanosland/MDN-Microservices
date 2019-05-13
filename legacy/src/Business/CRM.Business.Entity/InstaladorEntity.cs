using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity
{
    public class InstaladorEntity
    {
        public int Id_ins { get; set; }
        public string Titulo { get; set; }
        public string Glosa { get; set; }
        public string Ruta { get; set; }
        public int Tiempo { get; set; }
    }
}
