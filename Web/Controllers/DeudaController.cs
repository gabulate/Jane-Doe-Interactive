using ApplicationCore.Services;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.Security;
using Web.Utils;

namespace Web.Controllers
{
    public class DeudaController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Residencia> lista = null;
            try
            {
                int idUsuario = 1;
                if (Session["User"] != null)
                {
                    Usuario usuario = (Usuario)Session["User"];
                    idUsuario = usuario.Id;
                }
                IServiceResidencia _ServiceResidencia = new ServiceResidencia();
                lista = _ServiceResidencia.GetResidenciaByUsuario(idUsuario);
                ViewBag.title = "Lista Residencias";

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

        // GET: Deuda
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult IndexMante()
        {
            IEnumerable<Residencia> lista = null;
            try
            {
                IServiceResidencia _ServiceResidencia = new ServiceResidencia();
                lista = _ServiceResidencia.GetResidencia();
                ViewBag.title = "Lista Residencias";

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
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Details(int? id)
        {
            ServiceResidencia _ServiceResidencia = new ServiceResidencia();
            Residencia residencia = null;
            try
            {
                //Si va null
                if (id == null)
                {
                    return RedirectToAction("Index");
                }

                residencia = _ServiceResidencia.GetResidenciaById(Convert.ToInt32(id));
                if (residencia == null)
                {
                    TempData["Message"] = "No existe la residencia solicitado";
                    TempData["Redirect"] = "Deuda";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                return View(residencia);

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
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Create()
        {
            ViewBag.idPlanCobro = listPlanCobro();
            ViewBag.idResidencia = listResidencia();
            return View();
        }

        private SelectList listPlanCobro(int IdPlanCobro = 0)
        {
            IServicePlanCobro _ServicePlanCobro = new ServicePlanCobro();
            IEnumerable<PlanCobro> lista = _ServicePlanCobro.GetPlanCobro();
            return new SelectList(lista, "Id", "Descripcion", IdPlanCobro);

        }

        private SelectList listResidencia(int IdResidencia = 0)
        {
            IServiceResidencia _ServiceResidencia = new ServiceResidencia();
            IEnumerable<Residencia> lista = _ServiceResidencia.GetResidencia();
            return new SelectList(lista, "Id", "Descripcion", IdResidencia);

        }

        // POST: Deuda/Create
        [HttpPost]
        public ActionResult Save(Deuda deuda)
        {
            IServiceDeuda _ServiceDeuda = new ServiceDeuda();
            try
            {
                if (ModelState.IsValid)
                {
                    Deuda oDeuda = _ServiceDeuda.Save(deuda);

                    if (oDeuda == null)
                    {
                        TempData["mensaje"] = "Plan de Cobro no asignado. No se puede repetir el mes para el residente seleccionado. ";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["mensaje"] = "El plan de cobro se ha asignado correctamente";
                        return RedirectToAction("Index");
                    }

                }
                else
                {
                    // Valida Errores si Javascript está deshabilitado
                    Utils.Util.ValidateErrors(this);

                    //Cargar la vista crear o actualizar
                    //Lógica para cargar vista correspondiente
                    if (deuda.Id > 0)
                    {
                        return (ActionResult)View("Edit", deuda);
                    }
                    else
                    {
                        ViewBag.idPlanCobro = listPlanCobro(deuda.IdPlanCobro);
                        ViewBag.idResidencia = listResidencia(deuda.IdResidencia);
                        return View("Create", deuda);
                    }
                }
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

        #region Edit
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

        #endregion

        #region Delete
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
        #endregion
    }
}
