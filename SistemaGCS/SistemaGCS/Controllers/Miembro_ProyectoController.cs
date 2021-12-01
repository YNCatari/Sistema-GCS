using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaGCS.Models;
namespace SistemaGCS.Controllers
{
    public class Miembro_ProyectoController : Controller
    {
        // GET: Miembro_Proyecto
        private Proyecto objProyecto = new Proyecto();

        private Rol objRol = new Rol();
        private Usuario objUsuario = new Usuario();
        private Miembro_Proyecto objMiembros = new Miembro_Proyecto();

        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objMiembros.Listar());
            }
            else
            {
                return View(objMiembros.Buscar(criterio));
            }

        }
        public ActionResult Agregar(int id = 0)
        {
           
           
            ViewBag.Tipousua = objUsuario.Listar();
            ViewBag.Tiporol = objRol.Listar();
            ViewBag.Tipopro = objProyecto.Listar();

            return View(id == 0 ?new Miembro_Proyecto() : objMiembros.Obtener(id));

        }
        public ActionResult Guardar(Miembro_Proyecto model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Miembro_Proyecto/Index");
            }
            else
            {
                return View("~/Miembro_Proyecto/Agregar");
            }
        }
       



    }
}