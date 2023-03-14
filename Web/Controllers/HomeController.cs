using ApplicationCore.Services;
using Infrastructure.Models;
using Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            IEnumerable<Informacion> lista = null;
            try
            {
                IServiceInformacion _ServicioPlanCobro = new ServiceInformacion();
                lista = _ServicioPlanCobro.GetInformacion();
                ViewBag.title = "Lista Información";
                //Lista RubrosCobro
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

        public ActionResult IndexMante()
        {

            IEnumerable<Informacion> lista = null;
            try
            {
                IServiceInformacion _ServiceInformacion = new ServiceInformacion();
                lista = _ServiceInformacion.GetInformacion();
                ViewBag.title = "Lista Información";
                //Lista RubrosCobro
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

        //CREAR SERVICE DE TIPOINFORMACION
        private MultiSelectList listTipos(ICollection<TipoInformacion> tipos = null)
        {
            IServiceRubroCobro _ServiceRubroCobro = new ServiceRubroCobro();
            IEnumerable<RubroCobro> lista = _ServiceRubroCobro.GetRubroCobro();

            int[] listaRubrosSelect = null;
            if (tipos != null)
            {
                listaRubrosSelect = tipos.Select(r => r.Id).ToArray();
            }
            return new MultiSelectList(lista, "Id", "Descripcion", listaRubrosSelect);
        }

        public ActionResult Edit(int? id)
        {
            IServiceInformacion _ServiceInformacion = new ServiceInformacion();
            Informacion info = null;
            try
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                info = _ServiceInformacion.GetInformacionById(Convert.ToInt32(id));
                if (info == null)
                {
                    TempData["Message"] = "No existe el aviso solicitado";
                    TempData["Redirect"] = "Home";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                //ViewBag.IdTipoInfo = listTipos(plan.RubroCobro);

                return View(info);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Home";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public  ActionResult DescargarArchivo(int? id = 0)
        {
            IServiceInformacion _Service = new ServiceInformacion();
            Informacion oInformacion = _Service.GetInformacionById(2);

            return File(oInformacion.Doc1, "application/pdf", "hola.pdf");
        }
    }
}