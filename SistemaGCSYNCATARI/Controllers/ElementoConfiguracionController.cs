using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaGCSYNCATARI.Models;

namespace SistemaGCSYNCATARI.Controllers
{
    public class ElementoConfiguracionController : Controller
    {
        // GET: ElementoConfiguracion
        private Elemento_Configuracion objElementoConfiguracion = new Elemento_Configuracion();
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objElementoConfiguracion.Listar());
            }
            else
            {
                return View(objElementoConfiguracion.Buscar(criterio));
            }
        }
        public ActionResult Ver(int id)
        {
            return View(objElementoConfiguracion.Obtener(id));
        }
        public ActionResult Agregar(int id = 0)
        {
            return View(id == 0 ? new Elemento_Configuracion() : objElementoConfiguracion.Obtener(id));
        }

        public ActionResult Guardar(Elemento_Configuracion model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/ElementoConfiguracion/index");
            }
            else
            {
                return View("~/ElementoConfiguracion/Agregar");
            }
        }
        public ActionResult Eliminar(int id)
        {
            objElementoConfiguracion.Id_elementoconfiguracion = id;
            objElementoConfiguracion.Eliminar();
            return Redirect("~/ElementoConfiguracion");
        }
    }
}