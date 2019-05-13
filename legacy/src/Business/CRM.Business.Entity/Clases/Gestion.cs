using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity.Clases
{
    public class PadreGestion
    {
        public GestionEntity GestionBase { get; set; }
        public Ejecutivo Gestor { get; set; }
    }


    public class Gestion : PadreGestion
    { 
        public EstadogestionEntity EstadoGestion { get; set; }
        public EstadogestionEntity SubEstadoGestion { get; set; }
    }


    public class GestionRecuperacion : PadreGestion
    {
        public EstadogestionEntity CausaBasalGestion { get; set; }
        public EstadogestionEntity ConsecuenciaGestion { get; set; }
        public EstadogestionEntity EstadoGestion { get; set; }
    }

    public class GestionNormalizacionTMC : PadreGestion
    {
        public EstadogestionEntity EstadoGestion { get; set; }
        public EstadogestionEntity SubEstadoGestion { get; set; }
    }

    public class GestionNormalizacionSC : PadreGestion
    {
        public EstadogestionEntity EstadoGestion { get; set; }
        public EstadogestionEntity SubEstadoGestion { get; set; }
    }

    public class GestionGenerica : PadreGestion
    {
        public EstadogestionEntity CausaBasalGestion { get; set; }
        public EstadogestionEntity ConsecuenciaGestion { get; set; }
        public EstadogestionEntity EstadoGestion { get; set; }
        public EstadogestionEntity SubEstadoGestion { get; set; }
    }


}
