using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaGCS.Models;
using System.Web.Mvc;

namespace SistemaGCS.Controllers
{
    public class CronogramaController : Controller
    {
        private Proyecto objProyecto = new Proyecto();
        private Cronograma objCronograma = new Cronograma();

        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objCronograma.Listar());
            }
            else
            {
                return View(objCronograma.Buscar(criterio));
            }

        }

        public ActionResult Buscar(string criterio)
        {
            return View(criterio == null || criterio == "" ? objCronograma.Listar() : objCronograma.Buscar(criterio));

        }
        //METODO AGREGAR ID
        public ActionResult Agregar(int id = 0)
        {
            ViewBag.Proyecto = objProyecto.Listar();//llenar el combox
            return View(id == 0 ? new Cronograma() : objCronograma.Obtener(id));
        }
        //METODO GUARDAR
        public ActionResult Guardar(Cronograma model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Cronograma/index");
            }
            else
            {
                return View("~/Cronograma/Agregar");
            }
        }
        //METODO DELETE
        public ActionResult Eliminar(int id)
        {
            objCronograma.Id_cronograma = id;
            objCronograma.Eliminar();
            return Redirect("~/Cronograma");
        }
    }
}