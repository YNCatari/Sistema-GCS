using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaGCS.Models;
using System.Web.Mvc;

namespace SistemaGCS.Controllers
{
    public class Version_ECSController : Controller
    {
        // GET: Usuario
        private Version_ECS objVersion = new Version_ECS();

        private Elemento_Configuracion objEC = new Elemento_Configuracion();
        private Miembro_Proyecto objMiembro = new Miembro_Proyecto();

        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objVersion.Listar());
            }
            else
            {
                return View(objVersion.Buscar(criterio));
            }

        }
        public ActionResult Visualizar(int id)
        {
            return View(objVersion.Obtener(id));
        }
        public ActionResult Buscar(string criterio)
        {
            return View(criterio == null || criterio == "" ? objVersion.Listar() : objVersion.Buscar(criterio));

        }

        public ActionResult Agregar(int id = 0)
        {
            ViewBag.Ec = objEC.Listar();//llenar el combox
            ViewBag.tipomiembro = objMiembro.Listar();//llenar el combox
            return View(id == 0 ? new Version_ECS() : objVersion.Obtener(id));
        }

        public ActionResult Guardar(Version_ECS model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Version_ECS/Index");
            }
            else
            {
                return View("~/Version_ECS/Agregar");
            }
        }

        
    }
}