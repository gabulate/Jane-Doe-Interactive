using ApplicationCore.Services;
using Infrastructure.Models;
using Infrastructure.Utils;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.Security;
using Web.ViewModel;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace Web.Controllers
{
    public class ReporteController : Controller
    {

        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult DescargarPDF()
        {
            //Ejemplos IText7 https://kb.itextpdf.com/home/it7kb/examples
            IEnumerable<Deuda> lista = null;
            try
            {
                // Extraer informacion
                //IServiceDeuda _Service = new ServiceDeuda();
                //lista = _Service.GetDeudaPendiente();
                lista = (IEnumerable<Deuda>)TempData["ListaDeudas"];


                // Crear stream para almacenar en memoria el reporte 
                MemoryStream ms = new MemoryStream();
                //Inicializar writer
                PdfWriter writer = new PdfWriter(ms);

                //Inicializar document
                PdfDocument pdfDoc = new PdfDocument(writer);
                Document doc = new Document(pdfDoc);

                //Título
                Paragraph header = new Paragraph("Listado de deudas")
                                    .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD))
                                    .SetFontSize(16)
                                    .SetHorizontalAlignment(HorizontalAlignment.CENTER)
                                    .SetFontColor(ColorConstants.BLACK);
                doc.Add(header);
                // Crear tabla con 5 columnas 
                Table table = new Table(3, true);
                //Encabezados de la tabla
                table.AddHeaderCell("Fecha");
                table.AddHeaderCell("Descripción");
                table.AddHeaderCell("Residencia");

                foreach (var item in lista)
                {
                    // Agregar datos a las celdas
                    table.AddCell(new Paragraph(item.Fecha.ToString("MMMM/yyyy")));
                    table.AddCell(new Paragraph(item.PlanCobro.Descripcion));
                    table.AddCell(new Paragraph(item.Residencia.Descripcion));

                }
                doc.Add(table);

                decimal costo = 0;
                foreach (Deuda de in lista)
                {
                    costo += (de.PlanCobro.MontoTotal);
                }

                Paragraph costoPar = new Paragraph("Costo: ₡" + costo)
                                    .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD))
                                    .SetFontSize(14)
                                    .SetHorizontalAlignment(HorizontalAlignment.CENTER)
                                    .SetFontColor(ColorConstants.BLACK);
                doc.Add(costoPar);

                // Colocar número de páginas
                int numberofPages = pdfDoc.GetNumberOfPages();
                for (int i = 1; i <= numberofPages; i++)
                {
                    //Texto alineado a un punto específico
                    doc.ShowTextAligned(
                        new Paragraph(
                            String.Format("página {0} de {1}", i, numberofPages)
                            ),
                        559, 826, i, TextAlignment.RIGHT, VerticalAlignment.TOP, 0
                        );
                }

                //Terminar document
                doc.Close();
                // Retorna un File
                return File(ms.ToArray(), "application/pdf", "reporte.pdf");
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData.Keep();
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Ingresos()
            {
                return View();
            }

        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Deudas()
        {

            IEnumerable<Deuda> lista = null;
            try
            {
                IServiceDeuda _Service = new ServiceDeuda();
                lista = _Service.GetDeudaPendiente();
                ViewBag.title = "Lista Deudas pendientes";

                decimal total = 0;
                foreach(Deuda de in lista)
                {
                    total += (de.PlanCobro.MontoTotal);
                }
                ViewBag.total = total;
                ViewBag.listResidencia = listResidencia();

                TempData["ListaDeudas"] = lista;
                TempData.Keep();

                return View(lista);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;

                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult updateFiltroDeuda(int residencia, int mes)
        {
            //Contenido a actualizar
            IEnumerable<Deuda> lista = null;
            IServiceDeuda _Service = new ServiceDeuda();

            lista = _Service.GetDeudaPendiente((int)residencia, mes);

            TempData["ListaDeudas"] = lista;
            TempData.Keep();

            decimal total = 0;
            foreach (Deuda de in lista)
            {
                total += (de.PlanCobro.MontoTotal);
            }
            ViewBag.total = total;

            //Nombre de vista parcial, datos para la vista
            return PartialView("_CuadroDeudas", lista);

        }

        private SelectList listResidencia(int idPropietario = 0)
        {
            IServiceResidencia _service = new ServiceResidencia();
            IEnumerable<Residencia> lista = _service.GetResidencia();
            return new SelectList(lista, "Id", "Descripcion", idPropietario);
        }

        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult graficoIngresos()
        {
            IServiceDeuda _ServiceDeuda = new ServiceDeuda();
            ViewModelGrafico grafico = new ViewModelGrafico();
            _ServiceDeuda.GetIngresosCountDate(out string etiquetas, out string valores);
            grafico.Etiquetas = etiquetas;
            grafico.Valores = valores;
            int cantidadValores = valores.Split(',').Length;
            grafico.Colores = string.Join(",", grafico.GenerateColors(cantidadValores));
            grafico.titulo = "Número del mes";
            grafico.tituloEtiquetas = "Cantidad de ingresos por mes";
            grafico.tipo = "bar";
            ViewBag.grafico = grafico;
            return View();
        }
    }
}