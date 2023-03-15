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
    public class IncidenteController : Controller
    {
        // GET: Incidente
        public ActionResult Index()
        {

            IEnumerable<Incidente> lista = null;
            try
            {
                IServiceIncidente _Servicio = new ServiceIncidente();
                lista = _Servicio.GetIncidenteByUsuario(1);
                ViewBag.title = "Lista Incidentes";
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

            IEnumerable<Incidente> lista = null;
            try
            {
                IServiceIncidente _Servicio = new ServiceIncidente();
                lista = _Servicio.GetIncidente();
                ViewBag.title = "Lista Incidentes";
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

        // GET: Incidente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        private SelectList listEstados(int IdEstadoIncidente = 0)
        {
            IServiceEstadoIncidente _Service = new ServiceEstadoIncidente();
            IEnumerable<EstadoIncidente> lista = _Service.GetEstadoIncidente();
            return new SelectList(lista, "Id", "Descripcion", IdEstadoIncidente);
        }

        // GET: Incidente/Create
        public ActionResult Create()
        {
            ViewBag.IdEstadoIncidente = listEstados();
            return View();
        }

        // GET: Incidente/Edit/5
        public ActionResult Edit(int? id)
        {
            IServiceIncidente _Service = new ServiceIncidente();
            Incidente incidente = null;
            try
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                incidente = _Service.GetIncidenteById(Convert.ToInt32(id));
                if (incidente == null)
                {
                    TempData["Message"] = "No existe el incidente solicitado";
                    TempData["Redirect"] = "Home";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                ViewBag.IdEstadoIncidente = listEstados(incidente.Estado);
                return View(incidente);
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

        // GET: Incidente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        public ActionResult Save(Incidente incidente)
        {
            IServiceIncidente _Service = new ServiceIncidente();
            
            try
            {
                if (ModelState.IsValid)
                {
                    Incidente oIncidente = _Service.Save(incidente);
                }
                else
                {
                    // Valida Errores si Javascript está deshabilitado
                    Utils.Util.ValidateErrors(this);
                    ViewBag.IdEstadoIncidente = listEstados(incidente.Estado);

                    //Cargar la vista crear o actualizar
                    //Lógica para cargar vista correspondiente
                    if (incidente.Id > 0)
                    {
                        ViewBag.IdEstadoIncidente = listEstados(incidente.Estado);
                        return View("Edit", incidente);
                    }
                    else
                    {
                        ViewBag.IdEstadoIncidente = listEstados(incidente.Estado);
                        return View("Create", incidente);
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

        // POST: Incidente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
