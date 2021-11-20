using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaGCS.Models;
using System.Web.Mvc;

namespace SistemaGCS.Controllers
{
    public class InformeEstadoController : Controller
    {
        // GET: InformeEstado
        private Orden_Cambio objIE = new Orden_Cambio();
        private Solicitud_Cambios objTipo = new Solicitud_Cambios();
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objIE.Listar());
            }
            else
            {
                return View(objIE.Buscar(criterio));
            }
        }

        public ActionResult Buscar(string criterio)
        {
            return View(criterio == null || criterio == "" ? objIE.Listar() : objIE.Buscar(criterio));

        }
        //METODO AGREGAR ID
        public ActionResult Agregar(int id = 0)
        {
            ViewBag.Tipo = objTipo.Listar();//llenar el combox
            return View(id == 0 ? new Orden_Cambio() : objIE.Obtener(id));
        }

        //METODO GUARDAR
        public ActionResult Guardar(Usuario model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/InformeEstado/Index");
            }
            else
            {
                return View("~/InformeEstado/Agregar");
            }
        }
        //METODO DELETE
        public ActionResult Eliminar(int id)
        {
            objIE.Id_ordencambio = id;
            objIE.Eliminar();
            return Redirect("~/InformeEstado");
        }



    }
}