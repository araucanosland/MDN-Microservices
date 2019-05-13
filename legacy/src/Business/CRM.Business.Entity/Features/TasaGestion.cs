using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity.Features
{
    public class TasaGestion
    {
        public int Periodo { get; set; }
        public decimal Porcentaje
        {
            get { return (GestionesTotal / GestionesRealizadas) * 100; }
        }
        public int GestionesRealizadas { get; set; }
        public int GestionesTotal { get; set; }
    }
}
