using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaGCS.Models;
using System.Web.Mvc;

namespace SistemaGCS.Controllers
{
    public class Cronograma_ElementoController : Controller
    {
        // GET: Usuario
        private Cronograma_Elemento objCronogramaelemento = new Cronograma_Elemento();

        private Proyecto objProyecto = new Proyecto();
        private Elemento_Configuracion objElementoconfiguracion = new Elemento_Configuracion();

        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objCronogramaelemento.Listar());
            }
            else
            {
                return View(objCronogramaelemento.Buscar(criterio));
            }

        }
        public ActionResult Visualizar(int id)
        {
            return View(objCronogramaelemento.Obtener(id));
        }
        public ActionResult Buscar(string criterio)
        {
            return View(criterio == null || criterio == "" ? objCronogramaelemento.Listar() : objCronogramaelemento.Buscar(criterio));

        }

        public ActionResult Agregar(int id = 0)
        {
            ViewBag.Ec = objProyecto.Listar();//llenar el combox
            ViewBag.tipomiembro = objElementoconfiguracion.Listar();//llenar el combox
            return View(id == 0 ? new Cronograma_Elemento() : objCronogramaelemento.Obtener(id));
        }

        public ActionResult Guardar(Cronograma_Elemento model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Cronograma_Elemento/Index");
            }
            else
            {
                return View("~/Cronograma_Elemento/Agregar");
            }
        }



    }
}