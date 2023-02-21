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
    public class PlanCobroController : Controller
    {
        // GET: PlanCobro
        public ActionResult Index()
        {
            IEnumerable<PlanCobro> lista = null;
            try
            {
                IServicePlanCobro _ServicioPlanCobro = new ServicePlanCobro();
                lista = _ServicioPlanCobro.GetPlanCobro();
                ViewBag.title = "Lista PlanCobro";
                //Lista RubrosCobro????
                IServiceRubroCobro _ServiceRubroCobro = new ServiceRubroCobro();
                ViewBag.listaRubroCobro = _ServiceRubroCobro.GetRubroCobro();
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

        // GET: PlanCobro/Details/5
        public ActionResult Details(int? id)
        {
            ServicePlanCobro _ServicePlanCobro = new ServicePlanCobro();
            PlanCobro plan = null;
            try
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                plan = _ServicePlanCobro.GetPlanCobroByID(Convert.ToInt32(id));
                if(plan == null)
                {
                    TempData["Message"] = "No existe el plan solicitado";
                    TempData["Redirect"] = "PlanControl";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                return View(plan);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Libro";
                TempData["Redirect-Action"] = "IndexAdmin";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // GET: PlanCobro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlanCobro/Create
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

        // GET: PlanCobro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlanCobro/Edit/5
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

        // GET: PlanCobro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlanCobro/Delete/5
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
