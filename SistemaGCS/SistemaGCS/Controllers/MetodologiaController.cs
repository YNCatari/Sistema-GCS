using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaGCS.Models;
using System.Web.Mvc;

namespace SistemaGCS.Controllers
{
    public class MetodologiaController : Controller
    {
        // GET: Usuario
        private Metodologia objMetodologia = new Metodologia();
        //private Tipo_Usuario objTipo = new Tipo_Usuario();

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

        public ActionResult Buscar(string criterio)
        {
            return View(criterio == null || criterio == "" ? objMetodologia.Listar() : objMetodologia.Buscar(criterio));

        }
        //METODO AGREGAR ID
        public ActionResult Agregar(int id = 0)
        {
            //ViewBag.Tipo = objTipo.Listar();//llenar el combox
            return View(id == 0 ? new Metodologia() : objMetodologia.Obtener(id));
        }
        //METODO GUARDAR
        public ActionResult Guardar(Metodologia model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Metodologia/index");
            }
            else
            {
                return View("~/Metodologia/Agregar");
            }
        }
        
    }
}