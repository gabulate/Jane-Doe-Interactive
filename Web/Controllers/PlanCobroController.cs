using ApplicationCore.Services;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.Security;
using Web.Utils;

namespace Web.Controllers
{
    public class PlanCobroController : Controller
    {
        // GET: PlanCobro
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Index()
        {
            IEnumerable<PlanCobro> lista = null;
            try
            {
                IServicePlanCobro _ServicioPlanCobro = new ServicePlanCobro();
                lista = _ServicioPlanCobro.GetPlanCobro();
                ViewBag.title = "Lista PlanCobro";
                //Lista RubrosCobro
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
        [CustomAuthorize((int)Roles.Administrador)]
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
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Create()
        {
            ViewBag.idRubro = listRubros();
            return View();
        }

        private MultiSelectList listRubros(ICollection<RubroCobro> rubros = null)
        {
            IServiceRubroCobro _ServiceRubroCobro = new ServiceRubroCobro();
            IEnumerable<RubroCobro> lista = _ServiceRubroCobro.GetRubroCobro();

            int[] listaRubrosSelect = null;
            if(rubros != null)
            {
                listaRubrosSelect = rubros.Select(r=>r.Id).ToArray();
            }
            return new MultiSelectList(lista, "Id", "Descripcion", listaRubrosSelect);
        }


        // GET: PlanCobro/Edit/5
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Edit(int? id)
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
                    TempData["Message"] = "No existe el plan de cobro solicitado";
                    TempData["Redirect"] = "PlanCobro";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                //Listado
                ViewBag.IdRubro = listRubros(plan.RubroCobro);
                return View(plan);
            }
            catch(Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "PlanCobro";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // POST: PlanCobro/Edit/5
        [CustomAuthorize((int)Roles.Administrador)]
        [HttpPost]
        public ActionResult Save(PlanCobro plan, string[] selectedRubrosCobro)
        {
            
            //Gestión de archivos
            MemoryStream target = new MemoryStream();
            IServicePlanCobro _ServicePlanCobro = new ServicePlanCobro();
            try
            {
                 if (ModelState.IsValid)
                 {
                        PlanCobro oPlanCobroI = _ServicePlanCobro.Save(plan, selectedRubrosCobro);
                 }
                 else
                 {
                     // Valida Errores si Javascript está deshabilitado
                     Utils.Util.ValidateErrors(this);
                     ViewBag.idRubro = listRubros(plan.RubroCobro);
                    //Cargar la vista crear o actualizar
                    //Lógica para cargar vista correspondiente
                    if(plan.Id > 0)
                    {
                        return (ActionResult)View("Edit", plan);
                    }
                    else
                    {
                        return View("Create", plan); 
                    }
                    
                }
                 return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "PlanCobro";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
        #region Delete
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
        #endregion
    }
}
