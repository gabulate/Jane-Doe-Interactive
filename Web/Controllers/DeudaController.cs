using ApplicationCore.Services;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.Utils;

namespace Web.Controllers
{
    public class DeudaController : Controller
    {
        // GET: Deuda
        public ActionResult Index()
        {
            IEnumerable<Deuda> lista = null;
            try
            {
                IServiceDeuda _ServiceDeuda = new ServiceDeuda();
                lista = _ServiceDeuda.GetDeuda();
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

        // GET: Deuda/Details/5
        public ActionResult Details(int? id)
        {
            ServiceDeuda _ServiceDeuda = new ServiceDeuda();
            Deuda deuda = null;
            try
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                //LÍNEA 48 DA PROBLEMAS!!!!!!!!!! ERROR 404
                //deuda=_ServiceDeuda.GetDeudaByIdResidencia(Convert.ToInt32(id)); 
                if(deuda==null)
                {
                    TempData["Message"] = "No existe el deuda solicitado";
                    TempData["Redirect"] = "Deuda";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                return View(deuda);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Deuda";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // GET: Deuda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deuda/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Deuda/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Deuda/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Deuda/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Deuda/Delete/5
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
