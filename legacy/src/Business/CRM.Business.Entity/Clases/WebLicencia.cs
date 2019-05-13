using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity.Clases
{
    public class WebLicenciaRecepcion
    {
        public string wRutEmpresa { get; set; }
        public string wFechaRecepcion { get; set; }
        public int wLMRecibida { get; set; }
        public int wLMDigitada { get; set; }
        public int wLMNoDigitada { get; set; }
        public int wLMNoRecepcion { get; set; }
        public int wCodOficina { get; set; }
        public int wLMRecepcionada { get; set; }

    }
    public class WebLicenciaEnvio
    {
        public string wFechaEnvio { get; set; }
        public int wLMEnviada { get; set; }
        public int wCodOficina { get; set; }

    }

    public class WebParametro
    {
        public string Fecha { get; set; }
        public string RutEmpresa { get; set; }
    }



    public class WebIngresoLicencia
    {
        public long CodIngreso { get; set; }
        public string RutAfiliado { get; set; }
        public string NombreAfiliado { get; set; }
        public bool SinDatosEnSistema { get; set; }
        public string FormatoLM { get; set; }
        public string FolioLc { get; set; }
        public int CodOficina { get; set; }
        public int CantidadDiasLM { get; set; }
        public string FechaInicioLM { get; set; }
        public string FechaHastaLM { get; set; }
        public int TipoLM { get; set; }
        public int OfiDerivacion { get; set; }


        public List<WebDocumentacion> DocumentacionLM { get; set; }
       // 

        public bool CompletitudDocumentos()
        {
            int cnt = 0;
            DocumentacionLM.ForEach(dclm => {
                if (dclm.Recepcionado)
                {
                    cnt++;
                }
            });

            return (TipoLM == 3) ? ((CantidadDiasLM >= 50 ? cnt==7 : cnt==6 )) : (cnt==3);
        }

        public int DeterminateStatus()
        {
            int retorno = 0;
            bool diasvacios = CantidadDiasLM == 0;
            bool iniciovacio = FechaInicioLM == null ||  FechaInicioLM.Length == 0;
            bool tipolmvacio = TipoLM == 0;

            if(diasvacios || iniciovacio || tipolmvacio)
            {
                retorno = 1;
            }
            else
            {
                if (CompletitudDocumentos())
                {
                    retorno = 3;
                }
                else
                {
                    retorno = 2;
                }
            }
            return retorno;
        }
    }


    public class WebDocumentacion
    {
        public int Periodo { get; set; }
        public bool Recepcionado { get; set; }
        public int TipoDoc { get; set; }
    }


}
