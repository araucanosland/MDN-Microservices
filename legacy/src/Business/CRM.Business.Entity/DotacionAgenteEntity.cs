using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity
{
    public class DotacionAgenteEntity
    {
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string RutReemplazo { get; set; }
        public string NombreReemplazo { get; set; }
        public string Cargo { get; set; }
        public int TitularAusente { get; set; }
    }

    public class DatosEjecutivoEntity
    {
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public string TipoContrato { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Correo { get; set; }
        public string Sexo { get; set; }
    }

    public class DatosActualizaEjecutivoEntity
    {
        public string Rut { get; set; }
        public string Cargo { get; set; }
        public string TipoContrato { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinaliza { get; set; }
        public string Sexo { get; set; }
    }
}
