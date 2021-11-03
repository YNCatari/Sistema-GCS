using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaGCS.Models;
namespace SistemaGCS.Controllers
{
    public class MetodologiasController : Controller
    {
        // GET: Metodologias
        private Metodologia objMetodologia = new Metodologia();

        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objMetodologia.Listar());
            }
            else
            {
                return View(objMetodologia.Buscar(criterio));
            }
        }
        public ActionResult Ver(int id)
        {
            return View(objMetodologia.Obtener(id));
        }
        public ActionResult Agregar(int id = 0)
        {
            return View(id == 0 ? new Metodologia() : objMetodologia.Obtener(id));
        }

        public ActionResult Guardar(Metodologia model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Metodologias/index");
            }
            else
            {
                return View("~/Metodologias/Agregar");
            }
        }
        public ActionResult Eliminar(int id)
        {
            objMetodologia.Id_metodologia = id;
            objMetodologia.Eliminar();
            return Redirect("~/Metodologias");
        }
    }
}