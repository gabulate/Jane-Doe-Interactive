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
using Web.Security;

namespace Web.Controllers
{
    public class IncidenteController : Controller
    {
        // GET: Incidente

        public ActionResult Index()
        {
            int idUsuario = 1;
            if (Session["User"] != null)
            {
                Usuario usuario = (Usuario)Session["User"];
                idUsuario = usuario.Id;
            }
            IEnumerable<Incidente> lista = null;
            try
            {
                IServiceIncidente _Servicio = new ServiceIncidente();
                //lista = _Servicio.GetIncidenteByUsuario(1);
                lista = _Servicio.GetIncidenteByUsuario(idUsuario);
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

        [CustomAuthorize((int)Roles.Administrador)]
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

       

        private SelectList listEstados(int IdEstadoIncidente = 0)
        {
            IServiceEstadoIncidente _Service = new ServiceEstadoIncidente();
            IEnumerable<EstadoIncidente> lista = _Service.GetEstadoIncidente();
            return new SelectList(lista, "Id", "Descripcion", IdEstadoIncidente);
        }

        // GET: Incidente/Create
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Create()
        {
            ViewBag.IdEstadoIncidente = listEstados();
            return View();
        }

        // GET: Incidente/Edit/5
        [CustomAuthorize((int)Roles.Administrador)]
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

        [HttpPost]
        public ActionResult Save(Incidente incidente)
        {
            IServiceIncidente _Service = new ServiceIncidente();
            int idUsuario=1;
            if (Session["User"] != null)
            {
                Usuario usuario = (Usuario)Session["User"];
                idUsuario = usuario.Id;
            }
            try
            {
                if (ModelState.IsValid)
                {
                    Incidente oIncidente = _Service.Save(incidente,idUsuario);
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
                //
                //Hay que hacer que si se creó, vuelva al index normal
                //y si se editó que vuelva al IndexMante
                //
                return RedirectToAction("Index");
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

        
    }
}
