using ApplicationCore.Services;
using Infrastructure.Models;
using Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.Security;

namespace Web.Controllers
{
    public class ReservacionController : Controller
    {
        [HttpPost]
        public ActionResult Save(Reservacion reserva)
        {
            IServiceReservacion _Service = new ServiceReservacion();
            try
            {
                ModelState.Remove("Borrado");

                if (ModelState.IsValid)
                {
                    Usuario usuario = (Usuario)Session["User"];
                    Reservacion oReservacion = _Service.Save(reserva, usuario.Id);
                }
                else
                {
                    // Valida Errores si Javascript está deshabilitado
                    Utils.Util.ValidateErrors(this);

                    //Cargar la vista crear o actualizar
                    //Lógica para cargar vista correspondiente
                    if (reserva.Id > 0)
                    {
                        return (ActionResult)View("Edit", reserva);
                    }
                    else
                    {
                        ViewBag.idAreaComun = listAreaComun();
                        return View("Create", reserva);
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                // Redireccion a la captura del Error

                ViewBag.NotificationMessage = Utils.SweetAlertHelper.Mensaje("No se ha podido crear la reservación",
                            ex.Message, Utils.SweetAlertMessageType.error
                            );
                ViewBag.idAreaComun = listAreaComun();
                return View("Create", reserva);
            }
        }

        // GET: Incidente/Create
        public ActionResult Create()
        {
            ViewBag.idAreaComun = listAreaComun();
            return View();
        }
        private SelectList listAreaComun(int IdAreaComun = 0)
        {
            IServiceAreaComun _Service = new ServiceAreaComun();
            IEnumerable<AreaComun> lista = _Service.GetAreaComun();
            return new SelectList(lista, "Id", "Descripcion", IdAreaComun);

        }

        // GET: Reservacion
        public ActionResult Index()
        {
            int idUsuario = 1;
            if (Session["User"] != null)
            {
                Usuario usuario = (Usuario)Session["User"];
                idUsuario = usuario.Id;
            }
            IEnumerable<Reservacion> lista = null;
            try
            {
                IServiceReservacion _Servicio = new ServiceReservacion();
                lista = _Servicio.GetReservacionByUsuario(idUsuario);
                ViewBag.title = "Lista Reservaciones";
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
            IEnumerable<Reservacion> lista = null;
            try
            {
                IServiceReservacion _Servicio = new ServiceReservacion();
                lista = _Servicio.GetReservacion();
                ViewBag.title = "Lista de Reservaciones";
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
    }
}