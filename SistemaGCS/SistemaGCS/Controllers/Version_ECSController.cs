using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaGCS.Models;
using System.Web.Mvc;

namespace SistemaGCS.Controllers
{
    public class VersionECSController : Controller
    {
        // GET: VersionECS
        private Version_ECS objVECS = new Version_ECS();
        private Miembro_Proyecto objMP = new Miembro_Proyecto();
        private Elemento_Configuracion objEC = new Elemento_Configuracion();
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objVECS.Listar());
            }
            else
            {
                return View(objVECS.Buscar(criterio));
            }
        }

        // Action Result Vista
        public ActionResult Ver(int id)
        {
            return View(objVECS.Obtener(id));
        }
        public ActionResult Buscar(string criterio)
        {
            return View(criterio == null || criterio == "" ? objVECS.Listar() : objVECS.Buscar(criterio));
        }

        // Action Result Agregar Vista

        public ActionResult Agregar(int id = 0)
        {
            ViewBag.listaobjMP = objMP.Listar();//llenar el combox
            ViewBag.listaobjEC = objEC.Listar();//llenar el combox
            return View(id == 0 ? new Version_ECS() : objVECS.Obtener(id));
        }

        // Action Result Guardar
        public ActionResult Guardar(Version_ECS model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/VersionECS/Index");
            }
            else
            {
                return View("~/VersionECS/Agregar");
            }
        }
        // Action Result Eliminar
        public ActionResult Eliminar(int id)
        {
            objVECS.Id_version = id;
            objVECS.Eliminar();
            return Redirect("~/VersionECS");
        }
    }
}