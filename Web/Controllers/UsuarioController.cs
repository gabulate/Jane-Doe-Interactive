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
        [CustomAuthorize((int)Roles.Administrador)]
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
                TempData["Redirect"] = "Usuario";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // GET: Usuario/Details/5
        [CustomAuthorize((int)Roles.Administrador)]
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
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Create()
        {
            ViewBag.vbidTipoUsuario = listTipoUsuario();
            return View();
        }

        private SelectList listTipoUsuario(int valorSeleccionado = 0)
        {
            IServiceTipoUsuario _ServiceTipoUsuario = new ServiceTipoUsuario();
            IEnumerable<TipoUsuario> lista = _ServiceTipoUsuario.GetTipoUsuario();
            return new SelectList(lista, "Id", "Descripcion", valorSeleccionado);
        }

        // POST: Usuario/Create CREAR O ACTUALIZAR
        [HttpPost]
        public ActionResult Save(Usuario usuario)
        {

            IServiceUsuario _ServiceUsuario = new ServiceUsuario();
            try
            {

                //ModelState.Remove("Id");
                //ModelState.Remove("IdTipoUsuario");

                ModelState.Remove("Nombre");
                ModelState.Remove("Apellido");
                ModelState.Remove("Email");
                ModelState.Remove("Cedula");
                ModelState.Remove("Contrasenna");

                if (ModelState.IsValid)
                {
                    Usuario oUsuarioI = _ServiceUsuario.Save(usuario);
                }
                else
                {
                    // Valida Errores si Javascript está deshabilitado
                    Utils.Util.ValidateErrors(this);
                    ViewBag.vbidTipoUsuario = listTipoUsuario(usuario.IdTipoUsuario);
                    //Cargar la vista crear o actualizar
                    //Lógica para cargar vista correspondiente
                    if (usuario.Id > 0)
                    {
                        ViewBag.vbidTipoUsuario = listTipoUsuario(usuario.IdTipoUsuario);
                        return View("Edit", usuario);
                    }
                    else
                    {
                        ViewBag.vbidTipoUsuario = listTipoUsuario(usuario.IdTipoUsuario);
                        return View("Create", usuario);
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }

        }

        // GET: Usuario/Edit/5
        [CustomAuthorize((int)Roles.Administrador)]
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
                ViewBag.vbidTipoUsuario = listTipoUsuario(usuario.IdTipoUsuario);
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

    }
}