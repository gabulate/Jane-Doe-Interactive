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
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            IEnumerable<Usuario> lista = null;
            try
            {
                IServiceUsuario _ServiceUsuario = new ServiceUsuario();
                lista = _ServiceUsuario.GetUsuario();
                ViewBag.title = "Lista Usuarios";
                //return View(lista);
                //Lista TipoUsuario
                IServiceTipoUsuario _ServiceTipoUsuario = new ServiceTipoUsuario();
                ViewBag.listTipoUsuarios = _ServiceTipoUsuario.GetTipoUsuario();
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

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            IServiceUsuario _ServiceUsuario = new ServiceUsuario();
            Usuario usuario = null;
            try
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                usuario = _ServiceUsuario.GetUsuarioById(Convert.ToInt32(id));
                if (usuario == null)
                {
                    TempData["Message"] = "No existe el libro solicitado";
                    TempData["Redirect"] = "Usuario";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                return View(usuario);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Usuario";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.idTipoUsuario = listTipoUsuario();
            return View();
        }

        private SelectList listTipoUsuario(int idTipoUsuario = 0)
        {
            IServiceTipoUsuario _ServiceTipoUsuario = new ServiceTipoUsuario();
            IEnumerable<TipoUsuario> lista = _ServiceTipoUsuario.GetTipoUsuario();
            return new SelectList(lista, "Id", "Descripcion", idTipoUsuario);
        }

        // POST: Usuario/Create CREAR O ACTUALIZAR
        [HttpPost]
        public ActionResult Save(Usuario usuario)
        {

            IServiceUsuario _ServiceUsuario = new ServiceUsuario();
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario oUsuarioI = _ServiceUsuario.Save(usuario);
                }
                else
                {
                    // Valida Errores si Javascript está deshabilitado
                    Utils.Util.ValidateErrors(this);
                    ViewBag.idTipoUsuario = listTipoUsuario(usuario.IdTipoUsuario);
                    //Cargar la vista crear o actualizar
                    //Lógica para cargar vista correspondiente
                    if (usuario.Id > 0)
                    {
                        ViewBag.idTipoUsuario = listTipoUsuario(usuario.IdTipoUsuario);
                        return View("Edit", usuario);
                    }
                    else
                    {
                        ViewBag.idTipoUsuario = listTipoUsuario(usuario.IdTipoUsuario);
                        return View("Create", usuario);
                    }
                }
                return RedirectToAction("Index");
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

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            IServiceUsuario _ServiceUsuario = new ServiceUsuario();
            Usuario usuario = null;
            try
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                usuario = _ServiceUsuario.GetUsuarioById(Convert.ToInt32(id));
                if (usuario == null)
                {
                    TempData["Message"] = "No existe el rubro solicitado";
                    TempData["Redirect"] = "Usuario";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                return View(usuario);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Usuario";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        #region delete
        // GET: Usuario/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Usuario/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        #endregion
    }
}