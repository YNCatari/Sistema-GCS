using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaGCS.Models;
using System.Web.Mvc;

namespace SistemaGCS.Controllers
{
    public class Elemento_ConfiguracionController : Controller
    {
        // GET: Usuario
        private Elemento_Configuracion objElementoConfiguracion = new Elemento_Configuracion();

        private Fase objFase = new Fase();
        private Cronograma_Elemento objCE = new Cronograma_Elemento();

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

        public ActionResult Buscar(string criterio)
        {
            return View(criterio == null || criterio == "" ? objElementoConfiguracion.Listar() : objElementoConfiguracion.Buscar(criterio));

        }
        //METODO AGREGAR ID
        public ActionResult Agregar(int id = 0)
        {
            ViewBag.Fase = objFase.Listar();//llenar el combox
            ViewBag.CE = objCE.Listar();//llenar el combox

            return View(id == 0 ? new Elemento_Configuracion() : objElementoConfiguracion.Obtener(id));
        }
        //METODO GUARDAR
        public ActionResult Guardar(Elemento_Configuracion model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Elemento_Configuracion/Index");
            }
            else
            {
                return View("~/Elemento_Configuracion/Agregar");
            }
        }
        
        
    }
}