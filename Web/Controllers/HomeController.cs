using ApplicationCore.Services;
using Infrastructure.Models;
using Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.IO;
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

        private SelectList listTipos(int idTipo = 0)
        {
            IServiceTipoInformación _Service = new ServiceTipoInformacion();
            IEnumerable<TipoInformacion> lista = _Service.GetTipoInformacion();
            return new SelectList(lista, "Id", "Descripcion", idTipo);
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
                ViewBag.IdTipoInformacion = listTipos(info.IdTipoInformacion);
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

        public ActionResult Create()
        {
            ViewBag.IdTipoInformacion = listTipos();
            return View();
        }

        // POST: RubroCobro/Create CREAR O ACTUALIZAR
        [HttpPost]
        public ActionResult Save(Informacion info, HttpPostedFileBase Documento)
        {
            MemoryStream target = new MemoryStream();
            IServiceInformacion _ServiceInformacion = new ServiceInformacion();

            try
            {
                //Insertar la imagen
                if (info.Doc1 == null)
                {
                    if (Documento != null)
                    {
                        Documento.InputStream.CopyTo(target);
                        info.Doc1 = target.ToArray();
                        ModelState.Remove("Documento");
                    }
                }
                if (ModelState.IsValid)
                {
                    Informacion oInformacion = _ServiceInformacion.Save(info);
                }
                else
                {
                    // Valida Errores si Javascript está deshabilitado
                    Utils.Util.ValidateErrors(this);
                    //Cargar la vista crear o actualizar
                    //Lógica para cargar vista correspondiente
                    if (info.Id > 0)
                    {
                        return (ActionResult)View("Edit", info);
                    }
                    else
                    {
                        return View("Create", info);
                    }
                }
                return RedirectToAction("IndexMante");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "";
                TempData["Redirect-Action"] = "IndexAdmin";
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
            Informacion oInformacion = _Service.GetInformacionById((int)id);
            string name = oInformacion.TipoInformacion.Descripcion;

            return File(oInformacion.Doc1, "application/pdf", name + ".pdf");
        }
    }
}