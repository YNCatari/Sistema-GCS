using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaGCS.Models;
namespace SistemaGCS.Controllers
{
    public class FaseController : Controller
    {
        // GET: Fase
        private Fase objFase = new Fase();
        private Metodologia objTipo = new Metodologia();

        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objFase.Listar());
            }
            else
            {
                return View(objFase.Buscar(criterio));
            }

        }
        // Action Result Vista
        public ActionResult Ver(int id)
        {
            return View(objFase.Obtener(id));
        }
        public ActionResult Buscar(string criterio)
        {
            return View(criterio == null || criterio == "" ? objFase.Listar() : objFase.Buscar(criterio));

        }
        // Action Result Agregar Vista
        public ActionResult Agregar(int id = 0)
        {
            ViewBag.Tipo = objTipo.Listar();//llenar el combox
            return View(id == 0 ? new Fase() : objFase.Obtener(id));
        }
        // Action Result Guardar
        public ActionResult Guardar(Fase model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Fase/index");
            }
            else
            {
                return View("~/Fase/Agregar");
            }
        }
        // Action Result Eliminar
        public ActionResult Eliminar(int id)
        {
            objFase.Id_fase = id;
            objFase.Eliminar();
            return Redirect("~/Fase");
        }
    }
}