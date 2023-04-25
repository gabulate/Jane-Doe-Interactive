using ApplicationCore.Services;
using Infrastructure.Models;
using Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.ViewModel;

namespace Web.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Ingresos()
        {
            return View();
        }

        public ActionResult Deudas()
        {

            IEnumerable<Deuda> lista = null;
            try
            {
                IServiceDeuda _Service = new ServiceDeuda();
                lista = _Service.GetDeudaPendiente();
                ViewBag.title = "Lista Deudas pendientes";

                decimal total = 0;
                foreach(Deuda de in lista)
                {
                    total += (de.PlanCobro.MontoTotal);
                }
                ViewBag.total = total;

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
        public ActionResult graficoOrden()
        {
            
        }
    }
}