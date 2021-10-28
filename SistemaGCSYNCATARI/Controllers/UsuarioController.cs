using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaGCSYNCATARI.Models;

namespace SistemaGCSYNCATARI.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        private Usuario objUsuario = new Usuario();
        private Tipo_Usuario objTipo = new Tipo_Usuario();

        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objUsuario.Listar());
            }
            else
            {
                return View(objUsuario.Buscar(criterio));
            }

        }
        public ActionResult Ver(int id)
        {
            return View(objUsuario.Obtener(id));
        }
        public ActionResult Buscar(string criterio)
        {
            return View(criterio == null || criterio == "" ? objUsuario.Listar() : objUsuario.Buscar(criterio));

        }

        public ActionResult Agregar(int id = 0)
        {
            ViewBag.Tipo = objTipo.Listar();//llenar el combox
            return View(id == 0 ? new Usuario() : objUsuario.Obtener(id));
        }

        public ActionResult Guardar(Usuario model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Usuario/index");
            }
            else
            {
                return View("~/Usuario/Agregar");
            }
        }

    }
}