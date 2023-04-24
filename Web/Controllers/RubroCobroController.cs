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
    public class RubroCobroController : Controller
    {
        // GET: RubroCobro
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult IndexMante()
        {
            IEnumerable<RubroCobro> lista = null;
            try
            {
                IServiceRubroCobro _ServiceRubroCobro = new ServiceRubroCobro();
                lista = _ServiceRubroCobro.GetRubroCobro();
                ViewBag.title = "Lista RubrosCobro";
                return View(lista);

            }
            catch(Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;

                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // GET: RubroCobro/Details/5
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Details(int? id)
        {
            ServiceRubroCobro _ServiceRubroCobro = new ServiceRubroCobro();
            RubroCobro rubro = null;
            try
            {
                if( id== null)
                {
                    return RedirectToAction("IndexMante");
                }
                rubro = _ServiceRubroCobro.GetRubroCobroByID(Convert.ToInt32(id));
                if(rubro == null )
                {
                    TempData["Message"] = "No existe el libro solicitado";
                    TempData["Redirect"] = "RubroCobro";
                    TempData["Redirect-Action"] = "IndexMante";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                return View(rubro);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "RubroCobro";
                TempData["Redirect-Action"] = "IndexAdmin";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // GET: RubroCobro/Create
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: RubroCobro/Create CREAR O ACTUALIZAR
        [CustomAuthorize((int)Roles.Administrador)]
        [HttpPost]
        public ActionResult Save(RubroCobro rubro)
        {
            MemoryStream target = new MemoryStream();
            IServiceRubroCobro _ServiceRubroCobro = new ServiceRubroCobro();

            try
            {
                if(ModelState.IsValid)
                {
                    RubroCobro oRubroCobroI = _ServiceRubroCobro.Save(rubro);
                }
                else
                {
                    // Valida Errores si Javascript está deshabilitado
                    Utils.Util.ValidateErrors(this);
                    //Cargar la vista crear o actualizar
                    //Lógica para cargar vista correspondiente
                    if (rubro.Id > 0)
                    {
                        return (ActionResult)View("Edit", rubro);
                    }
                    else
                    {
                        return View("Create", rubro);
                    }
                }
                return RedirectToAction("IndexMante");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "RubroCobro";
                TempData["Redirect-Action"] = "IndexAdmin";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // GET: RubroCobro/Edit/5
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Edit(int? id)
        {
            ServiceRubroCobro _ServiceRubroCobro = new ServiceRubroCobro();
            RubroCobro rubro = null;
            try
            {
                if (id == null)
                {
                    return RedirectToAction("IndexMante");
                }
                rubro = _ServiceRubroCobro.GetRubroCobroByID(Convert.ToInt32(id));
                if (rubro == null)
                {
                    TempData["Message"] = "No existe el rubro solicitado";
                    TempData["Redirect"] = "RubroCobro";
                    TempData["Redirect-Action"] = "IndexMante";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                return View(rubro);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "RubroCobro";
                TempData["Redirect-Action"] = "IndexAdmin";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        #region Delete

        // GET: RubroCobro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RubroCobro/Delete/5
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
