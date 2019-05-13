using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity
{
    public class SeguimientoArticulosOficinaEntity
    {
        public int IdSeguimiento { get; set; }
        public string Nombre { get; set; }
        public int Oficina { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string EstadoArticulo { get; set; }
        public string Comentarios { get; set; }



        public SeguimientoArticulosOficinaEntity()
        {
            IdSeguimiento = 0;
            Nombre = string.Empty;
            Oficina = 0;
            FechaRegistro = new DateTime(1900, 1, 1);
            EstadoArticulo = string.Empty;
            Comentarios = string.Empty;
        }


    }


    public class SeguimientoArticulosOficinaWeb
    {
        public string EstadoArticulo { get; set; }
        public string Comentarios { get; set; }
    }
}
