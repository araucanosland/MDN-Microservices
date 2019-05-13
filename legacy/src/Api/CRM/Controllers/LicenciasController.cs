using System;
using System.Collections.Generic;
using System.Linq;
using CRM.Business.Entity;
using CRM.Business.Entity.Clases;
using CRM.Business.Entity.Contracts;
using CRM.Business.Data;
using CRM.Filters;
using System.IO;
using System.Net.Http.Headers;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using CDK.Excel;
using System.Net.Http;

namespace CRM.Controllers
{
    [Route("api/Licencias")]
    public class LicenciasController : ControllerBase
    {
        [AuthorizationRequired]
        [HttpGet]
        [Route("lista-licencias-dia")]
        public IEnumerable<BaseLicencia> ListaLicenciasIngresadas(int codOficina, string dia)
        {
            DateTime elDia = Convert.ToDateTime(dia);
            List<BaseLicencia> Retorno = new List<BaseLicencia>();
            string token = Request.Headers["Token"].ToString();
            List<Ingresolicencia> ingLc = IngresolicenciaDataAccess.ObtenerEntidadesByOficina(codOficina, elDia);
            ingLc.ForEach(lc =>
            {
                Retorno.Add(new BaseLicencia
                {
                    IngresoData = lc,
                    EstadoData = EstadolicenciaDataAccess.ObtenerPorID(lc.CodEstado),
                    NombreEjecutivo = DotacionDataAccess.ObtenerByRut(lc.RutEjecutivo).Nombres
                });
            });

            return Retorno;
        }


        [AuthorizationRequired]
        [HttpGet]
        [Route("licencia-data")]
        public BaseLicencia DatoLicenciaIngresada(long codIngreso)
        {
            string token = Request.Headers["Token"].ToString();
            Ingresolicencia ingLc = IngresolicenciaDataAccess.ObtenerPorID(codIngreso);
            return new BaseLicencia
            {
                IngresoData = ingLc,
                EstadoData = EstadolicenciaDataAccess.ObtenerPorID(ingLc.CodEstado),
                NombreEjecutivo = DotacionDataAccess.ObtenerByRut(ingLc.RutEjecutivo).Nombres
            };
        }


        [AuthorizationRequired]
        [HttpPost]
        [Route("guardar-licencia")]
        public ResultadoBase GuardarLicencia(WebIngresoLicencia entrada)
        {


            try
            {
                string token = Request.Headers["Token"].ToString();
                Ingresolicencia ing = new Ingresolicencia();

                ing.CodIngreso = entrada.CodIngreso;
                ing.CodEstado = entrada.DeterminateStatus();
                ing.FechaIngreso = DateTime.Now;
                ing.FolioLicencia = entrada.FolioLc;
                ing.Oficina = entrada.CodOficina;
                ing.RutAfiliado = entrada.RutAfiliado.Replace(".", "");
                ing.NombreAfiliado = entrada.NombreAfiliado;
                ing.SinDatosEnSistema = entrada.SinDatosEnSistema;
                ing.FormatoLM = entrada.FormatoLM;
                ing.OficinaDerivacion = entrada.OfiDerivacion;


                if (entrada.CantidadDiasLM > 0)
                {
                    ing.CantidadDiasLM = entrada.CantidadDiasLM;
                }
                else
                {
                    ing.CantidadDiasLM = null;
                }

                if (entrada.FechaInicioLM != null && entrada.FechaInicioLM.Length > 0)
                {
                    ing.FechaInicioLM = Convert.ToDateTime(entrada.FechaInicioLM);
                }
                else
                {
                    ing.FechaInicioLM = null;
                }

                if (entrada.FechaHastaLM != null && entrada.FechaHastaLM.Length > 0)
                {
                    ing.FechaHastaLM = Convert.ToDateTime(entrada.FechaHastaLM);
                }
                else
                {
                    ing.FechaHastaLM = null;
                }

                if (entrada.TipoLM > 0)
                {
                    ing.TipoLM = entrada.TipoLM;
                }
                else
                {
                    ing.TipoLM = null;
                }

                //  

                IngresolicenciaDataAccess.Guardar(ing, token);
                return new ResultadoBase() { Estado = "OK", Mensaje = "Licencia ingresada con éxito", Objeto = entrada };
            }
            catch (Exception ex)
            {
                var x = ex.Message.Split(';');
                return new ResultadoBase() { Estado = "ERR", Mensaje = x[1], Objeto = x[0] };






                //if (base1.Estado.Equals("ERR"))
                //{
                //    return new ResultadoBase() { Estado = "ERR", Mensaje = x[0], Objeto = ex };
                //}
                //else
                //{
                //    return new ResultadoBase() { Estado = "ERR", Mensaje = x[1], Objeto = ex };
                //}


            }
        }


        [AuthorizationRequired]
        [HttpPost]
        [Route("guardar-licencia-derivacion")]
        public ResultadoBase GuardarLicenciaDerivacion(WebIngresoLicencia entrada)
        {


            try
            {
                string token = Request.Headers["Token"].ToString();

                Ingresolicencia ing = new Ingresolicencia();
                ing.RutAfiliado = entrada.RutAfiliado.Replace(".", ""); ;
                ing.FolioLicencia = entrada.FolioLc;
                // ing.Oficina = entrada.CodOficina;

                IngresolicenciaDataAccess.GuardaDerivacion(ing, token);
                return new ResultadoBase() { Estado = "OK", Mensaje = "Licencia derivada con éxito", };
            }
            catch (Exception ex)
            {
                return new ResultadoBase() { Estado = "ERR", Mensaje = ex.Message, Objeto = ex };
            }
        }


        [AuthorizationRequired]
        [HttpGet]
        [Route("eliminar-licencia")]
        public ResultadoBase EliminarLicencia(int CodIngreso)
        {
            try
            {
                string token = Request.Headers["Token"].ToString();
                IngresolicenciaDataAccess.Eliminar(CodIngreso, token);
                return new ResultadoBase() { Estado = "OK", Mensaje = "Licencia Eliminada con éxito", Objeto = CodIngreso };
            }
            catch (Exception ex)
            {
                return new ResultadoBase() { Estado = "ERR", Mensaje = "Error al eliminar licencia: " + ex.Message, Objeto = ex };
            }
        }



        //[AuthorizationRequired]
        [HttpGet]
        [Route("exportar-dia")]
        public HttpResponseMessage ExportarXLS(int codOficina, string dia)
        {
            DateTime elDia = Convert.ToDateTime(dia);
            var ingLc = IngresolicenciaDataAccess.ObtenerEntidadesByOficinaXLS(codOficina, elDia);

            Columna[] columns = {
                                    new Columna("FolioLicencia", "Folio LM"),
                                    new Columna("RutAfiliado","Rut Afiliado"),
                                    new Columna("NombreAfiliado","Nombre Afiliado"),
                                    new Columna("FechaIngreso", "Fecha Ingreso"),
                                    new Columna("RutEjecutivo", "Rut Ejecutivo"),
                                    new Columna("NombreEjecutivo", "Nombre Ejecutivo"),
                                    new Columna("SinDatosEnSistema", "Sin datos en sistema"),
                                    new Columna("SucursalDestino","Sucursal Destino")
            };

            byte[] filecontent = ExcelExportHelper.ExportExcel(ingLc, "LM Ingresadas al " + dia, true, columns);
            HttpResponseMessage response = new HttpResponseMessage();

            Stream stri = new MemoryStream(filecontent);
            response.Content = new StreamContent(stri);
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = "LM_Ingresadas_" + dia.Replace("-", "_").Replace("/", "_") + ".xls";
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(ExcelExportHelper.ExcelContentType);
            response.Content.Headers.ContentLength = stri.Length;

            return response;


        }
        [HttpGet]
        [Route("export-pdf")]
        public HttpResponseMessage ExportarPDF(int codOficina, string dia)
        {

            DateTime elDia = Convert.ToDateTime(dia);
            var ingLc = IngresolicenciaDataAccess.ObtenerEntidadesByOficinaPdf(codOficina, elDia);

            Columna[] columns = {
                                    new Columna("FolioLicencia", "Folio LM"),
                                    new Columna("RutAfiliado","Rut Afiliado"),
                                    new Columna("NombreAfiliado","Nombre Afiliado"),
                                    new Columna("FechaIngreso", "Fecha Ingreso"),
                                    new Columna("RutEjecutivo", "Rut Ejecutivo"),
                                    new Columna("NombreEjecutivo", "Nombre Ejecutivo"),
                                    new Columna("SinDatosEnSistema", "Sin datos en sistema"),
                                    new Columna("FormatoLM","Formato LM"),
                                    new Columna("LmFueradeArea","LM fuera de area"),
                                    new Columna("FormatoLM","Formato LM"),
                                    new Columna("SinDatosEnSistema", "Sin datos en sistema"),
                                    new Columna("SucursalDestino","Sucursal Destino")
            };

            byte[] filecontent = CreatePDF2(ingLc, "LM Ingresadas al " + dia, true, columns);
            HttpResponseMessage response = new HttpResponseMessage();


            Stream stri = new MemoryStream(filecontent);
            response.Content = new StreamContent(stri);
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = "LM_Ingresadas_Manual_" + dia.Replace("-", "_").Replace("/", "_") + ".pdf";
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            response.Content.Headers.ContentLength = stri.Length;

            return response;


        }
        public byte[] CreatePDF2(DataTable dataTable, string heading = "", bool showSrNo = false, params Columna[] columnsToTake)
        {
            Document doc = new Document(PageSize.LETTER, 50, 50, 50, 50);

            using (MemoryStream output = new MemoryStream())
            {
                PdfWriter wri = PdfWriter.GetInstance(doc, output);
                doc.Open();
                PdfPTable tblPrueba = new PdfPTable(dataTable.Columns.Count);
                PdfPRow row = null;
                float[] widths = new float[] { 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f };
                iTextSharp.text.Font font5 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                iTextSharp.text.Font font6 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                Paragraph header = new Paragraph("Motor de Negocios: Recepción LM Sin Visar Manuales") { Alignment = Element.ALIGN_CENTER };


                tblPrueba.SetWidths(widths);

                tblPrueba.WidthPercentage = 100;
                int iCol = 0;
                string colname = "";
                PdfPCell cell = new PdfPCell(new Phrase("Products"));
                cell.BorderWidthBottom = 0.75f;
                cell.Colspan = dataTable.Columns.Count;

                foreach (DataColumn c in dataTable.Columns)
                {

                    tblPrueba.AddCell(new Phrase(c.ColumnName, font5));
                }

                foreach (DataRow r in dataTable.Rows)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        tblPrueba.AddCell(new Phrase(r[0].ToString(), font5));
                        tblPrueba.AddCell(new Phrase(r[1].ToString(), font5));
                        tblPrueba.AddCell(new Phrase(r[2].ToString(), font5));
                        tblPrueba.AddCell(new Phrase(r[3].ToString(), font5));
                        tblPrueba.AddCell(new Phrase(r[4].ToString(), font5));
                        tblPrueba.AddCell(new Phrase(r[5].ToString(), font5));
                        tblPrueba.AddCell(new Phrase(r[6].ToString(), font5));
                        tblPrueba.AddCell(new Phrase(r[7].ToString(), font5));
                        tblPrueba.AddCell(new Phrase(r[8].ToString(), font5));
                        tblPrueba.AddCell(new Phrase(r[9].ToString(), font5));

                    }
                }



                iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);


                // agregamos titulo y adjuntamos tabla desde base
                doc.Add(header);
                doc.Add(Chunk.NEWLINE);
                doc.Add(Chunk.NEWLINE);
                doc.Add(tblPrueba);
                doc.Close();
                return output.ToArray();
            }

        }

        [HttpGet]
        [Route("export-pdf-mixta")]
        public HttpResponseMessage ExportarPDFMixta(int codOficina, string dia)
        {

            DateTime elDia = Convert.ToDateTime(dia);
            var ingLc = IngresolicenciaDataAccess.ObtenerEntidadesByOficinaPdf_Mixta(codOficina, elDia);

            Columna[] columns = {
                                    new Columna("FolioLicencia", "Folio LM"),
                                    new Columna("RutAfiliado","Rut Afiliado"),
                                    new Columna("NombreAfiliado","Nombre Afiliado"),
                                    new Columna("FechaIngreso", "Fecha Ingreso"),
                                    new Columna("RutEjecutivo", "Rut Ejecutivo"),
                                    new Columna("NombreEjecutivo", "Nombre Ejecutivo"),
                                    new Columna("SinDatosEnSistema", "Sin datos en sistema"),
                                    new Columna("FormatoLM","Formato LM"),
                                    new Columna("SinDatosEnSistema", "Sin datos en sistema"),
                                    new Columna("SucursalDestino","Sucursal Destino")
            };

            byte[] filecontent = CreatePDFMixta(ingLc, "LM Ingresadas al " + dia, true, columns);
            HttpResponseMessage response = new HttpResponseMessage();


            Stream stri = new MemoryStream(filecontent);
            response.Content = new StreamContent(stri);
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = "LM_Ingresadas_Mixta_" + dia.Replace("-", "_").Replace("/", "_") + ".pdf";
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            response.Content.Headers.ContentLength = stri.Length;

            return response;


        }

        public byte[] CreatePDFMixta(DataTable dataTable, string heading = "", bool showSrNo = false, params Columna[] columnsToTake)
        {
            Document doc = new Document(PageSize.LETTER, 50, 50, 50, 50);

            using (MemoryStream output = new MemoryStream())
            {
                PdfWriter wri = PdfWriter.GetInstance(doc, output);
                doc.Open();
                PdfPTable tblPrueba = new PdfPTable(dataTable.Columns.Count);
                PdfPRow row = null;
                float[] widths = new float[] { 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f,4f,4f };
                iTextSharp.text.Font font5 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                iTextSharp.text.Font font6 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                Paragraph header = new Paragraph("Motor de Negocios: Recepción LM Sin Visar Mixta") { Alignment = Element.ALIGN_CENTER };


                tblPrueba.SetWidths(widths);

                tblPrueba.WidthPercentage = 100;
                int iCol = 0;
                string colname = "";
                PdfPCell cell = new PdfPCell(new Phrase("Products"));
                cell.BorderWidthBottom = 0.75f;
                cell.Colspan = dataTable.Columns.Count;

                foreach (DataColumn c in dataTable.Columns)
                {

                    tblPrueba.AddCell(new Phrase(c.ColumnName, font5));
                }

                foreach (DataRow r in dataTable.Rows)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        tblPrueba.AddCell(new Phrase(r[0].ToString(), font5));
                        tblPrueba.AddCell(new Phrase(r[1].ToString(), font5));
                        tblPrueba.AddCell(new Phrase(r[2].ToString(), font5));
                        tblPrueba.AddCell(new Phrase(r[3].ToString(), font5));
                        tblPrueba.AddCell(new Phrase(r[4].ToString(), font5));
                        tblPrueba.AddCell(new Phrase(r[5].ToString(), font5));
                        tblPrueba.AddCell(new Phrase(r[6].ToString(), font5));
                        tblPrueba.AddCell(new Phrase(r[7].ToString(), font5));
                        tblPrueba.AddCell(new Phrase(r[8].ToString(), font5));
                        tblPrueba.AddCell(new Phrase(r[9].ToString(), font5));

                    }
                }



                iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);


                // agregamos titulo y adjuntamos tabla desde base
                doc.Add(header);
                doc.Add(Chunk.NEWLINE);
                doc.Add(Chunk.NEWLINE);
                doc.Add(tblPrueba);
                doc.Close();
                return output.ToArray();
            }

        }


        //[AuthorizationRequired]
        [HttpGet]
        [Route("consulta-fonasa")]
        public ResultadoBase ConsultaWSFonasa(int FolioLM)
        {
            try
            {
                string token = Request.Headers["Token"].ToString();
                string codigoUsr = "Araucana", passUsr = "Rwg5B3Mz", oper = "10105";
                short aseg = 1, tipo = 1;
                //WSFonasaCajas.WSFonaCajasSoapClient wsFonasa = new WSFonasaCajas.WSFonaCajasSoapClient();
                //WSFonasaCajas.RespConFormLCC rsFonasa = wsFonasa.ConFormuLCC(codigoUsr, passUsr, aseg, oper, tipo, FolioLM);

                //return new ResultadoBase() { Estado = "OK", Mensaje = "Servicio respondió respuesta valida", Objeto = rsFonasa };
                return new ResultadoBase() { Estado = "OK", Mensaje = "Servicio respondió respuesta valida", Objeto = "Nu Hay" };
            }
            catch (Exception ex)
            {
                return new ResultadoBase() { Estado = "ERR", Mensaje = "Error al consultar a Servicio Fonasa", Objeto = ex };
            }
        }


        //[AuthorizationRequired]
        [HttpGet]
        [Route("datos-afiliado")]
        public ResultadoBase ConsultaWSDatosAfiliado(string AfiliadoRut)
        {
            try
            {
                //string token = Request.Headers["Token"].ToString();

                //ConsultaDatosAfiliadoService.ConsultaDatosAfiliadoDelegateClient wsAfidata = new ConsultaDatosAfiliadoService.ConsultaDatosAfiliadoDelegateClient();
                //ConsultaDatosAfiliadoService.datosAfiliado AfiData = wsAfidata.obtenerDatosAfiliado(AfiliadoRut);
                //return new ResultadoBase() { Estado = "OK", Mensaje = "Servicio respondió respuesta valida", Objeto = AfiData };
                return new ResultadoBase() { Estado = "OK", Mensaje = "Servicio respondió respuesta valida", Objeto = "DD" };
            }
            catch (Exception ex)
            {
                return new ResultadoBase() { Estado = "ERR", Mensaje = "Error al consultar a Servicio Fonasa", Objeto = ex };
            }
        }


        [AuthorizationRequired]
        [HttpGet]
        [Route("datos-encabezado-lic")]
        public Ingresolicencia ObtEncabezadoLicencia(int codOficina, string dia)
        {
            DateTime elDia = Convert.ToDateTime(dia);
            return IngresolicenciaDataAccess.ObtenerEncabezado(codOficina, elDia);

        }


        [AuthorizationRequired]
        [HttpGet]
        [Route("listar-suc-derivacion")]
        public List<OficinaDerivacionEntity> listaOfiDerivacion()
        {
            return LicenciaDataAccess.ListaOficinaDerivacion();
        }


    }
}
