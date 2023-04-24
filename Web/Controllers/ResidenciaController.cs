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
    public class ResidenciaController : Controller
    {
        // GET: Residencia
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Index()
        {
            IEnumerable<Residencia> lista = null;
            try
            {
                IServiceResidencia _ServiceResidencia = new ServiceResidencia();
                lista = _ServiceResidencia.GetResidencia();
                ViewBag.title = "Lista Residencias";
                //Lista Propietarios
                IServiceUsuario _ServiceUsuario = new ServiceUsuario();
                ViewBag.listaUsuarios = _ServiceUsuario.GetUsuario();
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

        // GET: Residencia/Details/5
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
                    TempData["Message"] = "No existe el residencia solicitado";
                    TempData["Redirect"] = "Residencia";
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
                TempData["Redirect"] = "Libro";
                TempData["Redirect-Action"] = "IndexAdmin";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
        private SelectList listPropietarios(int idPropietario = 0)
        {
            IServiceUsuario _ServiceUsuario = new ServiceUsuario();
            IEnumerable<Usuario> lista = _ServiceUsuario.GetUsuario();
            return new SelectList(lista, "Id", "Nombre", idPropietario);
        }

        private SelectList listCondicionResidencia(int condicion = 0)
        {
            IServiceCondicionResidencia _ServiceCondicionResidencia = new ServiceCondicionResidencia();
            IEnumerable<CondicionResidencia> lista = _ServiceCondicionResidencia.GetCondicionResidencia();
            return new SelectList(lista, "Id", "Descripcion", condicion);
        }

        // GET: Residencia/Create
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Create()
        {
            ViewBag.CondicionResidencia = listCondicionResidencia();
            ViewBag.listaUsuarios = listPropietarios();
            return View();
        }

        // POST: Residencia/Create
        //establece la lógica cuando se crea un libro
        [HttpPost]
        public ActionResult Save(Residencia residencia)
        {
            IServiceResidencia _ServiceResidencia = new ServiceResidencia();
            try
            {
                if(ModelState.IsValid)
                {
                    Residencia oResidencia = _ServiceResidencia.Save(residencia);
                }
                else
                {
                    Utils.Util.ValidateErrors(this);
                    ViewBag.CondicionResidencia= listCondicionResidencia(residencia.Condicion);
                    if(residencia.Id > 0)
                    {
                        ViewBag.CondicionResidencia = listCondicionResidencia(residencia.Condicion);
                        ViewBag.listaUsuarios = listPropietarios(residencia.Propietario);
                        //return View("Edit", residencia);
                        return (ActionResult)View("Edit", residencia);
                    }
                    else
                    {
                        ViewBag.CondicionResidencia = listCondicionResidencia(residencia.Condicion);
                        ViewBag.listaUsuarios = listPropietarios(residencia.Propietario);
                        return View("Create", residencia);
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Residencia";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }


        // GET: Residencia/Edit/5
       // [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Edit(int? id)
        {
            IServiceResidencia _ServiceResidencia = new ServiceResidencia();
            Residencia residencia = null;
            try
            {
                if(id== null)
                {
                    return RedirectToAction("Index");
                }
                residencia = _ServiceResidencia.GetResidenciaById(Convert.ToInt32(id));
                if(residencia == null)
                {
                    TempData["Message"] = "No existe el incidente solicitado";
                    TempData["Redirect"] = "Residencia";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                ViewBag.CondicionResidencia = listCondicionResidencia(residencia.Condicion);
                ViewBag.listaUsuarios = listPropietarios(residencia.Propietario);
                return View(residencia);
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

       

        #region Delete
        // GET: Residencia/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Residencia/Delete/5
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
