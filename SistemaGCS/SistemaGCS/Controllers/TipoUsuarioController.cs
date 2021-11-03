using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaGCS.Models;
namespace SistemaGCS.Controllers
{
    public class TipoUsuarioController : Controller
    {
        // GET: TipoUsuario
        private Tipo_Usuario objTipoUsuario = new Tipo_Usuario();
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objTipoUsuario.Listar());
            }
            else
            {
                return View(objTipoUsuario.Buscar(criterio));
            }
        }
        
        public ActionResult Agregar(int id = 0)
        {
            return View(id == 0 ? new Tipo_Usuario() : objTipoUsuario.Obtener(id));
        }

        public ActionResult Guardar(Tipo_Usuario model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/TipoUsuario/index");
            }
            else
            {
                return View("~/TipoUsuario/Agregar");
            }
        }
        //METODO DELETE
        public ActionResult Eliminar(int id)
        {
            objTipoUsuario.Id_tipousuario = id;
            objTipoUsuario.Eliminar();
            return Redirect("~/TipoUsuario");
        }
    }
}